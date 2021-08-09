using System.Collections.Generic;

namespace Lessons_api.Data.Models
{
    public class StudentEntity
    {
        public StudentEntity()
        {
            Lessons = new HashSet<LessonEntity>();
            StudentLessonRels = new HashSet<StudentLessonRel>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public ICollection<LessonEntity> Lessons { get; set; }
        public ICollection<StudentLessonRel> StudentLessonRels { get; set; }
    }
}
