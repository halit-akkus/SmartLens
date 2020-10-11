using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Entities.Results
{
    public class Stream
    {
        public Guid UserId { get; set; }
        public  byte[] Image { get; set; }
    }
}
