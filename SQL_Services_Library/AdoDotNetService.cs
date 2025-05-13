using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;

namespace SQL_Services_Shared
{
    public class AdoDotNetService
    {

        private readonly SqlConnectionStringBuilder _stringBuilder;

        public AdoDotNetService(SqlConnectionStringBuilder connectionStringBuilder)
        { 
            _stringBuilder = connectionStringBuilder;
        }

        public DataTable Query(string query, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters.ToArray());

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }

        public DataTable Query(string query, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }



        public int Execute(string query, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result;
        }


        public List<T> QueryV2 <T>(string query, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            connection.Close();

            string jsonDt = JsonConvert.SerializeObject(dt);
            List<T> convertedList = JsonConvert.DeserializeObject<List<T>>(jsonDt)!;

            return convertedList;
        }

    }


}
