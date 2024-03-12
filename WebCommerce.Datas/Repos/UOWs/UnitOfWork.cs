using WebCommerce.DbDatas.Repos.Implimentation;
using WebCommerce.DbDatas.Repos.Interface;
using WebCommerce.Models;

namespace WebCommerce.DbDatas.Repos.UOWs
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryRepo = new CategoryRepo(context);
            ProductRepo = new ProductRepo(context);
          
        }
        public IProductRepo ProductRepo { get; private set; }

        public ICategoryRepo CategoryRepo { get; private set; }

        //public void DeleteRemove(int id)
        //{
        //    var productToBeDeleted = _context.Products.Find(id);
        //    productToBeDeleted.IsActive = false;
        //}

        //public void DeleteRemove(int id)
        //{
        //    var productToBeDeleted = _context.Products.Find(id);
        //    productToBeDeleted.IsActive = false;
        //}
        public void Save()
        {
           _context.SaveChangesAsync();
        }
    }
}
