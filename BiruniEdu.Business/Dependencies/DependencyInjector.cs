using Autofac;
using BiruniEdu.Business.Abstract;
using BiruniEdu.Business.Concrete;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.DataAccess.Dal.Concrete;

namespace BiruniEdu.Business.Dependencies
{
    public class DependencyInjector: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FacultyDal>().As<IFacultyDal>();
            builder.RegisterType<FacultyService>().As<IFacultyService>();

            builder.RegisterType<DepartmentDal>().As<IDepartmentDal>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();

            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<UserService>().As<IUserService>();

        }
    }
}
