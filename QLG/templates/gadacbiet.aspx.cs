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
    public partial class WebForm2 : System.Web.UI.Page
    {
        lopdungchung lopdungchung = new lopdungchung();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            string q;
            if (Context.Items["ml"] == null)
                q = "select * from ga";
            else
            {
                string maloai = Context.Items["ml"].ToString();
                q = "select * from ga where maloai='" + maloai + "'";

            }

            try
            {
                
                this.DataList.DataSource = lopdungchung.loaddata(q);
                this.DataList.DataBind();
                
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void DataList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string maso = ((ImageButton)sender).CommandArgument;
            Context.Items["ms"] = maso; 
            Server.Transfer("ChiTietGa.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string maso = ((LinkButton)sender).CommandArgument;
            Context.Items["ms"] = maso;
            Server.Transfer("ChiTietGa.aspx");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string maso = ((LinkButton)sender).CommandArgument;
            Context.Items["ms"] = maso;
            Server.Transfer("ChiTietGa.aspx");
        }
    }
}