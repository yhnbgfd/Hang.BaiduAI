using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        private void button_Start_Click(object sender, EventArgs e)
        {
            var apiKey = this.textBox_apiKey.Text.Trim();
            var secretKey = this.textBox_secretKey.Text.Trim();

            FaceApi faceApi = new FaceApi();
            faceApi.Init(apiKey, secretKey);

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
                            var image2 = Convert.ToBase64String(File.ReadAllBytes(this.textBox_idCardPath.Text.Trim()));

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
    }
}
