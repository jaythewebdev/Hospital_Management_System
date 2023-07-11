using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models.DTO
{
    public class UpdateDTO
    {
        public int DoctorID { get; set; }

        //[Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }



        //[EmailAddress(ErrorMessage = "Invalid email address")]
        public string? EmailId { get; set; }


        public string? Specialization { get; set; }


        public int? Experience { get; set; }

        public string? Status { get; set; }
    }
}
