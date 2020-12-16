using System.ComponentModel.DataAnnotations;

namespace DbcWebApi.Models.Users
{
    public class AuthenticateModel
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}