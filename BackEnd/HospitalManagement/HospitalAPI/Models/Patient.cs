using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Patient
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public User? User { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(4, ErrorMessage = "Name must be atleast 4 characters long")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Date of birth is required")]
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MinLength(4, ErrorMessage = "Address must be atleast 4 characters long")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }

        public string? BloodType { get; set; }

    }
}
