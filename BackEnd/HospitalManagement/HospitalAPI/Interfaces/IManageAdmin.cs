using HospitalAPI.Models;
using HospitalAPI.Models.DTO;

namespace HospitalAPI.Interfaces
{
    public interface IManageAdmin
    {
        public  Task<UserDTO?> AdminRegistration(Admin user);
        public Task<Admin?> GetAdminProfile(int key);
        public Task<ICollection<Doctor?>?> ViewAllDoctors();
        public Task<ICollection<Doctor?>?> ViewAllUnapprovedDoctors();
        public Task<ICollection<Patient?>?> ViewAllPatients();

        public Task<StatusDTO?> ChangeDoctorStatus(StatusDTO userApproval);
        public Task<Doctor?> DeleteDoctorById(int key);
        public Task<ICollection<Patient?>?> SearchPatientByName(string name);

        public Task<ICollection<Doctor?>?> SearchByName(string name);
        public Task<ICollection<Doctor>?> SearchByNameForUnApproved(string name);

        public Task<ICollection<Doctor?>?> SearchDoctorBySpecialization(string specialization);
        public Task<ICollection<Doctor>?> SearchDoctorBySpecializationForUnApproved(string specialization);

        public Task<ICollection<Doctor?>?> SortByDescExpDoctors();
        public Task<ICollection<Doctor?>?> SortByAscExpDoctors();
        public Task<ICollection<Doctor?>?> SortByRecenetlyAddedDescDoctors();
        public Task<ICollection<Doctor?>?> SortByRecenetlyAddedAscDoctors();

    }
}
