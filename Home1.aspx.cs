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


public partial class Home : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    
    {
        //Session.Clear();
        //Session.Remove("home");
       
        string ab = Convert.ToString(Request.QueryString["parameter"]);
        if (ab == "newiniti")
        {
            trid.Visible = true;
            gvar.Visible = false;
        }
        else
        {
            trid.Visible = false;
            gvar.Visible = false;
        }

        if (ab == "reviewer1")
        {

            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select  * from CMS_Initiator where submit='Reviewer1' ", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string a =Convert.ToString(ds.Tables[0].Rows[0]["status"].ToString());
                gvar.DataSource = ds;
                gvar.DataBind();
                tridbar.Visible = false;
                tr1.Visible = true;
                tr2.Visible = false;
                tr3.Visible = false;
                gvar.Visible = true;
            }
          
        }
        else if (ab == "reviewer2")
        {
            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where  submit='Reviewer2' ", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvar.DataSource = ds;
                gvar.DataBind();
                tridbar.Visible = false;
                tr1.Visible = true;
                tr2.Visible = false;
                tr3.Visible = false;
                gvar.Visible = true;
            }

        }
        else if (ab == "reviewer3")
        {
            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where submit='Reviewer3'", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvar.DataSource = ds;
                gvar.DataBind();
                tridbar.Visible = false;
                tr1.Visible = true;
                tr2.Visible = false;
                tr3.Visible = false;
                gvar.Visible = true;
            }

        }
        else if (ab == "CFT")
        {
            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=2 and (submit='Reviewer1' or submit='Reviewer3')", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvar.DataSource = ds;
                gvar.DataBind();
                tridbar.Visible = false;
                tr1.Visible = true;
                tr2.Visible = false;
                tr3.Visible = false;
                gvar.Visible = true;
            }

        }
        else if (ab == "RA/CG")
        {
            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=3 and (submit='Reviewer1' or submit='Reviewer3')", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvar.DataSource = ds;
                gvar.DataBind();
                tridbar.Visible = false;
                tr1.Visible = true;
                tr2.Visible = false;
                tr3.Visible = false;
                gvar.Visible = true;
            }

        }
        else if (ab == "Approver")
        {
            gvar.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=4 and (submit='Reviewer1' or submit='Reviewer3')", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvar.DataSource = ds;
                gvar.DataBind();
                tridbar.Visible = false;
                tr1.Visible = true;
                tr2.Visible = false;
                tr3.Visible = false;
                gvar.Visible = true;
            }

        }
      
        else
        {
            gvar.Visible = false;
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewRowEventArgs e)
        {   //Get data row view
            DataRowView drview = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // int id = (int)gvar.DataKeys[e.RowIndex].Value;
                string lsDataKeyValue = gvar.DataKeys[e.Row.RowIndex].Values[0].ToString();
                SqlDataAdapter da1 = new SqlDataAdapter("select  * from CMS_Initiator where changeid='" + lsDataKeyValue + "'", connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Label dpEmpdept = (Label)e.Row.FindControl("lblstatusreg");
                string s = ds1.Tables[0].Rows[0]["status"].ToString();
                if (s == "2")
                    dpEmpdept.Text = "CFT Pending";
                if(s=="0")
                    dpEmpdept.Text = "Reviewer Pending";
                if (s == "3")
                    dpEmpdept.Text = "RA/CG Pending";
                if (s == "4")
                    dpEmpdept.Text = "Approver Pending";
                if (s == "5")
                    dpEmpdept.Text = "Approved ";

            }
               

            }
        }

    //{
    //    SqlDataAdapter da = new SqlDataAdapter("select  * from CMS_Initiator where (status=0 or status=2) and submit='Reviewer1')", connection);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        gvar.DataSource = ds;
    //        gvar.DataBind();
    //        string ab1 = "";
    //       string ab=Convert .ToString(ds.Tables[0].Rows[0]["status"].ToString());
    //       if (ab == "0")
    //       {
    //            ab1 = "Reviewer Pending";
    //          Label lbl = gvar.Rows[e.NewEditIndex].FindControl("lblstatusreg") as Label;
    //           lbl.Text = Convert.ToString(ab1);

              
    //       }
    //    }
       

//}
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
        Session["home"] = "home";
        string s = Convert.ToString(Session["username"]);

     
        if (s == "Admin")
        {
            Response.Redirect("Home.aspx");
        }
        else if (s == "Initiator")
        {
          
            Response.Redirect("CMS_Initiator.aspx");
        }
        else if (s == "Reviewer")
        {
            Response.Redirect("CMS_ChangeOwner.aspx");
        }
        else if (s == "Coordinator")
        {
            Response.Redirect("QAReg1.aspx");
        }
        else if (s == "CFT")
        {
            Response.Redirect("CMS_Final QA.aspx");
        }
        else if (s == "RA/CG")
        {
            Response.Redirect("CMS_racg.aspx");
        }
        else if (s == "Approver")
        {
            Response.Redirect("CMS_Cab Review.aspx");
        }
    }
    protected void imgini_click(object sender, ImageClickEventArgs e)
    {
        string a = "newInitiator";
        Response.Redirect("CMS_Initiator.aspx?parameter="+a);
    }


    protected void pnlEd_Click(object sender, EventArgs e)
    {

     
            //LinkButton id = (LinkButton) sender;
            //string iid = id.CommandArgument;
        string s = Session["username"].ToString();
        if((s=="Reviewer1")||(s=="Reviewer2")||(s=="Reviewer3"))
        {
            Response.Redirect("CMS_ChangeOwner.aspx");
        }
        else if ((s == "CFT"))
        {
            Response.Redirect("CMS_Final QA.aspx");
        }
        else if ((s == "RA/CG"))
        {
            Response.Redirect("CMS_racg.aspx");
        }
        else if ((s == "Approver"))
        {
            Response.Redirect("CMS_Cab Review.aspx");
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
   
}
