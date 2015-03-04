<%@ Page Title="" Language="C#" MasterPageFile="cmmheader.master" AutoEventWireup="true" CodeFile="cmm userstatus.aspx.cs" Inherits="cmm_userstatus" %>

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
<table border="0" style="border:1px solid #7496c2" width="80%" >
   <tr><td colspan="3" class="content" align="left" width="100%">User Status</td></tr>

   <tr><td align="center" width="75%">
   <table width="100%" align="center">
   <tr><td style="color:#3C629A;font-weight:bold;font-size:medium" align="center">Roles in CMM</td></tr>
   <tr><td><br /></td></tr>
    <tr>
<td  class="tdinitleft" align="center"><asp:LinkButton ID="LinkButton5" runat="server" Text ="Initiator" CssClass="lnkcolor"   Font-Size="14px" ></asp:LinkButton></td>
</tr>
<tr><td><br /></td></tr>
<tr>
<td  class="tdinitleft" align="center"><asp:LinkButton ID="LinkButton1" runat="server" Text ="reviewer" CssClass="lnkcolor"   Font-Size="14px" ></asp:LinkButton></td>
</tr>
<tr><td><br /></td></tr>
<tr>
<td  class="tdinitleft" align="center"><asp:LinkButton ID="LinkButton2" runat="server" Text ="Co-Ordinator" CssClass="lnkcolor"   Font-Size="14px" ></asp:LinkButton></td>
</tr>
<tr><td><br /></td></tr>
<tr>
<td  class="tdinitleft" align="center"><asp:LinkButton ID="LinkButton3" runat="server" Text ="CFT" CssClass="lnkcolor"   Font-Size="14px" ></asp:LinkButton></td>
</tr>
<tr><td><br /></td></tr>
<tr>
<td  class="tdinitleft" align="center"><asp:LinkButton ID="LinkButton4" runat="server" Text ="RA/CG" CssClass="lnkcolor"   Font-Size="14px" ></asp:LinkButton></td>
</tr>
<tr><td><br /></td></tr>
<tr>
<td  class="tdinitleft" align="center"><asp:LinkButton ID="LinkButton6" runat="server" Text ="Approver" CssClass="lnkcolor"   Font-Size="14px" ></asp:LinkButton></td>
</tr>
<tr><td><br /></td></tr>
</table>
   </td></tr>

</table>

</asp:Content>

