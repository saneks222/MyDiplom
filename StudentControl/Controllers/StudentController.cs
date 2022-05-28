using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentControl.Data.Repositories.IRepositories;
using StudentControl.Models;
using StudentControl.Models.ViewModel;

namespace StudentControl.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult ShowGroup(Guid GroupId)
        {
            if(GroupId==Guid.Empty)
                return View("Error");

            ViewBag.GroupId = GroupId;

            return View(_studentRepository.GetAll(GroupId));
        }
        [Authorize]
        public IActionResult AddStudentView(string GroupId) 
        {
            return View(new StudentVM() { GroupId=GroupId});
        }
        [Authorize]
        public IActionResult CreateStudent(StudentVM student) 
        {
            if(!ModelState.IsValid)
                return View("Error");

            var newStudent = new Student();
            newStudent.GroupId = Guid.Parse(student.GroupId);
            newStudent.Name = student.Name;
            newStudent.Surname = student.Surname;
            newStudent.Patronymic = student.Patronymic;
            newStudent.DateOfBirth = student.DateOfBirth;

            _studentRepository.Add(newStudent);

            return RedirectToAction("ShowGroup", "Student",new { GroupId= new Guid(student.GroupId)});
        }
        [Authorize]
        public IActionResult DeleteStudent(string StudentId, string GroupId) 
        {
            if(StudentId==null|| StudentId==""|| GroupId == null || GroupId == "")
                return View("Error");

            _studentRepository.Remove(Guid.Parse(StudentId));

            return RedirectToAction("ShowGroup", "Student", new { GroupId = new Guid(GroupId)});
        }
    }
}
