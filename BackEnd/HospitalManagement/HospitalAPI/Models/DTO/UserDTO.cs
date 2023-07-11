namespace HospitalAPI.Models.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        public string? Status { get; set;}
    }
}
