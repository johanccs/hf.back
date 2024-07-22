using hf.Application.Abstractions;
using hf.Domain.Entities;

namespace hf.Application.Commands.Products.CreateProduct
{
    public sealed record CreateProductCommand(Product Product): ICommand<Guid>;
}
