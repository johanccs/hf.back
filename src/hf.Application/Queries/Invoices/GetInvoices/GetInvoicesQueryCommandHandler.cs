using hf.Application.Abstractions;
using hf.Domain.Abstractions;
using hf.Domain.Entities;
using hf.Domain.Entities.Extensions;
using Microsoft.Extensions.Logging;

namespace hf.Application.Queries.Invoices.GetInvoices
{
    internal sealed class GetInvoicesQueryCommandHandler : IQueryHandler<GetInvoicesQuery, List<InvoiceUserExtension?>>
    {
        #region readonly fields

        private readonly ILogger<GetInvoicesQueryCommandHandler> _logger;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUserRepository _userRepository;

        #endregion

        #region ctor

        public GetInvoicesQueryCommandHandler(
            ILogger<GetInvoicesQueryCommandHandler>logger, IInvoiceRepository invoiceRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _invoiceRepository = invoiceRepository;
            _userRepository = userRepository;
        }

        #endregion

        public async Task<Result<List<InvoiceUserExtension?>>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoiceUsers = new List<InvoiceUserExtension>();
            var results = await _invoiceRepository.GetInvoicesByClientIdAsync(request.Id, cancellationToken);
            var user = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);

            foreach (var result in results) {
                invoiceUsers.Add(InvoiceUserExtension.Instance(result, user));
            }

            _logger.LogInformation($"{results.Count()} Invoice(s) to database");

            return Result.Success( invoiceUsers )!;
        }
    }
}
