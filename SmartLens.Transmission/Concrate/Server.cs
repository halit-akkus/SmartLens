using SmartLens.Business.Abstract.Listener;
using SmartLens.Business.Concrete.Listener;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartLens.Transmission.Concrate
{
   public static class Server
    {
        private static int Port;
        [STAThread]
        public static async Task<Image> GetImageAsync(IListener Listener)
        {
            byte[] bytes = await Listener.StartListener();

            return Image.FromStream(new MemoryStream(bytes));
        }

       public static async void ServerStarted(object obj)
        {
            string[] args = (string[])obj;
            Port = args.Length > 0 ? int.Parse(args[0]) : 11000;
            Console.WriteLine("Started Server[PORT NO:{0}]", Port);
            Console.WriteLine("-----------------------------");

            var IpEndPoint = new IPEndPoint(IPAddress.Any, Port);
            var intervall = Intervall.Get();


            var listener =  AsyncUdpListener.currentUdpServer(new UdpClient(Port), IpEndPoint);
            new Thread(new ParameterizedThreadStart(ConsoleEffect.Effect)).Start(listener.Message().Length);
           
            while (true)
            {
                Console.WriteLine();
                ConsoleEffect.SetColor();
                Console.Write($"{ listener.Message()} - WAITING");
                var checkImg = await GetImageAsync(listener);
                var size = ((int)2048 / 1024).ToString();
                intervall.SetIntervall(checkImg, size, int.Parse(size));
                listener = AsyncUdpListener.currentUdpServer(new UdpClient(Port), IpEndPoint);
            }
        }
    }
}
