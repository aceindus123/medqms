using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.SqlClient;

public partial class UserControl_assignments : System.Web.UI.UserControl
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        string ab = Convert.ToString(Request.QueryString["parameter"]);
        if (ab == "reviewer1")
        {
            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=0 and submit='Reviewer1' ", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvar.DataSource = ds;
                gvar.DataBind();

                gvar.Visible = true;
            }

        }
        else if (ab == "reviewer2")
        {
            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=0 and submit='Reviewer2' ", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvar.DataSource = ds;
                gvar.DataBind();

                gvar.Visible = true;
            }

        }
        else if (ab == "reviewer3")
        {
            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=0 and submit='Reviewer3'", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvar.DataSource = ds;
                gvar.DataBind();

                gvar.Visible = true;
            }

        }
        else
        {
            gvar.Visible = false;
        }
    }
}