using System;

namespace SmartLens.Client
{
    public interface IStream
    {
         Guid UserId { get; set; }
         byte[] Image { get; set; }
    }
}
