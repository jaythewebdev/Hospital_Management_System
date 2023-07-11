using HospitalAPI.Models.DTO;
using HospitalAPI.Models;

namespace HospitalAPI.Interfaces
{
    public interface IManagePatient
    {
        public Task<UserDTO?> PatientRegistration(PatientRegisterDTO user);
        public Task<Patient?> PatientProfile(int key);
        public Task<PatientUpdateDTO?> UpdatePatient(PatientUpdateDTO user);
        public Task<ICollection<Doctor>?> ViewAllApprovedDoctors();

        
        public Task<ICollection<Doctor?>?> SearchByNameForPatient(string name);
        public Task<ICollection<Doctor?>?> SearchDoctorBySpecializationForPatient(string specialization);
        public Task<ICollection<Doctor?>?> SortByDescExpDoctorsForPatient();
        public Task<ICollection<Doctor?>?> SortByAscExpDoctorsForPatient();
        public Task<ICollection<Doctor?>?> SortByRecenetlyAddedDescDoctorsForPatient();
        public Task<ICollection<Doctor?>?> SortByRecenetlyAddedAscDoctorsForPatient();
    }
}
