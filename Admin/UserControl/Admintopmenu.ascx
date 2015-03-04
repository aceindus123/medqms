<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admintopmenu.ascx.cs" Inherits="Admin_UserControl_Admintopmenu" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">

    <tr >
       <td align="left" colspan="2">
             <img src="../Admin/images/logo3(1).png" style="height:150px; width:1180px;" alt="CMM" />
        </td>
    </tr>

     <tr >
        <td align="right" style="padding-right:30px;line-height:35px;" class="text2" valign="bottom" colspan="2">
              Date :&nbsp;&nbsp;  <asp:Label ID="lbldate" runat="server"  Font-Bold="true"  ></asp:Label></td>
     </tr>

     <tr runat="server"  style="background-color: #F8ECE0; " >
         <td style="padding-left:30px" align="left" class="text2" >
             <asp:Label ID="Label1" runat="server" Font-Bold="true" Text=" User :"></asp:Label> <asp:Label ID="lbluser" runat="server" Font-Bold="true"></asp:Label>
         </td>
         <td align="right" style="padding-right:60px;color:#023989;font-family:Arial, Helvetica, sans-serif;font-weight :bold;"  >
             <asp:LinkButton ID="lbllogout" runat="server" Text="Logout"  Font-Size="15" Font-Bold="true" Font-Underline="false" ForeColor="#023989" PostBackUrl="~/new/Admin/Default.aspx"></asp:LinkButton>
         </td>
     </tr>

</table>
