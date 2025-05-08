using BiruniEdu.Business.Abstract;
using BiruniEdu.DataAccess.Context;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete;
using BiruniEdu.Entities.Concrete.Security;
using System.Linq.Expressions;

namespace BiruniEdu.Business.Concrete
{
    public class UserService:IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }

        public IList<User> GetList(Expression<Func<User, bool>>? filter = null)
        {
            return _userDal.GetList(filter).ToList();
        }


        public User Create(User entity)
        {
            return _userDal.Create(entity);
        }

        public User Update(User entity)
        {
            return _userDal.Update(entity);
        }

        public User Delete(Expression<Func<User, bool>> filter)
        {
            var record = _userDal.Get(filter);

            return _userDal.Delete(record);
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
