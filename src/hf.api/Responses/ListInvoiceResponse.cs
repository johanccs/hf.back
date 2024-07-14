
namespace hf.api.Responses
{
    public record ListInvoiceResponse(
        int Id,
        int ClientId,
        string ClientName,
        string ProductName,
        string ProductDescription,
        int Quantity,
        decimal Price,
        string ImageLink
     );
}
