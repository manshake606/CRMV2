<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffInformations.aspx.cs"
    Inherits="CRMWebServer.Staff.StaffInformations" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工管理页面</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="17" height="29" valign="top" background="../images/mail_leftbg.gif">
                <img src="../images/left-top-right.gif" width="17" height="29" />
            </td>
            <td width="935" height="29" valign="top" background="../images/content-bg.gif">
                <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg"
                    id="table2">
                    <tr>
                        <td height="31">
                            <div class="titlebt">
                                员工管理</div>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="17" height="29" valign="top" background="../images/mail_rightbg.gif">
            </td>
        </tr>
        <tr>
            <td height="71" valign="middle" background="../images/mail_leftbg.gif">
                &nbsp;
            </td>
            <td valign="top" bgcolor="#F7F8F9">
                <table width="100%" height="138" border="0" cellpadding="0" cellspacing="0">
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
                                        <span class="left_txt2">在这里，您可以查询到员工的基本信息</span><span class="left_txt2">！</span><br>
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
                                            <asp:Label ID="lblStaffID" runat="server" Text="员工编号：" Width="77px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStaffID" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbStaffName" runat="server" Text="员工姓名：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStaffName" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="查询" Width="80px" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnStaffAdd" runat="server" Text="添加" Width="80px" OnClick="btnStaffAdd_Click" />
                                        </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                            <asp:CheckBox ID="Chb_ChooseAll" runat="server" CssClass="left_txt" 
                                                Text="显示所有状态员工"/>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_txt">
                            &nbsp; 显示合同数据信息：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="gvwStaff" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                DataKeyNames="StaffID" ForeColor="Black" GridLines="Horizontal" OnRowCommand="gvwStaff_RowCommand"
                                AllowPaging="True" OnPageIndexChanging="gvwStaff_PageIndexChanging" PageSize="8"
                                Font-Size="Small" AllowSorting="True" OnSorting="gvwStaff_Sorting" 
                                BackColor="White" BorderColor="#999999" BorderStyle="Groove" 
                                BorderWidth="2px">
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="StaffID" HeaderText="员工编号" SortExpression="StaffID" />
                                    <asp:TemplateField HeaderText="员工姓名" SortExpression="StaffName">
                                        <ItemTemplate>
                                            <%# Eval("StaffName") %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="密码">
                                        <ItemTemplate>
                                            <%# Eval("Password") %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="出生日期" SortExpression="Birthday">
                                        <ItemTemplate>
                                            <%# Eval("Birthday")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="性别">
                                        <ItemTemplate>
                                            <%# Eval("StaffSex").ToString() == "0" ? "男" : "女"%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="联系电话">
                                        <ItemTemplate>
                                            <%# Eval("Phone") %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="电子邮件">
                                        <ItemTemplate>
                                            <%# Eval("Email")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="职位" DataField="PostID" Visible="False" />
                                    <asp:BoundField HeaderText="直线上司" DataField="DirectlyID" Visible="False" />
                                    <asp:BoundField DataField="EmployeeDate" HeaderText="入职日期" />
                                    <asp:TemplateField HeaderText="权限模块">
                                        <ItemTemplate>
                                            <%# Eval("Authority")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态判断">
                                        <ItemTemplate>
                                            <%# Eval("Enable").ToString() == "0" ? "允许" : "禁用"%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="省份">
                                        <ItemTemplate>
                                            <%# Eval("CompanyProvice")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="StaffProperty" HeaderText="员工属性" />
                                    <asp:BoundField DataField="LoginName" HeaderText="登录名" />
                                    <asp:TemplateField HeaderText="修改">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnUpdate" runat="server" CommandArgument='<%# Eval("StaffID") %>'
                                                CommandName="Update">更新</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <PagerTemplate>
                                    <table>
                                        <tr>
                                            <td style="text-align: right">
                                                第<asp:Label ID="lblPageIndex" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>"></asp:Label>页
                                                共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount %>"></asp:Label>页
                                                <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                    CommandName="Page" Text="首页" ForeColor="White"></asp:LinkButton>
                                                <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                    CommandName="Page" Text="上一页" ForeColor="White"></asp:LinkButton>
                                                <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                    CommandName="Page" Text="下一页" ForeColor="White"></asp:LinkButton>
                                                <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                    CommandName="Page" Text="尾页" ForeColor="White"></asp:LinkButton>
                                                <asp:TextBox ID="txtNewPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1%>"
                                                    Width="20px"></asp:TextBox>
                                                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                    CommandName="Page" Text="GO" ForeColor="White"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_txt">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td height="71" valign="middle" background="../images/mail_rightbg.gif">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="middle" background="../images/mail_leftbg.gif">
                <img src="../images/buttom_left2.gif" width="17" height="17" />
            </td>
            <td height="17" valign="top" background="../images/buttom_bgs.gif">
                <img src="../images/buttom_bgs.gif" width="17" height="17" />
            </td>
            <td background="../images/mail_rightbg.gif">
                <img src="../images/buttom_right2.gif" width="16" height="17" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
