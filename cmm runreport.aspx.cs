   using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class cmm_runreport : System.Web.UI.Page
{
 
     SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
           Response.Redirect("default.aspx");
        }
        if (!IsPostBack)
        {
            string uname = Convert.ToString(Session["uname"]);
            lbluname.Text = uname;
            string ab = Convert.ToString(Request.QueryString["parameter"]);
            string gid = Convert.ToString(Session["gvcid"]);
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            lbldate.Text = date;
            string time = DateTime.Now.ToString("hh:mm:ss");
            lbltime.Text = time;
            string umrolename = Convert.ToString(Session["umroles"]);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select distinct Cid from AuditHistory  order by Cid asc", con);
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
        Response.Redirect("default.aspx");
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        string chid = DdlchangeRid.SelectedItem.Text.ToString();
        lbchid.Text ="Change Request Id : "+ chid;
        lbchid.Visible = true;
        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select  Userid ,Role,Activity as 'Status Activity',Timestamp from AuditHistory where Cid='" + chid + "' order by id asc", con);
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
        Response.Redirect("CMMHome.aspx");
    }
}