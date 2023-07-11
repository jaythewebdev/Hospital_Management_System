using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public User? User { get; set; }
        [Required(ErrorMessage = "Name is required")]

        [MinLength(4, ErrorMessage = "Name must be atleast 4 characters long")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "DOB is required")]

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        public string? Specialization { get; set; }

        [Required(ErrorMessage = "Experience is required")]
        public int? Experience { get; set; }

        public string? Status { get; set; }


    }
}
