<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CMMHome.aspx.cs" Inherits="Admin_CMMHome" %>
<%@ Register Src="~/Admin/UserControl/Admintopmenu.ascx" TagName="header1" TagPrefix="top1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<head runat="server">
    <title>:: CMM ADMIN HOME ::</title>
     <link href="css/style.css" rel="stylesheet" />
 <link href="css/style1.css" rel="stylesheet" />
<link href="css/menustyle.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
       <div id="wrapperclass" >
        <top1:header1 ID="head1" runat="server" />
          <br /><br /><br />
         <table border="0" width="100%"  align="center">
                    <tr>
                        <td align="center" ><asp:ImageButton ID="imgrc" ImageUrl="~/Admin/images/clients.png"  runat="server" PostBackUrl="~/Admin/CMMClients.aspx"/></td>
                        <td >&nbsp;</td>
                        <td align="center" ><asp:ImageButton ID="imgsupport" ImageUrl="~/Admin/images/reports.png" runat="server" PostBackUrl="~/Admin/CMMReports.aspx" /></td>
                        <td >&nbsp;</td>
                        <td align="center" ><asp:ImageButton ID="imgbtnpostjobs" ImageUrl="~/Admin/images/log-data(1).png" runat="server" PostBackUrl="~/Admin/CMMLogdata.aspx"  /></td>
                        <td >&nbsp;</td>
                        <td align="center"><asp:ImageButton ID="imgjobseeker" ImageUrl="~/Admin/images/clients1.png" runat="server"  PostBackUrl="~/Admin/CMMUsers.aspx"  /></td>
                    </tr>

                    <tr style=" text-decoration:none">
                        <td align="center" class="datalp">
                          <%--  <a href="#"><font  class="datalp" >Clients</font></a>--%>
                          <asp:LinkButton ID="lnkclients"  runat="server" Text="Clients" PostBackUrl="~/Admin/CMMClients.aspx"></asp:LinkButton>
                        </td>
                        <td>&nbsp;</td>
                        <td align="center" class="datalp">
                           <%-- <a href="#"><font  class="datalp">Reports</font></a>--%>
                           <asp:LinkButton ID="lnkreports"  runat="server" Text="Reports" PostBackUrl="~/Admin/CMMReports.aspx"></asp:LinkButton>
                        </td>
                         <td>&nbsp;</td>
                        <td align="center" class="datalp">
                           <%-- <a href="#"><font  class="datalp">Log Data</font></a>--%>
                           <asp:LinkButton ID="lnklog"  runat="server" Text="Log Data" PostBackUrl="~/Admin/CMMLogdata.aspx"></asp:LinkButton>
                        </td>
                         <td>&nbsp;</td>
                        <td align="center" class="datalp">
                         <%--   <a href="#"><font  class="datalp">Users</font></a>--%>
                         <asp:LinkButton ID="lnkusers"  runat="server" Text="Users" PostBackUrl="~/Admin/CMMUsers.aspx"></asp:LinkButton>
                        </td>
                     </tr>

                     <tr><td colspan="5" height="100px">&nbsp;</td></tr>
                     <tr>
                        <td align="center"><asp:ImageButton ID="imgpermission" ImageUrl="~/Admin/images/support(1).png" runat="server"  PostBackUrl="~/Admin/CMMSupport.aspx"   /></td>    
                        <td>&nbsp;</td>
                        <td align="center"><asp:ImageButton ID="imgads" ImageUrl="~/Admin/images/support2.png"  runat="server"  PostBackUrl="~/Admin/CMMContact.aspx" /></td>
                        <td>&nbsp;</td>
                        <td align="center"><asp:ImageButton ID="imgjobfairs" ImageUrl="~/Admin/images/feedback.png"  runat="server"  PostBackUrl="~/Admin/CMMFeedback.aspx" /></td>
                         <td>&nbsp;</td>
                        <td align="center"><asp:ImageButton ID="imgresume" ImageUrl="~/Admin/images/support.png"  runat="server" PostBackUrl="~/Admin/CMMPermissions.aspx" /></td>
                         
                    </tr>
                    <tr>
                        <td align="center" class="datalp">
                          <%--  <a href="#"><font  class="datalp">Support</font></a>--%>
                         <asp:LinkButton ID="lnksupport"  runat="server" Text="Support" PostBackUrl="~/Admin/CMMSupport.aspx"></asp:LinkButton>

                        </td>
                        <td>&nbsp;</td>
                        <td align="center" class="datalp">
                        <%--    <a href="#"><font  class="datalp">Contact</font></a>--%>
                         <asp:LinkButton ID="lnkcontact"  runat="server" Text="Contact"  PostBackUrl="~/Admin/CMMContact.aspx"></asp:LinkButton>

                        </td>
                        <td>&nbsp;</td>
                        <td align="center" class="datalp">
                      <%--      <a href="#"><font  class="datalp">FeedBack</font></a>--%>
                         <asp:LinkButton ID="lnkfeed"  runat="server" Text="FeedBack" PostBackUrl="~/Admin/CMMFeedback.aspx"></asp:LinkButton>

                        </td>
                          <td>&nbsp;</td>
                        <td align="center" class="datalp" >
                            <%--<a href="#"><font  class="datalp">Permissions</font></a>--%>
                         <asp:LinkButton ID="lnkpermissions"  runat="server" Text="Permissions" PostBackUrl="~/Admin/CMMPermissions.aspx" ></asp:LinkButton>

                        </td>
                    </tr>
                </table>
                <br /><br /><br />
        </div>
    </form>
</body>
</html>
