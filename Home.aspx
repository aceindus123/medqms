<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/Cmmheader.ascx" TagName="top" TagPrefix="c1" %>
<%@ Register Src="UserControl/logoutmenu.ascx" TagName="logout" TagPrefix="log" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>||CMM||</title>
<link href="css/style1.css" rel="stylesheet" />
<link href="css/menustyle.css" rel="stylesheet" />
 <link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
    <link rel="stylesheet" type="text/css" href="css/table.css" />
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('.header a').filter(function () {
            return this.href == location.href.replace(/#.*/, "");
        }).addClass('active');
    });
</script>

<script type="text/javascript">
    function linktarget() {
        window.document.forms[0].target = '_blank';
    
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
  
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapperclass">
<div id="header">
<div class="logo">
<img src="images/logocmm.jpg" style="height:110px; width:300px;" />

</div>

</div>

<div id="nav" style="vertical-align:top" runat="server" visible="false">
      
      <table class="menuspace" style="vertical-align:top">
      <tr>
      
          <td width="8%" align="center" runat="server" id="home">
     <li style="list-style:none;" class="header">
<%--  <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click"  
            >Home</asp:LinkButton>--%>
             <a href="Home.aspx" id="home1" runat="server" >Home</a>
           
 
   </li>
   </td>
      
    
       <td width="8%" align="center" runat="server" id="ini">
     <li style="list-style:none;" class="header">
<%--  <asp:LinkButton ID="lnkbtnHome" runat="server"  onclick="lnkbtnHome_Click1" 
            >Initiator</asp:LinkButton>--%>
             <a href="CMS_Initiator.aspx" id="initiator1" runat="server" >Initiator</a>
           
 
   </li>
   </td>
      
      <td width="8%" align="center" runat="server" id="rev">
      <li style="list-style:none;" class="header">
   <%-- <asp:LinkButton ID="lnkCls" runat="server"  
              onclick="lnkCls_Click">Reviewer</asp:LinkButton>--%>
               <a href="CMS_ChangeOwner.aspx" id="reviewer1" runat="server" >Reviewer</a>
            

</li>
      </td>
    
      
       <td align="center" width="6%" runat="server" id="cor">
       
     <%-- <li style="padding-left:0px;margin-left:6px;list-style-type:none"><a href="news.aspx" >Coordinator</a></li>--%>
     <li style="list-style:none;" class="header">
      <%-- <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"  
             >Coordinator</asp:LinkButton>--%>
              <a href="QAReg1.aspx"  id="coordinator1" runat="server">Coordinator</a>
           
              </li>

    
      </td>
   
      <td width="8%" align="center" runat="server" id="cet">
      
      <li style="padding-left:0px;padding-left:0px;list-style-type:none" class="header">
      <%--<a href="Default.aspx" title="Forums">CFT</a>--%>
    <%--  <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click"  
             >CFT</asp:LinkButton>--%>
              <a href="CMS_Final QA.aspx" id="cft1" runat="server" >CFT</a>
            
      
      </li>
     </td>
   
      <td width="8%" align="center" runat="server" id="ra">
       <li style="padding-left:0px;padding-left:0px;list-style-type:none" class="header">
    <%-- <asp:LinkButton ID="lnkYP" runat="server" onclick="lnkYP_Click">RA/CG</asp:LinkButton>--%>
     <a href="CMS_racg.aspx" id="racg1" runat="server" >RA/CG</a>
  
</li>
      </td>
     
       <td width="8%" align="center" runat="server" id="app">
      <li style="padding-left:0px; padding-left:0px;list-style-type:none" class="header">
      <%--<a href="travelhome.aspx" >Approver</a>--%>
    <%--  <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Approver</asp:LinkButton>--%>
     <a href="CMS_Cab Review.aspx" id="approver1" runat="server" >Approver</a>
    

</li>
      </td>
 
      </tr>
      </table>


</ul>
</div>


<div id="content">
<div style="padding-top:0px;padding-bottom:25px" align="center">

<log:logout runat="server"></log:logout>

<table border="0"  width="100%" >

<tr><td><table width="100%">
<tr>
<td  align="left" style="padding-left:150px">

<table width="100%" >
<tr><td><br /></td></tr>
<tr><td >
<asp:LinkButton ID="lnkinbox" runat="server" Text="1. Inbox" CssClass="lnkcolor" onclick="clickinbox" OnClientClick="return linktarget();"></asp:LinkButton>

</td></tr>
<tr><td><br /></td></tr>
<tr><td style="margin-bottom:10px">


<asp:LinkButton ID="lnkqnficaion" runat="server" Text="2. Quality Notifications" OnClick="clicknotify" OnClientClick="return linktarget();" CssClass="lnkcolor" ></asp:LinkButton>
</td></tr>
<tr><td><br /></td></tr>
<tr><td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkcmm" runat="server" Text="2.1 Change Management"  CssClass="lnkcolor" OnClick="clickchangemgt" ></asp:LinkButton>
</td></tr>
<tr><td><br /></td></tr>
<tr><td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Text="2.2 Complaints" OnClick="clickcomplaints" OnClientClick="return linktarget();" CssClass="lnkcolor" ></asp:LinkButton>
</td></tr>
<tr><td><br /></td></tr>
<tr><td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" Text="2.3 Annual Product Review" OnClick="clickannualrev" OnClientClick="return linktarget();" CssClass="lnkcolor" ></asp:LinkButton>
</td></tr>
<tr><td><br /></td></tr>
<tr><td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" Text="2.4 CAPA" OnClick="clickcapa" OnClientClick="return linktarget();" CssClass="lnkcolor" ></asp:LinkButton>
</td></tr>
<tr><td><br /></td></tr>

</table>
</td>



<td style="padding-right:30px;height:150px" align="center" ><table width="60%" align="center"><tr>
<td align="center" style="border:solid 1px #7496c2;text-align:left"  >

<table width="100%">
<tr><td><br /></td></tr>
<tr><td >
<asp:Label ID="Label1" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Medium">1.</asp:Label>&nbsp;&nbsp;<asp:Label ID="lnkstatus" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Medium"></asp:Label>
</td></tr> 
<tr><td><br /></td></tr>
<%-- <tr><td style="padding-left:20px;padding-bottom:10px"><asp:Label ID="lnkstatus" runat="server" ForeColor="Black" Font-Size="Small"></asp:Label></td></tr>
--%>
<tr><td>

<asp:LinkButton ID="LinkButton4" runat="server" Text="2. SOP" OnClick="sopclick" OnClientClick="return linktarget();" CssClass="lnkcolor" ></asp:LinkButton>
</td></tr>
<tr><td><br /></td></tr>
<tr><td>
<asp:LinkButton ID="LinkButton5" runat="server" Text="3. Flow Chart" OnClick="cmmfchart" OnClientClick="return linktarget();" CssClass="lnkcolor" ></asp:LinkButton>
</td></tr>
<tr><td><br /></td></tr>
<tr><td>
<asp:LinkButton ID="LinkButton6" runat="server" Text="4. Change Password" OnClick="chpwdcmmclick"  CssClass="lnkcolor" ></asp:LinkButton>
</td></tr>

<tr runat="server" visible="false"><td>
<asp:LinkButton ID="LinkButton7" runat="server" Text="5. Settings" OnClick="cmmsettings" OnClientClick="return linktarget();" CssClass="lnkcolor" ></asp:LinkButton>
</td></tr>
<tr><td><br /></td></tr>
</table>
</td>
</tr></table></td>
</tr>
</table></td></tr>
</table>


<div>

</div>
</div>
</div>

    </form>
</body>
</html>
