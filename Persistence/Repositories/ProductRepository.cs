

using Application.Interfaces.Repository;
using Domain.Entities;

namespace Persistence.EFCore.Repositories
{
    public class ProductRepository : GenericRepository<ProductDetails>, IProductRepository
    {
        public ProductRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
