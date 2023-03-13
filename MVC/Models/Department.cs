namespace MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string DeptManager { get; set; }

        public virtual List<Instructor>? Instructors { get; set; }
    }
}
