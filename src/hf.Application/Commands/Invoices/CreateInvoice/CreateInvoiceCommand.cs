using hf.Application.Abstractions;
using hf.Domain.Entities;

namespace hf.Application.Commands.Invoices.CreateInvoice
{
    public sealed record CreateInvoiceCommand(InvoiceHeader Invoice): ICommand<Guid>
    {
    }
}
