using StudentControl.Data.Repositories.IRepositories;
using StudentControl.Models;

namespace StudentControl.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _Db;

        public StudentRepository(ApplicationDbContext dbContext) 
        {
            _Db = dbContext;
        }

        public Guid Add(Student student)
        {
            if (student != null) 
                throw new Exception("Не возможно добавить пустой обьект");
            
            var currentStudent = _Db.Students.Add(student);
            _Db.SaveChanges();

            return currentStudent.Entity.Id;
        }

        public string AddRange(IEnumerable<Student> students)
        {
            if (students == null) 
                throw new Exception("Не возможно добавить пустую коллекцию обьектов");

            _Db.Students.AddRange(students);
            _Db.SaveChanges();

            return "200";
        }

        public IEnumerable<Student> GetAll()
        {
            var students = _Db.Students.ToList();

            if(students==null)
                throw new Exception("Данные не найдены");

            return students;
        }

        public Student GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Пустой гуид");

            var student = _Db.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                throw new Exception("Студент с таким id не найден");

            return student;
        }

        public string Remove(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Пустой гуид");

            var student = _Db.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                throw new Exception("Студент с таким id не найден");

            _Db.Students.Remove(student);
            _Db.SaveChanges();

            return "200";
        }

        public Student UpdateById(Guid id, Student student)
        {
            if (id == Guid.Empty)
                throw new Exception("Пустой гуид");
            if (student == null)
                throw new Exception("Отсутсвуют данные для обновления");

            var currentStudent = _Db.Students.FirstOrDefault(x => x.Id == id);
            if (currentStudent == null)
                throw new Exception("Студент с таким id не найден");

            currentStudent.ModifiedOn = DateTime.Now;
            currentStudent.Name = student.Name != null ? student.Name : currentStudent.Name;
            currentStudent.Surname = student.Surname != null ? student.Surname : currentStudent.Surname;
            currentStudent.Patronymic = student.Patronymic != null ? student.Patronymic : currentStudent.Patronymic;
            currentStudent.DateOfBirth = student.DateOfBirth != default(DateTime) ? student.DateOfBirth : currentStudent.DateOfBirth;

            var addedStudent = _Db.Students.Add(currentStudent);
            _Db.SaveChanges();

            return addedStudent.Entity;
        }
    }
}
