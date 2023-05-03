using Microsoft.AspNetCore.Mvc;
using WebAPI_MNS_Games.Models;
using System.Data.SqlClient;
using System.Data;
using WebAPI_MNS_Games.Abstractions;

namespace WebAPI_MNS_Games.Controllers
{
    [Route("api/AppUserController")]
    [ApiController]
    public class AppUserController
    {
        // properties
        const string DataSource = @"Data Source=DESKTOP-64ED8DR\SQLEXPRESS;Initial Catalog=MNS_Games_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //private readonly SqlConnection DbConnection = new(DataSource);
        private readonly IUserService _userService;


        public AppUserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetAppUsers")]
        [HttpGet]
        public List<AppUserModel> Get()
        {
            return _userService.GetAppUserModels();
        }

        [Route("GetAppUser/id")]
        [HttpGet]
        public AppUserModel GetAppUserModelByID(int id)
        {
            return _userService.GetAppUserModel(id);
        }
    }
}