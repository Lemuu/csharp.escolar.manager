using System.Data;
using System.Data.SQLite;
using System.IO;

namespace EscolarManager.Storage.connection
{
    public class DbConnection
    {
        private const string _path = @"C:\Users\Escolar Manager\source\repos\EscolarManager";
        public SQLiteConnection Connection { get; private set; }

        public DbConnection()
        {
            this.OpenConnection();
        }

        public bool OpenConnection()
        {
            try
            {
                if (this.Connection == null || this.Connection.State.Equals(ConnectionState.Closed))
                {
                    if (!File.Exists($@"{_path}\EscolarManager.db"))
                    {
                        SQLiteConnection.CreateFile($@"{_path}\EscolarManager.db");
                    }
                    this.Connection = new SQLiteConnection($@"Data Source = {_path}\EscolarManager.db");
                    this.Connection.Open();
                }
                return true;
            } catch {
                return false;
            }
        }

        public bool CloseConnection()
        {
            if (!this.Connection.State.Equals(ConnectionState.Closed))
            {
                this.Connection.Close();
                this.Connection.Dispose();
                return true;
            } else
            {
                this.Connection.Dispose();
                return false;
            }
        }

    }
}
