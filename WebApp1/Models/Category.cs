using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public String  CategoryName { get; set; }
    }
}
