<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractIncome.aspx.cs"
    Inherits="CRMWebServer.FinancialPage.ContractIncome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>顾问提成统计</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />

    <script src="../js/Calendar3.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="17" valign="top" background="../images/mail_leftbg.gif">
                <img src="../images/left-top-right.gif" width="17" height="29" />
            </td>
            <td valign="top" background="../images/content-bg.gif">
                <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg"
                    id="table2">
                    <tr>
                        <td height="31">
                            <div class="titlebt">
                                顾问提成
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="16" valign="top" background="../images/mail_rightbg.gif">
                <img src="../images/nav-right-bg.gif" width="16" height="29" />
            </td>
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
                                        <span class="left_txt2">在这里，您可以查看客户顾问提成</span><span
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
                                            <asp:Label ID="lblConsult" runat="server" Text="顾问编号：" Width="77px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConsult" runat="server"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        &nbsp;<td>
                                            <asp:Button ID="btnSearch" runat="server" Text="查询" Width="69px" />
                                        </td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="gvConsultIncome" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="DeductID" onrowcancelingedit="gvConsultIncome_RowCancelingEdit" 
                                onrowediting="gvConsultIncome_RowEditing" 
                                onrowupdating="gvConsultIncome_RowUpdating" CellPadding="3" 
                                CssClass="left_txt" ForeColor="Black" GridLines="Horizontal" 
                                BackColor="White" BorderColor="#999999" BorderStyle="Groove" 
                                BorderWidth="2px">
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="DeductID" HeaderText="编号" ReadOnly="True" />
                                    <asp:BoundField DataField="DeductIncome" HeaderText="提成金额" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="发放日期">
                                    <ItemTemplate>
                                    <%# Eval("DeductDate") %>
                                    </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDate" runat="server" Text='<%# Eval("DeductDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ConsultantID" HeaderText="顾问编号" ReadOnly="True" />
                                    <asp:BoundField DataField="ContractID" HeaderText="合同编号" ReadOnly="True" />
                                    <asp:CommandField HeaderText="操作" ShowEditButton="True" />
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
                                            <asp:Label ID="lblDeductItem" runat="server" Text="提成选项：" Width="77px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPecentItem" runat="server" 
                                                onselectedindexchanged="ddlPecentItem_SelectedIndexChanged">
                                            </asp:DropDownList>
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
                                            <asp:Label ID="lblDeductmoney" runat="server" Text="提成金额：" Width="77px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDeductMoney" runat="server" ReadOnly="True"></asp:TextBox>
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
                                            <asp:Label ID="lblReleaseDate" runat="server" Text="提成日期：" Width="77px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtReleaseDate" runat="server"　onclick="new Calendar().show(this);"></asp:TextBox>
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
                                            <asp:Label ID="lblConsultID" runat="server" Text="顾问编号：" Width="77px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConsultID" runat="server" ReadOnly="True"></asp:TextBox>
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
                                            <asp:Label ID="lblConractID" runat="server" Text="合同编号：" Width="77px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContractID" runat="server" ReadOnly="True"></asp:TextBox>
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
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;
                                        </td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnConfirmAdd" runat="server" Text="添加" Width="68px" 
                                            onclick="btnConfirmAdd_Click" />
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
            <td background="../images/mail_rightbg.gif">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="bottom" background="../images/mail_leftbg.gif">
                <img src="../images/buttom_left2.gif" width="17" height="17" />
            </td>
            <td background="../images/buttom_bgs.gif">
                <img src="../images/buttom_bgs.gif" width="17" height="17">
            </td>
            <td valign="bottom" background="../images/mail_rightbg.gif">
                <img src="../images/buttom_right2.gif" width="16" height="17" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
