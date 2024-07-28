using hf.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace hf.Domain.Entities
{
    public class Login:Entity
    {
        public Login():base(Guid.NewGuid())
        {

        }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        protected override bool Validate()
        {
            return true;
        }
    }
}
