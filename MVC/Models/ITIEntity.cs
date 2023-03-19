using Microsoft.EntityFrameworkCore;

namespace MVC.Models
{
    public class ITIEntity : DbContext
    {
        public ITIEntity():base() { }

        public ITIEntity(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVCDB; Integrated Security = True; Encrypt = false");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
    }
}
