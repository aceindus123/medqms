using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            email.Visible = false;
            Session.Abandon();
            getcount();
            lbldate.Text = DateTime.Now.ToString();
        }
    }
    protected void getcount()
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select count(*) as count from CMS_Sitecount", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        lblcount.Text = ds.Tables[0].Rows[0]["count"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       if ((ddltype.SelectedItem.Text == "Admin" || ddltype.SelectedItem.Text == "Web Admin") && DropDownList1.Text == "Admin" && txtpwd.Text == "Admin")  
        {
            tdmsg.InnerHtml = "";
            email.Visible = false;
         //   Session["test"] = DropDownList1.Text;
            Session["username"] = DropDownList1.Text;
            Response.Redirect("CMMHome.aspx");
        }
       else if ((ddltype.SelectedItem.Text == "Client" || ddltype.SelectedItem.Text == "User") && DropDownList1.Text == "Medqms" && txtpwd.Text == "Medqms" && txtemail.Text == "infocms@gmail.com")
       {
       //    Session["test"] = DropDownList1.Text;
           Session["username"] = DropDownList1.Text;
           Response.Redirect("CMMHome.aspx");
       }
        else
        {
            
            string strScript = "alert('Please Enter Correct UserId and Password');location.replace('Default.aspx');"; //string strScript = "alert('Please Enter Correct UserId and Password');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);

            //tdmsg.InnerHtml = "Please Enter Correct UserId and Password";
            //Response.Redirect("Default.aspx?ret=ok");
        }
    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedItem.Text == "Client" || ddltype.SelectedItem.Text == "User")
        {
            email.Visible = true;
        }
        else
        {
            email.Visible = false;
        }
    }
}
