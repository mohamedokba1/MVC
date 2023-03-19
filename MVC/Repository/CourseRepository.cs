using MVC.Models;

namespace MVC.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ITIEntity Context;
        public CourseRepository(ITIEntity context)
        {
            Context = context;
        }
        public void Delete(Course course)
        {
            Context.Courses.Remove(course);
            Context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return Context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return Context.Courses.FirstOrDefault(crs => crs.Id == id);
        }

        public void Insert(Course course)
        {
            Context.Courses.Add(course);
            Context.SaveChanges();
        }

        public void Update(int id, Course course)
        {
            Course oldCourse = Context.Courses.FirstOrDefault(c => c.Id == id);
            oldCourse.CrsName = course.CrsName;
            oldCourse.MinDegree = course.MinDegree;
            oldCourse.dept_Id = course.dept_Id;
            oldCourse.Degree = course.Degree;
            oldCourse.Department = course.Department;
            Context.Courses.Update(course);
            Context.SaveChanges();
        }
    }
}
