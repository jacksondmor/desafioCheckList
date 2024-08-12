using desafioCheckList.Core;
using static desafioCheckList.Core.CheckListItem;

namespace desafioCheckList.DAO
{
    public interface ICheckListItemDAO
    {
        Task<CheckListItem?> Insert(CheckListItem item);
        Task<UpdateCheckListItem?> Update(int id, UpdateCheckListItem item);
        Task<CheckListItem?> GetById(int id);
        Task<List<CheckListItem>?> List(FilterCheckListItem filter);
    }
}
