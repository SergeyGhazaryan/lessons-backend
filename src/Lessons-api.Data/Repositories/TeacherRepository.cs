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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly LessonsContext _lessonsContext;

        public TeacherRepository(LessonsContext lessonsContext)
        {
            _lessonsContext = lessonsContext;
        }

        public async Task<TeacherEntity> GetTeacherById(int id)
        {
            var result = await _lessonsContext.Teachers.Include(s => s.User).SingleOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<List<TeacherEntity>> GetAllTeachers()
        {
            var result = await _lessonsContext.Teachers.Include(t => t.User).ToListAsync();

            return result;
        }

        public async Task<TeacherEntity> AddTeacher(TeacherEntity teacherEntity)
        {
            await _lessonsContext.Teachers.AddAsync(teacherEntity);
            await _lessonsContext.SaveChangesAsync();

            return teacherEntity;
        }

        public async Task<TeacherEntity> UpdateTeacher(int id, UserEntity userEntity)
        {
            var updatedTeacher = await _lessonsContext.Teachers.Include(t => t.User).SingleOrDefaultAsync(t => t.Id == id);

            if (updatedTeacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var updatedTeacherUser = updatedTeacher.User;

            updatedTeacherUser.FirstName = userEntity.FirstName;
            updatedTeacherUser.LastName = userEntity.LastName;
            updatedTeacherUser.Country = userEntity.Country;
            updatedTeacherUser.City = userEntity.City;
            updatedTeacherUser.Age = userEntity.Age;
            await _lessonsContext.SaveChangesAsync();

            return updatedTeacher;
        }

        public async Task<int> DeleteTeacherById(int id)
        {
            var deletedTeacher = await _lessonsContext.Teachers.Where(s => s.Id == id).Include(s => s.User).FirstOrDefaultAsync();
            var deletedUserId = deletedTeacher.UserId;

            if (deletedTeacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            _lessonsContext.Teachers.Remove(deletedTeacher);
            await _lessonsContext.SaveChangesAsync();

            return deletedUserId;
        }
    }
}
