using desafioCheckList.Core.Core;

namespace desafioCheckList.DAO.DAO
{
    public interface IVehicle_InspectionListDAO
    {
        Task<Vehicle_InspectionList> GetById(int id);
    }
}
