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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using cmm.departments;
using System.Text.RegularExpressions;
using cmm.errorexcep;
using cmm.audithistory;
using cmm.audithistoryproperties;
using cmm.cftproperties;
using cmm.cftmethods;
public partial class Final_QA : System.Web.UI.Page
{
    DataTable dt;
    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string temp;    
    public static string category;
    department dept = new department();
    int prioritycde;
    audithistoryproperties auditpop = new audithistoryproperties();
    bool t;
    static string excep_page = "CMS_Final QA.aspx";
    error err = new error();
    cft_properties cftpop = new cft_properties();
    cftmethod cftmethod = new cftmethod();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
            Response.Redirect("default.aspx");
        }
        string name1 = Convert.ToString(Session["uname"]);
        lbluname.Text = name1;
        string changeid = Convert.ToString(Session["cmid"]);
        //string gidcid = Convert.ToString(Request.QueryString["parameter"]);
        string gidcid = Convert.ToString(Page.RouteData.Values["parameter"]);
        string gid = Convert.ToString(Session["gvcid"]);
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;
        //lbltext.Text = changeid;
        string s = Convert.ToString(Session["id1"]);
        //lbltext.Text = s;
        int userroleid = Convert.ToInt32(Session["userroleid"]);
        if (Session["uname"] == null)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Session Closed.Please ReLogin into medqms')", true);

           // Response.Redirect("default.aspx");
            Response.RedirectToRoute("logincms");
        }
        if (!IsPostBack)
        {
            int userdept = Convert.ToInt32(Session["userdepartment"]);
            category = "assignment";
            lblassign.CssClass = "active";
            lblitems.CssClass = "lnkcolor";
           DataSet ds = new DataSet();
         

            dept.departmentbinding(txtcomment);
            DropDownList2.Items.Insert(0, "Select");
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Executor", typeof(string)));

            dt.Columns.Add(new DataColumn("Reviewer", typeof(string)));

            dt.Columns.Add(new DataColumn("Target Date", typeof(string)));
            ViewState["cur"] = dt;
            if (userroleid == 9 || userroleid == 3)
            {
                if (changeid == "")
                {

                 
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from audithistory where Cid='" + changeid + "' and ROleCode=4 and submireviewer='" + lbluname.Text + "'", Connection);
                    DataSet dss = new DataSet();
                    da.Fill(dss);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        bindmethod1();
                    }
                    else
                    {
                          bindmethod1();
                       EnableAllControlscolor(this.Page.Form.Controls, false);
                       Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
                    }
                }

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
                  bindmethod1();
                  EnableAllControlscolor(this.Page.Form.Controls, false);
            }



           
            statusbind();
        }
    }

    private void bindmethod1()
    {

        string temp = Convert.ToString(Session["cmid"]);
        lbltext.Text = temp;
        userbody.Visible = true;
        SqlDataAdapter da1= new SqlDataAdapter("select * from CMS_CFT where changeid='" + temp + "' and cftrevname='"+lbluname.Text+"'", Connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            //  Session["search1"] = ds1.ToString();

            if (ds1.Tables[0].Rows.Count > 0)
            {
                pnl111.Visible = true;
                userbody.Visible = true;
                txtcomment.SelectedItem.Text = ds1.Tables[0].Rows[0]["Department"].ToString();
                TextBox1.Text = ds1.Tables[0].Rows[0]["ImpactAnalysis"].ToString(); ;
                ddlitems.SelectedItem.Text = ds1.Tables[0].Rows[0]["cfdcode"].ToString();
                lbltext.Text = temp;
                if (ddlitems.SelectedItem.Text == "Yes")
                {
                    // pnl1.Visible = true;
                    dt = (DataTable)ViewState["cur"];

                    SqlDataAdapter da = new SqlDataAdapter("select * from CMS_CFT where changeid='" + temp + "'", Connection);
                    DataSet dscft = new DataSet();
                    da.Fill(dscft, "cms_coordinator");
                    foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                    {
                        DataRow dr2 = dt.NewRow();
                        dr2["Executor"] = Convert.ToString((dr["Executor"]));
                        dr2["Reviewer"] = Convert.ToString((dr["Reviewer"]));
                        dr2["Target Date"] = Convert.ToString((dr["TargetDate"]));
                        dt.Rows.Add(dr2);

                    }
                    gd.DataSource = dt;
                    gd.DataBind();
                    gd.Enabled = false;
                    gd.Visible = true;
                    pnl1.Visible = false;
                }
                else
                {
                    pnl1.Visible = false;
                    gd.Visible = false;
                }


            }
        else
        {
            string umrolename = Convert.ToString(Session["umroles"]);
            int userroleid = Convert.ToInt32(Session["userroleid"]);
                SqlDataAdapter daau=new SqlDataAdapter("select * from audithistory where Cid='"+temp+"' and RoleCode=4 and submireviewer='"+lbluname.Text+"'",Connection);
                DataSet dsau=new DataSet();
                daau.Fill(dsau);
                if(dsau.Tables[0].Rows.Count>0)
                {
                  if (userroleid == 3)
                  {
                lbltext.Text = temp;
                pnl111.Visible = true;
                userbody.Visible = true;
                trwaiting.Visible = true;
                lblwait.Text = "Waiting For Approving This '" + temp + "' Request";
                  }
                }
                else
                {

            if (userroleid == 3)
            {
                lbltext.Text = temp;
                pnl111.Visible = true;
                userbody.Visible = true;
                trwaiting.Visible = true;
                lblwait.Text = "Waiting For Approving This '" + temp + "' Request";
            }
            else if (umrolename == "Initiator&Reviewer")
            {
                lbltext.Text = temp;
                pnl111.Visible = true;
                userbody.Visible = true;
                trwaiting.Visible = true;
                lblwait.Text = "Waiting For Approving This '" + temp + "' Request";
            }
            else
            {

                pnl111.Visible = true;
            }

            string strScript = "alert('Reviewer not perform any action to this '" + temp + "' record');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
           }
        }

    }
    public void EnableAllControlscolor(ControlCollection cc, bool enable)
    {
        foreach (Control c in cc)
        {
            try { EnableAllControlscolor(c.Controls, enable); }
            catch { }
            if (c.GetType() == typeof(TextBox)) { try { ((TextBox)c).Enabled = enable; ((TextBox)c).CssClass = "readonlycolor"; } catch { } }
            else if (c.GetType() == typeof(DropDownList)) { try { ((DropDownList)c).Enabled = enable; ((DropDownList)c).CssClass = "readonlycolor"; } catch { } }
            else if (c.GetType() == typeof(Button)) { try { ((Button)c).Enabled = enable; ((Button)c).CssClass = "readonlycolor"; } catch { } }
            // else if (c.GetType() == typeof(LinkButton)) { try { ((LinkButton)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(HtmlInputText)) { try { ((HtmlInputText)c).Attributes.Add("disabled", "true"); } catch { } }
        }
    }
   

    public void EnableAllControlss(ControlCollection cc, bool enable)
    {
        foreach (Control c in cc)
        {
            try { EnableAllControlss(c.Controls, enable); }
            catch { }
            if (c.GetType() == typeof(TextBox)) { try { ((TextBox)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(DropDownList)) { try { ((DropDownList)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(Button)) { try { ((Button)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(LinkButton)) { try { ((LinkButton)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(HtmlInputText)) { try { ((HtmlInputText)c).Attributes.Add("disabled", "true"); } catch { } }
        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void statuscft()
    {
        string crdres = Convert.ToString(Session["cftcoordrevs"]);

        string ass = Convert.ToString(Session["cftresss"]);
        string abs = Convert.ToString(Session["cftresss1"]);

        string ass1 = Convert.ToString(Session["cftrevres1"]);
        string abs1 = Convert.ToString(Session["cftrevres2"]);


        string ass12 = Convert.ToString(Session["cftresss1"]);
        string abs12 = Convert.ToString(Session["cftresss11"]);
        string crdres1 = ass1 + ""+","+"" + abs1;
        SqlDataAdapter da = new SqlDataAdapter("select * from cms_initiator where changeid='" + lbltext.Text + "'", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);
            int cstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Curstatus"]);
            int cftstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["cftstatus"]);
            if (status == 1 && cstatus == 4)
            {
                if (cftstatus == 91)
                {

                    //Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + crdres1 + "')</script>");
                    lblstat.Text=crdres1;
                }
                else
                {
                   // Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Assigned To " + crdres1 + " Reviewers')</script>");
                lblstat.Text="Assigned To " + crdres1 + " Reviewers";
                }
            }
            else if (status == 1 && cstatus == 9)
            {

                string res = ass + "," + abs;
                 lblstat.Text="status is:" + ass12 + " " + abs12 + " .";
               // Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('status is:" + ass12 + "" + abs12 + " .')</script>");

            }


        }
        else
        {

        }
        Session.Remove("cftresss");
        Session.Remove("cftresss1");
        Session.Remove("cftcoordrevs");

        Session.Remove("cftrevres1");
        Session.Remove("cftrevres2");
        Session.Remove("cftresss1");
        Session.Remove("cftresss2");

    }
    //protected void statusbind()
    //{   //Get data row view
    //     string lsDataKeyValue = Convert.ToString(Session["cmid"]);
          
    //        SqlDataAdapter da1 = new SqlDataAdapter("select  * from CMS_Initiator where changeid='" + lsDataKeyValue + "'", Connection);
    //        Session["cid"] = lsDataKeyValue;

    //        //  SqlDataAdapter da1 = new SqlDataAdapter("select  * from CMS_Initiator order by Iid desc", con);
    //        DataSet ds1 = new DataSet();
    //        da1.Fill(ds1);
    //        if (ds1.Tables[0].Rows.Count > 0)
    //        {
               
                
    //            int s = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);
    //            int st = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
    //            int cftst = Convert.ToInt32(ds1.Tables[0].Rows[0]["cftstatus"]);
    //            if (s == 1 && st == 1)
    //            {
    //                //dpEmpdept.Text = "assign to Reviewer";
    //                lblstat.Text = "Reviewer";
    //            }
    //            else if (s == 1 && st == 0)
    //            {
    //               // dpEmpdept.Text = "Initiator Reject";
    //                lblstat.Text = "Initiator";
    //            }
    //            else if (s == 1 && st == 2)
    //            {
    //               // dpEmpdept.Text = "Initiator pending";
    //                lblstat.Text = "Initiator";
    //            }
    //            else if (s == 3 && st == 0)
    //            {
    //               // dpEmpdept.Text = "Reviewer Reject";
    //                lblstat.Text = "Reviewer";
    //            }

    //            else if (s == 3 && st == 2)
    //            {
    //               // dpEmpdept.Text = "Initiator Pending";
    //                lblstat.Text = "Initiator";
    //            }

    //            else if (s == 3 && st == 1)
    //            {
    //               // dpEmpdept.Text = "assign to Coordinator";
    //                lblstat.Text = "Coordinator";
    //            }

    //            else if (s == 4 && st == 0)
    //            {
    //                //dpEmpdept.Text = "Coordinator Reject";
    //                lblstat.Text = "Coordinator";
    //            }

    //            else if (s == 4 && st == 2)
    //            {
    //                //dpEmpdept.Text = "Reviewer Pending";
    //                lblstat.Text = "Reviewer";
    //            }

    //            else if (s == 4 && st == 1)
    //            {


    //                if (cftst == 91 || cftst == 101)
    //                {
    //                    //dpEmpdept.Visible = false;
    //                    string crdrevs = "";
                       
    //                    lblstat.Text = "Coordinator";
    //                    SqlDataAdapter da11 = new SqlDataAdapter("select * from audithistory where Cid='" + lsDataKeyValue + "' and RoleCode=4", Connection);
    //                    DataSet ds11 = new DataSet();
    //                    da11.Fill(ds11);

    //                    string sMyData = string.Empty;
    //                    foreach (DataRow dr in ds11.Tables[0].Rows)
    //                    {
    //                        crdrevs = crdrevs + "," + dr["submireviewer"].ToString();
    //                    }


    //                    crdrevs = crdrevs.TrimEnd(',');

    //                    string[] crdrevis = Regex.Split(crdrevs, ",");
    //                    string crdres = "";
    //                    string ass = "";
    //                    string abs = "";
    //                    for (int i = 0; i < crdrevis.Length; i++)
    //                    {
    //                        crdres = crdrevis[i];
    //                        Console.WriteLine(crdres);
    //                        string ab = "";
    //                        string ba = "";
    //                        SqlDataAdapter da = new SqlDataAdapter("select Userid from audithistory where Cid='" + lsDataKeyValue + "' and Userid='" + crdres + "' and RoleCode=9", Connection);
    //                        DataSet ds = new DataSet();
    //                        da.Fill(ds);
    //                        if (ds.Tables[0].Rows.Count > 0)
    //                        {
    //                            // dpEmpdept.Text = crdres + "completed";
    //                            ab = string.Join(",","CFT" +" " +crdres + "completed");
    //                           // ab ="CFT"+""+crdres+""+"Reviewer Assign To Coordinator";
    //                            //dpEmpdept.Text = ab + "," + ba;
    //                            Session["cftrevres1"] = ab;
    //                        }
    //                        else
    //                        {
    //                            ba = string.Join(",", crdres + "pending");
                               
    //                            //dpEmpdept.Text = crdres + "pending";
    //                            // dpEmpdept.Text =ab+","+ba;
    //                            Session["cftrevres2"] = ba;
                                
    //                        }
    //                        ass = Convert.ToString(Session["cftrevres1"]);
    //                        abs = Convert.ToString(Session["cftrevres2"]);



                           
    //                    }
    //                    statuscft();
    //                }
    //                else
    //                {
    //                    string ab = lbluname.Text;
    //                    if (ab != "RARev1" && ab != "RARev2")
    //                    {
                           
    //                            // dpEmpdept.Text = "Assigned to CFT";
    //                            lblstat.Text = "CFT";
                           
    //                    }
    //                    else if (ab == "RARev1" || ab == "RARev2")
    //                    {
    //                       // dpEmpdept.Text = "Assigned to RACG";
    //                        lblstat.Text = "RACG";
    //                    }
    //                    //statuscft();
    //                }
                   
    //            }

    //            else if (s == 9 && st == 19)
    //            {
    //                //dpEmpdept.Text = "CFT assign to coordinator ";
    //                lblstat.Text = "Coordinator";
    //            }

    //            else if (s == 9 && st == 1)
    //            {
    //                //dpEmpdept.Text = "CFT assign to coordinator ";
    //                lblstat.Text = "Coordinator";
    //            }
    //            if (s == 9 && st == 2)
    //            {
    //                //dpEmpdept.Text = "CFT pending ";
    //                lblstat.Text = "CFT";
    //            }
    //            if (s == 9 && st == 0)
    //            {
    //                //dpEmpdept.Text = "CFT Reject ";
    //                lblstat.Text = "CFT";
    //            }

    //            else if (s == 4 && st == 11)
    //            {
    //                SqlDataAdapter da = new SqlDataAdapter("select * from cms_coordinator where changeid='" + lsDataKeyValue + "'", Connection);
    //                DataSet dscft = new DataSet();
    //                da.Fill(dscft);
    //                if (dscft.Tables[0].Rows.Count > 0)
    //                {
    //                    string fnrev = Convert.ToString(dscft.Tables[0].Rows[0]["funreview"]);
    //                    string acttree = Convert.ToString(dscft.Tables[0].Rows[0]["actitmtree"]);
    //                    if (fnrev == "Yes" && acttree == "No")
    //                    {
    //                        //dpEmpdept.Text = "assigned to Approver";
    //                        lblstat.Text = "Approver";
    //                    }
    //                    else
    //                    {
    //                        //dpEmpdept.Text = "assigned to RACG";
    //                        lblstat.Text = "RACG";
    //                    }
    //                }
    //            }
    //            else if (s == 4 && st == 10)
    //            {
    //                //dpEmpdept.Text = "Coordinator Rejected CFT";
    //                lblstat.Text = "Coordinator";
    //            }
    //            else if (s == 4 && st == 12)
    //            {
    //                //dpEmpdept.Text = "Coordinator pending CFT";
    //                lblstat.Text = "Coordinator";
    //            }


    //            else if (s == 10 && st == 0)
    //            {
    //                //dpEmpdept.Text = "RACG Reject";
    //                lblstat.Text = "RACG";
    //            }

    //            else if (s == 10 && st == 2)
    //            {
    //                //dpEmpdept.Text = "RACG Pending";
    //                lblstat.Text = "RACG";
    //            }

    //            else if (s == 10 && st == 1)
    //            {
    //               // dpEmpdept.Text = "RACG assigned to Coordinator";
    //                lblstat.Text = "Coordinator";
    //            }

    //            else if (s == 4 && st == 21)
    //            {
    //               // dpEmpdept.Text = "Assigned to Approver";
    //                lblstat.Text = "Approver";
    //            }
    //            else if (s == 4 && st == 20)
    //            {
    //               // dpEmpdept.Text = "Coordinator Rejected RACG";
    //                lblstat.Text = "Coordinator";
    //            }
    //            else if (s == 4 && st == 22)
    //            {
    //                //dpEmpdept.Text = "Coordinator pending RACG";
    //                lblstat.Text = "Coordinator";
    //            }

    //            else if (s == 8 && st == 1)
    //            {
    //               // dpEmpdept.Text = "Approved ";
    //                lblstat.Text = "Approver";
    //            }
    //            else if (s == 8 && st == 0)
    //            {
    //                //dpEmpdept.Text = "Approver Reject ";
    //                lblstat.Text = "Approver";
    //            }
    //            else if (s == 8 && st == 2)
    //            {
    //               // dpEmpdept.Text = "Approver pending ";
    //                lblstat.Text = "Approver";
    //            }
    //        }


    //    }


    protected void statuscord(string changeid)
    {
        string crdres = Convert.ToString(Session["coordrevs"]);

        string ass = Convert.ToString(Session["resss"]);
        string abs = Convert.ToString(Session["resss1"]);

        string ass1 = Convert.ToString(Session["revres1"]);
        string abs1 = Convert.ToString(Session["revres2"]);


        string ass12 = Convert.ToString(Session["resss1"]);
        string abs12 = Convert.ToString(Session["resss11"]);
        string crdres1 = ass1 + "" + abs1;
        SqlDataAdapter da = new SqlDataAdapter("select * from cms_initiator where changeid='" + changeid + "'", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);
            int cstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Curstatus"]);
            int cftstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["cftstatus"]);
            if (status == 1 && cstatus == 4)
            {
                if (cftstatus == 91)
                {

                    Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert(' " + crdres1 + "')</script>");
                    lblstat.Text = crdres1;
                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Assigned To " + crdres + " Reviewers')</script>");
                    lblstat.Text = "Assigned To " + crdres + " Reviewers";
                }
            }
            else if (status == 1 && cstatus == 9)
            {

                string res = ass + "," + abs;
                // Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('status is:" + ass12 + "" + abs12 + " .')</script>");
                lblstat.Text = "status is:" + ass12 + " " + abs12 + " .";
            }


        }
        else
        {

        }
        Session.Remove("resss");
        Session.Remove("resss1");
        Session.Remove("coordrevs");

        Session.Remove("revres1");
        Session.Remove("revres2");
        Session.Remove("resss1");
        Session.Remove("resss2");

    }

    protected void statusbind()
    {   //Get data row view
        string lsDataKeyValue = Convert.ToString(Session["cmid"]);

        SqlDataAdapter da1 = new SqlDataAdapter("select  * from CMS_Initiator where changeid='" + lsDataKeyValue + "'", Connection);
        Session["changeid"] = lsDataKeyValue;
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);

      
        if (ds1.Tables[0].Rows.Count > 0)
        {
            int s = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);
            int st = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
            int cftst = Convert.ToInt32(ds1.Tables[0].Rows[0]["cftstatus"]);

            if (s == 1 && st == 1)
            {
                // dpEmpdept.Text = "assign to Reviewer";
                lblstat.Text = "Reviewer";
            }
            else if (s == 1 && st == 0)
            {
                //dpEmpdept.Text = "Initiator Reject";
                lblstat.Text = "Initiator";
            }
            else if (s == 1 && st == 2)
            {
                //dpEmpdept.Text = "Initiator pending";
                lblstat.Text = "Initiator";
            }
            else if (s == 3 && st == 0)
            {
                //dpEmpdept.Text = "Reviewer Reject";
                lblstat.Text = "Reviewer";
            }

            else if (s == 3 && st == 2)
            {
                // dpEmpdept.Text = "Reviewer waiting need info from Initiator";
                lblstat.Text = "Initiator";
            }

            else if (s == 3 && st == 1)
            {
                // dpEmpdept.Text = "assign to Coordinator";
                lblstat.Text = "Coordinator";
            }

            else if (s == 4 && st == 0)
            {
                // dpEmpdept.Text = "Coordinator Reject";
                lblstat.Text = "Coordinator";
            }

            else if (s == 4 && st == 2)
            {
                //dpEmpdept.Text = "Reviewer Pending";
                lblstat.Text = "Reviewer";
            }

            else if (s == 4 && st == 1)
            {
                //dpEmpdept.Text = "assigned to CFT";
                //dpAssign.Text = "CFT";

                if (cftst == 91 || cftst == 101)
                {
                    lblstat.Text = "Coordinator";
                    string crdrevs = "";
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from audithistory where Cid='" + lsDataKeyValue + "' and RoleCode=4", Connection);
                    DataSet ds11 = new DataSet();
                    da11.Fill(ds11);

                    string sMyData = string.Empty;
                    foreach (DataRow dr in ds11.Tables[0].Rows)
                    {
                        crdrevs = crdrevs + "," + dr["submireviewer"].ToString();
                    }


                    crdrevs = crdrevs.TrimEnd(',');

                    string[] crdrevis = Regex.Split(crdrevs, ",");
                    string crdres = "";
                    string ass = "";
                    string abs = "";
                    for (int i = 0; i < crdrevis.Length; i++)
                    {
                        crdres = crdrevis[i];
                        Console.WriteLine(crdres);
                        string ab = "";
                        string ba = "";
                        SqlDataAdapter da = new SqlDataAdapter("select Userid from audithistory where Cid='" + lsDataKeyValue + "' and Userid='" + crdres + "' and RoleCode=9", Connection);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            // dpEmpdept.Text = crdres + "completed";
                            if (cftst == 91)
                            {
                                //dpAssign.Text = "CFT";
                                ab = string.Join(",", "CFT" + " " + crdres + "completed");
                            }
                            else if (cftst == 101)
                            {
                                ab = string.Join(",", "RACG" + " " + crdres + "completed");
                            }
                            else
                            {
                                ab = string.Join(",", crdres);
                            }


                            //dpEmpdept.Text = ab + "," + ba;
                            Session["revres1"] = ab;
                        }
                        else
                        {
                            // ba = string.Join(",", crdres + "pending");

                            if (cftst == 91)
                            {
                                ba = string.Join(",", "CFT" + " " + crdres + "pending");
                            }
                            else if (cftst == 101)
                            {
                                ba = string.Join(",", "RACG" + " " + crdres + "pending");
                            }
                            else
                            {
                                ba = string.Join(",", crdres);
                            }
                            //dpEmpdept.Text = crdres + "pending";
                            // dpEmpdept.Text =ab+","+ba;
                            Session["revres2"] = ba;
                        }
                        ass = Convert.ToString(Session["revres1"]);
                        abs = Convert.ToString(Session["revres2"]);

                    }
                    statuscord(lsDataKeyValue);
                    // dpEmpdept.Text = ass + "," + abs;

                }
                else
                {
                    // dpEmpdept.Visible = false;


                    string crdrevs = "";
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM cms_coordinator where changeid='" + lsDataKeyValue + "'", Connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "CMM_LoginUsers");

                    foreach (DataRow dr in ds.Tables["CMM_LoginUsers"].Rows)
                    {
                        string Reviewer = Convert.ToString((dr["Reviewer"]));
                        // int Dept = Convert.ToInt32(ds.Tables[0].Rows[0]["Department"]);
                        SqlDataAdapter da2 = new SqlDataAdapter("select * from cms_coordinator  where Reviewer='" + Reviewer + "'", Connection);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            crdrevs += Convert.ToString(ds2.Tables[0].Rows[0]["Reviewer"]) + ",";
                        }


                    }
                    crdrevs = crdrevs.Remove(crdrevs.Length - 1);
                    // dpEmpdept.Text = crdrevs;
                    // dpAssign.Text = "CFT";
                    Session["coordrevs"] = crdrevs;
                    statuscord(lsDataKeyValue);
                }
            }
            else if (s == 9 && st == 1)
            {

                //dpEmpdept.Text = "CFT assign to coordinator";
                lblstat.Text = "coordinator";

            }
            if (s == 9 && st == 2)
            {
                // dpEmpdept.Text = "CFT pending ";
                lblstat.Text = "CFT";
            }
            if (s == 9 && st == 0)
            {
                //dpEmpdept.Text = "CFT Reject ";
                lblstat.Text = "CFT";
            }

            else if (s == 4 && st == 11)
            {
                //dpEmpdept.Text = "Coordinator assign to RACG";
                //dpAssign.Text = "RACG";
                //dpEmpdept.Text = "Coordinator assign to Approver";
                lblstat.Text = "Approver";
            }
            else if (s == 4 && st == 10)
            {
                //dpEmpdept.Text = "Coordinator Rejected CFT";
                //dpAssign.Text = "Coordinator";
                // dpEmpdept.Text = "Coordinator Rejected CFT";
                lblstat.Text = "Coordinator";
            }
            else if (s == 4 && st == 12)
            {
                //dpEmpdept.Text = "Coordinator pending CFT";
                //dpAssign.Text = "Coordinator";
                // dpEmpdept.Text = "Coordinator pending CFT";
                lblstat.Text = "Coordinator";
            }


            else if (s == 10 && st == 0)
            {
                // dpEmpdept.Text = "RACG Reject";
                lblstat.Text = "RACG";
            }

            else if (s == 10 && st == 2)
            {
                // dpEmpdept.Text = "RACG Pending";
                lblstat.Text = "RACG";
            }

            else if (s == 10 && st == 1)
            {
                // dpEmpdept.Text = "RACG assigned to Coordinator";
                lblstat.Text = "Coordinator";
            }

            else if (s == 4 && st == 21)
            {
                // dpEmpdept.Text = "Coordinator assign to Approver";
                lblstat.Text = "Approver";
            }
            else if (s == 4 && st == 20)
            {
                // dpEmpdept.Text = "Coordinator Rejected RACG";
                lblstat.Text = "Coordinator";
            }
            else if (s == 4 && st == 22)
            {
                // dpEmpdept.Text = "Coordinator pending RACG";
                lblstat.Text = "Coordinator";
            }


            else if (s == 8 && st == 1)
            {
                // dpEmpdept.Text = "Approved ";
                lblstat.Text = "Approver";
            }
            else if (s == 8 && st == 0)
            {
                // dpEmpdept.Text = "Approver Reject ";
                lblstat.Text = "Approver";
            }
            else if (s == 8 && st == 2)
            {
                //dpEmpdept.Text = "Approver pending ";
                lblstat.Text = "Approver";
            }
            else if (s == 4 && st == 81)
            {
                //dpEmpdept.Text = "Coordinator Assign To Approver ";
                lblstat.Text = "Approver";
            }
        }
    }
    protected void ddlitems_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtcomment.SelectedIndex != 0)
        {
            lbltext.Text = Convert.ToString(Session["cid"]);
            if (ddlitems.SelectedItem.Text == "Yes")
            {
                pnl1.Visible = true;
            }
            else
            {
                pnl1.Visible = false;
            }
            pnl111.Visible = true;
            userbody.Visible = true;
            gd.Visible = false;
        }
        else
        {
            ddlitems.SelectedIndex = 0;
            string strScript = "alert('Please Select Department');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
        }

    }
    protected void add_Click(object sender, EventArgs e)
    {        
        dt = (DataTable)ViewState["cur"];
        DataRow dr = dt.NewRow();
        dr["Executor"] = DropDownList1.SelectedItem.Text;
        dr["Reviewer"] = DropDownList2.SelectedItem.Text;
        dr["Target Date"] = DateTime.Now.ToString();
        dt.Rows.Add(dr);
        gd.DataSource = dt;
        gd.DataBind();
        ViewState["cur"] = dt;
        gd.Visible = true;
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        txtdate.Text = "";
        pnl111.Visible = true;
        userbody.Visible = true;  
        
    }
   
    protected void gd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
 
    protected void gd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {        
        int rowid = e.RowIndex;
        dt = (DataTable)ViewState["cur"];
        dt.Rows[rowid].Delete();
        string strScript = "alert('Successfully Deleted.');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
        gd.DataSource = dt;
        gd.DataBind();

    }

     protected void submit_Click(object sender, EventArgs e)
    {
        bindmethod();
    }

     private void bindmethod()
     {

        
         int status = 1;
         int cstatus = 9;
         string s = Convert.ToString(Session["cid"]);
         string pdate = DateTime.Now.ToString();
          string revname=string.Empty;
         cftpop.Changeid1 = lbltext.Text;
         cftpop.Department = txtcomment.SelectedItem.Text;
         cftpop.Impactanalysis = TextBox1.Text;
         cftpop.Executor = DropDownList1.SelectedItem.Text;
         cftpop.Reviewer = DropDownList2.SelectedItem.Text;
         cftpop.Targetdate = txtdate.Text;
         cftpop.Actiontree = ddlitems.SelectedItem.Text;
         cftpop.curstatus = cstatus;

         SqlCommand cmd = new SqlCommand("sp_CMS_CFT", Connection);
         cmd.CommandType = CommandType.StoredProcedure;
         //  cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["USERID"]));
         cmd.Parameters.AddWithValue("@Department", txtcomment.SelectedItem.Text);
         cmd.Parameters.AddWithValue("@ImpactAnalysis", TextBox1.Text);
         cmd.Parameters.AddWithValue("@Executor", DropDownList1.SelectedItem.Text);
         cmd.Parameters.AddWithValue("@Reviewer", DropDownList2.SelectedItem.Text);
         cmd.Parameters.AddWithValue("@TargetDate", txtdate.Text);
         //cmd.Parameters.AddWithValue("@Cate", txtGreet.Text);
         cmd.Parameters.AddWithValue("@changeid", s);
         cmd.Parameters.AddWithValue("@status", status);
         cmd.Parameters.AddWithValue("@cfdcode", ddlitems.SelectedItem.Text);
         cmd.Parameters.AddWithValue("@cstatus", cstatus);
         cmd.Parameters.AddWithValue("@cftrevname", lbluname.Text);
       //  SqlDataAdapter da1 = new SqlDataAdapter("select * from audithistory where Cid='" + lbltext.Text + "' and RoleCode=4 ", Connection);
        
         SqlDataAdapter da1 = new SqlDataAdapter("select * from audithistory where Cid='" + lbltext.Text + "' and RoleCode=4 and submireviewer='"+lbluname.Text+"'", Connection);
         DataSet ds1 = new DataSet();
         da1.Fill(ds1);

         if (ds1.Tables[0].Rows.Count > 0)
         {
             if (ddlitems.SelectedItem.Text == "Yes")
             {
                 if (gd.Visible == true)
                 {
                     foreach (GridViewRow g1 in gd.Rows)
                     {
                         SqlCommand com = new SqlCommand("insert into  CMS_CFT  (Department ,ImpactAnalysis ,Executor ,Reviewer ,TargetDate ,changeid,status,cfdcode,curstatus,cftrevname) values ('" + txtcomment.SelectedItem.Text + "','" + TextBox1.Text + "', '" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "','" + s + "'," + status + ",'" + ddlitems.SelectedItem.Text + "'," + cstatus + ",'"+lbluname.Text+"') ", Connection);
                         Connection.Open();
                         com.ExecuteNonQuery();
                         Connection.Close();
                     }

                 }
                 else
                 {
                    
                     Connection.Open();
                     cmd.ExecuteNonQuery();
                     Connection.Close();
                     //  t = cftmethod.InsertCFT(cftpop.Changeid1, cftpop.Department, cftpop.Impactanalysis, cftpop.Executor, cftpop.Reviewer, cftpop.Targetdate, cftpop.Actiontree, cftpop.curstatus);

                 }
             }
             if (ddlitems.SelectedItem.Text == "No")
             {
                 Connection.Open();
                 cmd.ExecuteNonQuery();
                 Connection.Close();
             }
         
         }
         else
         {

             EnableAllControlss(this.Page.Form.Controls, false);
         
         }


                  audithistory();

             string cssid = lbltext.Text;
             bool ab = methodpriority(cssid);

             if (ab == true)
             {
                 SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set status=1,Curstatus=9,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "'", Connection);
                 DataSet ds = new DataSet();
                 da.Fill(ds);
             }
             else
             {

                 SqlDataAdapter da = new SqlDataAdapter("update cms_cft set revstatus=4 where Changeid='" +lbltext.Text + "' and cftrevname='"+lbluname.Text+"'", Connection);
                 DataSet ds = new DataSet();
                 da.Fill(ds);

                 SqlCommand cmdcft = new SqlCommand("update CMS_Initiator set cftstatus=91,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "' ", Connection);
                 Connection.Open();
                 cmdcft.ExecuteScalar();
                 Connection.Close();
             }

             userbody.Visible = false;
             pnl111.Visible = false;
             Session["gvcid"] = null;
             txtcomment.SelectedIndex = 0;
             DropDownList1.SelectedIndex = 0;
             DropDownList2.SelectedIndex = 0;
             ddlitems.SelectedIndex = 0;
             txtdate.Text = "";
            // gd.Visible = false;

             SqlDataAdapter da11 = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from CMS_Initiator where Changeid='" + lbltext.Text + "' ", Connection);
             DataSet ds11 = new DataSet();
             da11.Fill(ds11);
            
         
         SendMailVeh_Rentals();
         string strScript = "alert('Successfully Submitted and send mail to initiator.');";
         Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
         //assignbind();
       
     }





     private void audithistory()
     {
         // string abc = Convert.ToString(Session["changeidaction"]).ToString();
         try
         {
             string role = "CFT Reviewer";
             int rcode = 9;

           
             Connection.Open();

             string act = "CFT Request Assigned to Coordinator"; 
             string assigned="Coordinator";
             auditpop.auditChangeid = lbltext.Text;
             auditpop.auditrole = role;
             auditpop.audituserid = lbluname.Text;
             auditpop.auditactivity = act;
             auditpop.audittimestamp = DateTime.Now.ToString();
             auditpop.auditrolecode = rcode;
             auditpop.auditassignedto = assigned;

             auditpop.Submitreviewer = DropDownList2.SelectedItem.Text;
             audithistorymethod auditinsert = new audithistorymethod();

             if (ddlitems.SelectedItem.Text == "Yes")
             {

                 foreach (GridViewRow dr in gd.Rows)
                 {
                    
                     for (int i = 0; i < gd.Rows.Count; i++)
                     {

                         auditpop.Submitreviewer = dr.Cells[1].Text;

                     }
                  
                     t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
                         auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);
      
                 }
             
             }
             else if (ddlitems.SelectedItem.Text == "No")
             {

                
                 t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
                     auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);
      
             }
             else
             {

                 
                 t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
                     auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);
      
             }




            

        if (t == true)
             {
                 userbody.Visible = false;
                 pnl111.Visible = false;
               
                 txtcomment.SelectedIndex = 0;
                 DropDownList1.SelectedIndex = 0;
                 DropDownList2.SelectedIndex = 0;
                 ddlitems.SelectedIndex = 0;
                 txtdate.Text = "";
                 gd.Visible = false;

             }
             Connection.Close();

         }
         catch (Exception ex)
         {
             err.insert_exception(ex, excep_page);
             Response.Redirect("CMMErrorpage.aspx");
         }

     }
     private void SendMailVeh_Rentals()
     {
         string Msg = "";
         string UMail = ConfigurationManager.AppSettings["mailid"].ToString();
         string UName = "Initiator";
         try
         {
             MailMessage mm = new MailMessage();
             mm.From = new MailAddress("infocmsproject@gmail.com");
             mm.To.Add(UMail);
             //mm.Bcc.Add("test_indus@yahoo.com");
             Msg += "Dear " + UName + ",<br>" +
                     "<br> Message From Final QA:" ;
             mm.Subject = "Message From Final QA";
             mm.IsBodyHtml = true;
             mm.Body = Msg;
             SmtpClient smtp = new SmtpClient();
             smtp.Send(mm);
         }
         catch (Exception ex)
         {
             string erromes = ex.Message;
         }
     }


    
   
     protected void Button1_Click(object sender, EventArgs e)
     {
         bindmethod();
         SqlCommand cmd = new SqlCommand("update cms_initiator set status = 2,updatedate='" + System.DateTime.Now.ToString() + "' where changeid='" + lbltext.Text + "'", Connection);
         Connection.Open();
         cmd.ExecuteScalar();
         Connection.Close();
        
         string Msg = "";
          string UMail = ConfigurationManager.AppSettings["mailid"].ToString();
         string UName = "Initiator";
         try
         {
             MailMessage mm = new MailMessage();
             mm.From = new MailAddress("infocmsproject@gmail.com");
             mm.To.Add(UMail);
             //mm.Bcc.Add("test_indus@yahoo.com");
             Msg += "Dear " + UName + ",<br>" +
                     "<br> Need Some Changes:";
             mm.Subject = "Message From Final QA ";
             mm.IsBodyHtml = true;
             mm.Body = Msg;
             SmtpClient smtp = new SmtpClient();
             smtp.Send(mm);
         }
         catch (Exception ex)
         {
             string erromes = ex.Message;
         }
         string strScript = "alert('Data was saved and returned to the coordinator.');";
         Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
         //Response.Write(@"<script language='javascript'>alert('Successfully Submitted:  \n');</script>");
     }
     protected void linkassign_Click(object sender, EventArgs e)
     {
         category = "assignment";
         lblassign.CssClass = "active";
         lblitems.CssClass = "lnkcolor";
       
         int userroleid = Convert.ToInt32(Session["userroleid"]);
         if (userroleid == 9)
         {             
             assignbind();
             Button7.Enabled = true;
             submit.Enabled = true; ;
             Button1.Enabled = true;

         }
         else
         {             
             
           
         }
        
         userbody.Visible = false;
         pnl111.Visible = false;


        
     }
     protected void actionbinding()
     {
         
        

     }
     protected void assignbind()
     {

        
         

     }
     protected void lnkact_Click(object sender, EventArgs e)
     {
         category = "act";
         lblitems.CssClass = "active";
         lblassign.CssClass = "lnkcolor";
        
          int userroleid = Convert.ToInt32(Session["userroleid"]);
         if (userroleid == 9)
         {     
         
         actionbinding();
         Button7.Enabled = true;
         submit.Enabled = true;
         Button1.Enabled = true;
         }
         else
         {
            
             EnableAllControlss(this.Page.Form.Controls, false);
             lnklogout.Enabled = true;
             linkassign.Enabled = true;
             lnkact.Enabled = true;
            
            
         }
         
         userbody.Visible = false;
         pnl111.Visible = false;

     }
  

     protected void searchbychangeid(string temp)
     {
         SqlDataAdapter df = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from CMS_Initiator where Changeid='" + temp + "' ", Connection);
         DataSet dh = new DataSet();
         df.Fill(dh);
         if (dh.Tables[0].Rows.Count > 0)
         {
            
            

             SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_CFT where changeid='" + temp + "'", Connection);
             DataSet ds1 = new DataSet();
             da1.Fill(ds1);
           //  Session["search1"] = ds1.ToString();

             if (ds1.Tables[0].Rows.Count > 0)
             {
                 pnl111.Visible = true;
                 userbody.Visible = true; 
                 txtcomment.SelectedItem.Text = ds1.Tables[0].Rows[0]["Department"].ToString();
                 TextBox1.Text = ds1.Tables[0].Rows[0]["ImpactAnalysis"].ToString(); ;
                 ddlitems.SelectedItem.Text = ds1.Tables[0].Rows[0]["cfdcode"].ToString();                 
                 lbltext.Text = temp;               
                 if (ddlitems.SelectedItem.Text == "Yes")
                 {
                    // pnl1.Visible = true;
                     dt = (DataTable)ViewState["cur"];
                     
                     SqlDataAdapter da = new SqlDataAdapter("select * from CMS_CFT where changeid='" + temp + "'", Connection);
                     DataSet dscft = new DataSet();
                     da.Fill(dscft, "cms_coordinator");
                     foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                     {
                         DataRow dr2 = dt.NewRow();
                         dr2["Executor"] = Convert.ToString((dr["Executor"]));
                         dr2["Reviewer"] = Convert.ToString((dr["Reviewer"]));
                         dr2["Target Date"] = Convert.ToString((dr["TargetDate"])); 
                         dt.Rows.Add(dr2);

                     }
                     gd.DataSource = dt;
                     gd.DataBind();
                     gd.Enabled = false;
                     gd.Visible = true;
                     pnl1.Visible = false;
                 }
                 else
                 {
                     pnl1.Visible = false;
                     gd.Visible = false;
                 }
                                  
               
                 
                // EnableAllControls(this.Page.Form.Controls, false);
             }
             else
             {
                  string fundeptrev=string .Empty;

                  SqlDataAdapter dadeptcrd = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + lbltext.Text + "'", Connection);
         
                  DataSet dsdeptcrd = new DataSet();
                     dadeptcrd.Fill(dsdeptcrd);
                     string sMyData = string.Empty;
                     foreach (DataRow dr in dsdeptcrd.Tables[0].Rows)
                     {
                         sMyData = sMyData + "," + dr["Reviewer"].ToString();
                     }


                     sMyData = sMyData.TrimEnd(',');

                     string[] arr = Regex.Split(sMyData, ",");
                     foreach (var word in arr)
                     {
                         //return word;
                         Console.WriteLine(word);
                         fundeptrev = word;
                         if (fundeptrev == lbluname.Text)
                         {
                             txtcomment.SelectedIndex = 0;
                             TextBox1.Text = "";
                             ddlitems.SelectedIndex = 0;
                             DropDownList1.SelectedIndex = 0;
                             DropDownList2.SelectedIndex = 0;
                             txtdate.Text = "";
                             pnl111.Visible = false;
                             userbody.Visible = false;
                             pnl1.Visible = false;
                         }
                         else
                         {
                            
                         }
                     }


                

                 //lbltext.Text = temp;

                 //EnableAllControls(this.Page.Form.Controls, false);
             }
         }
         else
         {
           
             pnl111.Visible = false;
             userbody.Visible = false;
             pnl1.Visible = false;
         }
       
     }
   
     
     protected void lnllogout(object sender, EventArgs e)
     {
         Response.Redirect("default.aspx");
     }
     protected void gvinitiate_pageindexchanging(object source, GridViewPageEventArgs e)
     {
       
         if (category == "assignment")
         {
             assignbind();
         }
         else
             actionbinding();

     }
     protected void clickid(object sender, EventArgs e)
     {
         //ddlid.SelectedIndex = -1;
         LinkButton ln = sender as LinkButton;
         lbltext.Text = ln.CommandArgument.ToString();
         string changeid = lbltext.Text;
         userbody.Visible = true;
         searchbychangeid(changeid);
         int userroleid = Convert.ToInt32(Session["userroleid"]);
         if (userroleid == 9)
         {
             lbltext.Text = changeid;

         }
         else
         {
             EnableAllControlss(this.Page.Form.Controls, false);
             lnklogout.Enabled = true;
             linkassign.Enabled = true;
             lnkact.Enabled = true;

         }   
         

         lblassign.CssClass = "active";
         lblitems.CssClass = "lnkcolor";

        
         pnl111.Visible = true;
         userbody.Visible = true;
         //lbltext.Text = "";
           


     }


     

protected void  Button7_Click(object sender, EventArgs e)
{
    bindmethod();
   

   // string lnkcmgid = Convert.ToString(Session["cmid"]);

    SqlCommand cmd = new SqlCommand("update cms_initiator set status=123 changeid='" + lbltext.Text + "'", Connection);
    Connection.Open();
    cmd.ExecuteScalar();
    Connection.Close();

    string strScript = "alert('Saved & Closed Successfully');";
    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
}
protected void txtcomment_SelectedIndexChanged(object sender, EventArgs e)
{
    lbltext.Text = Convert.ToString(Session["cmid"]);
    DropDownList2.Items.Clear();
    int selDept = Convert.ToInt32(txtcomment.SelectedValue);
    //SqlDataAdapter da = new SqlDataAdapter("select * from CMM_Loginusers where Department=" + selDept + " and RoleCode=3", Connection);
    //DataSet ds = new DataSet();
    //da.Fill(ds);
    //if (ds.Tables[0].Rows.Count > 0)
    //{
    //    DropDownList2.DataSource = ds;
    //    DropDownList2.DataValueField = "UserId";
    //    DropDownList2.DataTextField = "UserId";
    //    DropDownList2.DataBind();
    //}
    //DropDownList2.Items.Insert(0, "Select");


    string rev = "(select * from CMM_Loginusers where Department=" + selDept + " and RoleCode=3) ";
    SqlDataAdapter dabind = new SqlDataAdapter(rev, Connection);
    DataSet dsbind = new DataSet();
    dabind.Fill(dsbind);
    DropDownList2.DataSource = dsbind;
    // DropDownList7.DataValueField = "UserId";
    DropDownList2.DataTextField = "UserId";
    DropDownList2.DataBind();
    DropDownList2.Items.Insert(0, "Select");
}
private bool methodpriority(string chid)
{
    bool a;
    SqlDataAdapter da = new SqlDataAdapter("select Reviewer from cms_coordinator where changeid='" + chid + "'", Connection);
    DataSet ds=new DataSet();
    da.Fill(ds);

    SqlDataAdapter da1 = new SqlDataAdapter("select Userid from audithistory where Cid='" + chid + "' and (RoleCode=9 or RoleCode=10)", Connection);
    DataSet ds1=new DataSet();
    da1.Fill(ds1);
    Boolean val = true;
    if (ds.Tables[0].Rows.Count != ds1.Tables[0].Rows.Count)
    {
        val = false;
     // MessageBox.Show("Not Identical. Rows are not even");
    }
    else
    {
       
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                if (ds.Tables[0].Rows[i][j].ToString() == ds1.Tables[0].Rows[i][j].ToString())
                {
                    //
                    val = true;
                }
                else
                {
                    val = false;
                    //MessageBox.Show(i.ToString() + "," + j.ToString());
                    //break;
                }
            }
        }
        
        
    }
    return val;
}
}
