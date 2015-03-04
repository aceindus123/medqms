<%@ Page Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true" CodeFile="QAReg1.aspx.cs" Inherits="Final_QA" Title="Coordinator" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

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
 <script type="text/javascript">
     function GridSelectAllColumn(spanChk) {
         var oItem = spanChk.children;
         var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0]; xState = theBox.checked;
         elm = theBox.form.elements;

         for (i = 0; i < elm.length; i++) {
             if (elm[i].type === 'checkbox' && elm[i].checked != xState)
                 elm[i].click();
         }
     }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
 <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>


<%--
   <table width="80%">
    
    
     <tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="LinkButton1" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<asp:Label ID="Label13" runat="server" Text="Date" CssClass="boldblack"  Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><asp:Label ID="Label15" runat="server" Text="UserName" CssClass="boldblack" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" ></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:70px">
<asp:Label ID="Label17" runat="server" Text="Time" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>
</td>
</tr>
    </table>--%>

    <table width="100%" >
       <tr><td colspan="2" style="background-color:#ebebeb"><table width="100%">
        <tr><td  align="left" style="padding-left:10px;padding-top:3px"><img src="images/logocmpny.png" alt="aceindus"  width="130px"/>
        
        </td>
        <td align="right" style="padding-right:50px;padding-top:3px">
        
        <b><asp:Label ID="Label13" CssClass="boldblack" runat="server" Text="UserName"  Font-Bold="true"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbluname" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;<strong>|</strong>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton5" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>

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
<tr><td align="left" class="content" colspan="2">

<asp:Label ID="qaid" runat ="server" Text="Change control co-ordinator"  ></asp:Label>
</td>

</tr>

<tr><td>

<table width="100%" style="background-color:white">

 

<tr><td colspan="2" class="tdinitleft" style="padding-left:10px" align="left">

<table align="left" width="100%">
<tr><td align="left" runat="server" visible="false"><asp:LinkButton ID="linkassign" runat="server"  
        CssClass="lnkcolor" onclick="linkassign_Click"> &nbsp;<asp:Label ID="lblassign" runat="server" Text="My Changes"></asp:Label></asp:LinkButton> <asp:Label ID="lblcomma" runat="server" Text="/" CssClass="lnkcolor"></asp:Label>
 <asp:LinkButton ID="lnkact" runat="server"  CssClass="lnkcolor" 
        onclick="lnkact_Click"> &nbsp;<asp:Label ID="lblitems" runat="server" Text="My Action Items"></asp:Label></asp:LinkButton></td></tr>

<tr runat="server" visible="false"><td align="left"><asp:LinkButton ID="lnknew" runat="server" CssClass="lnkcolor" 
        onclick="lnknew_Click"> <asp:Label ID="lblinitiate" runat="server" Text="Rviewer Type" ></asp:Label></asp:LinkButton></td></tr>
</table>
</td>

<td align="right" valign="top" style="padding-right:50px" id="tdstatus" runat="server"><asp:Label ID="lblstatu" runat="server" Font-Bold="true" Text="Status" CssClass="boldblack"></asp:Label>
<strong >:</strong>
<asp:Label ID="lblstat" runat="server" ></asp:Label>
 </td>
</tr>


<tr runat="server" id="trwaiting" visible="false"><td colspan="3" align="center"><asp:Label ID="lblwait" runat="server" ForeColor="#26614D" Font-Size="13px"></asp:Label></td></tr>
  
 <tr id="content" runat="server" visible="false">
            <td colspan="3" align="left" style="padding-left:10px">

     

            <asp:Panel id="pnl111" runat="server" visible="false">




<table  width="100%" >
         
  <tr>
            <td class="lefttd" align="right">
             <b>  <asp:Label ID="Label19" runat="server" Text="Change Request Id" ></asp:Label></b>            
            </td>
            <td class="colontd">
            <strong>:</strong>
            </td>
            <td align="left">
                <asp:Label ID="lbltext" runat="server" CssClass="cidfont" ></asp:Label>
            </td>
            </tr>
<tr>
<td align="right"  class="lefttd" width="200px" >
                                    <b><asp:Label ID="Lablf" runat="server" Text="Comments"></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" style="vertical-align:top" valign="top">
                                
                                    <asp:TextBox ID="txtcomment" runat="server" CssClass="textborder" Width="180px" Height="55px"></asp:TextBox>

</td>

</tr>

<tr>
<td align="right"  class="lefttd"  width="200px" >
                      <b>  <asp:Label ID="Label1" runat="server" Text="Is Functional Review Required"></asp:Label></b>

</td>
<td class="colontd"><strong >:</strong></td>
<td align="left" >

<asp:DropDownList ID="DropDownList3" runat="server" Width="150px" 
        onselectedindexchanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true" CssClass="textborder" >
<asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
                      <%-- <asp:DropDownList ID="DropDownList3" runat="server" onchange = "Change(this)" Height="20px" Width="190px" 
                                            CssClass="textborder">
       <asp:ListItem Text = "No" Value = "1"></asp:ListItem>                                      
    <asp:ListItem Text = "Yes" Value = "0"></asp:ListItem>
   
    </asp:DropDownList>
                             --%>
                          
                            
</td>

</tr>
<tr>
<td>

</td>
<td>

</td>
<td align="left" id="pnn" runat="server" visible="false">
<asp:Panel ID="pnl1" runat="server"  width="100%"  Visible="false" >

<table width="95%" class="subtable"  >
<tr >
<td colspan="3"  align="left"  width="200px" >
    <asp:Label ID="Label11" runat="server" Text="Add Review Details" ForeColor="#7496c2" Font-Bold="true" ></asp:Label>
</td>
</tr>


<tr class="subtr">
<td><table><tr>
<td align="right" >
<asp:Label ID="lblpr" runat="server" Text="Priority"  width="190px"></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:DropDownList ID="txtpriority" runat="server" CssClass="textborder" width="150px" onselectedindexchanged="txtpriority_SelectedIndexChanged" AutoPostBack="true"
        >
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>Priority of routing</asp:ListItem>
        <asp:ListItem>Parallel routing</asp:ListItem>
        </asp:DropDownList>
   
   <asp:RequiredFieldValidator ID="prid" runat="server" ControlToValidate="txtpriority" ErrorMessage="Please Select Priority filed" InitialValue="Select" ValidationGroup="functionadd">*</asp:RequiredFieldValidator>

</td>

</tr></table></td>


<td id="tdpri" runat="server" visible="true"><table><tr>
<td align="right" >
<asp:Label ID="Label16" runat="server" Text="Priority Code"  width="120px"></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:DropDownList ID="ddlrioritycode" runat="server" CssClass="textborder" width="120px"
        >
       
        <asp:ListItem>Select One</asp:ListItem>
      
        <asp:ListItem>1</asp:ListItem>
         <asp:ListItem>2</asp:ListItem>
          <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
         <asp:ListItem>5</asp:ListItem>
          <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
         <asp:ListItem>8</asp:ListItem>
          <asp:ListItem>9</asp:ListItem>
        </asp:DropDownList>
  
   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlrioritycode" ErrorMessage="Please Select Priority filed" InitialValue="Select One" ValidationGroup="functionadd">*</asp:RequiredFieldValidator>

</td>

</tr></table></td>

</tr>

<tr class="subtr">

<td><table><tr>
<td align="left"  >
   <asp:Label ID="Label6" runat="server" 
        Text="Choose cross functional Reviewer" width="190px"></asp:Label>

</td>
<td >:</td>
<td align="left" valign="top">
<asp:DropDownList ID="DropDownList6" runat="server" CssClass="textborder" AutoPostBack="true"
        Width="150px" onselectedindexchanged="DropDownList6_SelectedIndexChanged">
 <asp:ListItem Text="Select" ></asp:ListItem>
  
</asp:DropDownList>

<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList6" ErrorMessage="Please Select Priority filed" InitialValue="Select" ValidationGroup="functionadd">*</asp:RequiredFieldValidator>

</td>
</tr></table></td>


<td id="Td1" ><table><tr>
<td align="right"  valign="top">
<asp:Label ID="Label2" runat="server" Text="Timeline" Width="120px"></asp:Label>

</td>
<td valign="top">:</td>
<td align="left" valign="top" >
<asp:TextBox ID="txttime" runat="server" CssClass="textborder" Width="120px"
        ></asp:TextBox>
    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" 
        TargetControlID="txttime">
    </ajax:CalendarExtender>

   
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttime" ErrorMessage="Please Select Priority filed"  ValidationGroup="functionadd">*</asp:RequiredFieldValidator>


</td>
</tr></table></td>



</tr>

<tr class="subtr">

<td><table><tr>
<td align="right"  valign="top">
<asp:Label ID="Label5" runat="server" Text="Reviewer"  Width="190px"></asp:Label>

</td>
<td  valign="top">:</td>
<td align="left" valign="top">
    <asp:DropDownList ID="DropDownList7" runat="server" CssClass="textborder" 
        Width="150px" onselectedindexchanged="DropDownList7_SelectedIndexChanged">
    <asp:ListItem>Select</asp:ListItem>
      
       
    </asp:DropDownList>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList7" ErrorMessage="Please Select Priority filed" InitialValue="Select" ValidationGroup="functionadd">*</asp:RequiredFieldValidator>

</td>

</tr></table></td>


<td runat="server" visible="false"><table><tr>
<td align="left" >
<asp:Label ID="Label4" runat="server" Text="Target completion Date" width="140px"></asp:Label>

</td>
<td >:</td>
<td align="left" valign="top">
    <asp:TextBox ID="txtcmpdate" runat="server" CssClass="textborder" Width="120px"></asp:TextBox>
    <ajax:CalendarExtender ID="txtcmpdate_CalendarExtender" runat="server" 
        TargetControlID="txtcmpdate">
    </ajax:CalendarExtender>
</td>
</tr></table></td>
</tr>


<tr class="subtr">
<td></td>
<td  align="right" style="padding-left:15px">
<%--<asp:Button ID="Button1" runat="server" Text="Add" onclick="add_Click" />--%>
<asp:Button ID="Button1" runat="server" Text="Add" CssClass="buttonstyle" onclick="add_Click" ValidationGroup="functionadd"/>
</td>

</tr>

</table>

</asp:Panel>
</td>
</tr>

<tr>
<td>

</td>
<td>
</td>
<td style="padding-top:5px" align="left">

<asp:GridView ID="gd" runat="server" Visible="true" Width="85%" 
        AutoGenerateColumns="false" BorderColor="#adb1b9" BorderWidth="1px" 
        CssClass="subtr" 
        onrowdeleting="gd_RowDeleting" 
         >
         <Columns>
          <asp:BoundField DataField="priority" HeaderText="Priority Name"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
      
           <asp:BoundField DataField="prioritycode" HeaderText="Priority"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
       
                     <asp:BoundField DataField="crossfunreviwer" HeaderText="Choose The Cross Functional Reviewer"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
       <asp:BoundField DataField="Timeline" HeaderText="TimeLine" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
           
         <asp:BoundField DataField="Reviewer" HeaderText="Reviewer" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
            
            <asp:BoundField DataField="tgtcmpltndate" HeaderText="Target Completion Date" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
             <asp:CommandField DeleteImageUrl="~/images/delete-button.png" ShowDeleteButton="true" ButtonType="Image" ControlStyle-Width="18px" ControlStyle-Height="18px" HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left"/>
         
         </Columns>
      
<HeaderStyle BackColor="#c6d8ef" />
<AlternatingRowStyle BackColor="#e3e3e3" />


</asp:GridView>
</td>
</tr>




</table>









<table width="100%">
<tr ><td class="lefttd" align="right"  width="200px" >
    <b><asp:Label ID="Label3" runat="server" 
        Text=" Action Tree"></asp:Label></b>
        </td>
        
        <td class="colontd"><strong >:</strong></td>
<td align="left" style="padding-top:3px">



<asp:DropDownList ID="DropDownList1" runat="server" Width="150px" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="textborder">
<asp:ListItem >Select</asp:ListItem>
<asp:ListItem >Yes</asp:ListItem>
<asp:ListItem  >No</asp:ListItem>

</asp:DropDownList>

             
</td>

        </tr>
        <tr>
        <td></td><td></td>
        <td align="left">
   <asp:Panel ID="Panel1" runat="server" Visible="false" Width="100%">
       
<table width="95%" class="subtable" >
<tr class="subtr">
<td colspan="4">
    <asp:Label ID="Label12" runat="server" Text="Add Action Details" ForeColor="#7496c2" Font-Bold="true"></asp:Label>

</td>
</tr>
<tr class="subtr" runat="server" >
<td><table><tr>
<td align="right" >
<asp:Label ID="Label7" runat="server" Text="Action item description" width="130px" ></asp:Label>

</td>
<td >:</td>
<td align="left" style="padding-top:3px">
    <asp:TextBox ID="txtdesc" runat="server" CssClass="textborder" Width="150px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reddesc" runat="server" ControlToValidate="txtdesc" ErrorMessage="Enter Action Item Description" ValidationGroup="actionadd">*</asp:RequiredFieldValidator>
   
</td>
</tr></table></td>
<td><table><tr>
<td align="right" >
<asp:Label ID="Label8" runat="server" Text="Executor" width="120px" ></asp:Label>

</td>
<td >:</td>
<td align="left" >
    <asp:DropDownList ID="DropDownList8" runat="server" CssClass="textborder" Width="150px">
     <asp:ListItem Value="0">Select</asp:ListItem>
        <asp:ListItem Value="1">Executor1</asp:ListItem>
        <asp:ListItem Value="2">Executor2</asp:ListItem>
        <asp:ListItem Value="3">Executor3</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="Select" ControlToValidate="DropDownList8" ErrorMessage="Please Select Executor" ValidationGroup="actionadd">*</asp:RequiredFieldValidator>
   
</td>
</tr></table></td>
</tr>

<tr class="subtr">




<td><table><tr>

<td align="right" >
<asp:Label ID="lbldept" runat="server" Text="Department" width="130px"></asp:Label>

</td>
<td>:</td>
<td align="left">
<asp:DropDownList ID="ddldept" runat="server" CssClass="textborder" Width="150px" AutoPostBack="true"
        onselectedindexchanged="ddldept_SelectedIndexChanged" >
<asp:ListItem Text="Select" ></asp:ListItem>
   <asp:ListItem Text="Production" ></asp:ListItem>
                         <asp:ListItem Text="Quality Assurance" ></asp:ListItem>
                          <asp:ListItem Text="Quality Control" ></asp:ListItem>

</asp:DropDownList>
    
   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="Select" ControlToValidate="ddldept" ErrorMessage="Please Select Department" ValidationGroup="actionadd">*</asp:RequiredFieldValidator>
   
   
</td>
</tr></table></td>

<td><table><tr>

<td align="right">
<asp:Label ID="Label9" runat="server" Text="Reviewer"  width="120px"></asp:Label>

</td>
<td>:</td>
<td align="left">
    <asp:DropDownList ID="DropDownList9" runat="server" CssClass="textborder" Width="150px">
    <asp:ListItem Value="0">Select</asp:ListItem>
        <asp:ListItem Value="1">Reviewer1</asp:ListItem>
        <asp:ListItem Value="2">Reviewer2</asp:ListItem>
        <asp:ListItem Value="3">Reviewer3</asp:ListItem>
    </asp:DropDownList>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="Select" ControlToValidate="DropDownList9" ErrorMessage="Please Select Reviewer" ValidationGroup="actionadd">*</asp:RequiredFieldValidator>
   
   
</td>
</tr></table></td>
</tr>




<tr class="subtr">

<td><table><tr>
<td align="right" >
<asp:Label ID="lblhod" runat="server" Text="Department HOD"  width="130px" ></asp:Label>

</td>
<td>:</td>
<td align="left">
    <asp:DropDownList ID="ddldepthod" runat="server" CssClass="textborder" Width="150px">
    <asp:ListItem >Select</asp:ListItem>
        <asp:ListItem >Dept HOD1</asp:ListItem>
        <asp:ListItem >Dept Hod2</asp:ListItem>
       
    </asp:DropDownList>

   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" InitialValue="Select" ControlToValidate="ddldepthod" ErrorMessage="Please Select Department HOD" ValidationGroup="actionadd">*</asp:RequiredFieldValidator>
   
</td>
</tr></table></td>

<td><table><tr>
<td align="right"  >
<asp:Label ID="Label10" runat="server" Text="Timeline" width="120px"></asp:Label>

</td>
<td >:</td>
<td align="left" >
<asp:TextBox ID="txttime1" runat="server" CssClass="textborder" Width="150px"
        ></asp:TextBox>
    <ajax:CalendarExtender ID="txttime1_CalendarExtender" runat="server" 
        TargetControlID="txttime1">
    </ajax:CalendarExtender>
   
   <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  ControlToValidate="txttime1" ErrorMessage="Please Enter Timeline" ValidationGroup="actionadd">*</asp:RequiredFieldValidator>
   

</td>
</tr></table></td>
</tr>



<tr >
<td></td><td align="right"><asp:Button ID="Button2" runat="server" Text="Add"  onclick="add1_Click" CssClass="buttonstyle" ValidationGroup="actionadd"/></td>

</tr>



</table>

        </asp:Panel>
        </td>
        </tr>
        
        <tr>
        <td>
        
        </td>
        <td>
        </td>
        <td align="left">
        
        



<asp:GridView ID="GridView1" runat="server" Visible="true" Width="85%" 
        AutoGenerateColumns="false" BorderColor="#adb1b9" BorderWidth="1px" 
        CssClass="subtr" 
        onrowdeleting="grd1_RowDeleting" 
         >
         <Columns>

   
         <asp:BoundField DataField="actnitmdesc" HeaderText="Action Item Description Reviewer"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
          <asp:BoundField DataField="Executor" HeaderText="Executor" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
          <asp:BoundField DataField="department" HeaderText="Department"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="depthod" HeaderText="DepartmentHod" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"  />
           
           <asp:BoundField DataField="Reviewer1" HeaderText="Reviewer" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="TimeLine1" HeaderText="TimeLine" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>

            <asp:CommandField DeleteImageUrl="~/images/delete-button.png" ShowDeleteButton="true" ButtonType="Image" ControlStyle-Width="18px" ControlStyle-Height="18px" HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left"/>
         
         </Columns>
      
<HeaderStyle BackColor="#c6d8ef" />
<AlternatingRowStyle BackColor="#e3e3e3" />


</asp:GridView>
        </td>
        </tr>
        
        </table>




</asp:Panel>

</td>
</tr>

<tr ><td colspan="3" style="text-align:right;padding-right:30px" id="btns" runat="server">


                       
                       <asp:Button  ID="Button3"  runat="server"  Text="Save(F1)"  
                           CssClass="buttonstyle"  Width="100px" onclick="Button3_Click"  />
                       
                       <asp:Button  ID="Button4"  runat="server"  Text="Save/Close"  
                           CssClass="buttonstyle"  Width="100px" onclick="Button4_Click"  />
                      
                           <asp:Button  ID="submit"  runat="server"  Text="Submit(F3)"  CssClass="buttonstyle"  Width="90px"  OnClick="submit_Click"
              />           
               <asp:Button  ID="Button5"  runat="server"  Text="Cancel"  CssClass="buttonstyle"  
                           Width="100px" onclick="Button5_Click"  />
                            <asp:Button  ID="btnaprver"  runat="server"  Text="Approve"  Visible="false"
                           CssClass="buttonstyle"  Width="90px" onclick="btnaprver_Click" 
              />           
                                 </td>
           
       


</tr>


<tr><td><asp:ValidationSummary ID="valid1" runat="server" ValidationGroup="valid" ShowSummary="false" ShowMessageBox="true" /></td></tr>

</table>

</asp:Content>

