using hf.Application.Abstractions;
using hf.Domain.Entities;

namespace hf.Application.Queries.Logins
{
    public class LoginQuery: IQuery<User>
    {
        public LoginQuery(Login login)
        {
            Login = login;
        }

        public Login Login { get; }
    }
}
