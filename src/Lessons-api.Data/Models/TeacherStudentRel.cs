using System.ComponentModel.DataAnnotations;

namespace Lessons_api.Data.Models
{
    public class TeacherStudentRel
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
    }
}
