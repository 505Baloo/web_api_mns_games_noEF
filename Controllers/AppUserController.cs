using Microsoft.AspNetCore.Mvc;
using WebAPI_MNS_Games.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Nodes;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using WebAPI_MNS_Games.Domain.DTO;
using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.Domain.Services;
using WebAPI_MNS_Games.Domain;

namespace WebAPI_MNS_Games.Controllers
{
    [Route("api/AppUser")]
    [ApiController]
    public class AppUserController 
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<AppUserDTO> GetAllUsersDTO()
        {
            return _appUserService.GetAllUsersDTO();
        }

        [Route("Get/{id}")]
        [HttpGet]
        public AppUserDTO GetUserNicknameByIDDTO(int id)
        {
            return _appUserService.GetAllUsersNicknameDTO(id);
        }


        [Route("Create")]
        [HttpPost]
        public void CreateUser([FromBody] CreateAppUserCmd createAppUserCmd)
        {
            _appUserService.CreateAppUser(createAppUserCmd);
        }

        [Route("Update/{id}")]
        [HttpPost]
        public void UpdateUser([FromBody] int id)
        {
            _appUserService.UpdateAppUser(id);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public void DeleteUser(int id)
        {
            _appUserService.DeleteAppUser(id);
        }

        //public void InsertUser([FromBody]JsonObject bodyValues)
        //{
        //    try
        //    {
        //        using (DbConnection)
        //        {
        //            DbConnection.Open();
        //            SqlCommand sqlCmd = new SqlCommand("SP_INSERT_NEW_USER", DbConnection);
        //            sqlCmd.CommandType = CommandType.StoredProcedure;

        //            sqlCmd.Parameters.AddWithValue("@LoginNickname", SqlDbType.VarChar).Value = bodyValues["loginNickname"];
        //            sqlCmd.Parameters.AddWithValue("@LoginPassword", SqlDbType.VarChar).Value = bodyValues["loginPassword"];
        //            sqlCmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = bodyValues["email"];
        //            sqlCmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = bodyValues["firstName"];
        //            sqlCmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = bodyValues["lastName"];
        //            sqlCmd.Parameters.AddWithValue("@IsAdmin", SqlDbType.Bit).Value = bodyValues["isAdmin"];
        //            sqlCmd.Parameters.AddWithValue("@StreetNumber", SqlDbType.VarChar).Value = bodyValues["streetNumber"];
        //            sqlCmd.Parameters.AddWithValue("@StreetName", SqlDbType.VarChar).Value = bodyValues["streetName"];
        //            sqlCmd.Parameters.AddWithValue("@Zipcode", SqlDbType.VarChar).Value = bodyValues["zipcode"];
        //            sqlCmd.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = bodyValues["city"];
        //            sqlCmd.Parameters.AddWithValue("@Country", SqlDbType.VarChar).Value = bodyValues["country"];

        //            sqlCmd.ExecuteNonQuery();

        //            DbConnection.Close();
        //        }
        //    }
        //    catch(Exception e)
        //    {

        //    }
        //}
    }
}