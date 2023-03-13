using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class InstructorController : Controller
    {
        ITIEntity DB = new ITIEntity();
        public IActionResult Index()
        {
            List<Instructor> instructors = DB.Instructors.Include(ins => ins.Department).Include(ins => ins.Course).ToList();
            return View(instructors);
        }
        public IActionResult Detail(int id)
        {
            Instructor? instructor = DB.Instructors.SingleOrDefault(inst => inst.Id == id);
            return View(instructor);
        }
        public IActionResult first()
        {
            TempData["Msg"] = "Hello Form ITI";
            return Content($"Data saved");
        }
        public IActionResult second() 
        {
            string message = TempData["Msg"].ToString(); 
            return Content($"Message: {message}");
        }
        public IActionResult third()
        {
            string message = "Empty";
            if (TempData.ContainsKey("Msg"))
            {
             message = TempData["Msg"].ToString();
            }
            return Content($"Message: {message}");
        }
    }
}
