namespace hf.Api.Responses
{
    public record ListProductResponse(
        int Id, 
        string ProductName, 
        string ProductDescription, 
        decimal Price, 
        int Quantity,
        string ImageLink);
}
