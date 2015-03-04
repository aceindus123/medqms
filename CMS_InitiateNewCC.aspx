<%@ Page Title="" Language="C#" MasterPageFile="~/CMMmain.master" AutoEventWireup="true" CodeFile="CMS_InitiateNewCC.aspx.cs" Inherits="CMS_InitiateNewCC" %>

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

<tr><td colspan="2">

<table align="left"><tr>
<td><a href="#">File</a></td>
<td><a href="#">View</a></td>
<td><a href="#">Help</a></td>
</tr>


</table>

</td></tr>
<tr><td colspan="2">

<table align="left" >
<tr><td align="left"><asp:Label ID="lblassign" runat="server" Text="My Assignments" ForeColor="Red"></asp:Label>/<asp:Label ID="lblitems" runat="server" Text="My Action Items"></asp:Label></td></tr>
<tr><td align="left"><asp:Label ID="lblinitiate" runat="server" Text="Initiate New CC"></asp:Label></td></tr>
</table>
</td></tr>

<tr><td align="center" colspan="2">
<table>
<tr><td align="center"><asp:Label ID="Label1" runat="server" Text="CHANGE MANAGEMENT"></asp:Label></td></tr>
<tr><td colspan="2">

<asp:GridView ID="gvinitiate" runat="server" AutoGenerateColumns="false">
<Columns>

<asp:TemplateField HeaderText="CC No.">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Change Description">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Change Period">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Change Classification">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Department">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Product Name">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Market">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Customer">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Assigned To">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Due Date">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Status">
<ItemTemplate>
</ItemTemplate>
</asp:TemplateField>


</Columns>
</asp:GridView>
									
													
										

</td></tr>

</table>
</td></tr>



</table>

</div>
</div>

</asp:Content>

