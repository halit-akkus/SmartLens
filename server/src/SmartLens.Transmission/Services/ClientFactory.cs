using SmartLens.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Transmission.Services
{
     public class ClientFactory
    {
        private Dictionary<string, Func<IClient>> _client;
        public ClientFactory(int port)
        {
            _client = new Dictionary<string, Func<IClient>>();
            _client["Udp"] = () => { return new Udp(); };
        }
        public IClient CreateClient(string protocolType)
        {
            return _client[protocolType].Invoke();
        }
    }
}
