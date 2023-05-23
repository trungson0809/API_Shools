
using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;
using WebAPI_QuanLyHocSinh.Dto;

using Microsoft.EntityFrameworkCore;

namespace WebAPI_QuanLyHocSinh.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly db_schoolsContext _context;

        public SubjectRepository(db_schoolsContext context)
        {
            _context = context;
        }

        // List
        public ICollection<Subject> GetAllSubjects()
        {
            return _context.Subjects.OrderBy(c=>c.SubjectId).ToList();
        }
        // take 1
        public Subject GetSubjectById(int subjectId)
        {
            return _context.Subjects.Where(c => c.SubjectId == subjectId).FirstOrDefault();
        }

        // Create
        public bool CreateSubject(Subject subject)
        {
            _context.Add(subject);
            return Save();
        }

        // Delete
        public bool DeleteSubject(Subject subject)
        {
            _context.Remove(subject);
            return Save();
        }
        // Edit
        public bool EditSubject(Subject subject)
        {
            _context.Update(subject);
            return Save();
        }
  
        // Check
        public bool SubjectExists(int subjectId)
        {
            return _context.Subjects.Any(c => c.SubjectId == subjectId);
        }

        // Save
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }    
    }
}
