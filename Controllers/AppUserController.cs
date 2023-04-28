using Microsoft.AspNetCore.Mvc;
using WebAPI_MNS_Games.Models;
using System.Data.SqlClient;

namespace WebAPI_MNS_Games.Controllers
{
    [Route("api/AppUserController")]
    [ApiController]
    public class AppUserController
    {
        // properties
        const string DataSource = @"Data Source=JORDAN\SQLEXPRESS;Initial Catalog=MNS_Games_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection DbConnection = new(DataSource);

        private readonly List<AppUserModel> Users = new();

        [Route("GetAppUsers")]
        [HttpGet]
        public List<AppUserModel> Get()
        {
            // SQL Query preparation
            string query = "SELECT * FROM AppUser";
            SqlCommand command = new(query, DbConnection);


            // Starting connection with DB and executing
            DbConnection.Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            while (sqlReader.Read()) // returns true while there is something to read
            {
                // use the row from the database and create new model
                Users.Add(new AppUserModel
                {
                    ID = int.Parse(sqlReader["ID"].ToString()),
                    LoginNickname = sqlReader["LoginNickname"].ToString(),
                    LoginPassword = sqlReader["LoginPassword"].ToString(),
                    Email = sqlReader["Email"].ToString(),
                    FirstName = sqlReader["FirstName"].ToString(),
                    LastName = sqlReader["LastName"].ToString(),
                    IsAdmin = bool.Parse(sqlReader["IsAdmin"].ToString()),
                    StreetNumber = sqlReader["StreetNumber"].ToString(),
                    StreetName = sqlReader["StreetName"].ToString(),
                    Zipcode = sqlReader["Zipcode"].ToString(),
                    City = sqlReader["City"].ToString(),
                    Country = sqlReader["Country"].ToString(),
                });
            }
            DbConnection.Close();

            return Users;
        }
    }
}