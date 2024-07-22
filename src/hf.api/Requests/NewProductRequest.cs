namespace hf.Api.Requests
{
    public class NewProductRequest
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}
