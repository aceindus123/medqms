using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class CMM_forgetpwd : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if else statement for to check user id which you entered is existed or not
     // string   mailid = "sdamisetty_aceindus@yahoo.com";
        if (!txtmail.Text.Trim().ToLower().Equals(""))
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                //To open connection
                connection.Open();
                Int16 cnt;

                string mailid = txtmail.Text;
                //Checking wether the role name is already exist or not
                cmd.CommandText = "SELECT COUNT(*) FROM CMM_LoginUsers WHERE UserId ='" +txtuname.Text + "' ";
                cnt = Convert.ToInt16(cmd.ExecuteScalar());
                if (cnt == 1)
                {
                    SqlCommand cmduid = new SqlCommand("SELECT UserId,LPassword FROM CMM_LoginUsers WHERE UserId='" + txtuname.Text+"' ", connection);
                    SqlDataReader drUid;
                    drUid = cmduid.ExecuteReader();
                    //Send mail to the id which you entered in the text field with your password details
                    if (drUid.HasRows)
                    {
                        drUid.Read();
                       //string mailid = string.Empty;
                       // mailid = drUid["vEmail"].ToString();
                       
                       // mailid="sdamisetty_aceindus@yahoo.com";
                        MailMessage MsgMail = new MailMessage();
                        MsgMail.Subject = "Confidential Description :";
                        string bdy = "";
                        bdy += "<a href='http://acsglb.com/cmm'><img src='http://acsglb.com/cmm/images/logo3cmm.png' width='250' height='76' border='0'></a><br />";
                        bdy += "Dear Change Management Module Member,<br>";
                        bdy += "<br> We have received a request for your password for Email ID: '" + mailid + "'";
                        bdy += "<br> User Name : '"+txtuname.Text+"'" ;
                        bdy += "<br> Your password : " + drUid["LPassword"].ToString();
                        bdy += "<br> For security reasons we recommend the following:";
                        bdy += "<br><br> 1. Never give out your CMM password ";
                        bdy += "<br> 2. Make a password with special characters and numbers";
                        bdy += "<br> 3. Make your password easy for you to remember, but difficult for others to guess<br><br>";
                        bdy += "<br> <br>Thank you for using Change Management Module";
                        bdy += "<br> <br><br>Regards,";
                        bdy += "<br> Customer Care CMM";
                        bdy += "<br> <br><br>http://www.acsglb.com/cmm";
                        drUid.Close();

                        MsgMail.From = new MailAddress("infocmsproject@gmail.com");
                        MsgMail.To.Add(mailid);
                        MsgMail.IsBodyHtml = true;
                        MsgMail.Body = bdy;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Send(MsgMail);
                        lblMsg.Text = "Your Password has been sent to your mail id.";
                        
                      
                       
                    }
                  //  string strScript = "";
                  //  strScript = "alert('Your Password has been sent to your mail id');location.replace(default.aspx);";
                  //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
                    txtmail.Text = "";
                    txtuname.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Your Password has been sent to your mail id')", true);

                }
                else
                {
                    lblMsg.Text = "Invalid User Id";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Invalid User Id,Please Enter Correct User Id')", true);

                    txtmail.Text = "";
                    txtuname.Text = "";
                }
            }
            // To catch exception
            catch (SqlException oe)
            {
                lblMsg.Text = oe.Message;
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                //To close connection
                connection.Close();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Invalid User Id,Please Enter Correct User Id')", true);

            lblMsg.Text = "Invalid User Id";
            txtmail.Text = "";
            txtuname.Text = "";
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        // Response.Redirect("Default.aspx");
        Response.RedirectToRoute("logincms");
        
    }
}