using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cmm.DataAccessLayer;
using cmm.errorexcep;
public partial class cmm_capa : System.Web.UI.Page
{
    static string excep_page = "default.aspx";
    error err = new error();
    protected void Page_Load(object sender, EventArgs e)
    {
        string name1 = Convert.ToString(Session["uname"]);
        lbluname.Text = name1;
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;
    }
    protected void lnllogout(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx", false);
        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");

        }
    }
}