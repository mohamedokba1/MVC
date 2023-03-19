using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using MVC.Models;
using System.Web;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModel
{
    public class InstructorDepartmentCourseViewModel
    {
        public int instID { get; set; }
        [MinLength(5)]
        [MaxLength(10)]
        public string instName { get; set; }
        [Range(minimum: 2000, maximum: 10000)]
        public int salary { get; set; }
        public string address { get; set; }
        //[RegularExpression (@"\w*\. (png | jpg | gif)")]
        public string? image { get; set; }
        public string? deptName { get; set; }
        public string? crsName { get; set; }
        public int depId { get; set; }
        public int crs_id { get; set; }
        public IFormFile imageFile { get; set; }
        public List<Department>? departments { get; set; }
        public List<Course>? courses { get; set; }
    }
}
