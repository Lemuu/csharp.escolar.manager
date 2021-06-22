using EscolarManager.Repository.Storage.actions;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Repository.Services;
using System;
using EscolarManager.Models.School;
using EscolarManager.Models.Phone;

namespace EscolarManager.Repository.Schools
{
    public class SchoolPhonesRepository : IRepository<School>
    {

        public const string TableName = "schools_phones_data";
        public SchoolPhonesRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`id_school` INTEGER NOT NULL, " +
                "`DDD` VARCHAR(5) NOT NULL," +
                "`number` VARCHAR(40) NOT NULL," +
                $"FOREIGN KEY `id_school` REFERENCES {SchoolRepository.TableName}(`id`)" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(School data, Phone phone)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (id_school,DDD,number) VALUES (@id_school,@DDD,@number);", ToDictionaryObjects(data, phone));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public bool Insert(School data)
        {
            throw new NotImplementedException();
        }

        public void Update(School data)
        {
            throw new NotImplementedException();
        }

        public List<School> FindAll()
        {
            throw new NotImplementedException();
        }

        public Dictionary<Phone, int> FindAllPhones()
        {
            Dictionary<Phone, int> phones = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName}", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    phones.Add(new Phone(
                           Convert.ToString(reader["DDD"]),
                           Convert.ToString(reader["number"])
                        ), Convert.ToInt32(reader["id_school"])
                    );

                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return phones;
        }

        public List<Phone> FindOneByIdSchool(int idSchool)
        {
            List<Phone> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName} WHERE `id_school`={idSchool};", StorageServices.DbConnection().Connection);

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

        public bool Delete(School data)
        {
            Query query = new();
            query.Append($"DELETE FROM {TableName} WHERE `id_school`={data.Id}");
            return query.Execute();
        }

        private Dictionary<string, object> ToDictionaryObjects(School data, Phone phone)
        {
            Dictionary<string, object> items = new();
            items.Add("@id_school", data.Id);
            items.Add("@DDD", phone.DDD);
            items.Add("@number", phone.Number);
            return items;
        }
    }
}
