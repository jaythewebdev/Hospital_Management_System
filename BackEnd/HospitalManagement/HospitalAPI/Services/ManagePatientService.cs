using HospitalAPI.Interfaces;
using HospitalAPI.Models;
using HospitalAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace HospitalAPI.Services
{
    public class ManagePatientService : IManagePatient
    {
        private readonly IBaseCRUD<int, User> _userRepo;
        private readonly IBaseCRUD<int, Doctor> _doctorRepo;
        private readonly IBaseCRUD<int, Patient> _patientRepo;
        private readonly IGenerateToken _generateToken;

        public ManagePatientService(IBaseCRUD<int, User> userRepo, IBaseCRUD<int, Doctor> doctorRepo, IBaseCRUD<int, Patient> patientRepo, IGenerateToken generateToken)
        {
            _userRepo = userRepo;
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
            _generateToken = generateToken;
        }
        public async Task<UserDTO?> PatientRegistration(PatientRegisterDTO user)
        {
            UserDTO myUser = null;
            var hmac = new HMACSHA512();
            user.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordClear ?? "1234"));
            user.User.PasswordKey = hmac.Key;
            user.User.Role = "Patient";
            var users = await _patientRepo.GetAll();
            if (users != null)
            {
                var myPatientUser = users.FirstOrDefault(u => u.EmailId == user.EmailId && u.PhoneNumber == user.PhoneNumber);
                if (myPatientUser != null)
                {
                    return null;
                }
            }
            var userResult = await _userRepo.Add(user.User);
            var patientResult = await _patientRepo.Add(user);
            if (userResult != null && patientResult != null)
            {
                myUser = new UserDTO();
                myUser.UserId = patientResult.PatientId;
                myUser.Role = userResult.Role;
                myUser.Status = null;
                myUser.Token = _generateToken.GenerateToken(myUser);
            }
            return myUser;
        }

        public async Task<ICollection<Doctor>?> ViewAllApprovedDoctors()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.Where(u => u.Status == "Approved").ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<PatientUpdateDTO?> UpdatePatient(PatientUpdateDTO user)
        {
            var userData = await _patientRepo.Get(user.PatientID);
            if (userData != null)
            {
                userData.PhoneNumber = user.PhoneNumber;
                userData.EmailId = user.EmailId;
                var result = await _patientRepo.Update(userData);
                if (result != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<Patient?> PatientProfile(int key)
        {
            var users = await _patientRepo.Get(key);
            if (users != null)
            {
                return users;
            }
            return null;
        }


        public async Task<ICollection<Doctor>?> SearchByNameForPatient(string name)
        {
            var users = await _doctorRepo.GetAll();
            if (users != null)
            {
                var doctors = users.Where(i => i.Name.ToUpper().Contains(name.ToUpper()) && i.Status=="Approved").ToList();
                if (doctors.Count > 0)
                {
                    return doctors;
                }
            }
            return null;
        }


        public async Task<ICollection<Doctor>?> SearchDoctorBySpecializationForPatient(string specialization)
        {
            var users = await _doctorRepo.GetAll();
            if (users != null)
            {
                var doctors = users.Where(i => i.Specialization.ToUpper().Contains(specialization.ToUpper()) && i.Status == "Approved").ToList();
                if (doctors.Count > 0)
                {
                    return doctors;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SortByDescExpDoctorsForPatient()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.Where(u => u.Status == "Approved").OrderByDescending(u => u.Experience).ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SortByAscExpDoctorsForPatient()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.Where(u => u.Status == "Approved").OrderBy(u => u.Experience).ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SortByRecenetlyAddedDescDoctorsForPatient()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.Where(u => u.Status == "Approved").OrderByDescending(u => u.DoctorId).ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SortByRecenetlyAddedAscDoctorsForPatient()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.Where(u => u.Status == "Approved").OrderBy(u => u.DoctorId).ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

    }
}
