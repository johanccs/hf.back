using hf.Application.Abstractions;
using hf.Domain.Entities;

namespace hf.Application.Commands.Users.CreateUser
{
    public sealed record CreateUserCommand(User User): ICommand<Guid>;
   
}
