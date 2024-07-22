using hf.Application.Abstractions;
using hf.Domain.Abstractions;

namespace hf.Application.Commands.Users.CreateUser
{
    internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _userRepository.AddAsync(command.User, cancellationToken);
            var saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (saveResult > 0)
            {
                var result = Result.Success<Guid>(command.User.Id);

                return result;
            }
            else
            {
                return Result.Failure<Guid>(new Error("500", "InterServerError"));
            }
        }
    }
}
