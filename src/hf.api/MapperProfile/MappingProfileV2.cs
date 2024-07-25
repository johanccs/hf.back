using hf.Api.Responses;
using hf.Domain.Entities.Extensions;

namespace hf.Api.MapperProfile
{
    public static class MappingProfileV2
    {
        public static List<ListInvoiceResponse> MapTo(List<InvoiceUserExtension?> from)
        {
            var internalInvoiceResponses = new List<ListInvoiceResponse>();

            foreach (var item in from)
            {
                internalInvoiceResponses.Add(
                    new ListInvoiceResponse(
                        item.InternalInvoiceHeader.Id.ToString(),
                        item.InternalInvoiceHeader.ClientId.ToString(),
                        item.FriendlyName,
                        item.InternalInvoiceHeader.Date,
                        item.InternalInvoiceHeader.Subtotal));
            }

            return internalInvoiceResponses;
        }
    }
}
