using HospitalAPI.Interfaces;
using HospitalAPI.Models;
using HospitalAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace HospitalAPI.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IBaseCRUD<int, User> _userRepo;
        private readonly IBaseCRUD<int, Doctor> _doctorRepo;
        private readonly IBaseCRUD<int, Patient> _patientRepo;
        private readonly IBaseCRUD<int, Admin> _adminRepo;  

        private readonly IGenerateToken _generateToken;

        public ManageUserService(IBaseCRUD<int, User> userRepo, IBaseCRUD<int, Doctor> doctorRepo, IBaseCRUD<int, Patient> patientRepo, IBaseCRUD<int, Admin> adminRepo,IGenerateToken generateToken)
        {

            _userRepo = userRepo;
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
            _adminRepo = adminRepo;
            _generateToken = generateToken;
        }


        public async Task<UserDTO> Login(UserDTO user)
        {
            var userData = await _userRepo.Get(user.UserId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                var status=await _doctorRepo.Get(user.UserId);
                user = new UserDTO();
                user.UserId = userData.UserId;
                user.Role = userData.Role;
                user.Status = userData.Role == "Doctor" ? status.Status : null;
                user.Token = (userData.Role == "Doctor" && status.Status=="Approved")||(userData.Role=="Patient")||(userData.Role == "Admin") ? 
                    _generateToken.GenerateToken(user):null;
            }
            return user;
        }

    }
}
