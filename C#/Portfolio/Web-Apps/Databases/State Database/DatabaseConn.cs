/** 
 * ADITYA PATEL
 * CPT - 206
 * SQL CONNECTION
 * 
 * This class handles all database operations, including establishing connections,
 * executing SELECT queries to retrieve data, and executing INSERT/UPDATE queries
 * with parameters to modify data.
 * **/

using System;
using System.Data;
using System.Data.SqlClient;

namespace APatel_Lab__3
{
    public class DatabaseConn
    {
        private readonly string connectionString = @"Data Source=DESKTOP-1VJ4V0K;Initial Catalog=APatel_Lab_3;Integrated Security=True";


        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ExecuteSelectQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Establishing the connection
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Adapter to fetch data
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    conn.Open();

                    // Then filling the Datatable with qeury result
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                // An exception to catch database erros
                throw new Exception("Database error: " + ex.Message);
            }
            return dataTable;
        }

        public void ExecuteInsertUpdateQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();

                    // Executes the query (INSERT, UPDATE, DELETE)
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Operation Failed: " + ex.Message);
            }
        }
    }
}
