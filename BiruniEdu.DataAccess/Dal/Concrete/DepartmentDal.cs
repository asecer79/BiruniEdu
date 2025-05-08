using BiruniEdu.Core.DataAccess.Concrete.Ef;
using BiruniEdu.DataAccess.Context;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BiruniEdu.DataAccess.Dal.Concrete
{
    public class DepartmentDal:EfEntityRepositoryBase<Department,UniEduDbContext>, IDepartmentDal
    {
       

    }
}
