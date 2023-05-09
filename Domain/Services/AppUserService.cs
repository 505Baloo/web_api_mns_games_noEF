using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.Domain.CMD;
using WebAPI_MNS_Games.Domain.DTO;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Domain.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserService(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public void CreateAppUser(CreateAppUserCmd appUserCmd)
        {
            AppUser appUser = appUserCmd.ToAppUser();
            _appUserRepository.CreateAppUser(appUser);
        }

        public IEnumerable<AppUserDTO> GetAllUsersDTO()
        {
            var appUsers = _appUserRepository.GetAllUsers();

            return appUsers.Select(appUser => new AppUserDTO(appUser)).ToList();
        }

        public AppUserDTO GetAllUsersNicknameDTO(int id)
        {
            AppUser appUser = _appUserRepository.GetAppUserModelById(id);

            return new AppUserDTO(appUser);
        }

        public void CreateAppUser(CreateAppUserCmd appUserCmd)
        {
            AppUser appUser = appUserCmd.ToAppUser();
            _appUserRepository.CreateAppUser(appUser);
        }
        
        public void DeleteAppUser(int id)
        {
            _appUserRepository.DeleteAppUser(id);
        }
    }
}
