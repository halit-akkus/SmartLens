using SmartLens.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Entities.Concrate
{
   public class Device : IEntity
    {
        public string Id { get; set; }
        public string DeviceName { get; set; }
    }
}
