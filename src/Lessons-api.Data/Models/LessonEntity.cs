using System.Collections.Generic;

namespace Lessons_api.Data.Models
{
    public class LessonEntity
    {
        public LessonEntity()
        {
            StudentLessonRels = new HashSet<StudentLessonRel>();
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Language { get; set; }
        public ICollection<StudentLessonRel> StudentLessonRels { get; set; }
    }
}
