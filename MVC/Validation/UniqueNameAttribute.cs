using System.ComponentModel.DataAnnotations;
using MVC.Models;
namespace MVC.Validation
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        ITIEntity Context = new ITIEntity();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Course course = Context.Courses.FirstOrDefault(crs => crs.CrsName == value.ToString());
            return (course == null) ? ValidationResult.Success : new ValidationResult("This course is already exist");
        }
    }
}
