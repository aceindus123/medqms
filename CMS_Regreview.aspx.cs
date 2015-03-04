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

public partial class Final_QA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    public class Item
    {
        public string txtcom { get; set; }
        public string txtfrv { get; set; }
        public string txtcfr { get; set; }
        public string txtcdate { get; set; }
        public string txtrev { get; set; }
        public string txtdate { get; set; }


        public string txtat1 { get; set; }
        public string txtdesc { get; set; }
        public string txtexe1 { get; set; }
        public string txtrev1 { get; set; }
        public string txttime { get; set; }
       
        
    }
   
    protected void add_Click(object sender, EventArgs e)

    {
        gd.DataSource = new List<Item>
        {
            new Item {txtcom = "comments",txtfrv="Yes", txtcfr = "FReviewer1",txtcdate="2/10/2014",txtrev="Reviewer",txtdate="2/10/2014"},
            new Item {txtcom = "comments",txtfrv="No", txtcfr = "FReviewer2",txtcdate="2/15/2014",txtrev="Reviewer",txtdate="2/10/2014"},
            new Item {txtcom = "comments",txtfrv="Yes", txtcfr = "FReviewer1",txtcdate="5/10/2014",txtrev="Reviewer",txtdate="5/10/2014"},
            new Item {txtcom = "comments",txtfrv="No", txtcfr = "FReviewer3",txtcdate="8/10/2014",txtrev="Reviewer",txtdate="6/10/2014"},
            new Item {txtcom = "comments",txtfrv="Yes", txtcfr = "FReviewer1",txtcdate="2/19/2014",txtrev="Reviewer",txtdate="7/10/2014"},
           
            
        };
        gd.DataBind();
        gd.Visible = true;
        
    }
    protected void gd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void bindgrid()
    {
        DataSet ds = new DataSet();
        gd.DataSource = ds;
        gd.DataBind();
        gd.Visible = true;
    }
    protected void lnkdeleterecord(object sender, EventArgs e)
    {
       
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deleted Successfully')", true);
     
    }
    protected void save_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Saved Successfully')", true);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Submitted Successfully')", true);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Saved')", true);
    }
   
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedItem.Text == "Yes")
        {

            pnl1.Visible = true;
        }
        else
        {
            pnl1.Visible = false;
            gd.Visible = false;
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
            GridView1.Visible = false;
        }
    }
    protected void add1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = new List<Item>
        {
             new Item {txtat1 = "Yes",txtdesc="Description", txtexe1 = "Executor",txtrev1="Reviewer",txttime="7/10/2014"},
           new Item {txtat1 = "No",txtdesc="Description", txtexe1 = "Executor1",txtrev1="Reviewer",txttime="5/10/2014"},
           new Item {txtat1 = "Yes",txtdesc="Description", txtexe1 = "Executor2",txtrev1="Reviewer1",txttime="2/18/2014"},
           new Item {txtat1 = "No",txtdesc="Description", txtexe1 = "Executor",txtrev1="Reviewer2",txttime="1/10/2014"},
           new Item {txtat1 = "Yes",txtdesc="Description", txtexe1 = "Executor3",txtrev1="Reviewer3",txttime="9/15/2014"},
           
            
        };
        GridView1.DataBind();
        GridView1.Visible = true;
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Canceled')", true);
    }
}
