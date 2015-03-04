<%@ Page Title="" Language="C#" MasterPageFile="cmmheader.master" AutoEventWireup="true" CodeFile="cmmqualitynotifications.aspx.cs" Inherits="cmmqualitynotifications" %>

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
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="80%" style="vertical-align:top">

     <tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="LinkButton1" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<b><asp:Label ID="Label13" runat="server" Text="Date"  Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><b><asp:Label ID="Label15" runat="server" Text="UserName"  Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" ></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:70px">
<b><asp:Label ID="Label17" runat="server" Text="Time" Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>
</td>
</tr>
    </table>

     <div id="content">
    <table width="80%"  border="1px solid #7496c2"  align="center" style="vertical-align:top"> 
<tr><td align="left" class="content" >

<asp:Label ID="qaid" runat ="server" Text="Quality Notifications"></asp:Label>
</td>

</tr>
   <tr><td width="80%" align="center">
    
   
    <div style="background-image:url(images/underc2.jpg);background-repeat:no-repeat;text-align:center;width:600px;height:300px" >
    <br /><br /><br />
      <asp:Label ID="capa" runat="server" CssClass="homebodyheadings" Text="Quality Notifications"></asp:Label>
      <br />
        <asp:Label ID="Label1" runat="server" CssClass="homebodyis" Text="is" ></asp:Label>
      </div>
  
    </td>
    </tr>
    </table>
    </div>
</asp:Content>

