using System.ComponentModel.DataAnnotations;

namespace StudentControl.Models.ViewModel
{
    public class StudentVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public string GroupId { get; set; }
    }
}
