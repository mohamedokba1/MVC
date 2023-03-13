using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PassDataController : Controller
    {
        public IActionResult setSession()
        {
            HttpContext.Session.SetString("Name", "Mohamed");
            HttpContext.Session.SetInt32("Age", 25);
            return Content("Session created");
        }

        public IActionResult getSession()
        {
            string? name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content($"Name = {name}, Age = {age}");
        }
    }
}
