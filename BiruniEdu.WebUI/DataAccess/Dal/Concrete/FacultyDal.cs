using BiruniEdu.WebUI.DataAccess.Context;
using BiruniEdu.WebUI.DataAccess.Dal.Abstract;
using BiruniEdu.WebUI.Entities;

namespace BiruniEdu.WebUI.DataAccess.Dal.Concrete
{
    public class FacultyDal:IFacultyDal
    {
        public Faculty Get(int id)
        {
            using (UniEduDbContext dbContext =new UniEduDbContext())
            {
                return dbContext.Faculties.FirstOrDefault(p => p.Id == id)!;
            }
        }

        public IList<Faculty> GetList()
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                return dbContext.Faculties.ToList();
            }
        }

        public Faculty Create(Faculty entity)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                dbContext.Faculties.Add(entity);

                dbContext.SaveChanges();

                return entity;
            }
        }

        public Faculty Update(Faculty entity)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {
                dbContext.Faculties.Update(entity);

                dbContext.SaveChanges();

                return entity;
            }
        }

        public bool Delete(int id)
        {
            using (UniEduDbContext dbContext = new UniEduDbContext())
            {

               var entity= dbContext.Faculties.FirstOrDefault(p => p.Id == id)!;

                dbContext.Faculties.Remove(entity);

                dbContext.SaveChanges();

                return true;
            }
        }
    }
}
