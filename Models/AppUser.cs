using System.ComponentModel.DataAnnotations;

namespace WebAPI_MNS_Games.Models
{
    public class AppUser
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string LoginNickname { get; set; }
        [Required]
        public string LoginPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}