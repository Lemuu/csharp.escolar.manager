using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Phone;
using EscolarManager.Repository.Services;
using EscolarManager.Repository.Storage.actions;

namespace EscolarManager.Repository.Repository.ClassTeams
{
    public class ClassTeamsStudentsRepository : IRepository<ClassTeam>
    {

        public const string TableName = "class_team_students_data";
        public ClassTeamsStudentsRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`id_classTeam` INTEGER NOT NULL, " +
                "`DDD` VARCHAR(5) NOT NULL," +
                "`number` VARCHAR(40) NOT NULL," +
                $"FOREIGN KEY `id_classTeam` REFERENCES {ClassTeamsRepository.TableName}(`id`)" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(ClassTeam data, Phone phone)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (id_classTeam,DDD,number) VALUES (@id_classTeam,@DDD,@number);", ToDictionaryObjects(data, phone));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public bool Insert(ClassTeam data)
        {
            throw new NotImplementedException();
        }

        public void Update(ClassTeam data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ClassTeam data)
        {
            throw new NotImplementedException();
        }

        public List<ClassTeam> FindAll()
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
                        ), Convert.ToInt32(reader["id_classTeam"])
                    );

                }
            }
            catch (SQLiteException)
            {
                throw;
            }
            return phones;
        }

        public List<Phone> FindOneByIdClassTeam(int idClassTeam)
        {
            List<Phone> users = new();
            try
            {
                SQLiteCommand command = new($"SELECT * FROM {TableName} WHERE `id_classTeam`={idClassTeam};", StorageServices.DbConnection().Connection);

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

        private Dictionary<string, object> ToDictionaryObjects(ClassTeam data, Phone phone)
        {
            Dictionary<string, object> items = new();
            items.Add("@name", data.Name);
            return items;
        }
    }
}
