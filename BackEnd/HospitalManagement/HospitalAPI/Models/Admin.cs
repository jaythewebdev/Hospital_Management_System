using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public User? User { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(4, ErrorMessage = "Name must be atleast 4 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        //[Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid email address")]
        public string? EmailId { get; set; }

    }
}
