using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViewModel;
using System.Drawing;

namespace MVC.Controllers
{
    public class TraineeController : Controller
    {
        ITIEntity DbContext = new ITIEntity();
        public IActionResult showResult(int id, int crsid)
        {
            var CourseStudentData = DbContext.CrsResults.Include(c => c.Trainee).Include(c => c.Course)
                .Where(c => c.trainee_id == id && c.crs_Id == crsid)
                .Select(t =>  new CourseResultViewModel
                {
                    studentName = t.Trainee.TraineeName,
                    CrsName = t.Course.CrsName,
                    sudentDegree = t.Degree,
                    color = (t.Degree > t.Course.MinDegree) ? "green" : "red"
                }).FirstOrDefault();
            return View(CourseStudentData);
        }

        public IActionResult showCourseResult(int id)
        {
            var courseData = DbContext.CrsResults.Include(s => s.Trainee).Where(crs => crs.crs_Id == id)
                .Select(t => new CourseResultViewModel()
                {
                   studentName =  t.Trainee.TraineeName,
                   sudentDegree =  t.Degree,
                   CrsName =  t.Course.CrsName,
                   color =  (t.Degree > t.Course.MinDegree) ? "green" : "red" 
                }).ToList();
             
            return View(courseData);
        }
    }

}
