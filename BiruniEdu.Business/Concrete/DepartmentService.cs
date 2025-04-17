using BiruniEdu.Business.Abstract;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.Entities.Concrete;

namespace BiruniEdu.Business.Concrete
{
    public class DepartmentService :IDepartmentService

    {
        private IDepartmentDal _departmentDal;

        public DepartmentService(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public Department Get(int id)
        {
            //

            //

            return _departmentDal.Get(id);
        }

        public IList<Department> GetList()
        {
            return _departmentDal.GetList();

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
            return _departmentDal.Delete(id);

        }
    }
}
