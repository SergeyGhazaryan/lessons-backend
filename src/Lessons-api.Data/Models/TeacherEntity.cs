using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lessons_api.Data.Models
{
    public class TeacherEntity
    {
        public TeacherEntity()
        {
            TeacherStudentRels = new HashSet<TeacherStudentRel>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [NotMapped]
        public ICollection<TeacherStudentRel> TeacherStudentRels { get; set; }
    }
}
