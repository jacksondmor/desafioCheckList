using desafioCheckList.Core;
using static desafioCheckList.Core.CheckList;

namespace desafioCheckList.DAO
{
    public interface ICheckListDAO
    {
        Task<CheckList?> Insert(InsertCheckList client);
        Task<UpdateCheckList?> Update(int id, UpdateCheckList client);
        Task<bool> Delete(int id);
        Task<CheckList?> GetById(int id);
        Task<List<CheckList>?> List(FilterCheckList filter);
    }
}
