using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentControl.Data.Repositories.IRepositories;
using StudentControl.Models;

namespace StudentControl.Controllers
{
    public class LessonController : Controller
    {
        private ILessonRepository _lessonRepositiry;

        public LessonController(ILessonRepository lessonRepository) 
        {
            _lessonRepositiry = lessonRepository;
        }
        [Authorize]
        public IActionResult Lessons()
        {
            return View(_lessonRepositiry.GetAll());
        }
        [Authorize]
        public IActionResult AddLesson(Guid GroupId,string LessonName,string ClassRoom) 
        {
            _lessonRepositiry.AddLesson(GroupId, LessonName, ClassRoom);
            return RedirectToAction("Lessons");
        }
        [Authorize]
        public IActionResult Visits(Guid LessonId) 
        {
            return View(_lessonRepositiry.GetVisit(LessonId).ToList()); 
        }
        [Authorize]
        public IActionResult DeleteLesson(Guid id) 
        {
            if(id==null||id==Guid.Empty)
                return View("Error");

            _lessonRepositiry.RemoveLesson(id);

            return View("Lessons",_lessonRepositiry.GetAll());
        }
        [Authorize]
        public IActionResult UpdateVisit(List<Visit> visits) 
        {
            _lessonRepositiry.UpdateVisit(visits);
            return RedirectToAction("Lessons");
        }
    }
}
