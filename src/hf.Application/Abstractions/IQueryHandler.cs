using hf.Domain.Abstractions;
using MediatR;

namespace hf.Application.Abstractions
{
    public interface IQueryHandler<TQuery,TResponse> : IRequestHandler<TQuery,Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
