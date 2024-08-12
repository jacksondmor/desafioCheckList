using desafioCheckList.Core;
using static desafioCheckList.Core.VehicleType;

namespace desafioCheckList.DAO
{
    public interface IVehicleTypeDAO
    {
        Task<VehicleType> GetById(int id);
        Task<List<VehicleType>?> List(FilterVehicleType filter);
    }
}
