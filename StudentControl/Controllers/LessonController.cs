using Microsoft.AspNetCore.Mvc;
using StudentControl.Data.Repositories.IRepositories;

namespace StudentControl.Controllers
{
    public class LessonController : Controller
    {
        private ILessonRepository _lessonRepositiry;

        public LessonController(ILessonRepository lessonRepository) 
        {
            _lessonRepositiry = lessonRepository;
        }

        public IActionResult Lessons()
        {
            return View(_lessonRepositiry.GetAll());
        }

        public IActionResult AddLesson(Guid GroupId,string LessonName,string ClassRoom) 
        {
            _lessonRepositiry.AddLesson(GroupId, LessonName, ClassRoom);
            return RedirectToAction("Lessons");
        }

        public IActionResult Visits(Guid LessonId) 
        {
            return View(_lessonRepositiry.GetVisit(LessonId)); 
        }
    }
}
