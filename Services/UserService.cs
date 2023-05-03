using System.Data;
using System.Data.Common;
using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Services
{
    public class UserService : IUserService
    {
        private readonly IDbConnection _dbConnection;

        public UserService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<AppUserModel> GetAppUserModels()
        {
            List<AppUserModel> appUsers = new List<AppUserModel>();

            // SQL Query preparation
            string query = "SELECT * FROM AppUser";
            IDbCommand commandDb = ConnectAndInitializeCommand();
            commandDb.CommandText = query;

            IDataReader sqlReader = commandDb.ExecuteReader();
            while (sqlReader.Read()) // returns true while there is something to read
            {
                // use the row from the database and create new model
                appUsers.Add(ConvertReaderToAppUserModel(sqlReader));
            }
            _dbConnection.Close();

            return appUsers;
        }

        public AppUserModel GetAppUserModel(int id)
        {
            AppUserModel appUserModel = null;
            string query = $"SELECT * FROM AppUser Where ID={id}";
            IDbCommand commandDb = ConnectAndInitializeCommand();
            commandDb.CommandText = query;

            IDataReader sqlReader = commandDb.ExecuteReader();
            while (sqlReader.Read()) // returns true while there is something to read
            {
                appUserModel = ConvertReaderToAppUserModel(sqlReader);
            }
            _dbConnection.Close();

            return appUserModel;

        }
        private IDbCommand ConnectAndInitializeCommand()
        {
            _dbConnection.Open();
            return _dbConnection.CreateCommand();
        }

        private static AppUserModel ConvertReaderToAppUserModel(IDataReader dataReader)
        {
            return new AppUserModel
            {
                ID = int.Parse(dataReader["ID"].ToString()),
                LoginNickname = dataReader["LoginNickname"].ToString(),
                LoginPassword = dataReader["LoginPassword"].ToString(),
                Email = dataReader["Email"].ToString(),
                FirstName = dataReader["FirstName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                IsAdmin = bool.Parse(dataReader["IsAdmin"].ToString()),
                StreetNumber = dataReader["StreetNumber"].ToString(),
                StreetName = dataReader["StreetName"].ToString(),
                Zipcode = dataReader["Zipcode"].ToString(),
                City = dataReader["City"].ToString(),
                Country = dataReader["Country"].ToString(),
            };
        }
        // Creer un nouveau Service, Methode dans le services
        // Créer une interface I****Service + implémenter Service
        //Créer une méthode dans le controller qui renvoi l'element voulu
        //Ajouter un nouveau service dans programm.cs ex-dessous :
         //builder.Services.AddTransient<IUserService, UserService>();
        
    }
}
