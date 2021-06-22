using EscolarManager.Repository.Storage.actions;
using System.Collections.Generic;
using System.Data.SQLite;
using EscolarManager.Repository.Services;
using System;
using EscolarManager.Models.Student;
using EscolarManager.Repository.Persons;

namespace EscolarManager.Repository.Students
{
    public class StudentRepository : IRepository<Student>
    {

        private const string TableName = "students_data";
        public StudentRepository()
        {
            this.Table();
        }

        public bool Table()
        {
            Query query = new(
                $"CREATE TABLE IF NOT EXISTS `{TableName}` (" +
                "`id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "`id_person` INTEGER NOT NULL, " +
                "`id_responsible` INTEGER NOT NULL, " +
                "`id_classTeam` INTEGER NOT NULL, " +
                $"FOREIGN KEY `id_person` REFERENCES {PersonRepository.TableName}(`id`), " +
                $"FOREIGN KEY `id_responsible` REFERENCES {PersonRepository.TableName}(`id`), " +
                $"FOREIGN KEY `id_classTeam` REFERENCES {PersonRepository.TableName}(`id`)" +
                ");"
            );
            return query.Execute();
        }

        public bool Insert(Student data)
        {
            Query query = new();
            query.Append($"INSERT INTO {TableName} (id_person,id_responsible,id_classTeam) VALUES (@id_person,@id_responsible,@id_classTeam);", ToDictionaryObjects(data));
            bool result = query.Execute();
            data.Id = query.IdGenerated;
            return result;
        }

        public void Update(Student data)
        {
            Query query = new();
            query.Append($"UPDATE {TableName} SET `id_person`='@id_person', `id_responsible`='@id_responsible', `id_classTeam`='@id_classTeam' WHERE `id`={data.Id}", ToDictionaryObjects(data));
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
                            Repositories.PersonRepository.FindOneById(Convert.ToInt32(reader["id_person"])),
                            Repositories.PersonRepository.FindOneById(Convert.ToInt32(reader["id_responsible"])),
                            Repositories.ClassTeamsRepository.FindOneById(Convert.ToInt32(reader["id_classTeam"]))
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
            items.Add("@id_person", data.Person.Id);
            items.Add("@id_responsible", data.Responsible.Id);
            items.Add("@id_classTeam", data.ClassTeam.Id);
            return items;
        }
    }
}
