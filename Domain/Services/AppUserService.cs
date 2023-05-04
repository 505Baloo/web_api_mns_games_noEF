using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.Domain.DTO;

namespace WebAPI_MNS_Games.Domain.Services
{
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository _appUserRepository;

        public AppUserService(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public IEnumerable<AppUserDTO> GetAllUsersDTO()
        {
            var appUsers = _appUserRepository.GetAllUsers();

            return appUsers.Select(appUser => new AppUserDTO(appUser)).ToList();
        }
    }
}
