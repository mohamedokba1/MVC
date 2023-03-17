using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(20)]
        [MaxLength (30)]
        [Range(minimum: 10, maximum: 30)]
        public string TraineeName { get; set; }
        [RegularExpression(@"\w*\.(png | jpg | jif)")]
        public string Image { get; set; }
        public string Address { get; set; }
        public int Grade { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }

        public virtual Department? Department { get; set; }
    }
}
