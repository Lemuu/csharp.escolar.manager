using EscolarManager.Repository.Storage.actions;
using EscolarManager.Models.User;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Repository.Services;
using System;
using EscolarManager.Models.Person;

namespace EscolarManager.Repository.Persons
{
    public class PersonPhonesRepository : IRepository<Person>
    {

        private const string TableName = "persons_phones_data";
        public PersonPhonesRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`id_person` INTEGER NOT NULL, " +
                "`phone` VARCHAR(40) NOT NULL," +
                $"FOREIGN KEY `id_person` REFERENCES {StudentRepository.TableName}(`id`)" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(Person data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (username,email,password) VALUES (@username,@email,@password);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(Person data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `username`='@username', `email`='@email', `password`='@password') WHERE `id`={data.Id}", ToDictionaryObjects(data));
            query.Execute();
        }

        public List<Person> FindAll()
        {
            List<Person> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName}", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(
                        new Person(
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
        public bool Delete(Person data)
        {
            Query query = new();
            query.Append($"DELETE FROM {TableName} WHERE `id`={data.Id}");
            return query.Execute();
        }

        private Dictionary<string, object> ToDictionaryObjects(Person data)
        {
            Dictionary<string, object> items = new();
            items.Add("@Name", data.Name);
            items.Add("@Address", data.Address);
            items.Add("@CPF", data.CPF);
            return items;
        }
    }
}
