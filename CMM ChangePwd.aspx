<%@ Page Title="" Language="C#" MasterPageFile="cmmheader.master" AutoEventWireup="true" CodeFile="CMM ChangePwd.aspx.cs" Inherits="CMM_ChangePwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/style1.css" rel="stylesheet" />
<link href="css/menustyle.css" rel="stylesheet" />
 <link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
    <link rel="stylesheet" type="text/css" href="css/table.css" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="content">
<div style="padding-top:0px;padding-bottom:25px" align="center">

<table width="80%" style="vertical-align:top" align="center">
<tr>
<td align="left" class="tdinitleft" style="padding-left:50px"><asp:LinkButton ID="lnklogout" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>
<td align="right" class="lefttd" style="padding-right:50px">
<b><asp:Label ID="lbldateid" runat="server" Text="Date"  Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
</td>
</tr>

<tr>
<td align="left"  style="padding-left:50px" class="lefttd"><b><asp:Label ID="lblname" runat="server" Text="UserName"  Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbluname" runat="server" ></asp:Label>
</td>

<td  align="right" class="lefttd" style="padding-right:72px">
<b><asp:Label ID="lbltimeid" runat="server" Text="Time" Font-Bold="true"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;<strong >:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>
</td>
</tr>
</table>

 <table id="table2" border="0" style="border:1px solid #7496c2" width="80%">
                      
                    <tr><td colspan="3" class="content" align="left" width="100%">
                    <table width="100%">
                    <tr>
                    <td align="left">
                  Change Password
                    </td><td align="right" style="padding-right:30px">
                    <asp:LinkButton ID="lnkhome" runat ="server" Text="Back" CssClass="lnkcolor"
                                onclick="lnkhome_Click" ></asp:LinkButton>
                    </td>
                    </tr>
                    </table>
                    
                    
                    </td></tr>
                     <tr><td><br /></td></tr>
                    <tr><td colspan="3" align="center">
                    <table style="background-color:#e3e3e3;border:solid 1px #7496c2" width="70%" >
                   
                    <tr><td align="center">
                     <img src="images/changepassword.jpg" alt="Change Password" />
                    </td>
                    <td> <table >
                     <tr><td><br /></td></tr>
                    <tr>
                    <td class="lefttd" align="right"><asp:Label ID="lblusname" runat="server" Text="User Id" Font-Bold="true" ></asp:Label></td>
                    <td class="colontd"><strong>:</strong></td>
                    <td align="left"><asp:Label ID="lblusername" runat="server"></asp:Label></td>
                    </tr>
                      <tr>
                    <td class="lefttd" align="right"><asp:Label ID="Label1" runat="server" Text="Old Password" Font-Bold="true" ></asp:Label></td>
                    <td class="colontd"><strong>:</strong></td>
                    <td  align="left"><asp:TextBox ID="txtoldpwd" runat="server" CssClass="textborder" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rdold" runat="server" ControlToValidate="txtoldpwd" ErrorMessage="Please Enter Old Password" ValidationGroup="chpwd">*</asp:RequiredFieldValidator>
                    </td>
                    </tr>
                     <tr>
                    <td class="lefttd" align="right"><asp:Label ID="Label2" runat="server" Text="New Password" Font-Bold="true" ></asp:Label></td>
                    <td class="colontd"><strong>:</strong></td>
                    <td  align="left"><asp:TextBox ID="txtnewpwd" runat="server"  CssClass="textborder" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewpwd" ErrorMessage="Please Enter New Password" ValidationGroup="chpwd">*</asp:RequiredFieldValidator>
                   
                    </td>
                    </tr>
                      <tr>
                    <td class="lefttd" align="right"><asp:Label ID="Label3" runat="server" Text="Confirm Password" Font-Bold="true" ></asp:Label></td>
                    <td class="colontd"><strong>:</strong></td>
                    <td  align="left"><asp:TextBox ID="txtcfpwd" runat="server"  CssClass="textborder" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcfpwd" ErrorMessage="Please Enter Confirm Password" ValidationGroup="chpwd">*</asp:RequiredFieldValidator>
                   
                    </td>
                    </tr>
                      <tr>
                    <td class="lefttd" align="right"><asp:Label ID="Label4" runat="server" Text="Email Id" Font-Bold="true" ></asp:Label></td>
                    <td class="colontd"><strong>:</strong></td>
                    <td align="left"><asp:TextBox ID="txtemailid" runat="server"  CssClass="textborder" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemailid" ErrorMessage="Please Enter Valid Email Id" ValidationGroup="chpwd">*</asp:RequiredFieldValidator>
                   
                    </td>
                    </tr>
                    <tr><td colspan="3"></td></tr>
                       <tr>
                   <td colspan="3" align="center">
                   <asp:Button ID="chpwd" runat="server" CssClass="buttonstyle" Text="ChangePwd" onclick="chpwd_Click"  ValidationGroup="chpwd" Width="100px"/>
                   &nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="buttonstyle" Width="70px"/>
                   </td>
                    </tr>
                    <tr><td colspan="3"></td></tr>
                    </table>
                    </td>
                    </tr>
                   
                    </table>
                   
                    </td></tr>
                     <tr><td><br /></td></tr>
</table>

</div>
</div>
</asp:Content>

