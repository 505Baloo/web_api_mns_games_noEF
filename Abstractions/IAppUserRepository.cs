using WebAPI_MNS_Games.Domain;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Abstractions
{
    public interface IAppUserRepository
    {
        public IEnumerable<AppUser> GetAllUsers();

        public AppUser GetAppUserModelById(int id);

        public string CreateAppUser(AppUser appUser);

        public void DeleteAppUser(int id);

        public string UpdateAppUser(AppUser appUser, int id);
    }
}
