using BlogProject.Models;

namespace BlogProject.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);

        Task AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
