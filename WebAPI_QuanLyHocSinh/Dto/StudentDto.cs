using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WebAPI_QuanLyHocSinh.Dto
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int? ClassId { get; set; }

    }
}
