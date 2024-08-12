using desafioCheckList.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;
using Dapper;
using static desafioCheckList.Core.CheckList;

namespace desafioCheckList.DAO
{
    public class CheckListDAO : ICheckListDAO
    {
        private readonly SqlConnection _connDbDesafioCheckList;

        public CheckListDAO(IDbConnectionFactory dbConnectionFactory)
        {
            _connDbDesafioCheckList = dbConnectionFactory.GetConnDbDesafioCheckList();
        }

        public async Task<CheckList?> Insert(InsertCheckList insertItem)
        {
            CheckList? item = (await _connDbDesafioCheckList.QueryAsync<CheckList>(@"
			INSERT INTO dbo.CheckList (
				IdUser,
                IdVehicleType,
                Plate,
                DriverName,
                Approver,
                GeneralObservation
			)
			VALUES
			(
				@IdUser,
                @IdVehicleType,
                @Plate,
                @DriverName,
                @Approver,
                @GeneralObservation
			); SELECT
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
                FROM dbo.CheckList
                WHERE Id = SCOPE_IDENTITY();", insertItem))
            .FirstOrDefault();

            return item;
        }

        public async Task<UpdateCheckList?> Update(int id, UpdateCheckList item)
        {
            await _connDbDesafioCheckList.ExecuteAsync(@"
            UPDATE 
                dbo.CheckList
            SET 
			    Status = @Status,
			    Approved = @Approved, 
                DateUpdated = getDate()
            WHERE
	            Id = @Id", new { Status = item.Status, Approved = item.Approved, Id = id }) ;

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
