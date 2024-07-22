using hf.Application.Abstractions;
using hf.Domain.Abstractions;
using hf.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace hf.Application.Queries.Products.GetProducts
{
    public sealed class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<Product?>>
    {
        private readonly ILogger<GetProductsQueryHandler> _logger;
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(ILogger<GetProductsQueryHandler>logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<Result<IEnumerable<Product?>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var results = await _productRepository.GetProductReadonlyAsync();

            _logger.LogInformation($"{results.Count()} Products fetched from database");

            return Result.Success(results);
        }
    }
}
