<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeaCommisions.aspx.cs" Inherits="CRMWebServer.FinancialPage.SeaCommisions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>海佣缴款页面</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    <script src="../js/Calendar3.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
    <td width="17" valign="top" background="../images/mail_leftbg.gif"><img src="../images/left-top-right.gif" width="17" height="29" /></td>
    <td valign="top" background="../images/content-bg.gif">
    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg" id="table2">
      <tr>
        <td height="31">
   
            <div class="titlebt">
                缴款管理
                </div>
            </td>
      </tr>
    </table>
    </td>
    <td width="16" valign="top" background="../images/mail_rightbg.gif"><img src="../images/nav-right-bg.gif" width="16" height="29" /></td>
  </tr>
        <tr>
            <td height="71" valign="middle" background="../images/mail_leftbg.gif">
                &nbsp;
            </td>
            <td valign="top" bgcolor="#F7F8F9">
                <table width="98%" height="138" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="13" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" height="55" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <td width="10%" height="55" valign="middle">
                                            <img src="../images/title.gif" width="54" height="55">
                                        </td>
                                    </td>
                                    <td width="90%" valign="top">
                                        <span class="left_txt2">在这里，您可以进行海佣信息维护</span><span
                                            class="left_txt2">！</span><br>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            <table width="100%" height="1" border="0" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC">
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_txt">
                            &nbsp;根据不同条件查询合同信息：
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblCotractID" runat="server" Text="合同编号：" Width="77px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContractID" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        &nbsp;<td>
                                            <asp:Button ID="btnSearch" runat="server" Text="查询" Width="80px" OnClick="btnSearch_Click" />
                                        </td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="gvSeaCommision" runat="server" AutoGenerateColumns="False" 
                                CellPadding="3" ForeColor="Black"
                                GridLines="Horizontal" DataKeyNames="SeaCommisionID" CssClass="left_txt" 
                                BackColor="White" BorderColor="#999999" BorderStyle="Groove" 
                                BorderWidth="2px">
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="SeaCommisionID" HeaderText="海佣编号" />
                                    <asp:BoundField DataField="SeaCommisionTotalAmount" HeaderText="海佣预估金额" />
                                    <asp:BoundField DataField="SeaCommisionLimit" HeaderText="海佣缴费年限" />
                                    <asp:BoundField DataField="SeaCommisionCallsDate" HeaderText="海佣催缴日期" />
                                    <asp:BoundField DataField="SeaCommisionActualAmount" HeaderText="海佣实收金额" />
                                    <asp:BoundField DataField="SeaCommisionGetDate" HeaderText="海佣收到日期" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_txt">
                            &nbsp; 添加缴款记录信息：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblSeaCommisionTotalAmount" runat="server" Text="海佣预估金额：" 
                                                Width="85px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSeaCommisionTotalAmount" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RevFeesTotal" runat="server" ControlToValidate="txtSeaCommisionTotalAmount"
                                            ErrorMessage="请输入数字" 
                                            ValidationExpression="^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblSeaCommisionLimit" runat="server" Text="海佣缴款年限：" Width="85px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSeaCommisionLimit" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RevSeaCommisionLimit" runat="server" ControlToValidate="txtSeaCommisionLimit"
                                            ErrorMessage="请输入数字" 
                                            ValidationExpression="^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblSeaCommisionCallsDate" runat="server" Text="海佣催缴日期：" 
                                                Width="85px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSeaCommisionCallsDate" runat="server" Width="180px" 
                                                onclick="new Calendar().show(this);"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblSeaCommisionActualAmount" runat="server" Text="海佣实收金额：" 
                                                Width="85px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSeaCommisionActualAmount" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RevSeaCommisionActualAmount" runat="server" ControlToValidate="txtSeaCommisionActualAmount"
                                            ErrorMessage="请输入数字" 
                                            ValidationExpression="^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblSeaCommisionGetDate" runat="server" Text="海佣收到日期：" 
                                                Width="85px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSeaCommisionGetDate" runat="server" Width="180px" 
                                                onclick="new Calendar().show(this);"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblContractID" runat="server" Text="合同编号：" Width="85px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContract" runat="server" Width="180px" ReadOnly="True" Enabled="False"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblCustomerID" runat="server" Text="客户编号：" Width="85px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerID" runat="server" Width="180px" ReadOnly="True" Enabled="False"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
      
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAdd" runat="server" Height="28px" OnClick="btnAdd_Click"
                                            Text="添加" Width="76px" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;
                                        </td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnBack" runat="server" Height="28px" Text="返回 " Width="76px" 
                                            onclick="btnBack_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../images/mail_rightbg.gif">&nbsp;</td>
        </tr>
        <tr>
    <td valign="bottom" background="../images/mail_leftbg.gif"><img src="../images/buttom_left2.gif" width="17" height="17" /></td>
    <td background="../images/buttom_bgs.gif"><img src="../images/buttom_bgs.gif" width="17" height="17"></td>
    <td valign="bottom" background="../images/mail_rightbg.gif"><img src="../images/buttom_right2.gif" width="16" height="17" /></td>
  </tr>
    </table>
    </form>
</body>
</html>
