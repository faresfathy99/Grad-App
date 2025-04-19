using System.ComponentModel.DataAnnotations;

namespace MizanGraduationProject.Data.DTOs
{
    public class VerifyEmailDTO
    {
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please enter verification token")]
        public string Token { get; set; } = null!;
    }
}
