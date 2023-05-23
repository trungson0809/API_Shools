using System;
using System.Collections.Generic;

namespace WebAPI_QuanLyHocSinh.Context
{
    public partial class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
            Results = new HashSet<Result>();
        }

        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
