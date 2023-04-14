using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
       
        public string? sellerUsername { get; set; }

        public string? buyerUsername { get; set; }
        public int ProductId { get; set;}
        public int star { get; set; }
        public string? message  { get; set; }

        public int BidId { get; set; }

        
        
    }
}
