using hf.Domain.Abstractions;
using hf.Domain.Entities;
using hf.Infrastructure.Context;

namespace hf.Infrastructure.Repositories
{
    internal sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            await AddAsync(user, cancellationToken);
        }

        public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<User?>> GetReadonlyAsync(CancellationToken cancellationToken = default)
        {
            return await GetAllReadonlyAsync(cancellationToken);
        }

        public async Task<User> GetByUsernameByPassword(string username, string password, CancellationToken cancellationToken = default)
        {
            var users = await GetAllReadonlyAsync(cancellationToken);
            var user = users.FirstOrDefault(x => x.Username == username && x.Password == password);

            return user;
        }
    }
}