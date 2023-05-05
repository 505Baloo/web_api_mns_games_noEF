using System.ComponentModel.DataAnnotations;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Domain.CMD
{
    public class CreateAppUserCmd
    {
        [Required(ErrorMessage = "Please choose a login nickname.")]
        public string LoginNickname { get; set; }
        [Required(ErrorMessage = "Please set your login password.")]
        public string LoginPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public CreateAppUserCmd() { }

        public AppUser ToAppUser()
        {
            return new AppUser
            {
                LoginNickname = LoginNickname,
                LoginPassword = LoginPassword,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                StreetNumber = StreetNumber,
                StreetName = StreetName,
                Zipcode = Zipcode,
                City = City,
                Country = Country
            };
        }
    }
}
