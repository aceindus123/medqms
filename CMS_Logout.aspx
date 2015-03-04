<%@ Page Title="" Language="C#" MasterPageFile="~/CMMmain.master" AutoEventWireup="true" CodeFile="CMS_Logout.aspx.cs" Inherits="CMS_Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<div style="width:1180px">

<div>
<table width="1180px">
<tr><td align="left">Logout</td></tr>
<tr>
<td align="left"><asp:Label ID="lblname" runat="server" Text="UserName"></asp:Label>&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" Text="xxxxxx"></asp:Label>
</td>
<td align="right">
<asp:Label ID="lbldateid" runat="server" Text="Date"></asp:Label>&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server" Text="DD/MM/YYYY"></asp:Label>
</td>
</tr>
<tr><td colspan="2" align="right">
<asp:Label ID="lbltimeid" runat="server" Text="Time"></asp:Label>&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" Text="HH:MM:00"></asp:Label>
</td></tr>
</table></div>
</div>

</asp:Content>

