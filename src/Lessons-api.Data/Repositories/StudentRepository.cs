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
    public class StudentRepository : IStudentRepository
    {
        private readonly LessonsContext _lessonsContext;

        public StudentRepository(LessonsContext lessonsContext)
        {
            _lessonsContext = lessonsContext;
        }

        public async Task<StudentEntity> GetStudentById(int id)
        {
            var result = await _lessonsContext.Students.Include(s => s.User).SingleOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<List<StudentEntity>> GetAllStudents()
        {
            var result = await _lessonsContext.Students.Include(s => s.User).ToListAsync();

            return result;
        }

        public async Task<StudentEntity> AddStudent(StudentEntity studentEntity)
        {
            await _lessonsContext.Students.AddAsync(studentEntity);
            await _lessonsContext.SaveChangesAsync();

            return studentEntity;
        }

        public async Task<StudentEntity> UpdateStudent(int id, UserEntity userEntity)
        {
            var updatedStudent = await _lessonsContext.Students.Include(s => s.User).SingleOrDefaultAsync(s => s.Id == id);

            if (updatedStudent == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var updatedStudentUser = updatedStudent.User;

            updatedStudentUser.FirstName = userEntity.FirstName;
            updatedStudentUser.LastName = userEntity.LastName;
            updatedStudentUser.Country = userEntity.Country;
            updatedStudentUser.City = userEntity.City;
            updatedStudentUser.Age = userEntity.Age;
            await _lessonsContext.SaveChangesAsync();

            return updatedStudent;
        }

        public async Task<int> DeleteStudentById(int id)
        {
            var deletedStudent = await _lessonsContext.Students.Where(s => s.Id == id).Include(s => s.User).FirstOrDefaultAsync();
            var deletedUserId = deletedStudent.UserId;

            if (deletedStudent == null)
            {
                throw new HttpException(404, "Not Found");
            }

            _lessonsContext.Students.Remove(deletedStudent);
            await _lessonsContext.SaveChangesAsync();

            return deletedUserId;
        }
    }
}
