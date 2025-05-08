using BiruniEdu.Core.DataAccess.Concrete.Ef;
using BiruniEdu.DataAccess.Context;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete.Security;

namespace BiruniEdu.DataAccess.Dal.Concrete
{
    public class UserDal:EfEntityRepositoryBase<User,UniEduDbContext>,IUserDal
    {
        public bool CheckUserToLogin(string email, string password)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                return dbContext.Users.Any(p => p.Email==email&&p.Password==password)!;
            }
        }

        public List<OperationClaim>? GetUserOperationClaims(int userId)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                return dbContext.Users.FirstOrDefault(p => p.Id == userId)?.OperationClaims?.ToList();
            }
        }

        public User GetUserByEmail(string email, string password)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                return dbContext.Users.FirstOrDefault(p => p.Email == email && p.Password == password)!;
            }
        }
    }
}
