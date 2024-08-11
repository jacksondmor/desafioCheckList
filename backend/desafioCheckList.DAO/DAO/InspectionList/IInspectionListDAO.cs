using desafioCheckList.Core.Core;

namespace desafioCheckList.DAO.DAO
{
    public interface IInspectionListDAO
    {
        Task<InspectionList> GetById(int id);
    }
}
