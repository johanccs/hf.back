using hf.Application.Abstractions;
using hf.Domain.Abstractions;
using Microsoft.Extensions.Logging;

namespace hf.Application.Commands.Products.CreateProduct
{
    internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {
        #region readonly fields

        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region ctor

        public CreateProductCommandHandler(
            ILogger<CreateProductCommandHandler>logger, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;
            await _productRepository.AddProductAsync(product, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"{result} Product added to database");

            return Result.Success<Guid>(product.Id);
        }

        #endregion
    }
}
