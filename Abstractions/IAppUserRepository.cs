using WebAPI_MNS_Games.Domain;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Abstractions
{
    public interface IAppUserRepository
    {
        public IEnumerable<AppUser> GetAllUsers();

        public AppUser GetAppUserModelById(int id);

        public void CreateAppUser(AppUser appUser);

        public void DeleteAppUser(int id);

        public void UpdateAppUser(AppUser appUser, int id);
    }
}
