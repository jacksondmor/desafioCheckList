using Dapper;
using desafioCheckList.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;
using static desafioCheckList.Core.InspectionList;

namespace desafioCheckList.DAO
{
    public class InspectionListDAO : IInspectionListDAO
    {
        private readonly SqlConnection _connDbDesafioCheckList;

        public InspectionListDAO(IDbConnectionFactory dbConnectionFactory)
        {
            _connDbDesafioCheckList = dbConnectionFactory.GetConnDbDesafioCheckList();
        }

        public async Task<InspectionList?> GetById(int id)
        {
            return (await _connDbDesafioCheckList.QueryAsync<InspectionList>(@"
			SELECT
			    Id,
				Code,
				Description
			FROM 
                dbo.InspectionList
			WHERE
				Id = @Id", new { Id = id }))
            .FirstOrDefault();
        }
        public async Task<List<InspectionList>?> List(FilterInspectionList filter)
        {
            return (await _connDbDesafioCheckList.QueryAsync<InspectionList>(@"
			SELECT
			    Id,
				Code,
				Description
			FROM 
                dbo.InspectionList
			WHERE
				(@Code IS NULL OR Code = @Code)
			ORDER BY Id DESC", filter))
            .ToList();
        }
    }
}
