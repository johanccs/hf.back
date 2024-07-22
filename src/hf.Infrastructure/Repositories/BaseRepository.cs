using hf.Domain.Abstractions;
using hf.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace hf.Infrastructure.Repositories
{
    internal abstract class BaseRepository<T> where T: Entity
    {
        protected readonly AppDbContext DbContext;

        protected BaseRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<T>> GetAllReadonlyAsync(CancellationToken cancellationToken)
        {
            try
            {
                var users = await DbContext
                    .Set<T>()
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task AddAsync(T entity)
        {
            await DbContext.AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
