using System;

namespace SmartLens.Client
{
    public class Stream:IStream
    {
        public Guid UserId { get; set; }
        public byte[] Image { get; set; }
    }
}
