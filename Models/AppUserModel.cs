using System.ComponentModel.DataAnnotations;

namespace WebAPI_MNS_Games.Models
{
    public class AppUserModel
    {
        [Key]
        public int ID { get; set; }
        public string LoginNickname { get; set; }
        public string LoginPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}