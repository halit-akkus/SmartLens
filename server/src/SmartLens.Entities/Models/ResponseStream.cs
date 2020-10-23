using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Entities.Models
{
    public class ResponseStream
    {
        public Guid UserId { get; set; }
        public string[] DetectionList { get; set; }
    }
}
