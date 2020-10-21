using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.UITransmissionTestClient
{
    public class Udp : IClient
    {

        private UdpClient _udpClient;
        private IPEndPoint _iPEndPoint;
        public Udp(IPEndPoint iPEndPoint)
        {
            _iPEndPoint = iPEndPoint;
            _udpClient = new UdpClient();
        }

        public async Task<byte[]> SendData(IStream stream)
        {
              var serialize = JsonConvert.SerializeObject(stream);
              byte[] bytes = Encoding.ASCII.GetBytes(serialize);
            if (bytes.Length>64900)
            {
                return new byte[] { };
            }
              await  _udpClient.SendAsync(bytes, bytes.Length, _iPEndPoint);

              var receive = await _udpClient.ReceiveAsync();
             
            return receive.Buffer;
        }


    }
}
