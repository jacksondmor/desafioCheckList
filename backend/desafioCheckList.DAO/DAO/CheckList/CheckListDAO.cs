using desafioCheckList.Core.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;
using Dapper;
using static desafioCheckList.Core.Core.CheckList;

namespace desafioCheckList.DAO.DAO
{
    public class CheckListDAO : ICheckListDAO
    {
        private readonly SqlConnection _connDbDesafioCheckList;

        public CheckListDAO(IDbConnectionFactory dbConnectionFactory)
        {
            _connDbDesafioCheckList = dbConnectionFactory.GetConnDbDesafioCheckList();
        }

        public async Task<CheckList?> Insert(CheckList item)
        {
            item.Id = (await _connDbDesafioCheckList.QueryAsync<int>(@"
			INSERT INTO dbo.CheckList (
				IIdUser,
                IdVehicleType,
                Plate,
                DriverName,
                Approver,
                Status,
                Approved,
                GeneralObservation,
                DateCreated,
                DateUpdated
			)
			VALUES
			(
				@IIdUser,
                @IdVehicleType,
                @Plate,
                @DriverName,
                @Approver,
                @Status,
                @Approved,
                @GeneralObservation,
                @DateCreated,
                @DateUpdated
			); SELECT SCOPE_IDENTITY();", item))
            .FirstOrDefault();

            return item;
        }

        public async Task<CheckList?> Update(CheckList item)
        {
            await _connDbDesafioCheckList.ExecuteAsync(@"
            UPDATE 
                dbo.CheckList
            SET 
			    Status = @Status,
			    Approved = @Approved, 
                DateUpdated = getDate()
            WHERE
	            Id = @Id", item);

            return item;
        }

        public async Task<bool> Delete(int id)
        {
            return (await _connDbDesafioCheckList.ExecuteAsync(@"
			DELETE FROM CheckList WHERE Id = @Id",
                new { Id = id })
            ) > 0;
        }

        public async Task<CheckList?> GetById(int id)
        {
            return (await _connDbDesafioCheckList.QueryAsync<CheckList>(@"
			SELECT
                Id,
                IdUser,
                IdVehicleType,
                Plate,
                DriverName,
                Approver,
                Status,
                Approved,
                GeneralObservation,
                DateCreated,
                DateUpdated
			FROM 
                dbo.CheckList
			WHERE
				Id = @Id", new { Id = id }))
            .FirstOrDefault();
        }
        public async Task<List<CheckList>?> List(FilterCheckList filter)
        {
            return (await _connDbDesafioCheckList.QueryAsync<CheckList>(@"
			SELECT
                Id,
                IdUser,
                IdVehicleType,
                Plate,
                DriverName,
                Approver,
                Status,
                Approved,
                GeneralObservation,
                DateCreated,
                DateUpdated
			FROM 
                dbo.CheckList
			WHERE
				(@IdUser IS NULL OR IdUser = @IdUser) AND
                (@IdVehicleType IS NULL OR IdVehicleType = @IdVehicleType) AND
                (@Plate IS NULL OR Plate = @Plate) AND
                (@Approver IS NULL OR Approver = @Approver) AND
                (@Status IS NULL OR Status = @Status) AND
                (@Approved IS NULL OR Approved = @Approved)
			ORDER BY Id DESC", filter))
            .ToList();
        }
    }
}
