using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Product
    {
        
        
        public int ProductId { get; set; }
        [Required(ErrorMessage="Please enter a valid Product Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Cost")]
        public Double? Cost { get; set; }

        public string? Asset_condition { get; set; }
        public DateOnly StartBidDate { get; set; }
        public DateOnly ExpiryBidDate { get; set; }
        [Range(1,6, ErrorMessage="Select Correct")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Image { get; set; }
       
    }
}
