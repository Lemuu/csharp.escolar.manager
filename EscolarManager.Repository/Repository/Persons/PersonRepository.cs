using EscolarManager.Repository.Storage.actions;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Repository.Services;
using System;
using EscolarManager.Models.Person;

namespace EscolarManager.Repository.Persons
{
    public class StudentRepository : IRepository<Person>
    {

        protected internal const string TableName = "persons_data";
        public StudentRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`name` VARCHAR(150) NOT NULL, " +
                "`address` VARCHAR(150) NOT NULL, " +
                "`CPF` VARCHAR(16) NOT NULL" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(Person data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (name,address,CPF) VALUES (@name,@address,@CPF);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(Person data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `name`='@name', `address`='@address', `CPF`='@CPF') WHERE `id`={data.Id}", ToDictionaryObjects(data));
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
                            Convert.ToString(reader["name"]),
                            Convert.ToString(reader["address"]),
                            Convert.ToString(reader["CPF"])
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
            items.Add("@name", data.Name);
            items.Add("@address", data.Address);
            items.Add("@CPF", data.CPF);
            return items;
        }
    }
}
