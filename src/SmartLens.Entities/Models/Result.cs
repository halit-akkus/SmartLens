using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmartLens.Entities.Models.Result
{
    public class Result 
    {
        public byte[] ReceiveData { get; set; }
        public IPEndPoint IPEndPoint { get; set; }
    }
}
