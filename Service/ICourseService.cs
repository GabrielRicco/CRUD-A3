using Models;

namespace CrudMongoApp.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(Guid id);
        Task CreateAsync(Course course);
        Task UpdateAsync(Guid id, Course course);
        Task DeleteAsync(Guid id);
    }
}
