using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace QLG
{
    public class lopdungchung
    {
        SqlConnection conn;
        public lopdungchung()
        {
            conn=new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thang\Source\Repos\qlg\QLG\App_Data\qlg.mdf;Integrated Security=True";
        }
        public void Mo()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        public void Dong()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
        public int ExecuteNonQuery(String sql)
        {
            Mo();
            SqlCommand cmd = new SqlCommand(sql,conn);
            int kq = cmd.ExecuteNonQuery();
            return kq;
        }
        public DataTable loaddata(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
    }
}