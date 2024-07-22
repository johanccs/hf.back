using hf.Application.Abstractions;
using hf.Domain.Abstractions;
using hf.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace hf.Application.Queries.Users.GetUsers
{
    internal sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<User?>>
    {
        #region readonly fields

        private readonly ILogger<GetUsersQueryHandler> _logger;
        private readonly IUserRepository _userRepository;

        #endregion

        #region ctor

        public GetUsersQueryHandler(ILogger<GetUsersQueryHandler>logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        #endregion

        #region methods

        public async Task<Result<IEnumerable<User?>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var results = await _userRepository.GetReadonlyAsync();

            _logger.LogInformation($"{results.Count()} Users fetched from database");

            return Result.Success(results);
        }

        #endregion
    }
}
