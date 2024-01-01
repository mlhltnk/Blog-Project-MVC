﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService  //identityden sonra yaptık
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TAdd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetById(id);   //idye göre userdalın verileri getirecek  (bunun yerine findbynameasync kullandık bunu 2. yöntem olarak yazdım)
        }

        public List<AppUser> TGetlist()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser t)
        {
            _userDal.Update(t);   //güncelleme işlemi (bunun yerine updateasync kullandık bunu 2. yöntem olarak yazdım)
        }
    }
}