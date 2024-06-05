using Microsoft.AspNetCore.Mvc;
using CrudMongoApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace CrudMongoApp.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public SchoolController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult> AddStudentToCourse(Guid studentId, Guid courseId)
        {
            var student = await _studentService.GetByIdAsync(studentId);
            var course = await _courseService.GetByIdAsync(courseId);

            if (student != null && course != null)
            {
                student.CourseId = course.Id;
                if (!course.Students!.Contains(student))
                {
                    course.Students.Add(student);
                    await _studentService.UpdateAsync(studentId, student);
                    await _courseService.UpdateAsync(courseId, course);

                    return Ok("Estudante " + student.Name + " adicionado ao curso de " + course.Name);
                }
            }

            return BadRequest();
        }
    }
}