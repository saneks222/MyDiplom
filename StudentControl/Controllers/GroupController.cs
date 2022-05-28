using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentControl.Data.Repositories.IRepositories;
using StudentControl.Models;

namespace StudentControl.Controllers
{
    public class GroupController : Controller
    {
        IGrupRepository _grupRepository;

        public GroupController(IGrupRepository grupRepository) 
        {
            _grupRepository = grupRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public  IActionResult Groups() 
        {
            return View(_grupRepository.GetAll()); 
        }


        [Authorize]
        public IActionResult FilterGroups(string filterParam) 
        {
           if(filterParam==null || filterParam=="")
                RedirectToAction("Groups");

           return View("Groups", _grupRepository.GetFilterRange(filterParam));
        }
        [Authorize]
        public IActionResult AddGroups(string name) 
        {
            if(name==""||name==null)
                RedirectToAction("Groups");

            var group = new Group();
            group.Name = name;

            _grupRepository.Add(group);

            return RedirectToAction("Groups");
        }

        [Authorize]
        public IActionResult DeleteGroup(Guid id) 
        {
            if(id==Guid.Empty)
                return View("Error");

            _grupRepository.Remove(id);

            return RedirectToAction("Groups");
        }
    }
}
