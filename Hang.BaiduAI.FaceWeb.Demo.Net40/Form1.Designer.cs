namespace Hang.BaiduAI.FaceWeb.Demo.Net40
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VideoPlayer = new AForge.Controls.VideoSourcePlayer();
            this.textBox_apiKey = new System.Windows.Forms.TextBox();
            this.textBox_secretKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_idCardPath = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VideoPlayer
            // 
            this.VideoPlayer.Location = new System.Drawing.Point(12, 12);
            this.VideoPlayer.Name = "VideoPlayer";
            this.VideoPlayer.Size = new System.Drawing.Size(640, 480);
            this.VideoPlayer.TabIndex = 9;
            this.VideoPlayer.Text = "videoSourcePlayer1";
            this.VideoPlayer.VideoSource = null;
            this.VideoPlayer.Paint += new System.Windows.Forms.PaintEventHandler(this.VideoPlayer_Paint);
            // 
            // textBox_apiKey
            // 
            this.textBox_apiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_apiKey.Location = new System.Drawing.Point(658, 27);
            this.textBox_apiKey.Name = "textBox_apiKey";
            this.textBox_apiKey.Size = new System.Drawing.Size(227, 21);
            this.textBox_apiKey.TabIndex = 10;
            // 
            // textBox_secretKey
            // 
            this.textBox_secretKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_secretKey.Location = new System.Drawing.Point(658, 66);
            this.textBox_secretKey.Name = "textBox_secretKey";
            this.textBox_secretKey.Size = new System.Drawing.Size(227, 21);
            this.textBox_secretKey.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "API Key";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(658, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Secret Key";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(658, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "证件照路径";
            // 
            // textBox_idCardPath
            // 
            this.textBox_idCardPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_idCardPath.Location = new System.Drawing.Point(658, 105);
            this.textBox_idCardPath.Name = "textBox_idCardPath";
            this.textBox_idCardPath.Size = new System.Drawing.Size(227, 21);
            this.textBox_idCardPath.TabIndex = 15;
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Location = new System.Drawing.Point(740, 132);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 16;
            this.button_Start.Text = "启动";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // textBox_log
            // 
            this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_log.Location = new System.Drawing.Point(658, 198);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(227, 294);
            this.textBox_log.TabIndex = 17;
            this.textBox_log.WordWrap = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "日志";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 504);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_idCardPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_secretKey);
            this.Controls.Add(this.textBox_apiKey);
            this.Controls.Add(this.VideoPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Hang.BaiduAI.FaceWeb.Demo.Net40";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer VideoPlayer;
        private System.Windows.Forms.TextBox textBox_apiKey;
        private System.Windows.Forms.TextBox textBox_secretKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_idCardPath;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Label label4;
    }
}

