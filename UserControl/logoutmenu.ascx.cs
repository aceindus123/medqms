using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_logoutmenu : System.Web.UI.UserControl
{
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
       // Response.Redirect("Default.aspx");
        Response.RedirectToRoute("logincms");
    }
}