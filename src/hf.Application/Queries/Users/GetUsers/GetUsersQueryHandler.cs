using hf.Application.Abstractions;
using hf.Domain.Abstractions;
using hf.Domain.Entities;

namespace hf.Application.Queries.Users.GetUsers
{
    internal sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<User>>
    {
        #region readonly fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region ctor

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region methods

        public async Task<Result<IEnumerable<User?>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var results = await _userRepository.GetReadonlyAsync();

            return Result.Success(results);
        }

        #endregion
    }
}
