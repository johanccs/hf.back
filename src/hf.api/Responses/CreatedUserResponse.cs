namespace hf.Api.Responses
{
    public record CreatedUserResponse(
        int Id,
        string Name, 
        string Surname, 
        string Email,
        string Username,
        bool IsAdmin, 
        string DateRegistered,
        bool AccountLocked);
}
