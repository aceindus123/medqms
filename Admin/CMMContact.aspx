<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CMMContact.aspx.cs" Inherits="Admin_CMMContact" %>
<%@ Register Src="~/Admin/UserControl/Admintopmenu.ascx" TagName="header1" TagPrefix="top1" %>
<%@ Register Src="~/Admin/UserControl/menu.ascx" TagName="Menu1" TagPrefix="Menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>:: CMM Contact Page ::</title>

    
<link href="css/style1.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet" />
<link href="css/menustyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div id="wrapperclass" >
           <top1:header1 ID="head1" runat="server" />
           <br /><br /><br />
           <Menu:Menu1 ID="Header1" runat="server" />

           <br />
                <br />
                <table width="100%" >
                            <tr><td align="center" id="View" runat="server">
                                <font size="5" color="#00277a"><strong>Contact List</strong></font>
                              </td>
                            </tr>
                            </table>
          </div>
    </div>
    </form>
</body>
</html>
