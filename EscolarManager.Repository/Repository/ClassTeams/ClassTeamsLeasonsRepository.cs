using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Leason;
using EscolarManager.Repository.Services;
using EscolarManager.Repository.Storage.actions;

namespace EscolarManager.Repository.Repository.ClassTeams
{
    public class ClassTeamsLeasonsRepository : IRepository<ClassTeam>
    {

        public const string TableName = "class_team_leasons_data";
        public ClassTeamsLeasonsRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`id_classTeam` INTEGER NOT NULL, " +
                "`id_leason` INTEGER NOT NULL, " +
                $"FOREIGN KEY `id_classTeam` REFERENCES {ClassTeamsRepository.TableName}(`id`)" +
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

        public List<Leason> FindOneByIdClassTeam(int idClassTeam)
        {
            List<Leason> leasons = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName} WHERE `id_classTeam`={idClassTeam};", StorageServices.DbConnection().Connection);

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    leasons.Add(Repositories.LeasonRepository.FindOneById(Convert.ToInt32(reader["id_leason"])));
                }
                return leasons;
            }
            catch (SQLiteException)
            {
                throw;
            }
            return leasons;
        }

        private Dictionary<string, object> ToDictionaryObjects(ClassTeam data)
        {
            Dictionary<string, object> items = new();
            items.Add("@name", data.Name);
            return items;
        }

    }
}
