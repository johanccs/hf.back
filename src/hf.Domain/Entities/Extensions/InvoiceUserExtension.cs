namespace hf.Domain.Entities.Extensions
{
    public class InvoiceUserExtension
    {
        public string? FriendlyName  { get; private set; }
        public InvoiceHeader? InternalInvoiceHeader { get; private set; }

        private InvoiceUserExtension(InvoiceHeader? header, User? user)
        {
            InternalInvoiceHeader = header;
            FriendlyName = $"{user.Name} {user.Surname}";
        }

        public static InvoiceUserExtension Instance(InvoiceHeader? header, User? user) 
        {
            return new InvoiceUserExtension(header, user);
        }
    }
}
