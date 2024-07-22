using hf.Domain.Abstractions;
using MediatR;

namespace hf.Application.Abstractions
{
    public interface IQuery<TResponse>: IRequest<Result<TResponse>>
    {
    }
}
