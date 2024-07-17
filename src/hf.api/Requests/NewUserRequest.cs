namespace hf.api.Requests
{
    public record NewUserRequest(
        string Name, 
        string Surname, 
        string AccountType, 
        string DateRegistered);
}
