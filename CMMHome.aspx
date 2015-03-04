<%@ Page Title="" Language="C#" MasterPageFile="cmmheader.master" AutoEventWireup="true" CodeFile="CMMHome.aspx.cs" Inherits="CMMHome" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="UserControl/topusercontrol.ascx" TagName="top" TagPrefix="c1" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="UserControl/logoutmenu.ascx" TagName="logout" TagPrefix="log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
    <link rel="stylesheet" type="text/css" href="css/table.css" />
      <script type="text/javascript">

          $(document).ready(function () {
              $("#Button2").click(function () {
                  var v1 = $("#ddlsearch").get(0).selectedIndex;
                  var v2 = $("#DropDownList7").get(0).selectedIndex;
                  var v3 = $("#DropDownList8").get(0).selectedIndex;
                  var v4 = $("#DropDownList12").get(0).selectedIndex;
                  var v5 = $("#DropDownList14").get(0).selectedIndex;
                  var v6 = $("#DropDownList15").get(0).selectedIndex;
                  var v7 = $("#DropDownList16").get(0).selectedIndex;
                  if ((v1 == 0) && (v2 == 0) && (v3 == 0) && (v4 == 0) && (v5 == 0) && (v6 == 0) && (v7 == 0)) {
                      alert('please select at least one dropdown');
                      return false;
                  }
              });
          });
    </script>


    <script type ="text/javascript">
        function valid() {

            var v1 = document.getElementById('<%=ddlsearch.ClientID %>').selectedIndex;
            var v2 = document.getElementById('<%=DropDownList7.ClientID %>').selectedIndex;

            var v3 = document.getElementById('<%=DropDownList8.ClientID %>').selectedIndex;
            var v4 = document.getElementById('<%=DropDownList12.ClientID %>').selectedIndex;

            var v5 = document.getElementById('<%=DropDownList14.ClientID %>').selectedIndex;
            var v6 = document.getElementById('<%=DropDownList15.ClientID %>').selectedIndex;

            var v7 = document.getElementById('<%=DropDownList16.ClientID %>').selectedIndex;

            if (v1 != 0 || v2 !== 0 || v3 != 0 || v4 != 0 || v5 != 0 || v6 != 0 || v7 != 0)
            { }
            else {
                alert("please select atleast one dropdown");
                return false;
            }


        }
    
    </script>
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
       function CheckCheck() {
           var chkBoxList = document.getElementById('<%=gvinitiate.ClientID %>');
           var chkBoxCount = chkBoxList.getElementsByTagName("input");

           var btn = document.getElementById('<%=belowcontent.ClientID %>');
           var i = 0;
           var tot = 0;
           for (i = 0; i < chkBoxCount.length; i++) {
               if (chkBoxCount[i].checked) {
                   tot = tot + 1;
               }
           }

           if (tot > 1) {
               alert('Cannot check more than 1 check box');
           }
       }

    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-bottom:4px;">
   
      
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        

        <table width="100%" style="vertical-align:top">
        
                         <tr>
<td align="left" class="tdinitleft" style="padding-left:10px"><asp:LinkButton ID="LinkButton5" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="17px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<asp:Label ID="Label2" runat="server" Text="Date" CssClass="boldblack" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:10px" class="lefttd"><asp:Label ID="Label4" runat="server" Text="UserName" CssClass="boldblack"  Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" CssClass="initlblsleftrt"></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:70px">
<asp:Label ID="Label6" runat="server" Text="Time" Font-Bold="true" CssClass="boldblack"></asp:Label>&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>
        
        </table>
         
                 <%--   <table id="table2" border="0" style="border:1px solid #7496c2" width="80%">--%>
                  
                       <table id="table2" border="0"  width="100%">
                    
                    <tr><td colspan="3" class="content" align="left" width="100%">
                    <table width="100%">
                    <tr>
                    <td align="left">
                    Change Management
                    </td><td align="right" style="padding-right:50px">
                    <asp:LinkButton ID="lnkhome" runat ="server" Text="Back" Font-Size="14px" Font-Bold="true"
                                onclick="lnkhome_Click" ></asp:LinkButton>
                    </td>
                    </tr>
                    </table>
                    
                    
                    </td></tr>
                   
                         
                      



<tr><td colspan="2" class="tdinitleft" style="padding-left:10px" align="left">

<table align="left" >
<tr><td align="left">

<asp:LinkButton ID="linkassign" runat="server"  
        CssClass="lnkcolor" onclick="linkassign_Click">
 <asp:Label ID="lblassign" runat="server" Text ="My Changes"></asp:Label></asp:LinkButton> 
 <asp:Label ID="lblcomma" runat="server" Text="/" CssClass="lnkcolor"></asp:Label>

<asp:LinkButton ID="lnkact" runat="server"  CssClass="lnkcolor" 
        onclick="lnkact_Click">
 <asp:Label ID="lblitems" runat="server" Text="My Action Items"></asp:Label></asp:LinkButton>

 </td></tr>

<tr runat="server" visible="false" id="initnew"><td align="left"><asp:LinkButton ID="lnknew" runat="server" CssClass="lnkcolor" 
        onclick="lnknew_Click"> <asp:Label ID="lblinitiate" runat="server" Text="Initiate New CC" ></asp:Label></asp:LinkButton></td></tr>
</table>
</td></tr>
<tr runat="server" visible="false"><td colspan="3" ><hr class="searchline"/></td></tr>
<tr runat="server" id="trsearch" >

<td  align="left" colspan="3" style="padding-left:20px;width:100%"><table  align="left" width="100%">

                                             
<tr runat="server" id="tbl2" >

  <td colspan="2" align="center" style="width:100%">


  <table width="100%">
  <tr>
  <td align="left">
   <asp:Panel ID="pnclick" runat="server" align="left" width="40px">
   <table width="40px" >
  <tr>
  <td>
<asp:Image ID="imgplusmin" runat="server"/></td><td>
<asp:Label ID="lblsearch" runat="server" Text="Search" CssClass="lnkcolor"/></td></tr></table>
</asp:Panel>
  </td>
  </tr>
<tr>
<td align="left" style="width:100%">
<asp:Panel ID="pnSearch" runat="server" Width="100%" >

<table >
                                  <tr>

<td align="right"  ><b>Select Change ID</b></td> <td class="colontd">
                        :</td>
                   
                           
                        <td align="left">
                    <asp:DropDownList runat="server" ID="ddlsearch" Height="20px" 
                                class="searchdropdown" 
                                       
                        >
                                      
                
                    </asp:DropDownList>

                                                </td>
                                        
<td  class="lefttd" align="right" >
    <asp:Label ID="Label17" runat="server" width="250px"><b>Initiator Type</b> </asp:Label>
</td>
<td  class="colontd">
:
</td>
<td  align="left" style="width:280px">
    <asp:DropDownList ID="DropDownList7" runat="server"  Height="22px"
                        CssClass="searchdropdown"
       >
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
<asp:DropDownList runat="server" ID="DropDownList8" Height="22px"
                        CssClass="searchdropdown">
                            <asp:ListItem Value="0">Select Changes</asp:ListItem>
                            <asp:ListItem>Pre Approval Change</asp:ListItem>
                            <asp:ListItem>Post Approval Change</asp:ListItem>
                            </asp:DropDownList>                            </td>
  <td  class="lefttd" align="right">
 <b> Change Classification </b> 
</td>
<td class="colontd">:</td>
<td style="text-align:left">
  <asp:DropDownList ID="DropDownList12" runat="server"  Height="22px"
                        CssClass="searchdropdown">
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
                           <asp:DropDownList ID="DropDownList14" runat="server" CssClass="searchdropdown" Height="22px" 
                               >
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
                           <asp:DropDownList ID="DropDownList15" runat="server" CssClass="searchdropdown" 
                               Height="22px" onchange="Change(this)" >
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
             <asp:DropDownList ID="DropDownList16" runat="server" CssClass="searchdropdown" 
                 Height="22px" onchange="second1(this)" >
                 <asp:ListItem>Select</asp:ListItem>
                 <asp:ListItem Text="No" Value="1"></asp:ListItem>
                 <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
             </asp:DropDownList>
         </td>
         <td align="right" colspan="3" style="padding-right:0px" >
         <asp:Button ID="btnsearch" runat="server" Text="Search" onclick="search_Click" />

       <%--<asp:Button ID="Button2" runat="server" CssClass="buttonstyle" 
                                                Text="Search" onclick="Button2_Click" 
            />--%>
         </td>
     </tr>
                   

</table>

</asp:Panel>

    <ajax:collapsiblepanelextender ID="CollapsiblePanelExtender1" runat="server"  
        CollapseControlID="pnclick" Collapsed="true"
ExpandControlID="pnclick" TextLabelID="lblsearch"

ImageControlID="imgplusmin"
CollapsedImage="images/plus1.png"
ExpandedImage="images/minus1.png"
ExpandDirection="Vertical"
TargetControlID="pnSearch"
ScrollContents="false">
    </ajax:collapsiblepanelextender>
</td>
</tr>  </table>
                  
                  	
			
</td>
  </tr>
                                                
                                                </table></td>
                                                </tr>
                                                   <tr runat="server" visible="false"><td colspan="3"><hr class="searchline"/></td></tr>
<tr runat="server" visible="false"><td align="center" valign="top" colspan="2"><asp:Label ID="Label8" runat="server" Text="CHANGE MANAGEMENT" CssClass="bdyconthead"></asp:Label></td></tr>
<tr id="trassign" runat="server"><td colspan="2" align="center">

<%--<asp:GridView ID="gvinitiate" runat="server" AutoGenerateColumns="False"  
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" BorderColor="#7496c2"
        PageSize="3" AllowPaging="true"  DataKeyNames="changeid" CssClass="gridborder"
       OnPageIndexChanging="gvinitiate_pageindexchanging" OnRowDataBound="gvinitiate_RowEditing" >--%>
       <asp:GridView ID="gvinitiate" runat="server" AutoGenerateColumns="False"  
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" 
        PageSize="3" AllowPaging="true"  DataKeyNames="changeid" 
       OnPageIndexChanging="gvinitiate_pageindexchanging" OnRowDataBound="gvinitiate_RowEditing" >
    <RowStyle Height="20px" Font-Size="10px"/>
    <HeaderStyle CssClass="gridhead" BackColor="#8db2e3"/>
<AlternatingRowStyle BackColor="#e3e3e3" />

<Columns>

<asp:TemplateField >
<ItemStyle HorizontalAlign="Left" Width="3%" />
<ItemTemplate >
<asp:CheckBox runat="server" ID="chkassign" onclick="javascript:CheckCheck();"  ></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="CC No."  HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="5%" />
<ItemTemplate >
<!--<asp:Label ID="lblccno" runat="server" 
                Text='<# Eval("ccno") %>'  />-->
               <asp:LinkButton ID="lnkid" runat="server" OnClick="clickid" CommandArgument='<%#Eval("Changeid") %>'>
                <asp:Label ID="lblchangeid" runat="server" CssClass="gridlink"
                Text='<%# Eval("Changeid") %>' ></asp:Label></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Init By" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="5%" />
<ItemTemplate >

                 <asp:Label ID="lblinitby" runat="server" CssClass="gridbody"
                Text='<%# Eval("initby") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Change Description" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="10%" />
<ItemTemplate >
<!--  <asp:Label ID="lbldesc" runat="server" 
                Text='<# Eval("cdesc") %>' />-->
                 <asp:Label ID="lblcdesc" runat="server" CssClass="gridbody"
                Text='<%# Eval("CDesc") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Change Period" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="5%" />
<ItemTemplate>

                <asp:Label ID="lblcperiod" runat="server" CssClass="gridbody"
                Text='<%# Eval("changeperiod") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Change Classification" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="10%" />
<ItemTemplate>
  <asp:Label ID="lblclassification" runat="server" CssClass="gridbody"
                Text='<%# Eval("cclassification") %>' />
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Department" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="3%" />
<ItemTemplate>

                   <asp:Label ID="lblcdept" runat="server" CssClass="gridbody"
                Text='<%# Eval("Dept") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="8%" />
<ItemTemplate>

                   <asp:Label ID="lblcpname" runat="server" CssClass="gridbody"
                Text='<%# Eval("productname") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Market" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="4%" />
<ItemTemplate>

                   <asp:Label ID="lblcmarket" runat="server" CssClass="gridbody"
                Text='<%# Eval("Market") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Customer" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="4%" />
<ItemTemplate>

                   <asp:Label ID="lblccustomer" runat="server" CssClass="gridbody"
                Text='<%# Eval("Customer") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Assigned To" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="5%" />
<ItemTemplate>


                  <asp:Label ID="lblsubmit" runat="server" CssClass="gridbody"
                Text='<%# Eval("submit") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Due Date" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="5%" />
<ItemTemplate>
 
                <%# Convert.ToDateTime(Eval("initdate")).ToString("d")%>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left">
<ItemStyle HorizontalAlign="Left" Width="5%" />
<ItemTemplate>
  <!--<asp:Label ID="lblstatus" runat="server" 
                Text='<# Eval("status") %>' />-->
                 <asp:Label ID="lblcstatus" runat="server" CssClass="gridbody"
                Text='<%# Eval("Curstatus") %>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>


</Columns>
   
    <FooterStyle BackColor="Black" />
    <PagerStyle HorizontalAlign="Right"  CssClass="gridhead" Font-Bold="true" Font-Size="12px" BackColor="White" ForeColor="Black"/>
  
</asp:GridView>							
										

</td></tr>
<tr><td colspan="4" width="100%" align="center" valign="top" >
  <asp:RadioButtonList ID="belowcontent" runat="server" RepeatColumns="6" 
                          RepeatDirection="Horizontal"  CssClass="rbtninit" Width="90%" 
                          onselectedindexchanged="belowcontent_SelectedIndexChanged"  AutoPostBack="true">
                  <asp:ListItem  Value="Audit Trial"  >Audit Trial</asp:ListItem>
                  <asp:ListItem Value="E-mail Notification">E-mail Notification</asp:ListItem>
                  <asp:ListItem Value="Re-assign">Re-assign</asp:ListItem>
                  <asp:ListItem Value="CC Report">CC Report</asp:ListItem>
                  <asp:ListItem Value="Run Report">Run Report</asp:ListItem>
                  <asp:ListItem Value="Dashboards">Dashboards</asp:ListItem>
                  </asp:RadioButtonList>
                  </td></tr>
   <tr id="norec" runat="server" visible="false"><td colspan="4" align="center" ><asp:Label ID="norecords" runat="server" ForeColor="#26614D" Font-Bold="true" Font-Size="14px"></asp:Label></td></tr>
                                                  
                  
                   
                    <tr>
                    <td colspan="5" align="right" class="style1">
                   
                       
                    </td>
                    </tr>
                   
               
                    <asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="Please Fill All The Fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="init">
                    </asp:ValidationSummary>
                     
                    </table>
            
         
          
            
            
            
        
        
            
            
            
            
            
            
            
            
            
            
            
         
            
            
            
            
          
            
         
       
    </div>
</asp:Content>




