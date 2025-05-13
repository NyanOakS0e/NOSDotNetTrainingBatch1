using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace NOSDotNetTrainingBatch1.ConsoleApp
{
    internal class DapperService
    {
        private readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "NOSDotNetTrainingBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };


        public List<T> Query <T>(string query, object? parameter = null)
        {
            IDbConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();


            var lst = connection.Query<T>(query, parameter).ToList();

            return lst;
        }

        public int Execute(string query,object parameter)
        {
            IDbConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();

            var data = connection.Execute(query, parameter);

            return data;
        }
    }
}
