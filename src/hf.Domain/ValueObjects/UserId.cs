namespace hf.Domain.ValueObjects
{
    public class UserId
    {
        public Guid Id { get;}

        public UserId(Guid id)
        {
            Id = id;
        }
    }
}
