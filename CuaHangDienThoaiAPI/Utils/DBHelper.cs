using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CuaHangDienThoaiAPI.Utils
{
    public class DBHelper
    {
        public static DataTable Query(String consulta, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Common.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            SqlDataAdapter da;
            try
            {
                command.Connection = connection;
                command.CommandText = consulta;
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return dt;
        }

        public static int NonQuery(string query, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(Common.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                return command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}