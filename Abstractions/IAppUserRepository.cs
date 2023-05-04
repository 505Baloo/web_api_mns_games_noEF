using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Abstractions
{
    public interface IAppUserRepository
    {
        public IEnumerable<AppUser> GetAllUsers();
        public AppUser GetAppUserModelById(int id);
    }
}
