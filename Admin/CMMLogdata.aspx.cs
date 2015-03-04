using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class Admin_CMMLogdata : System.Web.UI.Page
{
    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
   
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {

            binding();

            SqlDataAdapter da = new SqlDataAdapter("select * from CMM_Loginusers", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlsearch.DataSource = ds;
            ddlsearch.DataValueField = "UserId";
            ddlsearch.DataTextField = "UserId";
            ddlsearch.DataBind();
            ddlsearch.Items.Insert(0, "Select UserId");
        
        }
    }
   
    protected void binding()
    {

        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Sitecount order by siteid desc", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        gridviewlogindetails.DataSource = ds;
        gridviewlogindetails.DataBind();
        ddlsearch.SelectedIndex = -1;
    }
    protected void gridviewlogindetails_pageindexchanging(object source, GridViewPageEventArgs e)
    {
        gridviewlogindetails.PageIndex = e.NewPageIndex;
        binding();
    }
    public class Item
    {
        public string CompenyId { get; set; }
        public string CompenyName { get; set; }
        public string Authority { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
    }
    protected void btnseach_Click(object sender, EventArgs e)
    {
        string searchid = ddlsearch.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Sitecount where Userid='"+searchid+"' order by siteid desc", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gridviewlogindetails.DataSource = ds;
            gridviewlogindetails.DataBind();
        }
        else
        {
            norec.Visible = true;
            gridviewlogindetails.Visible = false;
        }

    }
}