using hf.Domain.Abstractions;

namespace hf.Domain.Entities
{
    public class Login:Entity
    {
        public Login():base(Guid.NewGuid())
        {

        }
        public string Username { get; set; }
        public string Password { get; set; }

        protected override bool Validate()
        {
            return true;
        }
    }
}
