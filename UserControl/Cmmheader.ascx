<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cmmheader.ascx.cs" Inherits="UserControl_Cmmheader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>||CMM||</title>
<link href="../css/style1.css" rel="stylesheet" />
<link href="../css/menustyle.css" rel="stylesheet" />

    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('.header a').filter(function () {
            return this.href == location.href.replace(/#.*/, "");
        }).addClass('active');
    });
</script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapperclass">
<div id="header">
<div class="logo">
<img src="../images/logo3cmm.png" style="height:100px; width:500px;" alt="CMM"/>
</div>



</div>

<hr style="border-bottom-color:#adb1b9" />







  </div>
    </form>
</body>
</html>
