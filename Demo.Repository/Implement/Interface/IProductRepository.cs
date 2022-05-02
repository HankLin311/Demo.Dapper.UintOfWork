using Demo.Common.Do;
using Demo.Repository.Base;

namespace Demo.Repository.Implement.Interface
{
    public interface IProductRepository : IGenericRepository<ProductDo>
    {
        public int GetProductQty(int id);
    }
}
