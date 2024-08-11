using desafioCheckList.Core.Core;
using static desafioCheckList.Core.Core.VehicleType;

namespace desafioCheckList.DAO.DAO
{
    public interface IVehicleTypeDAO
    {
        Task<VehicleType> GetById(int id);
        Task<List<VehicleType>?> List(FilterVehicleType filter);
    }
}
