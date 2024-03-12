using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebCommerce.DbDatas.Repos.Interface;
using WebCommerce.Models;

namespace WebCommerce.DbDatas.Repos.Implimentation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context )
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public void AddData(T entity)
        {
            _dbSet.Add( entity );
        }

        public void DeleteData(T entity)
        {
            _dbSet?.Remove( entity );
        }

        public void DeleteDataRange(IEnumerable<T> entiteis)
        {
           _dbSet.RemoveRange(entiteis);    
        }

        public void DeleteRemove(int id)
        {
            var deletedInComing = _dbSet.Find(id);
            deletedInComing.Equals(false);
        }

        public void EditData(T entity)
        {
           _dbSet.Update( entity );
        }

        public T Get(int id)
        {
           return _dbSet.Find( id );
        }

        public T Get(Expression<Func<T, bool>> expression, string? includeProp = null)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(includeProp))
            {
                foreach (string includeprops in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeprops);
                }
                
            }
            return _dbSet.FirstOrDefault( expression );
        }

        public IEnumerable<T> GetAll(string? includeProp = null)
        {
            IQueryable<T> query = _dbSet;
            if(!string.IsNullOrEmpty(includeProp))
            {
                foreach (string includeprops in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                   query = query.Include(includeprops);
                }
            }
            return query.ToList();
        }

       
    }
}
