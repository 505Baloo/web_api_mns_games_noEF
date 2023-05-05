using System.Data;
using System.Data.Common;
using WebAPI_MNS_Games.Domain.CMD;
using WebAPI_MNS_Games.Domain.DTO;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Abstractions
{
    public interface IAppUserService
    {
        public IEnumerable<AppUserDTO> GetAllUsersDTO();

        public AppUserDTO GetAllUsersNicknameDTO(int id);

        public void CreateAppUser(CreateAppUserCmd appUserCmd);
    }
}
