using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CMMClients : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        gv1.DataSource = new List<Item>
        {
            new Item {  CompenyName = "Cipla",Authority="Ceo",Email="ceo@cipla.com",Mobile="9492318816",Url="www.lsgroups.com",Status="Active"},
             new Item { CompenyName = "Mylan",Authority="Director",Email="director1@mylan.com",Mobile="1245873188",Url="www.lsgroups.com",Status="DeActive"},
              new Item {  CompenyName = "Reddys",Authority="Hr",Email="reddyshr@reddys.com",Mobile="1245788816",Url="www.lsgroups.com",Status="Active"}
        };
        gv1.DataBind();

    }
    public class Item
    {
      
        public string CompenyName { get; set; }
        public string Authority { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkid = (LinkButton)e.Row.FindControl("lnknmae");

             for (int i = 0; i <= gv1.Rows.Count; i++)
             {
                 int Reg = 10001 + i;
                 string registration = "CMM" + Reg;
                lnkid.Text = registration;
            }
        }
    }
}