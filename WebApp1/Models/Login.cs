using Microsoft.Build.Framework;

namespace WebApp1.Models
{
    public class Login : UserModel
    {

        [Required]
        public override string Username { get ; set ; }

        [Required]
        public override string Password { get; set; }
    }
}
