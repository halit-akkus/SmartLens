using SmartLens.Business.Concrete.Listener;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SmartLens.Transmission
{
    class Program
    {
        private static int Port;
        private static int RequestCount;
        private static bool signal = false;
        static void SetColor(ConsoleColor fore, ConsoleColor background)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = fore;
        }

        [STAThread]
        static async void StartListener(UdpListener udpListener, IPEndPoint ıPEndPoint)
        {
            
            SetColor(ConsoleColor.White, ConsoleColor.DarkGreen);
            
                byte[] bytes = await udpListener.StartListener();
                signal = true;

                Console.WriteLine($"{++RequestCount} - Received broadcast from {ıPEndPoint}:");
                Console.WriteLine($"{Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
        }


        static  void Main(string[] args)
        {
            SetColor(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine("************************************");
            Port = args.Length>0 ? int.Parse(args[0]) : 11000;
            Console.WindowHeight = (Console.LargestWindowHeight * 8 / 10);
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
    }
}
