using WebAPI_QuanLyHocSinh.Context;
using WebAPI_QuanLyHocSinh.Dto;

namespace WebAPI_QuanLyHocSinh.Interfaces
{
    public interface IResultRepository
    {
        ICollection<Result> GetAllResults();
        Result GetResultById(int resultId);

        bool ResultExists(int resultId);

        bool DeleteResult(Result result);
        bool EditResult(Result result);
        bool RemoveAllResults(List<Result> removeResult);
        bool UpdateAllResults();

        bool Save();
    }
}
