namespace StudentControl.Models
{
    public class Lesson:BaseModel
    {
        public string Name { get; set; }
        public string Сlassroom { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
