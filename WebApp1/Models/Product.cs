using Microsoft.AspNetCore.Identity;
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
        [Required(ErrorMessage = "Upload Image")]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Cost")]
        public String? Cost { get; set; }
        [Required(ErrorMessage = "Select the Assest_Condition ")]
        public string? Asset_condition { get; set; }
        [Required(ErrorMessage = "Select Start Bid Date")]
        public DateTime StartBidDate { get; set; }
        [Required(ErrorMessage = "Select Start End Date")]
        public DateTime ExpiryBidDate { get; set; }
        [Range(1,6, ErrorMessage="Select Correct Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("AspNetUsers")]
        public string? Username { get; set; }

        internal void Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public virtual IdentityUser AspNetUsers { get; set; }


        public string Slug => Name==null? "" : Name.Replace(" ", "-");
       
    }
}
