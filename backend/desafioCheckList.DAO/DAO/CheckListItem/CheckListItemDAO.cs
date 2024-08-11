using Dapper;
using desafioCheckList.Core.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;

namespace desafioCheckList.DAO.DAO
{
    public class CheckListItemDAO : ICheckListItemDAO
    {
        private readonly SqlConnection _connDbDesafioCheckList;

        public CheckListItemDAO(IDbConnectionFactory dbConnectionFactory)
        {
            _connDbDesafioCheckList = dbConnectionFactory.GetConnDbDesafioCheckList();
        }

        public async Task<CheckListItem?> Insert(CheckListItem item)
        {
            item.Id = (await _connDbDesafioCheckList.QueryAsync<int>(@"
			INSERT INTO dbo.CheckListItem (
				IdCheckList,
				IdVehicle_InspectionList,
				Status, 
                Observation,
                DateCreated,
                DateUpdated
			)
			VALUES
			(
				@IdCheckList,
				@IdVehicle_InspectionList,
				@Status, 
                @Observation,
                @DateCreated,
                @DateUpdated
			); SELECT SCOPE_IDENTITY();", item))
            .FirstOrDefault();

            return item;
        }

        public async Task<CheckListItem?> Update(CheckListItem item)
        {
            await _connDbDesafioCheckList.ExecuteAsync(@"
            UPDATE 
                dbo.CheckListItem
            SET 
			    Status = @Status,
			    Observation = @Observation, 
                DateUpdated = getDate()
            WHERE
	            Id = @Id", item);

            return item;
        }

        public async Task<CheckListItem?> GetById(int id)
        {
            return (await _connDbDesafioCheckList.QueryAsync<CheckListItem>(@"
			SELECT
                Id,
                IdCheckList,
				IdVehicle_InspectionList,
				Status, 
                Observation,
                DateCreated,
                DateUpdated
			FROM 
                dbo.CheckListItem
			WHERE
				Id = @Id", new { Id = id }))
            .FirstOrDefault();
        }
    }
}
