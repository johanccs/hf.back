namespace hf.Api.Requests
{
    public class InvoiceHeaderRequest
    {
        public Guid ClientId { get; set; }
        public string Date { get; set; }
        public decimal Subtotal { get; set; }
        public List<InvoiceLineRequest> InvoiceLines { get; set; }

    }
}
