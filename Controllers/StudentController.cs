using Microsoft.AspNetCore.Mvc;
using CrudMongoApp.Services;
using Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Dto;

namespace CrudMongoApp.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(Guid id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<Student>> GetByCourseId(Guid courseId)
        {
            var student = await _studentService.GetByCourseIdAsync(courseId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Create(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.Id = Guid.NewGuid();
            student.CourseId = null;
            
            await _studentService.CreateAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, StudentDto student)
        {
            var existingStudent = await _studentService.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = student.Name;

            await _studentService.UpdateAsync(id, existingStudent);

            return Ok("Estudante de id " + student.Id + " atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentService.DeleteAsync(id);

            return Ok("Estudante de id " + student.Id + " deletado com sucesso!");
        }
    }
}
