using SmartLens.Core.DataAccess.EntityFramework;
using SmartLens.DataAccess.Abstract;
using SmartLens.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.DataAccess.Concrate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SmartLensContext>, IUserDal
    {

    }
}
