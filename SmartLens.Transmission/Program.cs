using SmartLens.Business.Concrete.Listener;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SmartLens.Transmission
{
    class Program
    {
        private static int Port;

        [STAThread]
        static async void Main(int[] args)
        {
            Port = args[0];
            var IpEndPoint = new IPEndPoint(IPAddress.Any, Port);
            var u = new UdpListener(new UdpClient(Port), IpEndPoint);
            byte[] bytes =await u.StartListener();
            Console.WriteLine($"Received broadcast from {IpEndPoint}:");
            Console.WriteLine($"{Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
        }
    }
}
