using WebCommerce.DbDatas.Repos.Interface;
using WebCommerce.Models;

namespace WebCommerce.DbDatas.Repos.Implimentation
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context) : base(context)
        {

            _context = context;

        }
    }
}
