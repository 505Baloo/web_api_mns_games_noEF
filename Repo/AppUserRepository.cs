using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
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

        public AppUser GetAppUserModelById(int id)
        {
            AppUser appUserModel = null;
            string query = $"SELECT * FROM AppUser Where ID={id}";
            IDbCommand commandDb = ConnectToDbAndInitializeCommand();
            commandDb.CommandText = query;

            IDataReader sqlReader = commandDb.ExecuteReader();
            while (sqlReader.Read()) // returns true while there is something to read
            {
                appUserModel = AppUserHelper.ConvertReaderToAppUser(sqlReader);
            }
            _dbConnection.Close();

            return appUserModel;
        }

        public void CreateAppUser(AppUser appUser)
        {
            IDbCommand sqlCommand = ConnectToDbAndInitializeCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;

            DbCommandHelper.AddParameterWithValue(sqlCommand, "LoginNickname", appUser.LoginNickname);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "LoginPassword", appUser.LoginPassword);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "FirstName", appUser.FirstName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "LastName", appUser.LastName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "Email", appUser.Email);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "IsAdmin", appUser.IsAdmin);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "StreetNumber", appUser.StreetNumber);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "StreetName", appUser.StreetName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "Zipcode", appUser.Zipcode);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "City", appUser.City);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "Country", appUser.Country);

            sqlCommand.ExecuteNonQuery();

            _dbConnection.Close();
        }
    }
}
