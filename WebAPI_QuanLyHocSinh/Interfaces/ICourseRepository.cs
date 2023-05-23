using WebAPI_QuanLyHocSinh.Context;

namespace WebAPI_QuanLyHocSinh.Interfaces
{
    public interface ICourseRepository
    {
        ICollection<Course> GetAllCourses();

        Course GetCourseById(int courseId);


        bool CourseExists(int courseId);
        bool CreateCourse(Course course);
        bool DeleteCourse(Course course);
        bool EditCourse(Course course);
        bool Save();
    }
}
