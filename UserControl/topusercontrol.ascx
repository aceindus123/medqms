<%@ Control Language="C#" AutoEventWireup="true" CodeFile="topusercontrol.ascx.cs" Inherits="UserControl_topusercontrol" %>
<link href="css/contentstyle.css" rel="stylesheet" />
<table width="100%" runat="server" id="tbl" >
<tr>
<td  class="lefttd" align="right" width="107px">
     <b> <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label> </b> 
</td>
<td  style="font-weight:bold" width="3">
:
</td>
<td CssClass="textborder" >
    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" Height="22px"
                        CssClass="textborder"
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem>Select One</asp:ListItem>
    <asp:ListItem>Approval</asp:ListItem>
     <asp:ListItem>Assignment</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
<tr>
<td colspan=3>
<asp:Panel ID="pnl1" runat="server" Visible="false" Width="100%">
<table>
<tr>
<td class="lefttd" align="right">
    &nbsp;</td>
<td class="colontd">&nbsp;</td>
 <td style="text-align:left">
     &nbsp;</td>
                            <td  class="lefttd" align="right">
                                &nbsp;</td>
<td class="colontd">&nbsp;</td>
<td style="text-align:left">
    &nbsp;</td>
 <tr>
<td  class="lefttd" align="right">
 <b> Type of Changes </b> 
</td>
<td class="colontd">:</td>
 <td style="text-align:left">
<asp:DropDownList runat="server" ID="ddl1" Width="200px" Height="22px"
                        CssClass="textborder">
                            <asp:ListItem Value="0">Select Changes</asp:ListItem>
                            <asp:ListItem>Pre Approval Change</asp:ListItem>
                            <asp:ListItem>Post Approval Change</asp:ListItem>
                            </asp:DropDownList>                            </td>
                            <td  class="lefttd" align="right">
 <b> Change Classification </b> 
</td>
<td class="colontd">:</td>
<td style="text-align:left">
  <asp:DropDownList ID="DropDownList3" runat="server" Width="200px" Height="22px"
                        CssClass="textborder">
                                             <asp:ListItem Text = "Select Classification" Value = "0"></asp:ListItem> 
       <asp:ListItem Text = "Quality Impactinng" Value = "1"></asp:ListItem>                                      
    <asp:ListItem Text = "Quality non-Impacting" Value = "2"></asp:ListItem>
   
    </asp:DropDownList>                            </td></tr>
                   <tr>
                       <td align="right" class="lefttd">
                           <b>Market </b>
                       </td>
                       <td class="colontd">
                           :</td>
                       <td style="text-align:left">
                           <asp:DropDownList ID="ddl4" runat="server" CssClass="textborder" Height="22px" 
                               Width="200px">
                               <asp:ListItem Value="0">Select Market</asp:ListItem>
                               <asp:ListItem Value="3">US</asp:ListItem>
                               <asp:ListItem Value="1">EU</asp:ListItem>
                               <asp:ListItem Value="2">WHO</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td align="right" class="lefttd">
                           <b>product impact </b>
                       </td>
                       <td class="colontd">
                           :</td>
                       <td style="text-align:left">
                           <asp:DropDownList ID="DropDownList2" runat="server" CssClass="textborder" 
                               Height="22px" onchange="Change(this)" Width="200px">
                               <asp:ListItem Text="No" Value="1">Select</asp:ListItem>
                               <asp:ListItem Text="No" Value="1"></asp:ListItem>
                               <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                           </asp:DropDownList>
                       </td>
     </tr>
     <tr>
         <td align="right" class="lefttd">
             <b>Regulator impact </b>
         </td>
         <td class="colontd">
             :</td>
         <td style="text-align:left">
             <asp:DropDownList ID="DropDownList13" runat="server" CssClass="textborder" 
                 Height="22px" onchange="second1(this)" Width="200px">
                 <asp:ListItem>Select</asp:ListItem>
                 <asp:ListItem Text="No" Value="1"></asp:ListItem>
                 <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
             </asp:DropDownList>
         </td>
         <td align="right" colspan="3">
             <asp:Button ID="Button2" runat="server" CssClass="buttonstyle" 
                 onclick="Button2_Click" Text="Go" />
         </td>
     </tr>
                   
                   </table>
</asp:Panel>
</td>
</tr>
<tr id="Tr1" runat="server">
<td colspan=6 >
<asp:Panel ID="pnl2" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td  class="lefttd" align="right">
<b>Department </b> 
</td>
<td class="colontd" width="3px">:</td>
 <td style="text-align:left">
 <asp:TextBox ID="TextBox5" runat="server" Height="18px" Width ="195px"></asp:TextBox>
                            </td>
                                <td  class="lefttd" align="right">
 <b> Date </b> 
</td>
<td class="colontd">:</td>
<td style="text-align:left">
 <asp:TextBox ID="TextBox6" runat="server" Height="18px" Width ="195px"></asp:TextBox>
                            </td>
             
                            </tr>
                            <tr>
                         <td colspan=6 align="right">
 <asp:Button ID="Button1" runat="server" Text="Go"  CssClass="buttonstyle" onclick="Button1_Click1"/>
                            </td>
                            </tr>
                            

                 
</table>
</asp:Panel>
</td>
</tr>
<tr>
<td colspan="6" align="center">
<asp:Panel ID="pnl3" runat="server">
        <asp:GridView ID="GridView1" runat="server"    Width="85%"  AutoGenerateColumns="false"
        CssClass="subtr"  DataKeyNames="changeid"  
         >
<HeaderStyle BackColor="#c6d8ef" />
<AlternatingRowStyle BackColor="#e3e3e3" />

<Columns>

<asp:TemplateField HeaderText="Change Request Id" HeaderStyle-HorizontalAlign="Left">

<ItemTemplate><asp:LinkButton ID="lblats" runat="server" Text='<%#Eval("Changeid")%>' OnClick="lnkeditrecord"></asp:LinkButton></ItemTemplate>
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
</td>
</tr>
<tr>
<td align="center" colspan="6">
    <asp:Label ID="Label1" runat="server" Text="No Records Found!" Font-Bold="true" ForeColor="Red" Font-Size="Medium" Visible="false"></asp:Label>

</td>
</tr>
</table>