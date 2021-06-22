using EscolarManager.Repository.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace EscolarManager.Repository.Storage.actions
{
    public class Query
    {
        private string Command { get; set; }
        private Dictionary<string, object> Objects = new Dictionary<string, object>();
        public int IdGenerated { get; set; }

        public Query()
        {
        }

        public Query(string command)
        {
            this.Append(command);
        }

        public void Append(Query query)
        {
            this.Append(query.Command, query.Objects);
        }

        public void Append(string command)
        {
            this.Append(command, new Dictionary<string, object>());
        }

        public void Append(string command, Dictionary<string, object> objects)
        {
            this.Command += command;
            foreach (var x in objects)
            {
                this.Objects.Add(x.Key, x.Value);
            }
        }

        public bool Execute()
        {
            try
            {
                SQLiteCommand command = new(this.Command, StorageServices.DbConnection().Connection);
                foreach (var x in this.Objects)
                {
                    command.Parameters.Add(new SQLiteParameter(x.Key, x.Value));
                }
                IdGenerated = command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

    }
}
