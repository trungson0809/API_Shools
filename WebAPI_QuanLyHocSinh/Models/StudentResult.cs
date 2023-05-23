using WebAPI_QuanLyHocSinh.Context;

namespace WebAPI_QuanLyHocSinh.Models
{
  
    public class StudentResultModel
    {
        public int StudentId { get; set; }
        public string? ClassName { get; set; }
        public string? SubjectName { get; set; }
        public string? SubjectMark{ get; set; }
        public decimal? GPA { get; set; }
        public string? StudentName { get; set; }

        public string? RankName { get; set; }
    }
}
