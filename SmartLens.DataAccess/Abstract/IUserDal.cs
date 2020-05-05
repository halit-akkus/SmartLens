using SmartLens.Core.DataAccess;
using SmartLens.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
    {
        //Custom Operations
    }
}
