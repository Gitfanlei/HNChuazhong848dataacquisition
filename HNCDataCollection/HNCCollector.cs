using HNCAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCDataCollection
{
    class HNCCollector
    {
        private static Int16 ActiveClientNo = -1;
        private string cncIp;
        private ushort cncPort;
        
        public bool StateOK = false;

        public string[] AxisValueInfo = new string[32];
        public Int32 AxisNum = -1;
        public string[] axisName = new string[32];
        public HNCPayload hncPayload;

        private const Int32 AxisTypesCount = 9;
        private const UInt32 AxisDisplayX = 0x00000001;//单位：毫米
        private Int32 mch = 0;
        private Int32[] axisId = new Int32[32];
        private Int32[] axisValue = new Int32[32];
        public Double[] loadValue = new Double[32];

        public HNCCollector(string cncIp, ushort cncPort)
        {
            this.cncIp = cncIp;
            this.cncPort = cncPort;
        }

        // 建立连接
        public bool Connect_CNC()
        {
            ActiveClientNo = HncApi.HNC_NetConnect(cncIp, cncPort);
            if ((ActiveClientNo < 0) || (ActiveClientNo >= 255)) return false;
            else { StateOK = true; return true; }
        }

        public void Disconnect_CNC()
        {
            HncApi.HNC_NetExit();
            StateOK = false;
            ActiveClientNo = -1;
        }

        public void GetAxisInfo()
        {
            // 确定活动的通道 并获取 网络号
            Int32 ret = HncApi.HNC_SystemGetValue((Int32)HncSystem.HNC_SYS_ACTIVE_CHAN, ref mch, ActiveClientNo);
            UInt32 AxisMask = AcquireAxisType(mch, ref AxisNum, ActiveClientNo);

            AxisInfoGotItems(AxisMask, ref axisName, ref axisId, ref axisValue,ref loadValue, ActiveClientNo);//获取轴名、ID

            GetAxisStrInfo(AxisNum, axisId, axisValue, ref AxisValueInfo);

            hncPayload = new HNCPayload
            {
                ID = "1",
                IP = $"{cncIp}:{cncPort}",
                Name = "HNC1",
                TimeStamp = DateTime.Now,
                PositionInfo = new HNCPositionData
                {
                    Ax_1 = $"{axisName[0]}:{axisValue[0]}",
                    Ax_2 = $"{axisName[1]}:{AxisValueInfo[1]}",
                    Ax_3 = $"{axisName[2]}:{AxisValueInfo[2]}",
                    Ax_4 = $"{axisName[3]}:{AxisValueInfo[3]}",
                    Ax_5 = $"{axisName[4]}:{AxisValueInfo[4]}"
                },
                LoadDataInfo = new HNCLoadData
                {
                    AxLoad_1 = $"{axisName[0]}:{loadValue[0].ToString("f6")}",
                    AxLoad_2 = $"{axisName[1]}:{loadValue[1].ToString("f6")}",
                    AxLoad_3 = $"{axisName[2]}:{loadValue[2].ToString("f6")}",
                    AxLoad_4 = $"{axisName[3]}:{loadValue[3].ToString("f6")}",
                    AxLoad_5 = $"{axisName[4]}:{loadValue[4].ToString("f6")}"
                }
            };


        }

        private UInt32 AcquireAxisType(Int32 ch, ref Int32 axisnum, Int16 clientNo)
        {
            Int32 mask = 0;

            HncApi.HNC_ChannelGetValue((int)HncChannel.HNC_CHAN_AXES_MASK, ch, 0, ref mask, clientNo);  // 类型-通道号-索引号-值-连接号
            Int32 num = 0;

            for (Int32 i = 0; i < AxisTypesCount; i++)
            {
                if (((AxisDisplayX << i) & mask) != 0)
                    num++;
            }
            axisnum = num;
            return (UInt32)mask;
        }

        // 获取变量值
        public bool AxisInfoGotItems(UInt32 AxisMask, ref string[] AxisName, ref Int32[] AxisId, ref Int32[] axisValue,ref Double[] loadValue, Int16 clientNo)
        {
            bool flag = true;

            Int32 index = 0;
            Int32 ret = 0;
            if (AxisMask == 0)
            {
                flag = false;
                return flag;
            }

            // 获取轴数据
            for (Int32 i = 0; i < AxisTypesCount; i++)
            {
                if ((AxisMask >> i & 1) == 1)
                {
                    ret += HncApi.HNC_AxisGetValue((int)HncAxis.HNC_AXIS_NAME, i, ref AxisName[index], clientNo);
                    AxisId[index] = i;
                    ret += HncApi.HNC_AxisGetValue((Int32)HncAxis.HNC_AXIS_ACT_POS, AxisId[index], ref axisValue[index], ActiveClientNo);

                    // 获取负载电流
                    ret += HncApi.HNC_AxisGetValue((Int32)HncAxis.HNC_AXIS_LOAD_CUR, AxisId[index], ref loadValue[index], ActiveClientNo);
                    index++;
                    if (ret != 0)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }

        private void GetAxisStrInfo(int count, Int32[] AxisId, Int32[] axisValue, ref string[] AxisValueInfo)
        {
            Int32 ret = 0;
            Int32 lax = 0;
            Int32 axistype = 0;
            Int32 metric = 0;
            Int32 unit = 100000;
            Int32 diameter = 0;
            for (int i = 0; i < count; i++)
            {
                ret = HncApi.HNC_ChannelGetValue((int)HncChannel.HNC_CHAN_LAX, mch, AxisId[i], ref lax, ActiveClientNo);
                // 直半径处理
                ret = HncApi.HNC_ChannelGetValue((int)HncChannel.HNC_CHAN_DIAMETER, mch, 0, ref diameter, ActiveClientNo);
                if (0 == lax && 1 == diameter)
                {
                    axisValue[i] *= 2;
                }
                ret = HncApi.HNC_AxisGetValue((int)HncAxis.HNC_AXIS_TYPE, lax, ref axistype, ActiveClientNo);
                if (axistype == 1)//直线轴
                {
                    ret = HncApi.HNC_SystemGetValue((int)HncSystem.HNC_SYS_MOVE_UNIT, ref unit, ActiveClientNo);
                    ret = HncApi.HNC_SystemGetValue((int)HncSystem.HNC_SYS_METRIC_DISP, ref metric, ActiveClientNo);
                    if (0 == metric) // 英制
                        unit = (Int32)(unit * 25.4);
                }
                else
                {
                    ret = HncApi.HNC_SystemGetValue((int)HncSystem.HNC_SYS_TURN_UNIT, ref unit, ActiveClientNo);
                }

                if (Math.Abs(unit) - 0.00001 <= 0.0) //除零保护
                {
                    AxisValueInfo[i] = "0";
                }
                else
                {
                    AxisValueInfo[i] = ((double)axisValue[i] / unit).ToString("F4"); // 实际输出的轴的位置   单位换算
                }

                if (axistype == 1)
                {
                    if (0 == metric) // 英制
                    {
                        AxisValueInfo[i] += " inch";
                    }
                    else
                    {
                        AxisValueInfo[i] += " mm";
                    }
                }
                else
                {
                    AxisValueInfo[i] += " D";
                }
            }
        }
    }
}
