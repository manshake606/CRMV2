<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputCustomer .aspx.cs"
    Inherits="CRMWebServer.InputCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息添加</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function CheckBlank() {
            var customerName = document.getElementById("<%=txtCustomerName %>");

            if (carategory.value == "1") {
                if (customerName.value = "") {
                    alert("\n请填写客户姓名！");
                }
            }
        }
        function showCalendarEnd() {
            document.getElementById("CalendarEnd").style.display = 'block';
        }
    </script>

    <style type="text/css">
        #CalendarStart
        {
            display: none;
        }
        #CalendarEnd
        {
            display: none;
        }
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #F8F9FA;
        }
        #ddjf
        {
            width: 51px;
        }
        .style30
        {
            height: 30px;
        }
        .style32
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 30px;
            width: 97px;
        }
        .style33
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            width: 97px;
        }
        .style35
        {
            width: 38px;
        }
        .style36
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            font-weight: bold;
            color: #333333;
            width: 477px;
        }
        .style37
        {
            width: 192px;
        }
        .style38
        {
            height: 30px;
            width: 192px;
        }
        .style39
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                                    <div class="titlebt">
                                        客户信息录入</div>
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
                    <table width="100%" height="138" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="13" valign="top">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="left_txt">
                                            当前位置：客户基本信息录入
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
                                                        <span class="left_txt2">本页面负责单个添加客户的信息</span><span class="left_txt3"></span><span
                                                            class="left_txt2"></span><br>
                                                        <span class="left_txt2"></span><span class="left_txt3"></span><span class="left_txt2">
                                                        </span><span class="left_txt3"></span><span class="left_txt2"></span>
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
                                                    <td class="style36" style="width: 45%">
                                                        &nbsp;&nbsp;&nbsp;客户基本信息
                                                    </td>
                                                    <td class="left_bt2" style="width: 55%">
                                                        &nbsp;&nbsp;客户业务信息录入 >
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="left_txt" width="15%" align="right" style="width: 15%">
                                                        客户姓名：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style37" style="width: 27%">
                                                        <div style="color: red">
                                                            <asp:TextBox ID="txtCustomerName" runat="server" Width="86px" MaxLength="6"></asp:TextBox>&nbsp;&nbsp;
                                                            *
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="true"  InitialValue =""
                                                                ControlToValidate="txtCustomerName" ErrorMessage="客户姓名不能为空"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td class="style32" align="right" style="width: 15%" >
                                                        客户重要性：
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="37%" class="style30" >
                                                        <asp:DropDownList ID="DDCustomerImportance" AutoPostBack="false" runat="server">
                                                            <asp:ListItem Enabled="true">一般</asp:ListItem>
                                                            <asp:ListItem>不重要</asp:ListItem>
                                                            <asp:ListItem>重要</asp:ListItem>
                                                            <asp:ListItem>特别重要</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right">
                                                        英文名：
                                                    </td>
                                                    <td width="3%">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" class="style37">
                                                        <asp:TextBox ID="txtEnglishName" runat="server" Width="83px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">
                                                        联系状态：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:DropDownList ID="DDLContactState" AutoPostBack="false" runat="server">
                                                            <asp:ListItem>未联系</asp:ListItem>
                                                            <asp:ListItem>待联系</asp:ListItem>
                                                            <asp:ListItem>已联系</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right" bgcolor="#f2f2f2">
                                                        客户性别：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style37">
                                                        <asp:DropDownList AutoPostBack="false" ID="DDSex" runat="server">
                                                            <asp:ListItem>男</asp:ListItem>
                                                            <asp:ListItem>女</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td height="30" class="style33" align="right">
                                                        决策人：
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30">
                                                        <asp:DropDownList ID="DDLPolicymaker" AutoPostBack="true" runat="server">
                                                            <asp:ListItem>本人</asp:ListItem>
                                                            <asp:ListItem>父亲</asp:ListItem>
                                                            <asp:ListItem>母亲</asp:ListItem>
                                                            <asp:ListItem>其他</asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtContactState" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right">
                                                        客户生日：
                                                    </td>
                                                    <td width="3%">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" class="style37">
                                                        <asp:TextBox ID="txtBirthday" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">
                                                        决策人姓名：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtPolicymakerName" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right" bgcolor="#f2f2f2">
                                                        客户年龄：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style37">
                                                        <asp:TextBox ID="txtAge" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="style33" align="right">
                                                        客户分类：
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30">
                                                        <asp:DropDownList ID="DDLCustomerClass" AutoPostBack="false" runat="server">
                                                            <asp:ListItem>未分类</asp:ListItem>
                                                            <asp:ListItem>短期潜在</asp:ListItem>
                                                            <asp:ListItem>长期潜在</asp:ListItem>
                                                            <asp:ListItem>意向不明</asp:ListItem>
                                                            <asp:ListItem>已经签约</asp:ListItem>
                                                            <asp:ListItem>已经流失</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right">
                                                        所在省份：
                                                    </td>
                                                    <td width="3%">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" class="style37">
                                                        <div style="color: red">
                                                            <asp:DropDownList ID="DDListCProvince" runat="server" AutoPostBack ="true"  OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp; *
                                                        </div>
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">
                                                        流失去向：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:DropDownList ID="DDLDrainTowards" AutoPostBack="false" runat="server">
                                                            <asp:ListItem>未流失</asp:ListItem>
                                                            <asp:ListItem>本地留学中介</asp:ListItem>
                                                            <asp:ListItem>外地留学中介</asp:ListItem>
                                                            <asp:ListItem>语言培训机构</asp:ListItem>
                                                            <asp:ListItem>学校统一办理</asp:ListItem>
                                                            <asp:ListItem>学生自己办理</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right" bgcolor="#f2f2f2">
                                                        所在城市：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style37">
                                                        <div style="color: Red">
                                                            <asp:DropDownList ID="DDListCCity" runat="server">
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp; *
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                ControlToValidate="DDListCCity" ErrorMessage="客户所在地区不能为空" InitialValue="城市"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td height="30" class="style33" align="right">
                                                        导入人：
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30">
                                                        <asp:TextBox ID="txtImportingPeople" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right">
                                                        客户电话：
                                                    </td>
                                                    <td width="3%">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" class="style37">
                                                        <asp:TextBox ID="txtPhone" runat="server" AutoPostBack="true" Width="86px" ></asp:TextBox>
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">
                                                        导入时间：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtImportingDate" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" align="right" bgcolor="#f2f2f2">
                                                        客户手机：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style37">
                                                        <div style="color: red">
                                                            <asp:TextBox ID="txtTelphone" runat="server" Width="86px" AutoPostBack="true" MaxLength="11"
                                                                ></asp:TextBox>
                                                            &nbsp; *
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                                                ControlToValidate="txtTelphone" ErrorMessage="客户手机必须为11位数字" 
                                                                onservervalidate="CustomValidator1_ServerValidate" 
                                                                ValidateEmptyText="True"></asp:CustomValidator>
                                                        </div>
                                                    </td>
                                                    <td height="30" class="style33" align="right">
                                                        客户学校名称：
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30">
                                                        <asp:TextBox ID="txtSname" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="left_txt" align="right">
                                                        备用手机：
                                                    </td>
                                                    <td width="3%" class="style30">
                                                        &nbsp;
                                                    </td>
                                                    <td class="style38">
                                                        <asp:TextBox ID="txtBackUpTel" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">
                                                        客户年级：
                                                    </td>
                                                    <td bgcolor="#f2f2f2" class="style35">
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtGrade" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="left_txt" align="right">
                                                        QQ号码：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style37">
                                                        <asp:TextBox ID="txtCQQ" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="style33" align="right">
                                                        客户专业：
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30">
                                                        <asp:TextBox ID="txtProfessionName" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right">
                                                        Email：
                                                    </td>
                                                    <td width="3%">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" class="style37">
                                                        <asp:TextBox ID="txtCemail" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">
                                                        被录取的国家：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtAdmissionCountry" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" height="30" align="right" bgcolor="#f2f2f2">
                                                        联系地址：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style37">
                                                        <asp:TextBox ID="txtCAddress" runat="server" Width="294px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="style33" align="right">
                                                        被录取的城市：
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30">
                                                        <asp:TextBox ID="txtAdmissionCity" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="left_txt" align="right">
                                                        其他联系人：
                                                    </td>
                                                    <td width="3%">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" class="style37">
                                                        <asp:TextBox ID="txtOtherContact" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">
                                                        客户被录取的学校名称：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtAdmissionSname" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f2f2f2" class="style39" align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2" class="style30">
                                                        &nbsp;
                                                    </td>
                                                    <td bgcolor="#f2f2f2" class="style38">
                                                        &nbsp;
                                                    </td>
                                                    <td class="style32" align="right">
                                                        客户被录取的专业：
                                                    </td>
                                                    <td width="3%" class="style30" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" class="style30">
                                                        <asp:TextBox ID="txtAdmissionProfessionName" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30"  class="left_txt" align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td height="30"  class="style37">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">
                                                        被录取日期：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtAdmissionDate" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="left_txt" align="right">
                                                        客户编号：
                                                    </td>
                                                    <td width="3%" bgcolor="#f2f2f2">
                                                        &nbsp;
                                                    </td>
                                                    <td height="30" bgcolor="#f2f2f2" class="style37">
                                                        <asp:Label ID="Label1" runat="server" Text="信息添加后自动生成"></asp:Label>
                                                    </td>
                                                    <td height="30" class="style33" align="right">
                                                        备注：
                                                    </td>
                                                    <td width="3%" >
                                                        &nbsp;
                                                    </td>
                                                    <td width="32%" height="30">
                                                        <asp:TextBox ID="txtRemark" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="3">
                                <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="nowtable">
                                    <tr>
                                        <td class="left_bt2">
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" colspan="3">
                                <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td  class="style32" align="right">客户重要性：</td>
                                                    <td class="style34" >&nbsp;</td>
                                                    <td width="32%" class="style30" >
                                                        <asp:DropDownList ID="DDCustomerImportance" AutoPostBack="false" runat="server">
                                                        <asp:ListItem Enabled ="true">一般</asp:ListItem>
                                                        <asp:ListItem>不重要</asp:ListItem>                                                        
                                                        <asp:ListItem>重要</asp:ListItem>                                                        
                                                        <asp:ListItem>特别重要</asp:ListItem>                                                       
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style31">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">联系状态：</td>
                                                    <td bgcolor="#f2f2f2" class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                         <asp:DropDownList ID="DDLContactState" AutoPostBack="false" runat="server">
                                                         <asp:ListItem>未联系</asp:ListItem>
                                                         <asp:ListItem>待联系</asp:ListItem>
                                                         <asp:ListItem>已联系</asp:ListItem>
                                                         </asp:DropDownList>                                                         
                                                    </td>
                                                    <td height="30" class="left_txt" bgcolor="#f2f2f2">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30"  class="style33" align="right">决策人：</td>
                                                    <td  class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" >
                                                         <asp:DropDownList ID="DDLPolicymaker" AutoPostBack="true" runat="server">
                                                         <asp:ListItem>本人</asp:ListItem>
                                                         <asp:ListItem>父亲</asp:ListItem>
                                                         <asp:ListItem>母亲</asp:ListItem>
                                                         <asp:ListItem>其他</asp:ListItem>
                                                         </asp:DropDownList> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                         <asp:TextBox  ID ="txtContactState" runat ="server"  Width ="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" >客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">决策人姓名：</td>
                                                    <td bgcolor="#f2f2f2" class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtPolicymakerName" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" bgcolor="#f2f2f2">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="style33" align="right">客户分类：</td>
                                                    <td class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" >
                                                         <asp:DropDownList ID="DDLCustomerClass" AutoPostBack="false" runat="server">
                                                         <asp:ListItem>未分类</asp:ListItem>
                                                         <asp:ListItem>短期潜在</asp:ListItem>
                                                         <asp:ListItem>长期潜在</asp:ListItem>
                                                         <asp:ListItem>意向不明</asp:ListItem>
                                                         <asp:ListItem>已经签约</asp:ListItem>
                                                         <asp:ListItem>已经流失</asp:ListItem>
                                                         </asp:DropDownList> 
                                                    </td>
                                                    <td height="30" class="left_txt" >客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">流失去向：</td>
                                                    <td bgcolor="#f2f2f2" class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                     <asp:DropDownList ID="DDLDrainTowards" AutoPostBack="false" runat="server">
                                                         <asp:ListItem>未流失</asp:ListItem>
                                                         <asp:ListItem>本地留学中介</asp:ListItem>
                                                         <asp:ListItem>外地留学中介</asp:ListItem>
                                                         <asp:ListItem>语言培训机构</asp:ListItem>
                                                         <asp:ListItem>学校统一办理</asp:ListItem>
                                                         <asp:ListItem>学生自己办理</asp:ListItem>
                                                         </asp:DropDownList> 
                                                    </td>
                                                    <td height="30" class="left_txt" bgcolor="#f2f2f2">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="style33" align="right">导入人：</td>
                                                    <td  class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" >
                                                        <asp:TextBox ID="txtImportingPeople" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" >客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">导入时间：</td>
                                                    <td bgcolor="#f2f2f2" class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtImportingDate" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" bgcolor="#f2f2f2">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30"  class="style33" align="right">客户学校名称：</td>
                                                    <td  class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" >
                                                        <asp:TextBox ID="txtSname" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" >客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">客户年级：</td>
                                                    <td bgcolor="#f2f2f2" class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtGrade" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" bgcolor="#f2f2f2">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30"  class="style33" align="right">客户专业：</td>
                                                    <td  class="style35">&nbsp;</td>
                                                    <td width="32%" height="30">
                                                        <asp:TextBox ID="txtProfessionName" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" >客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">被录取的国家：</td>
                                                    <td bgcolor="#f2f2f2" class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtAdmissionCountry" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" bgcolor="#f2f2f2">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30"  class="style33" align="right">被录取的城市：</td>
                                                    <td class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" >
                                                        <asp:TextBox ID="txtAdmissionCity" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" >客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">客户被录取的学校名称：</td>
                                                    <td bgcolor="#f2f2f2" class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtAdmissionSname" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" bgcolor="#f2f2f2">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30"  class="style33" align="right">客户被录取的专业：</td>
                                                    <td  class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" >
                                                        <asp:TextBox ID="txtAdmissionProfessionName" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" >客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" bgcolor="#f2f2f2" class="style33" align="right">被录取日期：</td>
                                                    <td bgcolor="#f2f2f2" class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" bgcolor="#f2f2f2">
                                                        <asp:TextBox ID="txtAdmissionDate" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" bgcolor="#f2f2f2">客户的中文姓名</td>
                                                </tr>
                                                <tr>
                                                    <td height="30" class="style33" align="right">备注：</td>
                                                    <td  class="style35">&nbsp;</td>
                                                    <td width="32%" height="30" >
                                                        <asp:TextBox ID="txtRemark" runat="server" Width="86px"></asp:TextBox>
                                                    </td>
                                                    <td height="30" class="left_txt" >客户的中文姓名</td>
                                                </tr>
                                    </table>--%>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="45%" height="30" align="right">
                                <asp:Button ID="bxtSubmit" runat="server" Text="完成以上修改" OnClick ="ButtonSubmit" />
                            </td>
                            <td width="6%" height="30" align="right">
                                &nbsp;
                            </td>
                            <td width="49%" height="30">
                                <input type="reset" value="取消" name="B12" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <td background="..\images\mail_rightbg.gif">
            &nbsp;
        </td>
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
    </div>
    </form>
</body>
</html>
