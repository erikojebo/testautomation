using System.ComponentModel.DataAnnotations;

namespace TestAutomation3.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string CustomerNumber { get; set; }
    }
}