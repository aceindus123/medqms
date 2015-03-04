<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CMS_leftmenu.ascx.cs" Inherits="Admin_UserControl_CMS_leftmenu" %>
<link rel="stylesheet" type="text/css" href="../css/menustyle.css" />


<table width="40%" border="1px">

<tr>  <td  align="left" runat="server" id="Td8" class="navleft" >

      
           Admin Control
 
   
   </td>
      </tr>
<tr>  <td  align="left" runat="server" id="home" >

             <a href="~/Admin/CMS_AdminHome.aspx" id="home1" runat="server" >Home</a>
           
 
   
   </td>
      </tr>

<tr>
<td  align="left" runat="server" id="Td1" class="color">
    

             <a href="#" id="A1" runat="server" >Initiator</a>
           
 
</td></tr>
<tr>
<td  align="left" runat="server" id="Td2" class="navleft">
    

             <a href="#" id="A2" runat="server" >Reviewer</a>
           
 
</td>
</tr>
<tr>
<td  align="left" runat="server" id="Td3" class="navleft">
    

             <a href="#" id="A3" runat="server" >Coordinator</a>
           
 
</td>
</tr>
<tr>
<td  align="left" runat="server" id="Td4" class="navleft">
    

             <a href="#" id="A4" runat="server" >CFT</a>
           
 
</td>
</tr>
<tr>
<td  align="left" runat="server" id="Td5" class="navleft">
    

             <a href="#" id="A5" runat="server" >RA/CG</a>
           
 
</td>
</tr>
<tr>
<td  align="left" runat="server" id="Td6" class="navleft">
    

             <a href="#" id="A6" runat="server" >Approver</a>
           
 
</td>
</tr>
<tr>
<td  align="left" runat="server" id="Td7" class="navleft">
    

             <asp:LinkButton ID="lnklogout" runat="server" Text="LogOut"></asp:LinkButton>
           
 
</td>
</tr>

</table>
