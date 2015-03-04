using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using cmm.errorexcep;

public partial class CMM_ChangePwd : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    static string excep_page = "CMM ChangePwd.aspx";
    error err = new error();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
            string strScript = "alert('Session Closed.Please ReLogin into medqms');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
            Response.Redirect("default.aspx");
        }
        string name = Convert.ToString(Session["uname"]);
        lbluname.Text = name;
        lblusername.Text = name;
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;
    }
    protected void lnllogout(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void lnkhome_Click(object sender, EventArgs e)
    {
       // Response.Redirect("home.aspx");
        Response.RedirectToRoute("cmmhome");
    }
    protected void chpwd_Click(object sender, EventArgs e)
    {
        string name= lblusername.Text ;
        string oldpwd = txtoldpwd.Text;
        string newpwd = txtnewpwd.Text;
        string cfpwd = txtcfpwd.Text;
        string mailid = txtemailid.Text;
        SqlCommand cmd = new SqlCommand("update CMM_Loginusers set LPassword='" + newpwd + "' where UserId='"+lbluname.Text+"' ", con);
        con.Open();
        cmd.ExecuteNonQuery();
        SendMailVeh_Rentals(name);
        con.Close();
        txtemailid.Text = "";

    }
    private void SendMailVeh_Rentals(string name)
    {
        string loginname = Convert.ToString(Session["userloginname"]);
        string UMail = ConfigurationManager.AppSettings["mailid"].ToString();
        string UName = name;
        try
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("infocmsproject@gmail.com");
            MailMessage MsgMail = new MailMessage();
            mm.To.Add(UMail);
            //mm.Bcc.Add("test_indus@yahoo.com");
            MsgMail.Subject = "Confidential Description : Password has been Changed";
            string bdy = "";
            bdy += "<a href='http://medqms.com/new'><img src='http://medqms.com/medqms/new/images/logocmm.jpg' width='250' height='76' border='0'></a><br />";
            bdy += "<b>Dear </b>'"+loginname+"',<br>";
            bdy += "<br> <b>Your Password has been Changed.</b><br>";
            bdy += "<br> <b>Your New Password Details.<b><br>";
            bdy += "<br> User Id : '" + lblusername.Text + "'<br>";
            bdy += "<br> Old Password : '" + txtoldpwd.Text + "'<br>";
            bdy += "<br> New Password : '" + txtnewpwd.Text + "'<br>";
            bdy += "<br> Confirm Password : '" + txtcfpwd.Text + "'<br>";
            MsgMail.From = new MailAddress("infocmsproject@gmail.com");
            MsgMail.To.Add(txtemailid.Text);
            MsgMail.IsBodyHtml = true;
            MsgMail.Body = bdy;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(MsgMail);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Your new Password has been sent to your mail id')", true);

        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }
    }
    protected void cancel_Click(object sender, EventArgs e)
    {
        txtemailid.Text = "";

    }
}