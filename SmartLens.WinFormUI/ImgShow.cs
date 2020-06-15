using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartLens.WinFormUI
{
    public partial class ImgShow : Form
    {
        public ImgShow()
        {
            InitializeComponent();
        }

        public void GetFps(string fps)
        {
          
            fps = fps == "0" ? "NO SIGNAL!" :fps+ " FPS";
            if (label1.InvokeRequired)
            {
                Action action = delegate
                {
                    label1.Text = fps;
                };
                label1.Invoke(action);
            }
            else
                label1.Text = fps;
        }
        public void GetImage(Image ımage,string size)
        {
            size += " KB";
            if (this.InvokeRequired)
            {
                Action action = delegate
                {
                    this.Text = size;
                };
                this.Invoke(action);
            }
            else
                label1.Text = size;
            pictureBox1.Image = ımage;
        }
    }
}
