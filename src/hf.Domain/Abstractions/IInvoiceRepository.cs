using hf.Domain.Entities;

namespace hf.Domain.Abstractions
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<InvoiceHeader?>> GetInvoiceReadonlyAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<InvoiceHeader?>> GetInvoicesByClientIdAsync(string id, CancellationToken cancellationToken = default);

        Task<InvoiceHeader?> GetInvoiceByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddInvoiceAsync(InvoiceHeader invoice, CancellationToken cancellationToken);
    }
}
