using hf.Application.Abstractions;
using hf.Domain.Entities;

namespace hf.Application.Queries.Products.GetProducts
{
    public sealed class GetProductsQuery: IQuery<IEnumerable<Product?>>
    {
        public GetProductsQuery() { }
    }
}
