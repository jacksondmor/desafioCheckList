using desafioCheckList.Core;
using FluentResults;
using static desafioCheckList.Core.VehicleType;

namespace desafioCheckList.Services
{ 
    public interface IVehicleTypeService
    {
        Task<Result<VehicleType>> GetById(int id);
        Task<Result<List<VehicleType>>> List(FilterVehicleType filter);
    }
}
