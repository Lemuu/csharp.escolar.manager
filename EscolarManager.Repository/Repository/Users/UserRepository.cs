using EscolarManager.Repository.Storage.actions;
using EscolarManager.Models.User;
using System.Collections.Generic;
using System.Data.SQLite;

namespace EscolarManager.Repository.Users
{
    public class UserRepository : IRepository<User>
    {

        private const string TableName = "users_data";
        private readonly SQLiteConnection connection;
        public UserRepository(SQLiteConnection connection)
        {
            this.Table();
            this.connection = connection;
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` BIGINT(11) PRIMARY KEY, " +
                "`username` VARCHAR(16) NOT NULL, " +
                "`email` VARCHAR(64) NOT NULL, " +
                "`password` TEXT NOT NULL" +
                ");"
            );
            return query.Execute(connection);
        }

        public bool Insert(User data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (username,email,password) VALUES (@username,@email,@password);", ToDictionaryObjects(data));
            bool result = query.Execute(connection);
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(User data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `username`='@username', `email`='@email', `password`='@password') WHERE `id`={data.Id}", ToDictionaryObjects(data));
            query.Execute(connection);
        }

        public List<User> FindAll()
        {
            List<User> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * {TableName}", connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(
                        new User(
                            (long)reader["id"],
                            (string)reader["username"],
                            (string)reader["email"],
                            (string)reader["password"]
                        )
                    );
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return users;
        }
        public bool Delete(User data)
        {
            Query query = new();
            query.Append($"DELETE FROM {TableName} WHERE `id`={data.Id}");
            return query.Execute(connection);
        }

        private Dictionary<string, object> ToDictionaryObjects(User data)
        {
            Dictionary<string, object> items = new();
            items.Add("@username", data.Username);
            items.Add("@email", data.Email);
            items.Add("@password", data.Password);
            return items;
        }
    }
}
