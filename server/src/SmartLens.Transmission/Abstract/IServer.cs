using SmartLens.Listener.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Transmission.Abstract
{
    public interface IServer
    {
        void ServerStarted(IListener listener);
    }
}
