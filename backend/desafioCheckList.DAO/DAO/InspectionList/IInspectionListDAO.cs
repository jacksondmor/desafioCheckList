using desafioCheckList.Core;
using static desafioCheckList.Core.InspectionList;

namespace desafioCheckList.DAO
{
    public interface IInspectionListDAO
    {
        Task<InspectionList> GetById(int id);
        Task<List<InspectionList>?> List(FilterInspectionList filter);
    }
}
