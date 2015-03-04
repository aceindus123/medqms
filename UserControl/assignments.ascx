<%@ Control Language="C#" AutoEventWireup="true" CodeFile="assignments.ascx.cs" Inherits="UserControl_assignments" %>

     <asp:Panel ID="pnl3" runat="server" >
        <asp:GridView ID="gvar" runat="server"    Width="75%"  AutoGenerateColumns="false" BorderColor="#b2a1c7" BorderWidth="1px" 
        CssClass="subtr"  DataKeyNames="changeid"  
         >
<AlternatingRowStyle BackColor="#dcccf1" />
<HeaderStyle BackColor="#b2a1c7" />

<Columns>

<asp:TemplateField HeaderText="Change Request Id" HeaderStyle-HorizontalAlign="Left">

<ItemTemplate><asp:LinkButton ID="lblats" runat="server" Text='<%#Eval("Changeid")%>' ></asp:LinkButton></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Description" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblyes" runat="server" Text='<%# Eval("CDesc") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Classification" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblyes1" runat="server" Text='<%# Eval("cclassification") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Market " HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype1" runat="server" Text='<%# Eval("Market") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Product Impact " HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype3" runat="server" Text='<%#Eval("pimpact") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Regulator Impact " HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype2" runat="server" Text='<%#Eval("rimpact") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>

</asp:Panel>