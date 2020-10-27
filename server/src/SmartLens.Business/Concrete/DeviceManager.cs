using SmartLens.Business.Abstract;
using SmartLens.DataAccess.Abstract;
using SmartLens.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Concrete
{
    public class DeviceManager : IDeviceService
    {
        IDeviceDal _deviceDal;
        public DeviceManager(IDeviceDal deviceDal)
        {
            _deviceDal = deviceDal;
        }

        public void Add(Device device)
        {
            _deviceDal.Add(device);
        }

        public void Delete(Device DeviceId)
        {
            _deviceDal.Delete(DeviceId);
        }

        public List<Device> GetAll()
        {
            return _deviceDal.GetList();
        }

        public Device GetById(string DeviceId)
        {
            return _deviceDal.Get(p=>p.Id==DeviceId);
        }

        public void Update(Device device)
        {
            _deviceDal.Update(device);
        }
    }

}
