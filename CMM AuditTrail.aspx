<%@ Page Title="" Language="C#" MasterPageFile="cmmheader.master" AutoEventWireup="true" CodeFile="CMM AuditTrail.aspx.cs" Inherits="CMM_AuditTrail" %>

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
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="LinkButton5" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>
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
         <table id="table2" border="0" style="border:1px solid #7496c2" width="80%">
                  
                    
                    
                    <tr><td colspan="3" class="content" align="left" width="100%">Audit Trail</td></tr>
                    <tr><td><br /><br /></td></tr>
                <tr><td align="center" colspan="3"> 
<asp:GridView ID="GridView1" runat="server" ></asp:GridView>
<br />
<asp:Button ID="btn" runat="server" Text="Export" OnClick="Button1_Click" />
 <tr><td><br /><br /></td></tr>
</td></tr>  
</table>

</asp:Content>

