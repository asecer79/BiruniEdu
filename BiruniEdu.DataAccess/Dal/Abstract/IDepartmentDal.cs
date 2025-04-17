using BiruniEdu.Entities.Concrete;

namespace BiruniEdu.DataAccess.Dal.Abstract
{
    public interface IDepartmentDal
    {
        Department Get(int id);
        IList<Department> GetList();

        Department Create(Department entity);

        Department Update(Department entity);

        bool Delete(int id);
    }
}
