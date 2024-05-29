using Models;

namespace Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByUsernameAsync(string username);
    Task CreateAsync(User user);
}