using desafioCheckList.Core.Core;

namespace desafioCheckList.DAO.DAO
{
    public interface ICheckListDAO
    {
        Task<CheckList?> Insert(CheckList client);
        Task<CheckList?> Update(CheckList client);
        Task<bool> Delete(int id);
        Task<CheckList?> GetById(int id);
    }
}
