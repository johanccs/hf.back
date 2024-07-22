using hf.Domain.Entities;

namespace hf.Domain.Abstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetProductReadonlyAsync(CancellationToken cancellationToken = default);

        Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddProductAsync(Product product, CancellationToken cancellationToken);
    }
}
