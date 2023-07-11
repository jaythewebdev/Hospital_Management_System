using HospitalAPI.Interfaces;
using HospitalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Services
{
    public class AdminRepo : IBaseCRUD<int, Admin>
    {
        private readonly HospitalContext _context;
        private readonly ILogger<UserRepo> _logger;

        public AdminRepo(HospitalContext hospitalContext, ILogger<UserRepo> logger)
        {
            _context = hospitalContext;
            _logger = logger;
        }


        public async Task<Admin?> Add(Admin item)
        {
            try
            {
                _context.Admins.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public Task<Admin?> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<Admin?> Get(int key)
        {
            try
            {
                var user = await _context.Admins.FirstOrDefaultAsync(u => u.AdminId == key);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Admin>?> GetAll()
        {
            try
            {
                var users = await _context.Admins.ToListAsync();
                if (users.Count > 0)
                    return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public Task<Admin?> Update(Admin item)
        {
            throw new NotImplementedException();
        }
    }
}
