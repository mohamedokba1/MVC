using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        [ForeignKey ("Course")]
        public int crs_Id { get; set; }
        [ForeignKey ("Trainee")]
        public int trainee_id { get; set; }

        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
