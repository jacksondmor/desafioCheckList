﻿using Dapper;
using desafioCheckList.Core;
using desafioCheckList.DAO.Data;
using System.Data.SqlClient;
using static desafioCheckList.Core.VehicleType;

namespace desafioCheckList.DAO
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
        public async Task<List<VehicleType>?> List(FilterVehicleType filter)
        {
            return (await _connDbDesafioCheckList.QueryAsync<VehicleType>(@"
			SELECT
			    Id,
				Code,
				Description
			FROM 
                dbo.VehicleType
			WHERE
				(@Code IS NULL OR Code = @Code)
			ORDER BY Id DESC", filter))
            .ToList();
        }
    }
}
