using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace SQL_Services_Shared
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder _stringBuilder;
        public DapperService(SqlConnectionStringBuilder connectionStringBuilder)
        {
            _stringBuilder = connectionStringBuilder;
        }


        public List<T> Query<T>(string query, object? parameter = null)
        {
            IDbConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
          
            connection.Open();


            var lst = connection.Query<T>(query, parameter).ToList();

            return lst;
        }

        public int Execute(string query, object parameter)
        {
            IDbConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();

            var data = connection.Execute(query, parameter);

            return data;
        }
    }
}
