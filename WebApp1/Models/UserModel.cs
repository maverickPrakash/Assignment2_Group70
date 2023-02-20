
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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

    public class HomeViewModel : UserModel
    {
        public string login { get; set; }     
    }
}
