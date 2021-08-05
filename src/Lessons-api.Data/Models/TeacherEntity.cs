namespace Lessons_api.Data.Models
{
    public class TeacherEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
