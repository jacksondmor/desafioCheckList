using desafioCheckList.Core.Core;
using static desafioCheckList.Core.Core.CheckListItem;

namespace desafioCheckList.DAO.DAO
{
    public interface ICheckListItemDAO
    {
        Task<CheckListItem?> Insert(CheckListItem item);
        Task<CheckListItem?> Update(CheckListItem item);
        Task<CheckListItem?> GetById(int id);
        Task<List<CheckListItem>?> List(FilterCheckListItem filter);
    }
}
