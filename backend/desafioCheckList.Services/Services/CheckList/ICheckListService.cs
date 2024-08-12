using desafioCheckList.Core;
using FluentResults;
using static desafioCheckList.Core.CheckList;

namespace desafioCheckList.Services
{
    public interface ICheckListService
    {
        Task<Result<CheckList>> Insert(InsertCheckList checkList);
        Task<Result> Update(int id, UpdateCheckList checkList);
        Task<Result> Delete(int id);
        Task<Result<CheckList>> GetById(int id);
        Task<Result<List<CheckList>>> List(FilterCheckList filter);
    }
}
