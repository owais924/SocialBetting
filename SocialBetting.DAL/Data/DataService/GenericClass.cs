using Dapper;
using Microsoft.Extensions.Configuration;
using SocialBetting.DAL.Services.IDataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.Services.DataService
{
    public class GenericClass : IGenericClass
    {
        private readonly IConfiguration _config;

        public GenericClass(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string SP,
            U parameters)
        {
            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("SocialBetting_Connection")))
            {
                if (con.State != ConnectionState.Open) con.Open();

                return await con.QueryAsync<T>(
                    SP, parameters, commandType: CommandType.StoredProcedure);
            }
        } 

        public async Task SaveData<T>(
            string SP,
            T parameters)
        {
            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("SocialBetting_Connection")))
            {
                if (con.State != ConnectionState.Open) con.Open();

                await con.ExecuteAsync(
                    SP, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
