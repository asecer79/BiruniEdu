using BiruniEdu.Entities.Concrete.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiruniEdu.Business.Abstract.CommonInterfaces
{
    public interface ICommonDbOperations<T>
    {
        T Get(int id);
        IList<T> GetList();
        T Create(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}
