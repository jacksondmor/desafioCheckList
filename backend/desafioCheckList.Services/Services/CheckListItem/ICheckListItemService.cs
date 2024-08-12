using desafioCheckList.Core;
using FluentResults;
using static desafioCheckList.Core.CheckListItem;

namespace desafioCheckList.Services
{
    public interface ICheckListItemService
    {
        Task<Result<CheckListItem>> Insert(CheckListItem item);
        Task<Result> Update(int id, string login, UpdateCheckListItem item);
        Task<Result<CheckListItem>> GetById(int id);
        Task<Result<List<CheckListItem>>> List(FilterCheckListItem filter);
    }
}
