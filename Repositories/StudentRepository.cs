using MongoDB.Driver;
using Models;
using Repositories;
using Microsoft.Extensions.Options;
using Config;

namespace CrudMongoApp.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoCollection<Student> _students;

        public StudentRepository(IMongoDatabase database)
        {
            _students = database.GetCollection<Student>("Students");
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _students.Find(student => true).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _students.Find(student => student.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Student student)
        {
            student.Id = Guid.NewGuid();
            await _students.InsertOneAsync(student);
        }

        public async Task UpdateAsync(Guid id, Student student)
        {
            await _students.ReplaceOneAsync(s => s.Id == id, student);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _students.DeleteOneAsync(s => s.Id == id);
        }
    }
}
