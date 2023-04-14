using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Payment
    {
        [Key]
        public int paymentId { get; set; }
        [Required(ErrorMessage ="Address is compulsory")]
        public string? address { get; set; }
        [Required(ErrorMessage ="City is compulsory")]
        public string? city { get; set; }
        [Required(ErrorMessage ="Province is compulsory")]
        public string? Province { get; set; }

        [Required(ErrorMessage = "Postal Code is compulsory")]
        public string? Postal { get; set; }

        [Required(ErrorMessage = "Country  is compulsory")]
        public string? country { get; set; }
        [Required(ErrorMessage = "Card Holder name  is compulsory")]
        public string? cardHolder { get; set; }


        [Required(ErrorMessage = "Card number is compulsory")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Invalid Card Number")]
        public int cardnumber { get; set; }

        [Required(ErrorMessage = "Expiry is compulsory")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid Expiry")]
        public int Expiry { get; set; }

        [Required(ErrorMessage = "CCV is compulsory")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid CCV")]
        public int CCV { get; set; }

        public int BidId { get; set; }
    }
}
