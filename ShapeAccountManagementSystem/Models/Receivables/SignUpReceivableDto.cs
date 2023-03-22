using System.ComponentModel.DataAnnotations;

namespace ShapeAccountManagementSystem.Models.Receivables
{
    public class SignUpReceivableDto
    {
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(12, ErrorMessage = "First Name should not exceed more than 12 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(16, ErrorMessage ="Last Name should not exceed more than 16 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(12, ErrorMessage = "Password should be atleast 12 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
