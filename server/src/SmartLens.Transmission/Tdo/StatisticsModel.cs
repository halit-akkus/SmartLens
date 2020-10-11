using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmartLens.Transmission.Tdo
{
    public class StatisticsModel
    {
        public IPEndPoint IPEndPoint { get; set; }
        public Stream Stream { get; set; }
    }
}
