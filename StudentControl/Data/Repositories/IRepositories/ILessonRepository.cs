using StudentControl.Models;

namespace StudentControl.Data.Repositories.IRepositories
{
    public interface ILessonRepository
    {
        public string AddLesson(Guid GroupId, string LessonName, string ClassRoom);
        public IEnumerable<Lesson> GetAll();

        public IEnumerable<Lesson> GetFilterRange(string param);

        public IEnumerable<Visit> GetVisit(Guid LessonId);

    }
}
