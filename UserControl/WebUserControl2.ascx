<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl2.ascx.cs"
    Inherits="WebUserControl2" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<link rel="stylesheet" type="text/css" href="../css/contentstyle.css" />
<div id="pp">
    <asp:Panel ID="Panel1" runat="server" Style="border: 1px solid #8B8A8A;">
        <table id="tbl1" style="background-color: #EBE9F6; width: 100%; " runat="server">
            <tr>
                <td colspan="3" style="background-color: #569cfc; width: 169px;font-family:Arial" align="left" height="27px">
                    <asp:Label ID="Label1" runat="server" Text="Action Item(s)" Font-Size="16px" Font-Bold="true" ForeColor="white" ></asp:Label>
                </td>
                <%-- <td  colspan="1" style=" background-color:Black; padding-right:8px;" align="right">
                <asp:Button ID="btnClose" runat="server" Text="X"  />
            </td>
            --%>
            </tr>
            <tr>
                <td valign="top" colspan="3" style="padding-left: 15px; height: 55px; width: 169px;">
                  <b> <asp:Label ID="lblCreateActnItems" runat="server" Text="Create Action Items"  ></asp:Label></b> 
                    <br />
                    <asp:DropDownList ID="ddlCreateActionItems" runat="server" Height="20px" CssClass="textborder"
                         Width="82px">
                        <asp:ListItem>yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
           <%-- <tr>
                <td valign="top" style="border-top: 1px solid #8B8A8A; padding-left: 15px; width: 169px;">
                    <asp:LinkButton ID="lbAddRow" runat="server" style="color:#023989" Font-Underline="true" OnClick="lbAddRow_Click">AddRow</asp:LinkButton>
                </td>
                <td valign="top" style="border-top: 1px solid #8B8A8A; padding-left: 15px; width: 401px;">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbDelLastRow" runat="server" style="color:#023989">Delete Last Row</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblTotalRows" runat="server" style="color:#023989" Text="Total Rows :"></asp:Label>
                    &nbsp;<asp:Label ID="lblTRows" runat="server" Text="1"></asp:Label>
                </td>
                <td valign="top" style="border-top: 1px solid #8B8A8A; padding-left: 15px; padding-top: 5px;
                    background-color: #EBE9F6; padding-right: 5px">
                    <asp:Label ID="lblPages" runat="server" style="color:#023989" Text="Pages :"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLeft" runat="server" Height="20px" Text="&lt;-" Width="25px" />
                    &nbsp;
                    <asp:Label ID="lblPage" runat="server" style="color:#023989" Text="1"></asp:Label>
                    &nbsp;
                    <asp:Button ID="btnRight" runat="server" Height="20px" Text="-&gt;" Width="25px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFullLeft" runat="server" Height="23px" Text="&lt;&lt;" Width="28px" />
                    &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPages1" runat="server" Height="16px" style=" border:2px solid #A8C1DF" Width="49px"></asp:TextBox>
                    &nbsp; &nbsp;
                    <asp:Button ID="btnRight1" runat="server" Height="23px" Text="&gt;" Width="28px" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLeft1" runat="server" Height="23px" Text="&lt;" Width="28px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFullRight" runat="server" Height="23px" Text="&gt;&gt;" Width="28px" />
                </td>
            </tr>--%>
        </table>
        <table style="background-color: #EBE9F6; width: 100%;">
            <tr>
               <%-- <td valign="top" style="border-top: 1px solid #8B8A8A; padding-left: 15px; width: 187px;
                    height: 47px;">
                    <asp:CheckBox ID="cbDelete" runat="server" style="color:#023989" Text="Delete" />
                </td>--%>
                <td valign="top" style="border: 1px solid #8B8A8A; padding-left: 15px; height: 47px;
                    ">
                    <b><asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label></b>
                    <br />
                    <asp:Label ID="lblActNo" runat="server" CssClass="c10" Text="1"></asp:Label>
                </td>
                <td valign="top" style="border: 1px solid #8B8A8A; padding-left: 15px; padding-bottom: 5px;
                    height: 47px;">
                 <b>  <asp:Label ID="lblActnItmDes" runat="server"  Text="Action Item Description"></asp:Label></b> 
                    <br />
                    <asp:TextBox ID="txtActItmDes" runat="server" Height="45px" TextMode="MultiLine" CssClass="textborder"
                        Width="300px"></asp:TextBox>
                    <ajax:TextBoxWatermarkExtender ID="tbwmChngOwnrComments"  runat="server"  TargetControlID="txtActItmDes"
                        WatermarkText="Please Write Action Item Description" >
                    </ajax:TextBoxWatermarkExtender>
                </td>
            </tr>
            <tr>
                
                <td style="border-bottom: 1px solid #8B8A8A; border-left: 1px solid #8B8A8A; width: 187px;
                    border-right: 1px solid #8B8A8A; padding-left: 15px; width: 275px;">
                   <b> <asp:Label ID="lblActItmType" runat="server"  Text="Action Item Type"></asp:Label></b>
                    <br />
                    <asp:DropDownList ID="ddlActItmType" runat="server" CssClass="textborder" Height="20px" Width="150px">
                        <asp:ListItem>Pre-Implementation</asp:ListItem>
                        <asp:ListItem>Implementation</asp:ListItem>
                        <asp:ListItem>Follow-Up</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td valign="top" style="border-right: 1px solid #8B8A8A; border-bottom: 1px solid #8B8A8A;
                    padding-left: 15px; padding-bottom: 5px">
                    <b><asp:Label ID="lblActItmDueDate" runat="server"  Text="Action Item Due Date"></asp:Label></b>
                    <br />
                    <asp:TextBox ID="date" runat="server" CssClass="textborder"></asp:TextBox>
                    <ajax:CalendarExtender ID="cal" runat="server" TargetControlID="date" ></ajax:CalendarExtender>
                    <%--<asp:TextBox ID="txtMonth" runat="server" CssClass="textborder" Width="24px"></asp:TextBox>
                    &nbsp;/
                    <asp:TextBox ID="txtDate" runat="server" CssClass="textborder" Width="24px"></asp:TextBox>
                    &nbsp;/
                    <asp:TextBox ID="txtYear" Width="30px" CssClass="textborder" runat="server"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                
                <td style="border-bottom: 1px solid #8B8A8A; border-left: 1px solid #8B8A8A; width: 187px;
                    border-right: 1px solid #8B8A8A; padding-left: 15px; padding-bottom: 5px; width: 275px;">
                  <b>  <asp:Label ID="lblAssFuncGroup" runat="server"  Text="Assign To Functional Group"></asp:Label></b>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textborder"></asp:TextBox>
                </td>
                <td valign="top" style="border-right: 1px solid #8B8A8A; border-bottom: 1px solid #8B8A8A;
                    padding-left: 15px; padding-bottom: 5px">
                   <b> <asp:Label ID="lblActItmOwner" runat="server"  Text="Action Item Owner"></asp:Label></b>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <b> <asp:Label ID="lblActItmApprover" runat="server"  Text="Action Item Approver"></asp:Label>&nbsp;&nbsp;</b>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="textborder"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="textborder"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                
                <td style="border-bottom: 1px solid #8B8A8A; width: 187px; border-left: 1px solid #8B8A8A;
                    border-right: 1px solid #8B8A8A; padding-left: 15px; padding-bottom: 5px; width: 275px;">
                   <b> <asp:Label ID="lblActItmCreated" runat="server"  Text="Action Item Created By"></asp:Label></b>
                    <br />
                    <asp:Label ID="lblActItmCreatedName" runat="server" CssClass="c10" Text="G.B Reddy(gbr2082)"></asp:Label>
                </td>
                <td valign="top" style="border-right: 1px solid #8B8A8A; border-bottom: 1px solid #8B8A8A;
                    padding-left: 15px; padding-bottom: 5px">
                 <b>   <asp:Label ID="lblCmpltActionItmBeforProced" runat="server"  Text="Complete Action Item Before Proceeding ?"></asp:Label></b>
                    <br />
                    <asp:DropDownList ID="ddlActItmBeforeProceed" runat="server" CssClass="textborder" Height="20px" Width="100px">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No
                        </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                
                <td valign="top" style="border-bottom: 1px solid #8B8A8A; width: 187px; border-left: 1px solid #8B8A8A;
                    border-right: 1px solid #8B8A8A; padding-left: 15px; padding-bottom: 5px; width: 275px;">
                   <b> <asp:Label ID="lblActItmExecType" runat="server"  Text="Action Item Execution Type"></asp:Label></b>
                    <br />
                    <asp:DropDownList ID="ddlActionItmExecutTyp" runat="server"  Height="20px" CssClass="textborder"
                        Width="150px">
                        <asp:ListItem>Documentation</asp:ListItem>
                        <asp:ListItem>Auto-Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td valign="top" style="border-right: 1px solid #8B8A8A; border-bottom: 1px solid #8B8A8A;
                    padding-left: 15px; padding-bottom: 5px">
                   <b> <asp:Label ID="lblOthrActItmExecType" runat="server"  Text="Other Action Item Execution Type"></asp:Label></b>
                    <br />
                    <asp:TextBox ID="txtOthrActItmExecType" runat="server" CssClass="textborder" Height="45px" TextMode="MultiLine"
                        Width="213px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
