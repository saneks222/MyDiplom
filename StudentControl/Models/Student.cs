using System.ComponentModel.DataAnnotations;

namespace StudentControl.Models
{
    public class Student:BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
