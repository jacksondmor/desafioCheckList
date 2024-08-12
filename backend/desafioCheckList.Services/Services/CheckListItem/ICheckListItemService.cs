using desafioCheckList.Core.Core;
using FluentResults;
using static desafioCheckList.Core.Core.CheckListItem;

namespace desafioCheckList.Services.Services
{
    public interface ICheckListItemService
    {
        Task<Result<CheckListItem>> Insert(CheckListItem item);
        Task<Result> Update(int id, string login, CheckListItem item);
        Task<Result<CheckListItem>> GetById(int id);
        Task<Result<List<CheckListItem>>> List(FilterCheckListItem filter);
    }
}
