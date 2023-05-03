using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Abstractions
{
    public interface IUserService
    {
        public List<AppUserModel> GetAppUserModels();
        public AppUserModel GetAppUserModel(int id);

    }
}
