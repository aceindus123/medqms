﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserControl_Admintopmenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbldate.Text = DateTime.Now.ToString();
        lbluser.Text = Convert.ToString(Session["username"]);
    }
}