using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Hang.BaiduAI.Face.Demo.Net40
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var str = OfflineSDKWrapper.get_device_id();

            var ptr = OfflineSDKWrapper.match("D:\\Temp\\1.bmp", 2, "D:\\Temp\\oneFace.bmp", 2);
            var ss = Marshal.PtrToStringAnsi(ptr);
        }
    }
}
