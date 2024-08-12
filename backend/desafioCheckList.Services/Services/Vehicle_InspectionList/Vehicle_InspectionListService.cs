using desafioCheckList.Core.Core;
using desafioCheckList.DAO.DAO;
using FluentResults;
using static desafioCheckList.Core.Core.Vehicle_InspectionList;

namespace desafioCheckList.Services.Services
{   
    public class Vehicle_InspectionListService : IVehicle_InspectionListService
    {
        private readonly IVehicle_InspectionListDAO _vehicle_InspectionListDAO;
        public Vehicle_InspectionListService(IVehicle_InspectionListDAO vehicle_InspectionListDAO) {
            _vehicle_InspectionListDAO = vehicle_InspectionListDAO;
        }
        public async Task<Result<Vehicle_InspectionList>> GetById(int id)
        {
            Vehicle_InspectionList? vehicle_InspectionListDb = await _vehicle_InspectionListDAO.GetById(id);

            if (vehicle_InspectionListDb is null)
            {
                return Result.Fail(new Error("Associação de Inspeções para Tipo Veículo não encontrado").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(vehicle_InspectionListDb);
        }
        public async Task<Result<List<Vehicle_InspectionList>>> List(FilterVehicle_InspectionList filter)
        {
            List<Vehicle_InspectionList>? lstVehicle_InspectionListDb = await _vehicle_InspectionListDAO.List(filter);

            if (lstVehicle_InspectionListDb is null || lstVehicle_InspectionListDb?.Count == 0)
            {
                return Result.Fail(new Error("Lista de Associação de Inspeções para Tipo Veículo não encontrado").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(lstVehicle_InspectionListDb);
        }
    }
}
