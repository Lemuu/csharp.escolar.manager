using EscolarManager.Repository.Storage.actions;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Repository.Services;
using System;
using EscolarManager.Models.Person;
using EscolarManager.Models.School;

namespace EscolarManager.Repository.Schools
{
    public class SchoolRepository : IRepository<School>
    {

        public const string TableName = "school_data";
        public SchoolRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`name`  VARCHAR(150) NOT NULL, " +
                "`CNPJ`  VARCHAR(32) NOT NULL, " +
                "`address`  VARCHAR(150) NOT NULL, " +
                "`email`  VARCHAR(150) NOT NULL" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(School data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (name,CNPJ,address,email) VALUES (@name,@CNPJ,@address,@email);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(School data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `name`='@name', `CNPJ`='@CNPJ', `address`='@address', `email`='@email' WHERE `id`={data.Id}", ToDictionaryObjects(data));
            query.Execute();
        }

        public List<School> FindAll()
        {
            List<School> schools = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName}", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    School school = new(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToString(reader["name"]),
                            Convert.ToString(reader["CNPJ"]),
                            Convert.ToString(reader["address"]),
                            Convert.ToString(reader["email"])
                    );
                    Repositories.SchoolPhonesRepository.FindOneByIdSchool(school.Id).ForEach(phone => school.AddPhone(phone));

                    schools.Add(school);
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return schools;
        }
        public bool Delete(School data)
        {
            Query query = new();
            query.Append($"DELETE FROM {TableName} WHERE `id`={data.Id}");
            return query.Execute();
        }

        public School FindOneByName(string name)
        {
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName} WHERE `name`={name};", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    School school = new(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToString(reader["name"]),
                            Convert.ToString(reader["CNPJ"]),
                            Convert.ToString(reader["address"]),
                            Convert.ToString(reader["email"])
                    );
                    Repositories.SchoolPhonesRepository.FindOneByIdSchool(school.Id).ForEach(phone => school.AddPhone(phone));

                    return school;
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return null;
        }

        private Dictionary<string, object> ToDictionaryObjects(School data)
        {
            Dictionary<string, object> items = new();
            items.Add("@name", data.Name);
            items.Add("@CNPJ", data.CNPJ);
            items.Add("@address", data.Address);
            items.Add("@email", data.Email);
            return items;
        }
    }
}
