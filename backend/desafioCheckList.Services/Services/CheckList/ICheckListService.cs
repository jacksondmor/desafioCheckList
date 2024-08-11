using desafioCheckList.Core.Core;
using FluentResults;
using static desafioCheckList.Core.Core.CheckList;

namespace desafioCheckList.Services.Services
{
    public interface ICheckListService
    {
        Task<Result<CheckList>> Insert(CheckList checkList);
        Task<Result> Update(int id, CheckList checkList);
        Task<Result> Delete(int id);
        Task<Result<CheckList>> GetById(int id);
        Task<Result<List<CheckList>>> List(FilterCheckList filter);
    }
}
