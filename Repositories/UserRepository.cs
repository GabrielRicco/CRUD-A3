using MongoDB.Driver;
using Models;
using Repositories;

namespace CrudMongoApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _users.Find(user => user.Username == username).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User user)
        {
            user.Id = Guid.NewGuid();
            await _users.InsertOneAsync(user);
        }
    }
}
