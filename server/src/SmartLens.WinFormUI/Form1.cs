using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLens.WinFormUI
{
    public partial class Form1 : Form
    {
        private ImgShow _img;

        public Form1()
        {
            _img = new ImgShow();
            InitializeComponent();
        }

        private static string _title = "SmartLens";
        static int height { get; set; }
        private static string total { get; set; }
        private string[] _loadingBar = {"",".","..","...","."," .","  .","   ."};
        private int _loadingCount = 0;
        public void GetFps(string fps,string outputFrequency,string downloadsize)
        {
            _img.GetFps(fps);
            string sgnlText = "No Signal!";
            if (!(int.Parse(fps)==0))
                sgnlText = $"proccessing {_loadingBar[_loadingCount++]}";
            if (_loadingCount >= _loadingBar.Length)
                _loadingCount = 0;
            if (sgnl.InvokeRequired)
            {
                Action action = delegate {
                    sgnl.Text = sgnlText;
                };
                sgnl.Invoke(action);
            }
            else
                label1.Text = sgnlText;

            outputFrequency += " hz";
            if (label14.InvokeRequired)
            {
                Action action = delegate {
                    label14.Text = outputFrequency;
                };
                label14.Invoke(action);
            }
            else
                label14.Text = outputFrequency;


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
       
        public void SetStatistics(string userId,IPEndPoint FromIpAddress, Image ımage,string size,string step)
        {
            step = "#" + step;
            _img.GetImage(ımage, size);
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
            if (label12.InvokeRequired)
            {
                Action action = delegate {
                    label12.Text = userId;
                };
                label12.Invoke(action);
            }
            else
                label12.Text = userId;
            if (label17.InvokeRequired)
            {
                Action action = delegate {
                    label17.Text =$"{FromIpAddress.Address.ToString()}:{FromIpAddress.Port}";
                };
                label17.Invoke(action);
            }
            else
                label17.Text = $"{FromIpAddress.Address.ToString()}:{FromIpAddress.Port}";
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipText = "İzlence menüsüne buradan ulaşabilirsiniz.";
                notifyIcon1.BalloonTipTitle = "SmartLens";
                notifyIcon1.Text = "SmartLens";
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
            notifyIcon1.BalloonTipText = "Server is Started";
            notifyIcon1.BalloonTipTitle = "SmartLens";
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
            _img.Show();
        }
        private int lastChar = 0;
        private void logoTimer_Tick(object sender, EventArgs e)
        {
            var charArray = _title.ToCharArray();
            _title = "";
            for (int i = 0; i < charArray.Length; i++)
            {
                if (i == lastChar||i==0|| i == 5)
                    _title += charArray[i].ToString().ToUpper();
                else _title += charArray[i].ToString().ToLower();
            }
            
            if (lastChar++ >= charArray.Length)
                lastChar = 0;


            label15.Text = _title;
        }
    }
}
