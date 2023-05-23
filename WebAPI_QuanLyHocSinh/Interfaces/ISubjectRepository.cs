using WebAPI_QuanLyHocSinh.Context;

namespace WebAPI_QuanLyHocSinh.Interfaces
{
    public interface ISubjectRepository
    {
        ICollection<Subject> GetAllSubjects();
        Subject GetSubjectById(int subjectId);

        bool SubjectExists(int subjectId);
        bool CreateSubject(Subject subject);
        bool DeleteSubject(Subject subject);
        bool EditSubject(Subject subject);
        bool Save();
    }
}
