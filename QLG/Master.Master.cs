using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace QLG
{
    public partial class Master : System.Web.UI.MasterPage
    {
        lopdungchung lopdungchung = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            try
            {
                string sql = "select * from loaiga";
                this.DataList1.DataSource = lopdungchung.loaddata(sql);
                this.DataList1.DataBind();
            }
            catch(SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string ten = this.Login1.UserName;
            string matkhau = this.Login1.Password;
            string sql = "select * from [user] where username='"+ten+"' and pass='"+matkhau+"'";
            DataTable t = new DataTable();
            try
            {
                t = lopdungchung.loaddata(sql);
            }

            catch(SqlException ex)
            {
                Response.Write("<b>ERROR</b>" + ex.Message + "<p/>");
            }

            if (t.Rows.Count != 0)
            {
                Response.Cookies["username"].Value = ten;
                Server.Transfer("gadacbiet.aspx");

            }

            else this.Login1.FailureText = "Ten dang nhap hoac mat khau khong dung!";
        }

        protected void DataList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string maloai = ((LinkButton)sender).CommandArgument;
            Context.Items["ml"] = maloai;
            Server.Transfer("gadacbiet.aspx");
        }
    }
}