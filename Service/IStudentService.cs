

using Models;

namespace CrudMongoApp.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(Guid id);
        Task CreateAsync(Student student);
        Task UpdateAsync(Guid id, Student student);
        Task DeleteAsync(Guid id);
    }
}
