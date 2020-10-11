using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmartLens.Transmission.ClientEndPoint
{
    public class ClientModel
    {
        public Guid UserId { get; set; }
        public IPEndPoint IpEndPoint { get; set; }
        public ClientModel(Guid userId, IPEndPoint ipEndPoint)
        {
            UserId = userId;
            IpEndPoint = ipEndPoint;
        }

    }
}
