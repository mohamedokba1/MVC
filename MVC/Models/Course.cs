using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CrsName { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        [ForeignKey ("Department")]
        public int dept_Id { get; set; }

        public virtual Department Department { get; set; }
    }
}
