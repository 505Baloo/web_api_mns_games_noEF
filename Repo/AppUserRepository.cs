using System.Data;
using System.Data.SqlClient;
using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.App_Code.Helpers;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Repo
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public AppUserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        private IDbCommand ConnectToDbAndInitializeCommand()
        {
            _dbConnection.Open();
            return _dbConnection.CreateCommand();
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            List<AppUser> appUsers = new List<AppUser>();

            // SQL Query preparation
            string query = "SELECT * FROM AppUser";
            IDbCommand commandDb = ConnectToDbAndInitializeCommand();
            commandDb.CommandText = query;

            IDataReader sqlReader = commandDb.ExecuteReader();
            while (sqlReader.Read()) // returns true while there is something to read
            {
                // use the row from the database and create new model
                appUsers.Add(AppUserHelper.ConvertReaderToAppUser(sqlReader));
            }

            _dbConnection.Close();

            return appUsers;
        }
    }
}
