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
using System.Configuration;
using System.Data.SqlClient;


public partial class CMSMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {



        string thisURL = this.Page.GetType().Name.ToString();
        switch (thisURL)
        {
            //case "CMMHome.aspx":
            //    home1.Attributes.Add("class", "active");
            //    break;
            case "cms_initiator_aspx":
                initiator1.Attributes.Add("class", "active");
                break;
            //case "CMS_ChangeOwner.aspx":
            //    reviewer1.Attributes.Add("class", "active");
            //    break;
        }
        //////try
        //////{
        //// SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        //////string s = System.IO.Path.GetFileName(Request.UrlReferrer.ToString());
        //////if ((s == "Default.aspx") || (s == "default.aspx") || (s == "") )
        //////{
        //////    string ss = Session["uname"].ToString();

        //////    switch (Session["uname"].ToString())
        //////    {
        //////        case "Initiator1":
        //////        case "Initiator2":
        //////        case "Initiator3":
        //////        case "Initiator4":
        //////        case "Initiator5":
        //////        case "Initiator6":
        //////        case "user1":
        //////        case "PRIuser2":
        //////            initiator1.Attributes.Add("class", "active");
        //////            reviewer1.Attributes.Add("class", "deactive");
        //////            break;
        //////        case "reviewer":
        //////        case "Reviewer":
        //////        case "Reviewer1":
        //////        case "Reviewer2":
        //////        case "Reviewer3":
        //////            //case "Reviewer4":
        //////            reviewer1.Attributes.Add("class", "active");
        //////            initiator1.Attributes.Add("class", "deactive");
        //////            break;
        //////        //case "Reviewer2": reviewer1.Attributes.Add("class", "active");
        //////        //    break;
        //////        //case "Reviewer3": reviewer1.Attributes.Add("class", "active");
        //////        //    break;
        //////        case "Coordinator": coordinator1.Attributes.Add("class", "active");
        //////            break;

        //////        case "CFT": cft1.Attributes.Add("class", "active");
        //////            break;

        //////        case "RACG": racg1.Attributes.Add("class", "active");
        //////            break;

        //////        case "Approver": approver1.Attributes.Add("class", "active");
        //////            break;

        //////        case "Admin": home1.Attributes.Add("class", "active");
        //////            break;



        //////    }

      
    }
    protected string GetCat()
    {

        string a = "Initiator1";
        return Page.GetRouteUrl("initiator", new { cat = a });

    }
}
