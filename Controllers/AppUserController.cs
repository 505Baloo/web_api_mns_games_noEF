using Microsoft.AspNetCore.Mvc;
using WebAPI_MNS_Games.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Nodes;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace WebAPI_MNS_Games.Controllers
{
    [Route("api/AppUser")]
    [ApiController]
    public class AppUserController 
    {
        // properties
        const string DataSource = @"Data Source=JORDAN\SQLEXPRESS;Initial Catalog=MNS_Games_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection DbConnection = new(DataSource);

        private readonly List<AppUserModel> Users = new();

        [Route("GetUserByID/{id}")]
        [HttpGet]
        public AppUserModel GetUserByID(int id)
        {
            AppUserModel user = new AppUserModel();
            using (DbConnection)
            {
                DbConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GET_USER_BY_ID", DbConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while(sqlReader.Read())
                {
                    user = new AppUserModel
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
                    };
                }

                sqlCmd.ExecuteNonQuery();
                DbConnection.Close();
            }
            return user;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public List<AppUserModel> GetAllUsers()
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

        [Route("InsertUser")]
        [HttpPost]
        public void InsertUser([FromBody]JsonObject bodyValues)
        {
            AppUserModel user = new AppUserModel()
            {
                LoginNickname = bodyValues["LoginNickname"].ToString(),
                LoginPassword = bodyValues["LoginPassword"].ToString(),
                Email = bodyValues["Email"].ToString(),
                FirstName = bodyValues["FirstName"].ToString(),
                LastName = bodyValues["LastName"].ToString(),
                IsAdmin = bool.Parse(bodyValues["IsAdmin"].ToString()),
                StreetNumber = bodyValues["StreetNumber"].ToString(),
                StreetName = bodyValues["StreetName"].ToString(),
                Zipcode = bodyValues["Zipcode"].ToString(),
                City = bodyValues["City"].ToString(),
                Country = bodyValues["Country"].ToString(),
            };

            using (DbConnection)
            {
                DbConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_INSERT_NEW_USER", DbConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@LoginNickname", SqlDbType.NVarChar).Value = bodyValues["LoginNickname"];
                sqlCmd.Parameters.AddWithValue("@LoginPassword", SqlDbType.NVarChar).Value = bodyValues["LoginPassword"];
                sqlCmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = bodyValues["Email"];
                sqlCmd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = bodyValues["FirstName"];
                sqlCmd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = bodyValues["LastName"];
                sqlCmd.Parameters.AddWithValue("@StreetNumber", SqlDbType.NVarChar).Value = bodyValues["StreetNumber"];
                sqlCmd.Parameters.AddWithValue("@StreetName", SqlDbType.NVarChar).Value = bodyValues["StreetName"];
                sqlCmd.Parameters.AddWithValue("@Zipcode", SqlDbType.NVarChar).Value = bodyValues["Zipcode"];
                sqlCmd.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = bodyValues["City"];
                sqlCmd.Parameters.AddWithValue("@Country", SqlDbType.NVarChar).Value = bodyValues["Country"];
                sqlCmd.Parameters.AddWithValue("@IsAdmin", SqlDbType.Bit).Value = bodyValues["IsAdmin"];

                sqlCmd.ExecuteNonQuery();
                DbConnection.Close();
            }
        }
    }
}