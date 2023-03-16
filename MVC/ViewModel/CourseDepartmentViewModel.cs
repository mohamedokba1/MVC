using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using MVC.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MVC.Validation;

namespace MVC.ViewModel
{
    public class CourseDepartmentViewModel
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Min Length is 2 Letters")]
        [MaxLength(20, ErrorMessage = "Max Length is 20 Letters")]
        [Required]
        [DisplayName("Course Name")]
        [UniqueName]
        public string CrsName { get; set; }
        [Range(maximum: 100, minimum: 50, ErrorMessage = "Degree Must be between 50 and 100")]
        public int Degree { get; set; }
        [DisplayName("Minimum Degree")]
        [Remote("CheckMinDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "Min Degree Must be Less than Degree")]
        public int MinDegree { get; set; }
        [Required(ErrorMessage = "Department is Required")]
        public int dept_id { get; set; }

        public List<Department>? departments { get; set; }
    }
}
