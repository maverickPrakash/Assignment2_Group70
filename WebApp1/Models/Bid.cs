using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }
        public int ProductId { get; set; }
        
        public string Bidder { get; set; }

        public int Cost { get; set; }
        public string Bidstatus { get; set; }
    }
}
