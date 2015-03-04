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
using System.Data.SqlClient;


public partial class UserControl_searchusercontrol : System.Web.UI.UserControl
{
    string s;
    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator order by Changeid desc", Connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            ddlid.DataSource = ds1;
            ddlid.DataTextField = "Changeid";
            ddlid.DataValueField = "Changeid";
            ddlid.DataBind();
            // Label1.Text = ddlid.SelectedValue;
            ddlid.Items.Insert(0, "Select");





            //string home = Convert.ToString(Session["home"]);
            //if (home == "")
            //{
            //    //tbl.Visible = false;
            //}
            //string s = Convert.ToString(Session["username"]);
            //if (s == "Reviewer")
            //{
            //    lblname.Text = "Reviewer Type";
            //}
            //else if (s == "CFT")
            //{
            //    lblname.Text = "CFT Type";
            //}
            //else if (s == "RA/CG")
            //{
            //    lblname.Text = "RA/CG Type";
            //}
            //else if (s == "Approver")
            //{
            //    lblname.Text = "Approver Type";
            //}
        }

    }
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddlvalue = DropDownList1.SelectedItem.Text;
    //    if (ddlvalue == "Approval")
    //    {
    //        pnl1.Visible = true;
    //        pnl2.Visible = false;
    //        GridView1.Visible = false;
    //    }
    //    else
    //    {
    //        pnl1.Visible = false;
    //        pnl2.Visible = true;
    //        GridView1.Visible = false;
    //    }
    //}
   
    //protected void Button2_Click(object sender, EventArgs e)
    //{
       

    //    string username = Convert.ToString(Session["username"]);
    //    int userroleid = Convert.ToInt32(Session["userroleid"]);
    //    string changeid = ddlid.SelectedItem.Text.ToString();

    //    SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator where Changeid='" + changeid + "'", Connection);
    //    DataSet ds1 = new DataSet();
    //    da1.Fill(ds1);
    //    gvinitiate.DataSource = ds1;
    //    gvinitiate.DataBind();
    //    gvinitiate.Visible = true;

    //    if (userroleid == 9)
    //    {

    //        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_CFT where changeid='" + changeid + "'", Connection);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {

    //            pnl111.Visible = true;
    //            userbody.Visible = true;

    //            lbltext.Text = changeid;
    //            txtcomment.SelectedItem.Text = ds.Tables[0].Rows[0]["Department"].ToString();
    //            TextBox1.Text = ds.Tables[0].Rows[0]["ImpactAnalysis"].ToString(); ;
    //            ddlitems.SelectedItem.Text = ds.Tables[0].Rows[0]["cfdcode"].ToString();
    //            DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["Executor"].ToString();
    //            DropDownList2.SelectedItem.Text = ds.Tables[0].Rows[0]["Reviewer"].ToString();
    //            txtdate.Text = ds.Tables[0].Rows[0]["TargetDate"].ToString();
    //            if (ddlitems.SelectedItem.Text == "Yes")
    //            {
    //                //pnl1.Visible = true;
    //                pnl111.Visible = true;
    //                userbody.Visible = true;
    //                pnl1.Visible = true;
    //            }
    //            else
    //            {
    //                pnl111.Visible = true;
    //                userbody.Visible = true;
    //                pnl1.Visible = false;
    //                //pnl1.Visible = true;
    //            }

    //            //ddl1.SelectedItem.Text = ds.Tables[0].Rows[0]["typechange"].ToString();          

    //        }
    //        else
    //        {
    //            pnl111.Visible = false;
    //            userbody.Visible = false;

    //            string strScript = "alert('CFT not perform any action to this '" + changeid + "' record');";
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
    //        }

    //    }


















    //    if (username == "Reviewer")
    //    {
    //        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=0 and Curstatus=1 and (submit='Reviewer1' or submit='Reviewer3')", connection);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            GridView1.DataSource = ds;
    //            GridView1.DataBind();
    //            Label1.Visible = false;
    //            GridView1.Visible = true;
    //        }
    //        else
    //        {
    //            Label1.Visible = true;

    //        }
    //    }
    //    else if (username == "CFT")
    //    {

    //        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=1  and Curstatus=2 and (submit='Reviewer1' or submit='Reviewer3')", connection);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            GridView1.DataSource = ds;
    //            GridView1.DataBind();
    //            Label1.Visible = false;
    //            GridView1.Visible = true;
    //        }
    //        else
    //        {
    //            Label1.Visible = true;

    //        }

    //    }
    //    else if (username == "RA/CG")
    //    {
    //        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=1  and Curstatus=3 and (submit='Reviewer1' or submit='Reviewer3')", connection);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            GridView1.DataSource = ds;
    //            GridView1.DataBind();
    //            Label1.Visible = false;
    //            GridView1.Visible = true;
    //        }
    //        else
    //        {
    //            Label1.Visible = true;

    //        }

    //    }
    //    else if (username == "Approver")
    //    {
    //        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where status=1  and Curstatus=4 and (submit='Reviewer1' or submit='Reviewer3')", connection);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            GridView1.DataSource = ds;
    //            GridView1.DataBind();
    //            Label1.Visible = false;
    //            GridView1.Visible = true;
    //        }
    //        else
    //        {
    //            Label1.Visible = true;

    //        }

    //    }
       
    //}
    //protected void Button1_Click1(object sender, EventArgs e)
    //{
        
    //     string username = Convert.ToString(Session["username"]);
    //     if (username == "Reviewer")
    //     {

    //         SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where submit='Reviewer2' and Curstatus=0", connection);
    //         DataSet ds = new DataSet();
    //         da.Fill(ds);
    //         if (ds.Tables[0].Rows.Count > 0)
    //         {
    //             GridView1.DataSource = ds;
    //             GridView1.DataBind();
    //             Label1.Visible = false;
    //             GridView1.Visible = true;
    //         }
    //         else
    //         {
    //             Label1.Visible = true;

    //         }
    //     }
    //     else if (username == "CFT")
    //     {
    //         SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where submit='Reviewer2' and Curstatus=2 ", connection);
    //         DataSet ds = new DataSet();
    //         da.Fill(ds);
    //         if (ds.Tables[0].Rows.Count > 0)
    //         {
    //             GridView1.DataSource = ds;
    //             GridView1.DataBind();
    //             Label1.Visible = false;
    //         }
    //         else
    //         {
    //             Label1.Visible = true;

    //         }
    //     }
    //     else if (username == "RA/CG")
    //     {
    //         SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where submit='Reviewer2' and Curstatus=3", connection);
    //         DataSet ds = new DataSet();
    //         da.Fill(ds);
    //         if (ds.Tables[0].Rows.Count > 0)
    //         {
    //             GridView1.DataSource = ds;
    //             GridView1.DataBind();
    //             Label1.Visible = false;
    //         }
    //         else
    //         {
    //             Label1.Visible = true;

    //         }
    //     }
    //     else if (username == "Approver")
    //     {
    //         SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where submit='Reviewer2' and Curstatus=4", connection);
    //         DataSet ds = new DataSet();
    //         da.Fill(ds);
    //         if (ds.Tables[0].Rows.Count > 0)
    //         {
    //             GridView1.DataSource = ds;
    //             GridView1.DataBind();
    //             Label1.Visible = false;
    //         }
    //         else
    //         {
    //             Label1.Visible = true;

    //         }
    //     }
    //}
    //protected void lnkeditrecord(object sender, EventArgs e)
    //{
    //    LinkButton btndel = sender as LinkButton;
    //    GridViewRow gvrow = btndel.NamingContainer as GridViewRow;
    //    string userid = Convert.ToString(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
    //    //Session["id1"] = userid;
    //    Label lblid = this.Parent.FindControl("lbltext") as Label;
    //    lblid.Text = userid;
    //    Session["id1"] = userid;
    //    Panel parentPanel = this.Parent.FindControl("pnl111") as Panel;
    //    parentPanel.Visible = true;

    //    try
    //    {
    //        SqlDataAdapter da = new SqlDataAdapter("select Changeid,cclassification from CMS_Initiator where Changeid='" + userid + "'", connection);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            DropDownList ddlapprover = this.Parent.FindControl("ddlitemsapprover") as DropDownList;

    //            ddlapprover.DataSource = ds;
    //            ddlapprover.DataTextField = "cclassification";
    //            ddlapprover.DataValueField = "Changeid";
    //            ddlapprover.DataBind();
    //            Panel pnlaprver = this.Parent.FindControl("pnl1apprver") as Panel;
    //            GridView gvapr = this.Parent.FindControl("gdaprver") as GridView;
    //            if (ds.Tables[0].Rows[0]["cclassification"].ToString() == "Quality Impactinng")
    //            {

    //                pnlaprver.Visible = true;
    //                gvapr.Visible = true;
    //            }
    //            else
    //            {
    //                pnlaprver.Visible = false;
    //                gvapr.Visible = false;

    //            }
    //        }
            
    //    }
    //    catch
    //    { }
    //}

    protected void Button2_Click(object sender, EventArgs e)
    {
       // Session["cmid"] = ddlid.SelectedItem.Text.ToString();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}