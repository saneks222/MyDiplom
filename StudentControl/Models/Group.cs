using System.ComponentModel.DataAnnotations;

namespace StudentControl.Models
{
    public class Group : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public Group()
        {
            Students = new List<Student>();
        }

        public List<Lesson> lessons { get; set; } = new List<Lesson>(); 
    }
}
