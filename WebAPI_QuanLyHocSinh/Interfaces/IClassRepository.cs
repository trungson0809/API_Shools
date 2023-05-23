using WebAPI_QuanLyHocSinh.Context;

namespace WebAPI_QuanLyHocSinh.Interfaces
{
    public interface IClassRepository
    {
        ICollection<Class> GetAllClasses();
        Class GetClassById(int classId);
        ICollection<Student> GetStudentsByClassId(int classId);


        bool ClassExists(int classId);
        bool CreateClass(Class _class);
        bool DeleteClass(Class _class);
        bool EditClass(Class _class);
        bool Save();
    }
}
