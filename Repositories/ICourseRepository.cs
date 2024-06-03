using Models;

namespace Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllCoursesAsync();
    Task<Course> GetByIdAsync(Guid id);
    Task CreateAsync(Course course);
    Task UpdateAsync(Guid id, Course course);
    Task DeleteAsync(Guid id);
}