using EscolarManager.Repository.Storage.actions;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Repository.Services;
using System;
using EscolarManager.Models.Person;
using EscolarManager.Models.Phone;

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
                "`DDD` VARCHAR(5) NOT NULL," +
                "`number` VARCHAR(40) NOT NULL," +
                $"FOREIGN KEY `id_person` REFERENCES {PersonRepository.TableName}(`id`)" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(Person data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (DDD,email) VALUES (@DDD,@number);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(Person data)
        {
            throw new NotImplementedException();
        }

        public List<Person>FindAll()
        {
            throw new NotImplementedException();
        }

        public Dictionary<Phone, int> FindAllPhones()
        {
            Dictionary<Phone, int> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName}", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new Phone(
                           Convert.ToString(reader["DDD"]),
                           Convert.ToString(reader["number"])
                        ), Convert.ToInt32(reader["id_person"])
                    );

                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return users;
        }

        public List<Phone> FindOneByIdPerson(int idPerson)
        {
            List<Phone> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName} WHERE `id_person`={idPerson};", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    users.Add(
                        new Phone(
                            Convert.ToString(reader["DDD"]),
                            Convert.ToString(reader["number"])
                        )
                    );
                    return users;
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return null;
        }

        public bool Delete(Person data)
        {
            Query query = new();
            query.Append($"DELETE FROM {TableName} WHERE `id_person`={data.Id}");
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
