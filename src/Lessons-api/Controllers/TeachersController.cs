using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.TeacherModel;
using Lessons_api.Domain.UserModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lessons_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById([FromRoute] int id)
        {
            var teacher = await _teacherService.GetTeacherById(id);

            return Ok(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachers();

            return Ok(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] ComingUserDTO model)
        {
            var addedTeacher = await _teacherService.AddTeacher(model);

            return Ok(addedTeacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher([FromRoute] int id, [FromBody] UpdateTeacherDTO model)
        {
            var updatedTeacher = await _teacherService.UpdateTeacher(id, model);

            return Ok(updatedTeacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherById([FromRoute] int id)
        {
            await _teacherService.DeleteTeacherById(id);

            return Ok();
        }
    }
}
