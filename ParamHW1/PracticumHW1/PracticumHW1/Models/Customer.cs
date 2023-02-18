using System.ComponentModel.DataAnnotations;

namespace PracticumHW1.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Invalid Name Length!")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address!")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage ="Invalid Phone Number!")]
        public string PhoneNumber { get; set; }
    }
}
