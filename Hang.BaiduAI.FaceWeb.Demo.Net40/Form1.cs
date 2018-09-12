using AForge.Video.DirectShow;
using Hang.BaiduAI.FaceWeb.Demo.Net40.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hang.BaiduAI.FaceWeb.Demo.Net40
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private delegate void LogInvoke(string str);
        private DetectResult _detectResult;

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
                LogInvoke li = new LogInvoke(WriteLog);
                while (true)
                {
                    if (_cts.IsCancellationRequested)
                    {
                        break;
                    }

                    try
                    {
                        var img = this.VideoPlayer.GetCurrentVideoFrame();
                        if (img != null)
                        {
                            var image1 = Convert.ToBase64String((byte[])new ImageConverter().ConvertTo(img, typeof(byte[])));
                            img.Dispose();
                            var image2 = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.idCardPath));

                            _detectResult = faceApi.Detect(image1);
                            if (_detectResult.error_code == 0)
                            {
                                BeginInvoke(li, new object[] { $"人脸数量：{_detectResult.result.face_num}" });

                                var result2 = faceApi.Match(image1, image2);
                                if (result2.error_code == 0)
                                {
                                    BeginInvoke(li, new object[] { $"比对分数：{result2.result.score}" });
                                }
                                else
                                {
                                    BeginInvoke(li, new object[] { $"比对分数：{result2.error_msg}" });
                                }
                            }
                            else
                            {
                                BeginInvoke(li, new object[] { $"人脸数量：{_detectResult.error_msg}" });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        BeginInvoke(li, new object[] { ex.Message });
                    }
                    finally
                    {
                        Thread.Sleep(100);
                    }
                }
            }, _cts.Token);

            WriteLog("启动完成");
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
            try
            {
                var list = _detectResult.result.face_list.ToArray();
                for (int i = 0; i < _detectResult.result.face_num; i++)
                {
                    var rect = new Rectangle((int)list[i].location.left, (int)list[i].location.top, list[i].location.width, list[i].location.height);
                    e.Graphics.DrawRectangle(Pens.Green, rect);
                }
            }
            catch
            {
            }
        }

        public void WriteLog(string str)
        {
            this.textBox_log.Text = str + Environment.NewLine + this.textBox_log.Text;
        }

    }
}
