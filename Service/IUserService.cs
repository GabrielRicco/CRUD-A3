using Models;

namespace CrudMongoApp.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByUsernameAsync(string username);
        Task CreateAsync(User user);
    }
}