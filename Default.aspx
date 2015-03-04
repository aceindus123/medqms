<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>||CMS||</title>
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

    <style type="text/css">
        .style1
        {
            height: 42px;
        }
    </style>

    <script  type="text/javascript">
        function FilterInput(txt) {
            var name = document.getElementById("<%= txtuname1.ClientID %>").value;
            if (name.length == 0) {
                alert('Please Enter the userid');
                document.getElementById("<%=txtuname1.ClientID%>").focus();
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="loginbtn">
    <div id="wrapperclass">
<div id="header">
<div class="logo">
<img src="images/logocmm.jpg" style="height:110px; width:300px;" alt="cmm"/>
</div>

</div>


<div id="content">
  <div id="hpage">
  <!--<div id="hpage" style="background-image:url('images/login_banner1.jpg');background-repeat:repeat-x;height:500px;">-->
<br />
<table align="center">
 <tr><td align="center" colspan="2"><h2 style="font-weight:bold;color:#006699;width:500px">Login to Quality System<asp:Label ID="lblnn" runat="server" Text="Mr. Arun" ForeColor="#006699" Font-Bold="true" Visible="false"></asp:Label>  </h2></td>
    </tr>



    <tr><td colspan="2" align="center"><table width="100%" class="login" style="background-image:url(images/loginbg12.png);background-repeat:no-repeat;height:320px" >
 <tr><td style ="height:28px"></td></tr>
      <tr>

    <td  colspan="3" style="color:White;font-size:large;font-weight:bold;height:25px" align="center">Login Details
    
    </td>
    </tr>

     <tr>
    <td class="lefttd" style ="padding-top:20px" align="right"><asp:Label ID="lbluname" runat="server" Text="UserName" CssClass="loginfont"></asp:Label></td>
    <td class="colontd" style ="padding-top:20px"><strong>:</strong></td>
    <td class="tdalignright" style ="padding-top:20px"><asp:TextBox ID="txtuname1" runat="server" CssClass="loginright" Font-Names="Arial"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtuname1" ErrorMessage="Please Enter User Name" ValidationGroup="loginvalid">*</asp:RequiredFieldValidator>
   
    </td>
    </tr>

      <tr>
    <td class="lefttd" style="padding-top:4px" align="right"><asp:Label ID="lblpwd" runat="server" Text="Password" CssClass="loginfont"></asp:Label></td>
    <td style="padding-top:4px" class="colontd"><strong>:</strong></td>
    <td class="tdalignright" style="padding-top:4px"><asp:TextBox ID="txtpwd1" runat="server" TextMode="Password" CssClass="loginright" Font-Names="Arial"  onfocus="FilterInput (this)"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpwd1" ErrorMessage="Please Enter Password" ValidationGroup="loginvalid">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    
    <tr>
    <td class="lefttd" style="padding-top:4px" align="right"><asp:Label ID="Label4" runat="server" Text="GMT Location" CssClass="loginfont"></asp:Label></td>
    <td style="padding-top:4px" class="colontd"> <strong>:</strong></td>
    <td class="tdalignright" style="padding-top:4px">  
    <asp:DropDownList runat="server" ID="ddltimezone" CssClass="loginright" Font-Names="Arial" Width="300px" >
                 <asp:ListItem Text="Select a TimeZone" />     
               </asp:DropDownList>

               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="Select a TimeZone" ControlToValidate="ddltimezone" ErrorMessage="Please Select TimeZone" ValidationGroup="loginvalid">*</asp:RequiredFieldValidator>
   
                </td>
    </tr>
    
    <tr>
    <td colspan="3" align="center" 
            
            style="padding-top:10px; font-weight: bold; font-size: 14px; color: Black;" 
            >
        <asp:LinkButton ID="forgetpwd1" runat="server" CssClass="lnkcolor" OnClick="forgetpwd"><asp:Label ID="Label5" runat="server"
     Text="Forgot Password" CssClass="loginfont"></asp:Label></asp:LinkButton>
        </td>
            </tr>
        <tr>
            <td align="center" colspan="3" style="padding-top:0px" valign="top" >
                <asp:ImageButton ID="loginbtn" runat="server"  Text="Login" onclick="loginbtn_Click"  ImageUrl="images/login_button1.png" ValidationGroup="loginvalid" Width="70px"
                     />
            </td>
        </tr>

        <tr><td colspan="3"><asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="Please Fill All The Fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="loginvalid">
                    </asp:ValidationSummary></td></tr>
    
    </table></td></tr>

    </table>
<br />
<br />
<br />
<br />
<br />




</div>
</div>  
   </div>
    </form>
</body>
</html>

