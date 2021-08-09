using Lessons_api.Data.Context;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons_api.Data.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly LessonsContext _lessonsContext;

        public LessonRepository(LessonsContext lessonsContext)
        {
            _lessonsContext = lessonsContext;
        }

        public async Task<LessonEntity> GetLessonById(int id)
        {
            var result = await _lessonsContext.Lessons.FindAsync(id);

            return result;
        }

        public async Task<List<LessonEntity>> GetLessonsByTeacherId(int teacherId)
        {
            var result = await _lessonsContext.Lessons.Where(l => l.TeacherId == teacherId).ToListAsync();

            return result;
        }

        public async Task<List<LessonEntity>> GetAllLessons()
        {
            var result = await _lessonsContext.Lessons.ToListAsync();

            return result;
        }

        public async Task<LessonEntity> CreateLesson(LessonEntity lessonEntity)
        {
            _lessonsContext.Add(lessonEntity);
            await _lessonsContext.SaveChangesAsync();

            var result = await _lessonsContext.Lessons.FindAsync(lessonEntity.Id);

            return result;
        }

        public async Task<LessonEntity> UpdateLesson(int teacherId, int lessonId, LessonEntity lessonEntity)
        {
            var updatedLesson = await _lessonsContext.Lessons.Where(l => l.TeacherId == teacherId && l.Id == lessonId).FirstOrDefaultAsync();

            if (updatedLesson == null)
            {
                throw new HttpException(404, "Not Found");
            }

            updatedLesson.Title = lessonEntity.Title;
            updatedLesson.Description = lessonEntity.Description;
            updatedLesson.Price = lessonEntity.Price;
            updatedLesson.Language = lessonEntity.Language;
            await _lessonsContext.SaveChangesAsync();

            return updatedLesson;
        }

        public async Task DeleteLessonByTeacherId(int id, int teacherId)
        {
            var deletedLesson = await _lessonsContext.Lessons.Where(l => l.TeacherId == teacherId && l.Id == id).FirstOrDefaultAsync();

            if (deletedLesson == null)
            {
                throw new HttpException(404, "Not Found");
            }

            _lessonsContext.Lessons.Remove(deletedLesson);
            await _lessonsContext.SaveChangesAsync();
        }
    }
}
