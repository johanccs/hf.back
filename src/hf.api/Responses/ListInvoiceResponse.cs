
namespace hf.Api.Responses
{
    public record ListInvoiceResponse(
        string Id, string ClientId, string FriendlyName, string Date, decimal Subtotal);
}
