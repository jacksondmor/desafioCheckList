using desafioCheckList.Core;
using static desafioCheckList.Core.Vehicle_InspectionList;

namespace desafioCheckList.DAO
{
    public interface IVehicle_InspectionListDAO
    {
        Task<Vehicle_InspectionList> GetById(int id);
        Task<List<Vehicle_InspectionList>?> List(FilterVehicle_InspectionList filter);
    }
}
