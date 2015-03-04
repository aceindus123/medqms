<%@ Page Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true"
    CodeFile="CMS_ChangeOwner.aspx.cs" Inherits="CMS_ChangeOwner" Title="Change Owner Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="UserControl/topusercontrol.ascx" TagName="top" TagPrefix="c1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
    <link rel="stylesheet" type="text/css" href="css/table.css" />
    <script  type="text/javasrcipt"  src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
  
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div style="padding-top: 0px; height: auto">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<%--
    <table width="80%">
    
    
     <tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="lnklogout" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<asp:Label ID="lbldateid" runat="server" Text="Date"  Font-Bold="true" CssClass="boldblack"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><asp:Label ID="lblname" runat="server" Text="UserName"  Font-Bold="true" CssClass="boldblack"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" ></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:70px">
<asp:Label ID="lbltimeid" runat="server" Text="Time" Font-Bold="true" CssClass="boldblack"></asp:Label>&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>
</td>
</tr>
    </table>--%>

     
    
        <table  width="100%" align="center" >
              <tr><td colspan="2" style="background-color:#ebebeb"><table width="100%">
        <tr><td  align="left" style="padding-left:10px;padding-top:3px"><img src="images/logocmpny.png" alt="aceindus"  width="130px"/>
        
        </td>
        <td align="right" style="padding-right:50px;padding-top:3px">
        
        <b><asp:Label ID="Label8" CssClass="boldblack" runat="server" Text="UserName"  Font-Bold="true"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbluname" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;<strong>|</strong>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton5" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>

        </tr>
        <tr><td  align="left" style="padding-left:20px" valign="top">
        <asp:Label ID="lbldiv" runat="server" Text="Divison/Project/Dept : " CssClass="boldblack" Font-Bold="true" ForeColor="#2e96b3"></asp:Label>
        &nbsp;<asp:Label ID="lblchmname" runat="server" Text="Hyd/Change Management Module/Production" CssClass="boldblack" Font-Bold="true"></asp:Label>
        </td>
        
        <td align="right"  style="padding-right:50px">
<b><asp:Label ID="Label10" runat="server" Text="Date"  Font-Bold="true" CssClass="boldblack" ></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
&nbsp;&nbsp;
<b><asp:Label ID="Label12" runat="server" Text="Time" Font-Bold="true" CssClass="boldblack"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>

</td>
        </tr>
       <tr><td colspan="2" align="left" >
      
<asp:Button ID="btnsaave" runat="server" Text="Save" />
<asp:Button ID="btnspellchk" runat="server" Text="Check Spelling"  OnClientClick="$Spelling.SpellCheckInWindow('editors')" />
</td></tr>
       </table></td></tr>
            <tr>
                <td align="left" valign="top" colspan="2" class="content" >
                   
                    Concerned Department HOD</td>
            </tr>
<tr><td colspan="2"><table width="100%">

        

<tr><td align="center" colspan="2" valign="top">
<table width="100%">
 

<table align="left"  width="100%">
<tr><td align="left" runat="server" visible="false">
<asp:LinkButton ID="linkassign" runat="server"  
        CssClass="lnkcolor" onclick="linkassign_Click">
 <asp:Label ID="lblassign" runat="server" Text="My Changes" ></asp:Label></asp:LinkButton> 

 <asp:Label ID="lblcomma" runat="server" Text="/" CssClass="lnkcolor"></asp:Label>
 <asp:LinkButton ID="lnkact" runat="server"  CssClass="lnkcolor" 
        onclick="lnkact_Click">
 <asp:Label ID="lblitems" runat="server"  Text="My Action Items"></asp:Label></asp:LinkButton>
 

</td>
 
 <td align="right" style="padding-right:50px" id="tdstatus" runat="server"><asp:Label ID="lblstatu" runat="server" Font-Bold="true" Text="Status" CssClass="boldblack"></asp:Label>
<strong >:</strong>
<asp:Label ID="lblstat" runat="server" ></asp:Label>
 </td>
</tr>

<tr id="Tr1" runat="server" visible="false"><td align="left"><asp:LinkButton ID="lnknew" runat="server" CssClass="lnkcolor" 
        onclick="lnknew_Click"> <asp:Label ID="lblinitiate" runat="server" Text="Rviewer Type" ></asp:Label></asp:LinkButton></td></tr>
</table>
</td></tr>
<tr><td><br /></td></tr>
          </table>                                      
          
           
            <asp:Panel id="pnl111" runat="server" visible="false">
            <table width="100%" style="vertical-align:top" >
             <tr runat="server" id="trwaiting" visible="false"><td colspan="3" align="center"><asp:Label ID="lblwait" runat="server" ForeColor="#26614D" Font-Size="13px"></asp:Label></td></tr>
           
           <tr>
            <td class="lefttd" align="right">
             <b>  <asp:Label ID="Label9" runat="server" Text="Change Request Id" ></asp:Label></b>            
            </td>
            <td class="colontd">
            <strong>:</strong>
            </td>
            <td align="left">
                <asp:Label ID="lbltext" runat="server"  CssClass ="cidfont" ForeColor="#006699"></asp:Label>
            </td>
            </tr>
            <tr>
            <td class="lefttd" align="right">
             <b>  <asp:Label ID="lblChngOwnrAction" runat="server" Text="HOD Action" ></asp:Label></b>            
            </td>
            <td class="colontd">
            <strong>:</strong>
            </td>
            <td align="left">
             <asp:DropDownList ID="ddlChngOwnrAction" runat="server" Width="200px" Height="22px"
                        CssClass="textborder" 
                    onselectedindexchanged="ddlChngOwnrAction_SelectedIndexChanged">
                        <asp:ListItem>Select One</asp:ListItem>
                        <asp:ListItem>Approve</asp:ListItem>
                        <asp:ListItem>Recommend for Reject</asp:ListItem>
                        <asp:ListItem>Return for additional info</asp:ListItem>
                       
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="Select One" runat="server" ControlToValidate="ddlChngOwnrAction" ErrorMessage="Please Select Change Owner Action" ValidationGroup="valid" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
            <td align="right" valign="top">
               <b>  <asp:Label ID="lblChngOwnrComments" runat="server" Text="Review Analysis / Outcome" 
                       ></asp:Label></b><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
             <td class="colontd" valign="top">
            <strong>:</strong>
            </td>
            <td align="left">
              <asp:TextBox ID="txtChngOwnrComments" runat="server" TextMode="MultiLine" Width="600px"
                        CssClass="textborder" Height="100px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="tbwmChngOwnrComments" runat="server" TargetControlID="txtChngOwnrComments"
                        WatermarkText="Please Write Owner Comments" >
                    </asp:TextBoxWatermarkExtender>
                    <asp:RequiredFieldValidator ID="rd1" runat="server" ControlToValidate="txtChngOwnrComments" ErrorMessage="Please Write Owner Comments" ValidationGroup="valid" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            </tr>
              
                         <tr>
                        <td align="right">
                            <b>
                            <asp:Label ID="lblFileToAttach" runat="server" Text="Attachments"></asp:Label>
                            </b>
                        </td>
                        <td class="colontd">
                            <strong>:</strong>
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fu" runat="server" />
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" >
                            <b>
                            <asp:Label ID="Label2" runat="server" Text="Create Action Tree "></asp:Label>
                            </b>
                        </td>
                        <td class="colontd">
                            <strong>:</strong>
                        </td>
                        <td align="left" >
                       

<asp:DropDownList ID="DropDownList1" runat="server" Width="150px" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="textborder">
<asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        
<asp:Panel ID="pnl1" runat="server" Visible="false" width="100%">
                            <table ID="owner1" class="subtable"  width="90%" runat="server" align="left">
                                <tr>
                                    <td align="left" colspan="3">
                                        <asp:Label ID="Label11" runat="server" Font-Bold="true" ForeColor="#7496c2" 
                                            Text="Add Action Details"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="subtr">


                                <td colspan="3"><table><tr>
                                    <td align="left">
                                        <asp:Label ID="Label7" runat="server" Text="Action Item Description"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtcomments" runat="server" CssClass="textborder" 
                                            Height="75px" TextMode="MultiLine" Width="390px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdcomments" runat="server" ValidationGroup="addingpnl" ControlToValidate="txtcomments" ErrorMessage="Please Enter Action Item Description">*</asp:RequiredFieldValidator>
                                    </td>

                                    </tr></table></td>
                                </tr>
                                <tr class="subtr">

                               <td><table><tr>
                                    <td align="right" >
                                        <asp:Label ID="Label3" runat="server" Text="Executor"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList2" runat="server" Height="22px" Width="200px">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Executor1</asp:ListItem>
                                            <asp:ListItem>Executor2</asp:ListItem>
                                            <asp:ListItem>Executor3</asp:ListItem>
                                        </asp:DropDownList>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="DropDownList2"  InitialValue="Select" ValidationGroup="addingpnl">*</asp:RequiredFieldValidator>
                                  
                                    </td>

                                    </tr></table></td>


                                    <td><table><tr>
                                     <td align="right">
                                        <asp:Label ID="Label4" runat="server" Text="Reviewer"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="200px" 
                                            onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                          
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  runat="server" ControlToValidate="DropDownList3" InitialValue="Select" ValidationGroup="addingpnl">*</asp:RequiredFieldValidator>
                                  
                                    </td>
                                    
                                    
                                    </tr></table></td>

                                  
                                  <td><table><tr><td></td></tr></table></td>
                                </tr>
                                
                                <tr class="subtr">


                                <td><table><tr>

                                    <td align="right">
                                        <asp:Label ID="Label5" runat="server" Text="Approver"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList4" runat="server" Height="22px" Width="200px">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Approver1</asp:ListItem>
                                            <asp:ListItem>Approver2</asp:ListItem>
                                            <asp:ListItem>Approver3</asp:ListItem>
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  runat="server" ControlToValidate="DropDownList4"  InitialValue="Select" ValidationGroup="addingpnl">*</asp:RequiredFieldValidator>
                                  
                                    </td>

                                    </tr></table></td>

                                    <td><table><tr>
                                    
                                    <td align="right">
                                        <asp:Label ID="Label6" runat="server" Text="TimeLine"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="195px"></asp:TextBox>

                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1">
                                        </asp:CalendarExtender>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="addingpnl" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter TimeLine" >*</asp:RequiredFieldValidator>
                                  
                                    </td>
                                    
                                    </tr></table></td>
                                </tr>
                              
                              <tr><td></td>
<td></td>
<td align="right">
<asp:Button ID="add" runat="server" Text="Add" CssClass="buttonstyle"  onclick="add_Click"  ValidationGroup="addingpnl"/>

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
        AutoGenerateColumns="false" BorderColor="#adb1b9" BorderWidth="1px" 
        CssClass="subtr" 
        onrowdeleting="gd_RowDeleting" 
         >
         <Columns>
         
         <asp:BoundField DataField="ACTITEMDESC" HeaderText="Action Item Description Reviewer"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
          <asp:BoundField DataField="Executor" HeaderText="Executor" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
           <asp:BoundField DataField="Reviewer" HeaderText="Reviewer" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="Approver" HeaderText="Approver" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
             <asp:BoundField DataField="TimeLine" HeaderText="TimeLine" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
             <asp:CommandField DeleteImageUrl="~/images/delete-button.png" ShowDeleteButton="true" ButtonType="Image" ControlStyle-Width="18px" ControlStyle-Height="18px" HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left"/>
         
         </Columns>
      
<HeaderStyle BackColor="#c6d8ef" />
<AlternatingRowStyle BackColor="#e3e3e3" />


</asp:GridView>

</td></tr>
          <tr>
            <td colspan="3" align="right" style="background-color:none;text-align:right;padding-right:30px">
                   <%-- <asp:Button ID="Button1" runat="server" Text="Save(F1)" CssClass="buttonstyle" width="75px"
                       OnClientClick="alert('Saved Successfully')"/>--%>
                       <asp:Button ID="button" runat="server" Text="Save(F1)" 
                       CssClass="buttonstyle" Width="90px" onclick="button_Click"  />
                       
                  
               <asp:Button ID="saveclose" runat="server" Text="Save&Close(F2)" Width="120px"  
                       CssClass="buttonstyle" onclick="saveclose_Click" />
                    
                   <%-- <asp:Button ID="Button3" runat="server" Text="Submit(F3)" 
                        CssClass="buttonstyle" Width="75px" OnClientClick="alert('Submited Successfully')"/>--%>
                       <%-- <input id="Button8" type="button" value="Submit(F3)"  class="buttonstyle" onclick="alert('Submited Successfully')" style="Width:90px"/>
                --%>    
                  <asp:Button ID="submit" runat="server" Text="Submit(F3)" CssClass="buttonstyle" Width="90px" OnClick="submit_Click" ValidationGroup="valid"
             />
                  <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="buttonstyle" 
                       Width="90px" onclick="cancel_Click" />
                  
                </td></tr>
               
            </table>
            </asp:Panel>
            </td>
            </tr>
</table>
</td></tr>




</table></td></tr>
        
      
      
             </table>
        <table width="1110px">
       
            <tr><td>
            <asp:ValidationSummary ID="vl" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="valid" />
            </td></tr>
            
       
        </table>
        <%--<ajax:ModalPopupExtender ID="popActionItems" runat="server" TargetControlID="lbActionItems"
            PopupControlID="show" CancelControlID="btnClose" DropShadow="false" BackgroundCssClass=" background-color:#BCDBE8;
            filter: alpha(opacity=50);
            opacity: 0.7;">
        </ajax:ModalPopupExtender>--%>
       <%-- <asp:Panel ID="show" runat="server">
            <div id="divUc">
                <wc:cn ID="i" runat="server" />
            </div>
            <div id="divClose" align="center" style="background-color:#EBE9F6;border:1px solid #8B8A8A">
                <table width="100%" >
                    <tr>
                        <td align="center" >
                            <asp:Button ID="btnClose" runat="server"  Text="Close" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>--%>
    </div>
</asp:Content>
