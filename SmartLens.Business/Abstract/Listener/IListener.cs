using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Business.Abstract.Listener
{
   public interface IListener
    {
        string Message();
        Task<byte[]> StartListener();
    }
}
