using SmartLens.Entities.Results;
using SmartLens.Transmission.Services;
using SmartLens.WinFormUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            _DownloadSize += currentDownload;
            return _DownloadSize;
        }

        public void GetImage(Image ımage, int size, Guid userId)
        {
          _form1.SetStatistics(userId.ToString(),"127.0.0.1", ımage,size.ToString()
                , (++RequestCount).ToString());
        }

        public void SetIntervall(IResult result)
        {
            var streamData = ResultParse.GetImage(result);
            Guid userId = ResultParse.GetUserId(result);

            var image = Image.FromStream(new MemoryStream(streamData.Image));

            int size = result.receiveData.Length / 1024;
           
            GetImage(image,size,userId);
            DownloadSize(size);
            SetFps();
            Console.WriteLine($" OK : {size}KB");
        }
    }
}
