using BiruniEdu.Business.Abstract;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete;
using System.Linq.Expressions;

namespace BiruniEdu.Business.Concrete
{
    public class DepartmentService :IDepartmentService

    {
        private IDepartmentDal _departmentDal;

        public DepartmentService(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public Department Get(Expression<Func<Department, bool>> filter)
        {
            //

            //

            return _departmentDal.Get(filter);
        }

        public IList<Department> GetList(Expression<Func<Department, bool>>? filter=null)
        {
            return _departmentDal.GetList(filter).ToList();

        }

        public Department Create(Department entity)
        {
            return _departmentDal.Create(entity);
        }

        public Department Update(Department entity)
        {
            return _departmentDal.Update(entity);

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Department Delete(Expression<Func<Department, bool>> filter)
        {
            var record = _departmentDal.Get(filter);

            return _departmentDal.Delete(record);

        }
    }
}
