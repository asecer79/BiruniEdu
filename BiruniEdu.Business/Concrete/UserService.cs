using BiruniEdu.Business.Abstract;
using BiruniEdu.DataAccess.Context;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete.Security;

namespace BiruniEdu.Business.Concrete
{
    public class UserService:IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Get(int id)
        {
            return _userDal.Get(id);
        }

        public IList<User> GetList()
        {
            return _userDal.GetList();
           
        }

        public User Create(User entity)
        {
            return _userDal.Create(entity);
        }

        public User Update(User entity)
        {
            return _userDal.Update(entity);
        }

        public bool Delete(int id)
        {
            return _userDal.Delete(id);
        }

        public bool CheckUserToLogin(string email, string password)
        {
            return _userDal.CheckUserToLogin(email, password);

        }

        public List<OperationClaim> GetUserOperationClaims(int userId)
        {
            return _userDal.GetUserOperationClaims(userId);

        }

        public User GetUserByEmail(string email, string password)
        {
            return _userDal.GetUserByEmail(email, password);
        }
    }
}
