using BiruniEdu.WebUI.DataAccess.Context;
using BiruniEdu.WebUI.DataAccess.Dal.Abstract;
using BiruniEdu.WebUI.Entities;
using BiruniEdu.WebUI.Entities.Security;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BiruniEdu.WebUI.DataAccess.Dal.Concrete
{
    public class UserDal:IUserDal
    {
        public User Get(int id)
        {
            using (UniEduDbContext dbContext =new UniEduDbContext())
            {
                return dbContext.Users.FirstOrDefault(p => p.Id == id)!;
            }
        }

        public IList<User> GetList()
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                return dbContext.Users.ToList();
            }
        }

        public User Create(User entity)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                dbContext.Users.Add(entity);

                dbContext.SaveChanges();

                return entity;
            }
        }

        public User Update(User entity)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                dbContext.Users.Update(entity);

                dbContext.SaveChanges();

                return entity;
            }
        }

        public bool Delete(int id)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {

               var entity= dbContext.Users.FirstOrDefault(p => p.Id == id)!;

                dbContext.Users.Remove(entity);

                dbContext.SaveChanges();

                return true;
            }
        }

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
                return dbContext.Users.FirstOrDefault(p => p.Id == userId)?.OperationClaims.ToList();
            }
        }
    }
}
