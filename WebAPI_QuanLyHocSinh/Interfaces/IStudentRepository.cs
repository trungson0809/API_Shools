
using WebAPI_QuanLyHocSinh.Context;
using WebAPI_QuanLyHocSinh.Models;

namespace WebAPI_QuanLyHocSinh.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetAllStudents();
        ICollection<Student> GetStudentsByName(string name);
        List<StudentResultModel> GetAllStudentOfClass(int classId);
        List<StudentResultModel> GetAllStudentOfRank(string rankName);
        string GeneratePDF(int classId);

        Student GetStudent(int studentId);

        bool StudentExists(int studentId);
        bool CreateStudent(Student student);
        bool DeleteStudent(Student student);
        bool EditStudent(Student student);
        bool Save();
    }
}
