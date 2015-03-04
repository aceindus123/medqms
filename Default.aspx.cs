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
using System.Net;
using System.Collections.Generic;
using cmm.DataAccessLayer;
using cmm.errorexcep;
using System.Xml;


public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string tzi;
    static string excep_page = "default.aspx";
    error err = new error();
 protected void Page_Load(object sender, EventArgs e)
    {
        ddltimezone.Visible = true;
        System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        ////GMT Time for India
        DataTable dt = new DataTable();
        TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        string stime = INDIAN_ZONE.DisplayName;
        ddltimezone.Items.Add(new ListItem(stime.Substring(11) + " " + stime.Substring(0, 11)));
        if (!IsPostBack)
        { }
    }
    protected void insertipdetails()
    {
        string sys_ipaddress = GetIP();
        string date = DateTime.Now.ToShortDateString();
        string time = DateTime.Now.ToShortTimeString();
        SqlCommand cmdcount = new SqlCommand("insert into CMS_Sitecount(ipaddress,time,date,userid,country,city,Region) values(@ipaddress,@time,@date,@userid,@country,@city,@Region)", con);
        cmdcount.Parameters.AddWithValue("@date", date);
        cmdcount.Parameters.AddWithValue("@ipaddress", sys_ipaddress);
        cmdcount.Parameters.AddWithValue("@time", time);
        cmdcount.Parameters.AddWithValue("@userid", txtuname1.Text);
        cmdcount.Parameters.AddWithValue("@country", "");
        cmdcount.Parameters.AddWithValue("@city", "");
        cmdcount.Parameters.AddWithValue("@Region", "");
        con.Open();
        cmdcount.ExecuteNonQuery();
        con.Close();
    }
    private DataTable GetLocation(string strIPAddress)
    {
        WebRequest rssReq = WebRequest.Create("http://freegeoip.net/xml/" + strIPAddress);
        WebProxy px = new WebProxy("http://freegeoip.net/xml/" + strIPAddress, true);
        rssReq.Proxy = px;
        rssReq.Timeout = 2000;
        try
        {
            WebResponse rep = rssReq.GetResponse();
            XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());
            DataSet ds = new DataSet();
            ds.ReadXml(xtr);
            return ds.Tables[0];
        }
        catch
        {
            return null;
        }
    }
    protected string GetIP()
    {
        IPAddress[] addr = new IPAddress[0];
        try
        {
            string strHostName = "";


            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            addr = ipEntry.AddressList;
        }
        catch
        { }
        return addr[addr.Length - 2].ToString();
    }
    private string GetVisitor()
    {
        string strIPAddress = string.Empty;
        string strVisitorCountry = string.Empty;
        string strVisitorCity = string.Empty;
        string RegionName = string.Empty;
        string sys_ipaddress = GetIP();
        // strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        strIPAddress = sys_ipaddress;
        if (strIPAddress == "" || strIPAddress == null)
            strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
        // return strVisitorCountry;
        //return strVisitorCity;
        return RegionName;
    }
    protected void loginbtn_Click(object sender, EventArgs e)
    {
        try
        {
            string a1 = string.Empty; ;
            Session["uname"] = txtuname1.Text;
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CMM_LoginUsers where UserId='" + txtuname1.Text + "' and LPassword='" + txtpwd1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            string uname = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
            string pwd = Convert.ToString(ds.Tables[0].Rows[0]["LPassword"]);
            int a = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleCode"]);
            int b = Convert.ToInt32(ds.Tables[0].Rows[0]["Department"]);
            string c = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
            string email = Convert.ToString(ds.Tables[0].Rows[0]["emailid"]);
            Session["userroleid"] = a;
            Session["userdepartment"] = b;
            Session["userloginname"] = c;
            Session["loginmail"] = email;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (txtuname1.Text == uname && txtpwd1.Text == pwd)
                {
                  //  Response.Redirect("Home.aspx", false);
                    Response.RedirectToRoute("cmmhome");
                    // insertipdetails();
                    insertipdetails();
                }
                else
                {
                    //Check Your Username and password with small/capital letters
                    string strScript = "alert('Check Your Username and password.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
                }
            }
            else
            {
                //Enter Correct UserName and Password
                string strScript = "alert('Please Enter Correct UserName & Password.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
            }
        }
        catch (Exception ex)
        {
            string strScript = "alert('Please Enter Correct UserName & Password.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);

            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }
    }
    protected void forgetpwd(object sender, EventArgs e)
    {
        try
        {
          //  Response.Redirect("CMM forgetpwd.aspx", false);
            Response.RedirectToRoute("cmmforgetpwd");
        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }
    }
}
