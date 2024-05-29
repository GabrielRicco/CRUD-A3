using Models;
using Repositories;

namespace CrudMongoApp.Services

{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task CreateAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }
    }
}
