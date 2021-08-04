using Lessons_api.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Data.Interfaces
{
    public interface ITeacherRepository
    {
        Task<TeacherEntity> GetTeacherById(int id);
        Task<List<TeacherEntity>> GetAllTeachers();
        Task<TeacherEntity> AddTeacher(TeacherEntity teacherEntity);
        Task<TeacherEntity> UpdateTeacher(int id, UserEntity userEntity);
        Task DeleteTeacherById(int id);
    }
}
