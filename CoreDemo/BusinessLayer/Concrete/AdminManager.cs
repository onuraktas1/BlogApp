using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _AdminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _AdminDal = adminDal;
        }
        public void Add(Admin t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Admin t)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin t)
        {
            throw new NotImplementedException();
        }
    }
}
