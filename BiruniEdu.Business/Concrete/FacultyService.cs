using BiruniEdu.Business.Abstract;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete;

namespace BiruniEdu.Business.Concrete
{
    public class FacultyService :IFacultyService

    {
        private IFacultyDal _facultyDal;

        public FacultyService(IFacultyDal facultyDal)
        {
            _facultyDal = facultyDal;
        }

        public Faculty Get(int id)
        {
            //

            //

            return _facultyDal.Get(id);
        }

        public IList<Faculty> GetList()
        {
            return _facultyDal.GetList();

        }

        public Faculty Create(Faculty entity)
        {
            return _facultyDal.Create(entity);
        }

        public Faculty Update(Faculty entity)
        {
            return _facultyDal.Update(entity);

        }

        public bool Delete(int id)
        {
            return _facultyDal.Delete(id);

        }
    }
}
