<%@ Page Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true" CodeFile="CMS_Final QA.aspx.cs" Inherits="Final_QA" Title="Final QA Review Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="UserControl/topusercontrol.ascx" TagName="top" TagPrefix="c1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/table.css" />
    <link rel="stylesheet" type="text/css" href="css/contentstyle.css" />  
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
<asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
  <div style="padding-top:0px;padding-bottom:4px;">

<%--<table width="80%">
<tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="lnklogout" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<asp:Label ID="lbldateid" runat="server" Text="Date" CssClass="boldblack" Font-Bold="true" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>
<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><asp:Label ID="lblname" Font-Bold="true" runat="server" Text="UserName"  CssClass="boldblack"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" ></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:70px">
<asp:Label ID="lbltimeid" runat="server" Text="Time" CssClass="boldblack" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>
</td>
</tr>
</table> --%>     
    <table width="100%"  >
           <tr><td colspan="2" style="background-color:#ebebeb"><table width="100%">
        <tr><td  align="left" style="padding-left:10px;padding-top:3px"><img src="images/logocmpny.png" alt="aceindus"  width="130px"/>
        
        </td>
        <td align="right" style="padding-right:50px;padding-top:3px">
        
        <b><asp:Label ID="Label13" CssClass="boldblack" runat="server" Text="UserName"  Font-Bold="true"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbluname" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;<strong>|</strong>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnklogout" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>

        </tr>
        <tr><td  align="left" style="padding-left:20px" valign="top">
        <asp:Label ID="lbldiv" runat="server" Text="Divison/Project/Dept : " CssClass="boldblack" Font-Bold="true" ForeColor="#2e96b3"></asp:Label>
        &nbsp;<asp:Label ID="lblchmname" runat="server" Text="Hyd/Change Management Module/Production" CssClass="boldblack" Font-Bold="true"></asp:Label>
        </td>
        
        <td align="right"  style="padding-right:50px">
<b><asp:Label ID="Label14" runat="server" Text="Date"  Font-Bold="true" CssClass="boldblack" ></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
&nbsp;&nbsp;
<b><asp:Label ID="Label15" runat="server" Text="Time" Font-Bold="true" CssClass="boldblack"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>

</td>
        </tr>
       <tr><td colspan="2" align="left" >
      
<asp:Button ID="btnsaave" runat="server" Text="Save" />
<asp:Button ID="btnspellchk" runat="server" Text="Check Spelling"  OnClientClick="$Spelling.SpellCheckInWindow('editors')" />
</td></tr>
       </table></td></tr>  
<tr><td align="left" class="content" >

<asp:Label ID="qaid" runat ="server" Text="Cross-Functional Departments"></asp:Label>
</td>

</tr>
<tr><td align="left">
   
<table width="100%" style="background-color:white">
<tr>
<td  valign="top" style="padding-top:5px;" align="left">
<%--<asp:UpdatePanel ID="pnlupd" runat="server"  UpdateMode="Always">--%>
  
<table  width="100%"  > 



<tr><td colspan="2" class="tdinitleft" style="padding-left:10px" align="left">

<table align="left" width="100%" >
<tr><td align="left" runat="server" visible="false"><asp:LinkButton ID="linkassign" runat="server"  
        CssClass="lnkcolor" onclick="linkassign_Click"> <asp:Label ID="lblassign" runat="server" Text="My Changes"></asp:Label></asp:LinkButton> <asp:Label ID="lblcomma" runat="server" Text="/" CssClass="lnkcolor"></asp:Label>
 <asp:LinkButton ID="lnkact" runat="server"  CssClass="lnkcolor" 
        onclick="lnkact_Click"> <asp:Label ID="lblitems" runat="server" Text ="Action Items" ></asp:Label></asp:LinkButton></td></tr>

<tr runat="server" visible="false"><td align="left"></td></tr>
</table>

</td>
<td align="right" valign="top" style="padding-right:50px" id="tdstatus" runat="server"><asp:Label ID="lblstatu" runat="server" Font-Bold="true" Text="Status" CssClass="boldblack"></asp:Label>
<strong >:</strong>
<asp:Label ID="lblstat" runat="server" ></asp:Label>
 </td>
</tr>


<tr id="userbody" visible="false" runat="server"><td colspan="3" align="left">
<asp:Panel id="pnl111" runat="server" visible="false">
<table width="100%">
 <tr runat="server" id="trwaiting" visible="false">
 <td colspan="3" align="center"><asp:Label ID="lblwait" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></td></tr>
           
<tr>
<td align="right" style="width:22.5%">
<b><asp:Label ID="Label6" runat="server" Text="ChangeID" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left">
<asp:Label ID="lbltext" runat="server" CssClass="cidfont" ForeColor="#006699"></asp:Label>

</td>

</tr>
<tr>
<td align="right" style="width:22.5%">
<b><asp:Label ID="head" runat="server" Text="Department" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left">

<asp:DropDownList ID="txtcomment" runat="server"  Height="22px" Width="200px" 
        CssClass="textborder" onselectedindexchanged="txtcomment_SelectedIndexChanged" AutoPostBack="true">
</asp:DropDownList>

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

<asp:Panel ID="pnl1" runat="server" Visible="false" width="100%">
<table width="80%" class="subtable">
<tr >
<td colspan="3"  align="left">
    <asp:Label ID="Label11" runat="server" Text="Add Action Details" 
        ForeColor="#7496c2" ></asp:Label>
</td>
</tr>
<tr class="subtr">
<td><table><tr>
<td align="right"  >
<asp:Label ID="Label3" runat="server" Text="Executor" Width="100px" ></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:DropDownList ID="DropDownList1" runat="server" Width="130px" CssClass="textborder">
<asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="1"> Executior1</asp:ListItem>
<asp:ListItem Value="2"> Executior2</asp:ListItem>
<asp:ListItem Value="3"> Executior3</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="reqexe" runat="server" ControlToValidate="DropDownList1" InitialValue="Select" ValidationGroup="valadd" ErrorMessage="*" >*</asp:RequiredFieldValidator>
</td>

</tr></table></td>


<td><table><tr>
<td align="right" >
<asp:Label ID="Label4" runat="server" Text="Reviewer" width="100px"></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:DropDownList ID="DropDownList2" runat="server" Width="150px" CssClass="textborder">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList2" InitialValue="Select" ValidationGroup="valadd" ErrorMessage="*">*</asp:RequiredFieldValidator>

</td>
</tr>
</table>
</td>


</tr>
<tr class="subtr">
<td colspan="2"><table><tr>
<td align="right" >
<asp:Label ID="Label5" runat="server" Text="Target Date" width="100px"></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:TextBox ID="txtdate" runat="server" CssClass="textborder" Width="120px"></asp:TextBox>
<ajax:CalendarExtender ID="date" runat="server" TargetControlID="txtdate"></ajax:CalendarExtender>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdate"  ValidationGroup="valadd" ErrorMessage="*" >*</asp:RequiredFieldValidator>

</td>

</tr></table></td>
</tr>

<tr><td></td>
<td></td>
<td align="right">
<asp:Button ID="add" runat="server" Text="Add" onclick="add_Click" CssClass="buttonstyle" ValidationGroup="valadd" />

</td>
</tr>

</table>
</asp:Panel>
</td>
</tr>
<tr>
<td></td><td></td>

<td id="grdd" runat="server" align="left" style="padding-top:5px">

<asp:GridView ID="gd" runat="server" Visible="true" Width="85%" 
        AutoGenerateColumns="false" BorderColor="#b2a1c7" BorderWidth="1px" 
        CssClass="subtr"
        onrowdeleting="gd_RowDeleting" 
         >
<HeaderStyle BackColor="#c6d8ef" />
<AlternatingRowStyle BackColor="#e3e3e3" />

 <Columns>
         
         <asp:BoundField DataField="Executor" HeaderText="Executor"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
          <asp:BoundField DataField="Reviewer" HeaderText="Reviewer" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
           <asp:BoundField DataField="Target Date" HeaderText="TimeLine" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                   <asp:CommandField DeleteImageUrl="~/images/delete-button.png" ShowDeleteButton="true" ButtonType="Image" ControlStyle-Width="18px" ControlStyle-Height="18px" HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left"/>
         
         </Columns>
</asp:GridView>

</td></tr>




<tr><td colspan="2">
<asp:ValidationSummary ID="valid1" runat="server" ValidationGroup="valid" ShowSummary="false" ShowMessageBox="true" /></td></tr>
</table>
</asp:Panel>
</td></tr>
</table>

</td></tr>
<tr>


<td width="80%" colspan="2" height="30px" style="text-align:right;padding-right:30px" align="right" >
    &nbsp;&nbsp;

<asp:Button  ID="Button7"  runat="server"  Text="Save & Close(F2))"  
        CssClass="buttonstyle"  Width="120px" onclick="Button7_Click"
              />

 <asp:Button  ID="submit"  runat="server"  Text="Submit(F3)"  CssClass="buttonstyle"  Width="90px"  OnClick="submit_Click"
              />
              <asp:Button  ID="Button1"  runat="server"  
        Text="Return for Need Additional Information"  CssClass="buttonstyle"  
        Width="300px" onclick="Button1_Click" 
              />
</td></tr>

</table>

</td>
</tr>



</table>
</div>
</asp:Content>

