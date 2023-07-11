using HospitalAPI.Models;
using HospitalAPI.Models.DTO;

namespace HospitalAPI.Interfaces
{
    public interface IManageDoctor
    {
        public Task<UserDTO?> DoctorRegistration(DoctorRegisterDTO user);
        public Task<Doctor?> DoctorProfile(int key);
        public Task<UpdateDTO?> UpdateDoctor(UpdateDTO user);
    }
}
