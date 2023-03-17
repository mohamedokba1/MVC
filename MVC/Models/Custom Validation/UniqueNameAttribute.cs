using MVC.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Custom_Validation
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        ITIEntity Context = new ITIEntity();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CourseDepartmentViewModel FromRequest = validationContext.ObjectInstance as CourseDepartmentViewModel;
            string crsName = value.ToString();
            
            Course course = Context.Courses.FirstOrDefault(crs => crs.CrsName == crsName && crs.dept_Id == FromRequest.dept_id);
            if (course == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                string DptName = Context.Departments.FirstOrDefault(dept => dept.Id == FromRequest.dept_id).DeptName;
                return new ValidationResult($"This course is already exist in {DptName}");
            }
            
        }
    }
}
