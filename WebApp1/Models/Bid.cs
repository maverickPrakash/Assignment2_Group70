using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }
        
        public int ProductId { get; set; }

        

        public Product Product { get; set; }
        public string Bidder { get; set; }

        public String Cost { get; set; }
        public string Bidstatus { get; set; }

    }
}
