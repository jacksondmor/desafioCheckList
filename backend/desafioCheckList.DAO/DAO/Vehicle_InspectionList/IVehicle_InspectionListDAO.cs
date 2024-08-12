using desafioCheckList.Core.Core;
using static desafioCheckList.Core.Core.Vehicle_InspectionList;

namespace desafioCheckList.DAO.DAO
{
    public interface IVehicle_InspectionListDAO
    {
        Task<Vehicle_InspectionList> GetById(int id);
        Task<List<Vehicle_InspectionList>?> List(FilterVehicle_InspectionList filter);
    }
}
