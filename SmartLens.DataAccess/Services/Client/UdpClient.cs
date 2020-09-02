using Newtonsoft.Json;
using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.DataAccess.Services.Client
{
    class UdpClient : IClient
    {
        public int _Port { get; set; }
        public IPAddress _Broadcast { get; set; }
        public Socket _Socket { get; set; }
        public IPEndPoint _Ep { get; set; }

        public UdpClient()
        {
            _Port = 1444;
            _Broadcast = IPAddress.Parse("127.0.0.1");
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _Ep = new IPEndPoint(_Broadcast, _Port);
        }

        public Task SendData(IResult result)
        {
            return Task.Run(()=> {
                var serialize = JsonConvert.SerializeObject(result);
                byte[] bytes = Encoding.ASCII.GetBytes(serialize);
                
                _Socket.SendTo(bytes, _Ep);
            });
        }
    }
}
