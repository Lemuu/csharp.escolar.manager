namespace EscolarManager.Models.User
{
    class User
        : IUser
    {
        public long Id { get; }
        public string Username { get; }
        public string Email { get; }
        public string Password { get; }
    }
}
