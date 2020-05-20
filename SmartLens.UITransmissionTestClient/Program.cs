using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SmartLens.UITransmissionTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("127.0.0.1");
            while (true)
            {
                byte[] sendbuf = Encoding.ASCII.GetBytes("data");
                IPEndPoint ep = new IPEndPoint(broadcast, 11000);

                s.SendTo(sendbuf, ep);

                Console.WriteLine("Message sent to the broadcast address");
                Thread.Sleep(100);
            }
        }
    }
}
