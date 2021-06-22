using EscolarManager.Repository.Storage.actions;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Repository.Services;
using System;
using EscolarManager.Models.Student;

namespace EscolarManager.Repository.Students
{
    public class StudentRepository : IRepository<Student>
    {

        private const string TableName = "users_data";
        public StudentRepository()
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

        public bool Insert(Student data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (username,email,password) VALUES (@username,@email,@password);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(Student data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `username`='@username', `email`='@email', `password`='@password') WHERE `id`={data.Id}", ToDictionaryObjects(data));
            query.Execute();
        }

        public List<Student> FindAll()
        {
            List<Student> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName}", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(
                        new Student(
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
        public bool Delete(Student data)
        {
            Query query = new();
            query.Append($"DELETE FROM {TableName} WHERE `id`={data.Id}");
            return query.Execute();
        }

        private Dictionary<string, object> ToDictionaryObjects(Student data)
        {
            Dictionary<string, object> items = new();
            items.Add("@username", data.Username);
            items.Add("@email", data.Email);
            items.Add("@password", data.Password);
            return items;
        }
    }
}
