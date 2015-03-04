using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_UserControl_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string path = Path.GetFileName(Request.PhysicalPath);

            switch (path)
            {
                case "CMMClients.aspx": lnkclient.CssClass = "active";
                    break;
                case "CMMReports.aspx": lnkreport.CssClass = "active";
                    break;
                case "CMMLogdata.aspx": lnklog.CssClass = "active";
                    break;
                case "CMMUsers.aspx": lnkusers.CssClass = "active";
                    break;
                case "CMMSupport.aspx": lnksupport.CssClass = "active";
                    break;
                case "CMMContact.aspx": lnkcontact.CssClass = "active";
                    break;
                case "CMMFeedback.aspx": lnkfeedback.CssClass = "active";
                    break;
                case "CMMPermissions.aspx": lnkpermissions.CssClass = "active";
                    break;
                case "CMMProduct.aspx": lnkproduct.CssClass = "active";
                    break;
                

            }
        }

    }
    protected void lnkhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMHome.aspx");
    }
    protected void lnkclient_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMClients.aspx");
    }
    protected void lnkreport_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMReports.aspx");
    }
    protected void lnklog_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMLogdata.aspx");
    }
    protected void lnkusers_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMUsers.aspx");
    }
    protected void lnksupport_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMSupport.aspx");
    }
    protected void lnkcontact_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMContact.aspx");
    }
    protected void lnkfeedback_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMFeedback.aspx");
    }
    protected void lnkpermissions_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMPermissions.aspx");
    }
    protected void lnkproduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMMProduct.aspx");
    }
}