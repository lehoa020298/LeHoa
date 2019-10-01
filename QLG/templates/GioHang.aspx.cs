using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace QLG.templates
{
    public partial class GioHang : System.Web.UI.Page
    {
        lopdungchung lopdungchung = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Request.Cookies["username"] == null) return;
            this.docDL();
        }
        private void docDL()
        {
            try
            {
                string username = Request.Cookies["username"].Value;
                string sql = "select ga.tenga, ga.mota, ga.gia, ga.maso, hoadon.soluong, ga.gia*hoadon.soluong as thanhtien from ga,hoadon where ga.maso=hoadon.maso and hoadon.username='"+username+"'";
                DataTable dt = new DataTable();
                dt = lopdungchung.loaddata(sql);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                //Tính tổng thành tiền: duyệt DataTable          
                double tong = 0;
                foreach (DataRow row in dt.Rows)
                {
                    double thanhtien = Convert.ToDouble(row["thanhtien"]);
                    tong = tong + thanhtien;
                }
                /*for (int i = 0; i < dt.Rows.Count; i++) {                 double thanhtien = double.Parse(dt.Rows[i]["thanhtien"]);                 tong = tong + thanhtien;             }*/
                this.Label1.Text = "Tổng thành tiền: " + tong + " đồng";
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null) return;
            string username = Request.Cookies["username"].Value;
            string maso = ((LinkButton)sender).CommandArgument;
            string sql = "delete from hoadon where maso ='" + maso + "' and username ='" + username + "'";
            //SqlConnection con = new SqlConnection(stcn); 
            try
            {
                lopdungchung.Mo();
                int kq = lopdungchung.ExecuteNonQuery(sql);
            }
            catch (SqlException err)
            {
                Response.Write(err.Message);
            }
            finally
            {
                lopdungchung.Dong();
            }
            this.docDL();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null) return;
            Button sua = (Button)sender;
            string maso = sua.CommandArgument;
            GridViewRow item = (GridViewRow)sua.Parent.Parent; string soluong = ((TextBox)item.FindControl("TextBox1")).Text;
            string username = Request.Cookies["username"].Value;
            //SqlConnection con = new SqlConnection(stcn);
            String sql = "update hoadon set soluong=" + soluong + " where username='" + username + "' and maso='" + maso + "'";
            try
            {
                lopdungchung.Mo();
                lopdungchung.ExecuteNonQuery(sql);
            }
            catch (SqlException err)
            {
                Response.Write(err.Message);
            }
            finally
            {
                lopdungchung.Dong();
            }
            this.docDL();
        }
    }
}