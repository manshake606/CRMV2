<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffInformation.aspx.cs" Inherits="CRMWebServer.StaffInfo.StaffInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>财务管理页面</title>
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
                                合同管理</div>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="17" height="29" valign="top" background="../images/mail_rightbg.gif">
                <img src="../images/nav-right-bg.gif" width="16" height="29" />
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
                                        <span class="left_txt2">在这里，您可以根据您的网站要求，修改设置网站的</span><span class="left_txt3">基本参数</span><span
                                            class="left_txt2">！</span><br>
                                        <span class="left_txt2">包括</span><span class="left_txt3">网站名称，网址，网站备案号，联系方式，网站公告，关键词，风格</span><span
                                            class="left_txt2">等以及网站</span><span class="left_txt3">会员及等级积分设置</span><span class="left_txt2">。</span>
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
                                            <asp:Label ID="lblStaffID" runat="server" Text="员工编号：" Width="77px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStaffID" runat="server" Width="180px" CssClass="left_txt"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbStaffName" runat="server" Text="客户姓名：" Width="72px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStaffName" runat="server" Width="180px" CssClass="left_txt"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="查询" Width="80px" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbEndDate" runat="server" Text="结案日期：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndDate" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbSignDate" runat="server" Text="签约日期：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSignDate" runat="server" Width="180px" CssClass="left_txt"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Button ID="btnNewContract" runat="server" Text="添加" Width="80px" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
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
                        <td class="left_txt">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="left_txt">
                            显示合同数据信息：
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="StaffID">
                                <Columns>
                                    <asp:TemplateField HeaderText="员工姓名"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="密码"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="出生日期"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="性别"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="电话号码"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="电子邮件"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="员工职位"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="所属上级"></asp:TemplateField>
                                    <asp:BoundField DataField="EmployeeDate" HeaderText="入职日期" ReadOnly="True" />
                                    <asp:BoundField DataField="Authority" HeaderText="员工权限" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="所属公司"></asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
