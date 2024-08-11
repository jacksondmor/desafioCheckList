using desafioCheckList.Core.Core;

namespace desafioCheckList.DAO.DAO
{
    public interface IVehicleTypeDAO
    {
        Task<VehicleType> GetById(int id);
    }
}
