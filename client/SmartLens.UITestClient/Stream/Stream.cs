using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.UITransmissionTestClient
{
    public class Stream:IStream
    {
        public Guid UserId { get; set; }
        public byte[] Image { get; set; }
    }
}
