namespace HNCDataCollection
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.topicTxt = new System.Windows.Forms.TextBox();
            this.topicLabel = new System.Windows.Forms.Label();
            this.kafkaPortTxt = new System.Windows.Forms.TextBox();
            this.kafkaIPTxt = new System.Windows.Forms.TextBox();
            this.kafkaPortLabel = new System.Windows.Forms.Label();
            this.kafkaIPLabel = new System.Windows.Forms.Label();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.cncIPTxt = new System.Windows.Forms.TextBox();
            this.disconnBtn = new System.Windows.Forms.Button();
            this.connBtn = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.cncIPLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.axisLoadLabel = new System.Windows.Forms.Label();
            this.axisInfoLabel = new System.Windows.Forms.Label();
            this.cycleStopBtn = new System.Windows.Forms.Button();
            this.cycleCollectBtn = new System.Windows.Forms.Button();
            this.previewBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.topicTxt);
            this.groupBox1.Controls.Add(this.topicLabel);
            this.groupBox1.Controls.Add(this.kafkaPortTxt);
            this.groupBox1.Controls.Add(this.kafkaIPTxt);
            this.groupBox1.Controls.Add(this.kafkaPortLabel);
            this.groupBox1.Controls.Add(this.kafkaIPLabel);
            this.groupBox1.Controls.Add(this.portTxt);
            this.groupBox1.Controls.Add(this.cncIPTxt);
            this.groupBox1.Controls.Add(this.disconnBtn);
            this.groupBox1.Controls.Add(this.connBtn);
            this.groupBox1.Controls.Add(this.portLabel);
            this.groupBox1.Controls.Add(this.cncIPLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接";
            // 
            // topicTxt
            // 
            this.topicTxt.Location = new System.Drawing.Point(318, 60);
            this.topicTxt.Name = "topicTxt";
            this.topicTxt.Size = new System.Drawing.Size(39, 21);
            this.topicTxt.TabIndex = 11;
            this.topicTxt.Text = "hnc";
            // 
            // topicLabel
            // 
            this.topicLabel.AutoSize = true;
            this.topicLabel.Location = new System.Drawing.Point(283, 64);
            this.topicLabel.Name = "topicLabel";
            this.topicLabel.Size = new System.Drawing.Size(35, 12);
            this.topicLabel.TabIndex = 10;
            this.topicLabel.Text = "topic";
            // 
            // kafkaPortTxt
            // 
            this.kafkaPortTxt.Location = new System.Drawing.Point(219, 60);
            this.kafkaPortTxt.Name = "kafkaPortTxt";
            this.kafkaPortTxt.Size = new System.Drawing.Size(39, 21);
            this.kafkaPortTxt.TabIndex = 9;
            this.kafkaPortTxt.Text = "9092";
            // 
            // kafkaIPTxt
            // 
            this.kafkaIPTxt.Location = new System.Drawing.Point(74, 60);
            this.kafkaIPTxt.Name = "kafkaIPTxt";
            this.kafkaIPTxt.Size = new System.Drawing.Size(92, 21);
            this.kafkaIPTxt.TabIndex = 8;
            this.kafkaIPTxt.Text = "192.168.1.105";
            // 
            // kafkaPortLabel
            // 
            this.kafkaPortLabel.AutoSize = true;
            this.kafkaPortLabel.Location = new System.Drawing.Point(184, 64);
            this.kafkaPortLabel.Name = "kafkaPortLabel";
            this.kafkaPortLabel.Size = new System.Drawing.Size(29, 12);
            this.kafkaPortLabel.TabIndex = 7;
            this.kafkaPortLabel.Text = "端口";
            // 
            // kafkaIPLabel
            // 
            this.kafkaIPLabel.AutoSize = true;
            this.kafkaIPLabel.Location = new System.Drawing.Point(8, 64);
            this.kafkaIPLabel.Name = "kafkaIPLabel";
            this.kafkaIPLabel.Size = new System.Drawing.Size(59, 12);
            this.kafkaIPLabel.TabIndex = 6;
            this.kafkaIPLabel.Text = "Kafka地址";
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(219, 20);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(39, 21);
            this.portTxt.TabIndex = 5;
            this.portTxt.Text = "10001";
            // 
            // cncIPTxt
            // 
            this.cncIPTxt.Location = new System.Drawing.Point(74, 20);
            this.cncIPTxt.Name = "cncIPTxt";
            this.cncIPTxt.Size = new System.Drawing.Size(92, 21);
            this.cncIPTxt.TabIndex = 4;
            this.cncIPTxt.Text = "192.168.1.175";
            // 
            // disconnBtn
            // 
            this.disconnBtn.Location = new System.Drawing.Point(377, 16);
            this.disconnBtn.Name = "disconnBtn";
            this.disconnBtn.Size = new System.Drawing.Size(75, 23);
            this.disconnBtn.TabIndex = 3;
            this.disconnBtn.Text = "断开";
            this.disconnBtn.UseVisualStyleBackColor = true;
            this.disconnBtn.Click += new System.EventHandler(this.DisconnBtn_Click);
            // 
            // connBtn
            // 
            this.connBtn.Location = new System.Drawing.Point(282, 16);
            this.connBtn.Name = "connBtn";
            this.connBtn.Size = new System.Drawing.Size(75, 23);
            this.connBtn.TabIndex = 2;
            this.connBtn.Text = "连接";
            this.connBtn.UseVisualStyleBackColor = true;
            this.connBtn.Click += new System.EventHandler(this.ConnBtn_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(184, 24);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 12);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "端口";
            // 
            // cncIPLabel
            // 
            this.cncIPLabel.AutoSize = true;
            this.cncIPLabel.Location = new System.Drawing.Point(8, 24);
            this.cncIPLabel.Name = "cncIPLabel";
            this.cncIPLabel.Size = new System.Drawing.Size(47, 12);
            this.cncIPLabel.TabIndex = 0;
            this.cncIPLabel.Text = "CNC地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.axisLoadLabel);
            this.groupBox2.Controls.Add(this.axisInfoLabel);
            this.groupBox2.Controls.Add(this.cycleStopBtn);
            this.groupBox2.Controls.Add(this.cycleCollectBtn);
            this.groupBox2.Controls.Add(this.previewBtn);
            this.groupBox2.Location = new System.Drawing.Point(13, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 254);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轴信息";
            // 
            // axisLoadLabel
            // 
            this.axisLoadLabel.AutoSize = true;
            this.axisLoadLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.axisLoadLabel.Location = new System.Drawing.Point(257, 42);
            this.axisLoadLabel.Name = "axisLoadLabel";
            this.axisLoadLabel.Size = new System.Drawing.Size(24, 27);
            this.axisLoadLabel.TabIndex = 5;
            this.axisLoadLabel.Text = "0";
            this.axisLoadLabel.Click += new System.EventHandler(this.axisLoadLabel_Click);
            // 
            // axisInfoLabel
            // 
            this.axisInfoLabel.AutoSize = true;
            this.axisInfoLabel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.axisInfoLabel.Location = new System.Drawing.Point(26, 42);
            this.axisInfoLabel.Name = "axisInfoLabel";
            this.axisInfoLabel.Size = new System.Drawing.Size(28, 31);
            this.axisInfoLabel.TabIndex = 4;
            this.axisInfoLabel.Text = "0";
            // 
            // cycleStopBtn
            // 
            this.cycleStopBtn.Location = new System.Drawing.Point(433, 225);
            this.cycleStopBtn.Name = "cycleStopBtn";
            this.cycleStopBtn.Size = new System.Drawing.Size(75, 23);
            this.cycleStopBtn.TabIndex = 3;
            this.cycleStopBtn.Text = "停止采集";
            this.cycleStopBtn.UseVisualStyleBackColor = true;
            this.cycleStopBtn.Click += new System.EventHandler(this.CycleStopBtn_Click);
            // 
            // cycleCollectBtn
            // 
            this.cycleCollectBtn.Location = new System.Drawing.Point(348, 225);
            this.cycleCollectBtn.Name = "cycleCollectBtn";
            this.cycleCollectBtn.Size = new System.Drawing.Size(75, 23);
            this.cycleCollectBtn.TabIndex = 2;
            this.cycleCollectBtn.Text = "循环采集";
            this.cycleCollectBtn.UseVisualStyleBackColor = true;
            this.cycleCollectBtn.Click += new System.EventHandler(this.CycleCollectBtn_Click);
            // 
            // previewBtn
            // 
            this.previewBtn.Location = new System.Drawing.Point(263, 225);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(75, 23);
            this.previewBtn.TabIndex = 1;
            this.previewBtn.Text = "预览数据";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 386);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.TextBox cncIPTxt;
        private System.Windows.Forms.Button disconnBtn;
        private System.Windows.Forms.Button connBtn;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label cncIPLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cycleStopBtn;
        private System.Windows.Forms.Button cycleCollectBtn;
        private System.Windows.Forms.Button previewBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label axisInfoLabel;
        private System.Windows.Forms.TextBox kafkaPortTxt;
        private System.Windows.Forms.TextBox kafkaIPTxt;
        private System.Windows.Forms.Label kafkaPortLabel;
        private System.Windows.Forms.Label kafkaIPLabel;
        private System.Windows.Forms.TextBox topicTxt;
        private System.Windows.Forms.Label topicLabel;
        private System.Windows.Forms.Label axisLoadLabel;
    }
}

