namespace hf.Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Entity(Guid id)
        {
            Id = id;
        }

        protected abstract bool Validate();
    }
}
