using System;
using System.Collections.Generic;

namespace WebAPI_QuanLyHocSinh.Context
{
    public partial class Result
    {
        public int ResultId { get; set; }
        public int StudentId { get; set; }
        public decimal? Gpa { get; set; }
        public int? RankId { get; set; }

        public virtual Ranking? Rank { get; set; }
        public virtual Student Student { get; set; } = null!;
    }
}
