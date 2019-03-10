using System.ComponentModel.DataAnnotations;

namespace Auth.Api.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Have to supply an user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Have to supply an e-mail address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Have to supply a password")]
        public string Password { get; set; }
    }
}