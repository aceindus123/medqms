<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Admin_UserControl_Menu" %>
<table align="center" width="100%" >
                      <tr>
                             <td align="center"   width="16%" > 
                                <asp:LinkButton ID="lnkhome" runat="server" Text="Home" Font-Underline="false"  
                                     class="datalp9" onclick="lnkhome_Click" ></asp:LinkButton>
                             </td>
                      
                        <td style="font-size:16px;  font-weight:bold;">&nbsp;|</td>
                        <td align="center"   width="16%" > 
                                <asp:LinkButton ID="lnkclient" runat="server" Text="Clients" Font-Underline="false"  
                                     class="datalp9" onclick="lnkclient_Click"   ></asp:LinkButton>
                             </td>

                        <td style="font-size:16px;  font-weight:bold;">&nbsp;|</td>
                        <td align="center"   width="16%" > 
                                <asp:LinkButton ID="lnkreport" runat="server" Text="Reports" Font-Underline="false"  
                                     class="datalp9" onclick="lnkreport_Click"  ></asp:LinkButton>
                             </td>
                       <td style="font-size:16px;  font-weight:bold;">&nbsp;|</td>
                        <td align="center"   width="16%" >  
                                <asp:LinkButton ID="lnklog" runat="server" Text="Log Data" Font-Underline="false"  
                                     class="datalp9" onclick="lnklog_Click"  ></asp:LinkButton>
                             </td>
                       
                         <td style="font-size:16px; font-weight:bold;">&nbsp;|</td>
                           <td align="center"   width="16%" >   
                                <asp:LinkButton ID="lnkusers" runat="server" Text="Users" Font-Underline="false"  
                                     class="datalp9" onclick="lnkusers_Click"   ></asp:LinkButton>
                             </td>
                          </tr>

                      <tr>
                       
                      <td align="center"   width="16%" >    <asp:LinkButton ID="lnksupport" runat="server" 
                              Text="Support" Font-Underline="false" 
                                 CssClass="datalp9" onclick="lnksupport_Click"  ></asp:LinkButton>
                        </td>

                       
                        <td style="font-size:16px; font-weight:bold;">&nbsp;|</td>
                              <td align="center"   width="16%" >  
                                <asp:LinkButton ID="lnkcontact" runat="server" Text="Contact" 
                                     Font-Underline="false"  class="datalp9" onclick="lnkcontact_Click" 
                                     ></asp:LinkButton>
                                    
                        </td>
                             
                             <td style="font-size:16px; font-weight:bold;">&nbsp;|</td>
                             <td align="center"   width="16%" >  
                                <asp:LinkButton ID="lnkfeedback" runat="server" Text="Feedback" 
                                     Font-Underline="false"  class="datalp9" onclick="lnkfeedback_Click" 
                                     ></asp:LinkButton>
                                    
                        </td>

                        <td style="font-size:16px; font-weight:bold;" >&nbsp;|</td>
                        <td align="center"   width="16%" > 
                              <asp:LinkButton ID="lnkpermissions" runat="server" Text="Permissions" 
                                  Font-Underline="false"   class="datalp9" onclick="lnkpermissions_Click"
                                   ></asp:LinkButton>

                        </td>
                          <td style="font-size:16px; font-weight:bold;">&nbsp;|</td>
                            <td align="center"   width="16%" > 
                                <asp:LinkButton ID="lnkproduct" runat="server" Text="Product" 
                                     Font-Underline="false"  class="datalp9" onclick="lnkproduct_Click"
                                     ></asp:LinkButton>
                                    
                        </td>
                    </tr>
  </table>