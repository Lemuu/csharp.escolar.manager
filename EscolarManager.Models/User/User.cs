namespace EscolarManager.Models.User
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; }
        public string Password { get; }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public User(int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }
    }

}
