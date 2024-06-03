using MongoDB.Driver;
using Models;
using Repositories;

namespace CrudMongoApp.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IMongoCollection<Course> _courses;

        public CourseRepository(IMongoDatabase database)
        {
            _courses = database.GetCollection<Course>("Courses");
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courses.Find(course => true).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            return await _courses.Find(course => course.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Course course)
        {
            course.Id = Guid.NewGuid();
            await _courses.InsertOneAsync(course);
        }

        public async Task UpdateAsync(Guid id, Course course)
        {
            await _courses.ReplaceOneAsync(s => s.Id == id, course);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _courses.DeleteOneAsync(s => s.Id == id);
        }
    }
}
