using Lessons_api.Domain.UserModel;

namespace Lessons_api.Domain.StudentModel
{
    public class StudentDTO : UserDTO
    {
        public int Id { get; set; }
    }
}
