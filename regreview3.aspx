<%@ Page Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true" CodeFile="regreview3.aspx.cs" Inherits="regreview3" Title="regreview" %>
 <%@  Register  Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit"  TagPrefix="asp"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="css/contentstyle.css" rel="stylesheet" />
    
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            height: 27px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-top:4px;padding-bottom:4px;">
<asp:ScriptManager ID="sman1" runat="server"></asp:ScriptManager>

  
    <div style="background-color:White; width:100%;color:black;">
    
        <table width="100%"   >
        <tr><th colspan="4" class="content" align="left">&nbsp;
            Action Item(s)</th></tr>
       <%-- <tr visible="false"><th colspan="4" style="text-align:left;background-color:White">&nbsp;Create Action Items<br />
&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:listitem>yes</asp:listitem>
        <asp:listitem>no</asp:listitem>
        </asp:DropDownList></th></tr>--%>
          <%-- <th colspan="4" style="text-align:left">
               
                  &nbsp;&nbsp;
               
                  <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#569cfc" 
                      onclick="LinkButton1_Click">Add Row</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="#569cfc">Delete last 
                  Row</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:Label ID="lbl3" runat="server" Text="Total Rows:1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Lbl4" runat="server" Text="pages:"></asp:Label>
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="&lt;=" Width="26px" />
                            <asp:Label ID="Label14" runat="server" Text="1"></asp:Label>
                            <asp:Button ID="Button2" runat="server" Text="=&gt;" Width="26px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button3" runat="server" Text="&lt;&lt;" />
                            <asp:TextBox ID="TextBox8" runat="server" Width="70px"></asp:TextBox>
                            <asp:Button ID="Button4" runat="server" Text="&gt;&gt;" />        
       </th>
    --%>

      
    <tr>
      <%--<td width="10%" valign="top" >
          <b>
          &nbsp;&nbsp;
          <asp:Label ID="lblt" runat="server" Text="Delete"></asp:Label></b><br />
          &nbsp;<asp:CheckBox ID="cbox1" runat="server" />
      </td>--%>
      
      <td width="100%" colspan="4">
      
      <table width="100%" border="1px" >
      <tr>
       <td width="40%" valign="top" style="border-right:1px solid #1B1A1A; height:100%; text-align:left;  " >
       
       <table width="100%" >
       <tr>
       <td>
       <b><asp:Label ID="Label6" runat="server" Text="Action"></asp:Label></b>
       </td>
       <td>
      <strong> : </strong> 
       </td>
       <td style="padding-left:20px">
       1
       </td>
       </tr>
       <tr>
       <td>
          <b><asp:Label ID="lblc" runat="server" Text="Action Item Type"></asp:Label> </b><br />
                   
                    

       </td>
        <td>
      <strong> : </strong> 
       </td>
       <td  style="padding-left:20px">
        <asp:DropDownList ID="dlista" runat="server"  CssClass="textborder" 
               onselectedindexchanged="dlista_SelectedIndexChanged">
                     <asp:ListItem>Selectone</asp:ListItem>
                     <asp:ListItem>yes</asp:ListItem>
                     <asp:ListItem>no</asp:ListItem>
                     </asp:DropDownList>
                      <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="dlista" InitialValue="Selectone" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
       </td>
       </tr>
       <tr>
       <td>
         <b><asp:Label ID="lables" runat="server" Text="Assign to Functional Group"></asp:Label> </b>
         </td>
          <td>
      <strong> : </strong> 
       </td>
         <td  style="padding-left:20px">
                       
                         <asp:TextBox ID="txtc" runat="server" Width="165px" CssClass="textborder"></asp:TextBox>
                         <asp:TextBoxWatermarkExtender ID="txtw1" runat="server" TargetControlID="txtc" WatermarkText="Regulatory Affairs" ></asp:TextBoxWatermarkExtender>
       </td>
       </tr>
       <tr>
       <td>
        <b><asp:Label ID="lablg" runat="server" Text="Assign to Created By"></asp:Label> </b>
         </td>
          <td>
      <strong> : </strong> 
       </td>
         <td  style="padding-left:20px">
          <asp:Label ID="Label3" runat="server" Text="Roopak sawney roopak"></asp:Label>
         </td>                    
                       
      
       </tr>
       <tr>
       <td>
       <b> <asp:Label ID="Label4" runat="server" Text="Regulatory Action"></asp:Label> </b>
       </td>
        <td>
      <strong> : </strong> 
       </td>
       <td  style="padding-left:20px">
                     
                     <asp:DropDownList ID="DropDownList2" runat="server" Width="170px">
                     <asp:ListItem>Selectone</asp:ListItem>
                     <asp:ListItem>yes</asp:ListItem>
                     <asp:ListItem>no</asp:ListItem>
                     </asp:DropDownList>
                      <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"  ControlToValidate="DropDownList2" InitialValue="Selectone" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
              </td>
  
       
       </tr>
       </table>
       
       
           
      </td>
         <td width="100%" valign="top" style="text-align:left">
         
         <table width="100%">
         <tr>
         <td width="260px">
          <b><asp:Label ID="lbls" runat="server" Text="Action Item Description"></asp:Label></b><br />
           
         </td>
          <td>
      <strong> : </strong> 
       </td>
         <td  style="padding-left:20px">
           <asp:TextBox ID="txta" runat="server" TextMode="MultiLine" CssClass="textborder"></asp:TextBox>
             <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ControlToValidate="txta" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
         </td>
         </tr>
         <tr>
         <td>
          <b><asp:Label ID="Label9" runat="server" Text="Action Item Due Date"></asp:Label></b>
         </td>
          <td>
      <strong> : </strong> 
       </td>
         <td  style="padding-left:20px">
             <asp:TextBox ID="TextBox8" runat="server" Width="165px" CssClass="textborder"></asp:TextBox>
             <asp:CalendarExtender ID="cal1" runat="server" TargetControlID="TextBox8"></asp:CalendarExtender>
         </td>
         </tr>
         <tr>
         <td>
           <b><asp:Label ID="Label11" runat="server" Text="Action Item owner"></asp:Label> </b>
                           
                          
         </td>
          <td>
      <strong> : </strong> 
       </td>
         <td  style="padding-left:20px">
           <asp:TextBox ID="TextBox5" runat="server" Width="165px" CssClass="textborder"></asp:TextBox>
                              <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server"  ControlToValidate="TextBox5" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
                            
         </td>
         </tr>
         <tr>
         <td>
          <b><asp:Label ID="Label10" runat="server" Text="Action Item Approver"></asp:Label> </b>                           
                            
         </td>
          <td>
      <strong> : </strong> 
       </td>
         <td  style="padding-left:20px">
         <asp:TextBox ID="TextBox4" runat="server" Width="165px" CssClass="textborder"></asp:TextBox>
         </td>
         </tr>
         <tr>
         <td>
           <b><asp:Label ID="Label12" runat="server" Text="Complete Action Item Before Proceeding"></asp:Label> </b><br />
                       
         </td>
          <td>
      <strong> : </strong> 
       </td>
         <td  style="padding-left:20px">
           <asp:TextBox ID="TextBox6" runat="server" Width="165px" CssClass="textborder"></asp:TextBox>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server"  ControlToValidate="TextBox6" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
         </td>
         </tr>
         </table>
         
         
         
         
         
         
         
         
         
            
           
  
             
        </td>
      </tr>
      <tr>
      <td colspan="4" style="width:100%" >
     
     <table width="100%" border="1px">
     <tr>
     <td width="455px">
     <table width="100%">
     <tr>
     <td width="199px">
     <b><asp:label ID="lble" runat="server" Text="Impact on Regulatory Filling"></asp:label></b>
     </td>
      <td>
      <strong> : </strong> 
       </td>
     <td align="left"  style="padding-left:20px">
       <asp:DropDownList ID="DropDownList3" runat="server" CssClass="textborder">
                       <asp:listitem>yes</asp:listitem>
                       <asp:listitem>no</asp:listitem>
                       </asp:DropDownList>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"  ControlToValidate="DropDownList3" InitialValue="yes" ValidationGroup="regreview">*
                       </asp:RequiredFieldValidator>
     </td>
     </tr>
     <tr>
     <td>
        <b> <asp:Label ID="Label7" runat="server" Text="Filling Region"></asp:Label> </b>
      </td>
       <td>
      <strong> : </strong> 
       </td>
      <td align="left"  style="padding-left:20px">
       <asp:TextBox ID="TextBox2" runat="server" Width="170px" CssClass="textborder" ></asp:TextBox>
                          <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"  ControlToValidate="TextBox2" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
     </td>
     </tr>
     <tr>
     <td>
       <b> <asp:Label ID="Label8" runat="server" Text="Filling Country"></asp:Label> </b></td>
        <td>
      <strong> : </strong> 
       </td>
       <td align="left"  style="padding-left:20px">
                         
                         <asp:TextBox ID="TextBox3" runat="server" Width="170px" CssClass="textborder"></asp:TextBox>
                          <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"  ControlToValidate="TextBox3" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
     </td>
     </tr>
     </table>
     </td>
     <td>
     <table width="100%">
     <tr>
     <td colspan="2" >
     
     </td>
     </tr>
     <tr>
     <td width="260px" class="style2">
      <b><asp:Label ID="lblf" runat="server" Text="Filling Region Description"></asp:Label></b><br />
                         
                         
                     </td>
                      <td class="style2">
      <strong> : </strong> 
       </td>
                     <td align="left"  style="padding-left:20px">
                     <asp:TextBox ID="txty" runat="server" CssClass="textborder"></asp:TextBox>
     </td>
     </tr>
     <tr>
     <td>
     <b><asp:Label ID="Label13" runat="server" Text="Type of change Notification/Approve"></asp:Label> </b>
     </td>
      <td>
      <strong> : </strong> 
       </td>
     <td align="left"  style="padding-left:20px">
                       
                         <asp:TextBox ID="TextBox7" runat="server" CssClass="textborder"></asp:TextBox>
                         <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"  ControlToValidate="TextBox7" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
     </td>
     </tr>
     </table>
     </td>
     </tr>
     </table>
      
      </td>
      
     
      </tr>
      
      <tr>
      <td >
      <table width="100%">
      <tr>
      <td>
       <b> <asp:label ID="lbl9" runat="server" Text="Change Owner Action"></asp:label><b>
      </td>
       <td>
      <strong> : </strong> 
       </td> 
      <td align="left"  style="padding-left:20px">
      Approve
      </td>
      </tr>
      <tr>
      <td >
      <b> <asp:label ID="lbl22" runat="server" Text="QA Action"></asp:label></b>
      </td>
       <td>
      <strong> : </strong> 
       </td>
      <td align="left"  style="padding-left:20px">
      Approve
      </td>
      </tr>
      <tr>
      <td>
        <b>
              
                <asp:Label ID="lbl25" runat="server" Text="Regulatory Reviewer Action"></asp:Label></b></td>
                 <td>
      <strong> : </strong> 
       </td>
                <td align="left" style="padding-left:20px">
                   
                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="textborder">
                    <asp:ListItem>selectone</asp:ListItem>
                    <asp:ListItem>Approve</asp:ListItem>
                    <asp:ListItem>Need More Details</asp:ListItem>
                    <asp:ListItem>Recommend Void</asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server"  ControlToValidate="DropDownList4" InitialValue="selectone" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
      </td>
      </tr>
      </table>
      </td>
      
      <td>
          <table width="100%">
      <tr>
      <td width="260px">
       <b> <asp:label ID="Label1" runat="server" Text="Change Owner Comments"></asp:label><b>
      </td>
       <td>
      <strong> : </strong> 
       </td>
      <td align="left"  style="padding-left:20px">
      Change owner Comments  
      </td>
      </tr>
      <tr>
      <td>
      <b> <asp:label ID="Label14" runat="server" Text="
 QA Comments"></asp:label></b>
      </td>
       <td>
      <strong> : </strong> 
       </td>
      <td align="left"  style="padding-left:20px">
     
  QA Comments
      </td>
      </tr>
      <tr>
      <td>
        <b>
              
                <asp:Label ID="Label15" runat="server" Text=" Regulatory Reviewer Comments"></asp:Label></b></td>
                 <td>
      <strong> : </strong> 
       </td>
                <td align="left"  style="padding-left:20px">
                   
                    <asp:TextBox ID="TextBox9" runat="server" CssClass="textborder"></asp:TextBox>
                     <asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server"  ControlToValidate="TextBox9" InitialValue="selectone" ValidationGroup="regreview">*
            </asp:RequiredFieldValidator>
      </td>
      </tr>
      </table>
      </td>
      </tr>
      <tr>
      <td colspan="2" align="center">
          <asp:Button ID="Button1" runat="server" Text="submit" ValidationGroup="regreview"/>
          <asp:ValidationSummary ID="vsum1" runat="server" ValidationGroup="regreview" 
            ShowMessageBox="true" ShowSummary="false" Height="136px" HeaderText="please fill all the fields " />
      </td>
      
      </tr>
      </tr>
      
             
             </table>
                  
      </td>
      </tr>
      </table>
      </td>
      
      
    </tr> 
           
            
        
          
   
              
  
    <%-- <tr> 
    <td  > 
    &nbsp;&nbsp;&nbsp; 
    <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="#569cfc">Add Row</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </td>
    <td  >
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lbtn3" runat="server" ForeColor="#569cfc">Delete Last Row</asp:LinkButton>
    </td>
    </tr> --%>
   
   
  <%-- <tr>
  <td style="background-color:#569cfc;">
    &nbsp;&nbsp;
    <asp:Label ID="lbl8" runat="server" Text="Review"></asp:Label>
    </td>
    </tr>--%>
   
           <%-- <tr>
                <td width="50%" align="left">
                &nbsp;
              
                &nbsp;<asp:Label ID="lbl20" runat="server" Text="Approve"></asp:Label>
                    &nbsp;</td>
                <td width="50%" style="text-align:left;">
             
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="Change owner Comments"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left"><br />
                &nbsp;
                <asp:Label ID="lbl21" runat="server" Text="Approve"></asp:Label>
                    &nbsp;</td>
                <td align="left"><b>&nbsp; <asp:label ID="lbl23" runat="server" Text="QA Comments"></asp:label></b><br />
                &nbsp;
                <asp:Label ID="lbl24" runat="server" Text="QA Comments"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left">
              
                        
                    &nbsp;</td>
                <td align="left">&nbsp;&nbsp; <asp:Label ID="Label5" runat="server" Text="Regulatory Reviewer Comments" ></asp:Label><br />
                 &nbsp;
                 <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox> 
                    &nbsp;</td>
            </tr><br />
       
   
    
      <tr>
              <td colspan="2">
   
        <asp:Button ID="button" runat="server" Text="Submit" ValidationGroup="regreview" />
        
        <asp:ValidationSummary ID="vsum1" runat="server" ValidationGroup="regreview" 
            ShowMessageBox="true" ShowSummary="false" Height="136px" />
              </td>
         </tr>--%>
   </table>
    </div>
    </div>
    </b></b>
</asp:Content>

