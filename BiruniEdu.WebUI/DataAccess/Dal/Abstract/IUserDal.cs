using BiruniEdu.WebUI.Entities;
using BiruniEdu.WebUI.Entities.Security;

namespace BiruniEdu.WebUI.DataAccess.Dal.Abstract
{
    public interface IUserDal
    {
        User Get(int id);
        IList<User> GetList();

        User Create(User entity);

        User Update(User entity);

        bool Delete(int id);

        bool CheckUserToLogin(string email, string password);

        List<OperationClaim> GetUserOperationClaims(int userId);
    }
}
