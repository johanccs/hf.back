using hf.Domain.Entities;

namespace hf.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User?>> GetReadonlyAsync(CancellationToken cancellationToken = default);

        Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken=default);

        Task AddAsync(User user, CancellationToken cancellationToken);

        Task<User> GetByUsernameByPassword(string username, string password, CancellationToken cancellationToken = default);
    }
}
