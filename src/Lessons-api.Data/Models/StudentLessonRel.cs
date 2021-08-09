using System.ComponentModel.DataAnnotations;

namespace Lessons_api.Data.Models
{
    public class StudentLessonRel
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }
    }
}
