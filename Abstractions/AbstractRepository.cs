using System.Data;

namespace WebAPI_MNS_Games.Abstractions
{
    public class AbstractRepository
    {
        protected readonly IDbConnection _dbConnection;

        public AbstractRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        protected IDbCommand ConnectToDbAndInitializeCommand()
        {
            _dbConnection.Open();
            return _dbConnection.CreateCommand();
        }
    }
}
