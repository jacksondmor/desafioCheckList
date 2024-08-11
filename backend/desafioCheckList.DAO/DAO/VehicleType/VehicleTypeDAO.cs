using Dapper;
using desafioCheckList.Core.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;

namespace desafioCheckList.DAO.DAO.DAO
{
    public class VehicleTypeDAO : IVehicleTypeDAO
    {
        private readonly SqlConnection _connDbDesafioCheckList;

        public VehicleTypeDAO(IDbConnectionFactory dbConnectionFactory)
        {
            _connDbDesafioCheckList = dbConnectionFactory.GetConnDbDesafioCheckList();
        }

        public async Task<VehicleType?> GetById(int id)
        {
            return (await _connDbDesafioCheckList.QueryAsync<VehicleType>(@"
			SELECT
			    Id,
				Code,
				Description
			FROM 
                dbo.VehicleType
			WHERE
				Id = @Id", new { Id = id }))
            .FirstOrDefault();
        }
    }
}
