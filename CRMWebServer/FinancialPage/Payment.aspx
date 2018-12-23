<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="CRMWebServer.FinancialPage.ConsultantRule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>缴款记录页面</title>
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
                                        <span class="left_txt2">在这里，您可以进行缴款管理</span><span
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
                                            <asp:Button ID="btnSearch" runat="server" Text="查询" Width="80px" />
                                        </td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="gvPayment" runat="server" AutoGenerateColumns="False" 
                                CellPadding="3" ForeColor="Black"
                                GridLines="Horizontal" DataKeyNames="PaymentID" OnRowCancelingEdit="gvPayment_RowCancelingEdit"
                                OnRowEditing="gvPayment_RowEditing" OnRowUpdating="gvPayment_RowUpdating" 
                                CssClass="left_txt" BackColor="White" BorderColor="#999999" 
                                BorderStyle="Groove" BorderWidth="2px">
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="PaymentID" HeaderText="缴款编号" ReadOnly="True" />
                                    <asp:BoundField DataField="FeesTotal" HeaderText="合同金额" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="缴款金额">
                                        <ItemTemplate>
                                            <%# Eval("PaymentFees") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPaymentFees" runat="server" Text='<%# Eval("PaymentFees") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="缴款日期">
                                        <ItemTemplate>
                                            <%# Eval("PaymentDate") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPaymentDate" runat="server" Text='<%# Eval("PaymentDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ContractID" HeaderText="合同编号" ReadOnly="True" />
                                    <asp:BoundField DataField="CustomerID" HeaderText="客户编号" ReadOnly="True" />
                                    <asp:CommandField HeaderText="修改" ShowEditButton="True" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
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
                                            <asp:Label ID="lblFeesTotal" runat="server" Text="合同金额：" Width="77px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFeesTotal" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RfvFeesTotal" runat="server" ControlToValidate="txtFeesTotal"
                                            ErrorMessage="*" ValidationGroup="ContractGroup"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RevFeesTotal" runat="server" ControlToValidate="txtFeesTotal"
                                            ErrorMessage="请输入数字" 
                                            ValidationExpression="^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$" 
                                            ValidationGroup="ContractGroup"></asp:RegularExpressionValidator>
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
                                            <asp:Label ID="lblPaymentFees" runat="server" Text="缴款金额：" Width="77px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaymentFees" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RfvPaymentFees" runat="server" ControlToValidate="txtPaymentFees"
                                            ErrorMessage="*" ValidationGroup="ContractGroup"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RevPaymentFees" runat="server" ControlToValidate="txtPaymentFees"
                                            ErrorMessage="请输入数字" 
                                            ValidationExpression="^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$" 
                                            ValidationGroup="ContractGroup"></asp:RegularExpressionValidator>
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
                                            <asp:Label ID="lblPaymentDate" runat="server" Text="缴款日期：" Width="77px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaymentDate" runat="server" Width="180px" 
                                                onclick="new Calendar().show(this);" ReadOnly="True"></asp:TextBox>
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
                                            <asp:Label ID="lblContractID" runat="server" Text="合同编号：" Width="77px" CssClass="left_txt"></asp:Label>
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
                                            <asp:Label ID="lblCustomerID" runat="server" Text="客户编号：" Width="77px" CssClass="left_txt"></asp:Label>
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
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                                                ID="btnPayment" runat="server" Height="28px" OnClick="btnPayment_Click"
                                            Text="添加" Width="76px" ValidationGroup="ContractGroup" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;
                                        </td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnBack" runat="server" Height="28px" onclick="btnBack_Click" 
                                            Text="返回" Width="76px" />
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
