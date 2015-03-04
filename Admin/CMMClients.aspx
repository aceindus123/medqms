<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CMMClients.aspx.cs" Inherits="Admin_CMMClients" %>
<%@ Register Src="~/Admin/UserControl/Admintopmenu.ascx" TagName="header1" TagPrefix="top1" %>
<%@ Register Src="~/Admin/UserControl/menu.ascx" TagName="Menu1" TagPrefix="Menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>:: CMM Clients Page ::</title>
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
           <br /><br />

           <table width="100%" >
              <tr>
                 <td align="center" id="View" runat="server">
                      <font size="5" color="#00277a"><strong>Clients List</strong></font>
                  </td>
              </tr>
           </table>
           <br />
           <table  align="center" width="100%"  >
             <tr>
               <td align="left" width="5%" style="padding-left:60px;">
               <asp:Button ID="btn1" runat="server" Text="View"  style="height:30px; width:50px;" alt="CMM" Font-Bold="true" BackColor="#A9BCF5"/>  <%--<img src="../Admin/images/view1.png" style="height:35px; width:50px;" alt="CMM" />--%>
              </td>
              <td align="left" width="5%">
            <asp:Button ID="Button1" runat="server" Text="Edit" style="height:30px; width:50px;" alt="CMM" Font-Bold="true"  BackColor="#A9BCF5"/>     <%--<img src="../Admin/images/edit1.png" style="height:35px; width:50px;" alt="CMM" />--%>
              </td>
              <td align="left" width="5%"> 
          <asp:Button ID="Button2" runat="server" Text="Email"  style="height:30px; width:50px;" alt="CMM" Font-Bold="true" BackColor="#A9BCF5"/>      <%-- <img src="../Admin/images/delete.png" style="height:35px; width:50px;" alt="CMM" />--%>
              </td>
              <td align="left" width="5%" >
          <asp:Button ID="Button3" runat="server" Text="Delete" style="height:30px; width:50px;" alt="CMM" Font-Bold="true" BackColor="#A9BCF5" />       <%--<img src="../Admin/images/mail1.png" style="height:35px; width:70px;" alt="CMM" />--%>
              </td>

              <td align="right" width="80%" style="padding-right:60px;">
             <asp:Button ID="Button4" runat="server" Text="New Client" style="height:30px; width:80px;" alt="CMM" Font-Bold="true" BackColor="#A9BCF5" />    <%--<img src="../Admin/images/delete1.png" style="height:35px; width:70px;" alt="CMM" />--%>
              </td>
             </tr>
           </table>

            
           <table align="center" width="100%">
              <tr>
                 <td align="center" width="100%" style="line-height:25px" >
                   <asp:GridView ID="gv1" runat="server" Width="90%" CellPadding="4" 
                         ForeColor="#333333" GridLines="None" OnRowDataBound="OnRowDataBound" >
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
                        
                        <Columns>
                          <asp:TemplateField>
                                            <HeaderTemplate>
                                              &nbsp;  <input id="chkAll"  runat="server"  type="checkbox" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                               &nbsp;  <asp:CheckBox ID="chkSelect" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="CompenyId">
                                            <ItemTemplate>
                                               &nbsp;  <asp:LinkButton ID="lnknmae" runat="server"  />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                        </Columns>
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
