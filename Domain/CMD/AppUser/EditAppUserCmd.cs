using System.ComponentModel.DataAnnotations;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Domain
{
    public class EditAppUserCmd
    {
        [Required(ErrorMessage = "A login nickname is required.")]
        public string LoginNickname { get; set; }

        [Required(ErrorMessage = "A login password is required.")]
        public string LoginPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "An email address is required.")]
        public string Email { get; set; }

        public string StreetNumber { get; set; }

        public string StreetName { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public EditAppUserCmd() { }

        public EditAppUserCmd(AppUser appUser)
        {
            LoginNickname = appUser.LoginNickname;
            LoginPassword = appUser.LoginPassword;
            FirstName = appUser.FirstName;
            LastName = appUser.LastName;
            Email = appUser.Email;
            StreetNumber = appUser.StreetNumber;
            StreetName = appUser.StreetName;
            Zipcode = appUser.Zipcode;
            City = appUser.City;
            Country = appUser.Country;
        }

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
                Country = Country,
            };
        }
    }
}
