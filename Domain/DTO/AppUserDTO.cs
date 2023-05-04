using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Domain.DTO
{
    public class AppUserDTO
    {
        public string LoginNickname { get; set; }

        public AppUserDTO() { }

        public AppUserDTO(AppUser appUser)
        {
            LoginNickname = appUser.LoginNickname;
        }
    }
}
