<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CMS_AdminHome.aspx.cs" Inherits="Admin_CMS_AdminHome" %>
<%@ Register Src="UserControl/CMS_leftmenu.ascx" TagName="top" TagPrefix="c1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<link href="css/style1.css" rel="stylesheet" />
<link href="css/menustyle.css" rel="stylesheet" />

    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>

    <title>CMM - Admin Control Panel</title>
    <script language="javascript" type="text/javascript">
        function alertsubmit() {
            alert("Please enter correct Username or Password!");
        }
    </script>
</head>
<body>
    <form id="form2" runat="server">
    <div id="wrapperclass">
<div id="header">
<div class="logo" style ="vertical-align:middle;padding-left:38px">
<img src="images/logo3.png" style="height:110px; width:1100px;" alt="CMM"/>
</div>

</div>



<div id="content">
<div height="600px">
<br />
<br />



<table width="100%" align="center">

<tr><td width="40%" align="left">
<c1:top ID="leftmenu" runat="server" />
</td>


                        <td valign="top" align="right" style="color:Green; font-family:Monotype Corsiva; font-size:large; font-weight:bold;padding-right:50px">
                         <asp:Label ID="Label1" runat="server" Text="Login Ip  :  "></asp:Label>
                        <asp:Label ID="ipid" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblcount" runat="server" ></asp:Label>&nbsp;&nbsp; Users viewed this site .
                        
</td>
</tr>
</table>

   

<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
</div>
</div>  
    </form>
</body>
</html>


