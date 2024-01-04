using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace MyApp.Data
{
    public class DataContextDapper(IConfiguration config)
    {

        // private IConfiguration  _config;
#pragma warning disable CS8601 // Possible null reference assignment.
        private string _connectionString = config.GetConnectionString("DefaultConnection");
#pragma warning restore CS8601 // Possible null reference assignment.

        public IEnumerable<T> LoadData<T>(string sql)
        {

            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);
        }
        public T LoadDataSingle<T>(string sql)
        {

            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return (dbConnection.Execute(sql) > 0);
        }


        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }
    }


}