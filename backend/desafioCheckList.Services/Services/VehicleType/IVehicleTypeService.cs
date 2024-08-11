using desafioCheckList.Core.Core;
using FluentResults;
using static desafioCheckList.Core.Core.VehicleType;

namespace desafioCheckList.Services.Services
{
    public interface IVehicleTypeService
    {
        Task<Result<VehicleType>> GetById(int id);
        Task<Result<List<VehicleType>>> List(FilterVehicleType filter);
    }
}
