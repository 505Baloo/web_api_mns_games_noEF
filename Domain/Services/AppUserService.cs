using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.Domain;
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

        public EditAppUserCmd GetEditAppUserCmd(int id)
        {
            AppUser appUser = _appUserRepository.GetAppUserModelById(id);

            return new EditAppUserCmd(appUser);
        }

        public void CreateAppUser(CreateAppUserCmd createAppUserCmd)
        {
            AppUser appUser = createAppUserCmd.ToAppUser();
            _appUserRepository.CreateAppUser(appUser);
        }

        public void UpdateAppUser(EditAppUserCmd editAppUserCmd, int id)
        {
            editAppUserCmd = GetEditAppUserCmd(id);
            AppUser appUser = editAppUserCmd.ToAppUser();

            _appUserRepository.UpdateAppUser(appUser, id);
        }
        
        public void DeleteAppUser(int id)
        {
            _appUserRepository.DeleteAppUser(id);
        }
    }
}
