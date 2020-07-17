using SmartLens.Business.Abstract.Listener;
using SmartLens.Business.Concrete.Listener;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Transmission.Concrate
{
    class ServerFactory
    {
        public IListener CreateListener(Standart.ListenerType listenerType,int _port)
        {
            if (listenerType == Standart.ListenerType.Tcp)
            {
                return AsyncTcpServer.currentTcpServer(_port);
            }
            else if (listenerType == Standart.ListenerType.Udp)
            {
               return AsyncUdpListener.currentUdpServer(_port);
            }
            return null;
        }
    }
}
