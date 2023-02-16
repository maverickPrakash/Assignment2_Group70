
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class UserModel
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        [Key]
        public int Id { get; set; }

    }
}
