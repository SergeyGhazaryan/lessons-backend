using Lessons_api.Data.Context;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Host;
using System.Collections.Generic;
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
            var result = await _lessonsContext.Students.FindAsync(id);

            return result;
        }

        public async Task<List<StudentEntity>> GetAllStudents()
        {
            var result = await _lessonsContext.Students.ToListAsync();

            return result;
        }

        public async Task<StudentEntity> AddStudent(StudentEntity studentEntity)
        {
            await _lessonsContext.Students.AddAsync(studentEntity);
            await _lessonsContext.SaveChangesAsync();

            return studentEntity;
        }

        public async Task<StudentEntity> UpdateStudent(int id, StudentEntity studentEntity)
        {
            var updatedStudent = await _lessonsContext.Students.FindAsync(id);

            if (updatedStudent == null)
            {
                throw new HttpException(404, "Not Found");
            }

            updatedStudent.FirstName = studentEntity.FirstName;
            updatedStudent.LastName = studentEntity.LastName;
            updatedStudent.Country = studentEntity.Country;
            updatedStudent.City = studentEntity.City;
            updatedStudent.Age = studentEntity.Age;
            await _lessonsContext.SaveChangesAsync();

            return updatedStudent;
        }

        public async Task DeleteStudentById(int id)
        {
            var deletedStudent = await _lessonsContext.Students.FindAsync(id);

            if (deletedStudent == null)
            {
                throw new HttpException(404, "Not Found");
            }

            _lessonsContext.Students.Remove(deletedStudent);
            await _lessonsContext.SaveChangesAsync();
        }
    }
}
