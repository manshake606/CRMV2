<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffUpdate.aspx.cs" Inherits="CRMWebServer.Staff.StaffUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>更新员工信息</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />

    <script src="../js/Calendar3.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #F8F9FA;
        }
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            height: 26px;
        }
        .style2
        {
            height: 26px;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 26px;
        }
    </style>
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
                更新员工
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
                        <td valign="top">
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="left_txt">
                                        当前位置：更新员工信息页面
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
                                    <td>
                                        <table width="100%" height="55" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="10%" height="55" valign="middle">
                                                    <img src="../images/title.gif" width="54" height="55">
                                                </td>
                                                <td width="90%" valign="top">
                                                    <span class="left_txt2">在这里，您可以维护员工的基本信息</span><span
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
                                    <td>
                                        <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="nowtable">
                                            <tr>
                                                <td class="left_bt2">
                                                    &nbsp;&nbsp;&nbsp;更新员工基本信息
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    员工姓名：
                                                </td>
                                                <td width="3%" bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td width="32%" height="30" bgcolor="#f2f2f2">
                                                    <asp:TextBox ID="txtStaffName" runat="server"
                                                        ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RfvStaffName" runat="server" 
                                                        ControlToValidate="txtStaffName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="45%" height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    员工姓名</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    密码：
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    <asp:TextBox ID="txtPwd1" runat="server"  
                                                        ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="Rfvpwd1" runat="server" 
                                                        ControlToValidate="txtPwd1" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td height="30" class="left_txt">
                                                    输入登录密码</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    重复密码：
                                                </td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    <asp:TextBox ID="txtPwd2" runat="server"></asp:TextBox>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                        ControlToCompare="txtPwd1" ControlToValidate="txtPwd2" ErrorMessage="两次密码不一致"></asp:CompareValidator>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    确认密码</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2" >
                                                    出生日期：&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    <asp:TextBox ID="txtBirthday" runat="server" onclick="new Calendar().show(this);"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RevBirthday" runat="server" 
                                                        ControlToValidate="txtBirthday" ErrorMessage="格式不正确" 
                                                        ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td height="30" class="left_txt">
                                                    员工出生日期</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    性别：
                                                </td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    <asp:DropDownList ID="ddlSex" runat="server">
                                                        <asp:ListItem Value="0">男</asp:ListItem>
                                                        <asp:ListItem Value="1">女</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    员工性别</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#F7F8F9" class="left_txt2">
                                                    联系电话：
                                                </td>
                                                <td bgcolor="#F7F8F9">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#F7F8F9">
                                                    <asp:TextBox ID="txtStaffPhone" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RevPhone" runat="server" 
                                                        ControlToValidate="txtStaffPhone" ErrorMessage="格式不正确" 
                                                        ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td height="30" bgcolor="#F7F8F9" class="left_txt">
                                                    员工联系方式</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#F2F2F2" class="left_txt2">
                                                    电子邮件：
                                                </td>
                                                <td bgcolor="#F2F2F2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#F2F2F2">
                                                    <asp:TextBox ID="txtStaffEmail" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RevEmail" runat="server" 
                                                        ControlToValidate="txtStaffEmail" ErrorMessage="格式不正确" 
                                                        ValidationExpression="^\w+([-+]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </td>
                                                <td height="30" bgcolor="#F2F2F2" class="left_txt">
                                                    员工电子邮件</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    员工职位：
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    <asp:DropDownList ID="ddlPostID" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlPostID_SelectedIndexChanged">
                                                        <asp:ListItem Value="1">经理</asp:ListItem>
                                                        <asp:ListItem Value="2">见习文案</asp:ListItem>
                                                        <asp:ListItem Value="3">初级文案</asp:ListItem>
                                                        <asp:ListItem Value="4">文案主管</asp:ListItem>
                                                        <asp:ListItem Value="5">市场</asp:ListItem>
                                                        <asp:ListItem Value="6">见习顾问</asp:ListItem>
                                                        <asp:ListItem Value="7">初级顾问</asp:ListItem>
                                                        <asp:ListItem Value="8">中级顾问</asp:ListItem>
                                                        <asp:ListItem Value="9">主任顾问</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td height="30" class="left_txt">
                                                    该员工职位</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    直线上司：
                                                </td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    <asp:DropDownList ID="ddlDirectlyID" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    如果员工职位是经理，则该项选择默认空值</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    入职日期：
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    <asp:TextBox ID="txtEmployeeDate" runat="server" onclick="new Calendar().show(this);"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RevEmployeeDate" runat="server" 
                                                        ControlToValidate="txtEmployeeDate" ErrorMessage="格式不正确" 
                                                        ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td height="30" class="left_txt">
                                                    员工入职日期</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    权限模块：</td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" dir="ltr">
                                                    <asp:CheckBox ID="chk0" runat="server" Text="无模块权限" />
                                                    <asp:CheckBox ID="chk1" runat="server" Text="非经理操作用户信息权限" />
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" dir="ltr">
                                                    <asp:CheckBox ID="chk3" runat="server" Text="能导入用户信息" />
                                                    <asp:CheckBox ID="chk4" runat="server" Text="能批量导入用户信息" />
                                                    <asp:CheckBox ID="chk5" runat="server" Text="能查询文案归档信息" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    <asp:CheckBox ID="chk6" runat="server" Text="能上传文案归档信息" />
                                                    <asp:CheckBox ID="chk8" runat="server" Text="顾问指派权限" />
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    <asp:CheckBox ID="chk9" runat="server" Text="经理指派权限" />
                                                    <asp:CheckBox ID="chk10" runat="server" Text="顾问跟进权限" />
                                                    <asp:CheckBox ID="chk11" runat="server" Text="经理跟进权限" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    &nbsp;</td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    <asp:CheckBox ID="chk12" runat="server" Text="财务查看权限" />
                                                    <asp:CheckBox ID="chk13" runat="server" Text="财务操作权限" />
                                                    <asp:CheckBox ID="chk14" runat="server" Text="员工个人权限" />
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    <asp:CheckBox ID="chk15" runat="server" Text="管理员权限" />
                                                    <asp:CheckBox ID="chk16" runat="server" Text="日志查看权限" />
                                                    <asp:CheckBox ID="chk17" runat="server" Text="日志修改权限" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    <asp:CheckBox ID="chk7" runat="server" Text="文案指派权限" />
                                                    <asp:CheckBox ID="chk2" runat="server" Text="经理操作用户信息权限" />
                                                </td>
                                                <td height="30">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    公司所在省份：</td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    <asp:DropDownList ID="DDListCProvince" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="DDListCProvince_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    公司所在省份</td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="left_txt2">
                                                    &nbsp;公司所在城市：</td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DDListCCity" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td bgcolor="#f2f2f2" class="left_txt">
                                                    公司所在城市</td>
                                            </tr>
                                            <tr>
                                                <td align="right" bgcolor="#f2f2f2" class="style1">
                                                    &nbsp;是否允许登录：</td>
                                                <td bgcolor="#f2f2f2" class="style2">
                                                    &nbsp;
                                                </td>
                                                <td bgcolor="#f2f2f2" class="style2">
                                                    <asp:DropDownList ID="ddlLogin" runat="server">
                                                        <asp:ListItem Value="0">是</asp:ListItem>
                                                        <asp:ListItem Value="1">否</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td bgcolor="#f2f2f2" class="style3">
                                                    是是否允许登录系统，0表示允许，1表示禁用</td>
                                            </tr> 
                                            <tr>
                                                <td align="right" bgcolor="#f2f2f2" class="style1">
                                                    &nbsp;员工属性：</td>
                                                <td bgcolor="#f2f2f2" class="style2">
                                                    &nbsp;
                                                </td>
                                                <td bgcolor="#f2f2f2" class="style2">
                                                    <asp:DropDownList ID="ddlProperty" runat="server">
                                                        <asp:ListItem Value="0">R</asp:ListItem>
                                                        <asp:ListItem Value="1">S</asp:ListItem>
                                                        <asp:ListItem Value="2">T</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td bgcolor="#f2f2f2" class="style3">
                                                    R代表正式员工，S代表实习生，T代表临时员工</td>
                                            </tr>  
                                            <tr>
                                                <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    员工登录名：
                                                </td>
                                                <td width="3%" bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td width="32%" height="30" bgcolor="#f2f2f2">
                                                    <asp:TextBox ID="txtLoginName" runat="server"
                                                        ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RfvLoginName" runat="server" 
                                                        ControlToValidate="txtLoginName" ErrorMessage="*" 
                                                        ValidationGroup="ValidationGroup1"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="45%" height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    员工登录名，验证用户登录系统</td>
                                            </tr>    
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="50%" height="30" align="right">
                                    </td>
                                    <td width="6%" height="30" align="right">
                                        &nbsp;
                                    </td>
                                    <td width="44%" height="30">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" height="30" align="right">
                                        &nbsp;<asp:Button ID="btnConfirm" runat="server" Text="确定" 
                                            onclick="btnConfirm_Click" />
                                    </td>
                                    <td width="6%" height="30" align="right">
                                        &nbsp;
                                    </td>
                                    <td width="44%" height="30">
                                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回" 
                                            onclick="btnReturn_Click" />
                                    </td>
                                    <td height="30" colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
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
