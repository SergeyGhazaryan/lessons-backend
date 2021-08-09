using System.Collections.Generic;

namespace Lessons_api.Data.Models
{
    public class LessonEntity
    {
        public LessonEntity()
        {
            Students = new HashSet<StudentEntity>();
            StudentLessonRels = new HashSet<StudentLessonRel>();
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
        public ICollection<StudentEntity> Students { get; set; }
        public ICollection<StudentLessonRel> StudentLessonRels { get; set; }
    }
}
