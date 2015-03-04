<%@ Page Language="C#" MasterPageFile="CMSMasterPage22.master" AutoEventWireup="true"  CodeFile="CMS_Initiator.aspx.cs" Inherits="CMS_Initiator" Title=":: CMS-Initiator ::"  ValidateRequest="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register  Namespace="FreeTextBoxControls" Assembly="FreeTextBox"  TagPrefix="ftb" %>
<%@ Register Src="UserControl/topusercontrol.ascx" TagName="top" TagPrefix="c1" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" type="text/css" href="css/contentstyle.css" />
    <link rel="stylesheet" type="text/css" href="css/table.css" />
 <style type ="text/css">
.c1{width:100%;}
.c12{height:680px;width:100%;}
.c4{text-align:left;width:400px;}
.c5{text-align:right;}
.c6{color:Silver;font-size:15px;}
.c7{height:600px;width:100%;}
.c8{text-align:left;background-color:#569cfc; color:White}
.c9{text-align:left;font-size:smaller;color:Red}

.c10{font-size:small;font-family:Times New Roman}
.c12{padding-left:10px;}
   
    .style1
    {
        height: 23px;
    }
   .pad
   {
   	margin-top:3px;
   	width:250px;
   	height:50px;
   	border:1px;
	/*border-color:Silver;*/
	border-color:#7496c2;
	border-style:groove;
	font-size:12px;
	font-family:Arial;
	/*color:Black;*/
	color:#7496c2;
margin-left:15px;   	}
 .padreason
   {
   	margin-top:3px;
   	width:250px;
   	height:50px;
   	border:1px;
	/*border-color:Silver;*/
	border-color:#7496c2;
	border-style:groove;
	font-size:12px;
	font-family:Arial;
	/*color:Black;*/
	color:#7496c2;
margin-left:0px;   	}
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
        function Change(ddl) {
            var txt = document.getElementById('impact');          
            txt.style.display = ddl.value == "1" ?  "none":"block" ;
            
        }
        
            
             function second1(ddl2) {
            var txt2 = document.getElementById('regimpact');          
            txt2.style.display = ddl2.value == "1" ?  "none":"block" ;
            }
               function second2(ddl3) {
            var txt3 = document.getElementById('safetyimpact1');          
            txt3.style.display = ddl3.value == "1" ?  "none":"block" ;
            }
            
            
    </script>
      <script type="text/javascript" src="tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript" language="javascript">
        tinyMCE.init({
            // General options
             mode: "exact",
            elements: "<%=txtdate.ClientID %>",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",
           width:"850px",
            // Theme options
        theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|formatselect,fontselect,fontsizeselect,|,undo,redo,anchor,forecolor,backcolor,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
        //theme_advanced_buttons2: "",
  //  theme_advanced_buttons3: "",
        //theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true,
        });

         tinyMCE.init({
            // General options
             mode: "exact",
            elements: "<%=TextBox3.ClientID %>",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",
           width:"830px",
            // Theme options
        theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|formatselect,fontselect,fontsizeselect,|,undo,redo,anchor,forecolor,backcolor,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
        //theme_advanced_buttons2: "",
  //  theme_advanced_buttons3: "",
        //theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true,
        });


         tinyMCE.init({
            // General options
             mode: "exact",
            elements: "<%=TextBox15.ClientID %>",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",
           width:"100px",
            // Theme options
        theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|formatselect,fontselect,fontsizeselect,|,undo,redo,anchor,forecolor,backcolor,search,replace,",
        theme_advanced_buttons2: "|,bullist,numlist,|,outdent,indent,blockquote,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
  //theme_advanced_buttons2: "",
  //  theme_advanced_buttons3: "",
        //theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true,
        });

        tinyMCE.init({
            // General options
             mode: "exact",
            elements: "<%=TextBox16.ClientID %>",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",
           width:"100px",
            // Theme options
       theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|formatselect,fontselect,fontsizeselect,|,undo,redo,anchor,forecolor,backcolor,search,replace,",
        theme_advanced_buttons2: "|,bullist,numlist,|,outdent,indent,blockquote,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
    //  theme_advanced_buttons3: "",
        //theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true,
        });
    </script>
    <script type='text/javascript' src="JavaScriptSpellCheck/include.js"></script>
<%--<script type="text/javascript" src="tinymce/js/tinymce/tinymce.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-top:0px;padding-bottom:4px;">
   
      
            
             <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
             </asp:ScriptManager>--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          <table width="100%"  border="0"> 

      <%--  <table width="80%" style="border:1px solid #7496c2;" border="0"> --%>
        <tr><td colspan="2" style="background-color:#ebebeb"><table width="100%">
        <tr><td  align="left" style="padding-left:10px;padding-top:3px"><img src="images/logocmpny.png" alt="aceindus"  width="130px"/>
        
        </td>
        <td align="right" style="padding-right:50px;padding-top:3px">
        
        <b><asp:Label ID="Label4" CssClass="boldblack" runat="server" Text="UserName"  Font-Bold="true"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbluname" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;<strong>|</strong>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton5" runat="server" Text ="Logout" CssClass="lnkcolor"    OnClick="lnllogout" Font-Size="15px" ></asp:LinkButton></td>

        </tr>
        <tr ><td  align="left" style="padding-left:20px" valign="top">
        <asp:Label ID="lbldiv" runat="server" Text="Divison/Project/Dept : " CssClass="boldblack" Font-Bold="true" ForeColor="#2e96b3"></asp:Label>
        &nbsp;<asp:Label ID="lblchmname" runat="server" Text="Hyd/Change Management Module/Production" CssClass="boldblack" Font-Bold="true"></asp:Label>
        </td>
        
        <td align="right"  style="padding-right:50px">
<b><asp:Label ID="Label2" runat="server" Text="Date"  Font-Bold="true" CssClass="boldblack" ></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbldate" runat="server"  CssClass="initlblsleftrt"></asp:Label>
&nbsp;&nbsp;
<b><asp:Label ID="Label6" runat="server" Text="Time" Font-Bold="true" CssClass="boldblack"></asp:Label></b>&nbsp;<strong >:</strong>&nbsp;
<asp:Label ID="lbltime" runat="server" ></asp:Label>

</td>
        </tr>
       <tr ><td colspan="2" align="left" >
      
<asp:Button ID="btnsaave" runat="server" Text="Save" CssClass="spellchkbtn"/>
<asp:Button ID="btnspellchk" runat="server" Text="Check Spelling" CssClass="spellchkbtn"  OnClientClick="$Spelling.SpellCheckInWindow('editors')" />
</td></tr>
       </table></td></tr>
        <tr><td colspan="2" style="width:100%" >
                    <table id="table1" border="0"  width="100%">
                  
                    
                    <%--<tr><td colspan="3" class="content" align="left" width="100%">Initiator</td></tr>--%>
                   
<tr runat="server" visible="false">
<td class="tdinitleft" style="padding-left:10px" align="left">

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

<tr><td align="left"><asp:LinkButton ID="lnknew" runat="server" CssClass="lnkcolor" 
        onclick="lnknew_Click"> <asp:Label ID="lblinitiate" runat="server" Text="Initiate New CC" ></asp:Label></asp:LinkButton></td></tr>
</table>
</td>
<td align="right" valign="top" style="padding-right:50px" id="tdstatus" runat="server"><asp:Label ID="lblstatu" runat="server" Font-Bold="true" Text="Status" CssClass="boldblack"></asp:Label>
 <strong >:</strong>
<asp:Label ID="lblstat" runat="server" ></asp:Label>
 </td>
</tr>
<tr runat="server" visible="false"><td colspan="2" ><hr class="searchline"/></td></tr>

                                                 
                      <tr><td colspan="2" style="width:100%" align="center">
                      <asp:Panel ID="pnltitle" runat="server" Height="400px" Width="100%" ScrollBars="Vertical" >
                  
                      <table>
                      <tr><td colspan="2" align="center"><table>
                      <tr><td style="width:15px; color:#093982;font-weight:bold;font-size:17px"><strong >Initiator</strong></td><td align="left" style="width:1050px" valign="middle"  ><hr class="pnlborder" /></td></tr>
                       </table></td></tr>
                       <tr id="trst" runat="server" visible="false">
                           <td colspan ="2" align="right" style="font-size:small;padding-right:50px;">
                           <font color="red">  marked with a red asterisk(*) are required</font></td></tr>
                       
                        <tr id="trbody" runat="server" visible="false"><td colspan="2" align="center" 
                                id="tbcontent" runat="server">
                        <table align="left" style="padding-left:15px;" >

                         <tr id="chaneig" runat="server" visible="false">
                        
                        
                       
                         <td style="text-align:right" class="lefttd"><b>Changeid</b><td class="colontd">
                        :</td>
                   
                           
                        </td><td align="left"  width="210px" >
                  <asp:Label ID="lblid" runat="server" CssClass ="cidfont"></asp:Label>
                                        </td>
                        
                        <td colspan="3"></td>
                        </tr>

                        <tr>
                         <td style="text-align:right" class="lefttd"><b>Type of Changes</b>
                         </td>
                         <td class="colontd">
                        :</td>
                    <td align="left"  width="350px" >
                    <asp:DropDownList runat="server" ID="ddl1" Height="20px"  class="dropdownbig" 
                                    >
                    <asp:ListItem >Select Changes</asp:ListItem>
                    <asp:ListItem>Pre Approval Change</asp:ListItem>
                     <asp:ListItem>Post Approval Change</asp:ListItem>
                   
                    </asp:DropDownList>
                    <asp:Label ID="lblrtchange" runat="server" Visible="false"></asp:Label>
                   
                                        </td>
                        
                        <td style="text-align:right" class="initlefttd"><b>Change Period</b><b style ="color:Red"></b></td><td class="colontd">
                            :</td><td style="text-align:left" width="370px">
                        <asp:DropDownList runat="server" ID="ddl2" Height="20px"  
                                    class="dropdownbig" TabIndex="15" >
                        <asp:ListItem Text="Select Period" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Temporary" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Permanent" Value="2"></asp:ListItem>

                        </asp:DropDownList>
                         <asp:Label ID="lblrchperiod" runat="server" Visible="false"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                        
                        <td style="text-align:right" class="lefttd"><b>Change Classification</b></td><td class="colontd">
                                :</td><td style="text-align:left">
                            <asp:DropDownList runat="server" ID="DropDownList3" Height="20px"  class="dropdownbig" >
                        <asp:ListItem Text="Select Classification" ></asp:ListItem>
                        <asp:ListItem Text="Quality Impactinng" ></asp:ListItem>
                        <asp:ListItem Text="Quality non-Impacting" ></asp:ListItem>

                       
                        </asp:DropDownList>
                            <asp:Label ID="lclchangeclassification" runat="server" Visible="false"></asp:Label>
                        </td>

                        <td style="text-align:right;" class="initlefttd"><b>Site/Unit</b></td><td class="colontd">
                            :</td><td style="text-align:left">
                        <asp:DropDownList runat="server" ID="DropDownList4" Height="20px" class="dropdownbig" >
                        <asp:ListItem Text="Select Site/Unit" ></asp:ListItem>
                        <asp:ListItem Text="Unit1" ></asp:ListItem>
                        <asp:ListItem Text="Unit2" ></asp:ListItem>
                         <asp:ListItem Text="Unit3"></asp:ListItem>
                         </asp:DropDownList>

                           <asp:Label ID="lblsrunit" runat="server" Visible="false"></asp:Label>
                        </td>
                        </tr>

                        <tr>
                        <td style="text-align:right" class="lefttd"><b>Department</b><b style="color:Red"></b><td class="colontd">
                           :</td>
                          
                               
                           </td><td style="text-align:left">
                                              <asp:DropDownList runat="server" ID="DropDownList5" Height="20px"  AutoPostBack="true"
                                                  class="dropdownbig" onselectedindexchanged="DropDownList5_SelectedIndexChanged" >
                       
                   
                       
                         </asp:DropDownList>
                            <asp:Label ID="lblrdept" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td style="text-align:right;" class="initlefttd">
                               <b>Change Source</b></td><td class="colontd">:</td><td style="text-align:left">
                              
                                <asp:TextBox ID="TextBox20" Height="20px" runat="server" Width="200px" CssClass="textborder"></asp:TextBox>
                       
                        <asp:Label ID="lblrcsource" runat="server" Visible="false"></asp:Label>
                        </td>
                        </tr>



                        <tr>
                        <td style="text-align:right" class="lefttd" ><b>Change Category</b></td>
                            <td class="colontd" >:</td><td style="text-align:left" >
                         <asp:DropDownList runat="server" ID="DropDownList9" Height="20px" 
                                CssClass="dropdownbig" >
                         <asp:ListItem Text="Select Category" Value="0"></asp:ListItem>
                         <asp:ListItem Text="Documents" Value="1"></asp:ListItem>
                         <asp:ListItem Text="Product" Value="2"></asp:ListItem>
                          <asp:ListItem Text="Material" Value="2"></asp:ListItem>
                          </asp:DropDownList>
                             <asp:Label ID="lblrcccat" runat="server" Visible="false" ></asp:Label>
                                        </td>
                                        <td style="text-align:right" class="initlefttd" ><b>Reference ID</b></td><td class="colontd"  valign="top"  >
                           :</td><td style="text-align:left" >
                                <asp:TextBox ID="txt4" runat="server" CssClass="textborder" Height="20px" 
                                    Width="200px"></asp:TextBox>
                                     <asp:Label ID="lblrrid" runat="server" Visible="false"></asp:Label>
                                        </td>

                            <tr>
                                <td class="lefttd" style="text-align:right" valign="top">
                                    <b>Customer</b> <b style="color:Red">*</b></td>
                                <td class="colontd" valign="top">
                                    :</td>
                                <td style="text-align:left">
                                    <asp:DropDownList ID="ddl3" runat="server" class="dropdownbig" Height="20px">
                                        <asp:ListItem Text="Select Customer" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Temporary" Value="1">GSK</asp:ListItem>
                                        <asp:ListItem Text="Permanent" Value="2">Pfizer</asp:ListItem>
                                        <asp:ListItem Text="Permanent" Value="2">Mylan</asp:ListItem>
                                    </asp:DropDownList>
                                       <asp:Label ID="lblrcustomer" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="red1" runat="server" ControlToValidate="ddl3" 
                                        ErrorMessage="Select Customer" InitialValue="0" ValidationGroup="init">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="initlefttd" style="text-align:right" valign="top">
                                    <b>Market<font color="red">*</font></b></td>
                                <td class="colontd" valign="top">
                                    :</td>
                                <td style="text-align:left">
                                    <asp:DropDownList ID="ddl4" runat="server" CssClass="dropdownbig" Height="20px">
                                        <asp:ListItem Value="0">Select Market</asp:ListItem>
                                        <asp:ListItem Value="3">US</asp:ListItem>
                                        <asp:ListItem Value="1">EU</asp:ListItem>
                                        <asp:ListItem Value="2">WHO</asp:ListItem>
                                    </asp:DropDownList>
                                       <asp:Label ID="lblrmarket" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="ddl4" ErrorMessage="Select Market" InitialValue="0" 
                                        ValidationGroup="init">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>License</b> <b style="color:Red">*</b></td>
                                <td class="colontd">
                                    :</td>
                                <td colspan="4" style="text-align:left">
                                    <asp:TextBox ID="txt111" runat="server" CssClass="textborder" Height="20px" 
                                        Width="600px"></asp:TextBox>
                                           <asp:Label ID="lblrlicense" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txt111" ErrorMessage="Please Enter License" 
                                        ValidationGroup="init">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>Change Description</b> <b style="color:Red">*</b></td>
                                <td class="colontd">
                                    :</td>
                                <td colspan="4" style="text-align:left">
                                    <asp:TextBox ID="txtdate" runat="server" CssClass="textborder" Height="70px" 
                                        TextMode="MultiLine" Width="750px"></asp:TextBox>
                                       <asp:Label ID="lblrcdesc" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txtdate" ErrorMessage="Please Enter Change Description" 
                                        ValidationGroup="init">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>Is there any product impact?</b> <b style="color:Red">*</b></td>
                                <td class="colontd">
                                    :</td>
                                <td colspan="1" style="text-align:left;width:100px">
                                  
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdownsmall" 
                                        Height="20px" onchange="Change(this)" Width="160px">
                                        <asp:ListItem Text="No">Select</asp:ListItem>
                                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                       <asp:Label ID="lblrpimpact" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="DropDownList2" ErrorMessage="Please Select Product Impact" 
                                        InitialValue="Select" ValidationGroup="init">*</asp:RequiredFieldValidator>
                                </td>
                                  <td align="left" colspan="3" >
                                    <table id="impact" align="left" style="display:none" width="100%">
                                        <tr class="subtr">
                                            <td align="left" style="color:#7496c2;width:82px;font-weight:bold;font-size:12px">
                                                Product Name
                                            </td>
                                            <td class="colontd" style="font-weight:bold;color:#7496c2;">
                                                :</td>
                                            <td align="left"  style="padding-left:5px">
                                                <asp:DropDownList ID="DropDownList10" runat="server" CssClass="textborder" 
                                                    Height="20px" Width="150px">
                                                    <asp:ListItem Text="Product Name" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Not Applicable" Value="3">Metformin</asp:ListItem>
                                                    <asp:ListItem Text="Prior approval" Value="1">Omeprazole</asp:ListItem>
                                                </asp:DropDownList>
                                                   <asp:Label ID="lblrpname" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td style="text-align:center;color:#7496c2;width:82px;font-weight:bold;font-size:12px">
                                                Dosage form
                                            </td>
                                           <td class="colontd" style="font-weight:bold;color:#7496c2;">
                                                :</td>
                                            <td align="left" style="padding-left:5px">
                                                <asp:DropDownList ID="DropDownList11" runat="server" Height="20px" 
                                                    Width="150px">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Not Applicable" Value="3">200mg</asp:ListItem>
                                                    <asp:ListItem Text="Prior approval" Value="1">500mg</asp:ListItem>
                                                    <asp:ListItem Text="Prior approval" Value="1">700mg</asp:ListItem>
                                                </asp:DropDownList>
                                                   <asp:Label ID="lblrdosage" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                           
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>Is there any Safety impact?</b> <b style="color:Red">*</b></td>
                                <td class="colontd">
                                    :</td>
                                <td colspan="1" style="text-align:left">
                                    <asp:DropDownList ID="DropDownList6" runat="server" CssClass="dropdownsmall" 
                                        Height="20px" onchange="second2(this)" Width="160px">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                       <asp:Label ID="lblrsafetyimpcat" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="DropDownList6" ErrorMessage="Please Select Safety Impact" 
                                        InitialValue="Select" ValidationGroup="init">*</asp:RequiredFieldValidator>
                                </td>
                                 <td align="left" colspan="3">
                                    <table id="safetyimpact1" style="display:none" width="100%">
                                        <tr>
                                            <td align="left" style="color:#7496c2;font-weight:bold;font-family:Arial;font-size:12px" width="180px">
                                                Enclose Safety risk assessment
                                            </td>
                                            <td class="colontd" style="font-weight:bold;color:#7496c2;">
                                                :</td>
                                            <td align="left" width="100px" style="padding-left:5px">
                                                <%-- <input type="file" name="somename" size="chars"> --%>
                                                <asp:FileUpload ID="FileUpload2" runat="server" Height="25px" Width="250px" />
                                               <asp:Label ID="lblrassesment" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                          
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>Is there any Regulator impact?</b> <b style="color:Red">*</b></td>
                                <td class="colontd">
                                    :</td>
                                <td colspan="1" style="text-align:left">
                                    <asp:DropDownList ID="DropDownList13" runat="server" CssClass="dropdownsmall" 
                                        Height="20px" onchange="second1(this)" Width="160px">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                       <asp:Label ID="lblrrimpact" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                        ControlToValidate="DropDownList13" 
                                        ErrorMessage="Please Select Regulator Impact" InitialValue="Select" 
                                        ValidationGroup="init">*</asp:RequiredFieldValidator>
                                </td>
                                   <td colspan="3">
                                    <table ID="regimpact" style="display:none" width="100%">
                                        <tr>
                                            <td align="left" style="color:#7496c2;font-weight:bold;font-size:12px;font-family:Arial" width="115px">
                                                Impact Description
                                            </td>
                                            <td class="colontd" style="font-weight:bold;color:#7496c2;">
                                                :</td>
                                            <td align="left" style="padding-left:5px">
                                                <asp:TextBox ID="TextBox4" runat="server" Width="185px"></asp:TextBox>
                                              <asp:Label ID="lblrrimpdesc" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="center" colspan="6">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <b>Existing</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="TextBox15" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                          <asp:Label ID="lblrexist" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <b>Proposal</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="TextBox16" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                               <asp:Label ID="lblrrproposal" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <asp:Button ID="btnaddrow" runat="server" CssClass="buttonstyle" 
                                        onclick="btnaddrow_Click" Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:GridView ID="gd" runat="server" AutoGenerateColumns="false" 
                                        BorderColor="#adb1b9" BorderWidth="1px" CssClass="subtr" 
                                        onrowdeleting="gd_RowDeleting" Visible="true" Width="85%">
                                        <Columns>
                                            <asp:BoundField DataField="existing" HeaderStyle-HorizontalAlign="Left" 
                                                HeaderText="Existing" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="proposal" HeaderStyle-HorizontalAlign="Left" 
                                                HeaderText="Proposal" ItemStyle-HorizontalAlign="Left" />
                                            <asp:CommandField ButtonType="Image" ControlStyle-Height="18px" 
                                                ControlStyle-Width="18px" DeleteImageUrl="~/images/delete-button.png" 
                                                HeaderStyle-HorizontalAlign="Center" HeaderText="Delete" 
                                                ItemStyle-HorizontalAlign="Center" ShowDeleteButton="true" />
                                        </Columns>
                                        <HeaderStyle BackColor="#c6d8ef" />
                                        <AlternatingRowStyle BackColor="#e3e3e3" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>Reason for Change</b>
                                </td>
                                <td class="colontd">
                                    :</td>
                                <td colspan="4" style="text-align:left">
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="textborder" Height="50px" 
                                        TextMode="MultiLine" Width="250px"></asp:TextBox>
                                           <asp:Label ID="lblrrchange" runat="server" Visible="false"></asp:Label>
                                    <%--<ftb:FreeTextBox ID="TextBox3" runat="Server" RemoveServerNameFromUrls="true" Height="100px"  Width="850px"
            BackColor=" Transparent" UseToolbarBackGroundImage="False" GutterBackColor="Transparent" 
            ToolbarBackgroundImage="False" ScriptMode="InPage" >
            <Toolbars>
                <ftb:Toolbar>
                </ftb:Toolbar>
            </Toolbars>
        </ftb:FreeTextBox>--%>
                                </td>
                                <td align="left">
                                    <asp:Button ID="Button1" runat="server" CssClass="buttonstyle" 
                                        onclick="btnaddrowreason_Click" Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:GridView ID="gd1" runat="server" AutoGenerateColumns="false" 
                                        BorderColor="#adb1b9" BorderWidth="1px" CssClass="subtr" 
                                        onrowdeleting="gd1_RowDeleting" Visible="true" Width="85%">
                                        <Columns>
                                            <asp:BoundField DataField="reschnge" HeaderStyle-HorizontalAlign="Left" 
                                                HeaderText="Reason For Change" ItemStyle-HorizontalAlign="Left" />
                                            <asp:CommandField ButtonType="Image" ControlStyle-Height="18px" 
                                                ControlStyle-Width="18px" DeleteImageUrl="~/images/delete-button.png" 
                                                HeaderStyle-HorizontalAlign="Center" HeaderText="Delete" 
                                                ItemStyle-HorizontalAlign="Center" ShowDeleteButton="true" />
                                        </Columns>
                                        <HeaderStyle BackColor="#c6d8ef" />
                                        <AlternatingRowStyle BackColor="#e3e3e3" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>Related Changes</b>
                                </td>
                                <td class="colontd">
                                    :</td>
                                <td style="text-align:left">
                                    <asp:DropDownList ID="TextBox13" runat="server" CssClass="textborder" 
                                        Height="20px" Width="190px">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>CMS101</asp:ListItem>
                                        <asp:ListItem>CMS102</asp:ListItem>
                                        <asp:ListItem>CMS103</asp:ListItem>
                                    </asp:DropDownList>
                                       <asp:Label ID="lblrrelatedchanges" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>Attachments</b>
                                </td>
                                <td class="colontd">
                                    :</td>
                                <td colspan="4" style="text-align:left">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Height="25px" Width="250px" />
                                       <asp:Label ID="lblrattach" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lefttd" style="text-align:right">
                                    <b>Submit to</b>
                                </td>
                                <td class="colontd">
                                    :</td>
                                <td colspan="4" style="text-align:left">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textborder" 
                                        Height="20px" Width="190px">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                       <asp:Label ID="lblrassignto" runat="server" ></asp:Label>
                                    <asp:RequiredFieldValidator ID="reqassign" runat="server" 
                                        ControlToValidate="DropDownList1" 
                                        ErrorMessage="Please Select Assigned To option" InitialValue="Select" 
                                        ValidationGroup="init">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                        </tr>

                        </table>
                        </td></tr>
                   
                    
                    
                  <tr runat="server" visible="false"><td colspan="2" width="100%" align="center">
                  <asp:RadioButtonList ID="belowcontent" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"  CssClass="rbtninit" Width="90%">
                  <asp:ListItem  Value="Audit Trial" Selected="True">Audit Trial</asp:ListItem>
                  <asp:ListItem>E-mail Notification</asp:ListItem>
                  <asp:ListItem>Re-assign</asp:ListItem>
                  <asp:ListItem>CC Report</asp:ListItem>
                  <asp:ListItem>Run Report</asp:ListItem>
                  <asp:ListItem>Dashboards</asp:ListItem>
                  </asp:RadioButtonList>
                  </td></tr>
                   
                 
                    <tr>
                    <td colspan="2" align="right" class="style1">
                   
                       
                    </td>
                    </tr>
                     <tr id="trbtn" runat="server" visible="true">
                     <td colspan="2" style="text-align:right;padding-right:30px"> 
                     <asp:Button ID="button" runat="server" Text="Save(F1)" 
                       CssClass="buttonstyle" Width="90px" onclick="button_Click"  />
                       <asp:Button ID="saveclose" runat="server" Text="Save & Close(F2)" 
                       CssClass="buttonstyle" Width="110px" onclick="saveclose_Click"   />
                                            
                                         <!--  <input id="Button8" type="button" value="Submit(F3)"  class="buttonstyle" onclick="alert('Submited Successfully')" style="Width:90px"/>  -->              
             <asp:Button ID="submit" runat="server" Text="Submit(F3)" CssClass="buttonstyle" Width="90px" OnClick="submit_Click" ValidationGroup="init"
             />
               
                          </td>
                     </tr>
               
                    <asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="Please Fill All The Fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="init">
                    </asp:ValidationSummary>
                      </table>
                       
                          </asp:Panel>
                      </td></tr> 
                    </table>
            
         </td></tr>
          
             
             </table>
         
       
    </div>
</asp:Content>

