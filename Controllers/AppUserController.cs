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
        public void CreateUser(CreateAppUserCmd createAppUserCmd)
        {
            _appUserService.CreateAppUser(createAppUserCmd);
        }

        [Route("Update/{id}")]
        [HttpPut]
        public void UpdateUser(EditAppUserCmd editAppUserCmd, int id)
        {
            _appUserService.UpdateAppUser(editAppUserCmd, id);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public void DeleteUser(int id)
        {
            _appUserService.DeleteAppUser(id);
        }
    }
}