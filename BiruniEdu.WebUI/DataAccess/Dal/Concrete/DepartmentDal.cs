using BiruniEdu.WebUI.DataAccess.Context;
using BiruniEdu.WebUI.DataAccess.Dal.Abstract;
using BiruniEdu.WebUI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiruniEdu.WebUI.DataAccess.Dal.Concrete
{
    public class DepartmentDal:IDepartmentDal
    {
        public Department Get(int id)
        {
            using (UniEduDbContext dbContext =new UniEduDbContext())
            {
                return dbContext.Departments
                    .Include(p=>p.Faculty)
                    .FirstOrDefault(p => p.Id == id)!;
            }
        }

        public IList<Department> GetList()
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                return dbContext.Departments.Include(p => p.Faculty).ToList();
            }
        }

        public Department Create(Department entity)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                dbContext.Departments.Add(entity);

                dbContext.SaveChanges();

                return entity;
            }
        }

        public Department Update(Department entity)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                dbContext.Departments.Update(entity);

                dbContext.SaveChanges();

                return entity;
            }
        }

        public bool Delete(int id)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {

               var entity= dbContext.Departments.FirstOrDefault(p => p.Id == id)!;

                dbContext.Departments.Remove(entity);

                dbContext.SaveChanges();

                return true;
            }
        }
    }
}
