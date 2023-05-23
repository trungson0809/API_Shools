using System;
using System.Collections.Generic;

namespace WebAPI_QuanLyHocSinh.Context
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public decimal? Mark { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
