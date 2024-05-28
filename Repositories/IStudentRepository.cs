using Models;

namespace Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student> GetByIdAsync(Guid id);
    Task CreateAsync(Student student);
    Task UpdateAsync(Guid id, Student student);
    Task DeleteAsync(Guid id);
}