using hf.Domain.Abstractions;
using hf.Domain.DomainExceptions;

namespace hf.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public bool IsAdmin { get; private set; }
        public string DateRegistered { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; set; }
        public bool AccountLocked { get; private set; }


        public User():base(Guid.NewGuid())
        {

        }

        public User(
            Guid userId, 
            string name, 
            string surname,
            string email,
            string username,
            string password,
            bool accountLocked, 
            bool isAdmin,
            string dateRegistered) : base(userId)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Username = username;
            Password = password;
            AccountLocked = accountLocked;
            IsAdmin = isAdmin;
            DateRegistered = dateRegistered;
        }

        //todo: Replace with value objects
        public void UpdateName(string name) => Name = name;
        public void UpdateSurname(string surname) => Surname = surname;
        public void UpdateDateRegistered(string dateRegistered) => DateRegistered = dateRegistered;

        protected override bool Validate()
        {
            if (Name is null)
                throw new InvalidEntityPropertyException($"{nameof(Name)} is required");

            if (Surname is null)
                throw new InvalidEntityPropertyException($"{nameof(Surname)} is required");

            if(Email is null)
                throw new InvalidEntityPropertyException($"{nameof(Email)} is required");

            if (Username is null)
                throw new InvalidEntityPropertyException($"{nameof(Username)} is required");

            if (Password is null)
                throw new InvalidEntityPropertyException($"{nameof(Password)} is required");

            if ((DateTime.Parse(DateRegistered)) < DateTime.Now)
                throw new InvalidEntityPropertyException($"{nameof(DateRegistered)} cannot be in the past");

            return true;

        }
    }
}
