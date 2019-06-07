using System;
using System.Net;
using System.Windows.Forms;
using HNCAPI;
using Newtonsoft.Json;

namespace HNCDataCollection
{
    public partial class Form1 : Form
    {
        private UInt16 localPort = 10001;

        private KafkaProducer kafkaProducer;
        private HNCCollector hncCollector;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowMsgBox(HncApi.HNC_NetInit(GetLocalIpAddr(), localPort) == 0 ? true : false, "初始化");
        }

        private void ConnBtn_Click(object sender, EventArgs e)
        {
            kafkaProducer = new KafkaProducer($"{kafkaIPTxt.Text}:{kafkaPortTxt.Text}", topicTxt.Text);
            hncCollector = new HNCCollector(cncIPTxt.Text, Convert.ToUInt16(portTxt.Text));
            ShowMsgBox(hncCollector.Connect_CNC(), "连接");
        }

        private void DisconnBtn_Click(object sender, EventArgs e)
        {
            hncCollector.Disconnect_CNC();
            timer1.Enabled = false;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            hncCollector.Disconnect_CNC();
            timer1.Enabled = false;
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (!hncCollector.StateOK) MessageBox.Show("请先连接！");
            else PreviewAxisInfo();
        }

        private void PreviewAxisInfo()
        {
            string axisInfo = "";
            for (int i = 0; i < hncCollector.AxisNum; i++)
            {
                axisInfo += hncCollector.axisName[i];
                axisInfo += ": ";
                axisInfo += hncCollector.AxisValueInfo[i];
                axisInfo += "\n";
            }
            axisInfoLabel.Text = axisInfo;

            // 输出采集的负载电流
            string loadInfo = "";
            for (int i = 0; i < hncCollector.AxisNum; i++)
            {
                loadInfo += hncCollector.axisName[i];
                loadInfo += "_loadValue: ";
                loadInfo += hncCollector.loadValue[i].ToString("f6");
                loadInfo += "\n";
            }
            axisLoadLabel.Text = loadInfo;
        }

        private void CycleCollectBtn_Click(object sender, EventArgs e)
        {
            if (!hncCollector.StateOK) MessageBox.Show("请先连接！");
            else
            {
                timer1.Start();
                cycleCollectBtn.Text = "采集中...";
                cycleCollectBtn.Enabled = false;
            }
        }

        private void CycleStopBtn_Click(object sender, EventArgs e)
        {
            if (!hncCollector.StateOK) MessageBox.Show("请先连接！");
            else
            {
                timer1.Stop();
                cycleCollectBtn.Text = "循环采集";
                cycleCollectBtn.Enabled = true;
            }
        }
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            hncCollector.GetAxisInfo();
            PreviewAxisInfo();
            WriteAxisInfo();
        }

        // kafka消息传输
        private void WriteAxisInfo()
        {
            string HNCPositionJson = JsonConvert.SerializeObject(hncCollector.hncPayload);
            var kafkaTopicOffset = kafkaProducer.ProduceToKafka(HNCPositionJson);
        }

        public static string GetLocalIpAddr()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry localHost = Dns.GetHostEntry(hostName);
            IPAddress localIpAddr = null;
            foreach (IPAddress ip in localHost.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                    && ip.ToString().StartsWith("192.168"))
                {
                    localIpAddr = ip;
                    break;
                }
            }
            return localIpAddr.ToString();
        }

        private void ShowMsgBox(bool flag, string msg)
        {
            if (flag) MessageBox.Show($"{msg}成功！");
            else MessageBox.Show($"{msg}失败！");
        }

        private void axisLoadLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
