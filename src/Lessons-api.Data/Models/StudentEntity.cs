using System.Collections.Generic;

namespace Lessons_api.Data.Models
{
    public class StudentEntity
    {
        public StudentEntity()
        {
            TeacherStudentRels = new HashSet<TeacherStudentRel>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public ICollection<TeacherStudentRel> TeacherStudentRels { get; set; }
    }
}
