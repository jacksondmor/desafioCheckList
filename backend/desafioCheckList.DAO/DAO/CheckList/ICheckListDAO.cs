using desafioCheckList.Core.Core;
using static desafioCheckList.Core.Core.CheckList;

namespace desafioCheckList.DAO.DAO
{
    public interface ICheckListDAO
    {
        Task<CheckList?> Insert(CheckList client);
        Task<CheckList?> Update(CheckList client);
        Task<bool> Delete(int id);
        Task<CheckList?> GetById(int id);
        Task<List<CheckList>?> List(FilterCheckList filter);
    }
}
