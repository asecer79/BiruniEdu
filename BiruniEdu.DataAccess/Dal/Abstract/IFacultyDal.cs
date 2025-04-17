using BiruniEdu.Entities.Concrete;

namespace BiruniEdu.DataAccess.Dal.Abstract
{
    public interface IFacultyDal
    {
        Faculty Get(int id);
        IList<Faculty> GetList();

        Faculty Create(Faculty entity);

        Faculty Update(Faculty entity);

        bool Delete(int id);
    }
}
