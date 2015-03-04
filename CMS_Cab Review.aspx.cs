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

public partial class CMS_Cab_Review : System.Web.UI.Page
{
    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string st;
    DataTable dt;
    public static string category;
    string temp;
    audithistorymethod auditinsert = new audithistorymethod();
    audithistoryproperties auditpop = new audithistoryproperties();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
          //  Response.Redirect("default.aspx");
            Response.RedirectToRoute("logincms");
        }
        string name = Convert.ToString(Session["uname"]);
        lbluname.Text = name;
       // string ab = Convert.ToString(Request.QueryString["parameter"]);
        string ab = Convert.ToString(Page.RouteData.Values["parameter"]);
        string gid = Convert.ToString(Session["gvcid"]);
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;
        //string s = Convert.ToString(Session["id1"]);
        string s = Convert.ToString(Session["cid1"]).ToString();
        lbltext.Text = s;
        int userroleid = Convert.ToInt32(Session["userroleid"]);
        string changeid = Convert.ToString(Session["cmid"]);
        if (!IsPostBack)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Comments", typeof(string)));
            dt.Columns.Add(new DataColumn("fwdaprv", typeof(string)));
            dt.Columns.Add(new DataColumn("mgtnfcion", typeof(string)));
            ViewState["cur"] = dt;
            if (ab == "gidcid")
            {
                if (userroleid == 8)
                {
                        lbltext.Text = changeid;
                        SqlDataAdapter da2 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from cms_Initiator where Changeid='" + changeid + "'", Connection);
                        DataSet ds = new DataSet();
                        da2.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            pnl111.Visible = true;
                            
                            userbody.Visible = true;
                         
                            ddlitemsapprover.SelectedItem.Text =Convert.ToString(ds.Tables[0].Rows[0]["cclassification"]);
                           
                            if (ddlitemsapprover.SelectedItem.Text == "Quality Impactinng")
                            { pnl1apprver.Visible = true; }
                            else
                            { pnl1apprver.Visible = false; }

                        }
                        else
                        {
                           
                        }

                    
                }
                else
                {
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                    string changeid1 = Convert.ToString(Session["cmid"]);

                    pnl111.Visible = true;

                    userbody.Visible = true;
                        lbltext.Text = changeid1;
                        searchbychangeid(changeid1);

                    EnableAllControls(this.Page.Form.Controls, false);
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
                }


            }
            else
            {
                pnl111.Visible = true;

                userbody.Visible = true;
                EnableAllControls(this.Page.Form.Controls, false);
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
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
    private void searchbychangeid(string changeid1)
    {
        lbltext.Text = changeid1;
        SqlDataAdapter da1 = new SqlDataAdapter("select substring(cdesc,1,18)as cdesc,* from CMS_Initiator where Changeid='" + changeid1 + "'", Connection);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {


            SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Apprver where changeid='" + changeid1 + "'", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                pnl111.Visible = true;
                userbody.Visible = true;

                lbltext.Text = changeid1;
                ddlitemsapprover.SelectedItem.Text = ds.Tables[0].Rows[0]["actionitem"].ToString();
                txtcomm.Text = ds.Tables[0].Rows[0]["Comments"].ToString(); ;
                //ddlapprove.SelectedItem.Text = ds.Tables[0].Rows[0]["fwdaprv"].ToString();
                //ddlmgt.SelectedItem.Text = ds.Tables[0].Rows[0]["mgtnfcion"].ToString();
                if (ddlitemsapprover.SelectedItem.Text == "Quality Impactinng")
                {

                    dt = (DataTable)ViewState["cur"];

                    SqlDataAdapter da2 = new SqlDataAdapter("select * from CMS_Apprver where changeid='" + changeid1 + "'", Connection);
                    DataSet dscft = new DataSet();
                    da2.Fill(dscft, "cms_coordinator");
                    foreach (DataRow dr in dscft.Tables["cms_coordinator"].Rows)
                    {
                        DataRow dr2 = dt.NewRow();
                        dr2["Comments"] = Convert.ToString((dr["Comments"]));
                        dr2["fwdaprv"] = Convert.ToString((dr["fwdaprv"]));
                        dr2["mgtnfcion"] = Convert.ToString((dr["mgtnfcion"]));
                        dt.Rows.Add(dr2);

                    }
                    gdaprver.DataSource = dt;
                    gdaprver.DataBind();
                    gdaprver.Enabled = false;
                    gdaprver.Visible = true;
                    pnl1apprver.Visible = false;


                }
                else
                {
                    gdaprver.Visible = false;
                    pnl1apprver.Visible = false;
                }
                pnl111.Visible = true;
                userbody.Visible = true;
            }
            else
            {

                pnl111.Visible = true;
                userbody.Visible = true;

            }
        }
        else
        {

            pnl111.Visible = true;
            userbody.Visible = true;
        }
    
    }

  

   
    public void EnableAllControls(ControlCollection cc, bool enable)
    {
        //foreach (Control c in cc)
        //{
        //    try { EnableAllControls(c.Controls, enable); }
        //    catch { }
        //    if (c.GetType() == typeof(TextBox)) { try { ((TextBox)c).Enabled = enable; } catch { } }
        //    else if (c.GetType() == typeof(DropDownList)) { try { ((DropDownList)c).Enabled = enable; } catch { } }
        //    else if (c.GetType() == typeof(Button)) { try { ((Button)c).Enabled = enable; } catch { } }
        //    else if (c.GetType() == typeof(LinkButton)) { try { ((LinkButton)c).Enabled = enable; } catch { } }
        //    else if (c.GetType() == typeof(HtmlInputText)) { try { ((HtmlInputText)c).Attributes.Add("disabled", "true"); } catch { } }
        //}
    }
    protected void gd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {        
        int rowid = e.RowIndex;
        dt = (DataTable)ViewState["cur"];
        dt.Rows[rowid].Delete();
        gdaprver.DataSource = dt;
        gdaprver.DataBind();
    }
    protected void statuscord()
    {
        string crdres = Convert.ToString(Session["coordrevs"]);

        string ass = Convert.ToString(Session["resss"]);
        string abs = Convert.ToString(Session["resss1"]);

        string ass1 = Convert.ToString(Session["revres1"]);
        string abs1 = Convert.ToString(Session["revres2"]);


        string ass12 = Convert.ToString(Session["resss1"]);
        string abs12 = Convert.ToString(Session["resss11"]);
        string crdres1 = ass1 + "" + abs1;
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
    {   //Get data row view
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
                    statuscord();
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
                    statuscord();
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
    private void bindretmethod()
    {

        int cstatus = 8;
        int status = 2;
        //Connection.Open();

        string s = Convert.ToString(Session["cid1"]);
        SqlCommand cmd = new SqlCommand("sp_CMS_Apprver", Connection);
        cmd.CommandType = CommandType.StoredProcedure;
        //  cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["USERID"]));


        cmd.Parameters.AddWithValue("@Comments", txtcomm.Text);
        //cmd.Parameters.AddWithValue("@Cate", txtGreet.Text);
        cmd.Parameters.AddWithValue("@Changeid", s);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@cstatus", cstatus);
        cmd.Parameters.AddWithValue("@actionitem", ddlitemsapprover.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@fwdaprv", ddlapprove.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@mgtnfcion", ddlmgt.SelectedItem.Text);

        if (gdaprver.Visible == true)
        {
            foreach (GridViewRow g1 in gdaprver.Rows)
            {

                SqlCommand com = new
                 SqlCommand("insert into  CMS_Apprver  (Comments ,Changeid ,status ,Curstatus ,actionitem ,fwdaprv,mgtnfcion) values ('" + g1.Cells[0].Text + "','" + s + "','" + status + "','" + cstatus + "','" + ddlitemsapprover.SelectedItem.Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "') ", Connection);
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

        string abc = Convert.ToString(Session["changeidaction"]).ToString();
        string role = "Approver";
        int rcode = 8;
        string act = "Approver Return The Request for additional information";
        // string name = Convert.ToString(Session["uname"]);
        
        SqlCommand cmda = new SqlCommand("Sp_AuditHistory", Connection);
        cmda.CommandType = CommandType.StoredProcedure;
        //  cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["USERID"]));


        cmda.Parameters.AddWithValue("@changeid", lbltext.Text);
        cmda.Parameters.AddWithValue("@role", role);
        cmda.Parameters.AddWithValue("@userid", lbluname.Text);
        cmda.Parameters.AddWithValue("@activity", act);
        cmda.Parameters.AddWithValue("@timestamp", DateTime.Now.ToString());
        cmda.Parameters.AddWithValue("@rolecode", rcode);
        cmda.Parameters.AddWithValue("@assignedto", "Approver returned to Coordinator");
        Connection.Open();

        int i = cmda.ExecuteNonQuery();
        Connection.Close();
        txtcomm.Text = "";
        ddlitemsapprover.SelectedIndex = -1;
        ddlapprove.SelectedIndex = -1;
        ddlmgt.SelectedIndex = -1;
        SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set Curstatus=8,status=2 where Changeid='" + Convert.ToString(Session["cid1"]) + "'", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        SendMailVeh_Rentals();
       // UserControl();
        Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Approver returned to Coordinator and send mail to initiator.')</script>");
     
        pnl111.Visible = false;
        userbody.Visible = false;
       // Session["gvcid"] = null;
    }

    private void bindrejectmethod()
    {
        int cstatus = 8;
        int status = 0;
        //Connection.Open();

        string s = Convert.ToString(Session["cid1"]);
        SqlCommand cmd = new SqlCommand("sp_CMS_Apprver", Connection);
        cmd.CommandType = CommandType.StoredProcedure;
        //  cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["USERID"]));


        cmd.Parameters.AddWithValue("@Comments", txtcomm.Text);
        //cmd.Parameters.AddWithValue("@Cate", txtGreet.Text);
        cmd.Parameters.AddWithValue("@Changeid", s);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@cstatus", cstatus);
        cmd.Parameters.AddWithValue("@actionitem", ddlitemsapprover.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@fwdaprv", ddlapprove.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@mgtnfcion", ddlmgt.SelectedItem.Text);

        if (gdaprver.Visible == true)
        {
            foreach (GridViewRow g1 in gdaprver.Rows)
            {

                SqlCommand com = new
                 SqlCommand("insert into  CMS_Apprver  (Comments ,Changeid ,status ,Curstatus ,actionitem ,fwdaprv,mgtnfcion) values ('" + g1.Cells[0].Text + "','" + s + "','" + status + "','" + cstatus + "','" + ddlitemsapprover.SelectedItem.Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "') ", Connection);
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
        string role = "Approver";
        int rcode = 8;
        string act = "Approver Reject The Request";
        // string name = Convert.ToString(Session["uname"]);

        SqlCommand cmda = new SqlCommand("Sp_AuditHistory", Connection);
        cmda.CommandType = CommandType.StoredProcedure;
        //  cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["USERID"]));


        cmda.Parameters.AddWithValue("@changeid", lbltext.Text);
        cmda.Parameters.AddWithValue("@role", role);
        cmda.Parameters.AddWithValue("@userid", lbluname.Text);
        cmda.Parameters.AddWithValue("@activity", act);
        cmda.Parameters.AddWithValue("@timestamp", DateTime.Now.ToString());
        cmda.Parameters.AddWithValue("@rolecode", rcode);
        cmda.Parameters.AddWithValue("@assignedto", "Approver rejected");
        Connection.Open();
        int i = cmda.ExecuteNonQuery();
        Connection.Close();
        txtcomm.Text = "";
        ddlitemsapprover.SelectedIndex = -1;
        ddlapprove.SelectedIndex = -1;
        ddlmgt.SelectedIndex = -1;

        SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set Curstatus=8,status=0 where Changeid='" + Convert.ToString(Session["cid1"]) + "'", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        SendMailVeh_Rentals();
        //UserControl();
        Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Approver rejected and send mail to initiator.')</script>");
       
        pnl111.Visible = false;
        userbody.Visible = false;
        //Session["gvcid"] = null;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        method();
    }
    protected void method()
    {

        string changeid = Convert.ToString(Session["cmid"]);
        int cstatus = 8;
        int status = 1;

        string s = lbltext.Text;
        SqlCommand cmd = new SqlCommand("sp_CMS_Apprver", Connection);
        cmd.CommandType = CommandType.StoredProcedure;
        
        cmd.Parameters.AddWithValue("@Comments", txtcomm.Text);
      
        cmd.Parameters.AddWithValue("@Changeid", changeid);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@cstatus", cstatus);
        cmd.Parameters.AddWithValue("@actionitem", ddlitemsapprover.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@fwdaprv", ddlapprove.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@mgtnfcion", ddlmgt.SelectedItem.Text);
        if (gdaprver.Visible == true)
        {
            foreach (GridViewRow g1 in gdaprver.Rows)
            {

                SqlCommand com = new
                 SqlCommand("insert into  CMS_Apprver  (Comments ,Changeid ,status ,Curstatus ,actionitem ,fwdaprv,mgtnfcion) values ('" + g1.Cells[0].Text + "','" + s + "','" + status + "','" + cstatus + "','" + ddlitemsapprover.SelectedItem.Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "') ", Connection);
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

        audithistory();


        SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set Curstatus=8,status=1 where Changeid='" + changeid + "'", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        SendMailVeh_Rentals();
        // UserControl();
        Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Successfully Approved and send mail to initiator.')</script>");
        // gridForApprover();
        pnl111.Visible = false;
        userbody.Visible = false;
    }

    protected void audithistory()
    {
        string changeid = Convert.ToString(Session["cmid"]);
        string role = "Approver";
        int rcode = 8;
        string activity = "Approver Approved The Request";
        // string name = Convert.ToString(Session["uname"]);
        lbltext.Text = changeid;
      

        auditpop.auditChangeid = lbltext.Text;
        auditpop.auditrole = role;
        auditpop.audituserid = lbluname.Text;
        auditpop.auditactivity = activity;
        auditpop.audittimestamp = DateTime.Now.ToString();
        auditpop.auditrolecode = rcode;
        auditpop.auditassignedto = "Approver Completed";
        auditpop.Submitreviewer = "Approved";
        bool t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
                    auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);

        if (t == true)
        {

            txtcomm.Text = "";
            ddlitemsapprover.SelectedIndex = -1;
            ddlapprove.SelectedIndex = -1;
            ddlmgt.SelectedIndex = -1;
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
                    "<br>Message From Approver :";
            mm.Subject = "Message From CMS Approver";
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
  
    protected void add_Click(object sender, EventArgs e)
    {
        string s = Convert.ToString(Session["cid1"]).ToString();
        lbltext.Text = s;
        dt = (DataTable)ViewState["cur"];
        DataRow dr = dt.NewRow();
        dr["Comments"] = txtcomm.Text;
        dr["fwdaprv"] = ddlapprove.SelectedItem.Text;
        dr["mgtnfcion"] = ddlmgt.SelectedItem.Text;
        dt.Rows.Add(dr);
        gdaprver.DataSource = dt;
        gdaprver.DataBind();
        ViewState["cur"] = dt;
        gdaprver.Visible = true;
        ddlapprove.SelectedIndex = 0;
        ddlmgt.SelectedIndex = 0;
        txtcomm.Text = "";
        pnl111.Visible = true;
        userbody.Visible = true;  

    }
 
    protected void lnllogout(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void linkassign_Click(object sender, EventArgs e)
    {
        category = "assignment";
        lblassign.CssClass = "active";
        lblitems.CssClass = "lnkcolor";
        
         int userroleid = Convert.ToInt32(Session["userroleid"]);
         if (userroleid == 8)
         {
             
            
             userbody.Visible = true;
           
             BtnSave.Enabled = true;
             Btnreturn.Enabled = true;
             Btnreject.Enabled = true;
             Btnsubmit.Enabled = true;
             
         }
         else
         {
            
             EnableAllControls(this.Page.Form.Controls, false);
             lnklogout.Enabled = true;
             linkassign.Enabled = true;
             lnkact.Enabled = true;
         }
    }
    
    protected void lnkact_Click(object sender, EventArgs e)
    {
        category = "act";
        lblitems.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        int userroleid = Convert.ToInt32(Session["userroleid"]);
        if (userroleid == 8)
        {

            
            userbody.Visible = true;
           
            BtnSave.Enabled = true;
            Btnreturn.Enabled = true;
            Btnreject.Enabled = true;
            Btnsubmit.Enabled = true;

        }
        else
        {
           
            EnableAllControls(this.Page.Form.Controls, false);
            lnklogout.Enabled = true;
            linkassign.Enabled = true;
            lnkact.Enabled = true;
        }
    }
    
   
 

    protected void clickid(object sender, EventArgs e)
    {
        
        LinkButton ln = sender as LinkButton;
        lbltext.Text = ln.CommandArgument.ToString();
        string changeid = ln.CommandArgument.ToString();
        Session["cid1"] = changeid;
        GridViewRow row = (GridViewRow)ln.NamingContainer;
        int i = Convert.ToInt32(row.RowIndex);
        int userroleid = Convert.ToInt32(Session["userroleid"]);
        searchbychangeid(changeid);
        if (userroleid == 8)
        {
            //searchbychangeid(changeid);
        }
        else
        {
            EnableAllControls(this.Page.Form.Controls, false);
            lnklogout.Enabled = true;
            linkassign.Enabled = true;
            lnkact.Enabled = true;

        }
      SqlDataAdapter da=new SqlDataAdapter("select cclassification from cms_initiator where changeid='"+changeid+"'",Connection);
      DataSet ds=new DataSet();
        da.Fill(ds);
        string classification="";
        if(ds.Tables[0].Rows.Count>0)
        {
        classification=Convert.ToString(ds.Tables[0].Rows[0]["cclassification"]);
        }

        ddlitemsapprover.SelectedItem.Text =classification;

        if (ddlitemsapprover.SelectedItem.Text == "Quality Impactinng")
        { pnl1apprver.Visible = true; }
        else
        { pnl1apprver.Visible = false; }
        userbody.Visible = true;
       
        pnl111.Visible = true;        
        lbltext.Text = changeid;
       
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        method();
        SqlCommand cmd = new SqlCommand("update cms_initiator set status=123 changeid='" + lbltext.Text + "' and Curstatus=8", Connection);
        Connection.Open();
        cmd.ExecuteScalar();
        Connection.Close();
        string strScript = "alert('Save&closed Successfully');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
    }
    protected void Btnreject_Click(object sender, EventArgs e)
    {
        method();
        SqlCommand cmd = new SqlCommand("update cms_initiator set status=0 changeid='" + lbltext.Text + "'  and Curstatus=8", Connection);
        Connection.Open();
        cmd.ExecuteScalar();
        Connection.Close();
        string strScript = "alert('Request is rejected');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
    }
    protected void Btnreturn_Click(object sender, EventArgs e)
    {
        method();
        SqlCommand cmd = new SqlCommand("update cms_initiator set status=2 changeid='" + lbltext.Text + "'  and Curstatus=8", Connection);
        Connection.Open();
        cmd.ExecuteScalar();
        Connection.Close();
        string strScript = "alert('Request is rejected');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
    }
   
   
}