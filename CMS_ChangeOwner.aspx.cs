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
using System.Net.Mail;
using cmm.audithistory;
using cmm.audithistoryproperties;
using cmm.errorexcep;
using System.Text.RegularExpressions;
public partial class CMS_ChangeOwner : System.Web.UI.Page
{

    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string st;
    DataTable dt;
    string temp;
    int strevgd;
    public static string category;
    string act = string.Empty;
    bool t;
    int userroleid;
    string userrolename;
    string b;
    audithistorymethod auditinsert = new audithistorymethod();
    audithistoryproperties auditpop = new audithistoryproperties();
    static string excep_page = "CMS_ChangeOwner.aspx";
    error err = new error();
    string assigned;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
            // string strScript = "alert('Session Closed.Please ReLogin into medqms');";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Session Closed.Please ReLogin into medqms')", true);
            
            //Response.Redirect("default.aspx");
            Response.RedirectToRoute("logincms");
        }
        string name1 = Convert.ToString(Session["uname"]);
        lbluname.Text = name1;
        userroleid = Convert.ToInt32(Session["userroleid"]);
        userrolename = Convert.ToString(Session["userrolename"]);
        //string ab = Convert.ToString(Request.QueryString["parameter"]);
        //string cmrev = Convert.ToString(Request.QueryString["reviewer"]);
        string ab = Convert.ToString(Page.RouteData.Values["parameter"]);
        string cmrev = Convert.ToString(Page.RouteData.Values["reviewer"]);
        string umrolname = Convert.ToString(Session["umroles"]);
        // string gid = Convert.ToString(Session["gvcid"]);
        string lnkcmgid = Convert.ToString(Session["cmid"]);
        pnl111.Visible = false;
       
       
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;
        //Session["id1"] = "";
        Connection.Open();
        //links.Visible = false;
        string str = "select Changeid from CMS_Status1 where status=1 ";
        SqlCommand cmd1 = new SqlCommand(str, Connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        st = Convert.ToString(ds.Tables[0].Rows[0][0]);
        Connection.Close();
        if (!IsPostBack)
        {

            dt = new DataTable();

            dt.Columns.Add(new DataColumn("ACTITEMDESC", typeof(string)));

            dt.Columns.Add(new DataColumn("Executor", typeof(string)));

            dt.Columns.Add(new DataColumn("Reviewer", typeof(string)));

            dt.Columns.Add(new DataColumn("Approver", typeof(string)));

            dt.Columns.Add(new DataColumn("TimeLine", typeof(string)));
            ViewState["cur"] = dt;
            DataSet ds11 = new DataSet();
            if (umrolname == "Initiator&Reviewer")
            {
               
                if (ab == "gidcid")
                {


                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "'", Connection);

                    da11.Fill(ds11);
                    if (ds11.Tables[0].Rows.Count > 0)
                    {
                        SqlDataAdapter da111 = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "' or ((status=1 and Curstatus=1) or (status=0 and Curstatus=3) or  (status=2 and Curstatus=3) or  (status=1 and Curstatus=3) ) and changeid='" + lnkcmgid + "'", Connection);
                        DataSet ds112 = new DataSet();
                        da111.Fill(ds112);
                        if (ds112.Tables[0].Rows.Count > 0)
                        {
                            bindmethod();
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        SqlDataAdapter das = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where  changeid='" + lnkcmgid + "'", Connection);
                        DataSet dss = new DataSet();
                        das.Fill(dss);
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            
                            bindmethod();
                        }
                        else
                        {

                            //recid.Text = lbluname.Text;
                          
                        }
                    }
                    
                    
                }
            }
            else 
            if (userroleid == 3)
            {
                // EnableAllControls(this.Page.Form.Controls, false);
               
                if (ab == "gidcid")
                {

                    
                SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "'", Connection);
               
                da11.Fill(ds11);
                if (ds11.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter da111 = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "' or ((status=1 and Curstatus=1) or (status=0 and Curstatus=3) or  (status=1 and Curstatus=3) ) and changeid='" + lnkcmgid + "'", Connection);
                    DataSet ds112 = new DataSet();
                    da111.Fill(ds112);
                    if (ds112.Tables[0].Rows.Count > 0)
                    {
                       

                        SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + lnkcmgid + "'", Connection);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                      

                        int status = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
                        int curstatus = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);

                        if (status == 1 && curstatus == 1)
                        {
                            bindmethod();
                           
                        }
                       else
                        {
                            bindmethod();
                            EnableAllControlscolor(this.Page.Form.Controls, false);
                        }
                       
                    }
                    else
                    {
                       
                    }
                }
                else
                {
                    SqlDataAdapter das = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where changeid='" + lnkcmgid + "'", Connection);
                    DataSet dss = new DataSet();
                    das.Fill(dss);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                       
                        SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + lnkcmgid + "'", Connection);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        int status = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
                        int curstatus = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);
                        if (status == 1 && curstatus == 1)
                        {
                            bindmethod();

                        }
                        else
                        {
                            bindmethod();
                            EnableAllControlscolor(this.Page.Form.Controls, false);
                        }
                       
                        
                    }
                    else
                    {

                        
                    }
                }

              
                }
            } 
          

            else if (userroleid == 8 || userroleid == 9 || userroleid == 10||userroleid==4)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
                if (ab == "gidcid")
                {

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + lnkcmgid + "'", Connection);

                    da11.Fill(ds11);
                    if (ds11.Tables[0].Rows.Count > 0)
                    {
                        SqlDataAdapter da111 = new SqlDataAdapter("select * from CMS_Initiator where  changeid='" + lnkcmgid + "'", Connection);
                        DataSet ds112 = new DataSet();
                        da111.Fill(ds112);
                        if (ds112.Tables[0].Rows.Count > 0)
                        {
                            
                            //category = "act";
                            bindmethod();


                        }
                        else
                        {
                           
                        }
                    }
                   
                 
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                }

            }

            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
                if (ab == "gidcid")
                {

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "'", Connection);

                    da11.Fill(ds11);
                    if (ds11.Tables[0].Rows.Count > 0)
                    {
                        SqlDataAdapter da111 = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "' or ((status=1 and Curstatus=1) or (status=0 and Curstatus=3)  or  (status=1 and Curstatus=3) ) and changeid='" + lnkcmgid + "'", Connection);
                        DataSet ds112 = new DataSet();
                        da111.Fill(ds112);
                        if (ds112.Tables[0].Rows.Count > 0)
                        {
                           
                            bindmethod();


                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        SqlDataAdapter das = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where submit='" + lbluname.Text + "' and ((status=1 and Curstatus=1) or (status=0 and Curstatus=3)  or  (status=1 and Curstatus=3) ) and changeid='" + lnkcmgid + "'", Connection);
                        DataSet dss = new DataSet();
                        das.Fill(dss);
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            
                            bindmethod();
                        }
                        else
                        {

                           
                        }

                    }
                   
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                    
                }

            }

            statusbind();
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

    protected void add_Click(object sender, EventArgs e)
    {
        string meth = "action addgrid";
        Session["addgrid"] = meth;

        dt = (DataTable)ViewState["cur"];
        DataRow dr = dt.NewRow();
        dr["ACTITEMDESC"] = txtcomments.Text;
        dr["Executor"] = DropDownList2.SelectedItem.Text;
        dr["Reviewer"] = DropDownList3.SelectedItem.Text;
        dr["Approver"] = DropDownList4.SelectedItem.Text;
        dr["TimeLine"] = TextBox1.Text;
        dt.Rows.Add(dr);
        gd.DataSource = dt;
        gd.DataBind();
        ViewState["cur"] = dt;
        gd.Visible = true;

        DropDownList3.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;
        txtcomments.Text = "";
        TextBox1.Text = "";
        pnl111.Visible = true;
     

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
        pnl111.Visible = true;
    
        pnl1.Visible = true;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)

    {
        int deptid = Convert.ToInt32(Session["userdepartment"]);
        if (DropDownList1.SelectedItem.Text == "Yes")
        {
            owner1.Visible = true;
            pnl1.Visible = true;
            //gd.Visible = true;
            pnl111.Visible = true;
           

            SqlDataAdapter da = new SqlDataAdapter("select * from CMM_Loginusers where Department="+deptid+" and RoleCode=3", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownList3.DataSource = ds;
            DropDownList3.DataValueField = "UserId";
            DropDownList3.DataTextField = "UserId";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "Select");
        }
        else
        {
            owner1.Visible = false;
            pnl1.Visible = false;
            gd.Visible = false;
            pnl111.Visible = true;
           

        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {

        method();

    }
    protected void method()
    {
        string updatetime = System.DateTime.Now.ToString();

        try
        {
            pnl111.Visible = true;
          
           
            int cstatus = 3;
            int status = 1;
            int st = 0;
            string imgpath = "";
           
            SqlCommand cmd = new SqlCommand("sp_CMS_Reviewer", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HODACTION", Convert.ToString(ddlChngOwnrAction.SelectedItem.Text));
            cmd.Parameters.AddWithValue("@Outcome", Convert.ToString(txtChngOwnrComments.Text));
            cmd.Parameters.AddWithValue("@ATTACHMENTS", Convert.ToString(imgpath));
            cmd.Parameters.AddWithValue("@ACTITEMDESC", Convert.ToString(txtcomments.Text));
            cmd.Parameters.AddWithValue("@Executor", Convert.ToString(DropDownList2.SelectedItem.Text));
            //cmd.Parameters.AddWithValue("@Cate", txtGreet.Text);
            cmd.Parameters.AddWithValue("@Reviewer", Convert.ToString(DropDownList3.SelectedValue));
            cmd.Parameters.AddWithValue("@Approver", Convert.ToString(DropDownList4.SelectedItem.Text));
            cmd.Parameters.AddWithValue("@TimeLine", Convert.ToString(TextBox1.Text));
            cmd.Parameters.AddWithValue("@cstatus", cstatus);
            cmd.Parameters.AddWithValue("@actitem", Convert.ToString(DropDownList1.SelectedItem.Text));
            cmd.Parameters.AddWithValue("@changeid", Convert.ToString(lbltext.Text));
            if (ddlChngOwnrAction.SelectedItem.Text == "Approve")
            {
                cmd.Parameters.AddWithValue("@status", status);
            }
            else if (ddlChngOwnrAction.SelectedItem.Text == "Return for additional info")
            {
                cmd.Parameters.AddWithValue("@status", 2);
            }
            else
            {
                cmd.Parameters.AddWithValue("@status", st);
            }
            string a = "";
            cmd.Parameters.AddWithValue("@submitto", Convert.ToString(a));
          

            if (DropDownList1.SelectedItem.Text == "Yes")
            {
                pnl1.Visible = true;
                pnl111.Visible = true;
               
                string ab = Convert.ToString(Session["addgrid"]);
                if (ab == "action addgrid")
                {
                    gd.Visible = true;
                    if (gd.Visible == true)
                    {
                        foreach (GridViewRow g1 in gd.Rows)
                        {
                            string pdate = DateTime.Now.ToString();
                            if (ddlChngOwnrAction.SelectedItem.Text == "Approve")
                            {
                                strevgd = 1;
                            }
                            else if (ddlChngOwnrAction.SelectedItem.Text == "Return for additional info")
                            { strevgd = 2; }
                            else
                            {
                                strevgd = 0;
                            }


                            SqlCommand com = new
                           SqlCommand("insert into  CMS_Reviewer  (HODACTION ,Outcome ,ATTACHMENTS ,ACTITEMDESC ,Executor ,Reviewer ,Approver ,TimeLine ,changeid,submitto,status,Curstatus,actitem) values ('" + ddlChngOwnrAction.SelectedItem.Text + "','" + txtChngOwnrComments.Text + "','" + imgpath + "', '" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "','" + g1.Cells[4].Text + "','" + lbltext.Text + "','" + ddlChngOwnrAction.SelectedItem.Text + "','" + strevgd + "'," + cstatus + ",'" + DropDownList1.SelectedItem.Text + "') ", Connection);
                            Connection.Open();
                            com.ExecuteNonQuery();
                            Connection.Close();
                            string s = ddlChngOwnrAction.SelectedItem.Text;
                            SendMailVeh_Rentals(s);
                        }

                    }
                }
                else
                {

                    Connection.Open();

                    cmd.ExecuteNonQuery();
                    Connection.Close();
                }
            }
            else if (DropDownList1.SelectedItem.Text == "No")
            {
                pnl111.Visible = false;
              
                pnl1.Visible = false;
                gd.Visible = false;

                Connection.Open();

                cmd.ExecuteNonQuery();
                Connection.Close();
            }


            if (ddlChngOwnrAction.SelectedItem.Text == "Approve")
            {

                SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set Curstatus=3 , status=1,updatedate='" + updatetime + "' where Changeid='" + lbltext.Text + "'", Connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //  UserControl(lbltext.Text);
                string s = ddlChngOwnrAction.SelectedItem.Text;
                SendMailVeh_Rentals(s);


            }
            else if (ddlChngOwnrAction.SelectedItem.Text == "Return for additional info")
            {
                SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set Curstatus=3 , status=2,updatedate='" + updatetime + "' where Changeid='" + lbltext.Text + "'", Connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                string s = ddlChngOwnrAction.SelectedItem.Text;
                SendMailVeh_Rentals(s);
                // UserControl(lbltext.Text);

            }
            else if (ddlChngOwnrAction.SelectedItem.Text == "Recommend for Reject")
            {
                SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set Curstatus=3 , status=0,updatedate='" + updatetime + "' where Changeid='" + lbltext.Text + "'", Connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //  UserControl(lbltext.Text);
                string s = ddlChngOwnrAction.SelectedItem.Text;
                SendMailVeh_Rentals(s);

            }
            SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + lbltext.Text + "'", Connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {

                lblwait.Visible = false;
            }
            string strScript = "alert('Successfully Submitted. and send mail to initiator');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
            audithistory();


            TextBox1.Text = "";
            // ddlChngOwnrAction.SelectedIndex = 0;
            DropDownList4.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
            ddlChngOwnrAction.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;

            txtChngOwnrComments.Text = "";
            txtcomments.Text = "";
            lbltext.Text = "";

            gd.Visible = false;
            //actionbinding();
            //  Session["gvcid"] = null;

        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }
        Session["updatetime1"] = updatetime;
    }

    private void audithistory()
    {
        // string abc = Convert.ToString(Session["changeidaction"]).ToString();
        try
        {
            string imgpath = "";
            string role = "Reviewer";
            int rcode = 3;

            if (ddlChngOwnrAction.SelectedItem.Text == "Approve")
            {
                act = "Reviewer Approved The Request";
            }
            else if (ddlChngOwnrAction.SelectedItem.Text == "Recommend for Reject")
            {
                act = "Reviewer Reject The Request";
            }
            else if (ddlChngOwnrAction.SelectedItem.Text == "Return for additional info")
            {
                act = "Reviewer Return The Request for additional information";
            }
            Connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + lbltext.Text + "'", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);
            int cstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Curstatus"]);
            if (status == 1 && cstatus == 3)
            {
                assigned = "coordinator";
            }
            else if (status == 2 && cstatus == 3)
            {
                assigned = "Reviewer";
            }
            else if (status == 0 && cstatus == 3)
            {
                assigned = "Reviewer Reject";
            }
            else if (status == 1 && cstatus == 3)
            {
                assigned = "Coordinator";
            }

           
            auditpop.auditChangeid = lbltext.Text;
            auditpop.auditrole = role;
            auditpop.audituserid = lbluname.Text;
            auditpop.auditactivity = act;
            auditpop.audittimestamp = DateTime.Now.ToString();
            auditpop.auditrolecode = rcode;
            auditpop.auditassignedto = assigned;


            if (DropDownList1.SelectedItem.Text == "Yes")
            {

                foreach (GridViewRow g1 in gd.Rows)
                {

                    for (int i = 0; i < gd.Rows.Count; i++)
                    {
                        auditpop.Submitreviewer = g1.Cells[2].Text;
                    }
                    t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
            auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);

                }
            }
            else if (DropDownList1.SelectedItem.Text == "No")
            {
                auditpop.Submitreviewer = "not select";

                t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
              auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);
            }
            else
            {

                auditpop.Submitreviewer = "Select";

                t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
              auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);
            }

           
            

          
            if (t == true)
            {
                TextBox1.Text = "";
                // ddlChngOwnrAction.SelectedIndex = 0;
                DropDownList4.SelectedIndex = 0;
                DropDownList3.SelectedIndex = 0;
                ddlChngOwnrAction.SelectedIndex = 0;
                DropDownList2.SelectedIndex = 0;

                txtChngOwnrComments.Text = "";
                txtcomments.Text = "";
                lbltext.Text = "";

            }
            Connection.Close();

        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }

    }
    private void SendMailVeh_Rentals(string message)
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
                    "<br> Your Request is :" + message;
            mm.Subject = "Message From CMS Reviewer";
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


    protected void ddlChngOwnrAction_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnl111.Visible = true;

    }

    protected void lnllogout(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
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
    protected void linkassign_Click(object sender, EventArgs e)
    {
       
        category = "assignment";
        lblassign.CssClass = "active";
        lblitems.CssClass = "lnkcolor";
        lnknew.CssClass = "lnkcolor";
     
        //  user.Visible = false;
      
        assignbind();
    }

    protected void actionbinding()
    {
        SqlDataAdapter da2 = new SqlDataAdapter("select * from CMS_Initiator ", Connection);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        string user = Convert.ToString(ds2.Tables[0].Rows[0]["initby"]);
        string revsub = Convert.ToString(ds2.Tables[0].Rows[0]["submit"]);
        //if (ds2.Tables[0].Rows.Count > 0)
        //{
        if (userroleid == 3)
        {
            string name1 = Convert.ToString(Session["uname"]);
            SqlDataAdapter da = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from CMS_Initiator where ((status=1 and Curstatus=1 ) or (status=2 and Curstatus=4)) and submit='" + lbluname.Text + "' order by updatedate desc ", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
          
        }
        else
        {
           
        }
        //}
    }
    protected void assignbind()
    {
        DataSet ds = new DataSet();
        string umrolname = Convert.ToString(Session["umroles"]);
        if (umrolname == "Initiator&Reviewer")
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "' order by Changeid desc", Connection);

            da.Fill(ds);
        }
        else
        if (userroleid == 1)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "' and (status=1 and Curstatus=1) or (status=1 and Curstatus=3)  ", Connection);
           
            da.Fill(ds);
           
        }
        else
            if (userroleid == 3)
            {
                lnknew.Visible = false;
                SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator where initby='" + lbluname.Text + "'", Connection);
                da1.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
              

                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where initby='" + lbluname.Text + "' order by updatedate desc", Connection);

                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       
                    }
                    else
                    {

                        //recid.Text = lbluname.Text;
                    
                    }
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where submit='" + lbluname.Text + "' order by updatedate desc", Connection);

                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        
                    }
                    else
                    {

                       
                       
                    }
                }

            }
            else if (userroleid == 4)
            {
                lnknew.Visible = false;
                SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where (Curstatus=3 and status=1) or (Curstatus=4 or status=2) or (Curstatus=9 or status=1) order by updatedate desc", Connection);

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                }
                else
                {

                }
            }
            else if (userroleid == 9)
            {
                lnknew.Visible = false;
                SqlDataAdapter da = new SqlDataAdapter("select * from cms_coordinator where funreview='Yes'", Connection);
                DataSet dscft = new DataSet();
                da.Fill(dscft, "cms_coordinator");

                foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                {
                    string ChangeId = Convert.ToString((dr["Changeid"]));
                    SqlDataAdapter da2 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from cms_Initiator where Changeid='" + ChangeId + "' and status=1 and  Curstatus=4", Connection);
                    da2.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                      
                    }


                }


                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                   
                }
            }
            else if (userroleid == 10)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from cms_coordinator where funreview='Yes'", Connection);
                DataSet dscft = new DataSet();
                da.Fill(dscft, "cms_coordinator");

                foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                {
                    string ChangeId = Convert.ToString((dr["Changeid"]));
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from cms_Initiator where Changeid='" + ChangeId + "' and (status=11 and  Curstatus=4)  ", Connection);
                    da2.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                      
                    }
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                   
                }
            }
       

    }
    protected void lnkact_Click(object sender, EventArgs e)
    {
       
        category = "act";
        lblitems.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        lnknew.CssClass = "lnkcolor";


       
        //user.Visible = false;
       
        actionbinding();
    }
   
  
    protected void lnknew_Click(object sender, EventArgs e)
    {
       
       
        // user.Visible = true;
      
        lnknew.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        lblitems.CssClass = "lnkcolor";
    }
    protected void clickid(object sender, EventArgs e)
    {
        
        LinkButton ln = sender as LinkButton;
        lbltext.Text = ln.CommandArgument.ToString();
        string lnkcmgid=lbltext.Text;
        SqlDataAdapter da2 = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + ln.CommandArgument.ToString() + "' ", Connection);
        DataSet dss = new DataSet();
        da2.Fill(dss);
        int s = Convert.ToInt32(dss.Tables[0].Rows[0]["Curstatus"]);
        int st = Convert.ToInt32(dss.Tables[0].Rows[0]["status"]);

        if (dss.Tables[0].Rows.Count > 0)
        {


            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Reviewer where changeid='" + lnkcmgid + "' order by postdate desc", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                pnl111.Visible = true;
               
                lbltext.Text = lnkcmgid;
                ddlChngOwnrAction.SelectedItem.Text = ds.Tables[0].Rows[0]["HODACTION"].ToString();
                txtChngOwnrComments.Text = ds.Tables[0].Rows[0]["Outcome"].ToString(); ;
                DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["actitem"].ToString();
                txtcomments.Text = ds.Tables[0].Rows[0]["actitemdesc"].ToString();
                DropDownList2.SelectedItem.Text = ds.Tables[0].Rows[0]["Executor"].ToString();
                DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["Reviewer"].ToString(); 
                DropDownList4.SelectedItem.Text = ds.Tables[0].Rows[0]["Approver"].ToString();
                TextBox1.Text = ds.Tables[0].Rows[0]["TimeLine"].ToString();
            
                    //DropDownList3.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Reviewer"].ToString());
                
                if (DropDownList1.SelectedItem.Text == "Yes")
                {
                    pnl1.Visible = false;
                    pnl111.Visible = true;
                
                    txtcomments.Text = ds.Tables[0].Rows[0]["actitemdesc"].ToString();
                    DropDownList2.SelectedItem.Text = ds.Tables[0].Rows[0]["Executor"].ToString();
                    DropDownList3.SelectedValue = ds.Tables[0].Rows[0]["Reviewer"].ToString(); 
                    DropDownList4.SelectedItem.Text = ds.Tables[0].Rows[0]["Approver"].ToString();
                    TextBox1.Text = ds.Tables[0].Rows[0]["TimeLine"].ToString();

                    dt = (DataTable)ViewState["cur"];

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Reviewer where changeid='" + lnkcmgid + "'", Connection);
                    DataSet dscft = new DataSet();
                    da11.Fill(dscft, "coord");
                    foreach (DataRow dr in dscft.Tables["coord"].Rows)
                    {
                        DataRow dr2 = dt.NewRow();
                        dr2["actitemdesc"] = Convert.ToString((dr["actitemdesc"]));
                        dr2["Executor"] = Convert.ToString((dr["Executor"]));
                        dr2["Reviewer"] = Convert.ToString((dr["Reviewer"]));
                        dr2["Approver"] = Convert.ToString((dr["Approver"]));
                        dr2["TimeLine"] = Convert.ToString((dr["TimeLine"]));


                        dt.Rows.Add(dr2);

                    }
                    gd.DataSource = dt;
                    gd.DataBind();
                    gd.Enabled = false;
                    gd.Visible = true;
               


                }
                else
                {
                    pnl111.Visible = true;
                   
                    pnl1.Visible = false;
                }

                //ddl1.SelectedItem.Text = ds.Tables[0].Rows[0]["typechange"].ToString();

            }
            else
            {
                string umrolename = Convert.ToString(Session["umroles"]);
                if (userroleid == 3)
                {
                    lbltext.Text = lnkcmgid;
                    pnl111.Visible = true;
                  
                    trwaiting.Visible = true;
                    lblwait.Text = "Waiting For Approving This '" + lnkcmgid + "' Request";
                }
                else if (umrolename == "Initiator&Reviewer")
                {
                    lbltext.Text = lnkcmgid;
                    pnl111.Visible = true;
                  
                    trwaiting.Visible = true;
                    lblwait.Text = "Waiting For Approving This '" + lnkcmgid + "' Request";
                }
                else
                {

                    pnl111.Visible = true;
                }

                string strScript = "alert('Reviewer not perform any action to this '" + lnkcmgid + "' record');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
            }
          
           
        }
    }
    private void bindmethod()
    {
        lnknew.CssClass = "lnkcolor";
        lblassign.CssClass = "active";
        lblitems.CssClass = "lnkcolor";
        string lnkcmgid = Convert.ToString(Session["cmid"]);

        if (lnkcmgid == "")
        {
            pnl111.Visible = true;
        }
        else
        {
            //temp = ddlid.SelectedItem.Text.ToString();
            SqlDataAdapter da1 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where changeid='" + lnkcmgid + "'", Connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);


            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Reviewer where changeid='" + lnkcmgid + "' order by postdate desc", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                pnl111.Visible = true;


                lbltext.Text = lnkcmgid;
                ddlChngOwnrAction.SelectedItem.Text = ds.Tables[0].Rows[0]["HODACTION"].ToString();
                txtChngOwnrComments.Text = ds.Tables[0].Rows[0]["Outcome"].ToString(); ;
                DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["actitem"].ToString();
                txtcomments.Text = ds.Tables[0].Rows[0]["actitemdesc"].ToString();
                DropDownList2.SelectedItem.Text = ds.Tables[0].Rows[0]["Executor"].ToString();
                DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["Reviewer"].ToString(); ;
                DropDownList4.SelectedItem.Text = ds.Tables[0].Rows[0]["Approver"].ToString();
                TextBox1.Text = ds.Tables[0].Rows[0]["TimeLine"].ToString();

                if (DropDownList1.SelectedItem.Text == "Yes")
                {
                    pnl1.Visible = false;
                    pnl111.Visible = true;

                    gd.Visible = true;

                    txtcomments.Text = ds.Tables[0].Rows[0]["actitemdesc"].ToString();
                    DropDownList2.SelectedItem.Text = ds.Tables[0].Rows[0]["Executor"].ToString();
                    DropDownList3.SelectedValue = ds.Tables[0].Rows[0]["Reviewer"].ToString(); ;
                    DropDownList4.SelectedItem.Text = ds.Tables[0].Rows[0]["Approver"].ToString();
                    TextBox1.Text = ds.Tables[0].Rows[0]["TimeLine"].ToString();

                    dt = (DataTable)ViewState["cur"];

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Reviewer where changeid='" + lnkcmgid + "'", Connection);
                    DataSet dscft = new DataSet();
                    da11.Fill(dscft, "coord");
                    foreach (DataRow dr in dscft.Tables["coord"].Rows)
                    {
                        DataRow dr2 = dt.NewRow();
                        dr2["actitemdesc"] = Convert.ToString((dr["actitemdesc"]));
                        dr2["Executor"] = Convert.ToString((dr["Executor"]));
                        dr2["Reviewer"] = Convert.ToString((dr["Reviewer"]));
                        dr2["Approver"] = Convert.ToString((dr["Approver"]));
                        dr2["TimeLine"] = Convert.ToString((dr["TimeLine"]));


                        dt.Rows.Add(dr2);

                    }
                    gd.DataSource = dt;
                    gd.DataBind();
                    gd.Enabled = false;
                    gd.Visible = true;


                }
                else
                {
                    pnl111.Visible = true;

                    pnl1.Visible = false;
                }

                //ddl1.SelectedItem.Text = ds.Tables[0].Rows[0]["typechange"].ToString();



            }
            else
            {
                string umrolename = Convert.ToString(Session["umroles"]);
                if (userroleid == 3)
                {
                    lbltext.Text = lnkcmgid;
                    pnl111.Visible = true;

                    trwaiting.Visible = true;
                    lblwait.Text = "Waiting For Approving This '" + lnkcmgid + "' Request";
                }
                else if (umrolename == "Initiator&Reviewer")
                {
                    lbltext.Text = lnkcmgid;
                    pnl111.Visible = true;

                    trwaiting.Visible = true;
                    lblwait.Text = "Waiting For Approving This '" + lnkcmgid + "' Request";
                }
                else
                {

                    pnl111.Visible = true;
                }

                string strScript = "alert('Reviewer not perform any action to this '" + lnkcmgid + "' record');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);

            }
        }
    
    }

    protected void button_Click(object sender, EventArgs e)
    {
        method();
       // string date = Convert.ToString(Session["updatetime1"]);
        string lnkcmgid = Convert.ToString(Session["cmid"]);

        SqlCommand cmd = new SqlCommand("update cms_initiator set status=123 where changeid='" + lnkcmgid + "'", Connection);
             Connection.Open();
             cmd.ExecuteScalar();
             Connection.Close();
             string strScript = "alert('Saved Successfully');";
           Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);

           Session.Remove("cmid");
    }
    protected void saveclose_Click(object sender, EventArgs e)
    {
         method();
       
          string lnkcmgid = Convert.ToString(Session["cmid"]);
              
              SqlCommand cmd = new SqlCommand("update cms_initiator set status=123 changeid='" + lnkcmgid + "'", Connection);
              Connection.Open();
              cmd.ExecuteScalar();
              Connection.Close();

              string strScript = "alert('Saved & Closed Successfully');";
              Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);

              Session.Remove("cmid");
    }
    protected void cancel_Click(object sender, EventArgs e)
    {
        string strScript = "alert('Cancel The Request');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}