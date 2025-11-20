using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace StudentInfoSystem
{
    public static class DatabaseHelper
    {
        private static string connectionString =
            "Server=localhost;Database=student_db_new;Uid=newappuser;Pwd=NewPass789;Connection Timeout=30;Pooling=true;Max Pool Size=100;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Helper method to execute queries and return DataTable
        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        // Helper method to execute non-query commands (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}