using Lessons_api.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Data.Interfaces
{
    public interface ILessonRepository
    {
        Task<LessonEntity> GetLessonById(int id);
        Task<List<LessonEntity>> GetLessonsByTeacherId(int teacherId);
        Task<List<LessonEntity>> GetAllLessons();
        Task<LessonEntity> CreateLesson(LessonEntity lessonEntity);
        Task<LessonEntity> UpdateLesson(int teacherId, int lessonId, LessonEntity lessonEntity);
        Task DeleteLessonByTeacherId(int id, int teacherId);
    }
}
