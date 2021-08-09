using System.Collections.Generic;

namespace Lessons_api.Data.Models
{
    public class TeacherEntity
    {
        public TeacherEntity()
        {
            Lessons = new HashSet<LessonEntity>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public ICollection<LessonEntity> Lessons { get; set; }
    }
}
