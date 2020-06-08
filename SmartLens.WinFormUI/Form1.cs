using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLens.WinFormUI
{
    public partial class Form1 : Form
    {
        private ImgShow Img { get; set; }

        public Form1()
        {
            Img = new ImgShow();
            InitializeComponent();
        }

        static int height { get; set; }
        static string total { get; set; }

        public void GetFps(string fps)
        {
            Img.GetFps(fps);
            fps += " hz";
            if (label1.InvokeRequired)
            {
                Action action = delegate {
                    label1.Text = fps;
                };
                label1.Invoke(action);
            }
            else
                label1.Text = fps;

           
        }
       
        public void GetImage(Image ımage,string size)
        {
           
             Img.GetImage(ımage, size);
             height = (int.Parse(size) + height);
           
            if (height > 1024)
                total = Math.Round( ((double)height / 1024), 2) + " MB";
            else total = height+" KB";
            
            if (label3.InvokeRequired)
            {
                Action action = delegate {
                    label3.Text = total;
                };
                label3.Invoke(action);
            }
            else
                label3.Text = total;

            size += " KB";
            if (label6.InvokeRequired)
            {
                Action action = delegate {
                    label6.Text = size;
                };
                label6.Invoke(action);
            }
            else
                label6.Text = size;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipText = "Bildirim içeriği";
                notifyIcon1.BalloonTipTitle = "Bildirim başlığı";
                notifyIcon1.Text = "Bildirim Text";
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(30000);
            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Img.Show();
        }
    }
}
