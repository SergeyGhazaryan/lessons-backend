using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.StudentModel;
using Lessons_api.Domain.UserModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lessons_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var student = await _studentService.GetStudentById(id);

            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] CreateUserDTO model)
        {
            var addedStudent = await _studentService.AddStudent(model);

            return Ok(addedStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] UpdateStudentDTO model)
        {
            var updatedStudent = await _studentService.UpdateStudent(id, model);

            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentById([FromRoute] int id)
        {
            await _studentService.DeleteStudentById(id);

            return Ok();
        }
    }
}
