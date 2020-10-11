
using Newtonsoft.Json;
using SmartLens.UITransmissionTestClient.Client;
using SmartLens.UITransmissionTestClient.Client.Concrete;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartLens.UITransmissionTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            client();
            Console.ReadLine();
        }

        static async void client()
        {
            var ep = new IPEndPoint(IPAddress.Parse("192.168.1.106"), 11000);

            IClient _client = new Udp(ep);
            IPaintingProcess Process = new PaintingProcess();

            while (true)
            {
                IStream stream = new Stream
                {
                    Image = Process.ImageToByte(Process.Screenshot(0, 0)),
                    UserId = Guid.NewGuid()
                };
                Console.Write("İmage:");
                var result =  _client.SendData(stream);
              

             
               var encodingToString = Encoding.UTF7.GetString(result.Result);
               Console.WriteLine(encodingToString);
               
              
            }
        }
    }
}

