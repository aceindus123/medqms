<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CMMReports.aspx.cs" Inherits="Admin_CMMReports" %>
<%@ Register Src="~/Admin/UserControl/Admintopmenu.ascx" TagName="header1" TagPrefix="top1" %>
<%@ Register Src="~/Admin/UserControl/menu.ascx" TagName="Menu1" TagPrefix="Menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>:: CMM Reports Page ::</title>

    
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
           <Menu:Menu1 ID="menu1" runat="server" />

           <br />
                <br />
                <table width="100%" >
                            <tr><td align="center" id="View" runat="server">
                                <font size="5" color="#00277a"><strong>Reports List</strong></font>
                              </td>
                            </tr>
                            </table>

                               <br />
           <table align="center" width="100%">
              <tr>
                 <td align="center" width="100%" style="line-height:25px" >
                   <asp:GridView ID="gv1" runat="server" Width="90%" CellPadding="4" 
                         ForeColor="#333333" GridLines="None" >
                         <AlternatingRowStyle BackColor="White" />
                         <EditRowStyle BackColor="#7C6F57" />
                         <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle HorizontalAlign="left" BackColor="#086A87" Font-Bold="True" 
                             ForeColor="White" />
                        
                         <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                         <RowStyle BackColor="#E3EAEB" />
                         <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                         <SortedAscendingCellStyle BackColor="#F8FAFA" />
                         <SortedAscendingHeaderStyle BackColor="#246B61" />
                         <SortedDescendingCellStyle BackColor="#D4DFE1" />
                         <SortedDescendingHeaderStyle BackColor="#15524A" />
                        
                   </asp:GridView>
                 </td>
              </tr>
          </table>

          <br /><br /><br /><br /><br />
          </div>
    </div>
    </form>
</body>
</html>
