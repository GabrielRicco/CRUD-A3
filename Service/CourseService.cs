using Models;
using Repositories;

namespace CrudMongoApp.Services

{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Course course)
        {
            await _courseRepository.CreateAsync(course);
        }

        public async Task UpdateAsync(Guid id, Course course)
        {
            await _courseRepository.UpdateAsync(id, course);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }
    }
}
