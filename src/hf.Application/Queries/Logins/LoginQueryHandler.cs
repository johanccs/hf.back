using hf.Application.Abstractions;
using hf.Domain.Abstractions;
using hf.Domain.Entities;

namespace hf.Application.Queries.Logins
{
    internal class LoginQueryHandler : IQueryHandler<LoginQuery, User>
    {
        #region readonly fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region ctor

        public LoginQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region methods

        public async Task<Result<User>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var login = request.Login;

            var result = await _userRepository.GetByUsernameByPassword(login.Username, login.Password);

            if (result is not null)
            {
                return Result.Success(result);
            }

            var r = Result.Failure(new User());

            return r;
        }

        #endregion
    }
}
