using Newtonsoft.Json;
using SmartLens.Client;
using SmartLens.Entities.Results;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Client
{
    public class Udp : IClient
    {
        private UdpClient _udpClient;

        public Udp()
        {
            _udpClient = new UdpClient();
        }

        public Task SendData(IPEndPoint ipEndPoint,byte[] data)
        {
               return Task.Run(() =>
              {
                  _udpClient.SendAsync(data,data.Length,ipEndPoint);
              });
        }

        public async Task<byte[]> SendData(IPEndPoint ipEndPoint, string imageByBase64)
        {
            var stream = new Stream
            {
                Image = Convert.FromBase64String(imageByBase64),
                UserId = Guid.NewGuid()
            };

            var serialize = JsonConvert.SerializeObject(stream);

            byte[] bytes = Encoding.ASCII.GetBytes(serialize);

            await _udpClient.SendAsync(bytes, bytes.Length, ipEndPoint);

            var receive = await _udpClient.ReceiveAsync();

            return receive.Buffer;
        }
    }
}
