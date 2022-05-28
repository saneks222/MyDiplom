using Microsoft.EntityFrameworkCore;
using StudentControl.Data.Repositories.IRepositories;
using StudentControl.Models;

namespace StudentControl.Data.Repositories
{
    public class LessonRepository : ILessonRepository
    {
       private readonly ApplicationDbContext _DB;
        public LessonRepository(ApplicationDbContext db) 
        {
            _DB = db;
        }

        public string AddLesson(Guid GroupId, string LessonName, string ClassRoom)
        {
            if(GroupId == Guid.Empty|| LessonName == "")
                throw new Exception("Не корректные данные");

            Group group = _DB.Groups.FirstOrDefault(x=>x.Id==GroupId);
            if (group == null)
                throw new Exception("группа не найдена");

            Lesson lesson = new Lesson();
            lesson.Name = LessonName;
            lesson.Group = group;
            lesson.Сlassroom = ClassRoom;
            Guid lessonId = _DB.Lessons.Add(lesson).Entity.Id;

            List<Student> studentsInGroup = _DB.Students.Where(x => x.GroupId == GroupId).ToList();

            if (studentsInGroup == null)
                throw new Exception("Ошибка при получение списка студентов в группе");

            foreach (var student in studentsInGroup) 
            {
                Visit visit = new Visit();
                visit.Attended = false;
                visit.LessonId = lessonId;
                visit.Student = student;
                _DB.Visits.Add(visit);
            }

            _DB.SaveChanges();

            return "200";
        }

        public IEnumerable<Lesson> GetAll()
        {
           var lessons =  _DB.Lessons.Include(x=>x.Group);
            if (lessons == null)
                throw new Exception("Группы отсутствуют");

            return lessons;
        }

        public IEnumerable<Lesson> GetFilterRange(string param)
        {
            if (param == null || param == "")
                return GetAll();

            var filter = param.ToLower();
            var lessons = _DB.Lessons.Include(x=>x.Group).Where(x=>x.Name.ToLower().Contains(filter)
                                                                ||x.Group.Name.ToLower().Contains(filter));
            if (lessons == null)
                throw new Exception("Группы отсутствуют");

            return lessons;
        }

        public IEnumerable<Visit> GetVisit(Guid LessonId)
        {
            if (LessonId == Guid.Empty)
                throw new Exception("Пустой гуид");

            var visit = _DB.Visits.Include(x=>x.Student).ThenInclude(x=>x.Group).Where(x => x.LessonId == LessonId);
            if (visit == null)
                throw new Exception("Даные отсутствуют");

            return visit;
        }

        public string RemoveLesson(Guid id)
        {
            Lesson lesson = _DB.Lessons.FirstOrDefault(x=>x.Id==id);
            _DB.Lessons.Remove(lesson);
            _DB.SaveChanges();

            return lesson.Id.ToString();
        }

        public string UpdateVisit(List<Visit> visits)
        {
            foreach (var visit in visits) 
            {
                var currentVisit = _DB.Visits.FirstOrDefault(x=>x.Id==visit.Id);
                currentVisit.Attended = visit.Attended;
                _DB.Visits.Update(currentVisit);
            }
            _DB.SaveChanges();

            return "200OK";
        }
    }
}
