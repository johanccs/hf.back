namespace hf.api.Requests
{
    public record NewUserRequest(int Id, string Name, string Surname, string AccountType, DateTime DateRegistered)
    {
    }
}
