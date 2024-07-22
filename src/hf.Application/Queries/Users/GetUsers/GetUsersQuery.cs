using hf.Application.Abstractions;
using hf.Domain.Entities;

namespace hf.Application.Queries.Users.GetUsers
{
    public class GetUsersQuery: IQuery<IEnumerable<User>>
    {
    }
}
