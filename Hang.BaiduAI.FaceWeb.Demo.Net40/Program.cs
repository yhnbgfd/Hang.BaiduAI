using System;
using System.Windows.Forms;

namespace Hang.BaiduAI.FaceWeb.Demo.Net40
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
