using Microsoft.AspNetCore.Mvc;
using MVC.Repository;
using MVC.Models;
namespace MVC.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }
        public IActionResult Index()
        {
            return View(departmentRepository.GetAll());
        }
        public IActionResult Delete(int id)
        {
            departmentRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id, Department dept )
        {
            departmentRepository.Update(id, dept);
            return RedirectToAction("Index");
        }
        public IActionResult New(Department dept)
        {
            departmentRepository.Insert(dept);
            return RedirectToAction("Index");
        }
    }
}
