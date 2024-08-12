using Dapper;
using desafioCheckList.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;
using static desafioCheckList.Core.User;

namespace desafioCheckList.DAO
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
                dbo." + "\u0022" + "User" + "\u0022" + @"
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
                dbo." + "\u0022" + "User" + "\u0022" + @"
            WHERE
				(@Login IS NULL OR Login = @Login)
			ORDER BY Id DESC", filter))
            .ToList();
        }
    }
}
