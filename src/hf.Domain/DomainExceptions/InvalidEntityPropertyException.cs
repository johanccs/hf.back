namespace hf.Domain.DomainExceptions
{
    public class InvalidEntityPropertyException: Exception
    {
        public InvalidEntityPropertyException(string message)
            :base(message){ }
    }
}
