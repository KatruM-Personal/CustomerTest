using System.ComponentModel.DataAnnotations;

namespace CustomerModels.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a Email.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter a Phone.")]
        public string? Phone { get; set; }
    }
}
