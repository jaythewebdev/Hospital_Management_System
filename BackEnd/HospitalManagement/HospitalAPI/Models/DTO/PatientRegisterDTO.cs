using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models.DTO
{
    public class PatientRegisterDTO:Patient
    {
        [Required]
        public string? PasswordClear { get; set; }
    }
}
