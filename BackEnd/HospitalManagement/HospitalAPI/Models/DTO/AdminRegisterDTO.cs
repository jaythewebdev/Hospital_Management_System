using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models.DTO
{
    public class AdminRegisterDTO : Admin
    {
        [Required]
        public string? PasswordClear { get; set; }
    }
}
