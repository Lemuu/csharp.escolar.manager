using EscolarManager.Models.Id;

namespace EscolarManager.Models.User
{
    public interface IUser : IId
    {
        string Username { get; }
        string Email { get; }
        string Password { get; }
    }
}
