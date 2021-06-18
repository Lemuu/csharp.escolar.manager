namespace EscolarManager.Models.User
{
    interface IUser
    {
        long Id { get; }
        string Username { get; }
        string Email { get; }
        string Password { get; }
    }
}
