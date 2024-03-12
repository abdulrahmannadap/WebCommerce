using WebCommerce.DbDatas.Repos.Interface;

namespace WebCommerce.DbDatas.Repos.UOWs
{
    public interface IUnitOfWork
    {
        public IProductRepo ProductRepo { get; }
        public ICategoryRepo CategoryRepo { get; }
        void Save();

        //void DeleteRemove(int id);
    }
}
