<%@ Page Title="" Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true" CodeFile="CMS_Cab Review.aspx.cs" Inherits="CMS_Cab_Review" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<%@ Register Src="UserControl/topusercontrol.ascx" TagName="top" TagPrefix="c1" %>
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
<asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
  <div style="padding-top:0px;padding-bottom:4px;" >
           <%--  <table width="80%">
             <tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="lnklogout" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<b><asp:Label ID="lbldateid" runat="server" Text="Date" CssClass="boldblack" Font-Bold="true" ></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><b><asp:Label ID="lblname" CssClass="boldblack" Font-Bold="true" runat="server" Text="UserName"  ></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" ></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:70px">
<b><asp:Label ID="lbltimeid" runat="server" Text="Time" CssClass="boldblack" Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>
</td>
</tr>
             
             </table>--%>
   
   
    <table  align="center" width="100%">
     <tr><td colspan="2" style="background-color:#ebebeb"><table width="100%">
        <tr><td  align="left" style="padding-left:10px;padding-top:3px"><img src="images/logocmpny.png" alt="aceindus"  width="130px"/>
        
        </td>
        <td align="right" style="padding-right:50px;padding-top:3px">
        
        <b><asp:Label ID="Label8" CssClass="boldblack" runat="server" Text="UserName"  Font-Bold="true"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbluname" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;<strong>|</strong>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnklogout" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>

        </tr>
        <tr><td  align="left" style="padding-left:20px" valign="top">
        <asp:Label ID="lbldiv" runat="server" Text="Divison/Project/Dept : " CssClass="boldblack" Font-Bold="true" ForeColor="#2e96b3"></asp:Label>
        &nbsp;<asp:Label ID="lblchmname" runat="server" Text="Hyd/Change Management Module/Production" CssClass="boldblack" Font-Bold="true"></asp:Label>
        </td>
        
        <td align="right"  style="padding-right:50px">
<b><asp:Label ID="Label9" runat="server" Text="Date"  Font-Bold="true" CssClass="boldblack" ></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
&nbsp;&nbsp;
<b><asp:Label ID="Label10" runat="server" Text="Time" Font-Bold="true" CssClass="boldblack"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>

</td>
        </tr>
       <tr><td colspan="2" align="left" >
      
<asp:Button ID="btnsaave" runat="server" Text="Save" />
<asp:Button ID="btnspellchk" runat="server" Text="Check Spelling"  OnClientClick="$Spelling.SpellCheckInWindow('editors')" />
</td></tr>
       </table></td></tr> 
    <tr><td>
    
<table width="100%"> 
<tr><td  align="left" class="content">
<asp:Label ID="qaid" runat ="server" Text="Head QA" ></asp:Label>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<table width="100%"  >
 

<tr><td colspan="2" class="tdinitleft" style="padding-left:10px" align="left">

<table align="left" >
<tr><td align="left" runat="server" visible="false"><asp:LinkButton ID="linkassign" runat="server"  
        CssClass="lnkcolor" onclick="linkassign_Click">
 <asp:Label ID="lblassign" runat="server" Text="My Changes"></asp:Label></asp:LinkButton> <asp:Label ID="lblcomma" runat="server" Text="/" CssClass="lnkcolor"></asp:Label>
 <asp:LinkButton ID="lnkact" runat="server"  CssClass="lnkcolor" 
        onclick="lnkact_Click">
 <asp:Label ID="lblitems" runat="server" Text="Action Items"></asp:Label></asp:LinkButton></td></tr>

</table>
</td>
<td align="right" valign="top" style="padding-right:50px" id="tdstatus" runat="server"><asp:Label ID="lblstatu" runat="server" Font-Bold="true" Text="Status" CssClass="boldblack"></asp:Label>
<strong >:</strong>
<asp:Label ID="lblstat" runat="server" ></asp:Label>
 </td>
</tr>

<tr id="userbody" runat="server" visible="false"><td colspan="3" >
<asp:Panel id="pnl111" runat="server" visible="false">
<table>
<tr>
<td align="right"  class="lefttd" >
<b><asp:Label ID="Label7" runat="server" Text="Change ID" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left">
    <asp:Label ID="lbltext" runat="server" CssClass="cidfont"></asp:Label>
</td>

</tr>
<tr>
<td align="right" class="lefttd"><b><asp:Label ID="actionid" runat="server" Text="QA Review Comments" ></asp:Label></b>
</td>
<td class="colontd"><strong>:</strong></td>
<td style ="padding-right:15px;padding-top:5px;padding-bottom:5px" align="left"><asp:TextBox ID="txtcomm" runat="server" TextMode="MultiLine" CssClass="textborder" Height="100px" Width="400px"></asp:TextBox>
</td>


</tr>


<tr>
<td align="right" style="width:200px">
<b><asp:Label ID="Label3" runat="server" Text="Approver Action Tree" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">
<asp:DropDownList ID="ddlitemsapprover" runat="server" Width="190px" 
        CssClass="textborder" 
         >   
<asp:ListItem>Select</asp:ListItem>
</asp:DropDownList>
<%-- AutoPostBack="true" onselectedindexchanged="ddlitems_SelectedIndexChanged1"
<asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Quality Non impacting</asp:ListItem>
<asp:ListItem>Quality impacting</asp:ListItem>--%>
</td>

</tr>

<tr><td>


</td>

<td></td>

<td>

<asp:Panel ID="pnl1apprver" runat="server"  width="100%">
<table width="90%" class="subtable" id="sub" runat="server">
<tr >
<td colspan="3"  align="left" >
    <asp:Label ID="Label11" runat="server" Text="Approver Action Details" 
        ForeColor="#7496c2" ></asp:Label>
</td>
</tr>
<tr class="subtr">
<td><table><tr>
<td align="right"  >
<asp:Label ID="Label1" runat="server" Text="Forward for Approve" Width="120px" ></asp:Label>

</td>
<td >:</td>
<td align="left" style="padding-top:3px">
<asp:DropDownList ID="ddlapprove" runat="server" Width="150px" CssClass="textborder">
<asp:ListItem>Select</asp:ListItem>
<asp:ListItem>CQA</asp:ListItem>
<asp:ListItem>Head QA</asp:ListItem>
</asp:DropDownList>
</td>

</tr></table></td>


<td><table><tr>
<td align="right" >
<asp:Label ID="Label4" runat="server" Text="Management Notification" width="150px"></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:DropDownList ID="ddlmgt" runat="server" Width="150px" CssClass="textborder">
<asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Send Mail</asp:ListItem>

</asp:DropDownList>
</td>
</tr>
</table>
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

<asp:GridView ID="gdaprver" runat="server" Visible="false" Width="85%" 
        AutoGenerateColumns="false" BorderColor="#adb1b9" BorderWidth="1px" 
        CssClass="subtr" 
        onrowdeleting="gd_RowDeleting" 
         >
         <Columns>
         
         <asp:BoundField DataField="Comments" HeaderText="QA Review Comments"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
          <asp:BoundField DataField="fwdaprv" HeaderText="Forward for Approve " ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
           <asp:BoundField DataField="mgtnfcion" HeaderText="Management Notification" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
              <asp:CommandField DeleteImageUrl="~/images/delete-button.png" ShowDeleteButton="true" ButtonType="Image" ControlStyle-Width="18px" ControlStyle-Height="18px" HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left"/>
         
         </Columns>
      
<HeaderStyle BackColor="#c6d8ef" />
<AlternatingRowStyle BackColor="#e3e3e3" />


</asp:GridView>

</td></tr>




<tr><td colspan="2"><asp:ValidationSummary ID="valid1" runat="server" ValidationGroup="valid" ShowSummary="false" ShowMessageBox="true" /></td></tr>

</table>
</asp:Panel>
</td></tr>


<tr id="tbtn" runat="server" ><td width="80%"  height="30px"  align="right" style="text-align:right;padding-right:30px" colspan="3">
    &nbsp;&nbsp;
      <asp:Button  ID="BtnSave"  runat="server"  Text="Save & Close(F2))"  
        CssClass="buttonstyle"  Width="120px" onclick="BtnSave_Click" 
              />

       <asp:Button  ID="Btnsubmit"  runat="server"  Text="Approve"  CssClass="buttonstyle"  Width="90px"  OnClick="submit_Click"
              />
              <asp:Button  ID="Btnreject"  runat="server"  Text="Reject"  
        CssClass="buttonstyle"  Width="90px" onclick="Btnreject_Click"  
              />
                

                 <asp:Button  ID="Btnreturn"  runat="server"  
        Text="Return for  Need Additional information"  CssClass="buttonstyle"  
        Width="250px" onclick="Btnreturn_Click" 
              />
</td></tr>

</table>
</td></tr></table>

</div>
</asp:Content>

