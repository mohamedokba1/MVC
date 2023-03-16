using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class BindingController : Controller
    {
        ITIEntity DbContext  = new ITIEntity();
        public IActionResult primitiveTest(string name, int age, int id)
        {
            return Content($"{name}");
        }

        //Binding collection
        public IActionResult DicTest(Dictionary<string, string> phone, string name)
        {
            return Content("OK");
        }
        // any action serve on both (get and post)
        // using attribute to limit that choice of request type 

        [HttpPost]
        public IActionResult save(Department newDept)
        {
            if(newDept.DeptName != null)
            {
                DbContext.Departments.Add(newDept);
                DbContext.SaveChanges();
                
            }
            return View("Index");
        }
    }
}
