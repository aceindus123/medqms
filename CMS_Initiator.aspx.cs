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
using System.Drawing.Text;
using cmm.DataAccessLayer;
using cmm.errorexcep;
using cmm.Initiator;
using cmm.Initiatorproperties;
using cmm.audithistory;
using cmm.audithistoryproperties;
using cmm.departments;
using System.Text.RegularExpressions;

public partial class CMS_Initiator : System.Web.UI.Page
{
    bool t;
    static int rowCount;
    SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string imgPath;
    string strScript = "";
    string imgName;
    string imgpath1 = "";
    string imgname1 = "";
    string a;
    string temp;
    string temp1;
    string b;
    public static string category;
    static string excep_page = "CMS_Initiator.aspx";
    error err = new error();
    Initiator initiate = new Initiator();
    Initiatorproperties initproperties = new Initiatorproperties();
    audithistorymethod auditinsert = new audithistorymethod();
    audithistoryproperties auditpop = new audithistoryproperties();
    int userroleid;
    string userrolename;
    string assigned;
    string changeid1 = "";
    DataTable dt;
    DataTable dt1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
          
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Session Closed.Please ReLogin into medqms')", true);

            Response.Redirect("default.aspx");
        }
         userroleid = Convert.ToInt32(Session["userroleid"]);
         userrolename = Convert.ToString(Session["userrolename"]);
         string name = Convert.ToString(Session["uname"]);
         string chmid = Convert.ToString(Session["cmid"]);
        //string chmidi = Convert.ToString(Request.QueryString["parameter"]);
         //string ab = Convert.ToString(Request.QueryString["parameter"]);
         string ab = Convert.ToString(Page.RouteData.Values["parameter"]);
         //string ba = Convert.ToString(Request.QueryString["param1"]);
         string ba = Convert.ToString(Page.RouteData.Values["param1"]);
         string umrolname = Convert.ToString(Session["umroles"]);
         string gid = Convert.ToString(Session["gvcid"]);
        lbluname.Text = name;

      

        if (name != null)
        {
            lbluname.Text = name;
        }
        else
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("logincms");
        }
        //lblassign.Text = name + " "+ "Assignments";
        //lblitems.Text = name +" "+ "Action Items";
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;

        DateTime theDate = DateTime.Now;
        //string format = "d MMM yyyy";
        string postdate = theDate.ToString();
        
        if (!IsPostBack)
        {
            trst.Visible = false;
            trbody.Visible = true;
           
            department dept = new department();
            dept.departmentbinding(DropDownList5);
            if (umrolname == "Initiator&Reviewer")
            {
                if (ab == "Initiator1")
                {
                    tbcontent.Visible = true;
                    trst.Visible = true;
                    trbody.Visible = false;
                    trbtn.Visible = true;
                    chaneig.Visible = true;
                    bindmethod();
                    statusbind();

                }

                else if (ab == "newInitiator")
                {

                    trbody.Visible = true;
                    trst.Visible = true;
                    tdstatus.Visible = false;
                    lnknew.CssClass = "active";
                    lblassign.CssClass = "lnkcolor";
                    lblitems.CssClass = "lnkcolor";
                    trbtn.Visible = true;
                    chaneig.Visible = false;

                }
               
            }
            else 
            if (userroleid == 1)
            {
                 if (ab == "Initiator1")
                    {
                        
                        tbcontent.Visible = true;
                        trst.Visible = true;
                        trbody.Visible = true;
                        trbtn.Visible = true;
                        chaneig.Visible = true;
                        bindmethod();
                        statusbind();

                    }
                 

                 else if (ab == "newInitiator")
                 {

                     trbody.Visible = true;
                     trst.Visible = true;
                     tdstatus.Visible = false;
                     lnknew.CssClass = "active";
                     lblassign.CssClass = "lnkcolor";
                     lblitems.CssClass = "lnkcolor";
                     trbtn.Visible = true;
                     chaneig.Visible = false;
                 }

                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('"+lbluname.Text+"  Only View The Information.')</script>");
      
                if (ab == "Initiator1")
                {
                    
                    tbcontent.Visible = true;
                    trst.Visible = true;
                    trbody.Visible = false;
                    trbtn.Visible = true;
                    chaneig.Visible = false;
                    bindmethod();
                    statusbind();
                    EnableAllControlscolor(this.Page.Form.Controls, false);
                }
                else if (ab == "newInitiator")
                {

                    trbody.Visible = true;
                    trst.Visible = true;
                    tdstatus.Visible = false;
                    lnknew.CssClass = "active";
                    lblassign.CssClass = "lnkcolor";
                    lblitems.CssClass = "lnkcolor";
                    trbtn.Visible = true;
                    chaneig.Visible = false;
                    EnableAllControlscolor(this.Page.Form.Controls, false);

                }
              
            }

          
        }

        dt = new DataTable();

        dt.Columns.Add(new DataColumn("existing", typeof(string)));

        dt.Columns.Add(new DataColumn("proposal", typeof(string)));

        ViewState["cur"] = dt;

        dt1 = new DataTable();

        dt1.Columns.Add(new DataColumn("reschnge", typeof(string)));

        ViewState["cur1"] = dt1;
       
       
    }
   
    public void EnableAllControls(ControlCollection cc, bool enable)
    {
        foreach (Control c in cc)
        {
            try { EnableAllControls(c.Controls, enable); }
            catch { }
            if (c.GetType() == typeof(TextBox)) { try { ((TextBox)c).Enabled = enable;  } catch { } }
            else if (c.GetType() == typeof(DropDownList)) { try { ((DropDownList)c).Enabled = enable;  } catch { } }
            else if (c.GetType() == typeof(Button)) { try { ((Button)c).Enabled = enable;  } catch { } }
            else if (c.GetType() == typeof(RadioButtonList)) { try { ((RadioButtonList)c).Enabled = enable; } catch { } }
            // else if (c.GetType() == typeof(LinkButton)) { try { ((LinkButton)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(HtmlInputText)) { try { ((HtmlInputText)c).Attributes.Add("disabled", "true"); } catch { } }
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
            else if (c.GetType() == typeof(RadioButtonList)) { try { ((RadioButtonList)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(Button)) { try { ((Button)c).Enabled = enable; ((Button)c).CssClass = "readonlycolor"; } catch { } }
            // else if (c.GetType() == typeof(LinkButton)) { try { ((LinkButton)c).Enabled = enable; } catch { } }
            else if (c.GetType() == typeof(HtmlInputText)) { try { ((HtmlInputText)c).Attributes.Add("disabled", "true"); } catch { } }
        }
    }

    protected void bindreadonlylabels()
    {

        ddl1.Visible = false;
        lblrtchange.Visible = true;
        ddl2.Visible = false;
        lblrchperiod.Visible = true;
        DropDownList3.Visible = false;
        lclchangeclassification.Visible = true;
        DropDownList4.Visible = false;
        lblsrunit.Visible = true;
        DropDownList5.Visible = false;
        lblrdept.Visible = true;
        TextBox20.Visible = false;
        lblrcsource.Visible = true;
        DropDownList9.Visible = false;
        lblrcccat.Visible = true;
        txt4.Visible = false;
        lblrrid.Visible = true;
        ddl3.Visible = false;
        lblrcustomer.Visible = true;
        ddl4.Visible = false;
        lblrmarket.Visible = true;
        txt111.Visible = false;
        lblrlicense.Visible = true;
        txtdate.Visible = false;
        lblrcdesc.Visible = true;
        DropDownList2.Visible = false;
        lblrpimpact.Visible = true;
        DropDownList10.Visible = false;
        lblrpname.Visible = true;
        DropDownList11.Visible = false;
        lblrdosage.Visible = true;
        DropDownList6.Visible = false;
        lblrsafetyimpcat.Visible = true;
        DropDownList13.Visible = false;
        lblrrimpact.Visible = true;
        TextBox4.Visible = false;
        lblrrimpdesc.Visible = true;
        TextBox15.Visible = false;
        lblrexist.Visible = true;
        TextBox16.Visible = false;
        lblrrproposal.Visible = true;
        TextBox3.Visible = false;
        lblrrchange.Visible = true;
        TextBox13.Visible = false;
        lblrrelatedchanges.Visible = true;
        DropDownList1.Visible = false;
        lblrassignto.Visible = true;
    }
   
    protected void bindmethod()
    {
       
        string chmid = Convert.ToString(Session["cmid"]);
        lblid.Text = chmid;
        SqlDataAdapter da = new SqlDataAdapter("select substring(CDesc,1,20)as cesc,* from CMS_Initiator where Changeid='" + chmid + "'", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            category = "assignment";
            lblassign.CssClass = "active";
            lblitems.CssClass = "lnkcolor";
            lnknew.CssClass = "lnkcolor";

            trbtn.Visible = true;
            trbody.Visible = true;
            lblid.Text = chmid;
            chaneig.Visible = true;
            ddl1.SelectedValue = ds.Tables[0].Rows[0]["typechange"].ToString();
            
            ddl2.SelectedItem.Text = ds.Tables[0].Rows[0]["changeperiod"].ToString();
            DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["cclassification"].ToString();
            DropDownList4.SelectedItem.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
            DropDownList5.SelectedItem.Text = ds.Tables[0].Rows[0]["Dept"].ToString();
            TextBox20.Text = ds.Tables[0].Rows[0]["csource"].ToString();
            DropDownList9.SelectedItem.Text = ds.Tables[0].Rows[0]["ccategory"].ToString();
            txt4.Text = ds.Tables[0].Rows[0]["Refid"].ToString();
            ddl3.SelectedItem.Text = ds.Tables[0].Rows[0]["Customer"].ToString();
            ddl4.SelectedItem.Text = ds.Tables[0].Rows[0]["Market"].ToString();
            txt111.Text = ds.Tables[0].Rows[0]["License"].ToString();
            txtdate.Text = ds.Tables[0].Rows[0]["CDesc"].ToString();
            DropDownList2.SelectedItem.Text = ds.Tables[0].Rows[0]["pimpact"].ToString();
            DropDownList10.SelectedItem.Text = ds.Tables[0].Rows[0]["productname"].ToString();
            DropDownList11.SelectedItem.Text = ds.Tables[0].Rows[0]["dosfrom"].ToString();
            DropDownList6.SelectedItem.Text = ds.Tables[0].Rows[0]["simpact"].ToString();
            DropDownList13.SelectedItem.Text = ds.Tables[0].Rows[0]["rimpact"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["regimpdesc"].ToString();

            TextBox13.Text = ds.Tables[0].Rows[0]["relchngs"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["reschnge"].ToString();
            DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["submit"].ToString();
            // Label1.Text = ds.Tables[0].Rows[0]["Changeid"].ToString();
            //lbl2.Text = ds.Tables[0].Rows[0]["initdate"].ToString();
            //lbl1.Text = ds.Tables[0].Rows[0]["initby"].ToString();
            TextBox15.Text = ds.Tables[0].Rows[0]["existing"].ToString();
            TextBox16.Text = ds.Tables[0].Rows[0]["proposal"].ToString();

            //  Label1.Text = temp;
        }
        else
        {
            category = "assignment";
            lblassign.CssClass = "active";
            lblitems.CssClass = "lnkcolor";
            lnknew.CssClass = "lnkcolor";
            trbtn.Visible = true;
            trbody.Visible = true;
         
        }


    }
    protected void submit_Click(object sender, EventArgs e)
    {
        method();
        Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Successfully Submitted: Change Id is:" + changeid1 + " .')</script>");
        // Label1.Text = a;
    }
   
    private void method()
    {
        Initiatorproperties initpop = new Initiatorproperties();
        Initiator initbind = new Initiator();
        trst.Visible = true;
      
        trbody.Visible = true;
        string searchop= belowcontent.SelectedItem.Text;
        int cstatus = 1;
        int status = 1;
        int cftstatus = 0;
        Guid id = Guid.NewGuid();
        string s = id.ToString("N");
        string s1 = s.Substring(0, 5);
       // a = Label1.Text;
        a = s1;
        DataSet ds = new DataSet();
        DateTime theDate = DateTime.Now;
        //string format = "d MMM yyyy";
        string postdate = theDate.ToString();
        string year = DateTime.Now.Year.ToString().Substring(2); string Base_dir = System.AppDomain.CurrentDomain.BaseDirectory;
        // int length = FileUpload1.PostedFile.ContentLength;
        //create a byte array to store the binary image data
        try
        {
         if (FileUpload1.HasFile)
            {
                try
                {

                    if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
                    {
                        imgName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        //sets the image path
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Attachments/" + imgName));
                        //sets the image path

                        imgPath = "~/Attachments/" + imgName;
                        //then save it to the Folder

                        FileUpload1.SaveAs(Server.MapPath(imgPath));
                        using (System.Drawing.Image Img = System.Drawing.Image.FromFile(Server.MapPath("~/Attachments/" + imgName)))
                        {
                            //validates the posted file before saving

                            imgName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                            imgPath = "~/Attachments/" + imgName;

                            //insert_greet1
                            Connection.Open();

                            initpop.initchangeid = a;
                            initpop.initinitdate = postdate;
                            initpop.initinitby = lbluname.Text;
                            initpop.inittypechange = ddl1.SelectedItem.Text;
                            initpop.initchangeperiod = ddl2.SelectedItem.Text;
                            initpop.initcclassification = DropDownList3.SelectedItem.Text;
                            initpop.initUnit = DropDownList4.SelectedItem.Text;

                            initpop.initDept = DropDownList5.SelectedItem.Text;
                            initpop.initcsource = TextBox20.Text;
                            initpop.initccategory = DropDownList9.SelectedItem.Text;
                            initpop.initRefid = txt4.Text;
                            initpop.initCustomer = ddl3.SelectedItem.Text;
                            initpop.initMarket = ddl4.SelectedItem.Text;

                            initpop.initLicense = txt111.Text;
                            initpop.initCDesc = txtdate.Text;
                            initpop.initexisting = TextBox15.Text;
                            initpop.initproposal = TextBox16.Text;
                            initpop.initrelchngs = TextBox13.SelectedItem.Text;
                            initpop.initreschnge = TextBox3.Text;

                            initpop.initsubmit = DropDownList1.SelectedItem.Text;
                            initpop.initAttachments = imgPath;
                            initpop.initpimpact = DropDownList2.SelectedItem.Text;
                            initpop.initsimpact = DropDownList6.SelectedItem.Text;
                            initpop.initrimpact = DropDownList13.SelectedItem.Text;
                            initpop.initproductname = DropDownList10.SelectedItem.Text;

                            initpop.initdosfrom = DropDownList11.SelectedItem.Text;
                            initpop.initsafetyass = imgpath1;
                            initpop.initregimpdesc = TextBox4.Text;
                            initpop.initstatus = status;
                            initpop.initcstatus = cstatus;
                            initpop.initsearchcc = searchop;
                            initpop.initupdatedate = postdate;


                            t = initbind.Insertinitiator(initpop.initchangeid, initpop.initinitdate, initpop.initinitby, initpop.inittypechange,
                                initpop.initchangeperiod, initpop.initcclassification, initpop.initUnit, initpop.initDept, initpop.initcsource,
                                initpop.initccategory, initpop.initRefid, initpop.initCustomer, initpop.initMarket, initpop.initLicense,
                                initpop.initCDesc, initpop.initexisting, initpop.initproposal, initpop.initrelchngs, initpop.initreschnge,
                                initpop.initsubmit, initpop.initAttachments, initpop.initpimpact, initpop.initsimpact, initpop.initrimpact, initpop.initproductname,
                                initpop.initdosfrom, initpop.initsafetyass, initpop.initregimpdesc, initpop.initstatus, initpop.initcstatus, initpop.initsearchcc,
                                initpop.initupdatedate,cftstatus);

                            if (t == true)
                            {
                                Session["initdate"] = postdate;

                                SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator where initdate='" + Session["initdate"].ToString() + "'", Connection);
                                da1.Fill(ds);
                                int newsid = Convert.ToInt16(ds.Tables[0].Rows[0]["Iid"]);
                                string ids = "000";
                                string newid = "CR" + year + ids;
                                string modurl = newid + newsid;

                                SqlCommand cmd23 = new SqlCommand("update CMS_Initiator set newid1='" + modurl + "' where Iid='" + newsid + "'", Connection);
                                cmd23.ExecuteNonQuery();
                                Connection.Close();

                                // Response.Write("Successfully Submitted. ChangeId is:"+a+". ");
                                strScript = "alert(Successfully Submitted.');";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    err.insert_exception(ex, excep_page);
                    Response.Redirect("CMMErrorpage.aspx");
                }
            }


            else
            {
                try
                {
                    imgName = "";
                    imgPath = "";


                    Connection.Open();

                    initpop.initchangeid = a;
                    initpop.initinitdate = postdate;
                    initpop.initinitby = lbluname.Text;
                    initpop.inittypechange = ddl1.SelectedItem.Text;
                    initpop.initchangeperiod = ddl2.SelectedItem.Text;
                    initpop.initcclassification = DropDownList3.SelectedItem.Text;
                    initpop.initUnit = DropDownList4.SelectedItem.Text;

                    initpop.initDept = DropDownList5.SelectedItem.Text;
                    initpop.initcsource = TextBox20.Text;
                    initpop.initccategory = DropDownList9.SelectedItem.Text;
                    initpop.initRefid = txt4.Text;
                    initpop.initCustomer = ddl3.SelectedItem.Text;
                    initpop.initMarket = ddl4.SelectedItem.Text;

                    initpop.initLicense = txt111.Text;
                    initpop.initCDesc = txtdate.Text;
                    initpop.initexisting = TextBox15.Text;
                    initpop.initproposal = TextBox16.Text;
                    initpop.initrelchngs = TextBox13.SelectedItem.Text;
                    initpop.initreschnge = TextBox3.Text;

                    initpop.initsubmit = DropDownList1.SelectedItem.Text;
                    initpop.initAttachments = imgPath;
                    initpop.initpimpact = DropDownList2.SelectedItem.Text;
                    initpop.initsimpact = DropDownList6.SelectedItem.Text;
                    initpop.initrimpact = DropDownList13.SelectedItem.Text;
                    initpop.initproductname = DropDownList10.SelectedItem.Text;

                    initpop.initdosfrom = DropDownList11.SelectedItem.Text;
                    initpop.initsafetyass = imgpath1;
                    initpop.initregimpdesc = TextBox4.Text;
                    initpop.initstatus = status;
                    initpop.initcstatus = cstatus;
                    initpop.initsearchcc = searchop;
                    initpop.initupdatedate = postdate;


                    t = initbind.Insertinitiator(initpop.initchangeid, initpop.initinitdate, initpop.initinitby, initpop.inittypechange,
                        initpop.initchangeperiod, initpop.initcclassification, initpop.initUnit, initpop.initDept, initpop.initcsource,
                        initpop.initccategory, initpop.initRefid, initpop.initCustomer, initpop.initMarket, initpop.initLicense,
                        initpop.initCDesc, initpop.initexisting, initpop.initproposal, initpop.initrelchngs, initpop.initreschnge,
                        initpop.initsubmit, initpop.initAttachments, initpop.initpimpact, initpop.initsimpact, initpop.initrimpact, initpop.initproductname,
                        initpop.initdosfrom, initpop.initsafetyass, initpop.initregimpdesc, initpop.initstatus, initpop.initcstatus, initpop.initsearchcc,
                        initpop.initupdatedate,cftstatus);
                    if (t == true)
                    {
                        Session["initdate"] = postdate;

                        SqlDataAdapter da1 = new SqlDataAdapter("select * from CMS_Initiator where initdate='" + Session["initdate"].ToString() + "'", Connection);
                        da1.Fill(ds);
                        int newsid = Convert.ToInt16(ds.Tables[0].Rows[0]["Iid"]);
                        string ids = "000";
                        string newid = "CR" + year + ids;
                        string modurl = newid + newsid;
                        Session["changeidaction"] = modurl;

                        SqlCommand cmd23 = new SqlCommand("update CMS_Initiator set Changeid='" + modurl + "' where Iid='" + newsid + "'", Connection);
                        cmd23.ExecuteNonQuery();
                        Connection.Close();
                    }

                }

                catch (Exception ex)
                {
                    err.insert_exception(ex, excep_page);
                    Response.Redirect("CMMErrorpage.aspx");
                }
            }
            audithistory();
            SqlDataAdapter dal = new SqlDataAdapter("select * from CMS_Initiator where initdate='" + Session["initdate"].ToString() + "'", Connection);
            DataSet dsl = new DataSet();
            dal.Fill(dsl);
            // Label1.Text = dsl.Tables[0].Rows[0]["Changeid"].ToString();
             changeid1 = dsl.Tables[0].Rows[0]["Changeid"].ToString();
            //Connection.Open();
            string ab = "insert into CMS_Status1 (status,Changeid)values(1,'" + changeid1 + "')";

            SqlCommand cmdst = new SqlCommand(ab, Connection);
            cmdst.ExecuteNonQuery();
            Connection.Close();

          Session["pdescdate"]=postdate;
        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
            
        }
    }

    protected void btnaddrow_Click(object sender, EventArgs e)
    {
        //int rowCount = 0;
      
        //rowCount = Convert.ToInt32(Session["clicks"]);
        //rowCount++;
        ////In each button clic save the numbers into the session.
        //Session["clicks"] = rowCount;
        ////Create the textboxes and labels each time the button is clicked.
        //for (int i = 0; i < rowCount; i++)
        //{
        //    TextBox TxtBoxU = new TextBox();
        //    TextBox TxtBoxE = new TextBox();
        //    TextBox TxtBoxR = new TextBox();
        //    TxtBoxU.ID = "TextBoxU " + i.ToString();
        //    TxtBoxE.ID = "TextBoxE " + i.ToString();
        //   // TxtBoxR.ID = "TextBoxR " + i.ToString();
        //    TxtBoxU.CssClass = "pad";
        //    TxtBoxE.CssClass = "padreason";
        //   // TxtBoxR.CssClass = "pad";
        //    txtn.Controls.Add(TxtBoxU);
        //    txtp.Controls.Add(TxtBoxE);
        //   // txtr.Controls.Add(TxtBoxR);
        //    trbody.Visible = true;
        //}


        dt = (DataTable)ViewState["cur"];
        DataRow dr = dt.NewRow();
        dr["existing"] = TextBox15.Text;
        dr["proposal"] = TextBox16.Text;
       
        dt.Rows.Add(dr);
        gd.DataSource = dt;
        gd.DataBind();
        ViewState["cur"] = dt;
        gd.Visible = true;


        TextBox15.Text = "";
        TextBox16.Text = "";
       
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
    protected void gd1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowid = e.RowIndex;
        dt1 = (DataTable)ViewState["cur1"];
        dt1.Rows[rowid].Delete();
        string strScript = "alert('Successfully Deleted.');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
        gd1.DataSource = dt1;
        gd1.DataBind();

    }
    protected void btnaddrowreason_Click(object sender, EventArgs e)
    {
        //int rowCount = 0;

        //rowCount = Convert.ToInt32(Session["clicks1"]);
        //rowCount++;
        ////In each button clic save the numbers into the session.
        //Session["clicks1"] = rowCount;
        ////Create the textboxes and labels each time the button is clicked.
        //for (int i = 0; i < rowCount; i++)
        //{
        //    TextBox TxtBoxR = new TextBox();
         
        //    TxtBoxR.CssClass = "padreason";
         
        //    txtr.Controls.Add(TxtBoxR);
        //    trbody.Visible = true;
        //}

        dt1 = (DataTable)ViewState["cur1"];
        DataRow dr1 = dt1.NewRow();
        dr1["reschnge"] = TextBox3.Text;
     
        dt1.Rows.Add(dr1);
        gd1.DataSource = dt1;
        gd1.DataBind();
        ViewState["cur1"] = dt1;
        gd1.Visible = true;

        TextBox3.Text = "";
       
    }
    private void audithistory()
    {
        string abc = Convert.ToString(Session["changeidaction"]).ToString();
        string role = Convert.ToString(Session["userrolename"]); ;
        int rcode = 1;
       // string name = Convert.ToString(Session["uname"]);
        Connection.Open();

        SqlDataAdapter da = new SqlDataAdapter("select * from CMS_Initiator where changeid='" + abc + "'", Connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
       // if(ds.Tables[0].Rows.co
        int status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);
        int cstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Curstatus"]);
        if (status == 1 && cstatus == 1)
        {
            assigned = DropDownList1.SelectedItem.Text;
        }
        else if (status == 2 && cstatus == 1)
        {
            assigned = "Initiator";
        }
        else if (status == 0 && cstatus == 1)
        {
            assigned = "Initiator";
        }

        auditpop.auditChangeid = abc;
        auditpop.auditrole = role;
        auditpop.audituserid = lbluname.Text;
        auditpop.auditactivity = "Initiator initiate new Change request";
        auditpop.audittimestamp = DateTime.Now.ToString();
        auditpop.auditrolecode = rcode;
        auditpop.auditassignedto = "Reviewer";
        auditpop.Submitreviewer = DropDownList1.SelectedItem.Text;

        t = auditinsert.Insertaudithistory(auditpop.auditChangeid, auditpop.auditrole, auditpop.audituserid, auditpop.auditactivity,
            auditpop.audittimestamp, auditpop.auditrolecode, auditpop.auditassignedto, auditpop.Submitreviewer);

        if (t == true)
        {
            txt111.Text = "";
            txt4.Text = "";
            TextBox20.Text = "";

            TextBox15.Text = "";
            TextBox16.Text = "";
            txtdate.Text = "";
            ddl1.SelectedIndex = 0;
            ddl2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
            DropDownList4.SelectedIndex = 0;
            DropDownList5.SelectedIndex = 0;
            DropDownList9.SelectedIndex = 0;
            ddl3.SelectedIndex = 0;
            ddl4.SelectedIndex = 0;
            DropDownList1.SelectedIndex = 0;
            TextBox13.SelectedIndex = 0;


            TextBox3.Text = "";
        }
     
    }
    protected void actionbinding()
    {
        

    }
    protected void assignbind()
    {
    }
    protected void linkassign_Click(object sender, EventArgs e)
    {

        category = "assignment";
        lblassign.CssClass = "active";
        lblitems.CssClass = "lnkcolor";
        lnknew.CssClass = "lnkcolor";
        trbody.Visible = false;
        trst.Visible = false;
       
        trbtn.Visible = false;
        assignbind();
       
    }
    protected void lnkact_Click(object sender, EventArgs e)
    {
        category = "act";
        lblitems.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        lnknew.CssClass = "lnkcolor";
        trbody.Visible = false;
        trst.Visible = false;  
        
        trbtn.Visible = false;
        actionbinding();
    }
  
 
    protected void lnknew_Click(object sender, EventArgs e)
    {
        chaneig.Visible = false;
        trbody.Visible = true;
        trst.Visible = true;
        
        lnknew.CssClass = "active";
        lblassign.CssClass = "lnkcolor";
        lblitems.CssClass = "lnkcolor";
        trbtn.Visible = true;
      
        txt111.Text = "";
        txt4.Text = "";
        TextBox20.Text = "";

        TextBox15.Text = "";
        TextBox16.Text = "";
        txtdate.Text = "";
        ddl1.SelectedIndex = -1;
        //ddl1.Items.Insert(0, "Select Changes");
        ddl2.SelectedIndex = 0;
        DropDownList3.SelectedIndex =0;
        DropDownList4.SelectedIndex =0;
        DropDownList5.SelectedIndex =0;
        DropDownList9.SelectedIndex =0;
        ddl3.SelectedIndex =0;
        ddl4.SelectedIndex = 0;
        DropDownList1.SelectedIndex =0;
        TextBox13.SelectedIndex = 0;
        TextBox3.Text = "";

       

      
    }
    protected void lnllogout(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx",false);
        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }
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

        int s = Convert.ToInt32(ds1.Tables[0].Rows[0]["Curstatus"]);
        int st = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"]);
        int cftst = Convert.ToInt32(ds1.Tables[0].Rows[0]["cftstatus"]);
        if (ds1.Tables[0].Rows.Count > 0)
        {


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
      protected void clickid(object sender, EventArgs e)
      {
          
              LinkButton ln = sender as LinkButton;
              string cid1 = ln.CommandArgument.ToString();
             string name1 = Convert.ToString(Session["uname"]);

              SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CMS_Initiator where initby='" + name1 + "' and changeid='" + cid1 + "'", Connection);
              DataSet ds = new DataSet();
              da.Fill(ds);


              if (ds.Tables[0].Rows.Count > 0)
              {


                  trbtn.Visible = true;
                  trbody.Visible = true;
                

                  ddl1.SelectedValue = ds.Tables[0].Rows[0]["typechange"].ToString();
                  ddl2.SelectedItem.Text = ds.Tables[0].Rows[0]["changeperiod"].ToString();
                  DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["cclassification"].ToString();
                  DropDownList4.SelectedItem.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
                  DropDownList5.SelectedItem.Text = ds.Tables[0].Rows[0]["Dept"].ToString();
                  TextBox20.Text = ds.Tables[0].Rows[0]["csource"].ToString();
                  DropDownList9.SelectedItem.Text = ds.Tables[0].Rows[0]["ccategory"].ToString();
                  txt4.Text = ds.Tables[0].Rows[0]["Refid"].ToString();
                  ddl3.SelectedItem.Text = ds.Tables[0].Rows[0]["Customer"].ToString();
                  ddl4.SelectedItem.Text = ds.Tables[0].Rows[0]["Market"].ToString();
                  txt111.Text = ds.Tables[0].Rows[0]["License"].ToString();
                  txtdate.Text = ds.Tables[0].Rows[0]["CDesc"].ToString();
                  DropDownList2.SelectedItem.Text = ds.Tables[0].Rows[0]["pimpact"].ToString();
                  DropDownList10.SelectedItem.Text = ds.Tables[0].Rows[0]["productname"].ToString();
                  DropDownList11.SelectedItem.Text = ds.Tables[0].Rows[0]["dosfrom"].ToString();
                  DropDownList6.SelectedItem.Text = ds.Tables[0].Rows[0]["simpact"].ToString();
                  DropDownList13.SelectedItem.Text = ds.Tables[0].Rows[0]["rimpact"].ToString();
                  TextBox4.Text = ds.Tables[0].Rows[0]["regimpdesc"].ToString();

                  TextBox13.Text = ds.Tables[0].Rows[0]["relchngs"].ToString();
                  TextBox3.Text = ds.Tables[0].Rows[0]["reschnge"].ToString();
                  DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["submit"].ToString();
                  // Label1.Text = ds.Tables[0].Rows[0]["Changeid"].ToString();
                  //lbl2.Text = ds.Tables[0].Rows[0]["initdate"].ToString();
                  //lbl1.Text = ds.Tables[0].Rows[0]["initby"].ToString();
                  TextBox15.Text = ds.Tables[0].Rows[0]["existing"].ToString();
                  TextBox16.Text = ds.Tables[0].Rows[0]["proposal"].ToString();

                  //  Label1.Text = temp;
              }
              else
              {
                 //trwaiting.Visible = true;
                 //lblwait.Text = "Waiting For Approving This '" + cid1 + "' Request";
                  trbtn.Visible = true;
                  trbody.Visible = true;
                
                  string strScript = "alert('No Records Found for This '" + cid1 + "'');";
                  Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
              }
              
         

    }

      protected void button_Click(object sender, EventArgs e)
      {
          method();
          string date=Convert.ToString(Session["pdescdate"]);
          SqlDataAdapter da = new SqlDataAdapter("select * from cms_initiator where initdate='" + date + "'", Connection);
            DataSet ds = new DataSet();
          da.Fill(ds);
          if (ds.Tables[0].Rows.Count > 0)
          {
             string Cid = Convert.ToString(ds.Tables[0].Rows[0]["changeid"]);
             SqlCommand cmd = new SqlCommand("update cms_initiator set status=123 where initdate='" + date + "'", Connection);
             Connection.Open();
             cmd.ExecuteScalar();
             Connection.Close();
              Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Successfully Saved: Change Id is:" + Cid + " .')</script>");
          }
          Session.Remove("pdescdate");// Label1.Text = a;
          //string strScript = "alert('Saved Successfully');";
         // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
      }
      protected void saveclose_Click(object sender, EventArgs e)
      {
          method();
          string date = Convert.ToString(Session["pdescdate"]);
          SqlDataAdapter da = new SqlDataAdapter("select * from cms_initiator where initdate='" + date + "'", Connection);
          DataSet ds = new DataSet();
          da.Fill(ds);
          if (ds.Tables[0].Rows.Count > 0)
          {
              string Cid = Convert.ToString(ds.Tables[0].Rows[0]["changeid"]);
              SqlCommand cmd = new SqlCommand("update cms_initiator set status=123 where initdate='" + date + "'", Connection);
              Connection.Open();
              cmd.ExecuteScalar();
              Connection.Close();
              Page.ClientScript.RegisterStartupScript(typeof(Page), "Message", "<script type='text/javascript'>alert('Saved & Closed Successfully: Change Id is:" + Cid + " .')</script>");
          }
          Session.Remove("pdescdate");
          //string strScript = "alert('Saved & Closed Successfully');";
          //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
      }
      protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
      {
          trbody.Visible = true;
          DataSet ds1 = new DataSet();
          SqlDataAdapter das=new SqlDataAdapter("select * from CMM_Departments where DeptDesc='"+DropDownList5.SelectedItem.Text+"'",Connection);
          das.Fill(ds1);
          int deptno =Convert.ToInt32(ds1.Tables[0].Rows[0]["DeptId"]);
          SqlDataAdapter da = new SqlDataAdapter("select * from CMM_Loginusers where Department="+deptno+" and RoleCode=3", Connection);
          DataSet ds = new DataSet();
          da.Fill(ds);
          DropDownList1.DataSource = ds;
          DropDownList1.DataValueField = "UserId";
          DropDownList1.DataTextField = "UserId";
          DropDownList1.DataBind();
          DropDownList1.Items.Insert(0, "Select One");
          
      }
   
    
}
