using HospitalAPI.Models;

namespace HospitalAPI.Interfaces
{
    public interface IPasswordGenerate
    {
        public Task<string?> GeneratePassword(Admin admin);
    }
}
