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
    public partial class ChiTietGa : System.Web.UI.Page
    {
        lopdungchung lopdungchung = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            if (Request.Cookies["username"] == null)
            {
                this.Label5.Text = "Ban phai dang nhap de xem ga!";
                return;
            }
            if (Context.Items["ms"] == null)
                return;
            string maso = Context.Items["ms"].ToString();
            string q = "select * from ga where maso='" + maso + "'";
            try
            {
                this.DataList.DataSource = lopdungchung.loaddata(q);
                this.DataList.DataBind();
            }
            catch(SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void DataList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Button mua = (Button)sender;
            //string maso = "01";
            string maso = ((Button)sender).CommandArgument.ToString();
            Context.Items["maso"] = maso;
            //DataListItem item = (DataListItem)mua.Parent;
            if (Request.Cookies["username"] == null) return;
            string username = Request.Cookies["username"].Value;
            lopdungchung.Mo();
           
            string sql = "select * from hoadon where username='"+username+"' and maso='"+maso+"'";
            DataTable dt = new DataTable();
            try
            {
                dt = lopdungchung.loaddata(sql);
            }

            catch (SqlException ex)
            {
                Response.Write("<b>ERROR</b>" + ex.Message + "<p/>");
            }
            if (dt.Rows.Count!=0)
            {
                string sql1 = "update hoadon set soluong=soluong+1 where username='"+username+"' and maso='"+maso+"'";
                int ketqua = lopdungchung.ExecuteNonQuery(sql1);
            }
            else
            {
                string sql2 = "insert into hoadon values ('" + username + "', '" + maso + "', 1)";
                int kq2 = lopdungchung.ExecuteNonQuery(sql2);
            }
            lopdungchung.Dong();
        }

    }
}