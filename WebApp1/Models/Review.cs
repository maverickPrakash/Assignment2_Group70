using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        
        public string SellerUsername { get; set; }
        public string BuyerUsername { get; set; }

        public int ProductId { get; set;}
        public int star { get; set; }
        public string message  { get; set; }

        public virtual IdentityUser AspNetUsers { get; set; }
    }
}
