using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SmartLens.Client
{
   public interface IClient
    {
      void SendBuffer(byte[] buffer);
        string _IpAddress { get; set; }
        int _Port { get; set; }
        IPAddress _Broadcast { get; set; }
        Socket _Socket { get; set; }
        IPEndPoint _Ep { get; set; }
    }
}
