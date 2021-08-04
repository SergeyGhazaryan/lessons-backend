namespace Lessons_api.Data.Models
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
