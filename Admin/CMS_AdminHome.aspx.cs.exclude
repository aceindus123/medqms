using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;

public partial class Admin_CMS_AdminHome : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string UserId;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToString(Session["username"]);
        if (UserId != "")
        {
            // it will stays in the same page
        }

        else
        {
            //After login into the account it will go Post ad
            Response.Redirect("Default.aspx");

        }
        if (!IsPostBack)
        {
            getcount();

            string av = GetIP();
            ipid.Text = av;
         
        }
    }
    protected void getcount()
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select count(*) as count from CMS_Sitecount", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        lblcount.Text = ds.Tables[0].Rows[0]["count"].ToString();
        //SqlDataAdapter da1 = new SqlDataAdapter("select ipaddress from CMS_Sitecount", con);
        //DataSet ds1 = new DataSet();
        //da1.Fill(ds1);
        //ipid.Text = ds1.Tables[0].Rows[0]["ipaddress"].ToString();
    }
    protected string GetIP()
    {
        IPAddress[] addr = new IPAddress[0];
        try
        {
            string strHostName = "";


            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            addr = ipEntry.AddressList;
        }
        catch
        { }
        return addr[addr.Length - 2].ToString();

    }
}