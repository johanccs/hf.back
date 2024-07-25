namespace hf.Api.Requests
{
    public class InvoiceLineRequest
    {
        public Guid InvoiceHeaderId {get;set;}
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
