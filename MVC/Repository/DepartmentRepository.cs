using MVC.Models;

namespace MVC.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIEntity Context;
        public DepartmentRepository(ITIEntity context) // inject Context
        {
            Context = context;
        }
        public void Delete(int deptid)
        {
            Department dept = Context.Departments.FirstOrDefault(dept => dept.Id == deptid); ;
            Context.Departments.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return Context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return Context.Departments.FirstOrDefault(dept => dept.Id == id);
        }

        public void Insert(Department department)
        {
            Context.Departments.Add(department);
        }

        public void Update(int Id, Department department)
        {
            Department oldDept = Context.Departments.FirstOrDefault(dept => dept.Id == Id);
            oldDept.DeptName = department.DeptName;
            oldDept.DeptManager = department.DeptManager;
            oldDept.Instructors = department.Instructors;
            Context.Departments.Update(oldDept);
        }
    }
}
