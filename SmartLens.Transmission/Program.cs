using SmartLens.Business.Concrete.Listener;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Timers;

namespace SmartLens.Transmission
{
    class Program
    {
        private static int Port;
        private static BigInteger RequestCount;
        private static bool signal = false;
        private static Random _rnd = new Random();
        static int fps = 0;
        static void SetColor(ConsoleColor fore)
        {
            Console.ForegroundColor = fore;
        }
        static void SetColor()
        {
            Console.ForegroundColor = (ConsoleColor)_rnd.Next(0, 16);
        }
       public static void Effect(object arr)
        {
            string[] result = (string[])arr;
            while (true)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i]);
                    Thread.Sleep(200);
                }
            }
        }
       
        public static Image byteToImage(byte[] byteArrayIn)
        {
            using (MemoryStream fileStream = new MemoryStream(byteArrayIn))
            {
                return  Image.FromStream(fileStream);
            }
        }
        [STAThread]
        static async void StartListener(UdpListener udpListener, IPEndPoint ıPEndPoint)
        {
                SetColor();
                byte[] bytes = await udpListener.StartListener();
                Image ımage = byteToImage(bytes);
               // byteToImage(bytes).Save("c.jpg", ImageFormat.Jpeg);
                signal = true;
                SetColor(ConsoleColor.Gray);
                Console.WriteLine($" - Received broadcast from {ıPEndPoint}: = > {++RequestCount}");
        }

        static void ServerStarted(string[] args)
        {
           
            Port = args.Length > 0 ? int.Parse(args[0]) : 11000;
            Console.WindowHeight = (Console.LargestWindowHeight * 9 / 10);
            Console.WriteLine("[PORT NO:{0}]", Port);
            var IpEndPoint = new IPEndPoint(IPAddress.Any, Port);
            while (true)
            {
                
                StartListener(new UdpListener(new UdpClient(Port), IpEndPoint), IpEndPoint);
                fps++;
                while (!signal)
                    Thread.Sleep(1);

                signal = false;
            }
        }
      static void cmd()
        {
            Process.Start("cmd.exe");
        }
      
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine(fps);
            fps = 0;
        }
        static  void Main(string[] args)
        {
            new Thread(new ThreadStart(cmd)).Start();
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;


            SetColor(ConsoleColor.White);
            new Thread(new ParameterizedThreadStart(Effect)).Start(new string[] { "|", "/", "--", "\\" });
            ServerStarted(args);
          
        }
    }
}
