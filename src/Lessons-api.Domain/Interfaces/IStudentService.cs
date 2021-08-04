using Lessons_api.Domain.StudentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDTO> GetStudentById(int id);
        Task<List<StudentDTO>> GetAllStudents();
        Task<AddStudentDTO> AddStudent(int userId);
        Task<UpdateStudentDTO> UpdateStudent(int id, UpdateStudentDTO model);
        Task DeleteStudentById(int id);
    }
}
