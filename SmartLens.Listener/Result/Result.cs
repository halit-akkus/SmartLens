using SmartLens.Listener.Abstract.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Listener.Concrate.Result
{
    class Result :  IResult
    {
        public byte[] receiveData { get; set; }
        public Client client { get; set; }
    }
}
