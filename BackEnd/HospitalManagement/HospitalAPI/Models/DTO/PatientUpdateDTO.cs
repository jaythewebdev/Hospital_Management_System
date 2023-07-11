namespace HospitalAPI.Models.DTO
{
    public class PatientUpdateDTO
    {
        public int PatientID { get; set; }

        //[Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }


        //[EmailAddress(ErrorMessage = "Invalid email address")]
        public string? EmailId { get; set; }
    }
}
