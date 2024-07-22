using hf.Domain.Abstractions;
using hf.Domain.Entities;
using hf.Infrastructure.Context;

namespace hf.Infrastructure.Repositories
{
    internal sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddProductAsync(Product product, CancellationToken cancellationToken)
        {
            await AddAsync(product, cancellationToken);
        }

        public async Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await GetByIdAsync(id, cancellationToken);

            return result;
        }

        public async Task<IEnumerable<Product?>> GetProductReadonlyAsync(CancellationToken cancellationToken = default)
        {
            var results = await GetAllReadonlyAsync(cancellationToken);

            return results;
        }
    }
}
