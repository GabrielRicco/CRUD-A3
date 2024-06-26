using Microsoft.AspNetCore.Mvc;
using CrudMongoApp.Services;
using Microsoft.AspNetCore.Authorization;
using Models;

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
                // Verifique se course.Students é nulo e inicialize se necessário
                if (course.Students == null)
                {
                    course.Students = [];
                }
                if (!course.Students.Contains(student))
                {
                    course.Students.Add(student);
                    await _studentService.UpdateAsync(studentId, student);
                    await _courseService.UpdateAsync(courseId, course);

                    return Ok("Estudante " + student.Name + " adicionado ao curso de " + course.Name);
                }

                return BadRequest("Estudante já está matriculado no curso");
            }

            return BadRequest("Estudante ou curso não encontrado");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStudentToCourse(Guid studentId, Guid courseId)
        {
            var student = await _studentService.GetByIdAsync(studentId);
            var course = await _courseService.GetByIdAsync(courseId);

            if (student != null && course != null)
            {
                student.CourseId = null;
                if (course.Students!.Contains(student))
                {
                    course.Students.Remove(student);
                    await _studentService.UpdateAsync(studentId, student);
                    await _courseService.UpdateAsync(courseId, course);

                    return Ok("Estudante " + student.Name + " removido do curso de " + course.Name);
                }

                return BadRequest("Estudante não está matriculado no curso");
            }

            return BadRequest("Estudante ou curso não encontrado");
        }
    }
}