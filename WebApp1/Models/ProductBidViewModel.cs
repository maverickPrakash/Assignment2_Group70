namespace WebApp1.Models
{
    public class ProductBidViewModel
    {
        public int BidId { get; set; }
        public int ProductId { get; set; }
        public string Bidder { get; set; }
        public string Cost { get; set; }
        public string Bidstatus { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Asset_condition { get; set; }
        public DateTime StartBidDate { get; set; }
        public DateTime ExpiryBidDate { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public string Slug { get; set; }
    }
}
