using EscolarManager.Storage.connection;

namespace EscolarManager.Repository.Services
{
    public static class StorageServices
    {
        private static DbConnection _dbConnection;

        public static void Init()
        {
            StorageServices._dbConnection = new DbConnection();
            StorageServices._dbConnection.OpenConnection();
        }

        public static void Disable()
        {
            StorageServices._dbConnection.CloseConnection();
            StorageServices._dbConnection = null;
        }

        public static DbConnection DbConnection()
        {
            return StorageServices._dbConnection;
        }

    }
}
