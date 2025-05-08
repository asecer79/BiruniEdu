using BiruniEdu.Business.Abstract.CommonInterfaces;
using BiruniEdu.Entities.Concrete.Security;

namespace BiruniEdu.Business.Abstract
{
    public interface IUserService:ICommonDbOperations<User>
    {
        
        bool CheckUserToLogin(string email, string password);

        List<OperationClaim> GetUserOperationClaims(int userId);

        User GetUserByEmail(string email, string password);

    }
}
