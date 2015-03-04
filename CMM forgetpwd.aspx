<%@ Page Title="" Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true" CodeFile="CMM forgetpwd.aspx.cs" Inherits="CMM_forgetpwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="css/style1.css" rel="stylesheet" />
<link href="css/menustyle.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
<link rel="stylesheet" type="text/css" href="css/table.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table width="80%"  style="border:1px solid #7496c2"  border="0" > 
<tr><td colspan="2"><table  width="100%" align="center">
<tr><td align="left" class="content" >

<asp:Label ID="qaid" runat ="server" Text="Forget Password"></asp:Label>
</td>
</tr>

                   <tr><td><br /></td></tr>
                   <tr><td align="center">
                    <table align="center" width="60%"  style="background-color:#EFF8FB;border:1px solid #7496c2;border-radius:7px">
           
        <tr>
      
          <td align="center" valign="middle">
            <table border="0" style="margin-top:30px;margin-bottom:50px; border:1px  #039; " cellpadding="2" cellspacing="6">
       <tr>
            <td colspan="3" align="center"   style="border:1px; height:25px; font-weight:bold;font-size:small; color:#bc5441">
                That You&#39;re Having Trouble Signing In</td>
       </tr>
       <tr>
            <td colspan="3" align="center"> 
              <font color="000099">Please enter your Email Id.</font>
            </td>
        </tr>
      <tr>
           <td style="padding-top:0px;padding-right:5px" align="right" 
               ><b>
            <asp:Label ID="lblCountry" runat="server" Text="UserName" CssClass="lefttd"></asp:Label></b>
            </td>
             <td valign="top" style="padding-top:0px" width="3%" class="colontd"><strong>:</strong></td>
               <td style="padding-top:0px;padding-left:25px"  align="left" 
               > 
                <asp:TextBox ID="txtuname" runat="server"  Width="140px"  ></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter User Name"
                        ControlToValidate="txtuname" Display="Dynamic" ValidationGroup="fpass" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
          <td style="padding-top:0px;padding-right:5px" align="right" 
              class="lefttd" >
               <b>User Id</b></td>
          
          <td  style="padding-top:0px" width="3%"  class="colontd" ><strong>:</strong></td>
          <td style="padding-top:0px;padding-left:25px"  align="left" 
                >              
             <asp:TextBox ID="txtmail" runat="server" MaxLength="50" Width="230px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter EmailId"
                        ControlToValidate="txtmail" Display="Dynamic" ValidationGroup="fpass" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="Invalid EmailID" ValidationGroup="fpass" ForeColor="Red" ControlToValidate="txtmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><!--<input type="text" name="ELID" maxlength="40">--></td>
          </td>
        </tr>
        
        
        <tr>
        <td>
        </td>
        <td></td>
        <td align="left" style="padding-top:0px;padding-left:25px">
            Ex:<b>xxxx@xxxx.com</b>
        </td>
        </tr>
        <tr>
       
        
                <td colspan="3" align="center" bgcolor="f5f5f5">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
                </td>
            
        </tr>
        <tr>
            <td colspan="3" align="center">  <asp:Button ID="btnSubmit" CssClass="but" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="fpass"/>
                &nbsp;
                    <asp:Button ID="btnClose" CssClass="but" runat="server" Text="Close" 
                    onclick="btnClose_Click"  /></td>
        </tr>
        
    </table>
          
          </td>
        </tr>
        </table></td></tr>
        </table>
</asp:Content>

