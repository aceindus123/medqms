<%@ Page Title="" Language="C#" MasterPageFile="~/CMMmain.master" AutoEventWireup="true" CodeFile="CMS_Login.aspx.cs" Inherits="CMS_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<div >
  <div>Login to Quality System of XXXXXXX (Name)</div>

        <div><table >
        <tr>
        <td><asp:Label ID="lblid" runat="server" Text="UserName"></asp:Label></td>
        <td><strong >:</strong></td>
        <td><asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td>
        </tr>

          <tr>
        <td><asp:Label ID="lblpwd" runat="server" Text="Password"></asp:Label></td>
        <td><strong >:</strong></td>
        <td><asp:TextBox ID="txtpwd" runat="server"></asp:TextBox></td>
        </tr>

          <tr>
        <td><asp:Label ID="lblloc" runat="server" Text="GMT Location"></asp:Label></td>
        <td><strong >:</strong></td>
        <td><asp:TextBox ID="txtloc" runat="server"></asp:TextBox></td>
        </tr>

          <tr>
        <td colspan="3">
        <asp:Button ID="btnlogin" runat="server" Text="Login" />
        </td>
        </tr>

          <tr>
        <td colspan="3">
        <a href="#" >Forgot User ID /Password</a>
        </td>
        </tr>
        </table></div>

</div>
</asp:Content>

