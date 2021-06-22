using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Models.ClassTeam;
using EscolarManager.Repository.Services;
using EscolarManager.Repository.Storage.actions;

namespace EscolarManager.Repository.Repository.ClassTeams
{
    public class ClassTeamsRepository : IRepository<ClassTeam>
    {

        public const string TableName = "persons_data";
        public ClassTeamsRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`name` VARCHAR(150) NOT NULL" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(ClassTeam data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (name) VALUES (@name);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(ClassTeam data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `name`='@name' WHERE `id`={data.Id}", ToDictionaryObjects(data));
            query.Execute();
        }

        public bool Delete(ClassTeam data)
        {
            throw new NotImplementedException();
        }

        public List<ClassTeam> FindAll()
        {
            List<ClassTeam> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName}", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ClassTeam classTeams = new(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToString(reader["name"])
                    );

                    users.Add(classTeams);
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return users;
        }

        public ClassTeam FindOneById(int id)
        {
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName} WHERE `id`={id};", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ClassTeam classTeam = new(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToString(reader["name"])
                    );
                    Repositories.ClassTeamsLeasonsRepository.FindOneByIdClassTeam(classTeam.Id).ForEach(leason => classTeam.AddLeason(leason));

                    return classTeam;
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return null;
        }

        private Dictionary<string, object> ToDictionaryObjects(ClassTeam data)
        {
            Dictionary<string, object> items = new();
            items.Add("@name", data.Name);
            return items;
        }

    }
}
