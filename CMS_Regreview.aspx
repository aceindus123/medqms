<%@ Page Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true" CodeFile="CMS_Regreview.aspx.cs" Inherits="Final_QA" Title="Final QA Review Page" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   <link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
   <style type="text/css">
  
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <table width="80%"  border="solid 1px" > 
<tr><td align="left" class="content" style="border:solid 1px">

<asp:Label ID="qaid" runat ="server" Text="change control co-ordinator"  ></asp:Label>
</td>

</tr>
<tr><td><table width="100%" style="background-color:white">
<tr>
<td  valign="top" style="padding-top:5px;" >
<table  width="100%" >
<tr>
<td align="right"  class="lefttd">
                                    <b><asp:Label ID="Lablf" runat="server" Text="Comments"></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left">
                                
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="textborder" Width="180px" Height="55px"></asp:TextBox>

</td>

</tr>

<tr>
<td align="right"  class="lefttd">
                      <b>  <asp:Label ID="Label1" runat="server" Text="Is Functional Review Required"></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" >
                            <asp:DropDownList ID="DropDownList3" runat="server" 
        CssClass="textborder" AutoPostBack="true"
                            
                                Width="181px" onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
         >
                            <asp:ListItem>Select One</asp:ListItem>
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                            </asp:DropDownList>
</td>

</tr>




</table>
</td>
</tr>
<tr><td>
<asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
<asp:Panel ID="pnl1" runat="server" Visible="false" width="100%">
<table width="100%">
<tr>
<td align="right"  class="lefttd">
    <b><asp:Label ID="Label6" runat="server" 
        Text="Choose the cross functional Reviewer"></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
<asp:DropDownList ID="DropDownList6" runat="server" CssClass="textborder">
<asp:ListItem>FReviewer1</asp:ListItem>
<asp:ListItem>FReviewer2</asp:ListItem>
<asp:ListItem>FReviewer3</asp:ListItem>

</asp:DropDownList>
</td>
</tr>
<tr>
<td align="right"  class="lefttd">
<b><asp:Label ID="Label4" runat="server" Text="Target completion Date" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
    <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
    <ajax:CalendarExtender ID="TextBox5_CalendarExtender" runat="server" 
        TargetControlID="TextBox5">
    </ajax:CalendarExtender>
</td>
</tr>
<tr>
<td align="right"  class="lefttd">
<b><asp:Label ID="Label5" runat="server" Text="Reviewer" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
    <asp:DropDownList ID="DropDownList7" runat="server">
        <asp:ListItem>Reviewer1</asp:ListItem>
        <asp:ListItem>Reviewer2</asp:ListItem>
        <asp:ListItem>Reviewer3</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;
</td>
</tr>
<tr>
<td align="right"  class="lefttd">
<b><asp:Label ID="Label2" runat="server" Text="Timeline" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
<asp:TextBox ID="TextBox3" runat="server" CssClass="textborder" 
        ></asp:TextBox>
    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" 
        TargetControlID="TextBox3">
    </ajax:CalendarExtender>
    &nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="Add" onclick="add_Click" />
</td>
</tr>

</table>
</asp:Panel>
</td></tr>

<tr><td id="grdd" runat="server" align="center" colspan="3">

<asp:GridView ID="gd" runat="server"    Width="80%" AutoGenerateColumns="false">
<AlternatingRowStyle BackColor="#dcccf1" />
<Columns>

<asp:TemplateField HeaderText="Comments" HeaderStyle-HorizontalAlign="Left">

<ItemTemplate><asp:Label ID="lbldep" runat="server" Text='<%#Eval("txtcom")%>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Functional Review" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblyes" runat="server" Text='<%# Eval("txtfrv") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Cross Functional Reviewer" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblyes1" runat="server" Text='<%# Eval("txtcfr") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Target completion Date 	" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype1" runat="server" Text='<%# Eval("txtcdate") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Reviewer" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype2" runat="server" Text='<%#Eval("txtrev") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Timeline" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype3" runat="server" Text='<%#Eval("txtdate") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>

 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                <asp:LinkButton ID="btndel" Text="Delete" runat="server" OnClick="lnkdeleterecord" ForeColor="Black"></asp:LinkButton>  
                </ItemTemplate>
                </asp:TemplateField>

</Columns>
</asp:GridView>

</td></tr>
<tr>

<td align="right"   >
<table width="100%"><tr><td class="lefttd" align="right">
    <b><asp:Label ID="Label3" runat="server" 
        Text="Create Action Items"></asp:Label></b>
        </td>
        
        <td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
                  <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="true"
                        CssClass="textborder" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                  <asp:ListItem>Select One</asp:ListItem>
                     <asp:ListItem>Yes</asp:ListItem>
                     <asp:ListItem>No</asp:ListItem>
                     </asp:DropDownList>
</td>

        </tr>
        
        </table>

</td>
</tr>

<tr><td>

<asp:Panel ID="Panel1" runat="server" Visible="false" width="100%">
<table width="100%">
<tr>
<td align="right"  class="lefttd">
<b><asp:Label ID="Label7" runat="server" Text="Action item description" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
    <asp:TextBox ID="TextBox7" runat="server" CssClass="textborder"></asp:TextBox>
    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" 
        TargetControlID="TextBox5">
    </ajax:CalendarExtender>
</td>
</tr>
<tr>
<td align="right"  class="lefttd">
<b><asp:Label ID="Label8" runat="server" Text="Executor" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
    <asp:DropDownList ID="DropDownList8" runat="server" CssClass="textborder">
        <asp:ListItem>Executor1</asp:ListItem>
        <asp:ListItem>Executor2</asp:ListItem>
        <asp:ListItem>Executor3</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;
</td>
</tr>
<tr>
<td align="right"  class="lefttd">
<b><asp:Label ID="Label9" runat="server" Text="Reviewer" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
    <asp:DropDownList ID="DropDownList9" runat="server" CssClass="textborder">
        <asp:ListItem>Reviewer1</asp:ListItem>
        <asp:ListItem>Reviewer2</asp:ListItem>
        <asp:ListItem>Reviewer3</asp:ListItem>
    </asp:DropDownList>
    <ajax:CalendarExtender ID="CalendarExtender3" runat="server" 
        TargetControlID="TextBox3">
    </ajax:CalendarExtender>
    &nbsp;&nbsp;
</td>
</tr>

<tr>
<td align="right"  class="lefttd">
<b><asp:Label ID="Label10" runat="server" Text="Timeline" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
<asp:TextBox ID="TextBox8" runat="server" CssClass="textborder" 
        ></asp:TextBox>
    <ajax:CalendarExtender ID="TextBox8_CalendarExtender" runat="server" 
        TargetControlID="TextBox8">
    </ajax:CalendarExtender>
    <ajax:CalendarExtender ID="CalendarExtender4" runat="server" 
        TargetControlID="TextBox3">
    </ajax:CalendarExtender>
    &nbsp;&nbsp;
<asp:Button ID="Button3" runat="server" Text="Add" onclick="add1_Click" />
</td>
</tr>



</table>
</asp:Panel>


</td></tr>

<tr><td id="Td1" runat="server" align="center" colspan="3">

<asp:GridView ID="GridView1" runat="server"    Width="60%" AutoGenerateColumns="false">
<AlternatingRowStyle BackColor="#dcccf1" />
<Columns>

<asp:TemplateField HeaderText="Action Items" HeaderStyle-HorizontalAlign="Left">

<ItemTemplate><asp:Label ID="lblats" runat="server" Text='<%#Eval("txtat1")%>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Description" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblyes" runat="server" Text='<%# Eval("txtdesc") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Executor" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblyes1" runat="server" Text='<%# Eval("txtexe1") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Reviewer " HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype1" runat="server" Text='<%# Eval("txtrev1") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Timeline " HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype2" runat="server" Text='<%#Eval("txttime") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>


 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                <asp:LinkButton ID="btndel" Text="Delete" runat="server" OnClick="lnkdeleterecord" ForeColor="Black"></asp:LinkButton>  
                </ItemTemplate>
                </asp:TemplateField>

</Columns>
</asp:GridView>

</td></tr>



<tr><td width="80%" colspan="2" height="30px" style="height:33px;padding-right:20px;padding-top:5px" align="right" >
&nbsp;&nbsp;
<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/saveb21.png" 
        ValidationGroup="valid" onclick="ImageButton2_Click" />&nbsp;&nbsp;
<asp:ImageButton ID="save" runat="server" ImageUrl="images/closeb2.png" 
        ValidationGroup="valid" onclick="save_Click" />&nbsp;&nbsp;
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/submitb2.png" 
        ValidationGroup="valid" onclick="ImageButton1_Click" />&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="images/cancelb2.png" 
        ValidationGroup="valid" onclick="ImageButton3_Click"  />

<%--<asp:Button ID="btnsaveclose" runat="server" Text="Save & Close" ValidationGroup="valid"/>&nbsp;&nbsp;
<asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="valid"/>&nbsp;&nbsp;
<asp:Button ID="btnclose" runat="server" Text="Return" onclick="btnclose_Click"  />--%>


</td></tr>
<tr><td><asp:ValidationSummary ID="valid1" runat="server" ValidationGroup="valid" ShowSummary="false" ShowMessageBox="true" /></td></tr>
</table></td></tr>


</table>

</asp:Content>

