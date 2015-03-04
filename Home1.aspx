<%@ Page Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true" CodeFile="Home1.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
      
    <style type="text/css">
        .lnk
        {
        	text-decoration:none;
        }
        .style1
        {
            width: 80%;
            margin-left:30px;
        }
        .style2
        {
            width: 400px;
            height: 200px;
        }
        .style4
        {
            width: 344px;
        }
        .style5
        {
            width: 344px;
            height: 200px;
        }
        .style6
        {
            height: 300px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-bottom:65px; padding-top:50px;border:1px solid; ">

     <asp:Panel ID="pnl3" runat="server">
        <asp:GridView ID="gvar" runat="server"    Width="75%"  
             AutoGenerateColumns="false" BorderColor="#b2a1c7" BorderWidth="1px"
        CssClass="subtr"  DataKeyNames="changeid" OnRowDataBound="GridView1_RowEditing" 
         >
<AlternatingRowStyle BackColor="#dcccf1" />
<HeaderStyle BackColor="#b2a1c7" />

<Columns>

<asp:TemplateField HeaderText="Change Request Id" HeaderStyle-HorizontalAlign="Left">

<ItemTemplate><asp:LinkButton ID="lblats" runat="server" Text='<%#Eval("Changeid")%>'   OnClick="pnlEd_Click"></asp:LinkButton></ItemTemplate>
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

<asp:TemplateField HeaderText ="Status" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblstatusreg" runat="server" ></asp:Label></ItemTemplate>
</asp:TemplateField>

</Columns>
</asp:GridView>

</asp:Panel>
    <table class="style1">
        <tr id="trid" runat="server" visible="false">
            <td align="center" class="style2">
                <asp:ImageButton ID="Imgb1" ImageUrl="Images1/initiate.png" runat="server"   OnClick="imgini_click"/></td>
            <td class="style4">
                </td>
               
            <td >
             <%--   <asp:Image ImageUrl="images/img2.jpg" ID="img1" runat="server" Width="276" Height="289" /> --%>
                </td>
        </tr>
        <tr id="tridbar" runat="server">
            <td align="center" class="style2">
                <asp:ImageButton ID="Imgb2" runat="server" ImageUrl="Images1/open.png"   onclick="LinkButton1_Click"/></td>
            <td class="style5">
                </td>
                <td style="background-image:url('images/img2.jpg');background-repeat:no-repeat" 
                width="300px" class="style6" align="center">

               
                
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                   
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" CssClass="lnk">Open Assignments</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="lnk" onclick="LinkButton1_Click">Closed Assignments</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="lnk" onclick="LinkButton1_Click">Over due Assignments</asp:LinkButton>
                    <br />
                    <br />
                    <br />
                
                </td>
        </tr>
          <tr id="tr1" runat="server" visible="false">
         <td valign="top"><table><tr>
            <td align="center" class="style2">
                <asp:Image ID="Image1" runat="server" ImageUrl="Images1/reports.png"  />&nbsp;</td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td align="center" class="style2">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images1/learn.png"  />&nbsp;</td>
            <td class="style4">
                </td>
        </tr></table></td>
            <td class="style5">
                </td>
                <td style="background-image:url('images/img2.jpg');background-repeat:no-repeat" 
                width="260px" class="style6" align="center">

               
                <br />
                   
                    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton1_Click" CssClass="lnk">Open Assignments</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton5" runat="server" CssClass="lnk" onclick="LinkButton1_Click">Closed Assignments</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton6" runat="server" CssClass="lnk" onclick="LinkButton1_Click">Over due Assignments</asp:LinkButton>
                    <br />
                    <br />
                    <br />
                
                </td>
        </tr>
        <tr id="tr2" runat="server">
            <td align="center" class="style2">
                <asp:Image ID="Imgb3" runat="server" ImageUrl="Images1/reports.png" />&nbsp;</td>
            <td class="style4">
                </td>
        </tr>
        <tr id="tr3" runat="server">
            <td align="center" class="style2">
                <asp:Image ID="Imgb4" runat="server" ImageUrl="Images1/learn.png"  />&nbsp;</td>
            <td class="style4">
                </td>
        </tr>
        
    </table>
</div>

</asp:Content>

