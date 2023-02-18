using System.ComponentModel.DataAnnotations;

namespace PracticumHW2.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Invalid Name Length!")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address!")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number!")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
