using AForge.Video.DirectShow;
using Hang.BaiduAI.FaceWeb.Demo.Net40.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hang.BaiduAI.FaceWeb.Demo.Net40
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox_apiKey.Text = Settings.Default.apiKey;
            this.textBox_secretKey.Text = Settings.Default.secretKey;
            this.textBox_idCardPath.Text = Settings.Default.idCardPath;

            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)//没有检测到摄像头
            {
                MessageBox.Show("没有检测到摄像头");
                return;
            }

            var videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.VideoResolution = videoSource.VideoCapabilities[0];//0是推荐分辨率
            this.VideoPlayer.VideoSource = videoSource;
            this.VideoPlayer.Start();
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            Settings.Default.apiKey = this.textBox_apiKey.Text.Trim();
            Settings.Default.secretKey = this.textBox_secretKey.Text.Trim();
            Settings.Default.idCardPath = this.textBox_idCardPath.Text.Trim();
            Settings.Default.Save();

            FaceApi faceApi = new FaceApi();
            faceApi.Init(Settings.Default.apiKey, Settings.Default.secretKey);

            // 定时截屏比对
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (_cts.IsCancellationRequested)
                        break;

                    try
                    {
                        var img = this.VideoPlayer.GetCurrentVideoFrame();
                        if (img != null)
                        {
                            var image1 = Convert.ToBase64String((byte[])new ImageConverter().ConvertTo(img, typeof(byte[])));
                            img.Dispose();
                            var image2 = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.idCardPath));

                            var result1 = faceApi.Detect(image1);
                            var result2 = faceApi.Match(image1, image2);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        Thread.Sleep(500);
                    }
                }
            }, _cts.Token);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cts.Cancel();

            if (this.VideoPlayer.IsRunning)
            {
                this.VideoPlayer.Stop();
            }
            this.VideoPlayer.Dispose();
        }

        private void VideoPlayer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
