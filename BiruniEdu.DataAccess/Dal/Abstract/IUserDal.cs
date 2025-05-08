using BiruniEdu.Core.DataAccess.Abstract;
using BiruniEdu.Entities.Concrete.Security;

namespace BiruniEdu.DataAccess.Dal.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
      

        bool CheckUserToLogin(string email, string password);

        List<OperationClaim> GetUserOperationClaims(int userId);

        User GetUserByEmail(string email, string password);

    }
}
