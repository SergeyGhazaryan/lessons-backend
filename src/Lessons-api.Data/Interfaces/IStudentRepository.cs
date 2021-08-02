using Lessons_api.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Data.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentEntity> GetStudentById(int id);
        Task<List<StudentEntity>> GetAllStudents();
        Task<StudentEntity> AddStudent(StudentEntity studentEntity);
        Task<StudentEntity> UpdateStudent(int id, StudentEntity studentEntity);
        Task DeleteStudentById(int id);
    }
}
