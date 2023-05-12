using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.App_Code.Helpers;
using WebAPI_MNS_Games.Domain;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Repo
{
    public class AppUserRepository : AbstractRepository, IAppUserRepository
    {
        public AppUserRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            List<AppUser> appUsers = new List<AppUser>();

            // SQL Query preparation
            IDbCommand sqlCommand = ConnectToDbAndInitializeCommand();
            DbCommandHelper.SetStoredProcedureName(sqlCommand, "SP_GET_ALL_USERS");

            IDataReader sqlReader = sqlCommand.ExecuteReader();
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
            AppUser? appUserModel = null;
            IDbCommand sqlCommand = ConnectToDbAndInitializeCommand();
            DbCommandHelper.SetStoredProcedureName(sqlCommand, "SP_GET_USER_BY_ID");

            DbCommandHelper.AddParameterWithValue(sqlCommand, "@ID", id);

            IDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read()) // returns true while there is something to read
            {
                appUserModel = AppUserHelper.ConvertReaderToAppUser(sqlReader);
            }
            _dbConnection.Close();

            return appUserModel;
        }

        public string CreateAppUser(AppUser appUser)
        {
            IDbCommand sqlCommand = ConnectToDbAndInitializeCommand();
            DbCommandHelper.SetStoredProcedureName(sqlCommand, "SP_INSERT_NEW_USER");
            DbCommandHelper.SetProcedureParameters(appUser, sqlCommand);

            IDbDataParameter returnCodeParameter = DbCommandHelper.AddOutputParameter(sqlCommand, "ReturnCode", DbType.String);

            sqlCommand.ExecuteNonQuery();
            
            _dbConnection.Close();

            return returnCodeParameter.Value.ToString();
        }

        public string UpdateAppUser(AppUser appUser, int id)
        {
            IDbCommand sqlCommand = ConnectToDbAndInitializeCommand();
            DbCommandHelper.SetStoredProcedureName(sqlCommand, "SP_UPDATE_USER");
            DbCommandHelper.SetProcedureParameters(appUser, sqlCommand);

            IDbDataParameter returnCodeParameter = DbCommandHelper.AddOutputParameter(sqlCommand, "ReturnCode", DbType.String);

            sqlCommand.ExecuteNonQuery();

            _dbConnection.Close();

            return returnCodeParameter.Value.ToString();
        }

        public void DeleteAppUser(int id)
        {
            IDbCommand sqlCommand = ConnectToDbAndInitializeCommand();
            DbCommandHelper.SetStoredProcedureName(sqlCommand, "SP_DELETE_USER");
            DbCommandHelper.AddParameterWithValue(sqlCommand, "ID", id);

            sqlCommand.ExecuteNonQuery();

            _dbConnection.Close();
        }
    }
}

//Just in case 
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@LoginNickname", appUser.LoginNickname);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@LoginPassword", appUser.LoginPassword);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@FirstName", appUser.FirstName);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@LastName", appUser.LastName);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@Email", appUser.Email);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@IsAdmin", appUser.IsAdmin);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@StreetNumber", appUser.StreetNumber);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@StreetName", appUser.StreetName);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@Zipcode", appUser.Zipcode);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@City", appUser.City);
//DbCommandHelper.AddParameterWithValue(sqlCommand, "@Country", appUser.Country);