using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class UserManager:IUserService
{
    private IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public void Add(AppUser t)
    {
        throw new NotImplementedException();
    }

    public void Delete(AppUser t)
    {
        throw new NotImplementedException();
    }

    public void Update(AppUser t)
    {
        throw new NotImplementedException();
    }

    public List<AppUser> GetAll()
    {
        throw new NotImplementedException();
    }

    public AppUser GetById(int id)
    {
        return _userDal.GetById(id);
    }
}