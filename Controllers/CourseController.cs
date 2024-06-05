using Microsoft.AspNetCore.Mvc;
using CrudMongoApp.Services;
using Models;
using Microsoft.AspNetCore.Authorization;
using Dto;
using AutoMapper;

namespace CrudMongoApp.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(Guid id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> Create(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            course.Id = Guid.NewGuid();
            course.Students = null;

            await _courseService.CreateAsync(course);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Course course)
        {
            var existingCourse = await _courseService.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            course.Id = existingCourse.Id;
            await _courseService.UpdateAsync(id, course);

            return Ok("Estudante de id " + course.Id + " atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.DeleteAsync(id);

            return Ok("Estudante de id " + course.Id + " deletado com sucesso!");
        }
    }
}
