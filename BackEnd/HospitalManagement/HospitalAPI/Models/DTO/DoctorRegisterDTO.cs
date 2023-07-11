using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models.DTO
{
    public class DoctorRegisterDTO:Doctor
    {
        [Required]
        public string? PasswordClear { get; set; }
    }
}
