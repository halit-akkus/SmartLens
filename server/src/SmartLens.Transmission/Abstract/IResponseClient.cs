using SmartLens.Listener.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Transmission.Abstract
{
    public interface IResponseClient
    {
        void ServerStarted(IListener listener,int port);
    }
}
