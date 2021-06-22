using EscolarManager.Repository.Storage.actions;
using EscolarManager.Models.User;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Repository.Services;
using System;

namespace EscolarManager.Repository.Users
{
    public class UserRepository : IRepository<User>
    {

        private const string TableName = "users_data";
        public UserRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`username` VARCHAR(16) NOT NULL, " +
                "`email` VARCHAR(64) NOT NULL, " +
                "`password` TEXT NOT NULL" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(User data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (username,email,password) VALUES (@username,@email,@password);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(User data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `username`='@username', `email`='@email', `password`='@password' WHERE `id`={data.Id}", ToDictionaryObjects(data));
            query.Execute();
        }

        public List<User> FindAll()
        {
            List<User> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName}", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(
                        new User(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToString(reader["username"]),
                            Convert.ToString(reader["email"]),
                            Convert.ToString(reader["password"])
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
            return query.Execute();
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
