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
using cmm.audithistory;
using cmm.audithistoryproperties;
using System.Text.RegularExpressions;

public partial class CMS_racg : System.Web.UI.Page
{
    DataTable dt;
    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string temp;
    int strevgd;
    public static string category;
    audithistorymethod auditinsert = new audithistorymethod();
    audithistoryproperties auditpop = new audithistoryproperties();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
           // Response.Redirect("default.aspx");
            Response.RedirectToRoute("logincms");
        }

        string name1 = Convert.ToString(Session["uname"]);
        lbluname.Text = name1;
        //string ab = Convert.ToString(Request.QueryString["parameter"]);
        string ab = Convert.ToString(Page.RouteData.Values["parameter"]);
        string gid = Convert.ToString(Session["gvcid"]);


        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;
        string s = Convert.ToString(Session["cid"]);
        lbltext.Text = s;
        int userroleid = Convert.ToInt32(Session["userroleid"]);
        string changeid = Convert.ToString(Session["cmid"]);

        if (!IsPostBack)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Action Item Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Executor", typeof(string)));
            dt.Columns.Add(new DataColumn("Reviewer", typeof(string)));
            dt.Columns.Add(new DataColumn("Date", typeof(string)));
            ViewState["cur"] = dt;
            if (userroleid == 10 || userroleid == 3)
            {
                string userregula = lbluname.Text;
                if (userregula == "RARev1" || userregula == "RARev2")
                {

                    searchbychangeid(changeid);
                    pnl111.Visible = true;
                    content.Visible = true;

                }
                else
                {

                    searchbychangeid(changeid);
                    pnl111.Visible = true; ;
                    content.Visible = true;
                    pnl1.Visible = false;

                    Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
                searchbychangeid(changeid);
                EnableAllControlscolor(this.Page.Form.Controls, false);
            }
           
            category = "assignment";
            lblassign.CssClass = "active";
            lblitems.CssClass = "lnkcolor";
            statusbind(changeid);
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
  
    private void searchbychangeid(string changeid)
    {
        content.Visible = true;
        SqlDataAdapter da1 = new SqlDataAdapter("select  substring(cdesc,1,18)as cdesc,*  from CMS_Initiator where Changeid='" + changeid + "'", Connection);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {         
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_CGReview where changeid='" + changeid + "'", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                pnl111.Visible = true;
                content.Visible = true;
                lbltext.Text = changeid;
                DdlRegularity.SelectedItem.Text = ds.Tables[0].Rows[0]["impregular"].ToString();
                Txtcomment.Text = ds.Tables[0].Rows[0]["Comments"].ToString(); ;
                ddlitems.SelectedItem.Text = ds.Tables[0].Rows[0]["actree"].ToString();
              
                if (ddlitems.SelectedItem.Text == "Yes")
                {
                   // pnl1.Visible = true;
                    dt = (DataTable)ViewState["cur"];

                    SqlDataAdapter da2 = new SqlDataAdapter("select * from CMS_CGReview where changeid='" + changeid + "'", Connection);
                    DataSet dscft = new DataSet();
                    da2.Fill(dscft, "cms_coordinator");
                    foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                    {
                        DataRow dr2 = dt.NewRow();
                        dr2["Action Item Description"] = Convert.ToString((dr["actnitmdesc"]));
                        dr2["Executor"] = Convert.ToString((dr["Executor"]));
                        dr2["Reviewer"] = Convert.ToString((dr["Reviewer"]));
                        dr2["Date"] = Convert.ToString((dr["TargetDate"]));
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
                }          

            }
            else
            {
                lbltext.Text = changeid;
                pnl111.Visible = true;
                content.Visible = true; 
                Txtcomment.Text = "";
                ddlitems.SelectedIndex = 0;
                DropDownList1.SelectedIndex = 0;
                DropDownList2.SelectedIndex = 0;
                txtdate.Text = "";
               
            }
        }
        else
        {
           
            pnl111.Visible = true;
            content.Visible = true;
        }
       

    }
    public void EnableAllControls(ControlCollection cc, bool enable)
    {
        foreach (Control c in cc)
        {
            try { EnableAllControls(c.Controls, enable); }
            catch { }
            if (c.GetType() == typeof(TextBox)) { try { ((TextBox)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(DropDownList)) { try { ((DropDownList)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(Button)) { try { ((Button)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(LinkButton)) { try { ((LinkButton)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(HtmlInputText)) { try { ((HtmlInputText)c).Attributes.Add("disabled", "true"); } catch { } }
        }
    }
    
   
    protected void ddlitems_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbltext.Text = Convert.ToString(Session["cid"]);
        if (ddlitems.SelectedItem.Text == "Yes")
        {
            int userdept = Convert.ToInt32(Session["userdepartment"]);
            SqlDataAdapter da = new SqlDataAdapter("select * from CMM_Loginusers where Department=" + userdept + " and RoleCode=3", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownList2.DataSource = ds;
            DropDownList2.DataValueField = "UserId";
            DropDownList2.DataTextField = "UserId";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "Select");
            pnl1.Visible = true;
            gd.Visible = false;

        }
        else
        {            
            pnl1.Visible = false;
            gd.Visible = false;
        }
    }
  
    protected void add_Click(object sender, EventArgs e)
    {
        string abc = "racggrid";
        Session["racggrid"] = abc;
        dt = (DataTable)ViewState["cur"];
        DataRow dr = dt.NewRow();
        dr["Action Item Description"] = action.Text;
        dr["Executor"] = DropDownList1.SelectedItem.Text;
        dr["Reviewer"] = DropDownList2.SelectedItem.Text;
        dr["Date"] = txtdate.Text;
        dt.Rows.Add(dr);
        gd.DataSource = dt;
        gd.DataBind();
        gd.Visible = true;
        ViewState["cur"] = dt;
        action.Text = "";
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        txtdate.Text = "";
       
        pnl111.Visible = true;
    }
   
    protected void gd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {   
        int rowid = e.RowIndex;
        dt = (DataTable)ViewState["cur"];
        dt.Rows[rowid].Delete();
        gd.DataSource = dt;
        gd.DataBind();

    }
    protected void method()
    {

        int cstatus = 10;
        int status = 1;
        //Connection.Open();

      //  string s = Convert.ToString(Session["cid"]);
        string s = lbltext.Text;
        SqlCommand cmd = new SqlCommand("sp_CMS_CGReview", Connection);
        cmd.CommandType = CommandType.StoredProcedure;
        //  cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["USERID"]));       
        cmd.Parameters.AddWithValue("@impregular", DdlRegularity.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@Comments", Txtcomment.Text);
        cmd.Parameters.AddWithValue("@actnitmdesc", action.Text);

        cmd.Parameters.AddWithValue("@Executor", DropDownList1.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@Reviewer", DropDownList2.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@TargetDate", txtdate.Text);
        //cmd.Parameters.AddWithValue("@Cate", txtGreet.Text);
        cmd.Parameters.AddWithValue("@changeid", s);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@cstatus", cstatus);
        cmd.Parameters.AddWithValue("@actree", ddlitems.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@username", lbluname.Text);

        string pdate = DateTime.Now.ToString();
        string racgg = Convert.ToString(Session["racggrid"]);
        if (racgg == "racggrid")
        {
            if (gd.Visible == true)
            {
                foreach (GridViewRow g1 in gd.Rows)
                {

                    SqlCommand com = new
                     SqlCommand("insert into  CMS_CGReview  (Comments ,actnitmdesc ,Executor ,Reviewer ,TargetDate ,changeid,status,actree,impregular,Curstatus,username) values ('" + Txtcomment.Text + "', '" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "','" + s + "'," + status + ",'" + ddlitems.SelectedItem.Text + "','" + DdlRegularity.SelectedItem.Text + "'," + cstatus + ",'" + lbluname.Text + "') ", Connection);
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
            }



        }
        else
        {
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        Txtcomment.Text = "";
        // ddlChngOwnrAction.SelectedIndex = 0;
        action.Text = "";
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DdlRegularity.SelectedIndex = 0;
        ddlitems.SelectedIndex = 0;
        txtdate.Text = "";
        gd.Visible = false;


        string cssid = lbltext.Text;
        bool ab = methodpriority(cssid);

        if (ab == true)
        {
            SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set status=1,Curstatus=10,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "'", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
        }
        else
        {

            SqlDataAdapter da = new SqlDataAdapter("update cms_cgreview set cstatus=4 where Changeid='" + lbltext.Text + "' and username='" + lbluname.Text + "'", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            SqlCommand cmdcft = new SqlCommand("update CMS_Initiator set cftstatus=101 where Changeid='" +lbltext.Text + "' ", Connection);
            Connection.Open();
            cmdcft.ExecuteScalar();
            Connection.Close();
        }

       
        SendMailVeh_Rentals();

        Session["gvcid"] = null;
        audithistory();
     
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Successfully Submitted. and send mail to initiator')", true);
       
        Session.Remove("racggrid");
    }
  
    protected void submit_Click(object sender, EventArgs e)
    {
        method();
       
    }

    protected void audithistory()
    {

        
        string role = "RACG";
        string activity = "RA/CG Approved The Request";
        int rcode = 10;
        string assigned = "Coordinator";
        //Connection.Open();
      //  SqlCommand cmdr = new SqlCommand("Sp_AuditHistory", Connection);
       // cmdr.CommandType = CommandType.StoredProcedure;
       
       
       
        auditpop.auditChangeid = lbltext.Text;
        auditpop.auditrole = role;
        auditpop.audituserid = lbluname.Text;
        auditpop.auditactivity = activity;
        auditpop.audittimestamp = DateTime.Now.ToString();
        auditpop.auditrolecode = rcode;
        auditpop.auditassignedto = assigned;
        auditpop.Submitreviewer = DropDownList2.SelectedItem.Text;
        bool t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
                    auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);
           
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
                    "<br>Message From RA/CG :" ;
            mm.Subject = "Message From CMS RA/CG";
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

   
   
    protected void return_Click(object sender, EventArgs e)
    {
        method();
        SqlCommand cmd = new SqlCommand("update CMS_Initiator set Curstatus=10,status=2,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "'", Connection);
        Connection.Open();
        cmd.ExecuteScalar();
        Connection.Close();
    }
   
    protected void statusracg()
    {
        string crdres = Convert.ToString(Session["racgcoordrevs"]);

        string ass = Convert.ToString(Session["racgresss"]);
        string abs = Convert.ToString(Session["racgresss1"]);

        string ass1 = Convert.ToString(Session["racgrevres1"]);
        string abs1 = Convert.ToString(Session["racgrevres2"]);


        string ass12 = Convert.ToString(Session["racgresss1"]);
        string abs12 = Convert.ToString(Session["racgresss11"]);
        string crdres1 = ass1 + "" + "," + "" + abs1;
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
               // Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('status is:" + ass12 + "" + abs12 + " .')</script>");
                  lblstat.Text="status is:" + ass12 + "" + abs12 + " .";
            }


        }
        else
        {

        }
        Session.Remove("racgresss");
        Session.Remove("racgresss1");
        Session.Remove("racgcoordrevs");

        Session.Remove("racgrevres1");
        Session.Remove("racgrevres2");
        Session.Remove("racgresss1");
        Session.Remove("racgresss2");

    }

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

    protected void statusbind(string changeid)
    {

        string lsDataKeyValue = changeid;

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
    //protected void statusbind(string changeid)
    //{  
        
    //        string lsDataKeyValue = changeid;
    //        SqlDataAdapter da1 = new SqlDataAdapter("select  * from CMS_Initiator where changeid='" + lsDataKeyValue + "'", Connection);         
    //        DataSet ds1 = new DataSet();
    //        Session["cid"] = lsDataKeyValue;
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
    //                //dpEmpdept.Text = "Initiator Reject";
    //                lblstat.Text = "Initiator";
    //            }
    //            else if (s == 1 && st == 2)
    //            {
    //                //dpEmpdept.Text = "Initiator pending";
    //                lblstat.Text = "Initiator";
    //            }
    //            else if (s == 3 && st == 0)
    //            {
    //                //dpEmpdept.Text = "Reviewer Reject";
    //                lblstat.Text = "Reviewer";
    //            }

    //            else if (s == 3 && st == 2)
    //            {
    //                //dpEmpdept.Text = "Initiator Pending";
    //                lblstat.Text = "Initiator";
    //            }

    //            else if (s == 3 && st == 1)
    //            {
    //                //dpEmpdept.Text = "assign to Coordinator";
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
    //                   // dpEmpdept.Visible = false;
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

    //                    string[] crdrevis = System.Text.RegularExpressions.Regex.Split(crdrevs, ",");
    //                    string crdres = "";
    //                    string ass = "";
    //                    string abs = "";
    //                    for (int i = 0; i < crdrevis.Length; i++)
    //                    {
    //                        crdres = crdrevis[i];
    //                        Console.WriteLine(crdres);
    //                        string ab = "";
    //                        string ba = "";
    //                        SqlDataAdapter da = new SqlDataAdapter("select Userid from audithistory where Cid='" + lsDataKeyValue + "' and Userid='" + crdres + "' and RoleCode=10", Connection);
    //                        DataSet ds = new DataSet();
    //                        da.Fill(ds);
    //                        if (ds.Tables[0].Rows.Count > 0)
    //                        {
    //                            if (cftst == 91)
    //                            {
    //                                // dpEmpdept.Text = crdres + "completed";
    //                                ab = string.Join(",", "CFT" + " " + crdres + "completed");
    //                            }
    //                            else if (cftst == 101)
    //                            {
    //                                // dpEmpdept.Text = crdres + "completed";
    //                                ab = string.Join(",", "RACG" + " " + crdres + "completed");
    //                            }
    //                            // ab ="CFT"+""+crdres+""+"Reviewer Assign To Coordinator";
    //                            //dpEmpdept.Text = ab + "," + ba;
    //                            Session["racgrevres1"] = ab;
    //                        }
    //                        else
    //                        {
    //                            if (cftst == 91)
    //                            {
    //                                ba = string.Join(",", crdres + "pending");
    //                            }
    //                            else if (cftst == 101)
    //                            {
    //                                ba = string.Join(",", crdres + "pending");
    //                            }
    //                            //dpEmpdept.Text = crdres + "pending";
    //                            // dpEmpdept.Text =ab+","+ba;
    //                            Session["racgrevres2"] = ba;

    //                        }
    //                        ass = Convert.ToString(Session["racgrevres1"]);
    //                        abs = Convert.ToString(Session["racgrevres2"]);

    //                        statusracg();

                           
    //                    }
    //                }
    //                else
    //                {
    //                    string ab = lbluname.Text;
    //                    if (ab != "RARev1" && ab != "RARev2")
    //                    {

    //                        //dpEmpdept.Text = "Assigned to CFT";
    //                        lblstat.Text = "CFT";
    //                    }
    //                    else if (ab == "RARev1" || ab == "RARev2")
    //                    {
    //                       // dpEmpdept.Text = "Assigned to RACG";
    //                        lblstat.Text = "RACG";
    //                    }
    //                }



                   
    //            }
    //            else if (s == 9 && st == 1)
    //            {
    //               // dpEmpdept.Text = "CFT assign to coordinator ";
    //                lblstat.Text = "Coordinator";
    //            }
    //            if (s == 9 && st == 2)
    //            {
    //               // dpEmpdept.Text = "CFT pending ";
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
    //                string fnrev = Convert.ToString(dscft.Tables[0].Rows[0]["funreview"]);
    //                string acttree = Convert.ToString(dscft.Tables[0].Rows[0]["actitmtree"]);
    //                if (fnrev == "Yes" && acttree == "No")
    //                {
    //                   // dpEmpdept.Text = "assigned to Approver";
    //                    lblstat.Text = "Approver";
    //                }
    //                else
    //                {
    //                  //  dpEmpdept.Text = "assigned to RACG";
    //                    lblstat.Text = "RACG";
    //                }

    //            }
    //            else if (s == 4 && st == 10)
    //            {
    //                //dpEmpdept.Text = "Coordinator Rejected CFT";
    //                lblstat.Text = "Coordinator";
    //            }
    //            else if (s == 4 && st == 12)
    //            {
    //               // dpEmpdept.Text = "Coordinator pending CFT";
    //                lblstat.Text = "Coordinator";
    //            }


    //            else if (s == 10 && st == 0)
    //            {
    //                //dpEmpdept.Text = "RACG Reject";
    //                lblstat.Text = "RACG";
    //            }

    //            else if (s == 10 && st == 2)
    //            {
    //               // dpEmpdept.Text = "RACG Pending";
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
    //                //dpEmpdept.Text = "Coordinator Rejected RACG";
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
    //                lblstat.Text = "Approved";
    //            }
    //            else if (s == 8 && st == 0)
    //            {
    //               // dpEmpdept.Text = "Approver Reject ";
    //                lblstat.Text = "Approver";
    //            }
    //            else if (s == 8 && st == 2)
    //            {
    //               // dpEmpdept.Text = "Approver pending ";
    //                lblstat.Text = "Approver";
    //            }

    //        }
    //    }
    

    protected void linkassign_Click(object sender, EventArgs e)
    {
        category = "assignment";
        lblassign.CssClass = "active";
        lblitems.CssClass = "lnkcolor";
       
        int userroleid = Convert.ToInt32(Session["userroleid"]);
        if (userroleid == 10)
        {
            // user.Visible = false;          

            assignbind();
            //pnl1.Visible = false;
        }
        else
        {
            EnableAllControls(this.Page.Form.Controls, false);
            lnklogout.Enabled = true;
            linkassign.Enabled = true;
            lnkact.Enabled = true;
           
        }
        content.Visible = false;
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
          if (userroleid == 10)
          {
              
              content.Visible = false;
            
              tdbtn.Visible = true;
             
              actionbinding();
              BtnSave.Enabled = true;
              btnsubmit.Enabled = true;
              Btnreturn.Enabled = true;
              pnl111.Visible = false; ;
              content.Visible = false;
              pnl1.Visible = false;
          }
          else
          {
              EnableAllControls(this.Page.Form.Controls, false);
              lnklogout.Enabled = true;
              linkassign.Enabled = true;
              lnkact.Enabled = true;
             
          }

    }
   
   
    protected void lnllogout(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void clickid(object sender, EventArgs e)
    {
        LinkButton ln = sender as LinkButton;
        lbltext.Text = ln.CommandArgument.ToString();
        string changeid = ln.CommandArgument.ToString();
        Session["cid1"] = changeid;
        
        int userroleid = Convert.ToInt32(Session["userroleid"]);
        if (userroleid == 10)
        {
            searchbychangeid(changeid);
        }
        else
        {
            EnableAllControls(this.Page.Form.Controls, false);
            lnklogout.Enabled = true;
            linkassign.Enabled = true;
            lnkact.Enabled = true;

        }
        searchbychangeid(changeid);

        content.Visible = true;
       
        pnl111.Visible = true;


        //lbltext.Text = "";
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        method();
        SqlCommand cmd = new SqlCommand("update CMS_Initiator set Curstatus=10,status=123,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "'", Connection);
        Connection.Open();
        cmd.ExecuteScalar();
        Connection.Close();
    }


    protected void DdlRegularity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlRegularity.SelectedItem.Text == "Yes")
        {
            com.Visible = true;
        }
        else
        {
            com.Visible = false;
        }
    }
    private bool methodpriority(string chid)
    {
        bool a;
        SqlDataAdapter da = new SqlDataAdapter("select Reviewer from cms_coordinator where changeid='" + chid + "'", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);

        SqlDataAdapter da1 = new SqlDataAdapter("select Userid from audithistory where Cid='" + chid + "' and (RoleCode=10 or RoleCode=9)", Connection);
        DataSet ds1 = new DataSet();
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
