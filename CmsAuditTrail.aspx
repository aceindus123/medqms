<%@ Page Title="" Language="C#" MasterPageFile="~/cmmheader.master" AutoEventWireup="true" CodeFile="CmsAuditTrail.aspx.cs" Inherits="CmsAuditTrail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
 <link rel="stylesheet" type="text/css" href="css/table.css" />
    <style type="text/css">
    
                                .lnkcolor
								{
									
									font-size:13px;
									font-weight:bold;
									font-family:Arial;
									color:#3C629A;
										text-decoration:none;
									}
									.lnkcolor:hover
									{
										
										color:#7496c2;
										}
										.active
										{
											color:#7496c2;
										text-decoration:underline;
											}
											.gridborder
												{
													border:1px solid #3C629A;
													}
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="80%">

<tr>
<td>
<table  style="vertical-align:top" width="100%">
        
                         <tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="LinkButton5" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" CausesValidation="false" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<b><asp:Label ID="Label2" runat="server" Text="Date"  Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><b><asp:Label ID="Label4" runat="server" Text="UserName"  Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server"></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:70px">
<b><asp:Label ID="Label6" runat="server" Text="Time" Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>
</td>
</tr>
        
        </table>
</td>
</tr>

<tr>
<td>
<table id="table2" border="0" style="border:1px solid #7496c2" width="100%"> 
                   <tr><td  class="content" align="center" width="100%">
                   <table width="100%" align="center" >
                   <tr>
                   <td align="left">
                      Audit Trail
                   </td>
                   <td align="right">
                   <asp:LinkButton ID="lnkHome" runat="server" Text="Back" 
                            onclick="lnkHome_Click" CausesValidation="false" ></asp:LinkButton>
                   </td>
                   </tr>
                   </table>
                   
                   
                   
                </td></tr>
                <tr><td><br /></td></tr>
                    <tr ><td align="center"><br />               
                 <b><asp:Label ID="Lbchangeid" runat="server" Text=" Select Change Request Id :"  Font-Bold="true"></asp:Label></b>   <asp:DropDownList ID="DdlchangeRid" runat ="server" ></asp:DropDownList>
                 <asp:RequiredFieldValidator ID="reqchid" runat="server" Text="*" ControlToValidate="DdlchangeRid" InitialValue="Select" ></asp:RequiredFieldValidator>
                 <asp:Button ID="btnAudit" Text="Show Audit Trail" runat="server" 
                            onclick="btnAudit_Click" />
                    <br /></td></tr>
                    
                    <tr>
                    <td align="left" style="padding-left:46px;">                    
                    <asp:Label ID="lbchid" runat="server" Text="" Visible="false" ></asp:Label>
                    <br />
                    </td>
                    </tr>
                <tr><td align="center" > 
<asp:GridView ID="grdAuditTrail" runat="server" Visible="False" CellPadding="4" ForeColor="#333333" 
                        GridLines="none"  BorderColor="#7496c2" Width="90%" CssClass="gridborder" >
    <AlternatingRowStyle BackColor="#e3e3e3"/>
    <EditRowStyle BackColor="#999999" />    
    <HeaderStyle BackColor="#8db2e3" CssClass="gridhead" Font-Size="13px" />
    <PagerStyle HorizontalAlign="Right"  CssClass="gridhead" Font-Bold="true" Font-Size="12px" BackColor="White" ForeColor="Black"  />
    <RowStyle  Height="30px" Font-Size="12px" HorizontalAlign="Center" Font-Names="Arial"  />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True"/>
   
      </asp:GridView>
<br />
 
</td></tr>  
<tr><td><br /><br /></td></tr>
</table>

</td>
</tr>
</table>

</asp:Content>

