using desafioCheckList.Core;
using FluentResults;
using static desafioCheckList.Core.Vehicle_InspectionList;

namespace desafioCheckList.Services
{
    public interface IVehicle_InspectionListService
    {
        Task<Result<Vehicle_InspectionList>> GetById(int id);
        Task<Result<List<Vehicle_InspectionList>>> List(FilterVehicle_InspectionList filter);
    }
}
