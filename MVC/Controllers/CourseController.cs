using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViewModel;

namespace MVC.Controllers
{
    public class CourseController : Controller
    {
        ITIEntity Context = new ITIEntity();


        public IActionResult Index()
        {
            List<Course> courses = Context.Courses.Include(crs => crs.Department).ToList();
            return View(courses);
        }

        public IActionResult New()
        {
            CourseDepartmentViewModel CourseDepartmentVM = new CourseDepartmentViewModel();
            CourseDepartmentVM.departments = Context.Departments.ToList();
            return View(CourseDepartmentVM);
        }
        public IActionResult save(CourseDepartmentViewModel newCourse)
        {
            Course course = new Course();
            if(ModelState.IsValid == true) 
            {
                try
                {
                    course.CrsName = newCourse.CrsName;
                    course.Degree = newCourse.Degree;
                    course.MinDegree = newCourse.MinDegree;
                    course.dept_Id = newCourse.dept_id;
                    Context.Courses.Add(course);
                    Context.SaveChanges();
                    return RedirectToAction("Index");
                }catch (Exception ex)
                {
                    // add local error 
                    //ModelState.AddModelError("dept_id", "Select a department");
                    ModelState.AddModelError(string.Empty, ex.Message);
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }

            }
            newCourse.departments = Context.Departments.ToList();
            return View("New",newCourse);
        }
        
        public IActionResult delete(int id)
        {
            Course oldCourse =Context.Courses.FirstOrDefault(crs => crs.Id == id);
            Context.Courses.Remove(oldCourse);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult checkMinDegree(int MinDegree, int Degree)
             => (MinDegree > Degree) ? Json(false) : Json(true);

        //public IActionResult CheckMinDegree(int Degree, int MinDegree)
        //   => (MinDegree < Degree) ? Json(true) : Json(false);
    }
}
