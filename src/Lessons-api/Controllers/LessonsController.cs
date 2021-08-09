using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.LessonModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lessons_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById([FromRoute] int id)
        {
            var lesson = await _lessonService.GetLessonById(id);

            return Ok(lesson);
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetLessonsByTeacherId([FromRoute] int teacherId)
        {
            var lessons = await _lessonService.GetLessonsByTeacherId(teacherId);

            return Ok(lessons);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            var lessons = await _lessonService.GetAllLessons();

            return Ok(lessons);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromBody] LessonContentDTO model)
        {
            int teacherId = 3;  //We will retrieve it from HttpContext later (currentUser)
            var createdLesson = await _lessonService.CreateLesson(teacherId, model);

            return Ok(createdLesson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson([FromRoute] int id, [FromBody] LessonContentDTO model)
        {
            int teacherId = 3;  //We will retrieve it from HttpContext later (currentUser) 
            var updatedLesson = await _lessonService.UpdateLesson(teacherId, id, model);

            return Ok(updatedLesson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLessonByTeacherId([FromRoute] int id)
        {
            int teacherId = 3;  //We will retrieve it from HttpContext later (currentUser)
            await _lessonService.DeleteLessonByTeacherId(id, teacherId);

            return Ok();
        }
    }
}
