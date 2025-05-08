using BiruniEdu.Core.DataAccess.Concrete.Ef;
using BiruniEdu.DataAccess.Context;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete;

namespace BiruniEdu.DataAccess.Dal.Concrete
{
    public class FacultyDal:EfEntityRepositoryBase<Faculty,UniEduDbContext>,IFacultyDal
    {
      
    }
}
