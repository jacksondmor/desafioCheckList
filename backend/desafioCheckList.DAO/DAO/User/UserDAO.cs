using Dapper;
using desafioCheckList.Core.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;
using static desafioCheckList.Core.Core.User;

namespace desafioCheckList.DAO.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly SqlConnection _connDbDesafioCheckList;

        public UserDAO(IDbConnectionFactory dbConnectionFactory)
        {
            _connDbDesafioCheckList = dbConnectionFactory.GetConnDbDesafioCheckList();
        }
        public async Task<User?> GetById(int id)
        {
            return (await _connDbDesafioCheckList.QueryAsync<User>(@"
			SELECT
		        Id,
                Name,
                Login,
                Password,
                DateCreated,
                DateUpdated
			FROM 
                dbo.User
			WHERE
				Id = @Id", new { Id = id }))
            .FirstOrDefault();
        }
        public async Task<List<User>?> List(FilterUser filter)
        {
            return (await _connDbDesafioCheckList.QueryAsync<User>(@"
			SELECT
		        Id,
                Name,
                Login,
                Password,
                DateCreated,
                DateUpdated
			FROM 
                dbo.User
			WHERE
				(@Login IS NULL OR Login = @Login)
			ORDER BY Id DESC", filter))
            .ToList();
        }
    }
}
