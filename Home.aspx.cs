using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Home : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    int userroleid;
    string userrolename;
    string strScript;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["uname"] == null)
        {
            
            strScript = "alert('Session Closed.Please ReLogin into medqms');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
           // Response.Redirect("default.aspx");
            Response.RedirectToRoute("logincms");
        }
        string name1 = Convert.ToString(Session["uname"]);
        //lbluname.Text = name1;
        //string date = DateTime.Now.ToString("dd/MM/yyyy");
        //lbldate.Text = date;
        //string time = DateTime.Now.ToString("hh:mm:ss");
        //lbltime.Text = time;
        userroleid = Convert.ToInt32(Session["userroleid"]);
        SqlDataAdapter da1 = new SqlDataAdapter("select * from CMM_Roles where RoleId=" + userroleid + "", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            userrolename = Convert.ToString(ds1.Tables[0].Rows[0]["RoleDesc"]);
            Session["userrolename"] = userrolename;
            userrolename = Convert.ToString(ds1.Tables[0].Rows[0]["RoleDesc"]);
            //lnkstatus.Text = userrolename;
            string uname = Convert.ToString(Session["uname"]);
            String userRoles = "";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CMM_LoginUsers where UserId='" + uname + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "CMM_LoginUsers");

            foreach (DataRow dr in ds.Tables["CMM_LoginUsers"].Rows)
            {
                int Rolecode = Convert.ToInt32((dr["RoleCode"]));
                // int Dept = Convert.ToInt32(ds.Tables[0].Rows[0]["Department"]);
                SqlDataAdapter da2 = new SqlDataAdapter("select * from CMM_Roles  where RoleId='" + Rolecode + "'", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    userRoles += Convert.ToString(ds2.Tables[0].Rows[0]["RoleDesc"]) + "&";
                }

                //Console.WriteLine(dr["CustomerID"] + "\t" +dr["ContactName"]);
            }
            userRoles = userRoles.Remove(userRoles.Length - 1);
            lnkstatus.Text = userRoles;
            Session["umroles"] = userRoles;
            lnkstatus.Visible = true;
            //try
            //{
            //    string s = System.IO.Path.GetFileName(Request.UrlReferrer.ToString());
            //    if ((s == "Default.aspx") || (s == "default.aspx") || (s == ""))
            //    {
            //        string ss = Session["uname"].ToString();

            //    }
            //}
            //catch
            //{ }
        }
        else
        {
            Response.RedirectToRoute("logincms");
        }
    }
    protected void clickchangemgt(object sender, EventArgs e)
    { 
       // Response.Redirect("CMMHome.aspx");
        Response.RedirectToRoute("changemanagement");
    }
    //protected void clickuserstatus(object sender, EventArgs e)
    //{
    //    Response.Redirect("cmm userstatus.aspx");
    //}
    protected void clickinbox(object sender, EventArgs e)
    {
        Response.Redirect("mailto:sdamisetty_aceindus@yahoo.com?");

    } 
    protected void sopclick(object sender, EventArgs e)
    {

        //Response.Redirect("cmmsop.aspx");
        Response.RedirectToRoute("cmmsop");
    }
    protected void cmmfchart(object sender, EventArgs e)
    {

        //Response.Redirect("cmmflowchart.aspx");
        Response.RedirectToRoute("cmmflowchart");
    }
    protected void chpwdcmmclick(object sender, EventArgs e)
    {
        Response.RedirectToRoute("cmmchpwd");
      //  Response.Redirect("CMM ChangePwd.aspx");
       // Response.Redirect("cmmupdateprofile.aspx");
    }
    protected void cmmsettings(object sender, EventArgs e)
    {

        //Response.Redirect("cmmsettings.aspx");
        Response.RedirectToRoute("cmmsettings");
    }
    protected void clicknotify(object sender, EventArgs e)
    {
        Response.RedirectToRoute("cmmnotifications");
       // Response.Redirect("cmmqualitynotifications.aspx");
    }
    protected void clickcomplaints(object sender, EventArgs e)
    {
        Response.RedirectToRoute("cmmcomplaints");
       // Response.Redirect("cmm complaints.aspx");
    }
    protected void clickannualrev(object sender, EventArgs e)
    {
        Response.RedirectToRoute("cmmapreview");
        //Response.Redirect("cmm annual pdtreview.aspx");
    }
    protected void clickcapa(object sender, EventArgs e)
    {
        Response.RedirectToRoute("cmmcapa");
        //Response.Redirect("cmm capa.aspx");
    }

    
}