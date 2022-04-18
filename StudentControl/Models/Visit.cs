namespace StudentControl.Models
{
    public class Visit:BaseModel
    {
        public Guid LessonId { get; set; }
        public Student Student { get; set; }
        public bool Attended { get; set; }
    }
}
