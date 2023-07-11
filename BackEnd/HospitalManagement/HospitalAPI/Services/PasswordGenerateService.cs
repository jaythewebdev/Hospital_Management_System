using HospitalAPI.Interfaces;
using HospitalAPI.Models;

namespace HospitalAPI.Services
{
    public class PasswordGenerateService : IPasswordGenerate
    {
        public async Task<string?> GeneratePassword(Admin admin)
        {
            string passwordClear = String.Empty;
            passwordClear = admin.Name.Substring(0,2);
            passwordClear += "1234";
            return passwordClear;
        }
    }
}
