using BlogProject.DTOs;
using BlogProject.Models;

namespace BlogProject.Service
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int UserId);
        Task<User> GetUserByEmailAsync(string email);

        Task RegisterUserAsync(RegisterDTO registerDTO);
        Task<IEnumerable<User>> GetAllUserAsync();
    }
}
