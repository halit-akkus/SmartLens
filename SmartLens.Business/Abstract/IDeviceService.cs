using SmartLens.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Abstract
{
   public interface IDeviceService
    {
        List<Device> GetAll();
        Device GetById(string DeviceId);
        void Add(Device device);
        void Update(Device device);
        void Delete(Device DeviceId);

    }
}
