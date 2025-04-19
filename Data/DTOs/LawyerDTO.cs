using System.ComponentModel.DataAnnotations;

namespace MizanGraduationProject.Data.DTOs
{
    public class LawyerDTO
    {
        [Required(ErrorMessage = "Please Enter your ID")]
        public string Id { get; set; } = null!;
        public string Location {  get; set; } = null!;
        public string Specialization {  get; set; } = null!;
    }
}
