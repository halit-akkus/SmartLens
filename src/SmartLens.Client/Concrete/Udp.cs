using Newtonsoft.Json;
using SmartLens.Client;
using SmartLens.Entities.Results;
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


    }
}
