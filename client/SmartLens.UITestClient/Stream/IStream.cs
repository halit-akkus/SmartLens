using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.UITransmissionTestClient
{
    public interface IStream
    {
        public Guid UserId { get; set; }
        public byte[] Image { get; set; }
    }
}
