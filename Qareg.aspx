<%@ Page Title="" Language="C#" MasterPageFile="~/CMSMasterPage22.master" AutoEventWireup="true" CodeFile="Qareg.aspx.cs" Inherits="Qareg" %>

<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
   <style type="text/css">
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


 <table >
             <tr>
             <td runat="server" id="tdini">
                 <asp:HyperLink  ID="LinkButton1" runat="server" NavigateUrl="CMS_Initiator.aspx">Intiator</asp:HyperLink>
                 </td>
                 <td>
                 <b>&gt;&gt;</b>
                 </td>
                   <td runat="server" id="tdreviewer">
             <asp:HyperLink ID="LinkButton2" runat="server" NavigateUrl="CMS_ChangeOwner.aspx">Reviewer</asp:HyperLink>
             </td>
                 
                  <td>
                 <b>&gt;&gt;</b>
                 </td>
           
                 <td runat="server" id="tdcft">
                 
                 <asp:HyperLink ID="LinkButton3" runat="server" NavigateUrl="CMS_Final QA.aspx">CFT</asp:HyperLink>
                 </td>
                  <td>
                 <b>&gt;&gt;</b>
                 </td>
                 <td runat="server" id="tdracg"> 
                 <asp:HyperLink ID="LinkButton4" runat="server" NavigateUrl="CMS_racg.aspx">RA/CG</asp:HyperLink>
             </td>
             
             
             </tr>
             </table>
 
    <table width="80%"  border="solid 1px" > 
<tr><td align="left" class="content" style="border:solid 1px">

<asp:Label ID="qaid" runat ="server" Text="Cross-Functional Departments"  ></asp:Label>
</td>

</tr>
<tr><td align="left">
   
<table width="100%" style="background-color:white">
<tr>
<td  valign="top" style="padding-top:5px;" align="left">
<%--<asp:UpdatePanel ID="pnlupd" runat="server"  UpdateMode="Always">--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    

<ContentTemplate>
 
<table  width="100%"  >
<tr><td colspan="3" style ="border-bottom: 1px solid #A8C1DF"><c1:top ID="HeaderMenu1" runat="server" /></td></tr>
<tr><td>
<asp:Panel id="pnl111" runat="server" visible="false">
<table>
<tr>
<td align="right" style="width:22.5%">
<b><asp:Label ID="Label6" runat="server" Text="ChangeID" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left">
<asp:Label ID="lbltext" runat="server" ></asp:Label>

</td>

</tr>
<tr>
<td align="right" style="width:22.5%">
<b><asp:Label ID="head" runat="server" Text="Department" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left">
<asp:TextBox ID="txtcomment" runat="server" CssClass="textborder"></asp:TextBox>

</td>

</tr>

<tr>
<td align="right"  class="lefttd">
<b><asp:Label ID="Label1" runat="server" Text="Impact Analysis" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" >
<asp:TextBox ID="TextBox1" runat="server" CssClass="textborder"></asp:TextBox>
</td>

</tr>



<tr>
<td align="right" style="width:200px">
<b><asp:Label ID="Label2" runat="server" Text="Create Action Tree" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
<asp:DropDownList ID="ddlitems" runat="server" Width="150px" 
        onselectedindexchanged="ddlitems_SelectedIndexChanged" AutoPostBack="true" CssClass="textborder">
<asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>

</tr>
<tr><td>


</td>

<td></td>

<td>
<asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
<asp:Panel ID="pnl1" runat="server" Visible="false" width="100%">
<table width="70%" class="subtable">
<tr >
<td colspan="3"  align="left">
    <asp:Label ID="Label11" runat="server" Text="Add Action Details" 
        ForeColor="#b2a1c7" ></asp:Label>
</td>
</tr>
<tr class="subtr">
<td align="right"  >
<asp:Label ID="Label3" runat="server" Text="Executor" ></asp:Label>

</td>
<td >:</td>
<td align="left" style="padding-top:3px">
<asp:DropDownList ID="DropDownList1" runat="server" Width="150px" CssClass="textborder">
<asp:ListItem Value="0">Select
   </asp:ListItem>

<asp:ListItem Value="1"> Executior1</asp:ListItem>
<asp:ListItem Value="2"> Executior2</asp:ListItem>
<asp:ListItem Value="3"> Executior3</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr class="subtr">
<td align="right" >
<asp:Label ID="Label4" runat="server" Text="Reviewer" ></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:DropDownList ID="DropDownList2" runat="server" Width="150px" CssClass="textborder">
<asp:ListItem Value="0">Select </asp:ListItem>

<asp:ListItem Value="1"> Reviewer1</asp:ListItem>
<asp:ListItem Value="2"> Reviewer2</asp:ListItem>
<asp:ListItem Value="3"> Reviewer3</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr class="subtr">
<td align="right" >
<asp:Label ID="Label5" runat="server" Text="Target Date" ></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:TextBox ID="txtdate" runat="server" CssClass="textborder"></asp:TextBox>
<ajax:CalendarExtender ID="date" runat="server" TargetControlID="txtdate"></ajax:CalendarExtender>
    &nbsp;&nbsp;
</td>
</tr>
<tr><td></td>
<td></td>
<td align="right">
<asp:Button ID="add" runat="server" Text="Add" onclick="add_Click" CssClass="buttonstyle" />

</td>
</tr>

</table>
</asp:Panel>
</td>
</tr>
<tr>
<td></td><td></td>

<td id="grdd" runat="server" align="left" style="padding-top:5px">

<asp:GridView ID="gd" runat="server" Visible="true" Width="69.7%" 
        AutoGenerateColumns="true" BorderColor="#b2a1c7" BorderWidth="1px" 
        CssClass="subtr"  AutoGenerateDeleteButton="true"  
        onrowdeleting="gd_RowDeleting" 
         >
<HeaderStyle BackColor="#b2a1c7" />
<AlternatingRowStyle BackColor="#dcccf1" />

<%--<asp:TemplateField HeaderText="Department" HeaderStyle-HorizontalAlign="Left">

<ItemTemplate><asp:Label ID="lbldep" runat="server" Text='<%#Eval("txtdep")%>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Impact Analysis" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblyes" runat="server" Text='<%# Eval("txtimp") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Action Tree" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lblyes1" runat="server" Text='<%# Eval("txtact") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>--%>
<%--<asp:TemplateField HeaderText ="Executor" HeaderStyle-HorizontalAlign="Left" >
<ItemTemplate><asp:Label ID="lbltype1" runat="server" Text='<%# Eval("txtexe") %>' ></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Reviewer" HeaderStyle-HorizontalAlign="Left" >
<ItemTemplate><asp:Label ID="lbltype2" runat="server" Text='<%#Eval("txtrev") %>' ></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="Date" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate><asp:Label ID="lbltype3" runat="server" Text='<%#Eval("txtdate") %>' ></asp:Label></ItemTemplate>
</asp:TemplateField>--%>
<%--<Columns>
 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Left" >
                <ItemTemplate>
                <asp:LinkButton ID="btndel" Text="Delete" runat="server" OnClick="lnkdeleterecord" ForeColor="Black"></asp:LinkButton>  
                </ItemTemplate>
                </asp:TemplateField>
</Columns>--%>
</asp:GridView>

</td></tr>




<tr><td><asp:ValidationSummary ID="valid1" runat="server" ValidationGroup="valid" ShowSummary="false" ShowMessageBox="true" /></td></tr>
</table>
</asp:Panel>
</td></tr>
</table>
</ContentTemplate>

</asp:UpdatePanel>
</td></tr>


</table>

</td>
</tr>


<tr>


<td width="80%" colspan="2" height="30px" style="background-color:#dadcdd;text-align:right;padding-right:30px" align="right" >
    &nbsp;&nbsp;<%--<asp:ImageButton ID="save" runat="server" ImageUrl="images/closeb2.png" 
        ValidationGroup="valid" onclick="save_Click" />&nbsp;&nbsp;
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/submitb2.png" 
        ValidationGroup="valid" onclick="ImageButton1_Click" />&nbsp;&nbsp;
<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/returnb1.png" 
        ValidationGroup="valid" onclick="ImageButton2_Click" />--%>
<input id="Button7" type="button" value="Save & Close(F2)"  class="buttonstyle" onclick="alert('Save & Closed Successfully')" style="Width:110px"/>

 <asp:Button  ID="submit"  runat="server"  Text="Submit(F3)"  CssClass="buttonstyle"  Width="90px"  OnClick="submit_Click"
              />
              <asp:Button  ID="Button1"  runat="server"  
        Text="Return for Need Additional Information"  CssClass="buttonstyle"  
        Width="300px" onclick="Button1_Click" 
              />

<%--<input id="Button1" type="button" value="Return for Need Additional Information"  class="buttonstyle" onclick="alert('Submited Successfully')" style="Width:300px"/>
--%></td></tr>
</table>
</asp:Content>

