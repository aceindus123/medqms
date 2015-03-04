using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CMMReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        gv1.DataSource = new List<Item>
        {
            new Item {Username = "Siva",  Compeny = "Cipla",Email="ramu@gmail.com",Mobile="9492318816", Reportstatus="Pending at Reviewer"},
             new Item {Username = "Raju",  Compeny = "Mylan",Email="mani@yahoo.com",Mobile="1245873188",Reportstatus="Pending at CFT"},
              new Item {Username = "Kumar",  Compeny = "Reddys",Email="karhi@outlook.com",Mobile="1245788816",Reportstatus="Pending at Approver?"}
        };
        gv1.DataBind();
    }
    public class Item
    {
        public string Username { get; set; }
        public string Compeny { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Reportstatus { get; set; }

    }
}