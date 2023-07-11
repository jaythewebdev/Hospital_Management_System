using HospitalAPI.Interfaces;
using HospitalAPI.Models.DTO;
using HospitalAPI.Models;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace HospitalAPI.Services
{
    public class ManageAdminService:IManageAdmin
    {
        private readonly IBaseCRUD<int, User> _userRepo;
        private readonly IBaseCRUD<int, Doctor> _doctorRepo;
        private readonly IBaseCRUD<int, Admin> _adminRepo;
        private readonly IBaseCRUD<int, Patient> _patientRepo;
        private readonly IGenerateToken _generateToken;
        private readonly IPasswordGenerate _passwordGenerate;

        public ManageAdminService(IBaseCRUD<int, User> userRepo, IBaseCRUD<int, Doctor> doctorRepo,IBaseCRUD<int, Admin> adminRepo, IBaseCRUD<int, Patient> patientRepo, IGenerateToken generateToken,IPasswordGenerate passwordGenerate)
        {
            _userRepo = userRepo;
            _doctorRepo = doctorRepo;
            _adminRepo = adminRepo;
            _patientRepo=patientRepo;
            _generateToken = generateToken;
            _passwordGenerate=passwordGenerate;
        }
        public async Task<UserDTO?> AdminRegistration(Admin user)
        {
            UserDTO myUser = null;
            var hmac = new HMACSHA512();
            string? generatedPassword = await _passwordGenerate.GeneratePassword(user);
            user.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(generatedPassword));

            //user.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordClear ?? "1234"));
            user.User.PasswordKey = hmac.Key;
            user.User.Role = "Admin";

            var users = await _adminRepo.GetAll();
            if (users != null)
            {
                var myAdminUser = users.FirstOrDefault(u => u.EmailId == user.EmailId && u.PhoneNumber == user.PhoneNumber);
                if (myAdminUser != null)
                {
                    return null;
                }
            }
            var userResult = await _userRepo.Add(user.User);
            var adminResult = await _adminRepo.Add(user);
            if (userResult != null && adminResult != null)
            {
                myUser = new UserDTO();
                myUser.UserId = adminResult.AdminId;
                myUser.Role = userResult.Role;
                myUser.Status = null;
                myUser.Token = _generateToken.GenerateToken(myUser);
            }
            return myUser;
        }

        public async Task<StatusDTO?> ChangeDoctorStatus(StatusDTO userApproval)
        {
            var userData = await _doctorRepo.Get(userApproval.Id);
            if (userData != null)
            {
                userData.Status = userApproval.Status;
                var result = await _doctorRepo.Update(userData);
                if (result != null)
                {
                    return userApproval;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> ViewAllUnapprovedDoctors()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.Where(u => u.Status == "UnApproved").OrderByDescending(u => u.DoctorId).ToList();
                if(myUsers.Count>0) {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> ViewAllDoctors()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                return userData;
            }
            return null;
        }

        public async Task<ICollection<Patient?>?> SearchPatientByName(string name)
        {
            var users = await _patientRepo.GetAll();
            if (users != null)
            {
                var doctors = users.Where(i => i.Name.ToUpper().Contains(name.ToUpper())).ToList();
                if (doctors.Count > 0)
                {
                    return doctors;
                }
            }
            return null;
        }


        public async Task<ICollection<Doctor>?> SearchByName(string name)
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

        public async Task<ICollection<Doctor>?> SearchByNameForUnApproved(string name)
        {
            var users = await _doctorRepo.GetAll();
            if (users != null)
            {
                var doctors = users.Where(i => i.Name.ToUpper().Contains(name.ToUpper()) && i.Status == "UnApproved").ToList();
                if (doctors.Count > 0)
                {
                    return doctors;
                }
            }
            return null;
        }

        public async Task<Doctor?> DeleteDoctorById(int key)
        {
            var userData = await _doctorRepo.Delete(key);
            if (userData != null)
            {
                return userData;
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SearchDoctorBySpecialization(string specialization)
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

        public async Task<ICollection<Doctor>?> SearchDoctorBySpecializationForUnApproved(string specialization)
        {
            var users = await _doctorRepo.GetAll();
            if (users != null)
            {
                var doctors = users.Where(i => i.Specialization.ToUpper().Contains(specialization.ToUpper()) && i.Status == "UnApproved").ToList();
                if (doctors.Count > 0)
                {
                    return doctors;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SortByDescExpDoctors()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.OrderByDescending(u => u.Experience).ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SortByAscExpDoctors()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.OrderBy(u => u.Experience).ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SortByRecenetlyAddedDescDoctors()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.OrderByDescending(u => u.DoctorId).ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> SortByRecenetlyAddedAscDoctors()
        {
            var userData = await _doctorRepo.GetAll();
            if (userData != null)
            {
                var myUsers = userData.OrderBy(u => u.DoctorId).ToList();
                if (myUsers.Count > 0)
                {
                    return myUsers;
                }
            }
            return null;
        }

        public async Task<Admin?> GetAdminProfile(int key)
        {
            var userData = await _adminRepo.Get(key);
            if (userData != null)
            {
                return userData;
            }
            return null;
        }

        public async Task<ICollection<Patient?>?> ViewAllPatients()
        {
            var userData = await _patientRepo.GetAll();
            if (userData != null)
            {
                return userData;
            }
            return null;
        }
    }
}
