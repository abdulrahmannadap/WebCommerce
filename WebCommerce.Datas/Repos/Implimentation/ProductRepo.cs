using WebCommerce.DbDatas.Repos.Interface;
using WebCommerce.Models;

namespace WebCommerce.DbDatas.Repos.Implimentation
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
