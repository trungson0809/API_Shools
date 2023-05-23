
using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;

using Microsoft.EntityFrameworkCore;
using PdfSharpCore;
using PdfSharpCore.Pdf;

using AutoMapper;
using WebAPI_QuanLyHocSinh.Models;
using System.Text;

namespace WebAPI_QuanLyHocSinh.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly db_schoolsContext _context;
        private readonly IMapper _mapper;


        public StudentRepository(db_schoolsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get All
        public ICollection<Student> GetAllStudents()
        {
            return _context.Students.OrderBy(c => c.Name).ToList();
        }// Get by Name
        public ICollection<Student> GetStudentsByName(string name)
        {
            return _context.Students.Where(c => c.Name.Contains(name)).OrderBy(c => c.Name).ToList();
        }

        //take 1
        public Student GetStudent(int studentId)
        {
            return _context.Students.Where(c => c.StudentId == studentId).FirstOrDefault();
        }
        // Get students with class
        public List<StudentResultModel> GetAllStudentOfClass(int classId)
        {
            var allStudents = _context.Results.AsQueryable();
            if (!string.IsNullOrEmpty(classId.ToString())) 
            {
                allStudents = allStudents.Include(s => s.Student).Where(s => s.Student.ClassId == classId).OrderByDescending(c=>c.Gpa);
            }

            var result = allStudents.Select(c => new StudentResultModel
            {
                StudentId   = c.StudentId,
                ClassName   = c.Student.Class.Name,
                RankName    = c.Rank.Name.ToString(),
                StudentName = c.Student.Name.ToString(),

                GPA = (decimal)c.Gpa
            });
            return result.ToList();
        }
        // Get  students with rank
        public List<StudentResultModel> GetAllStudentOfRank(string rankName)
        {
            var allStudents = _context.Results.AsQueryable();
            if (!string.IsNullOrEmpty(rankName.ToString()))
            {
                allStudents = allStudents.Include(s => s.Student).Where(s => s.Rank.Name== rankName);
            }

            var result = allStudents.Select(c => new StudentResultModel
            {
                StudentId   = c.StudentId,
                ClassName   = c.Student.Class.Name,


                RankName = c.Rank.Name.ToString(),
                StudentName = c.Student.Name.ToString(),

                GPA = (decimal)c.Gpa
            });
            return result.ToList();
        }

        // Create
        public bool CreateStudent(Student student)
        {
            _context.Add(student);
            return Save();
        }

        // Delete
        public bool DeleteStudent(Student student)
        {
            _context.Remove(student);
            return Save();
        }
        // Edit
        public bool EditStudent(Student student)
        {
            _context.Update(student);
            return Save();
        }
  
        // Check
        public bool StudentExists(int studentId)
        {
            return _context.Students.Any(c => c.StudentId == studentId);
        }

        // Save
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public string GeneratePDF(int classId)
        {
            var allStudents = _context.Results.AsQueryable();
            if (!string.IsNullOrEmpty(classId.ToString()))
            {
                allStudents = allStudents.Include(s => s.Student).Where(s => s.Student.ClassId == classId);
            }

            var result = allStudents.Select(c => new StudentResultModel
            {
                StudentId = c.StudentId,
                ClassName = c.Student.Class.Name,

                RankName = c.Rank.Name.ToString(),
                StudentName = c.Student.Name.ToString(),

                GPA = (decimal)c.Gpa
            });
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1> Bảng Điểm Lớp </h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Tên</th>
                                        <th>Lớp</th>
                                        <th>Điểm</th>
                                        <th>Xếp Loại</th>
                                    </tr>");
            foreach (var emp in result)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", emp.StudentName, emp.ClassName, emp.GPA, emp.RankName);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    

    
    }

}
