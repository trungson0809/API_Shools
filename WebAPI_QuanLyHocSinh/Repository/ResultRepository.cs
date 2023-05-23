using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;

namespace WebAPI_QuanLyHocSinh.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly db_schoolsContext _context;

        public ResultRepository(db_schoolsContext context)
        {
            _context = context;
        }

        // List
        public ICollection<Result> GetAllResults()
        {
            return _context.Results.OrderByDescending(c=>c.Gpa).ToList();
        }
        // Add all resutls into table Result
        public  bool UpdateAllResults()
        {
            
            var GPAtoList = (from s in _context.Courses
                             group s by s.StudentId into newList
                             select new
                             {
                                 StudentId = newList.Key,
                                 GPA = newList.Average(x => x.Mark)
                             });

            List<Result> resultList = new List<Result>();

            foreach (var item in GPAtoList)
            {
                Result objResult = new Result();
                objResult.StudentId = (int)item.StudentId;
                objResult.Gpa = item.GPA;
                if(item.GPA < 5)
                {
                    objResult.RankId = 4; // yếu
                }
                else if (item.GPA >= (decimal)5 && item.GPA < (decimal)6.5)
                {
                    objResult.RankId = 3; // Trung bình
                }
                else if (item.GPA >= (decimal)6.5 && item.GPA < (decimal)8)
                {
                    objResult.RankId = 2; // khá
                }
                else
                {
                    objResult.RankId = 1; // giỏi
                }
                resultList.Add(objResult);
            }
            _context.AddRange(resultList);      
            return Save();
        }
        // get 1
        public Result GetResultById(int resultId)
        {
            return _context.Results.Where(c => c.ResultId == resultId).FirstOrDefault();
        }
        
        public bool RemoveAllResults(List<Result> removeResult)
        {
            _context.RemoveRange(removeResult);
            return Save();
        }

        // Delete
        public bool DeleteResult(Result result)
        {
            _context.Remove(result);
            return Save();
        }
        // Edit
        public bool EditResult(Result result)
        {
            if (result.Gpa < 5)
            {
                result.RankId = 4; // yếu
            }
            else if (result.Gpa >= (decimal)5 && result.Gpa < (decimal)6.5)
            {
                result.RankId = 3; // Trung bình
            }
            else if (result.Gpa >= (decimal)6.5 && result.Gpa < (decimal)8)
            {
                result.RankId = 2; // khá
            }
            else
            {
                result.RankId = 1; // giỏi
            }
            _context.Update(result);
            return Save();
        }
  
        // Check
        public bool ResultExists(int ResultId)
        {
            return _context.Results.Any(c => c.ResultId == ResultId);
        }

        // Save
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
