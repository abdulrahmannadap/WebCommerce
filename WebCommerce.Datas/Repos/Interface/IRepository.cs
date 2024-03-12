using System.Linq.Expressions;

namespace WebCommerce.DbDatas.Repos.Interface
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression, string? includeProp = null);
        IEnumerable<T> GetAll(string? includeProp=null);
        
        void AddData(T entity);
        void EditData(T entity);
        void DeleteData(T entity);
        void DeleteDataRange(IEnumerable<T> entiteis);
        void DeleteRemove(int id);

    }
}
