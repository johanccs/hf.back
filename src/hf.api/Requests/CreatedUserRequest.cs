namespace hf.api.Requests
{
    public record CreatedUserRequest(int Id, string Name, string Surname, string AccountType, DateTime DateRegistered)
    {
    }
}
