using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


      string av= GetIP();
    
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
}