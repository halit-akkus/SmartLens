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

        public void GetFps(string fps,string downloadsize)
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

          
            if (int.Parse(downloadsize) > 1024)
                downloadsize = Math.Round((Convert.ToDouble( downloadsize) / 1024), 2) + " mb/s";
            else total = downloadsize += " kb/s";
            if (label10.InvokeRequired)
            {
                Action action = delegate {
                    label10.Text = downloadsize;
                };
                label10.Invoke(action);
            }
            else
                label10.Text = downloadsize;

        }
       
        public void GetImage(Image ımage,string size,string step)
        {
            step = "#" + step;
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

            if (label8.InvokeRequired)
            {
                Action action = delegate {
                    label8.Text = step;
                };
                label8.Invoke(action);
            }
            else
                label8.Text = step;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipText = "İzlence menüsüne buradan ulaşabilirsiniz.";
                notifyIcon1.BalloonTipTitle = "Smart Lens";
                notifyIcon1.Text = "Smart Lens";
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
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Server Started";
            notifyIcon1.BalloonTipTitle = "Smart Lens";
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(30000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void exitStripMenu(object sender, EventArgs e)
        {
             this.Close();
        }
        private void ShowDisplay(object sender, EventArgs e)
        {
            Img.Show();
        }
       
    }
}
