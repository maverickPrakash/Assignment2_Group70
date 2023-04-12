using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("SellerUsername")]
        public string? sellerUsername { get; set; }

        public virtual IdentityUser SellerUsername { get; set; }

        [ForeignKey("BuyerUsername")]
        public string? buyerUsername { get; set; }

        public virtual IdentityUser BuyerUsername { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set;}
        public Product Product { get; set;}
        public int star { get; set; }
        public string message  { get; set; }

        
        
    }
}
