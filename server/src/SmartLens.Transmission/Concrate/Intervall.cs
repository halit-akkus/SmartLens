using SmartLens.Entities.Results;
using SmartLens.Transmission.Tdo;
using SmartLens.WinFormUI;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Numerics;
using System.Timers;

namespace SmartLens.Transmission.Concrate
{
   public class Intervall: System.Timers.Timer
    {
        private static Intervall _intervall;
        private static int _inputFps = 0;
        private static int _outputFrequency = 0;
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
                _form1.GetFps(_inputFps.ToString(),_outputFrequency.ToString(),_DownloadSize.ToString());
            _inputFps = 0;
            _outputFrequency = 0;
            _DownloadSize = 0;
        }
        public int SetInputFps()
        {
            return ++_inputFps;
        }
        public int SetOutInputFrequency()
        {
            return ++_outputFrequency;
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

        public void GetImage(Image ımage, int size, Guid userId,IPEndPoint iPEndPoint)
        {
            if(_form1!=null)
          _form1.SetStatistics(userId.ToString(),iPEndPoint, ımage,size.ToString()
                , (++RequestCount).ToString());
        }

        public void SetIntervall(StatisticsModel statistics)
        {
            Guid userId = statistics.Stream.UserId;

            var image = Image.FromStream(new MemoryStream(statistics.Stream.Image));

            int size = statistics.Stream.Image.Length / 1024;
           

            GetImage(image,size,userId , statistics.IPEndPoint);
            DownloadSize(size);
            SetInputFps();
            Console.Clear();
            
            Console.WriteLine($" OK : EndPoint: {statistics.IPEndPoint} size: {size}KB");
        }
    }
}
