using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CmsAuditTrail : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
         //  Response.Redirect("default.aspx");
            Response.RedirectToRoute("logincms");
        }
        if (!IsPostBack)
        {
            string uname = Convert.ToString(Session["uname"]);
            lbluname.Text = uname;
            //string ab = Convert.ToString(Request.QueryString["parameter"]);
            string ab = Convert.ToString(Page.RouteData.Values["parameter"]);
            string gid = Convert.ToString(Session["gvcid"]);
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            lbldate.Text = date;
            string time = DateTime.Now.ToString("hh:mm:ss");
            lbltime.Text = time;
            string umrolename = Convert.ToString(Session["umroles"]);
            con.Open();
           
                bindmethod();
           
                SqlDataAdapter adp = new SqlDataAdapter("select * from AuditHistory where Userid='" + uname + "'", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                con.Close();
                DdlchangeRid.DataSource = ds;
                DdlchangeRid.DataTextField = "Cid";
                DdlchangeRid.DataValueField = "Cid";
                DdlchangeRid.DataBind();
                DdlchangeRid.Items.Insert(0, "Select");
           
           
        }
    }
    protected void lnllogout(object sender, EventArgs e)
    {
       // Response.Redirect("default.aspx");
        Response.RedirectToRoute("logincms");
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        string chid = DdlchangeRid.SelectedItem.Text.ToString();
        lbchid.Text ="Change Request Id : "+ chid;
        lbchid.Visible = true;
        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select  Userid ,Role,Activity as 'Status Activity',Timestamp from AuditHistory where Cid='" + chid + "' order by Timestamp", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        con.Close();
        grdAuditTrail.DataSource = ds;
        grdAuditTrail.DataBind();
        grdAuditTrail.Visible = true;
        DdlchangeRid.SelectedIndex = 0;
    }
    protected void lnkHome_Click(object sender, EventArgs e)
    {
        //Response.Redirect("CMMHome.aspx");
        Response.RedirectToRoute("changemanagement");
    }
    protected void bindmethod()
    {
       // string id =Convert.ToString(Request.QueryString["parameter"]);
        string id = Convert.ToString(Page.RouteData.Values["parameter"]);
        lbchid.Text = "Change Request Id : " + id;
        lbchid.Visible = true;
        SqlDataAdapter adp = new SqlDataAdapter("select  Userid ,Role,Activity as 'Status Activity',Timestamp from AuditHistory where Cid='" + id + "' order by Timestamp", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdAuditTrail.DataSource = ds;
            grdAuditTrail.DataBind();
            grdAuditTrail.Visible = true;
        }
        else
        {
            //search.Visible = true;
            lbchid.Text = "no rercords founded";
            //SqlDataAdapter adp1 = new SqlDataAdapter("select * from AuditHistory where Userid='" + lbluname.Text + "'", con);
            //DataSet ds1 = new DataSet();
            //adp1.Fill(ds1);
            //con.Close();
            //DdlchangeRid.DataSource = ds1;
            //DdlchangeRid.DataTextField = "Cid";
            //DdlchangeRid.DataValueField = "Cid";
            //DdlchangeRid.DataBind();
            //DdlchangeRid.Items.Insert(0, "Select");
        }
     
    }
}