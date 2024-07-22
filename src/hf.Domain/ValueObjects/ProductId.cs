namespace hf.Domain.ValueObjects
{
    public class ProductId
    {
        public Guid Id { get;}

        public ProductId(Guid id)
        {
            Id = id;
        }
    }
}
