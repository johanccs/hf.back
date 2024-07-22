using hf.Domain.Abstractions;
using MediatR;

namespace hf.Application.Abstractions
{
    public interface ICommand: IRequest<Result>{}

    public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
}
