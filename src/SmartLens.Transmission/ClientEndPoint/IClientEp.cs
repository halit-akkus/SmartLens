using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmartLens.Transmission.ClientEndPoint
{
    public interface IClientEp
    {
        IList<ClientModel> ClientList { get; set; }
        void AddClient(Guid UserId, IPEndPoint iPEndPoint);
        void RemoveClientByUserId(Guid UserId);
        ClientModel GetClientByUserId(Guid UserId);
    }
}
