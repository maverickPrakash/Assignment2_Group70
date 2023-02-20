using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class User
    {
        [Key]
        public String? Username { get; set; }
        public String? Password { get; set; }
        [Required(ErrorMessage ="Enter Valid Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Enter a Valid User Type")]
        public string? UserType { get; set; }
    }
}
