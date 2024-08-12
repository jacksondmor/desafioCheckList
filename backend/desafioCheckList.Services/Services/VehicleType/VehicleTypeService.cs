using desafioCheckList.Core.Core;
using desafioCheckList.DAO.DAO;
using FluentResults;
using static desafioCheckList.Core.Core.VehicleType;

namespace desafioCheckList.Services.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeDAO _vehicleTypeDAO;
        public VehicleTypeService(IVehicleTypeDAO vehicleTypeDAO) {
            _vehicleTypeDAO = vehicleTypeDAO;
        }
        public async Task<Result<VehicleType>> GetById(int id)
        {
            VehicleType? vehicleTypeDb = await _vehicleTypeDAO.GetById(id);

            if (vehicleTypeDb is null)
            {
                return Result.Fail(new Error("Tipo de veículo não encontrado").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(vehicleTypeDb);
        }
        public async Task<Result<List<VehicleType>>> List(FilterVehicleType filter)
        {
            List<VehicleType>? lstVehicleTypeDb = await _vehicleTypeDAO.List(filter);

            if (lstVehicleTypeDb is null || lstVehicleTypeDb?.Count == 0)
            {
                return Result.Fail(new Error("Lista de Associação de Inspeções para Tipo Veículo não encontrado").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(lstVehicleTypeDb);
        }
    }
}
