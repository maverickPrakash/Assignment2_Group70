using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage="Please enter a valid Product Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Cost")]
        public String? Cost { get; set; }
        [Required(ErrorMessage = "Select the Assest_Condition ")]
        public string? Asset_condition { get; set; }
        public DateTime StartBidDate { get; set; }
        public DateTime ExpiryBidDate { get; set; }
        [Range(1,6, ErrorMessage="Select Correct Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public String? Username { get; set; }
        public User? User { get; set; }
        

        public string Slug => Name==null? "" : Name.Replace(" ", "-");
       
    }
}
