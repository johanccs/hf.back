namespace hf.Api.Requests
{
    public record NewUserRequest(
        string Name, 
        string Surname,
        string Email,
        string UserName,
        string Password,
        bool AccountLocked,
        bool IsAdmin,
        string DateRegistered);
}
