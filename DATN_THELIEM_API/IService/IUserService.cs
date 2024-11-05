using DATN_THELIEM_API.Models;

namespace DATN_THELIEM_API.IService
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUserById(int id);
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        //Task DeleteUser(int id);
    }
}
