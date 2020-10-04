using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SmartLens.Transmission.ClientEndPoint
{
    class ClientEp : IClientEp
    {
      
        public IList<ClientModel> ClientList { get; set; }
        public void AddClient(Guid UserId, IPEndPoint iPEndPoint)
        {
            if (ClientList == null)
            {
                ClientList = new List<ClientModel>();
            }
               ClientList.Add(new ClientModel(UserId, iPEndPoint));
        }

        public ClientModel GetClientByUserId(Guid UserId)
        {
          var client =  ClientList.FirstOrDefault(client => client.UserId == UserId);
         
            return client;
        }

        public void RemoveClientByUserId(Guid UserId)
        {
          var client =  ClientList.FirstOrDefault(client => client.UserId == UserId);
            if (client!=null)
            {
                ClientList.Remove(client);
            }
        }
    }
}
