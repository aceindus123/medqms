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

public partial class mail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    private void SendMailVeh_Rentals()
    {
        string Msg = "";
        string UMail = ConfigurationManager.AppSettings["mailid"].ToString();
       // string UName = "Initiator";
        try
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("infocmsproject@gmail.com");
            mm.To.Add("kvslakshmi_aceindus@yahoo.com");
            mm.To.Add("sdamisetty_aceindus@yahoo.com");

            //mm.Bcc.Add(Advertiser_EmailId);
            Msg += "<a href='http://www.careersgen.com/Postresume'><img src='http://medqms.com/medqms/NEW/images/careers.png' width='250' height='76' border='0'></a><br />";
            mm.Subject = "careers";
            mm.IsBodyHtml = true;
            mm.Body = Msg;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(mm);
        }
        catch 
        {
           // string erromes = ex.Message;
            string strScript = "alert('please once check');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        SendMailVeh_Rentals();
    }
}