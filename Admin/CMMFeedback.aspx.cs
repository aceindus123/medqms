using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CMMFeedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        gv1.DataSource = new List<Item>
        {
            new Item {Name = "Siva",  Place = "Guntur",Email="ramu@gmail.com",Mobile="9492318816", Comment="Site Looks Good"},
             new Item {Name = "Raju",  Place = "Vijayawada",Email="mani@yahoo.com",Mobile="1245873188",Comment="Production work is Good"},
              new Item {Name = "Kumar",  Place = "Vizag",Email="karhi@outlook.com",Mobile="1245788816",Comment="Product Based Compeny ?"}
        };
        gv1.DataBind();
    }
    public class Item
    {
        public string Name { get; set; }
       
        public string Place { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Comment { get; set; }
       
    }
}