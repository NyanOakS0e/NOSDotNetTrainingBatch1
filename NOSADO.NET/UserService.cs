using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NOSADO.NET
{
    internal class UserService
    {
        // "_" htae pay ya tal because global variable ma loh
        private readonly SqlConnectionStringBuilder _connectionBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "NOSDotNetTrainingBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };






        public void ReadDetail(string id)
        {
            SqlConnection connection = new SqlConnection(_connectionBuilder.ConnectionString);

            connection.Open();

            string query = $"SELECT * FROM dbo.Users WHERE id = {id}";

            SqlCommand command = new SqlCommand(query, connection);

            //command.Parameters.AddWithValue("@id", id);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"ID: {row["id"]}, Name: {row["Name"]}, Email: {row["email"]}");
            }

        }
        public void ReadAll()
        {

            SqlConnection connection = new SqlConnection(_connectionBuilder.ConnectionString);
            connection.Open();

            string query = "SELECT * FROM dbo.Users";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"ID: {row["id"]}, Name: {row["Name"]}, Email: {row["email"]}");
            }
        }
    }
}
