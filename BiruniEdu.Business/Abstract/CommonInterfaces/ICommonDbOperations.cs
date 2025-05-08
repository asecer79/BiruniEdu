using System.Linq.Expressions;

namespace BiruniEdu.Business.Abstract.CommonInterfaces
{
    public interface ICommonDbOperations<T>
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>>? filter=null);
        T Create(T entity);
        T Update(T entity);
        T Delete(Expression<Func<T, bool>> filter);
    }
}
