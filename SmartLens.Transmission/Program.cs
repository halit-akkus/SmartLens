using SmartLens.Business.Concrete.Listener;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading;

namespace SmartLens.Transmission
{
    class Program
    {
        private static int Port;
        private static BigInteger RequestCount;
        private static bool signal = false;
        private static Random _rnd = new Random();
       
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
        [STAThread]
        static async void StartListener(UdpListener udpListener, IPEndPoint ıPEndPoint)
        {
                SetColor();
                byte[] bytes = await udpListener.StartListener();
         
            signal = true;
                SetColor(ConsoleColor.Gray);
                Console.WriteLine($" - Received broadcast from {ıPEndPoint}: = > {++RequestCount}");
                Console.WriteLine($"{Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
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
               
                while (!signal)
                    Thread.Sleep(1);

                signal = false;
            }
        }
      
        static  void Main(string[] args)
        {
            SetColor(ConsoleColor.White);
            new Thread(new ParameterizedThreadStart(Effect)).Start(new string[] { "|", "/", "--", "\\" });
            ServerStarted(args);
            
        }
    }
}
