using hf.Domain.Entities;

namespace hf.Domain.Abstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetReadonlyAsync(CancellationToken cancellationToken = default);

        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddAsync(Product product);
    }
}
