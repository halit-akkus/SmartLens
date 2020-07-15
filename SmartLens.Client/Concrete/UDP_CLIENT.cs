using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SmartLens.Client
{
   public class UDP_CLIENT:IClient
    {

       public string _IpAddress { get; set; }
        public int _Port { get; set; }
        public IPAddress _Broadcast { get; set; }
        public Socket _Socket { get; set; }
        public IPEndPoint _Ep { get; set; }

        public UDP_CLIENT(string IpAddress,int port)
        {
            _IpAddress = IpAddress;
            _Port = port;
            _Broadcast = IPAddress.Parse(_IpAddress);
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _Ep = new IPEndPoint(_Broadcast, _Port);
        }

        public void SendBuffer(byte[] buffer)
        {
                if (!(buffer.Length > 65505))
                  _Socket.SendTo(buffer, _Ep);
        }

       
}
}
