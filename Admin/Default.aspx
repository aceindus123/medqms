<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
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
    <form id="form1" runat="server">
    <div id="wrapperclass">
        <div id="header">
            <%--<div class="logo" style ="vertical-align:middle;padding-left:38px">--%>
                <table width="100%" align="center">
                  <tr>
                         <td   align="left"  >
                            <img src="../Admin/images/logo3(1).png" style="height:150px; width:1174px;" alt="CMM" />
                         </td>
                  </tr>
                   <tr>
                         <td class="text1" style="float:right; padding-top:10px; padding-right:50px;" >
                         Date :&nbsp;&nbsp;  <asp:Label ID="lbldate" runat="server"  Font-Bold="true"  ></asp:Label><br />
                      <asp:Label ID="lblcount" runat="server"  Font-Size="15"  ForeColor="Green"></asp:Label>&nbsp;&nbsp; Users viewed this site
                     </td>
                  </tr>
                </table> 
<%--            </div>--%>

        </div>


        <div id="content">
        <div  width="100%">
          <table align="right">
           <tr>
             
           </tr>

            <tr>
             <td style="padding-right:30px" class="text1">
           </tr>
           
          </table>
        </div>
            <div height="600px">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                    <table width="40%" align="center">
                    <tr>
                     <td align="right">
                       
                     </td>
                    </tr>
                        <tr>
                             <td align="right" class="text1">
                                <asp:Label ID="Label3" runat="server" Text="User Type" ></asp:Label>
                            </td>
                            <td class="text2">
                            <strong>:</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddltype" runat="server" Width="205px"  AutoPostBack="true"
                                    onselectedindexchanged="ddltype_SelectedIndexChanged">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                                <asp:ListItem>Web Admin</asp:ListItem>
                                <asp:ListItem>Client</asp:ListItem>
                                <asp:ListItem>User</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="text1">
                                <asp:Label ID="Label1" runat="server" Text="User Id"></asp:Label>
                            </td>
                            <td class="text2">
                              <strong>:</strong>
                            </td>
                            <td>
                              <asp:TextBox ID="DropDownList1" runat="server" Width="200px">
                              </asp:TextBox>
                           </td>
                        </tr>

                        <tr>
                           <td align="right" class="text1">
                              <asp:Label ID="Label2" runat="server" Text="Password" ></asp:Label>
                           </td>
                            <td class="text2">
                               <strong>:</strong>
                           </td>
                           <td>
                              <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                           </td>
                        </tr>

                        <tr id="email" runat="server">
                          <td align="right" class="text1">
                             <asp:Label ID="lblemail" runat="server" Text="Email Id" ></asp:Label>
                          </td>
                          <td class="text2">
                            <strong>:</strong>
                          </td>
                          <td>
                            <asp:TextBox ID="txtemail" runat="server" Width="200px">
                            </asp:TextBox>
                          </td>
                        </tr>

                        <tr>
                             <td align="center" colspan="3">
                                  <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" CausesValidation="False"/>
                            </td>
                       </tr>
                        <tr class="text">
                             <td id="tdmsg"  align="right" runat="server">
           
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
      </div>
    </form>
</body>
</html>

