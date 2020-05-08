using SmartLens.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Abstract
{
   public interface IUserService
    {
        List<User> GetAll();
    }
}
