using BlogProject.DTOs;
using BlogProject.Models;
using BlogProject.Repository;
using Microsoft.Identity.Client;

namespace BlogProject.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync (int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);

        }

        public async Task<User> GetUserByEmailAsync (string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task RegisterUserAsync(RegisterDTO registerDTO)
        {
            var user = new User
            {
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                Password = registerDTO.Password,
                Age = registerDTO.Age,
                Gender = registerDTO.Gender,
                IsBlogWriter = registerDTO.IsBlogWriter

            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

    


}
}
