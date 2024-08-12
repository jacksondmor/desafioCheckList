using desafioCheckList.Core.Core;
using static desafioCheckList.Core.Core.InspectionList;

namespace desafioCheckList.DAO.DAO
{
    public interface IInspectionListDAO
    {
        Task<InspectionList> GetById(int id);
        Task<List<InspectionList>?> List(FilterInspectionList filter);
    }
}
