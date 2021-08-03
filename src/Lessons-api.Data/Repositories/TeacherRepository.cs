using Lessons_api.Data.Context;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly LessonsContext _lessonsContext;

        public TeacherRepository(LessonsContext lessonsContext)
        {
            _lessonsContext = lessonsContext;
        }

        public async Task<TeacherEntity> GetTeacherById(int id)
        {
            var result = await _lessonsContext.Teachers.FindAsync(id);

            return result;
        }

        public async Task<List<TeacherEntity>> GetAllTeachers()
        {
            var result = await _lessonsContext.Teachers.ToListAsync();

            return result;
        }

        public async Task<TeacherEntity> AddTeacher(TeacherEntity teacherEntity)
        {
            await _lessonsContext.Teachers.AddAsync(teacherEntity);
            await _lessonsContext.SaveChangesAsync();

            return teacherEntity;
        }

        public async Task<TeacherEntity> UpdateTeacher(int id, TeacherEntity teacherEntity)
        {
            var updatedTeacher = await _lessonsContext.Teachers.FindAsync(id);

            if (updatedTeacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            updatedTeacher.FirstName = teacherEntity.FirstName;
            updatedTeacher.LastName = teacherEntity.LastName;
            updatedTeacher.Country = teacherEntity.Country;
            updatedTeacher.City = teacherEntity.City;
            updatedTeacher.Age = teacherEntity.Age;
            await _lessonsContext.SaveChangesAsync();

            return updatedTeacher;
        }

        public async Task DeleteTeacherById(int id)
        {
            var deletedTeacher = await _lessonsContext.Teachers.FindAsync(id);

            if (deletedTeacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            _lessonsContext.Teachers.Remove(deletedTeacher);
            await _lessonsContext.SaveChangesAsync();
        }
    }
}
