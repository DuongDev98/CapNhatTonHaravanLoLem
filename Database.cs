using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapNhatTonLoLem
{
    public class Database
    {
        public Database(string server, string username, string password, string database)
        {
            this.server = server;
            this.username = username;
            this.password = password;
            this.database = database;
        }
        public string server { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string database { set; get; }

        public DataTable GetTable(string query, IEnumerable<SqlParameter> sqlParameters, out string error)
        {
            error = "";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(string.Format(@"Server={0};Database={1};User Id={2};Password={3};", server, database, username, password));
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (sqlParameters != null)
                {
                    foreach (SqlParameter p in sqlParameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dt;
        }
    }
}
