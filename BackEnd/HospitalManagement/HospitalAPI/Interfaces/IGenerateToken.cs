using HospitalAPI.Models.DTO;

namespace HospitalAPI.Interfaces
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserDTO user);

    }
}
