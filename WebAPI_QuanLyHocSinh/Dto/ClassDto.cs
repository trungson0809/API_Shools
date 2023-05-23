using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_QuanLyHocSinh.Dto
{
    public class ClassDto
    {
        public int ClassId { get; set; }

        public string? Name { get; set; }

    }
}
