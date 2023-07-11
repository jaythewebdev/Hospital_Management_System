using HospitalAPI.Interfaces;
using HospitalAPI.Models;
using HospitalAPI.Models.DTO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace HospitalAPI.Services
{
    public class ManageDoctorService : IManageDoctor
    {
        private readonly IBaseCRUD<int, User> _userRepo;
        private readonly IBaseCRUD<int, Doctor> _doctorRepo;
        private readonly IBaseCRUD<int, Patient> _patientRepo;
        private readonly IGenerateToken _generateToken;

        public ManageDoctorService(IBaseCRUD<int, User> userRepo, IBaseCRUD<int, Doctor> doctorRepo, IBaseCRUD<int, Patient> patientRepo, IGenerateToken generateToken)
        {
            _userRepo = userRepo; 
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
            _generateToken = generateToken;
        }
        public async Task<UserDTO?> DoctorRegistration(DoctorRegisterDTO user)
        {
            UserDTO myUser = null;
            var hmac = new HMACSHA512();
            user.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordClear ?? "1234"));
            user.User.PasswordKey = hmac.Key;
            user.User.Role = "Doctor";
            user.Status = "UnApproved";
            var users = await _doctorRepo.GetAll();
            if (users != null)
            {
                var myDoctorUser = users.FirstOrDefault(u => u.EmailId == user.EmailId && u.PhoneNumber == user.PhoneNumber);
                if (myDoctorUser != null)
                {
                    return null;
                }
            }
            var userResult = await _userRepo.Add(user.User);
            var doctorResult = await _doctorRepo.Add(user);
            if (userResult != null && doctorResult != null)
            {
                myUser = new UserDTO();
                myUser.UserId = doctorResult.DoctorId;
                myUser.Role = userResult.Role;
                myUser.Status = doctorResult.Status;
                myUser.Token = (userResult.Role == "Doctor" && doctorResult.Status == "Approved") || (userResult.Role == "Patient") || (userResult.Role == "Admin") ?
                    _generateToken.GenerateToken(myUser) : null;
            }
            return myUser;
        }
        public async Task<UpdateDTO?> UpdateDoctor(UpdateDTO user)
        {
            var userData = await _doctorRepo.Get(user.DoctorID);
            if (userData != null)
            {
                userData.Status = user.Status;
                userData.PhoneNumber =user.PhoneNumber;
                userData.EmailId =user.EmailId;
                userData.Specialization =user.Specialization;
                userData.Experience =user.Experience;
                var result = await _doctorRepo.Update(userData);
                if (result != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<Doctor?> DoctorProfile(int key)
        {
            var users = await _doctorRepo.Get(key);
            if (users != null)
            {
                return users;
            }
            return null;
        }
    }
}
