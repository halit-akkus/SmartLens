using SmartLens.WinFormUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace SmartLens.Transmission.Concrate
{
   public class Intervall: System.Timers.Timer
    {
        private static Intervall _intervall;
        private static int _fps = 0;
        private static int _DownloadSize = 0;
        public static Form1 _form1;
        private static BigInteger RequestCount=0;

       
        public static Intervall Get()
        {
            if (_intervall == null)
            {
                _intervall = new Intervall();
                _intervall.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                timerEnabled(1000);
            }
            return _intervall;
        }
        public static void timerEnabled(int intervall)
        {
            _intervall.Interval = intervall;
            _intervall.Enabled = true;
        }
        public static void timerDisabled()
        {
            _intervall.Enabled = false;
        }
        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if ( _form1 != null)
                _form1.GetFps(_fps.ToString(), _DownloadSize.ToString());
            _fps = 0;
            _DownloadSize = 0;
        }
        public int SetFps()
        {
            return ++_fps;
        }
        public string requestCount()
        {
            return RequestCount.ToString();
        }
        public int DownloadSize(int currentDownload)
        {
            return _DownloadSize+currentDownload;
        }
        public void GetImage(Image ımage, string size)
        {
          _form1.GetImage(ımage,size
                , (++RequestCount).ToString());
        }

        public void SetIntervall(Image img,string size,int currentdownload)
        {
            GetImage(img, size);
            DownloadSize(currentdownload);
            SetFps();
            Console.Write($" Step #{requestCount()}");

            Console.WriteLine($" => Received : {size}KB");
        }
    }
}
