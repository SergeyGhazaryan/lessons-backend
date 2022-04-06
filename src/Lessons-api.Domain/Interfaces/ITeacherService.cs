using Lessons_api.Domain.TeacherModel;
using Lessons_api.Domain.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetTeacherById(int id);
        Task<List<TeacherDTO>> GetAllTeachers();
        Task<BaseUserDTO> AddTeacher(CreateUserDTO model);
        Task<BaseUserDTO> UpdateTeacher(int id, BaseUserDTO model);
        Task DeleteTeacherById(int id);
    }
}
