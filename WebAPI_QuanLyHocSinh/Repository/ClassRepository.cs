
using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;
using WebAPI_QuanLyHocSinh.Dto;

using Microsoft.EntityFrameworkCore;
using WebAPI_QuanLyHocSinh.Context;

namespace WebAPI_QuanLyHocSinh.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly db_schoolsContext _context;

        public ClassRepository(db_schoolsContext context)
        {
            _context = context;
        }

        // List
        public ICollection<Class> GetAllClasses()
        {
            return _context.Classes.OrderBy(c=>c.ClassId).ToList();
        }
        // get 1
        public Class GetClassById(int classId)
        {
            return _context.Classes.Where(c => c.ClassId == classId).FirstOrDefault();
        }
        // get student by class
        public ICollection<Student> GetStudentsByClassId(int classId)
        {
            return _context.Students.Where(c => c.ClassId == classId).OrderBy(c => c.Name).ToList();
        }

        // Create
        public bool CreateClass(Class _class)
        {
            _context.Add(_class);
            return Save();
        }

        // Delete
        public bool DeleteClass(Class _class)
        {
            _context.Remove(_class);
            return Save();
        }
        // Edit
        public bool EditClass(Class _class)
        {
            _context.Update(_class);
            return Save();
        }
  
        // Check
        public bool ClassExists(int classId)
        {
            return _context.Classes.Any(c => c.ClassId == classId);
        }

        // Save
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
