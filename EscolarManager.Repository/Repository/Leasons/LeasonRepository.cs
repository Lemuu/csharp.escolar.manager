using EscolarManager.Models.Leason;
using EscolarManager.Repository.Services;
using EscolarManager.Repository.Storage.actions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace EscolarManager.Repository.Repository.Leasons
{
    public class LeasonRepository : IRepository<Leason>
    {

        public const string TableName = "leasons_data";
        public LeasonRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`name` VARCHAR(150) NOT NULL, " +
                "`id_teacher` INTEGER NOT NULL" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(Leason data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (name,id_teacher) VALUES (@name,@id_teacher);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }
        public void Update(Leason data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `name`='@name', `id_teacher`='@id_teacher') WHERE `id`={data.Id}", ToDictionaryObjects(data));
            query.Execute();
        }
        public List<Leason> FindAll()
        {
            List<Leason> leasons = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName}", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Leason leason = new(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToString(reader["name"]),
                            Repositories.PersonRepository.FindOneById(Convert.ToInt32(reader["id_teacher"]))
                    );

                    leasons.Add(leason);
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return leasons;
        }

        public Leason FindOneById(long id)
        {
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName} WHERE `id`={id};", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Leason(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToString(reader["name"]),
                            Repositories.PersonRepository.FindOneById(Convert.ToInt32(reader["id_teacher"]))
                    );
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return null;
        }
        public bool Delete(Leason data)
        {
            Query query = new();
            query.Append($"DELETE FROM {TableName} WHERE `id`={data.Id}");
            return query.Execute();
        }

        private Dictionary<string, object> ToDictionaryObjects(Leason data)
        {
            Dictionary<string, object> items = new();
            items.Add("@name", data.Name);
            items.Add("@id_teacher", data.Teacher.Id);
            return items;
        }
    }
}
