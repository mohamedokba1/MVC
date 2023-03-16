using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using MVC.Models;
using MVC.ViewModel;

namespace MVC.Controllers
{
    public class InstructorController : Controller
    {
        ITIEntity DB = new ITIEntity();
        private readonly IWebHostEnvironment _environment;
        public InstructorController(IWebHostEnvironment environment)
        {
            _environment = environment; 
        }
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cousrse = DB.Courses.ToList();
            var Departments = DB.Departments.ToList();
            var oldref = DB.Instructors.Include(ins => ins.Department).Include(ins => ins.Course).Where(ins => ins.Id == id)
                .Select(ins => new InstructorDepartmentCourseViewModel()
                {
                    instID = ins.Id,
                    instName = ins.InsName,
                    salary = ins.Salary,
                    address = ins.Address,
                    image = ins.Image,
                    depId = ins.Dept_Id,
                    crs_id = ins.Crs_Id,
                    crsName = ins.Course.CrsName,
                    deptName = ins.Department.DeptName,
                    departments = Departments,
                    courses= cousrse,
                }).FirstOrDefault();
            return View(oldref);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int id, InstructorDepartmentCourseViewModel newIns)
        {
            string newFileName = string.Empty;
            Instructor oldRef = DB.Instructors.FirstOrDefault(ins => ins.Id == id);
            if (newIns.instName != null)
            {
                if(newIns.imageFile != null && newIns.imageFile.FileName != oldRef.Image)
                {
                    string uploads = Path.Combine(_environment.WebRootPath, "imgs");
                    newFileName = newIns.imageFile.FileName;
                    string fullpath = Path.Combine(uploads, newFileName);
                    
                    string oldFileName = oldRef.Image;
                    if(oldFileName == null) 
                    {
                        oldFileName = "";
                    }
                    string oldReferenceImage = Path.Combine(uploads, oldFileName);
                    if(oldReferenceImage != fullpath) 
                    {
                        System.IO.File.Delete(oldReferenceImage);
                        newIns.imageFile.CopyTo(new FileStream(fullpath, FileMode.Create));

                    }
                    newIns.image = newFileName;
                }
                oldRef.InsName = newIns.instName;
                oldRef.Salary = newIns.salary;
                oldRef.Address = newIns.address;
                oldRef.Image = (newIns.image != null)? newIns.image : oldRef.Image;
                oldRef.Crs_Id = newIns.crs_id;
                oldRef.Dept_Id = newIns.depId;
                DB.Update(oldRef);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newIns);
        }
        public IActionResult New()
        {
            InstructorDepartmentCourseViewModel InsDept = new InstructorDepartmentCourseViewModel();
            InsDept.courses =DB.Courses.ToList();
            InsDept.departments =DB.Departments.ToList();
            return View(InsDept);
        }
        [HttpPost]
        public IActionResult saveNew(InstructorDepartmentCourseViewModel newIns) 
        {
            Instructor newInstractor = new Instructor();
            if(newIns.instName != null)
            {
                if (newIns.imageFile != null)
                {
                    string uploads = Path.Combine(_environment.WebRootPath, "imgs");
                    string newFileName = newIns.imageFile.FileName;
                    string fullpath = Path.Combine(uploads, newFileName);
                    newIns.imageFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    newIns.image = newFileName;
                }
                newInstractor.InsName = newIns.instName;
                newInstractor.Address = newIns.address;
                newInstractor.Salary = newIns.salary;
                newInstractor.Image = newIns.image;
                newInstractor.Crs_Id = newIns.crs_id;
                newInstractor.Dept_Id = newIns.depId;
                DB.Instructors.Add(newInstractor);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }
    }
}
