using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_QuanLyHocSinh.Dto
{ 
    public class CourseDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal Mark { get; set; }
    }
}
