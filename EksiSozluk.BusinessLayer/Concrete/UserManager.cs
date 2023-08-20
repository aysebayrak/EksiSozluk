using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.DataAccessLayer.Abstract;
using EksiSozluk.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TDelete(AppUser t)
        {
            _userDal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _userDal.GetList();
        }

        public void TInsert(AppUser t)
        {
            _userDal.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _userDal.Update(t);
        }
    }
}
