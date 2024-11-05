using DATN_THELIEM_API.DATA;
using DATN_THELIEM_API.IService;
using DATN_THELIEM_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DATN_THELIEM_API.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDBContext _appDBContext;

        public UserService(HttpClient httpClient, AppDBContext appDBContext)
        {
            _httpClient = httpClient;
            _appDBContext = appDBContext;
        }
        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _appDBContext.USERS.ToListAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _appDBContext.USERS.FindAsync(id);
        }

        public async Task AddUser(Users user)
        {
            await _appDBContext.USERS.AddAsync(user);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task UpdateUser(Users user)
        {
            _appDBContext.USERS.Update(user);
            await _appDBContext.SaveChangesAsync();
        }

        //public async Task DeleteUser(int id)
        //{
        //    var user = await _appDBContext.USERS.FindAsync(id);
        //    if (user != null)
        //    {
        //        user.Status = 0; // Set status to 0 to perform a soft delete
        //        _appDBContext.USERS.Update(user);
        //        await _appDBContext.SaveChangesAsync();
        //    }
        //}
    }
}
