using hf.Domain.Abstractions;
using hf.Domain.Entities;
using hf.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace hf.Infrastructure.Repositories
{
    internal sealed class InvoiceRepository : BaseRepository<InvoiceHeader>, IInvoiceRepository
    {
        #region ctor

        public InvoiceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region methods

        public async Task AddInvoiceAsync(InvoiceHeader invoice, CancellationToken cancellationToken)
        {
            await AddAsync(invoice, cancellationToken);
        }

        public async Task<InvoiceHeader?> GetInvoiceByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetInvoiceByIdAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<InvoiceHeader?>> GetInvoiceReadonlyAsync(CancellationToken cancellationToken = default)
        {
            return await GetAllReadonlyAsync(cancellationToken);
        }

        public async Task<IEnumerable<InvoiceHeader?>> GetInvoicesByClientIdAsync(string clientId, CancellationToken cancellationToken = default)
        {
            var allInvoices = await DbContext
                .InvoiceHeaders
                .Include(x => x.InvoiceLines)
                .Where(x => x.ClientId.ToString() == clientId).ToListAsync();

            return allInvoices;
        }

        #endregion
    }
}
