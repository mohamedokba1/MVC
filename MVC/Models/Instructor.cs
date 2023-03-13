using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string InsName { get; set; }
        public double Salary { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        [ForeignKey ("Department")]
        public int Dept_Id { get; set; }
        [ForeignKey("Course")]
        public int Crs_Id { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Course? Course { get; set; }
    }
}
