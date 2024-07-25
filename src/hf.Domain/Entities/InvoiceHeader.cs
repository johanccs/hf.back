using hf.Domain.Abstractions;

namespace hf.Domain.Entities
{
    public class InvoiceHeader: Entity
    {
        public Guid ClientId { get; private set; }
        public string Date { get; private set; }
        public decimal Subtotal { get; set; }
        public List<InvoiceLine> InvoiceLines { get; private set; }

        public InvoiceHeader():base(Guid.NewGuid())
        {

        }

        public InvoiceHeader(Guid invoiceId, Guid clientId, string date, List<InvoiceLine> invoiceLines)
            :base(invoiceId)
        {
            ClientId = clientId;
            Date = date;
            InvoiceLines = invoiceLines;
        }

        protected override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
