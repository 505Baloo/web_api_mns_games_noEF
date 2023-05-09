using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.App_Code.Helpers;
using WebAPI_MNS_Games.Domain;
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

        public void CreateAppUser(AppUser appUser)
        {
            IDbCommand sqlCommand = ConnectToDbAndInitializeCommand();
            DbCommandHelper.SetStoredProcedureName(sqlCommand, "SP_INSERT_NEW_USER");
            
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@LoginNickname", appUser.LoginNickname);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@LoginPassword", appUser.LoginPassword);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@FirstName", appUser.FirstName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@LastName", appUser.LastName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@Email", appUser.Email);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@IsAdmin", appUser.IsAdmin);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@StreetNumber", appUser.StreetNumber);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@StreetName", appUser.StreetName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@Zipcode", appUser.Zipcode);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@City", appUser.City);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@Country", appUser.Country);

            //if(appUser.FirstName != null)
            //{
            //    DbCommandHelper.AddParameterWithValue(sqlCommand, "@FirstName", appUser.FirstName);
            //}
            //if(appUser.LastName != null)
            //{
            //    DbCommandHelper.AddParameterWithValue(sqlCommand, "@LastName", appUser.LastName);
            //}
            //if (appUser.IsAdmin != null)
            //{
            //    DbCommandHelper.AddParameterWithValue(sqlCommand, "@IsAdmin", appUser.IsAdmin);
            //}

            //if (appUser.StreetNumber != null)
            //{
            //    DbCommandHelper.AddParameterWithValue(sqlCommand, "@StreetNumber", appUser.StreetNumber);
            //}

            //if (appUser.StreetName != null)
            //{
            //    DbCommandHelper.AddParameterWithValue(sqlCommand, "@StreetName", appUser.StreetName);
            //}

            //if (appUser.Zipcode != null)
            //{
            //    DbCommandHelper.AddParameterWithValue(sqlCommand, "@Zipcode", appUser.Zipcode);
            //}

            //if (appUser.City != null)
            //{
            //    DbCommandHelper.AddParameterWithValue(sqlCommand, "@City", appUser.City);
            //}

            //if (appUser.Country != null)
            //{
            //    DbCommandHelper.AddParameterWithValue(sqlCommand, "@Country", appUser.Country);
            //}
            //Uncomment pour Ludo
            //DbCommandHelper.AddParameterWithValue(sqlCommand, "@ReturnCode", "");

            sqlCommand.ExecuteNonQuery();
            
            _dbConnection.Close();
        }

        public void UpdateAppUser(AppUser appUser, int id)
        {
            IDbCommand sqlCommand = ConnectToDbAndInitializeCommand();
            DbCommandHelper.SetStoredProcedureName(sqlCommand, "SP_UPDATE_USER");

            DbCommandHelper.AddParameterWithValue(sqlCommand, "@ID", id);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@LoginNickname", appUser.LoginNickname);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@LoginPassword", appUser.LoginPassword);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@FirstName", appUser.FirstName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@LastName", appUser.LastName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@Email", appUser.Email);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@StreetNumber", appUser.StreetNumber);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@StreetName", appUser.StreetName);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@Zipcode", appUser.Zipcode);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@City", appUser.City);
            DbCommandHelper.AddParameterWithValue(sqlCommand, "@Country", appUser.Country);

            sqlCommand.ExecuteNonQuery();

            _dbConnection.Close();
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
