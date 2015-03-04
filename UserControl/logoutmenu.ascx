<%@ Control Language="C#" AutoEventWireup="true" CodeFile="logoutmenu.ascx.cs" Inherits="UserControl_logoutmenu" %>
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
								
</style>
<link rel="stylesheet" type="text/css" href="../css/contentstyle.css" />
    <link rel="stylesheet" type="text/css" href="../css/table.css" />	
<table width="100%" style="vertical-align:top" align="center">
<tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="lnklogout" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="17px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<asp:Label ID="lbldateid" runat="server" Text="Date"  Font-Bold="true" CssClass="boldblack"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><asp:Label ID="lblname" runat="server" Text="UserName" CssClass="boldblack"  Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" CssClass="initlblsleftrt"></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:65px">
<asp:Label ID="lbltimeid" runat="server" Text="Time" Font-Bold="true" CssClass="boldblack"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>
</table>