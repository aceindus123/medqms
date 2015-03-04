<%@ Page Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true" CodeFile="CMS_racg.aspx.cs" Inherits="CMS_racg"  %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="UserControl/topusercontrol.ascx" TagName="top" TagPrefix="c1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/contentstyle.css" rel="stylesheet" />
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
  <%--<table width="80%">
             
             <tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="lnklogout" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<asp:Label ID="lbldateid" runat="server" Text="Date"   CssClass="boldblack" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><asp:Label ID="lblname" Font-Bold="true" CssClass="boldblack" runat="server" Text="UserName"  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" ></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:70px">
<asp:Label ID="lbltimeid" runat="server" Text="Time" Font-Bold="true" CssClass="boldblack"></asp:Label>&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>
</td>
</tr>
             
             </table>--%>
           
    <table width="100%" >
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
<tr><td align="left" class="content" >

<asp:Label ID="qaid" runat ="server" Text="Regulatory or CG Review"  ></asp:Label>
</td>

</tr>
<tr><td>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   
<ContentTemplate>

<table width="100%" style="background-color:white;">


<tr><td colspan="2" class="tdinitleft" style="padding-left:10px" align="left">

<table align="left" >
<tr><td align="left" runat="server" visible="false"><asp:LinkButton ID="linkassign" runat="server"  
        CssClass="lnkcolor" onclick="linkassign_Click"> 
    
&nbsp;&nbsp;&nbsp; <asp:Label ID="lblassign" runat="server" Text="My Changes"></asp:Label></asp:LinkButton><asp:Label ID="lblcomma" runat="server" Text="/" CssClass="lnkcolor"></asp:Label>
  <asp:LinkButton ID="lnkact" runat="server"  CssClass="lnkcolor" 
        onclick="lnkact_Click"> <asp:Label ID="lblitems" runat="server" Text ="Action Items" ></asp:Label></asp:LinkButton></td></tr>

<tr runat="server" visible="false"><td align="left"></td></tr>
</table>
</td>
<td align="right" valign="top" style="padding-right:50px" id="tdstatus" runat="server"><asp:Label ID="lblstatu"  runat="server" Font-Bold="true" Text="Status" CssClass="boldblack"></asp:Label>
<strong >:</strong>
<asp:Label ID="lblstat" runat="server" ></asp:Label>
 </td>
</tr>


<tr id="content" runat="server" visible="false">
<td  valign="top" style="padding-top:5px;padding-left:0px" colspan="3" align="left">
 <asp:Panel id="pnl111" runat="server" visible="false">
<table  width="100%" >
<tr>
<td align="right"  class="lefttd" >
<b><asp:Label ID="Label7" runat="server" Text="Change Request ID" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left">
    <asp:Label ID="lbltext" runat="server" CssClass="cidfont" ForeColor="#006699"></asp:Label>
</td>

</tr>

<tr>
<td align="right"  class="lefttd" style="width:22.5%">
<b><asp:Label ID="head" runat="server" Text="Impact on Regulatory" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left">
<asp:DropDownList ID="DdlRegularity" runat="server"  Width="190px" 
         AutoPostBack="true" CssClass="textborder" onselectedindexchanged="DdlRegularity_SelectedIndexChanged" 
       >
<asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>

</tr>

<tr id="com" runat="server" visible="false">
<td align="right" class="lefttd" style="width:22.5%">
<b><asp:Label ID="Label1" runat="server" Text="Comments" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" >
<asp:TextBox ID="Txtcomment" runat="server" CssClass="textborder" Width="400px" Height="70px"></asp:TextBox>
</td>

</tr>

<tr>
<td align="right" class="lefttd" style="width:22.5%">
<b><asp:Label ID="Label2" runat="server" Text="Create Action Tree" ></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" >
<asp:DropDownList ID="ddlitems" runat="server" Width="190px" 
        onselectedindexchanged="ddlitems_SelectedIndexChanged" AutoPostBack="true" CssClass="textborder">
<asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>

</tr>

<tr><td></td>
<td></td>
<td>

<asp:Panel ID="pnl1" runat="server" Visible="false" width="100%">
<table width="80%" class="subtable" >

 <tr >
<td colspan="3"  align="left" style="width:22.5%">
    <asp:Label ID="Label11" runat="server" Text="Add Action Details"  ForeColor="#7496c2" Font-Bold="true"></asp:Label>
</td>
</tr>

<tr class="subtr">

<td colspan="2"><table><tr>
<td align="left" >
<asp:Label ID="Label6" runat="server" Text=" Action Item Description"  ></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:TextBox ID="action" runat="server" Width="400px" Height="75px" CssClass="textborder" TextMode="MultiLine"></asp:TextBox>
</td>
</tr></table></td>

</tr>


<tr class="subtr">
<td><table><tr>

<td align="right"  >
<asp:Label ID="Label3" runat="server" Text="Executor" width="70px"></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:DropDownList ID="DropDownList1" runat="server" Width="190px" 
        CssClass="textborder" 
      >
<asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="1">Executor1</asp:ListItem>
<asp:ListItem Value="2">Executor2</asp:ListItem>
<asp:ListItem Value="3">Executor3</asp:ListItem>


</asp:DropDownList>
</td>
</tr></table></td>
<td><table><tr>
<td align="right"  >
<asp:Label ID="Label4" runat="server" Text="Reviewer" width="70px"></asp:Label>

</td>
<td>:</td>
<td align="left" >
<asp:DropDownList ID="DropDownList2" runat="server" Width="190px" CssClass="textborder">
<asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="1">Reviewer1</asp:ListItem>
<asp:ListItem Value="2">Reviewer2</asp:ListItem>
<asp:ListItem Value="3">Reviewer3</asp:ListItem>


</asp:DropDownList>
</td>
</tr></table></td>
</tr>

<tr class="subtr">
<td><table><tr>
<td align="right"  >
<asp:Label ID="Label5" runat="server" Text="Target Date" width="70px"></asp:Label>

</td>
<td >:</td>
<td align="left">
<asp:TextBox ID="txtdate" runat="server" CssClass="textborder" Width="185px"></asp:TextBox>
<ajax:CalendarExtender ID="date" runat="server" TargetControlID="txtdate"></ajax:CalendarExtender>
</td>
</tr></table></td>
<td><table></table></td>
</tr>
<tr class="subtr"><td id="Td1" runat ="server" align="center"></td>
<td></td>
<td align="right"><asp:Button ID="add" runat="server" Text="Add" onclick="add_Click" CssClass="buttonstyle"/></td>
</tr>

</table>
</asp:Panel>
</td>
</tr>

<tr><td></td><td></td>



<td id="grdd" runat="server" align="left">

<asp:GridView ID="gd" runat="server"    Width="88%" AutoGenerateColumns="false" BorderColor="#b2a1c7" BorderWidth="1px" 
        CssClass="subtr" 
        onrowdeleting="gd_RowDeleting" >
<HeaderStyle BackColor="#c6d8ef" />
<AlternatingRowStyle BackColor="#e3e3e3" />

  <Columns>
         
         <asp:BoundField DataField="Action Item Description" HeaderText="Action Item Description"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
          <asp:BoundField DataField="Executor" HeaderText="Executor" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
           <asp:BoundField DataField="Reviewer" HeaderText="Reviewer" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="Date" HeaderText="Target Date" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
               <asp:CommandField DeleteImageUrl="~/images/delete-button.png" ShowDeleteButton="true" ButtonType="Image" ControlStyle-Width="18px" ControlStyle-Height="18px" HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left"/>
         
         </Columns>

</asp:GridView>

</td>
</tr>

</table>
</asp:Panel>
</td>
</tr>

</table>
</ContentTemplate>
</asp:UpdatePanel>
</td>
</tr>
<tr id="tdbtn" runat="server" >

<td width="80%" colspan="2" height="30px" style="text-align:right;padding-right:30px" align="right" >
    &nbsp;&nbsp;
<asp:Button  ID="BtnSave"  runat="server"  Text="Save & Close(F2))"  
        CssClass="buttonstyle"  Width="120px" onclick="BtnSave_Click" 
              />

<asp:Button  ID="btnsubmit"  runat="server"  Text="Submit(F3)"  CssClass="buttonstyle"  Width="90px"  OnClick="submit_Click"
              />

 <asp:Button  ID="Btnreturn"  runat="server"  
        Text="Return for Need Additional Information"  CssClass="buttonstyle"  
        Width="300px" onclick="return_Click"  
              />
</td></tr>



</table>




</asp:Content>

