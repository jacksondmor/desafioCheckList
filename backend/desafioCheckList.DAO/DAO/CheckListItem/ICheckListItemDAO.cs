using desafioCheckList.Core.Core;

namespace desafioCheckList.DAO.DAO
{
    public interface ICheckListItemDAO
    {
        Task<CheckListItem?> Insert(CheckListItem client);
        Task<CheckListItem?> Update(CheckListItem client);
        Task<CheckListItem?> GetById(int id);
    }
}
