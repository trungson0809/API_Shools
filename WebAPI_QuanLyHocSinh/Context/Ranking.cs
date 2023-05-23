using System;
using System.Collections.Generic;

namespace WebAPI_QuanLyHocSinh.Context
{
    public partial class Ranking
    {
        public Ranking()
        {
            Results = new HashSet<Result>();
        }

        public int RankId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
