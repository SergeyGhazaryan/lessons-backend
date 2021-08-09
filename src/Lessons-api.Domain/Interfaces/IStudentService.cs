using Lessons_api.Domain.StudentModel;
using Lessons_api.Domain.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDTO> GetStudentById(int id);
        Task<List<StudentDTO>> GetAllStudents();
        Task<BaseUserDTO> AddStudent(CreateUserDTO model);
        Task<BaseUserDTO> UpdateStudent(int id, BaseUserDTO model);
        Task DeleteStudentById(int id);
    }
}
