using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        [DisplayName("Course Name")]
        public string CrsName { get; set; }
        public int Degree { get; set; }
        [DisplayName("Minimum Degree")]
        public int MinDegree { get; set; }
        [ForeignKey ("Department")]
        public int dept_Id { get; set; }

        public virtual Department Department { get; set; }
    }
}
