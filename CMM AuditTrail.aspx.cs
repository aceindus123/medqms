using System;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using cmm.errorexcep;
using System.Security;
using System.Security.Permissions;
using System.Reflection;
using System.Runtime.CompilerServices;


public partial class CMM_AuditTrail : System.Web.UI.Page
{
    private SqlConnection con;
    private SqlCommand com;
    private string constr, query;
    static string excep_page = "default.aspx";
    error err = new error();
    private void connection()
    {
        //SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        constr = ConfigurationManager.AppSettings["ConnectionString"];
        con = new SqlConnection(constr);
        con.Open();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
            string strScript = "alert('Session Closed.Please ReLogin into medqms');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertBox", strScript, true);
            Response.Redirect("default.aspx");
        }
        string name1 = Convert.ToString(Session["uname"]);
        lbluname.Text = name1;

        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lbldate.Text = date;
        string time = DateTime.Now.ToString("hh:mm:ss");
        lbltime.Text = time;
        if (!IsPostBack)
        {
            Bindgrid();

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "  
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
    }

    private void Bindgrid()
    {
        connection();
        query = "select* from AuditHistory where Userid='"+lbluname.Text+"'  order by cid, Timestamp desc";//not recommended this i have wrtten just for example,write stored procedure for security  
        com = new SqlCommand(query, con);
        SqlDataReader dr = com.ExecuteReader();
        GridView1.DataSource = dr;
        GridView1.DataBind();
        con.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportGridToPDF();
    }
    private void ExportGridToPDF()
    {

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        //GridView1.AllowPaging = true;
        //GridView1.DataBind();
    }
    protected void lnllogout(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx", false);
        }
        catch (Exception ex)
        {
            err.insert_exception(ex, excep_page);
            Response.Redirect("CMMErrorpage.aspx");
        }
    }
}