using Lessons_api.Domain.LessonModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Interfaces
{
    public interface ILessonService
    {
        Task<LessonDTO> GetLessonById(int id);
        Task<List<LessonDTO>> GetLessonsByTeacherId(int teacherId);
        Task<List<LessonDTO>> GetAllLessons();
        Task<LessonContentDTO> CreateLesson(int teacherId, LessonContentDTO model);
        Task<LessonContentDTO> UpdateLesson(int teacherId, int lessonId, LessonContentDTO model);
        Task DeleteLessonByTeacherId(int id, int teacherId);
    }
}
