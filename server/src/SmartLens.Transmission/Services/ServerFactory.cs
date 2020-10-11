using SmartLens.Listener.Abstract;
using SmartLens.Listener.Concrate;
using System;
using System.Collections.Generic;

namespace SmartLens.Transmission.Concrate
{
    public class ServerFactory
    {
        private Dictionary<string, Func<IListener>> _listener;
        public ServerFactory(int port)
        {
            _listener = new Dictionary<string, Func<IListener>>();
            _listener["Udp"] = () => { return AsyncUdpListener.CurrentUdpServer(port); };
        }
        public IListener CreateListener(string protocolType)
        {
            return _listener[protocolType].Invoke();
        }
    }
}
