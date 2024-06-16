using System.ComponentModel.DataAnnotations;

namespace CustomerModels.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a Email.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address Format")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter a Phone.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string? Phone { get; set; }
    }
}
