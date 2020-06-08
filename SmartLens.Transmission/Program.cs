

using SmartLens.Business.Concrete.Listener;
using SmartLens.WinFormUI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace SmartLens.Transmission
{
  static  class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private static  Form1 form1 { get; set; }
        private static int Port;
        private static BigInteger RequestCount;
        private static bool signal = false;
        private static Random _rnd = new Random();
        static int fps = 0;
        private static ConsoleColor[] Color = { ConsoleColor.DarkYellow, ConsoleColor.Gray,  ConsoleColor.DarkGreen,ConsoleColor.DarkRed,ConsoleColor.DarkCyan};
        static void SetColor(ConsoleColor fore)
        {
            Console.ForegroundColor = fore;
        }
        static void SetColor()
        {
         Console.ForegroundColor = Color[_rnd.Next(0,Color.Length)];
        }
        public static void ClearCurrent(int size)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(size, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(size, currentLineCursor);
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
                    ClearCurrent(21);
                }
            }
        }
        public static Image byteToImage(byte[] byteArrayIn)
        {
            using (var fileStream = new MemoryStream(byteArrayIn))
            {
                return  Image.FromStream(fileStream);
            }
        }
        [STAThread]
        static async void StartListener(UdpListener udpListener, IPEndPoint ıPEndPoint)
        {
                SetColor();
            byte[] bytes = await udpListener.StartListener();
            var ms = new MemoryStream(bytes);
            var img  = Image.FromStream(ms);
            string size = ((int)bytes.Length / 1024).ToString();
            form1.GetImage(img,size);
            //img.Save("RequestImg\\Img.jpg");
                signal = true;
            ClearCurrent(21);
                SetColor(ConsoleColor.Gray);
            Console.Write($" Step #{++RequestCount}");
            
            Console.WriteLine($" => Received;  {ıPEndPoint.Address}: {size}KB");
        }
        static void ServerStarted(object obj)
        {
            string[] args = (string[])obj;
            Port = args.Length > 0 ? int.Parse(args[0]) : 11000;
            Console.WindowHeight = (Console.LargestWindowHeight * 9 / 10);
            Console.WriteLine("[PORT NO:{0}]", Port);
            var IpEndPoint = new IPEndPoint(IPAddress.Any, Port);
            while (true)
            {
                StartListener(new UdpListener(new UdpClient(Port), IpEndPoint),  IpEndPoint);
                fps++;
                Console.Write("Waiting for broadcast");
                while (!signal)
                    Thread.Sleep(1);

                signal = false;
            }
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            form1.GetFps(fps.ToString());
            fps = 0;
        }
        private static void SetTimer()
        {
            var aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }
        static  void Main(string[] args)
        {
            SetTimer();

            new Thread(new ParameterizedThreadStart(Effect)).Start(new string[] { "/", "-", "\\", "|" });
           
            new Thread(new ParameterizedThreadStart(ServerStarted)).Start(args);
            
            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}
