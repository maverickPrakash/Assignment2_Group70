using Microsoft.Build.Framework;

namespace WebApp1.Models
{
    public class Registration : UserModel
    {
        [Required]
        public override string Username { get; set; }
        [Required]
        public override string Password { get; set; }
        [Required]
        public override string Email { get; set; }
        [Required]
        public override string Name { get; set; }
    }
}
