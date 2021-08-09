namespace Lessons_api.Domain.LessonModel
{
    public class BaseLessonDTO
    {
        public int TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
    }
}
