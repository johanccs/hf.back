using hf.Application.Abstractions;
using hf.Domain.Entities.Extensions;

namespace hf.Application.Queries.Invoices.GetInvoices
{
    public sealed class GetInvoicesQuery: IQuery<List<InvoiceUserExtension?>>
    {
        public GetInvoicesQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
