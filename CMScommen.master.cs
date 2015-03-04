
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CMScommen : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string s = System.IO.Path.GetFileName(Request.UrlReferrer.ToString());
            if ((s == "Default.aspx") || (s == "default.aspx")||(s==""))
            {
                string ss = Session["test"].ToString();
                switch (Session["test"].ToString())
                {
                    case "Initiator": initiator1.Attributes.Add("class", "active");
                        break;
                    case "Reviewer1": reviewer1.Attributes.Add("class", "active");
                        break;
                    case "Reviewer2": reviewer1.Attributes.Add("class", "active");
                        break;
                    case "Reviewer3": reviewer1.Attributes.Add("class", "active");
                        break;
                    case "Coordinator": coordinator1.Attributes.Add("class", "active");
                        break;

                    case "CFT": cft1.Attributes.Add("class", "active");
                        break;

                    case "RA/CG": racg1.Attributes.Add("class", "active");
                        break;

                    case "Approver": approver1.Attributes.Add("class", "active");
                        break;

                    case "Admin": home1.Attributes.Add("class", "active");
                        break;


                }

            }
        }
        catch
        { }
        //if (!IsPostBack)
        //{
        //    home.Attributes.Add("bgcolor", "#97B756");
        //}
    }
    //protected void lnkCls_Click(object sender, EventArgs e)
    //{
    //    rev.Attributes.Add("bgcolor", "#97B756");
    //    ini.Attributes["bgcolor"] = "transparent";
    //    cor.Attributes["bgcolor"] = "transparent";
    //    cet.Attributes["bgcolor"] = "transparent";
    //    app.Attributes["bgcolor"] = "transparent";
    //    ra.Attributes["bgcolor"] = "transparent";
    //    home.Attributes["bgcolor"] = "transparent";
    //    Response.Redirect("CMS_ChangeOwner.aspx");
       

       
    //}
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    cor.Attributes.Add("bgcolor", "#97B756");
    //    cet.Attributes["bgcolor"] = "transparent";
    //    app.Attributes["bgcolor"] = "transparent";
    //    ra.Attributes["bgcolor"] = "transparent";
    //    rev.Attributes["bgcolor"] = "transparent";
    //    ini.Attributes["bgcolor"] = "transparent";
    //    home.Attributes["bgcolor"] = "transparent";
    //    Response.Redirect("QAReg1.aspx");
    //}
   
    //protected void LinkButton2_Click(object sender, EventArgs e)
    //{
    //    cet.Attributes.Add("bgcolor", "#97B756");
    //    app.Attributes["bgcolor"] = "transparent";
    //    ra.Attributes["bgcolor"] = "transparent";
    //    rev.Attributes["bgcolor"] = "transparent";
    //    ini.Attributes["bgcolor"] = "transparent";
    //    cor.Attributes["bgcolor"] = "transparent";
    //    home.Attributes["bgcolor"] = "transparent";
    //    Response.Redirect("CMS_Final QA.aspx");
    //}
    //protected void lnkYP_Click(object sender, EventArgs e)
    //{
    //    ra.Attributes.Add("bgcolor", "#97B756");
    //    rev.Attributes["bgcolor"] = "transparent";
    //    ini.Attributes["bgcolor"] = "transparent";
    //    cor.Attributes["bgcolor"] = "transparent";
    //    cet.Attributes["bgcolor"] = "transparent";
    //    app.Attributes["bgcolor"] = "transparent";
    //    home.Attributes["bgcolor"] = "transparent";
    //    Response.Redirect("CMS_Regreview.aspx");
    //}
    //protected void LinkButton3_Click(object sender, EventArgs e)
    //{
    //    app.Attributes.Add("bgcolor", "#97B756");
    //    ra.Attributes["bgcolor"] = "transparent";
    //    rev.Attributes["bgcolor"] = "transparent";
    //    ini.Attributes["bgcolor"] = "transparent";
    //    cor.Attributes["bgcolor"] = "transparent";
    //    cet.Attributes["bgcolor"] = "transparent";
    //    home.Attributes["bgcolor"] = "transparent";
    //    Response.Redirect("CMS_Cab Review.aspx");
    //}
    //protected void lnkbtnHome_Click1(object sender, EventArgs e)
    //{
    //    ini.Attributes.Add("bgcolor", "#97B756");
    //    cor.Attributes["bgcolor"] = "transparent";
    //    cet.Attributes["bgcolor"] = "transparent";
    //    app.Attributes["bgcolor"] = "transparent";
    //    ra.Attributes["bgcolor"] = "transparent";
    //    rev.Attributes["bgcolor"] = "transparent";
    //    home.Attributes["bgcolor"] = "transparent";
    //    Response.Redirect("CMS_Initiator.aspx");
    //}
    //protected void LinkButton4_Click(object sender, EventArgs e)
    //{
    //    home.Attributes.Add("bgcolor", "#97B756");
    //    cor.Attributes["bgcolor"] = "transparent";
    //    cet.Attributes["bgcolor"] = "transparent";
    //    app.Attributes["bgcolor"] = "transparent";
    //    ra.Attributes["bgcolor"] = "transparent";
    //    rev.Attributes["bgcolor"] = "transparent";
    //    ini.Attributes["bgcolor"] = "transparent";
    //    Response.Redirect("Default.aspx");
    //}
}
