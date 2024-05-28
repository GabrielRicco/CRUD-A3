using Models;
using Repositories;

namespace CrudMongoApp.Services

{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }

        public async Task UpdateAsync(Guid id, Student student)
        {
            await _studentRepository.UpdateAsync(id, student);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}
