using BiruniEdu.Business.Abstract;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete;
using System.Linq.Expressions;

namespace BiruniEdu.Business.Concrete
{
    public class FacultyService :IFacultyService

    {
        private IFacultyDal _facultyDal;

        public FacultyService(IFacultyDal facultyDal)
        {
            _facultyDal = facultyDal;
        }

        public Faculty Get(Expression<Func<Faculty, bool>> filter)
        {
            //

            //

            return _facultyDal.Get(filter);
        }

        public IList<Faculty> GetList(Expression<Func<Faculty, bool>>? filter=null)
        {
            return _facultyDal.GetList().ToList();

        }

        public Faculty Create(Faculty entity)
        {
            return _facultyDal.Create(entity);
        }

        public Faculty Update(Faculty entity)
        {
            return _facultyDal.Update(entity);

        }

        public Faculty Delete(Expression<Func<Faculty, bool>> filter)
        {
            var record = _facultyDal.Get(filter);
            return _facultyDal.Delete(record);

        }
    }
}
