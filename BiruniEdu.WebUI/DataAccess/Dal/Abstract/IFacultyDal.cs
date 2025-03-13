using BiruniEdu.WebUI.Entities;

namespace BiruniEdu.WebUI.DataAccess.Dal.Abstract
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
