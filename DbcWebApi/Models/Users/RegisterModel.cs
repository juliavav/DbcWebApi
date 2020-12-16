using System.ComponentModel.DataAnnotations;

namespace DbcWebApi.Models.Users
{
    public class RegisterModel
    {
        [Required] public string FirstName { get; set; }


        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
    }
}