<%@ Control Language="C#" AutoEventWireup="true" CodeFile="searchusercontrol.ascx.cs" Inherits="UserControl_searchusercontrol" %>
<script type ="text/javascript">
    function valid() {

        var v1 = document.getElementById('<%=ddlid.ClientID %>').selectedIndex;
        var v2 = document.getElementById('<%=DropDownList5.ClientID %>').selectedIndex;

        var v3 = document.getElementById('<%=DropDownList6.ClientID %>').selectedIndex;
        var v4 = document.getElementById('<%=ddl4.ClientID %>').selectedIndex;

        var v5 = document.getElementById('<%=DropDownList7.ClientID %>').selectedIndex;
        var v6 = document.getElementById('<%=DropDownList13.ClientID %>').selectedIndex;

        var v7 = document.getElementById('<%=ddl1.ClientID %>').selectedIndex;

        if (v1 != 0 || v2 !== 0 || v3 != 0 || v4 != 0 || v5 != 0 || v6 != 0 || v7 != 0)
        { }
        else {
            alert("please select atleast one dropdown");
            return false;
        }
    }
    
    </script>
<link href="css/contentstyle.css" rel="stylesheet" />
<table>
                                  <tr>

<td align="right"  ><b>Select Change Id</b></td> <td class="colontd">
                        :</td>
                   
                           
                        <td align="left">
                    <asp:DropDownList runat="server" ID="ddlid" Height="20px" Width="190px" class="textborder" 
                                       
                        >
                                       <asp:ListItem>Select</asp:ListItem>
                
                    </asp:DropDownList>

                                                </td>
                                        
<td  class="lefttd" align="right" >
    <asp:Label ID="Label17" runat="server" width="120px"><b>CFT Type</b> </asp:Label>
</td>
<td  class="colontd">
:
</td>
<td  align="left" >
    <asp:DropDownList ID="DropDownList5" runat="server" Width="200px" Height="22px"
                        CssClass="textborder"
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem>Select One</asp:ListItem>
    <asp:ListItem>Approval</asp:ListItem>
     <asp:ListItem>Assignment</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
                                  
   <tr>
<td  class="lefttd" align="right" >
 <b> Type of Changes </b> 
</td>
<td class="colontd">:</td>
 <td style="text-align:left">
<asp:DropDownList runat="server" ID="ddl1" Width="200px" Height="22px"
                        CssClass="textborder">
                            <asp:ListItem Value="0">Select Changes</asp:ListItem>
                            <asp:ListItem>Pre Approval Change</asp:ListItem>
                            <asp:ListItem>Post Approval Change</asp:ListItem>
                            </asp:DropDownList>                            </td>
  <td  class="lefttd" align="right">
 <b> Change Classification </b> 
</td>
<td class="colontd">:</td>
<td style="text-align:left">
  <asp:DropDownList ID="DropDownList6" runat="server" Width="200px" Height="22px"
                        CssClass="textborder">
                                             <asp:ListItem Text = "Select Classification" Value = "0"></asp:ListItem> 
       <asp:ListItem Text = "Quality Impactinng" Value = "1"></asp:ListItem>                                      
    <asp:ListItem Text = "Quality non-Impacting" Value = "2"></asp:ListItem>
   
    </asp:DropDownList>                            </td>
    </tr>
                   <tr>
                       <td align="right" class="lefttd" style="padding-left:50px">
                           <b>Market </b>
                       </td>
                       <td class="colontd">
                           :</td>
                       <td style="text-align:left">
                           <asp:DropDownList ID="ddl4" runat="server" CssClass="textborder" Height="22px" 
                               Width="200px">
                               <asp:ListItem Value="0">Select Market</asp:ListItem>
                               <asp:ListItem Value="3">US</asp:ListItem>
                               <asp:ListItem Value="1">EU</asp:ListItem>
                               <asp:ListItem Value="2">WHO</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td align="right" class="lefttd">
                           <b>product impact </b>
                       </td>
                       <td class="colontd">
                           :</td>
                       <td style="text-align:left">
                           <asp:DropDownList ID="DropDownList7" runat="server" CssClass="textborder" 
                               Height="22px" onchange="Change(this)" Width="200px">
                               <asp:ListItem Text="No" Value="1">Select</asp:ListItem>
                               <asp:ListItem Text="No" Value="1"></asp:ListItem>
                               <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                           </asp:DropDownList>
                       </td>
     </tr>
     <tr>
         <td align="right" class="lefttd">
             <b>Regulator impact </b>
         </td>
         <td class="colontd">
             :</td>
         <td style="text-align:left">
             <asp:DropDownList ID="DropDownList13" runat="server" CssClass="textborder" 
                 Height="22px" onchange="second1(this)" Width="200px">
                 <asp:ListItem>Select</asp:ListItem>
                 <asp:ListItem Text="No" Value="1"></asp:ListItem>
                 <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
             </asp:DropDownList>
         </td>
         <td align="right" colspan="3">

       <asp:Button ID="Button2" runat="server" CssClass="buttonstyle" 
                                                Text="Search" onclick="Button2_Click" 
             OnClientClick="return valid();"/>
         </td>
     </tr>
                   

</table>
