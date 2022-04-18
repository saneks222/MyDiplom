using StudentControl.Models;

namespace StudentControl.Data.Repositories.IRepositories
{
    public interface IStudentRepository 
    { 
        public  Student GetById(Guid id);

        public IEnumerable<Student> GetAll();

        public string Remove(Guid id);

        public Student UpdateById(Guid id,Student student); 
    
        public Guid Add(Student student);

        public string AddRange(IEnumerable<Student> students); 
    }
}
