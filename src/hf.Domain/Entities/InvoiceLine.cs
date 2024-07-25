using hf.Domain.Abstractions;

namespace hf.Domain.Entities
{
    public class InvoiceLine : Entity
    {
        public Guid InvoiceHeaderId { get; set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public InvoiceHeader InvoiceHeader { get; set; }

        public InvoiceLine():base(Guid.NewGuid()) { }

        public InvoiceLine(Guid invoiceId, Guid productId, int quantity, decimal price)
            :base(invoiceId)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        protected override bool Validate()
        {
            return true;
        }
    }
}
