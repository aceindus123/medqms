using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using cmm.errorexcep;

public partial class CMMHome : System.Web.UI.Page
{
    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string st;
    DataTable dt;
    string temp;
    int strevgd;
    public static string category;
    string act = string.Empty;
    int usernumber;
    string username;
    string b;
    string num;
    string roled;
    string ab;
    int userroleid;
    string userrolename;
    static string excep_page = "CMMHome.aspx";
    error err = new error();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
            string strScript = "alert('Session Closed.Please ReLogin into medqms');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
           // Response.Redirect("default.aspx");
            Response.RedirectToRoute("logincms");
        }
        string name1 = Convert.ToString(Session["uname"]);
        lbluname.Text = name1;

        string ab = Convert.ToString(Request.QueryString["parameter"]);
        string gid = Convert.ToString(Session["gvcid"]);

        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;

        userroleid = Convert.ToInt32(Session["userroleid"]);

        string umrolename = Convert.ToString(Session["umroles"]);

        if (!IsPostBack)
        {
            searchbind();
            category = "assignment";
            lblassign.CssClass = "active";
            lblitems.CssClass = "lnkcolor";
            DataSet ds = new DataSet();
            if ((userroleid == 1) || (umrolename == "Initiator&Reviewer"))
            {
                lnknew.Visible = true;
                initnew.Visible = true;
                assignbind();
            }
            else
            {
                norec.Visible = false;
                // lblitems.Visible = true;
                lnknew.Visible = false;
                initnew.Visible = false;
                assignbind();
            }
       
        }
      
           
      
    }
    private void searchbind()
    {

        DataSet ds = new DataSet();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from CMS_Initiator order by changeid asc", Connection);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlsearch.DataSource = ds;
                ddlsearch.DataTextField = "Changeid";
                ddlsearch.DataValueField = "Changeid";
                ddlsearch.DataBind();
                ddlsearch.Items.Insert(0, "Select");
            }
            else
            {
                ddlsearch.Items.Insert(0, "Select");
            }
        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }
    }
    protected void search_Click(object sender, EventArgs e)
    {
        try
        {

            temp = ddlsearch.SelectedItem.Text;

            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where Changeid='" + temp + "'", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvinitiate.Visible = true;
                gvinitiate.DataSource = ds;
                gvinitiate.DataBind();
            }
            else
            {
                ddlsearch.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }
    }
    protected void gvinitiate_pageindexchanging(object source, GridViewPageEventArgs e)
    {
        gvinitiate.PageIndex = e.NewPageIndex;
        if (category == "assignment")
        {
            assignbind();
        }
        else
            actionbinding();

    }
    protected void gvinitiate_RowEditing(object sender, GridViewRowEventArgs e)
    {   //Get data row view
        userroleid = Convert.ToInt32(Session["userroleid"]);
        userrolename = Convert.ToString(Session["userrolename"]);
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // int id = (int)gvar.DataKeys[e.RowIndex].Value;
            string lsDataKeyValue = gvinitiate.DataKeys[e.Row.RowIndex].Values[0].ToString();
            SqlDataAdapter da1 = new SqlDataAdapter("select  * from CMS_Initiator where changeid='" + lsDataKeyValue + "'", Connection);
            Session["changeid"] = lsDataKeyValue;
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);


           

            Label dpEmpdept = (Label)e.Row.FindControl("lblcstatus");
            Label dpAssign = (Label)e.Row.FindControl("lblsubmit");
            int s = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);
            int st = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
            int cftst = Convert.ToInt32(ds1.Tables[0].Rows[0]["cftstatus"]);
            if (ds1.Tables[0].Rows.Count > 0)
            {

                LinkButton lnkid = (LinkButton)e.Row.FindControl("lnkid");
              if (s == 1 && st == 1)
                {
                    dpEmpdept.Text = "assign to Reviewer";
                    dpAssign.Text = "Reviewer";
                }
                else if (s == 1 && st == 0)
                {
                    dpEmpdept.Text = "Initiator Reject";
                    dpAssign.Text = "Initiator";
                }
                else if (s == 1 && st == 2)
                {
                    dpEmpdept.Text = "Initiator pending";
                    dpAssign.Text = "Initiator";
                }
                else if (s == 3 && st == 0)
                {
                    dpEmpdept.Text = "Reviewer Reject";
                    dpAssign.Text = "Reviewer";
                }

                else if (s == 3 && st == 2)
                {
                    dpEmpdept.Text = "Initiator Pending";
                    dpAssign.Text = "Initiator";
                }

                else if (s == 3 && st == 1)
                {
                    dpEmpdept.Text = "assign to Coordinator";
                    dpAssign.Text = "Coordinator";
                }

                else if (s == 4 && st == 0)
                {
                    dpEmpdept.Text = "Coordinator Reject";
                    dpAssign.Text = "Coordinator";
                }

                else if (s == 4 && st == 2)
                {
                    dpEmpdept.Text = "Reviewer Pending";
                    dpAssign.Text = "Reviewer";
                }

                else if (s == 4 && st == 1)
              {
                  string ab = lbluname.Text;

                  if (cftst == 91 || cftst == 101)
                  {
                      if (ab != "RARev1" && ab != "RARev2")
                      {
                          dpEmpdept.Text = "pending";
                          dpAssign.Text = "CFT";

                      }

                      else if (ab == "RARev1" || ab == "RARev2")
                      {
                          dpEmpdept.Text = "pending";
                          dpAssign.Text = "RACG";
                      }
                  
                  }
                    else
                  {
                      SqlCommand cmd = new SqlCommand("select changeid into cftstatusreview from cms_cft where cftrevname='" + lbluname.Text + "' and revstatus=19", Connection);
                      Connection.Open();
                      cmd.ExecuteNonQuery();
                      Connection.Close();
                      SqlDataAdapter da = new SqlDataAdapter("SELECT changeid FROM cms_coordinator UNION SELECT changeid FROM cftstatusreview", Connection);
                      DataSet ds = new DataSet();
                      da.Fill(ds);
                      if (ds.Tables[0].Rows.Count > 0)
                      {

                          if (ab != "RARev1" && ab != "RARev2")
                          {
                              dpEmpdept.Text = "Assigned to CFT";
                              dpAssign.Text = "CFT";

                          }

                          else if (ab == "RARev1" || ab == "RARev2")
                          {
                              dpEmpdept.Text = "Assigned to RACG";
                              dpAssign.Text = "RACG";
                          }
                      }
                      else
                      {




                          if (ab != "RARev1" && ab != "RARev2")
                          {
                              dpEmpdept.Text = "CFT Assign To Coordinator";
                              dpAssign.Text = "Coordinator";

                          }

                          else if (ab == "RARev1" || ab == "RARev2")
                          {
                              dpEmpdept.Text = "Coordinator Assign To RACG";
                              dpAssign.Text = "RACG";
                          }

                      }

                      SqlCommand cmddel = new SqlCommand("drop table cftstatusreview", Connection);
                      Connection.Open();
                      cmddel.ExecuteNonQuery();
                      Connection.Close();
                  }
                 
                }
                else if (s == 9 && st == 1)
                {
                    dpEmpdept.Text = "CFT assign to coordinator ";
                    dpAssign.Text = "Coordinator";
                }
                if (s == 9 && st == 2)
                {
                    dpEmpdept.Text = "CFT pending ";
                    dpAssign.Text = "CFT";
                }
                if (s == 9 && st == 0)
                {
                    dpEmpdept.Text = "CFT Reject ";
                    dpAssign.Text = "CFT";
                }
                   
                else if (s == 4 && st == 11)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from cms_coordinator where changeid='" + lsDataKeyValue + "'", Connection);
                    DataSet dscft = new DataSet();
                    da.Fill(dscft);
                    if (dscft.Tables[0].Rows.Count > 0)
                    {
                        string fnrev = Convert.ToString(dscft.Tables[0].Rows[0]["funreview"]);
                        string acttree = Convert.ToString(dscft.Tables[0].Rows[0]["actitmtree"]);
                        if (fnrev == "Yes" && acttree == "No")
                        {
                            dpEmpdept.Text = "assigned to Approver";
                            dpAssign.Text = "Approver";
                        }
                        else
                        {
                            dpEmpdept.Text = "assigned to RACG";
                            dpAssign.Text = "RACG";
                        }
                    }

                   
                }
                else if (s == 4 && st == 10)
                {
                    dpEmpdept.Text = "Coordinator Rejected CFT";
                    dpAssign.Text = "Coordinator";
                }
                else if (s == 4 && st == 12)
                {
                    dpEmpdept.Text = "Coordinator pending CFT";
                    dpAssign.Text = "Coordinator";
                }


                else if (s == 10 && st == 0)
                {
                    dpEmpdept.Text = "RACG Reject";
                    dpAssign.Text = "RACG";
                }

                else if (s == 10 && st == 2)
                {
                    dpEmpdept.Text = "RACG Pending";
                    dpAssign.Text = "RACG";
                }

                else if (s == 10 && st == 1)
                {
                    dpEmpdept.Text = "RACG assigned to Coordinator";
                    dpAssign.Text = "Coordinator";
                }

                else if (s == 4 && st == 21)
                {
                    dpEmpdept.Text = "Assigned to Approver";
                    dpAssign.Text = "Approver";
                }
                else if (s == 4 && st == 20)
                {
                    dpEmpdept.Text = "Coordinator Rejected RACG";
                    dpAssign.Text = "Coordinator";
                }
                else if (s == 4 && st == 22)
                {
                    dpEmpdept.Text = "Coordinator pending RACG";
                    dpAssign.Text = "Coordinator";
                }             

                else if (s == 8 && st == 1)
                {
                    dpEmpdept.Text = "Approved ";
                    dpAssign.Text = "Approver";
                }
                else if (s == 8 && st == 0)
                {
                    dpEmpdept.Text = "Approver Reject ";
                    dpAssign.Text = "Approver";
                }
                else if (s == 8 && st == 2)
                {
                    dpEmpdept.Text = "Approver need information from coordinator ";
                    dpAssign.Text = "coordinator";
                }
                else if (s == 4 && st == 81)
                {
                    dpEmpdept.Text = "Coordinator Assign To Approver ";
                    dpAssign.Text = "Approver";
                }
            }
        }
    }


    protected void linkassign_Click(object sender, EventArgs e)
    {
        category = "assignment";
        lblassign.CssClass = "active";
        lblitems.CssClass = "lnkcolor";
        lnknew.CssClass = "lnkcolor";
        trassign.Visible = true;
        assignbind();
    }

    protected void actionbinding()
    {
        int userroleid = Convert.ToInt32(Session["userroleid"]);

        string usrolename = Convert.ToString(Session["userrolename"]);
        DataSet ds = new DataSet();
        if (userroleid == 1)
        {
            SqlDataAdapter da = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from CMS_Initiator where initby='" + lbluname.Text + "' and Curstatus=1 or (Curstatus=3 and status=2) order by updatedate asc ", Connection);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvinitiate.Columns[2].Visible = false;
                gvinitiate.Columns[5].Visible = false;
                gvinitiate.Columns[6].Visible = false;
                gvinitiate.Columns[7].Visible = false;
                gvinitiate.DataSource = ds;
                gvinitiate.DataBind();
            }
            else
            {

                //recid.Text = lbluname.Text;
                norec.Visible = true;
                norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                gvinitiate.Visible = false;
            }
       
        }
        else if (userroleid == 3)
        {
            SqlDataAdapter da = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from CMS_Initiator where submit='" + lbluname.Text + "' and (Curstatus=1 and status=1) or (Curstatus=4 and status=2) order by updatedate asc ", Connection);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvinitiate.Columns[2].Visible = false; 
                gvinitiate.Columns[5].Visible = false;
                gvinitiate.Columns[6].Visible = false;
                gvinitiate.Columns[7].Visible = false;
                gvinitiate.DataSource = ds;
                gvinitiate.DataBind();
            }
            else
            {
                //recid.Text = lbluname.Text;
                norec.Visible = true;
                norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                gvinitiate.Visible = false;
            }
       
           
        }
        else if (userroleid == 4)
        {
            SqlDataAdapter da = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from CMS_Initiator where (Curstatus=3 and status=1) or (Curstatus=4 or status=2) or (Curstatus=9 or status=1) order by updatedate desc", Connection);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvinitiate.Columns[2].Visible = false;
                gvinitiate.Columns[5].Visible = false;
                gvinitiate.Columns[6].Visible = false;
                gvinitiate.Columns[7].Visible = false;
                gvinitiate.DataSource = ds;
                gvinitiate.DataBind();
            }
            else
            {

                //recid.Text = lbluname.Text;
                norec.Visible = true;
                norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                gvinitiate.Visible = false;
            }
       
           
        }
        else if (userroleid == 9)
        {
            SqlDataAdapter da = new SqlDataAdapter("select distinct(Changeid) from cms_coordinator where funreview='Yes'", Connection);
            DataSet dscft = new DataSet();
            da.Fill(dscft, "cms_coordinator");
            if (dscft.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                {
                    string ChangeId = Convert.ToString((dr["Changeid"]));
                    SqlDataAdapter da2 = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from cms_Initiator where Changeid='" + ChangeId + "' and ((status=1 and  Curstatus=4) or(Curstatus=9 and status=2))", Connection);
                    da2.Fill(ds);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvinitiate.Columns[2].Visible = false;
                    gvinitiate.Columns[5].Visible = false;
                    gvinitiate.Columns[6].Visible = false;
                    gvinitiate.Columns[7].Visible = false;
                    gvinitiate.DataSource = ds;
                    gvinitiate.DataBind();
                }
                else
                {

                    //recid.Text = lbluname.Text;
                    norec.Visible = true;
                    norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                    gvinitiate.Visible = false;
                }
       
            }
            else
            {
                norec.Visible = true;
                norecords.Text = "No Records Found for This user";
                gvinitiate.Visible = false;
            }

        }

        else if (userroleid == 10)
        {
            SqlDataAdapter da = new SqlDataAdapter("select distinct(Changeid) from cms_coordinator where funreview='Yes' and actitmtree= 'Yes'", Connection);
            DataSet dscft = new DataSet();
            da.Fill(dscft, "cms_coordinator");
            if (dscft.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                {
                    string ChangeId = Convert.ToString((dr["Changeid"]));
                    SqlDataAdapter da2 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from cms_Initiator where Changeid='" + ChangeId + "' and ((status=11 and  Curstatus=4) or(Curstatus=10 and status=2))", Connection);
                    da2.Fill(ds);

                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvinitiate.Columns[2].Visible = false;
                    gvinitiate.Columns[5].Visible = false;
                    gvinitiate.Columns[6].Visible = false;
                    gvinitiate.Columns[7].Visible = false;
                    gvinitiate.DataSource = ds;
                    gvinitiate.DataBind();
                }
                else
                {

                    //recid.Text = lbluname.Text;
                    norec.Visible = true;
                    norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                    gvinitiate.Visible = false;
                }
       
            }
            else
            {
                norec.Visible = true;
                norecords.Text = "No Records Found for This user";
                gvinitiate.Visible = false;
            }

        }
        else if (userroleid == 8)
        {
            SqlDataAdapter da = new SqlDataAdapter("select distinct(intr.Changeid) from cms_coordinator crd inner join cms_Initiator intr on crd.changeid=intr.Changeid where (crd.funreview='No' and intr.status=1 and intr.Curstatus=4) or"+ 
"(crd.funreview='Yes' and crd.actitmtree='No' and intr.status=11 and intr.Curstatus=4) or (crd.funreview='Yes' and crd.actitmtree='Yes' and intr.status=21 and intr.Curstatus=4)", Connection);
            DataSet dscft = new DataSet();
            da.Fill(dscft, "cms_coordinator");
            if (dscft.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                {
                    string ChangeId = Convert.ToString((dr["Changeid"]));
                    SqlDataAdapter da2 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from cms_Initiator where Changeid='" + ChangeId + "'", Connection);
                    da2.Fill(ds);

                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvinitiate.Columns[2].Visible = false;
                    gvinitiate.Columns[5].Visible = false;
                    gvinitiate.Columns[6].Visible = false;
                    gvinitiate.Columns[7].Visible = false;
                    gvinitiate.DataSource = ds;
                    gvinitiate.DataBind();
                }
                else
                {

                    //recid.Text = lbluname.Text;
                    norec.Visible = true;
                    norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                    gvinitiate.Visible = false;
                }
       
            }
            else
            {
                norec.Visible = true;
                norecords.Text = "No Records Found for This user";
                gvinitiate.Visible = false;
            }

        }


    }
    protected void assignbind()
    {
        int userroleid = Convert.ToInt32(Session["userroleid"]);
        string umrolname = Convert.ToString(Session["umroles"]);
        string usrolename = Convert.ToString(Session["userrolename"]);
        DataSet ds = new DataSet();

        if (umrolname == "Initiator&Reviewer")
        {
            lnknew.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where initby='" + lbluname.Text + "'  order by updatedate desc", Connection);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvinitiate.Columns[2].Visible = true;
                gvinitiate.Columns[5].Visible = true;
                gvinitiate.Columns[6].Visible = true;
                gvinitiate.Columns[7].Visible = true;
                gvinitiate.DataSource = ds;
                gvinitiate.DataBind();
            }
            else
            {

                //recid.Text = lbluname.Text;
                norec.Visible = true;
                norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                gvinitiate.Visible = false;
            }
           
        }
        else
            if (userroleid == 1)
            {
                lnknew.Visible = true;
                SqlDataAdapter da = new SqlDataAdapter("(select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where initby='" + lbluname.Text + "' )except(select substring(CDesc,1,20)as cdesc, * from CMS_Initiator where initby='" + lbluname.Text + "' and status=123)", Connection);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvinitiate.Columns[2].Visible = true;
                    gvinitiate.Columns[5].Visible = true;
                    gvinitiate.Columns[6].Visible = true;
                    gvinitiate.Columns[7].Visible = true;
                    gvinitiate.DataSource = ds;
                    gvinitiate.DataBind();
                }
                else
                {

                    //recid.Text = lbluname.Text;
                    norec.Visible = true;
                    norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                    gvinitiate.Visible = false;
                }
            }
            else if (userroleid == 3)
            {
                lnknew.Visible = false;
                DataSet dscrd = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter("(select * from CMS_Initiator where initby='" + lbluname.Text + "' )except(select  * from CMS_Initiator where initby='" + lbluname.Text + "' and status=123)", Connection);
                da1.Fill(dscrd);

                DataSet dsr = new DataSet();
                if (dscrd.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where initby='" + lbluname.Text + "' order by updatedate desc", Connection);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvinitiate.Columns[2].Visible = true;
                        gvinitiate.Columns[5].Visible = true;
                        gvinitiate.Columns[6].Visible = true;
                        gvinitiate.Columns[7].Visible = true;
                        gvinitiate.DataSource = ds;
                        gvinitiate.DataBind();
                    }
                    else
                    {

                        //recid.Text = lbluname.Text;
                        norec.Visible = true;
                        norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                        gvinitiate.Visible = false;
                    }
                }
                else
                {
                   
                    SqlDataAdapter daaudit = new SqlDataAdapter("select * from audithistory where  (RoleCode=4  and submireviewer='" + lbluname.Text + "')or (RoleCode=9 and Userid='" + lbluname.Text + "')or (RoleCode=1 and submireviewer='" + lbluname.Text + "')", Connection);
                    DataSet dsaudit = new DataSet();
                    daaudit.Fill(dsaudit);

                   

                    if (dsaudit.Tables[0].Rows.Count > 0)
                    {
                       

                        Connection.Close();

                        SqlCommand cmd1 = new SqlCommand("select a.changeid,v.Cid into auditids from CMS_Initiator a inner join audithistory v on a.submit = v.submireviewer where a.submit='" + lbluname.Text + "'", Connection);
                        Connection.Open();
                        cmd1.ExecuteNonQuery();
                        Connection.Close();
                       
                        //SqlDataAdapter daid=new SqlDataAdapter("select changeid,Cid from auditids",Connection);
                        //DataSet dsid = new DataSet();
                        //daid.Fill(dsid);
                        SqlCommand cmd2 = new SqlCommand("select distinct changeid into result1 from (select Cid as changeid from auditids s1 union select changeid as Cid  from auditids s2) as emps", Connection);
                       
                      
                        Connection.Open();
                        cmd2.ExecuteNonQuery();
                        Connection.Close();
                        SqlDataAdapter dare = new SqlDataAdapter("(select DISTINCT Changeid,* from CMS_Initiator where submit='" + lbluname.Text + "' or changeid IN(select * from result1)except(select  DISTINCT Changeid,* from CMS_Initiator where submit='" + lbluname.Text + "' and status=123))", Connection);

                      
                        dare.Fill(dsr);

                        if (dsr.Tables[0].Rows.Count > 0)
                        {
                            gvinitiate.Columns[2].Visible = true;
                            gvinitiate.Columns[5].Visible = true;
                            gvinitiate.Columns[6].Visible = true;
                            gvinitiate.Columns[7].Visible = true;
                            gvinitiate.DataSource = dsr;
                            gvinitiate.DataBind();

                           

                        }
                        else
                        {
                          

                            SqlCommand cmd3 = new SqlCommand("select Cid into cftresult from audithistory where (submireviewer='" + lbluname.Text + "' and RoleCode=4)", Connection);
                            Connection.Open();
                            cmd3.ExecuteNonQuery();
                            Connection.Close();
                            SqlDataAdapter dare1 = new SqlDataAdapter("(select DISTINCT Changeid,* from CMS_Initiator where  changeid IN(select * from cftresult))", Connection);
                            DataSet dssub = new DataSet();
                            dare1.Fill(dssub);

                            if (dssub.Tables[0].Rows.Count > 0)
                            {
                                gvinitiate.Columns[2].Visible = true;
                                gvinitiate.Columns[5].Visible = true;
                                gvinitiate.Columns[6].Visible = true;
                                gvinitiate.Columns[7].Visible = true;
                                gvinitiate.DataSource = dssub;
                                gvinitiate.DataBind();


                            }
                            else
                            {
                                norec.Visible = true;
                                norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                                gvinitiate.Visible = false;
                            }
                            SqlCommand delcftresult = new SqlCommand("drop table cftresult", Connection);
                            Connection.Open();
                            delcftresult.ExecuteNonQuery();
                            Connection.Close();
                           
                        }


                        SqlCommand delauditids = new SqlCommand("drop table auditids", Connection);
                        SqlCommand delresult = new SqlCommand("drop table result1", Connection);


                        Connection.Open();
                        delauditids.ExecuteNonQuery();
                        delresult.ExecuteNonQuery();
                       

                    }


                    else
                    {
                        SqlDataAdapter dare = new SqlDataAdapter("select DISTINCT Changeid,* from CMS_Initiator where submit='" + lbluname.Text + "'", Connection);
                        dare.Fill(dsr);

                        if (dsr.Tables[0].Rows.Count > 0)
                        {
                            gvinitiate.Columns[2].Visible = true;
                            gvinitiate.Columns[5].Visible = true;
                            gvinitiate.Columns[6].Visible = true;
                            gvinitiate.Columns[7].Visible = true;
                            gvinitiate.DataSource = dsr;
                            gvinitiate.DataBind();
                        }
                        else
                        {

                            norec.Visible = true;
                            norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                            gvinitiate.Visible = false;
                        }
                    }

                }
              
                
            }
            else if (userroleid == 4)
            {
                lnknew.Visible = false;
                SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where ((Curstatus=4 and status=81)or(Curstatus=8 and status=2)or(Curstatus=9 and status=1)or (Curstatus=10 and status=1) or(Curstatus=3 and status=1)or (Curstatus=4 and status=2) or (Curstatus=4 and status=1)or (Curstatus=9 and status=2)or (Curstatus=8 and status=1)) order by updatedate desc", Connection);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvinitiate.Columns[2].Visible = true;
                    gvinitiate.Columns[5].Visible = true;
                    gvinitiate.Columns[6].Visible = true;
                    gvinitiate.Columns[7].Visible = true;
                    gvinitiate.DataSource = ds;
                    gvinitiate.DataBind();
                }
                else
                {

                    //recid.Text = lbluname.Text;
                    norec.Visible = true;
                    norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                    gvinitiate.Visible = false;
                }

            }
            else if (userroleid == 9)
            {
                lnknew.Visible = false;
                SqlDataAdapter da = new SqlDataAdapter("select distinct(Changeid) from cms_coordinator where funreview='Yes'", Connection);
                DataSet dscft = new DataSet();
                da.Fill(dscft, "cms_coordinator");
                if (dscft.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                    {
                        string ChangeId = Convert.ToString((dr["Changeid"]));
                        SqlDataAdapter da2 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from cms_Initiator where Changeid='" + ChangeId + "' and ((status=1 and  Curstatus=4) or (status=12 and  Curstatus=4)) ", Connection);
                        da2.Fill(ds);

                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvinitiate.Columns[2].Visible = true;
                        gvinitiate.Columns[5].Visible = true;
                        gvinitiate.Columns[6].Visible = true;
                        gvinitiate.Columns[7].Visible = true;
                        gvinitiate.DataSource = ds;
                        gvinitiate.DataBind();
                    }
                    else
                    {

                        //recid.Text = lbluname.Text;
                        norec.Visible = true;
                        norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                        gvinitiate.Visible = false;
                    }
                }
                else
                {
                    norec.Visible = true;
                    norecords.Text = "No Records Found for This user";
                    gvinitiate.Visible = false;
                }

            }
            else if (userroleid == 10)
            {
                SqlDataAdapter da = new SqlDataAdapter("select distinct(Changeid) from cms_coordinator where funreview='Yes'", Connection);
                DataSet dscft = new DataSet();
                da.Fill(dscft, "cms_coordinator");
                if (dscft.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                    {
                        string ChangeId = Convert.ToString((dr["Changeid"]));
                        SqlDataAdapter da2 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from cms_Initiator where Changeid='" + ChangeId + "' and ((status=11 and  Curstatus=4) or (status=22 and  Curstatus=4) ) ", Connection);
                        da2.Fill(ds);

                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvinitiate.Columns[2].Visible = true;
                        gvinitiate.Columns[5].Visible = true;
                        gvinitiate.Columns[6].Visible = true;
                        gvinitiate.Columns[7].Visible = true;
                        gvinitiate.DataSource = ds;
                        gvinitiate.DataBind();
                    }
                    else
                    {

                        //recid.Text = lbluname.Text;
                        norec.Visible = true;
                        norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                        gvinitiate.Visible = false;
                    }
                }
                else
                {
                    norec.Visible = true;
                    norecords.Text = "No Records Found for This user";
                    gvinitiate.Visible = false;
                }

            }
            else if (userroleid == 8)
            {

                SqlDataAdapter da = new SqlDataAdapter("select * from cms_Initiator where (status=1 and Curstatus=8) or (status=2 and Curstatus=8)or(status=81 and Curstatus=4) or (status=11 and Curstatus=4) or (status=21 and Curstatus=4)", Connection);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    gvinitiate.Columns[2].Visible = true;
                    gvinitiate.Columns[5].Visible = true;
                    gvinitiate.Columns[6].Visible = true;
                    gvinitiate.Columns[7].Visible = true;
                    gvinitiate.DataSource = ds1;
                    gvinitiate.DataBind();
                }
                else
                {
                    norec.Visible = true;
                    norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                    gvinitiate.Visible = false;
                }
                //SqlDataAdapter da = new SqlDataAdapter("select distinct(intr.Changeid) from cms_coordinator crd inner join cms_Initiator intr on crd.changeid=intr.Changeid where (crd.funreview='No' and intr.status=1 and intr.Curstatus=4) or" +
                //"(crd.funreview='Yes' and crd.actitmtree='No' and intr.status=11 and intr.Curstatus=4) or (crd.funreview='Yes' and crd.actitmtree='Yes' and intr.status=21 and intr.Curstatus=4)", Connection);
                //DataSet dscft = new DataSet();
                //da.Fill(dscft, "cms_coordinator");
                //if (dscft.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                //    {
                //        string ChangeId = Convert.ToString((dr["Changeid"]));
                //        SqlDataAdapter da2 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from cms_Initiator where Changeid='" + ChangeId + "'", Connection);
                //        da2.Fill(ds);

                //    }
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        gvinitiate.Columns[2].Visible = true;
                //        gvinitiate.Columns[5].Visible = true;
                //        gvinitiate.Columns[6].Visible = true;
                //        gvinitiate.Columns[7].Visible = true;
                //        gvinitiate.DataSource = ds;
                //        gvinitiate.DataBind();
                //    }
                //    else
                //    {
                //        norec.Visible = true;
                //        norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
                //        gvinitiate.Visible = false;
                //    }

                //}
                //else
                //{
                //    norec.Visible = true;
                //    norecords.Text = "No Records Found for This user";
                //    gvinitiate.Visible = false;
                //}

            }

   


    }
    protected void lnkact_Click(object sender, EventArgs e)
    {
        
        category = "act";
        lblitems.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        lnknew.CssClass = "lnkcolor";
        trassign.Visible = true;
        actionbinding();
    }
    protected void lnllogout(object sender, EventArgs e)
    {
       // Response.Redirect("Default.aspx");

        Response.RedirectToRoute("logincms");
    }
    protected void lnknew_Click(object sender, EventArgs e)
    {
        trassign.Visible = false;
        lnknew.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        lblitems.CssClass = "lnkcolor";
        initnew.Visible = true;
        string a1 = "newInitiator";

        //Response.Redirect("CMS_Initiator.aspx?param1=" + a1);
        Response.RedirectToRoute("createinitiator",new {param1=a1});
    }
    protected void clickid(object sender, EventArgs e)
    {
       
        LinkButton ln = sender as LinkButton;
        string changeid = ln.CommandArgument.ToString();
        Session["cmid"]= changeid;
        trassign.Visible = false;
        lnknew.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        lblitems.CssClass = "lnkcolor";
        trassign.Visible = true;
         userroleid = Convert.ToInt32(Session["userroleid"]);
         string umrolname = Convert.ToString(Session["umroles"]);
         SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where changeid='"+changeid+"' ", Connection);
        DataSet ds=new DataSet();
        da.Fill(ds);
        int s =Convert.ToInt32(ds.Tables[0].Rows[0]["Curstatus"]);
        int st = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (userroleid == 1)
            {
                
                    string a = "Initiator1";
                 //   Response.Redirect("CMS_Initiator.aspx?parameter=" + a);

                   Response.RedirectToRoute("initiator", new {parameter = a });
            }
           else if (userroleid == 3)
            {
                if (s == 1 && st == 1)
                {
                    b = "gidcid";
                   // Response.Redirect("CMS_ChangeOwner.aspx?parameter=" + b);
                    Response.RedirectToRoute("changeowner", new { parameter = b });
                }

                else if (s == 4 && st == 2)
                {
                    b = "gidcid";
                    //Response.Redirect("CMS_ChangeOwner.aspx?parameter=" + b);
                    Response.RedirectToRoute("changeowner", new { parameter = b });
                }

                else if (s == 4 && st == 1)
                {
                    string ab = lbluname.Text;
                  
                   if (ab != "RARev2" && ab != "RARev1")
                    {
                        b = "gidcid";
                       // Response.Redirect("CMS_Final QA.aspx?parameter=" + b);
                        Response.RedirectToRoute("cmmcft", new { parameter = b });

                    }
                   else if (ab == "RARev1" || ab == "RARev2")
                    {
                        b = "gidcid";
                       // Response.Redirect("CMS_racg.aspx?parameter=" + b);
                        Response.RedirectToRoute("cmmracg", new { parameter = b });
                    }

                 
                  
                }
                if (s == 9 && st == 2)
                {
                    b = "gidcid";
                    //Response.Redirect("CMS_Final QA.aspx?parameter=" + b);
                    Response.RedirectToRoute("cmmcft", new { parameter = b });
                }
                if (s == 9 && st == 0)
                {
                    b = "gidcid";
                   // Response.Redirect("CMS_Final QA.aspx?parameter=" + b);
                    Response.RedirectToRoute("cmmcft", new { parameter = b });
                }

                else if (s == 10 && st == 0)
                {
                    b = "gidcid";
                  //  Response.Redirect("CMS_racg.aspx?parameter=" + b);
                    Response.RedirectToRoute("cmmracg", new { parameter = b });
                }

                else if (s == 10 && st == 2)
                {
                    b = "gidcid";
                    //Response.Redirect("CMS_racg.aspx?parameter=" + b);
                    Response.RedirectToRoute("cmmracg", new { parameter = b });
                }

            }
            else if (userroleid == 4)
            {
                string a = "gidcid";
                //Response.Redirect("QAReg1.aspx?parameter=" + a);
                Response.RedirectToRoute("cmmqareg", new { parameter = a });
            }
            else if (userroleid == 8)
            {
                string a = "gidcid";
               // Response.Redirect("CMS_Cab Review.aspx?parameter=" + a);
                Response.RedirectToRoute("cmmapprover", new { parameter = a });
            }
           
        }
        else
        {
            initnew.Visible = true;

            norecords.Text = "No Records Found for This '" + lbluname.Text + "' user";
        }
       
    }
           
    protected void belowcontent_SelectedIndexChanged(object sender, EventArgs e)
    {
        string changeid = "";
        string str1 = "";
        if (belowcontent.SelectedValue == "Audit Trial")
        {
           
            foreach (GridViewRow gvrow in gvinitiate.Rows)
            {
                 
                CheckBox chk = (CheckBox)gvrow.FindControl("chkassign");
                if (chk != null & chk.Checked)
                {

                    str1 = gvinitiate.DataKeys[gvrow.RowIndex].Values[0].ToString();
                }
            }
            changeid = str1;
           //Response.Redirect("CmsAuditTrail.aspx?parameter=" + changeid);
            Response.RedirectToRoute("cmmaudittrail", new { parameter=changeid });
            //Response.Redirect("CMM AuditTrail.aspx");
        }
       else if (belowcontent.SelectedValue == "Run Report")
        {
            Response.Redirect("cmm runreport.aspx");
            //Response.Redirect("CMM AuditTrail.aspx");
        }
        else if (belowcontent.SelectedValue == "E-mail Notification")
        {
            //Response.Redirect("mailto:rmattaparthi@aceindus.in?");
            Response.Redirect("mailto:sdamisetty@aceindus.in?");
            //Response.Redirect("CMM AuditTrail.aspx");
        }
        else if (belowcontent.SelectedValue == "Re-assign")
        {
            string str = string.Empty;
            string strname = string.Empty;
            foreach (GridViewRow gvrow in gvinitiate.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkassign");
                if (chk != null & chk.Checked)
                {
                   // str += gvinitiate.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                   // strname += gvrow.Cells[2].Text + ',';
                    str = gvinitiate.DataKeys[gvrow.RowIndex].Value.ToString();
                   
                }
            }
            str = str.Trim(",".ToCharArray());
            strname = strname.Trim(",".ToCharArray());
            Session["reassign"] = str;
            string a = "reassignid";
           // Response.Redirect("QAReg1.aspx?parameter=" + a);
            Response.RedirectToRoute("cmmqareg", new { parameter = a });
        }


       
    }

     
    protected void lnkhome_Click(object sender, EventArgs e)
    {
       // Response.Redirect("Home.aspx");
        Response.RedirectToRoute("cmmhome");
    }
}
