<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CMMLogdata.aspx.cs" Inherits="Admin_CMMLogdata" %>
<%@ Register Src="~/Admin/UserControl/Admintopmenu.ascx" TagName="header1" TagPrefix="top1" %>
<%@ Register Src="~/Admin/UserControl/menu.ascx" TagName="Menu1" TagPrefix="Menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>:: CMM Log Data Page ::</title>

    
<link href="css/style1.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet" />
<link href="css/menustyle.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="css/tables.css" />
<link rel="stylesheet" type="text/css" href="css/table.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div id="wrapperclass" >
           <top1:header1 ID="head1" runat="server" />
           <br /><br /><br />
           <Menu:Menu1 ID="Header1" runat="server" />
           <br /><br />
                <table width="100%" align="center" >
                <tr><td  width="100%" align="center" ><table width="60%">
                            <tr><td align="center" id="View" runat="server"  >
                                <font size="5" color="#00277a"><strong>Login Status</strong></font>
                              </td>
                            </tr>
                            <tr><td><asp:Label ID="lbltextsearch" runat="server" Text="" Font-Size="Small"></asp:Label></td></tr>
                   <tr><td align="center" width="100%">
                   <asp:Label ID="lblsearch" runat="server" Text="User Id" CssClass="tdalignleft"></asp:Label>
                   <strong><asp:Label runat="server" Text=":" CssClass="tdcolon" Width="20px"></asp:Label></strong>
                   <asp:DropDownList ID="ddlsearch" runat="server" CssClass="textborder" Width="180px">
                 
                   <asp:ListItem>Select UserId</asp:ListItem>
                   </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="reqsearch" runat="server" ControlToValidate="ddlsearch" InitialValue="Select UserId" ErrorMessage="*" ValidationGroup="validsearch">*</asp:RequiredFieldValidator>
                   <asp:Button ID="btnseach" runat="server" Text="Search" CssClass="buttonstyle" ValidationGroup="validsearch"
                           onclick="btnseach_Click"/>
                   </td></tr>   
                     <tr><td><br /></td></tr>
              <tr>
                 <td align="center"  style="line-height:25px" >
                  <asp:GridView ID="gridviewlogindetails" runat="server" AutoGenerateColumns="False" 
                         CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" 
                          OnPageIndexChanging="gridviewlogindetails_pageindexchanging" AllowPaging="true" PageSize="10" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                         <EditRowStyle BackColor="#7C6F57" />
                         <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle HorizontalAlign="Center" BackColor="#086A87" Font-Bold="True" 
                             ForeColor="White" />
                              <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                         <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center"/>
                     <Columns>

                      <asp:TemplateField HeaderText="SNo" >
                     <ItemTemplate >
                     <asp:Label ID="lbluname" runat="server" Text='<%#Eval("siteid") %>'></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="UserId" >
                     <ItemTemplate>
                     <asp:Label ID="lbluname" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>

                      <asp:TemplateField HeaderText="IP Address" >
                     <ItemTemplate>
                     <asp:Label ID="lbluname" runat="server" Text='<%#Eval("ipaddress") %>'></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="Login Date" >
                     <ItemTemplate>
                     <asp:Label ID="lbluname" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>

                     
                      

                     
                       <asp:TemplateField HeaderText="Country" >
                     <ItemTemplate>
                     <asp:Label ID="lblcountry" runat="server" Text='<%#Eval("country") %>'></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>

                     
                    <%--   <asp:TemplateField HeaderText="Region" >
                     <ItemTemplate>
                     <asp:Label ID="lblregion" runat="server" Text='<%#Eval("Region") %>'></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>--%>

                      <asp:TemplateField HeaderText="City" >
                     <ItemTemplate>
                     <asp:Label ID="lblcity" runat="server" Text='<%#Eval("city") %>'></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>
                     </Columns>
                  </asp:GridView>
                 </td>
              </tr>

              <tr runat="server" visible="false" id="norec"><td align="center"><asp:Label ID="lblnorecords" runat="server" Text="No Records found" ForeColor="Green" Font-Size="Medium"></asp:Label></td></tr>
              </table></td></tr>
          </table>

          <br /><br /><br /><br /><br />
          </div>
    </div>
    </form>
</body>
</html>
