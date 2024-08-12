using Dapper;
using desafioCheckList.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;
using static desafioCheckList.Core.Vehicle_InspectionList;

namespace desafioCheckList.DAO
{
    public class Vehicle_InspectionListDAO : IVehicle_InspectionListDAO
    {
        private readonly SqlConnection _connDbDesafioCheckList;

        public Vehicle_InspectionListDAO(IDbConnectionFactory dbConnectionFactory)
        {
            _connDbDesafioCheckList = dbConnectionFactory.GetConnDbDesafioCheckList();
        }

        public async Task<Vehicle_InspectionList?> GetById(int id)
        {
            return (await _connDbDesafioCheckList.QueryAsync<Vehicle_InspectionList>(@"
			SELECT
		        Id,
                IdVehicleType,
                IdInspectionList,
                Parameter,
                DateCreated,
                DateUpdated,
                Actived
			FROM 
                dbo.Vehicle_InspectionList
			WHERE
				Id = @Id", new { Id = id }))
            .FirstOrDefault();
        }
        public async Task<List<Vehicle_InspectionList>?> List(FilterVehicle_InspectionList filter)
        {
            return (await _connDbDesafioCheckList.QueryAsync<Vehicle_InspectionList>(@"
			SELECT
		        Id,
                IdVehicleType,
                IdInspectionList,
                Parameter,
                DateCreated,
                DateUpdated,
                Actived
			FROM 
                dbo.Vehicle_InspectionList
			WHERE
				(@IdVehicleType IS NULL OR IdVehicleType = @IdVehicleType) AND
				(@IdInspectionList IS NULL OR IdInspectionList = @IdInspectionList)
			ORDER BY Id DESC", filter))
            .ToList();
        }
    }
}
