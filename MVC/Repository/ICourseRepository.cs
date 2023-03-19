using MVC.Models;

namespace MVC.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();
        public void Delete(Course course);
        public void Update(int id, Course course);
        public Course GetById(int id);
        public void Insert(Course course);
    }
}
