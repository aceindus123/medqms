using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using cmm.audithistory;
using cmm.audithistoryproperties;
using cmm.errorexcep;
using cmm.coordinatorpop;
using cmm.coordbindmethods;
using System.Net.Mail;
using cmm.departments;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

public partial class Final_QA : System.Web.UI.Page
{
    DataTable dt;
    DataTable dt1;
    
    string temp;
  
    int i;
    string b;
    public static string category;
    string act = string.Empty;
    int userroleid;
    string userrolename;
    bool t;
    public string functionrev=string .Empty;
    int flag;
    SqlDataAdapter dacord;
    audithistorymethod auditinsert = new audithistorymethod();
    audithistoryproperties auditpop = new audithistoryproperties();
    Coordinatorproperties coordprop = new Coordinatorproperties();
    Coordinatormethods coordmethod = new Coordinatormethods();
    department depts = new department();
    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {

        string name = Convert.ToString(Session["uname"]);
        lbluname.Text = name;
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;

        userroleid = Convert.ToInt32(Session["userroleid"]);
        userrolename = Convert.ToString(Session["userrolename"]);
       
        string chmid = Convert.ToString(Session["cmid"]);
        string reassignid = Convert.ToString(Session["reassign"]);
       // string ab = Convert.ToString(Request.QueryString["parameter"]);
     //   string cmrev = Convert.ToString(Request.QueryString["reviewer"]);
        string ab = Convert.ToString(Page.RouteData.Values["parameter"]);
         string cmrev = Convert.ToString(Page.RouteData.Values["reviewer"]);
        string lnkcmgid = Convert.ToString(Session["cmid"]);

        if (Session["uname"] == null)
        {
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Session Closed.Please ReLogin into medqms')", true);

          //  Response.Redirect("default.aspx");
            Response.RedirectToRoute("logincms");
        }
        
        if (!IsPostBack)
        {
            SqlDataAdapter dastatus = new SqlDataAdapter("select status,Curstatus from cms_initiator where changeid='" + lnkcmgid + "'", Connection);
            DataSet dsstatus = new DataSet();
            dastatus.Fill(dsstatus);
            if (dsstatus.Tables[0].Rows.Count > 0)
            {
                int st = Convert.ToInt32(dsstatus.Tables[0].Rows[0]["status"]);
                int cust = Convert.ToInt32(dsstatus.Tables[0].Rows[0]["Curstatus"]);
                if ((cust == 9 && st == 1) || (cust == 10 && st == 1))
                {
                    btnaprver.Visible = true;
                    submit.Enabled = false;
                }
                else
                {
                    btnaprver.Visible = false;
                    submit.Enabled = true;
                }
            }
            dt1 = new DataTable();

            dt1.Columns.Add(new DataColumn("actnitmdesc", typeof(string)));

            dt1.Columns.Add(new DataColumn("Executor", typeof(string)));

            dt1.Columns.Add(new DataColumn("Reviewer1", typeof(string)));
            dt1.Columns.Add(new DataColumn("Timeline1", typeof(string)));

            dt1.Columns.Add(new DataColumn("Department", typeof(string)));

            dt1.Columns.Add(new DataColumn("DeptHod", typeof(string)));

           

            ViewState["cur"] = dt1;


            dt = new DataTable();

            dt.Columns.Add(new DataColumn("crossfunreviwer", typeof(string)));

            dt.Columns.Add(new DataColumn("tgtcmpltndate", typeof(string)));

            dt.Columns.Add(new DataColumn("Reviewer", typeof(string)));
            dt.Columns.Add(new DataColumn("Timeline", typeof(string)));
            dt.Columns.Add(new DataColumn("Priority", typeof(string)));

            dt.Columns.Add(new DataColumn("Prioritycode", typeof(string)));
         
            ViewState["cur1"] = dt;

            if (userroleid == 4)
            {
                if (ab == "gidcid")
                {
                  //  SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where   ((Curstatus=3 and status=1) or (Curstatus=4 or status=2) or (Curstatus=9 or status=1) or (Curstatus=4 or status=1)) and changeid='" + lnkcmgid + "' order by updatedate desc", Connection);
                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where   ((Curstatus=3 and status=1) or (Curstatus=4 or status=2) or (Curstatus=9 or status=1) or (Curstatus=4 or status=1)) and changeid='" + lnkcmgid + "' order by updatedate desc", Connection);
                 
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        bindmethod();
                        category = "assignment";
                        lblassign.CssClass = "active";
                        lblitems.CssClass = "lnkcolor";

                    }
                    else
                    {
                    }

                    SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator  order by Changeid desc", Connection);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                   
                  
                }
                else if (ab == "reassignid")
                {


                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where   ((Curstatus=3 and status=1) or (Curstatus=4 or status=2) or (Curstatus=9 or status=1) or (Curstatus=4 or status=1)) and changeid='" + reassignid + "' order by updatedate desc", Connection);

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        reassignbindmethod();
                        category = "assignment";
                        lblassign.CssClass = "active";
                        lblitems.CssClass = "lnkcolor";

                    }
                    else
                    {


                        
                    }


                
                }
            }
            else if (userroleid == 3)
            {
               

               if (ab == "gidcid")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where changeid='" + lnkcmgid + "' order by updatedate desc", Connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       
                       // rolebinding();
                        bindmethod();
                    }
                    else
                    {

                          }
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator  order by Changeid desc", Connection);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                }
                else if (ab == "reassignid")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where changeid='" + reassignid + "' order by updatedate desc", Connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        
                        // rolebinding();
                        reassignbindmethod();
                    }
                    else
                    {

                        //recid.Text = lbluname.Text;
                      
                    }
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator  order by Changeid desc", Connection);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                  
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                }

               Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     
            
            }
            else
            {
               
                if (ab == "gidcid")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where changeid='" + lnkcmgid + "' order by updatedate desc", Connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       

                        // rolebinding();
                        bindmethod();
                    }
                    else
                    {

                        //recid.Text = lbluname.Text;
                       
                    }
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator  order by Changeid desc", Connection);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                   
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                }
                else if (ab == "reassignid")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where changeid='" + reassignid + "' order by updatedate desc", Connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        // rolebinding();
                        reassignbindmethod();
                    }
                    else
                    {

                        //recid.Text = lbluname.Text;
                    }
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator  order by Changeid desc", Connection);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                   
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                }
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('" + lbluname.Text + "  Only View The Information.')</script>");
     

            }

            dacord=new SqlDataAdapter("select * from CMS_Initiator where changeid='"+chmid+"'",Connection);
            DataSet dscord=new DataSet();
            dacord.Fill(dscord);
            if (dscord.Tables[0].Rows.Count > 0)
            {
                string reqdept = Convert.ToString(dscord.Tables[0].Rows[0]["Dept"]);
                SqlDataAdapter da = new SqlDataAdapter("(select * from CMM_Departments)except (select * from CMM_Departments where DeptDesc='"+reqdept+"')",Connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownList6.DataSource = ds;
                DropDownList6.DataTextField = "DeptDesc";
                DropDownList6.DataValueField = "DeptDesc";
                DropDownList6.DataBind();
                DropDownList6.Items.Insert(0,"Select");

            }
            else
            {
                depts.departmentbinding(DropDownList6);
            }
            depts.departmentbinding(ddldept);
            statusbind();
        }
      
    }

    protected void reassignbindmethod()
    {
        btns.Visible = true;
        string reassignid = Convert.ToString(Session["reassign"]);
        
     
        //temp = ddlid.SelectedItem.Text.ToString();
        SqlDataAdapter da1 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where changeid='" + reassignid + "'", Connection);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        int sta = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
        int cursta = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);
       


        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + reassignid + "' order by PostDate desc", Connection);
        DataSet ds = new DataSet();

        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            // btns.Visible = false;
            pnl111.Visible = true;
            content.Visible = true;

            lbltext.Text = reassignid;
            txtcomment.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
            DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["funreview"].ToString();


            if (sta == 1 && cursta == 9)
            {

                DropDownList1.SelectedIndex = -1;

                if (ds.Tables[0].Rows[0]["funreview"].ToString() == "Yes")
                {
                    DropDownList3.SelectedItem.Text = "Yes";
                    pnl1.Visible = false;
                    pnn.Visible = false;
                    gd.Visible = true;

                    dt = (DataTable)ViewState["cur1"];

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + reassignid + "' order by PostDate asc", Connection);
                    DataSet dscft = new DataSet();
                    da11.Fill(dscft, "coord");
                    foreach (DataRow dr in dscft.Tables["coord"].Rows)
                    {
                        DataRow dr2 = dt.NewRow();

                        gd.Columns[1].Visible = false;
                        gd.Columns[0].Visible = false;
                        gd.Columns[5].Visible = false;
                        dr2["crossfunreviwer"] = Convert.ToString((dr["crossfunreviwer"]));
                        dr2["tgtcmpltndate"] = Convert.ToString((dr["tgtcmpltndate"]));
                        dr2["Reviewer"] = Convert.ToString((dr["Reviewer"]));
                        dr2["Timeline"] = Convert.ToString((dr["Timeline"]));


                        dt.Rows.Add(dr2);

                    }
                    gd.DataSource = dt;
                    gd.DataBind();
                    gd.Enabled = false;
                    gd.Visible = true;

                }
                else
                {
                    DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["funreview"].ToString();
                }

            }

            else if (sta == 1 && cursta == 10)
            {
                txtdesc.Text = ds.Tables[0].Rows[0]["actnitmdesc"].ToString();
                DropDownList8.SelectedItem.Text = ds.Tables[0].Rows[0]["Executor"].ToString();
                DropDownList9.SelectedItem.Text = ds.Tables[0].Rows[0]["Reviewer1"].ToString(); ;
                ddldept.SelectedItem.Text = ds.Tables[0].Rows[0]["department"].ToString();
                ddldepthod.SelectedItem.Text = ds.Tables[0].Rows[0]["depthod"].ToString();
                txttime1.Text = ds.Tables[0].Rows[0]["Timeline1"].ToString();
                txtpriority.SelectedItem.Text = ds.Tables[0].Rows[0]["priority"].ToString();
                // DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["actitmtree"].ToString();
                ddlrioritycode.SelectedItem.Text = ds.Tables[0].Rows[0]["prioritycode"].ToString();
                DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["actitmtree"].ToString();
                if (ds.Tables[0].Rows[0]["actitmtree"].ToString() == "Yes")
                {
                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[6].Visible = false;
                    GridView1.Columns[7].Visible = false;
                    DropDownList1.SelectedItem.Text = "Yes";
                    Panel1.Visible = false;
                    GridView1.Visible = true;

                    dt1 = (DataTable)ViewState["cur"];

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + reassignid + "' order by PostDate desc", Connection);
                    DataSet dscft = new DataSet();
                    da11.Fill(dscft, "coord");
                    foreach (DataRow dr in dscft.Tables["coord"].Rows)
                    {
                        DataRow dr2 = dt1.NewRow();
                        dr2["actnitmdesc"] = Convert.ToString((dr["actnitmdesc"]));
                        dr2["Executor"] = Convert.ToString((dr["Executor"]));
                        dr2["Reviewer1"] = Convert.ToString((dr["Reviewer1"]));
                        dr2["TimeLine1"] = Convert.ToString((dr["TimeLine1"]));
                        dr2["prioritycode"] = Convert.ToString((dr["prioritycode"]));
                        dr2["department"] = Convert.ToString((dr["department"]));
                        dr2["depthod"] = Convert.ToString((dr["depthod"]));
                        dr2["priority"] = Convert.ToString((dr["priority"]));
                        dt1.Rows.Add(dr2);
                    }
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    GridView1.Enabled = false;
                    GridView1.Visible = true;
                    gd.Visible = true;

                 
                }
                else
                {
                    Panel1.Visible = false;
                    GridView1.Visible = false;
                }

            }

            else
            {
                DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["actitmtree"].ToString();

                if (ds.Tables[0].Rows[0]["actitmtree"].ToString() == "Yes")
                {
                    GridView1.Columns[3].Visible = false;
                    GridView1.Columns[4].Visible = false;
                    GridView1.Columns[5].Visible = false;
                    DropDownList1.SelectedItem.Text = "Yes";
                    Panel1.Visible = false;
                    GridView1.Visible = true;

                    dt1 = (DataTable)ViewState["cur"];

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + reassignid + "' order by PostDate desc", Connection);
                    DataSet dscft = new DataSet();
                    da11.Fill(dscft, "coord");
                    foreach (DataRow dr in dscft.Tables["coord"].Rows)
                    {
                        DataRow dr2 = dt1.NewRow();
                        dr2["actnitmdesc"] = Convert.ToString((dr["actnitmdesc"]));
                        dr2["Executor"] = Convert.ToString((dr["Executor"]));
                        dr2["Reviewer1"] = Convert.ToString((dr["Reviewer1"]));
                        dr2["TimeLine1"] = Convert.ToString((dr["TimeLine1"]));
                       // dr2["prioritycode"] = Convert.ToString((dr["prioritycode"]));

                        dr2["department"] = Convert.ToString((dr["department"]));
                        dr2["depthod"] = Convert.ToString((dr["depthod"]));
                       // dr2["priority"] = Convert.ToString((dr["priority"]));

                        dt1.Rows.Add(dr2);
                    }
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    GridView1.Enabled = false;
                    GridView1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                    GridView1.Visible = false;
                }

            }
            if (DropDownList3.SelectedItem.Text == "Yes")
            {
                pnl1.Visible = true;
                pnn.Visible = true;
                DropDownList6.SelectedItem.Text = ds.Tables[0].Rows[0]["crossfunreviwer"].ToString(); ;
            }
            else
            {
                pnn.Visible = false;
                pnl1.Visible = false;

            }
            btns.Visible = true;
        }
        else
        {
            if (userroleid == 4)
            {
                lbltext.Text = reassignid;
                pnl111.Visible = true;
                content.Visible = true;
                trwaiting.Visible = true;

                lblwait.Text = "Waiting For Approving This '" + reassignid + "' Request";
            }
            else
            {
                pnl111.Visible = false;

                trwaiting.Visible = false;
            }
            string strScript = "alert('Coordinator not perform any action to this '" + reassignid + "' record');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);

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

    
    
    protected void gd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowid = e.RowIndex;
        dt = (DataTable)ViewState["cur1"];
        dt.Rows[rowid].Delete();
        string strScript = "alert('Successfully Deleted.');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
        gd.DataSource = dt;
        gd.DataBind();
        pnl111.Visible = true;
        content.Visible = true;
        pnl1.Visible = true;
       // Session.Clear();
    }
    protected void grd1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowid = e.RowIndex;
        dt = (DataTable)ViewState["cur"];
        dt.Rows[rowid].Delete();
        string strScript = "alert('Successfully Deleted.');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        pnl111.Visible = true;
        content.Visible = true;
        Panel1.Visible = true;

    }
   
    protected void gd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList3.SelectedItem.Text == "Yes")
        {
           
            pnl1.Visible = true;
           
            pnn.Visible = true;
           
            DataSet ds111 = new DataSet();
            SqlDataAdapter da12 = new SqlDataAdapter("select * from CMS_Initiator where Changeid='"+lbltext.Text+"'", Connection);
            da12.Fill(ds111);
            string deptdec = Convert.ToString(ds111.Tables[0].Rows[0]["Dept"]);
            SqlDataAdapter da11 = new SqlDataAdapter("select DeptDesc from CMM_Departments EXCEPT (SELECT DeptDesc FROM CMM_Departments where DeptDesc='" + deptdec + "')", Connection);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11);
            DropDownList6.DataSource = ds11;
            DropDownList6.DataValueField = "DeptDesc";
            DropDownList6.DataTextField = "DeptDesc";
            DropDownList6.DataBind();
            DropDownList6.Items.Insert(0, "Select");
          
        }
        else
        {
            
            pnl1.Visible = false;
            gd.Visible = false;
            pnn.Visible = false;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
           if (DropDownList1.SelectedItem.Text == "Yes")
           {

               Panel1.Visible = true;
              
              
           }
           else
           {
               Panel1.Visible = false;
             
              
           }
    
    }
   
    protected void add_Click(object sender, EventArgs e)
    {
         
        dt = (DataTable)ViewState["cur1"];
        DataRow dr = dt.NewRow();
        dr["Reviewer"] = DropDownList7.SelectedItem.Text;
        dr["crossfunreviwer"] = DropDownList6.SelectedItem.Text;
        dr["prioritycode"] = ddlrioritycode.SelectedItem.Text;

        dr["Priority"] = txtpriority.SelectedItem.Text;

        dr["tgtcmpltndate"] = txtcmpdate.Text;
        dr["Timeline"] = txttime.Text;
        dt.Rows.Add(dr);
        gd.DataSource = dt;
        gd.DataBind();
        gd.Visible = true;

       
    // gd.Columns[0].Visible = false;
      //  gd.Columns[1].Visible = false;

   gd.Columns[5].Visible = false;


        if (DropDownList3.SelectedItem.Text == "Yes")
        {
            gd.Visible = true;
            if (txtpriority.SelectedItem.Text == "Priority of routing")
            {
                //if (gd.Visible == true)
                //{
                ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("0"));
                foreach (GridViewRow gvrow in gd.Rows)
                {

                    if (gvrow.Cells[1].Text == "1")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("1"));
                    }
                    else if (gvrow.Cells[1].Text == "2")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("2"));
                    }
                    else if (gvrow.Cells[1].Text == "3")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("3"));
                    }
                    else if (gvrow.Cells[1].Text == "4")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("4"));
                    }
                    else if (gvrow.Cells[1].Text == "5")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("5"));
                    }
                    else if (gvrow.Cells[1].Text == "6")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("6"));
                    }
                    else if (gvrow.Cells[1].Text == "7")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("7"));
                    }
                    else if (gvrow.Cells[1].Text == "8")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("8"));
                    }
                    else if (gvrow.Cells[1].Text == "9")
                    {
                        ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("9"));
                    }
                }
            }
            //else if (txtpriority.SelectedItem.Text == "Parallel routing")
            //{

            //    ddlrioritycode.SelectedItem.Text = "0";
            //}
            //else
            //{

            //    ddlrioritycode.SelectedIndex = -1;
            //}
        }
        // }
        else
        {

            dr["prioritycode"] = ddlrioritycode.SelectedItem.Text;

        }
    
        DropDownList6.SelectedIndex = 0;
        DropDownList7.SelectedIndex = 0;
        txtcmpdate.Text = "";
        txttime.Text = "";
        txtpriority.SelectedIndex = -1;
        ddlrioritycode.SelectedIndex =-1;
        ViewState["cur1"] = dt;
        Session.Remove("functionrev");
        string meth = "functionreview addgrid";
        fun1(meth);
       
    }
    protected void add1_Click(object sender, EventArgs e)
    {
        string meth = "action addgrid";
        fun1(meth);
        dt1 = (DataTable)ViewState["cur"];
        DataRow dr = dt1.NewRow();
     
        dr["actnitmdesc"] = txtdesc.Text;
      
        dr["Executor"] = DropDownList8.SelectedItem.Text;
        dr["Reviewer1"] = DropDownList9.SelectedItem.Text;

        dr["department"] = ddldept.SelectedItem.Text;

        dr["depthod"] = ddldepthod.SelectedItem.Text;
        dr["Timeline1"] = txttime1.Text;
       
      
        dt1.Rows.Add(dr);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
        GridView1.Visible = true;
       GridView1.Columns[2].Visible=false;
       GridView1.Columns[3].Visible = false;
        txtdesc.Text = "";
        DropDownList8.SelectedIndex = 0;
        DropDownList9.SelectedIndex = 0;

        ddldepthod.SelectedIndex = 0;
        ddldept.SelectedIndex = 0;
       
       
        txttime1.Text = "";
        ViewState["cur"] = dt1;
        

    }
  
   
    protected void Button9_Click(object sender, EventArgs e)
    {
   
        Response.Redirect("Default.aspx");
   
    }
    public string  fun1(string meth)
    {
       // Session.Remove("functionrev");
        functionrev = meth;
        Session["funrev"] = functionrev;
      
       return functionrev;
    }

   
    protected void submit_Click(object sender, EventArgs e)
    {
        //connection is opened
        Connection.Open();
        //insert all fileds
     submitmethod();
        pnl111.Visible = false;
        content.Visible = false;
       //connection is closed

        Session.Remove("functionrev");
        //Session.Abandon();
        Connection.Close();
    }
    private void submitmethod()
    {
        

       // string funrev = functionrev;
        int cstatus = 4;
        int status = 1;
        //assign all fileds to that properties
        coordprop.comments = txtcomment.Text;
        coordprop.funreview = DropDownList3.SelectedItem.Text;
        coordprop.changeid = lbltext.Text;
        coordprop.submit = "";
        coordprop.status = status;
        coordprop.Curstatus = cstatus;
        coordprop.actitmtree = DropDownList1.SelectedItem.Text;

        coordprop.priority = txtpriority.SelectedItem.Text;
        coordprop.prioritycode = ddlrioritycode.SelectedItem.Text;
        coordprop.crossfunreviwer = DropDownList6.SelectedItem.Text;
        coordprop.Timeline = txttime.Text;
        coordprop.Reviewer = DropDownList7.SelectedItem.Text;
        coordprop.tgtcmpltndate = txtcmpdate.Text;

        coordprop.actnitmdesc = txtdesc.Text;
        coordprop.Executor = DropDownList8.SelectedItem.Text;
        coordprop.Reviewer1 = DropDownList9.SelectedItem.Text;
        coordprop.department = ddldept.SelectedItem.Text;
        coordprop.depthod = ddldepthod.SelectedItem.Text;
        coordprop.Timeline1 = txttime1.Text;

        string funrev = Convert.ToString(Session["funrev"]);


        
             SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator where  changeid='"+lbltext.Text+"' ", Connection);
             DataSet ds1 = new DataSet();
             da1.Fill(ds1);
             int sstatus =Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
             int curtatus = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);

             if (sstatus == 1 && curtatus == 9 || (curtatus == 8 && sstatus == 2))
             {
                
                 
                 SqlCommand cmd1 = new SqlCommand("update CMS_Initiator set status=81 ,Curstatus=4 ,cftstus=0,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "' ", Connection);
                 Connection.Open();
                 cmd1.ExecuteScalar();
                 Connection.Close();
             }

             else if (sstatus == 1 && curtatus == 10)
             {
                 
                
                 SqlCommand cmd1 = new SqlCommand("update CMS_Initiator set status=81 ,Curstatus=4 ,cftstus=0,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "' ", Connection);
                 Connection.Open();
                 cmd1.ExecuteScalar();
                 Connection.Close();
             }
             else
             {
                 if (coordprop.funreview == "Yes")
                 {
                     pnn.Visible = true;
                     pnl1.Visible = true;

                     if (funrev == "functionreview addgrid")
                     {
                         gd.Visible = true;

                         foreach (GridViewRow functionrevgd in gd.Rows)
                         {
                             for (int i = 0; i < gd.Rows.Count; i++)
                             {
                                 coordprop.priority = functionrevgd.Cells[0].Text;
                                 coordprop.prioritycode = functionrevgd.Cells[1].Text;
                                 coordprop.crossfunreviwer = functionrevgd.Cells[2].Text;
                                 coordprop.Timeline = functionrevgd.Cells[3].Text;
                                 coordprop.Reviewer = functionrevgd.Cells[4].Text;
                                 coordprop.tgtcmpltndate = functionrevgd.Cells[5].Text;
                             }
                             if (coordprop.actitmtree != "Yes")
                             {

                                 Panel1.Visible = false;
                                 coordprop.actnitmdesc = "no action desc";
                                 coordprop.Executor = "no executor";
                                 coordprop.Reviewer1 = "no reviewer";
                                 coordprop.department = "no department";
                                 coordprop.depthod = "no dept hod";
                                 coordprop.Timeline1 = "no timeline";
                             }

                             else if (coordprop.actitmtree == "Yes")
                             {

                                 foreach (GridViewRow actiongd in GridView1.Rows)
                                 {
                                     for (int i = 0; i < GridView1.Rows.Count; i++)
                                     {
                                         coordprop.actnitmdesc = actiongd.Cells[0].Text;
                                         coordprop.Executor = actiongd.Cells[1].Text;
                                         coordprop.Reviewer1 = actiongd.Cells[2].Text;
                                         coordprop.department = actiongd.Cells[3].Text;
                                         coordprop.depthod = actiongd.Cells[4].Text;
                                         coordprop.Timeline1 = actiongd.Cells[5].Text;
                                     }
                                 }

                             }

                             t = coordmethod.insertcoord(coordprop.comments, coordprop.crossfunreviwer, coordprop.tgtcmpltndate, coordprop.Reviewer, coordprop.Timeline,
                           coordprop.actnitmdesc, coordprop.Executor, coordprop.changeid, coordprop.submit, coordprop.Reviewer1, coordprop.department, coordprop.depthod,
                            coordprop.Timeline1, coordprop.status, coordprop.Curstatus, coordprop.priority, coordprop.actitmtree, coordprop.funreview, coordprop.prioritycode);
                             if (t == true)
                             {
                                 SqlDataAdapter dastatus = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + lbltext.Text + "'", Connection);
                                 DataSet dsstatus = new DataSet();
                                 dastatus.Fill(dsstatus);
                                 if (dsstatus.Tables[0].Rows.Count > 0)
                                 {
                                     int cstatusc = Convert.ToInt32(dsstatus.Tables[0].Rows[0]["Curstatus"]);
                                     int statusc = Convert.ToInt32(dsstatus.Tables[0].Rows[0]["status"]);
                                 }
                                 SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set status=1 ,Curstatus=4 ,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "' ", Connection);
                                 DataSet ds = new DataSet();
                                 da.Fill(ds);
                             }
                         }


                     }
                     else if (funrev == "")
                     {
                         gd.Visible = false;
                         coordprop.priority = txtpriority.SelectedItem.Text;
                         coordprop.prioritycode = ddlrioritycode.SelectedItem.Text;
                         coordprop.crossfunreviwer = DropDownList6.SelectedItem.Text;
                         coordprop.Timeline = txttime.Text;
                         coordprop.Reviewer = DropDownList7.SelectedItem.Text;
                         coordprop.tgtcmpltndate = txtcmpdate.Text;



                         t = coordmethod.insertcoord(coordprop.comments, coordprop.crossfunreviwer, coordprop.tgtcmpltndate, coordprop.Reviewer, coordprop.Timeline,
                            coordprop.actnitmdesc, coordprop.Executor, coordprop.changeid, coordprop.submit, coordprop.Reviewer1, coordprop.department, coordprop.depthod,
                            coordprop.Timeline1, coordprop.status, coordprop.Curstatus, coordprop.priority, coordprop.actitmtree, coordprop.funreview, coordprop.prioritycode);
                         if (t == true)
                         {
                             SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set status=1 ,Curstatus=4 ,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "' ", Connection);
                             DataSet ds = new DataSet();
                             da.Fill(ds);
                         }
                     }

                 }
                 else if (coordprop.funreview == "No")
                 {
                     pnn.Visible = false;
                     pnl1.Visible = false;
                     coordprop.crossfunreviwer = "no function rev";
                     coordprop.tgtcmpltndate = "no date";
                     coordprop.Reviewer = "no rev";
                     coordprop.Timeline = "no timeline";
                     coordprop.priority = "no priority";
                     coordprop.prioritycode = "no priority code";


                     if (coordprop.actitmtree == "Yes")
                     {

                         Panel1.Visible = true;
                         if (funrev == " action addgrid")
                         {
                             GridView1.Visible = true;

                             foreach (GridViewRow actionaddgd in GridView1.Rows)
                             {

                                 coordprop.actnitmdesc = actionaddgd.Cells[0].Text;
                                 coordprop.Executor = actionaddgd.Cells[1].Text;
                                 coordprop.Reviewer1 = actionaddgd.Cells[2].Text;
                                 coordprop.department = actionaddgd.Cells[3].Text;
                                 coordprop.depthod = actionaddgd.Cells[4].Text;
                                 coordprop.Timeline1 = actionaddgd.Cells[5].Text;
                             }
                         }
                         else if (funrev == "")
                         {

                             coordprop.actnitmdesc = txtdesc.Text;
                             coordprop.Executor = DropDownList8.SelectedItem.Text;
                             coordprop.Reviewer1 = DropDownList9.SelectedItem.Text;
                             coordprop.department = ddldept.SelectedItem.Text;
                             coordprop.depthod = ddldepthod.SelectedItem.Text;
                             coordprop.Timeline1 = txttime1.Text;
                         }


                     }
                     else if (coordprop.actitmtree == "No")
                     {
                         Panel1.Visible = false;
                         coordprop.actnitmdesc = "no action desc";
                         coordprop.Executor = "no executor";
                         coordprop.Reviewer1 = "no reviewer";
                         coordprop.department = "no department";
                         coordprop.depthod = "no dept hod";
                         coordprop.Timeline1 = "no timeline";

                     }

                     t = coordmethod.insertcoord(coordprop.comments, coordprop.crossfunreviwer, coordprop.tgtcmpltndate, coordprop.Reviewer, coordprop.Timeline,
                          coordprop.actnitmdesc, coordprop.Executor, coordprop.changeid, coordprop.submit, coordprop.Reviewer1, coordprop.department, coordprop.depthod,
                          coordprop.Timeline1, coordprop.status, coordprop.Curstatus, coordprop.priority, coordprop.actitmtree, coordprop.funreview, coordprop.prioritycode);
                     if (t == true)
                     {
                         SqlDataAdapter da = new SqlDataAdapter("update CMS_Initiator set status=1 ,Curstatus=4 ,updatedate='" + System.DateTime.Now.ToString() + "' where Changeid='" + lbltext.Text + "' ", Connection);
                         DataSet ds = new DataSet();
                         da.Fill(ds);
                     }
                 }


             }
       
        string s = lbltext.Text;
        SendMailVeh_Rentals(s);

        SqlDataAdapter dacrd = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + lbltext.Text + "'", Connection);
        DataSet dscrd = new DataSet();
        dacrd.Fill(dscrd);
        if (dscrd.Tables[0].Rows.Count > 0)
        {
           
            lblwait.Visible = false;
        }
        audithistory();

       ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Successfully Submitted. and send mail to initiator')", true);
        DropDownList6.SelectedItem.Text = "Select";

        txtcomment.Text = "";
        DropDownList3.SelectedIndex = 0;
        txtcmpdate.Text = "";
        DropDownList7.SelectedIndex = 0;
      
        txttime.Text = "";
        txtdesc.Text = "";
    }


 
    private void audithistory()
    {
        
        SqlDataAdapter da1 = new SqlDataAdapter("select  * from CMS_Initiator where changeid='" + lbltext.Text + "' ", Connection);

        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        string assigned = "";
        string activity = "";
        int s = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);
        int st = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if ((s == 81 && st == 4))
            {
                activity = "Coordinator Assigned To Approver";
                assigned = "Approver";

            }

            if (s == 4 && st == 0)
            {
                activity = "Coordinator Rejected This Request";
                assigned = "Coordinator";

            }

            else if (s == 4 && st == 2)
            {
                activity = "Coordinator Return The Request for additional information";
                assigned = "Reviewer";

            }

            else if (s == 4 && st == 1)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from cms_coordinator where changeid='" + lbltext.Text + "'", Connection);
                DataSet dscft = new DataSet();
                da.Fill(dscft);
                if (dscft.Tables[0].Rows.Count > 0)
                {
                    string fnrev = Convert.ToString(dscft.Tables[0].Rows[0]["funreview"]);
                    if (fnrev == "Yes")
                    {
                        assigned = "CFT";
                        activity = "Coordinator Request Assigned to CFT";

                    }
                    else
                    {
                        assigned = "Approver";
                        activity = "Coordinator Request Assigned to Approver";

                    }
                }
            }
            else if (s == 4 && st == 11)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from cms_coordinator where changeid='" + lbltext.Text + "'", Connection);
                DataSet dscft = new DataSet();
                da.Fill(dscft);
                if (dscft.Tables[0].Rows.Count > 0)
                {
                    string fnrev = Convert.ToString(dscft.Tables[0].Rows[0]["funreview"]);
                    string acttree = Convert.ToString(dscft.Tables[0].Rows[0]["actitmtree"]);
                    if (fnrev == "Yes" && acttree == "No")
                    {
                        assigned = "Approver";
                        activity = "Coordinator CFT Request Assigned to Approver";

                    }
                    else
                    {
                        assigned = "RACG";
                        activity = "Coordinator CFT Request Assigned to RACG";

                    }
                }


            }
            else if (s == 4 && st == 10)
            {
                assigned = "Coordinator";
                activity = "Coordinator Rejected CFT Request";

            }
            else if (s == 4 && st == 12)
            {
                assigned = "Coordinator";
                activity = "Coordinator Return The CFT Request for additional information";

            }
            else if (s == 4 && st == 21)
            {
                assigned = "Approver";
                activity = "Coordinator RACG Request Assigned to Approver";

            }
            else if (s == 4 && st == 20)
            {
                assigned = "Coordinator";
                activity = "Coordinator Rejected RACG Request";

            }
            else if (s == 4 && st == 22)
            {
                assigned = "Coordinator";
                activity = "Coordinator Return The RACG Request for additional information";

            }
        }
        string role = Convert.ToString(Session["userrolename"]); ;
        int rcode = 4;
      
        auditpop.auditChangeid = lbltext.Text;
        auditpop.auditrole = role;
        auditpop.audituserid = lbluname.Text;
        auditpop.auditactivity = activity;
        auditpop.audittimestamp = DateTime.Now.ToString();
        auditpop.auditrolecode = rcode;
        auditpop.auditassignedto = assigned;

        string sMyData = string.Empty;
        string funrev = Convert.ToString(Session["funrev"]);
        string submitrevres = string.Empty;


        if (funrev == "functionreview addgrid")
        {
            gd.Visible = true;
           
            foreach (GridViewRow dr in gd.Rows)
            {
                //sMyData  = sMyData + "," + gd.Columns[4].ToString();
                for (int i = 0; i < gd.Rows.Count; i++)
                {

                   // sMyData = Convert.ToString(dr.Cells[4].Text) + ",";
                    
               
                        coordprop.Reviewer = dr.Cells[4].Text;
                        
                    
                }
               // submitrevres += sMyData;
                //submitrevres = submitrevres.TrimEnd(',');
                auditpop.Submitreviewer = coordprop.Reviewer;
                bool t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
                            auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);
           
            }

            
           
        }
        else
        {
             auditpop.Submitreviewer = DropDownList7.SelectedItem.Text;

            bool t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
                        auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);
        }
       Connection.Close();
       

    }
    private void SendMailVeh_Rentals(string message)
    {
        string Msg = "";
        string UMail = ConfigurationManager.AppSettings["mailid"].ToString();
        string UName = "Coordinator";
        try
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("infocmsproject@gmail.com");
            mm.To.Add(UMail);
            //mm.Bcc.Add("test_indus@yahoo.com");
            Msg += "Dear " + UName + ",<br>" +
                    "<br> Your Request is :" + message;
            mm.Subject = "Message From CMS Coordinator";
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
    protected void lnllogout(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void linkassign_Click(object sender, EventArgs e)
    {
        
       
        category = "assignment";
        lblassign.CssClass = "active";
        lblitems.CssClass = "lnkcolor";
        lnknew.CssClass = "lnkcolor";
        content.Visible = false;
        //user.Visible = false;
      
        assignbind();
    }

   
    protected void lnkact_Click(object sender, EventArgs e)
    {
        
        category = "act";
        lblitems.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        lnknew.CssClass = "lnkcolor";
        content.Visible = false;
        //user.Visible = false;
       
        actionbinding();
    }
    protected void lnknew_Click(object sender, EventArgs e)
    {

    }
  
    protected void actionbinding()
    {
        string name1 = Convert.ToString(Session["uname"]);
        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where (Curstatus=3 and status=1)  order by updatedate asc ", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
      

    }
    protected void assignbind()
    {
        
    }
    protected void statuscord()
    {
        string crdres = Convert.ToString(Session["coordrevs"]);

      string   ass = Convert.ToString(Session["resss"]);
       string  abs = Convert.ToString(Session["resss1"]);

       string ass1 = Convert.ToString(Session["revres1"]);
       string abs1 = Convert.ToString(Session["revres2"]);


       string ass12 = Convert.ToString(Session["resss1"]);
       string abs12 = Convert.ToString(Session["resss11"]);
       string crdres1 = ass1 + "" + abs1;
        SqlDataAdapter da=new SqlDataAdapter("select * from cms_initiator where changeid='"+lbltext.Text+"'",Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int status =Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);
            int cstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Curstatus"]);
            int cftstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["cftstatus"]);
            if (status == 1 && cstatus == 4 )
            {
                if (cftstatus == 91)
                {

                    Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert(' " + crdres1 + "')</script>");
            lblstat.Text=crdres1;
                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Assigned To " + crdres + " Reviewers')</script>");
                 lblstat.Text="Assigned To " + crdres + " Reviewers";
                }
            }
            else if (status == 1 && cstatus == 9)
            {

                string res = ass + "," + abs;
               // Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('status is:" + ass12 + "" + abs12 + " .')</script>");
    lblstat.Text="status is:" + ass12 + " " + abs12 + " .";
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

    protected void bindmethod()
    {
        category = "assignment";
        lblassign.CssClass = "active";
        lblitems.CssClass = "lnkcolor";
        btns.Visible = true;

        string lnkgmid = Convert.ToString(Session["cmid"]);
        
       
        //temp = ddlid.SelectedItem.Text.ToString();
        SqlDataAdapter da1 = new SqlDataAdapter("select substring(CDesc,1,20)as cdesc,* from CMS_Initiator where changeid='" + lnkgmid + "'", Connection);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        int sta=Convert.ToInt32( ds1.Tables[0].Rows[0]["status"]);
        int cursta =Convert.ToInt32( ds1.Tables[0].Rows[0]["Curstatus"]);
       


        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + lnkgmid + "' order by PostDate desc", Connection);
        DataSet ds = new DataSet();

        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
           // btns.Visible = false;
            pnl111.Visible = true;
            content.Visible = true;

            lbltext.Text = lnkgmid;
            txtcomment.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
            DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["funreview"].ToString();

 
               // DropDownList1.SelectedIndex = -1;

                if (ds.Tables[0].Rows[0]["funreview"].ToString() == "Yes")
                {
                    DropDownList3.SelectedItem.Text = "Yes";
                    Panel1.Visible = false;
                    pnl1.Visible = false;
                    pnn.Visible = false;
                    gd.Visible = true;
                  
                    dt = (DataTable)ViewState["cur1"];

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + lnkgmid + "' order by PostDate asc", Connection);
                    DataSet dscft = new DataSet();
                    da11.Fill(dscft, "coord");
                    foreach (DataRow dr in dscft.Tables["coord"].Rows)
                    {
                        DataRow dr2 = dt.NewRow();

                        gd.Columns[1].Visible = false;
                        gd.Columns[0].Visible = false;
                        gd.Columns[5].Visible = false;
                        dr2["crossfunreviwer"] = Convert.ToString((dr["crossfunreviwer"]));
                        dr2["tgtcmpltndate"] = Convert.ToString((dr["tgtcmpltndate"]));
                        dr2["Reviewer"] = Convert.ToString((dr["Reviewer"]));
                        dr2["Timeline"] = Convert.ToString((dr["Timeline"]));
                        dr2["prioritycode"] = Convert.ToString((dr["prioritycode"]));
                        dr2["priority"] = Convert.ToString((dr["priority"]));
                        dt.Rows.Add(dr2);

                    }
                    gd.DataSource = dt;
                    gd.DataBind();
                    gd.Enabled = false;
                    gd.Visible = true;

                }
                else
                {
                    DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["funreview"].ToString();
                }
                txtdesc.Text = ds.Tables[0].Rows[0]["actnitmdesc"].ToString();
                DropDownList8.SelectedItem.Text = ds.Tables[0].Rows[0]["Executor"].ToString();
                DropDownList9.SelectedItem.Text = ds.Tables[0].Rows[0]["Reviewer1"].ToString(); ;
                ddldept.SelectedItem.Text = ds.Tables[0].Rows[0]["department"].ToString();
                ddldepthod.SelectedItem.Text = ds.Tables[0].Rows[0]["depthod"].ToString();
                txttime1.Text = ds.Tables[0].Rows[0]["Timeline1"].ToString();
                txtpriority.SelectedItem.Text = ds.Tables[0].Rows[0]["priority"].ToString();
                // DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["actitmtree"].ToString();
                ddlrioritycode.SelectedItem.Text = ds.Tables[0].Rows[0]["prioritycode"].ToString();
                DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["actitmtree"].ToString();
                if (ds.Tables[0].Rows[0]["actitmtree"].ToString() == "Yes")
                {
                   // GridView1.Columns[5].Visible = false;
                   // GridView1.Columns[6].Visible = false;
                   // GridView1.Columns[7].Visible = false;
                    DropDownList1.SelectedItem.Text = "Yes";
                    Panel1.Visible = false;
                    GridView1.Visible = true;

                    dt1 = (DataTable)ViewState["cur"];

                    SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + lnkgmid + "' order by PostDate desc", Connection);
                    DataSet dscft = new DataSet();
                    da11.Fill(dscft, "coord");
                    foreach (DataRow dr in dscft.Tables["coord"].Rows)
                    {
                        DataRow dr2 = dt1.NewRow();
                        dr2["actnitmdesc"] = Convert.ToString((dr["actnitmdesc"]));
                        dr2["Executor"] = Convert.ToString((dr["Executor"]));
                        dr2["Reviewer1"] = Convert.ToString((dr["Reviewer1"]));
                        dr2["TimeLine1"] = Convert.ToString((dr["TimeLine1"]));
                       // dr2["prioritycode"] = Convert.ToString((dr["prioritycode"]));
                        dr2["department"] = Convert.ToString((dr["department"]));
                        dr2["depthod"] = Convert.ToString((dr["depthod"]));
                        //dr2["priority"] = Convert.ToString((dr["priority"]));
                        dt1.Rows.Add(dr2);
                    }
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    GridView1.Enabled = false;
                    GridView1.Visible = true;

                }
                else
                {
                    Panel1.Visible = false;
                    GridView1.Visible = false;
                }

         
            btns.Visible = true;
        }

        else
        {
            if (userroleid == 4)
            {
                lbltext.Text = lnkgmid;
                pnl111.Visible = true;
                content.Visible = true;
                trwaiting.Visible = true;

                lblwait.Text = "Waiting For Approving This '" + lnkgmid + "' Request";
            }
            else
            {
                lbltext.Text = lnkgmid;
                pnl111.Visible = true;
                content.Visible = true;
                trwaiting.Visible = false;
            }
            string strScript = "alert('Coordinator not perform any action to this '" + lnkgmid + "' record');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);

        }
    }
   
    protected void clickid(object sender, EventArgs e)
    {
       
        LinkButton ln = sender as LinkButton;
        lbltext.Text = ln.CommandArgument.ToString();
       

        SqlDataAdapter da2 = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + ln.CommandArgument.ToString() + "' ", Connection);
        DataSet ds = new DataSet();
        da2.Fill(ds);
        int s = Convert.ToInt32(ds.Tables[0].Rows[0]["Curstatus"]);
        int st = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //btns.Visible = false;
            lblassign.CssClass = "active";
            lblitems.CssClass = "lnkcolor";
            content.Visible = true;
            //  user.Visible = true;
           
            pnl111.Visible = true;
            pnl1.Visible = true;

                            dt1 = (DataTable)ViewState["cur"];
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + lbltext.Text + "' order by PostDate desc", Connection);
                            DataSet dscft = new DataSet();
                            da11.Fill(dscft, "coord");
                            foreach (DataRow dr in dscft.Tables["coord"].Rows)
                            {
                                DataRow dr2 = dt1.NewRow();
                                dr2["actnitmdesc"] = Convert.ToString((dr["actnitmdesc"]));
                                dr2["Executor"] = Convert.ToString((dr["Executor"]));
                                dr2["Reviewer1"] = Convert.ToString((dr["Reviewer1"]));
                                dr2["TimeLine1"] = Convert.ToString((dr["TimeLine1"]));
                                dr2["prioritycode"] = Convert.ToString((dr["prioritycode"]));
                                
                                dr2["department"] = Convert.ToString((dr["department"]));
                                dr2["depthod"] = Convert.ToString((dr["depthod"]));
                                dr2["priority"] = Convert.ToString((dr["priority"]));
                               
                                dt1.Rows.Add(dr2);

                            }
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            GridView1.Enabled = false;
                            GridView1.Visible = true;
                            
                        
                    

        }
        else
        {
           
        }

        
    }
   

    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        
          DataSet ds1 = new DataSet();
          SqlDataAdapter das=new SqlDataAdapter("select * from CMM_Departments where DeptDesc='"+DropDownList6.SelectedItem.Text+"'",Connection);
          das.Fill(ds1);
          int deptno =Convert.ToInt32(ds1.Tables[0].Rows[0]["DeptId"]);
          SqlDataAdapter da = new SqlDataAdapter("select * from CMM_Loginusers where Department=" + deptno + " and RoleCode=3", Connection);
          DataSet ds = new DataSet();
          da.Fill(ds);

          string sMyData = string.Empty;
          foreach (DataRow dr in ds.Tables[0].Rows)
          {
              sMyData = sMyData + "," + dr["UserId"].ToString();
          }


          sMyData = sMyData.TrimEnd(',');

          string[] arr = Regex.Split(sMyData, ",");
          
              
          SqlDataAdapter dadeptcrd = new SqlDataAdapter("select * from CMS_Coordinator where changeid='" + lbltext.Text + "'", Connection);
          DataSet dsdeptcrd = new DataSet();
          dadeptcrd.Fill(dsdeptcrd);
          if (dsdeptcrd.Tables[0].Rows.Count > 0)
          {
              string ab = "";
              string fundeptrev = Convert.ToString(dsdeptcrd.Tables[0].Rows[0]["Reviewer"]);
            
              foreach (var word in arr)
              {
                  //return word;
                  Console.WriteLine(word);
                  ab = word;

                  if (ab != fundeptrev)
                  {

                      DropDownList7.DataSource = ds;
                      DropDownList7.DataValueField = "UserId";
                      DropDownList7.DataTextField = "UserId";
                      DropDownList7.DataBind();
                      DropDownList7.Items.Insert(0, "Select");
                  }

                  else if (ab == fundeptrev)
                  {

                      string rev = "(select * from CMM_Loginusers where Department=" + deptno + " and RoleCode=3) EXCEPT (SELECT  * FROM CMM_Loginusers where Department=" + deptno + " and UserId='" + fundeptrev + "' and RoleCode=3)";
                      SqlDataAdapter dabind = new SqlDataAdapter(rev, Connection);
                      DataSet dsbind = new DataSet();
                      dabind.Fill(dsbind);
                      DropDownList7.DataSource = dsbind;
                      // DropDownList7.DataValueField = "UserId";
                      DropDownList7.DataTextField = "UserId";
                      DropDownList7.DataBind();
                      DropDownList7.Items.Insert(0, "Select");
                      break;
                  }


              }
          }
          else
          {

              DropDownList7.DataSource = ds;
              DropDownList7.DataValueField = "UserId";
              DropDownList7.DataTextField = "UserId";
              DropDownList7.DataBind();
              DropDownList7.Items.Insert(0, "Select");
          }
         
        
       
    }
  
    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet ds1 = new DataSet();
        SqlDataAdapter das = new SqlDataAdapter("select * from CMM_Departments where DeptDesc='" + ddldept.SelectedItem.Text + "'", Connection);
        das.Fill(ds1);
        int deptno = Convert.ToInt32(ds1.Tables[0].Rows[0]["DeptId"]);
        SqlDataAdapter da = new SqlDataAdapter("select * from CMM_Loginusers where Department=" + deptno + " and RoleCode=3", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList9.DataSource = ds;
        DropDownList9.DataValueField = "UserId";
        DropDownList9.DataTextField = "UserId";
        DropDownList9.DataBind();
        DropDownList9.Items.Insert(0, "Select");

       
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtpriority_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtpriority.SelectedItem.Text == "Parallel routing")
        {
            
            tdpri.Visible = true;
         
         ddlrioritycode.SelectedItem.Text = "0";
          
           
            ddlrioritycode.Enabled = false;
        }
        else if (txtpriority.SelectedItem.Text == "Priority of routing")
        {
            tdpri.Visible = true;
            ddlrioritycode.Enabled = true;
           
            ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("0"));
            ddlrioritycode.SelectedIndex =0;
        }
        else if (txtpriority.SelectedItem.Text == "Select")
        {
            tdpri.Visible = true;
            ddlrioritycode.Enabled = true;
            //ddlrioritycode.SelectedIndex = -1;
           
            ddlrioritycode.Items.Insert(0, "Select One");
            //ddlrioritycode.Items.Remove(ddlrioritycode.Items.FindByText("0"));
        
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        submitmethod();

        SqlCommand cmd = new SqlCommand("update cms_initiator set status=123 changeid='" + lbltext.Text + "'", Connection);
        Connection.Open();
        cmd.ExecuteScalar();
        Connection.Close();

       
        string strScript = "alert('Saved Successfully');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        submitmethod();

        SqlCommand cmd = new SqlCommand("update cms_initiator set status=123 changeid='" + lbltext.Text + "'", Connection);
        Connection.Open();
        cmd.ExecuteScalar();
        Connection.Close();
        string strScript = "alert('Save&closed Successfully');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string strScript = "alert('canceled');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
    }
    protected void btnaprver_Click(object sender, EventArgs e)
    {
        submitmethod();

        SqlCommand cmd = new SqlCommand("update cms_initiator set status=81 where changeid='" + lbltext.Text + "' and Curstatus=4", Connection);
        Connection.Open();
        cmd.ExecuteScalar();
        Connection.Close();
    }
 
}
