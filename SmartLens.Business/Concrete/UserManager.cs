using SmartLens.Business.Abstract;
using SmartLens.DataAccess.Abstract;
using SmartLens.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Concrete
{
    public class UserManager : IUserService
    {

        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public List<User> GetAll()
        {
            return _userDal.GetList();
        }
    }
}
