using hf.Application.Abstractions;
using hf.Domain.Abstractions;
using Microsoft.Extensions.Logging;

namespace hf.Application.Commands.Invoices.CreateInvoice
{
    internal class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, Guid>
    {
        #region readonly fields 

        private readonly ILogger<CreateInvoiceCommandHandler> _logger;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region ctor

        public CreateInvoiceCommandHandler(
            ILogger<CreateInvoiceCommandHandler>logger, IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Result<Guid>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = request.Invoice;

            await _invoiceRepository.AddInvoiceAsync(invoice, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"{result} Invoice added to database");

            return Result.Success<Guid>(invoice.Id);
        }

        #endregion
    }
}
