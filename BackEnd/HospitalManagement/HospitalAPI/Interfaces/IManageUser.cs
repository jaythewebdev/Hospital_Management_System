using HospitalAPI.Models;
using HospitalAPI.Models.DTO;

namespace HospitalAPI.Interfaces
{
    public interface IManageUser
    {
        public Task<UserDTO> Login(UserDTO user);

    }
}
