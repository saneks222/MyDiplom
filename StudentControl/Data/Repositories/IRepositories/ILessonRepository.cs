using StudentControl.Models;

namespace StudentControl.Data.Repositories.IRepositories
{
    public interface ILessonRepository
    {
        public string AddLesson(Guid GroupId, string LessonName, string ClassRoom);

        public string RemoveLesson(Guid id);

        public string UpdateVisit(List<Visit> visits);
        public IEnumerable<Lesson> GetAll();

        public IEnumerable<Lesson> GetFilterRange(string param);

        public IEnumerable<Visit> GetVisit(Guid LessonId);

    }
}
