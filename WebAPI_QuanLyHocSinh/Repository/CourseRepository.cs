
using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;
using WebAPI_QuanLyHocSinh.Dto;

using Microsoft.EntityFrameworkCore;
using WebAPI_QuanLyHocSinh.Context;

namespace WebAPI_QuanLyHocSinh.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly db_schoolsContext _context;

        public CourseRepository(db_schoolsContext context)
        {
            _context = context;
        }

        // List
        public ICollection<Course> GetAllCourses()
        {
            return _context.Courses.OrderBy(c=>c.CourseId).ToList();
        }
        // get 1
        public Course GetCourseById(int courseId)
        {
            return _context.Courses.Where(c => c.CourseId == courseId).FirstOrDefault();
        }
        
        // Create
        public bool CreateCourse(Course course)
        {
            _context.Add(course);
            return Save();
        }

        // Delete
        public bool DeleteCourse(Course course)
        {
            _context.Remove(course);
            return Save();
        }
        // Edit
        public bool EditCourse(Course course)
        {
            _context.Update(course);
            return Save();
        }
  
        // Check
        public bool CourseExists(int courseId)
        {
            return _context.Courses.Any(c => c.CourseId == courseId);
        }

        // Save
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Course> GetStudentsByMarks(int markStart)
        {
            throw new NotImplementedException();
        }
    }
}
