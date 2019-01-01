<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoDetails.aspx.cs"
    Inherits="CRMWebServer.Customer.CustomerInfoDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户详细</title>

    <script type="text/javascript" src="../js/Calendar3.js">
        

        
    </script>
    
    <script type="text/javascript" language="javascript">
        function secBoard(n) {
            for (i = 0; i < secTable.cells.length; i++)
                secTable.cells[i].className = "sec1";
            secTable.cells[n].className = "sec2";
            for (i = 0; i < mainTable.tBodies.length; i++)
                mainTable.tBodies[i].style.display = "none";
            mainTable.tBodies[n].style.display = "block";
        }
                                            
                                            
                                            
   </script>

    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
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
            color: #666666;
            height: 35px;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 35px;
            width: 23%;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 35px;
            width: 298px;
        }
        .style4
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            width: 100px;
        }
        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            height: 30px;
        }
        .style6
        {
            height: 30px;
        }
        .style7
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 30px;
        }
        .style8
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 35px;
            width: 5%;
        }
        .style9
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 35px;
            width: 14%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="18" valign="top" background="../images/mail_leftbg.gif">
                <img src="../images/left-top-right.gif" width="18" height="29" />
            </td>
            <td valign="top" background="../images/content-bg.gif">
                <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg"
                    id="table2">
                    <tr>
                        <td height="31">
                            <div class="titlebt">
                                客户详细
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="16" valign="top" background="images/mail_rightbg.gif">
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
                        <td valign="top">
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="left_txt">
                                        当前位置：基本设置
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
                                    <td>

                                        

                                        <!--HTML菜单导航-->
                                        <table width="72%" border="0" cellpadding="0" cellspacing="0" id="secTable">
                                            <tbody>
                                                <tr align="middle" height="20">
                                                    <td align="center" class="sec2" onclick="secBoard(0)">
                                                        客户基本信息
                                                    </td>
                                                    <td align="center" class="sec1" onclick="secBoard(1)">
                                                        意向信息
                                                    </td>
                                                    <td align="center" class="sec1" onclick="secBoard(2)">
                                                        能力测验</td>
                                                    <td align="center" class="sec1" onclick="secBoard(3)">
                                                        学校成绩排名
                                                    </td>
                                                    <td align="center" class="sec1" onclick="secBoard(4)">
                                                        家庭信息
                                                    </td>
                                                    <td align="center" class="sec1" onclick="secBoard(5)">
                                                        录取信息
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table class="main_tab" id="mainTable" cellspacing="0" cellpadding="0" width="100%"
                                            border="0">
                                            <!--客户基本信息-->
                                            <tbody style="display: block">
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                        </asp:ScriptManager>
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <table width="98%" height="133" border="0" cellpadding="0" cellspacing="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td bgcolor="#FAFBFC">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="100%" height="25" bgcolor="#FAFBFC">
                                                                                <table width="98%" height="133" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td height="5" colspan="2">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td bgcolor="#FAFBFC">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="100%" bgcolor="#FAFBFC">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td width="25%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            客户编号：
                                                                                                        </td>
                                                                                                        <td width="30%" bgcolor="#f2f2f2" align="left">
                                                                                                            <asp:TextBox ID="txtCustomerID" runat="server" Enabled="False"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="10%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            客户姓名：
                                                                                                        </td>
                                                                                                        <td width="25%" height="30" align="left" bgcolor="#f2f2f2">
                                                                                                            <div style="color: red">
                                                                                                                <asp:TextBox ID="txtCustomerNmae" runat="server" ValidationGroup="ss"></asp:TextBox>*</div>
                                                                                                            <asp:RequiredFieldValidator ID="RFVCustomerName" runat="server" ErrorMessage="客户姓名不能为空"
                                                                                                                CssClass="left_txt" ControlToValidate="txtCustomerNmae" ValidationGroup="A1"
                                                                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="30" align="right" class="left_txt2">
                                                                                                            英文名字：
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtCustomerEnglishName" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            出生日期：
                                                                                                        </td>
                                                                                                        <td height="30" align="left" class="left_txt">
                                                                                                            <asp:TextBox ID="txtCustomerBirsthday" runat="server" onclick="new Calendar().show(this);"
                                                                                                                ValidationGroup="ss" ontextchanged="txtCustomerBirsthday_TextChanged"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="REVStarttime" runat="server" ControlToValidate="txtCustomerBirsthday"
                                                                                                                ErrorMessage="时间格式有误" ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"
                                                                                                                CssClass="left_txt"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            性别：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            <asp:Panel ID="plRBGroup" runat="server">
                                                                                                                &nbsp;&nbsp;
                                                                                                                <asp:RadioButton ID="rbMale" runat="server" Text="男" GroupName="plRBGroup" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                <asp:RadioButton ID="rbFemle" runat="server" Text="女" GroupName="plRBGroup" />
                                                                                                            </asp:Panel>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            年龄：
                                                                                                        </td>
                                                                                                        <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                                                                                                            <asp:TextBox ID="txtAge" runat="server" ReadOnly="True"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="30" align="right" class="left_txt2">
                                                                                                            手机：
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <div style="color: red">
                                                                                                                <asp:TextBox ID="txtTelPhone" runat="server" ValidationGroup="ss"></asp:TextBox>*</div>
                                                                                                            <asp:RegularExpressionValidator ID="REVTel" runat="server" ControlToValidate="txtTelPhone"
                                                                                                                ErrorMessage="客户手机格式不正确" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$" CssClass="left_txt"
                                                                                                                Display="Dynamic" ValidationGroup="A1"></asp:RegularExpressionValidator>
                                                                                                            <asp:RequiredFieldValidator ID="REVtelphone" runat="server" ErrorMessage="手机号不能为空"
                                                                                                                CssClass="left_txt" ControlToValidate="txtTelPhone" Display="Dynamic" ValidationGroup="A1"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            固定电话：
                                                                                                        </td>
                                                                                                        <td height="30" align="left" class="left_txt">
                                                                                                            <asp:TextBox ID="txtCellPhone" runat="server" ValidationGroup="ss"></asp:TextBox><asp:RegularExpressionValidator
                                                                                                                ID="REVPhone" runat="server" ControlToValidate="txtCellPhone" ErrorMessage="电话格式不正确"
                                                                                                                ValidationExpression="^(\d{3,4}-)?\d{6,8}$" CssClass="left_txt"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            备用手机：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left" bgcolor="#f2f2f2">
                                                                                                            <asp:TextBox ID="txtBackUpCellPhone" runat="server" ValidationGroup="ss"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="REVBackupTel" runat="server" ControlToValidate="txtBackUpCellPhone"
                                                                                                                ErrorMessage="备用手机格式不正确" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$" CssClass="left_txt"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            城市首字母：
                                                                                                        </td>
                                                                                                        <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                                                                                                            <asp:TextBox ID="txtCityLetter" runat="server" Enabled="False"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="20" align="right" class="left_txt2">
                                                                                                            所在省份：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left">
                                                                                                            <div style="color: red">
                                                                                                                <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                                                                                                                    AutoPostBack="True" ValidationGroup="ss">
                                                                                                                </asp:DropDownList>
                                                                                                                *</div>
                                                                                                            <asp:RequiredFieldValidator ID="RFVProvince" runat="server" ControlToValidate="ddlProvince"
                                                                                                                ErrorMessage="客户所在省份不能为空" InitialValue="省份" CssClass="left_txt" ValidationGroup="A1"
                                                                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            所在城市：
                                                                                                        </td>
                                                                                                        <td width="42%" height="30" align="left">
                                                                                                            <div style="color: red">
                                                                                                                <asp:DropDownList ID="ddlCity" runat="server" ValidationGroup="ss">
                                                                                                                </asp:DropDownList>
                                                                                                                *</div>
                                                                                                            <asp:RequiredFieldValidator ID="RFVCity" runat="server" ControlToValidate="ddlCity"
                                                                                                                ErrorMessage="客户所在地区不能为空" InitialValue="城市" CssClass="left_txt" ValidationGroup="A1"
                                                                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            QQ：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left" bgcolor="#f2f2f2">
                                                                                                            <asp:TextBox ID="txtQQ" runat="server" ValidationGroup="ss"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="REVQQ" runat="server" ControlToValidate="txtQQ"
                                                                                                                ErrorMessage="不正确的QQ号" ValidationExpression="^[0-9]*$" CssClass="left_txt"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            邮箱：
                                                                                                        </td>
                                                                                                        <td width="42%" align="left" height="30" bgcolor="#f2f2f2">
                                                                                                            <asp:TextBox ID="txtEmail" runat="server" Width="199px" ValidationGroup="ss"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="REVCmail" runat="server" ControlToValidate="txtEmail"
                                                                                                                CssClass="left_txt" ErrorMessage="请输入正确的邮箱地址" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="30" align="right" class="left_txt2">
                                                                                                            联系人地址：
                                                                                                        </td>
                                                                                                        <td colspan="3" align="left">
                                                                                                            <asp:TextBox ID="txtCustomoerAddress" runat="server" Width="572px"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            其他联系人：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left" bgcolor="#f2f2f2">
                                                                                                            <asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="10%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            联系人电话：
                                                                                                        </td>
                                                                                                        <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                                                                                                            <asp:TextBox ID="txtContactPersonTel" runat="server" ValidationGroup="ss"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="REVotherPhone" runat="server" ControlToValidate="txtContactPersonTel"
                                                                                                                CssClass="left_txt" ErrorMessage="电话格式不正确" ValidationExpression="^(\d{3,4}-)?\d{6,8}$|^1[3|4|5|8][0-9]\d{4,8}$"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="30" align="right" class="left_txt2">
                                                                                                            决策人与之关系：
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtRelationshipWithC" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            决策人姓名：
                                                                                                        </td>
                                                                                                        <td height="30" align="left" class="left_txt">
                                                                                                            <asp:TextBox ID="txtPolicymakerName" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" align="right" bgcolor="#f2f2f2" class="style5">
                                                                                                            客户分类：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left" bgcolor="#f2f2f2" class="style6">
                                                                                                            <asp:DropDownList ID="ddlCustomerClass" runat="server" Width="126px" AutoPostBack="True">
                                                                                                                <asp:ListItem Value="0">未分类</asp:ListItem>
                                                                                                                <asp:ListItem Value="1">短期潜在</asp:ListItem>
                                                                                                                <asp:ListItem Value="2">长期潜在</asp:ListItem>
                                                                                                                <asp:ListItem Value="3">意向不明</asp:ListItem>
                                                                                                                <asp:ListItem Value="4">已经签约</asp:ListItem>
                                                                                                                <asp:ListItem Value="5">已经流失</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td width="8%" align="right" bgcolor="#f2f2f2" class="style5">
                                                                                                            流失去向：
                                                                                                        </td>
                                                                                                        <td width="42%" align="left" bgcolor="#f2f2f2" class="style7">
                                                                                                            <asp:DropDownList ID="ddlDrainTowards" runat="server" Width="126px">
                                                                                                                <asp:ListItem Value="0">未流失</asp:ListItem>
                                                                                                                <asp:ListItem Value="1">本地留学中介</asp:ListItem>
                                                                                                                <asp:ListItem Value="2">外地留学中介</asp:ListItem>
                                                                                                                <asp:ListItem Value="3">语言培训机构</asp:ListItem>
                                                                                                                <asp:ListItem Value="4">学校统一办理</asp:ListItem>
                                                                                                                <asp:ListItem Value="5">学校自己办理</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="30" align="right" class="left_txt2">
                                                                                                            客户原学校：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left">
                                                                                                            <asp:TextBox ID="txtOldSchoolName" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            现学习阶段：
                                                                                                        </td>
                                                                                                        <td height="20" align="left" class="left_txt">
                                                                                                            <asp:TextBox ID="txtOldGrade" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" height="20" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            专业：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left" bgcolor="#f2f2f2">
                                                                                                            <asp:TextBox ID="txtOldProfessional" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            客户重要性：
                                                                                                        </td>
                                                                                                        <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                                                                                                            <asp:DropDownList ID="ddlCustomerImportant" runat="server" Width="126px" AutoPostBack="True">
                                                                                                                <asp:ListItem Value="1">一般</asp:ListItem>
                                                                                                                <asp:ListItem Value="0">不重要</asp:ListItem>
                                                                                                                <asp:ListItem Value="2">重要</asp:ListItem>
                                                                                                                <asp:ListItem Value="3">特别重要</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" height="30" align="right" class="left_txt2">
                                                                                                            客户来源：
                                                                                                        </td>
                                                                                                        <td width="30%" align="left">
                                                                                                            <asp:DropDownList ID="ddlDataResource" runat="server" Width="126px">
                                                                                                                <asp:ListItem Value="0">来源不明</asp:ListItem>
                                                                                                                <asp:ListItem Value="1">名单预约</asp:ListItem>
                                                                                                                <asp:ListItem Value="2">客户推荐</asp:ListItem>
                                                                                                                <asp:ListItem Value="3">移民推荐</asp:ListItem>
                                                                                                                <asp:ListItem Value="4">常州推荐</asp:ListItem>
                                                                                                                <asp:ListItem Value="5">主动上门</asp:ListItem>
                                                                                                                <asp:ListItem Value="6">网络来源</asp:ListItem>
                                                                                                                <asp:ListItem Value="7">个人渠道</asp:ListItem>
                                                                                                                <asp:ListItem Value="9">环球雅思</asp:ListItem>
                                                                                                                <asp:ListItem Value="10">朗阁培训</asp:ListItem>
                                                                                                                <asp:ListItem Value="11">星马教育</asp:ListItem>
                                                                                                                <asp:ListItem Value="12">三立教育</asp:ListItem>
                                                                                                                <asp:ListItem Value="8">其他语言渠道</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            推荐人：
                                                                                                        </td>
                                                                                                        <td width="42%" height="30" align="left" class="left_txt">
                                                                                                            <asp:TextBox ID="txtRecommendation" runat="server" ValidationGroup="ss"></asp:TextBox>
                                                                                                            <asp:CustomValidator ID="CVReference" runat="server" ControlToValidate="txtRecommendation"
                                                                                                                ErrorMessage="请填写推荐人"></asp:CustomValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            数据来源：
                                                                                                        </td>
                                                                                                        <td align="left" bgcolor="#f2f2f2">
                                                                                                            <asp:TextBox ID="txtDataFrom" runat="server" ValidationGroup="ss"></asp:TextBox>
                                                                                                            <asp:CustomValidator ID="CVFromData" runat="server" ControlToValidate="txtDataFrom"
                                                                                                                ErrorMessage="请填写数据来源" CssClass="left_txt2"></asp:CustomValidator>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            推荐人备注：
                                                                                                        </td>
                                                                                                        <td height="30" align="left" class="left_txt">
                                                                                                            <asp:TextBox ID="txtRecommendRemark" runat="server"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="30" align="right" class="left_txt2">
                                                                                                            导入人：
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtImportingPeople" runat="server" Enabled="False"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            导入时间：
                                                                                                        </td>
                                                                                                        <td height="30" align="left" class="left_txt">
                                                                                                            <asp:TextBox ID="txtImportingTime" runat="server" Enabled="False"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                            主要意向国家：
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="IntentionCountrytxt" runat="server" Enabled="False"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                          
                                                                                                            是否背景提升</td>
                                                                                                        <td height="30" align="left" class="left_txt">
                                                                                                            
                                                                                                            <asp:DropDownList ID="ddlCustomerImprove" runat="server" AutoPostBack="True" 
                                                                                                                Width="126px">
                                                                                                                <asp:ListItem Value="0">是</asp:ListItem>
                                                                                                                <asp:ListItem Value="1">否</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                            
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                            合同编号：
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtContractNum" runat="server" Enabled="False"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                          
                                                                                                           </td>
                                                                                                        <td height="30" align="left" class="left_txt">
                                                                                                            
                                                                                                            
                                                                                                            
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" height="50" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            备注：
                                                                                                        </td>
                                                                                                        <td width="30%" colspan="3" align="left" bgcolor="#f2f2f2">
                                                                                                            <asp:TextBox ID="txtRemark" runat="server" Width="568px" TextMode="MultiLine"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="20%" height="50" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                                                            工作经验：
                                                                                                        </td>
                                                                                                        <td width="30%" colspan="3" align="left" bgcolor="#f2f2f2">
                                                                                                            <asp:TextBox ID="txtWorkExperience" runat="server" Width="568px" TextMode="MultiLine"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="4" align="center" class="left_txt2">
                                                                                                            <asp:Button ID="btnCustomerInfoUpdate" runat="server" Text="完成以上修改" OnClick="btnCustomerInfoUpdate_Click"
                                                                                                                ValidationGroup="ss" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnDelete" 
                                                                                                                runat="server" Text="删除" Width="71px" onclick="BtnDelete_Click" />
                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                                    ID="btnCustomerInfoCancel" runat="server" Text="取消设置" OnClick="btnCustomerInfoCancel_Click" />
                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnBind" runat="server" 
                                                                                                                Text="一键绑定" onclick="BtnBind_Click" />
                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                            
                                                                                                            
                                                                                                            <asp:Button ID="BtnUnband" runat="server" Text="一键解绑" 
                                                                                                                onclick="BtnUnband_Click" />
                                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="5" colspan="2">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="5" colspan="2">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                                <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
                                                                                                    <tr align="left" class="nowtable">
                                                                                                        <td class="left_bt2" align="left">
                                                                                                            &nbsp;跟进信息列表
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="5" colspan="2">
                                                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <table width="98%" height="133" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                                            <tbody>
                                                                                                                <tr>
                                                                                                                    <td height="5" colspan="2">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td bgcolor="#FAFBFC">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td width="100%" height="25" bgcolor="#FAFBFC">
                                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                            <tr>
                                                                                                                                <td height="30">
                                                                                                                                    <table width="100%" height="89" border="0" cellpadding="0" cellspacing="0">
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" bgcolor="#f2f2f2" class="style1">
                                                                                                                                                &nbsp;
                                                                                                                                            </td>
                                                                                                                                            <td bgcolor="#f2f2f2" class="style1" width="100%" align="center">
                                                                                                                                                <asp:GridView ID="gv_showfollowupInfo" runat="server" CellPadding="3" ForeColor="Black"
                                                                                                                                                    GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="CSID" OnRowCancelingEdit="gv_showfollowupInfo_RowCancelingEdit"
                                                                                                                                                    OnRowEditing="gv_showfollowupInfo_RowEditing" OnRowUpdating="gv_showfollowupInfo_RowUpdating"
                                                                                                                                                    OnRowDataBound="gv_showfollowupInfo_RowDataBound" AllowPaging="True" OnPageIndexChanging="gv_showfollowupInfo_PageIndexChanging"
                                                                                                                                                    Width="934px" OnRowDeleting="gv_showfollowupInfo_RowDeleting" 
                                                                                                                                                    PageSize="30" AllowSorting="True"
                                                                                                                                                    OnSorting="gv_showfollowupInfo_Sorting" BackColor="White" 
                                                                                                                                                    BorderColor="#999999" BorderStyle="Groove" BorderWidth="1px">
                                                                                                                                                    <Columns>
                                                                                                                                                        <asp:TemplateField HeaderText="客户姓名">
                                                                                                                                                            <EditItemTemplate>
                                                                                                                                                                <asp:TextBox ID="txtCustomerName" runat="server" Enabled="False" Text='<%# bind("CustomerName") %>'></asp:TextBox>
                                                                                                                                                            </EditItemTemplate>
                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                <asp:Label ID="LabCustomerName" runat="server" Text='<%# Bind("CustomerName") %>'></asp:Label>
                                                                                                                                                            </ItemTemplate>
                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                        <asp:TemplateField HeaderText="跟进内容">
                                                                                                                                                            <EditItemTemplate>
                                                                                                                                                                <asp:TextBox ID="TxtCSContent" runat="server" Text='<%# Bind("CSContent") %>' TextMode="MultiLine"></asp:TextBox>
                                                                                                                                                            </EditItemTemplate>
                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                <asp:Label ID="LabCSContent" runat="server" Text='<%# Bind("CSContent") %>'></asp:Label>
                                                                                                                                                            </ItemTemplate>
                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                        <asp:TemplateField HeaderText="跟进日期" SortExpression="CSDate">
                                                                                                                                                            <EditItemTemplate>
                                                                                                                                                                <asp:TextBox ID="TxtCSDate" runat="server" Text='<%# Bind("CSDate") %>' onclick="new Calendar().show(this);"></asp:TextBox>
                                                                                                                                                            </EditItemTemplate>
                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                <asp:Label ID="LabCSDate" runat="server" Text='<%# Bind("CSDate") %>'></asp:Label>
                                                                                                                                                            </ItemTemplate>
                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                        <asp:TemplateField HeaderText="跟进员工">
                                                                                                                                                            <EditItemTemplate>
                                                                                                                                                                <asp:TextBox ID="txtStaffName" runat="server" Enabled="False" Text='<%# bind("StaffName") %>'></asp:TextBox>
                                                                                                                                                            </EditItemTemplate>
                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                <asp:Label ID="LabStaffName" runat="server" Text='<%# Bind("StaffName") %>'></asp:Label>
                                                                                                                                                            </ItemTemplate>
                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                        <asp:CommandField ShowEditButton="True" DeleteText="删除" EditText="修改" ShowDeleteButton="false"
                                                                                                                                                            UpdateText="更新" HeaderText="操作" />
                                                                                                                                                    </Columns>
                                                                                                                                                    <FooterStyle BackColor="#CCCCCC" />
                                                                                                                                                    <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                                                                                                                                                    <EmptyDataTemplate>
                                                                                                                                                        <asp:Label ID="LabEmpty" runat="server" Text="记录为空！！" CssClass="left_txt"></asp:Label>
                                                                                                                                                    </EmptyDataTemplate>
                                                                                                                                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                                                                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
                                                                                                                                            <td bgcolor="#f2f2f2" class="style1">
                                                                                                                                                &nbsp;
                                                                                                                                            </td>
                                                                                                                                            <td bgcolor="#f2f2f2" class="style1">
                                                                                                                                                &nbsp;
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                    </table>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td height="30">
                                                                                                                                    <span style="float: left">
                                                                                                                                        <input id="Button9" type="button" value="联系状态添加" onclick="show(this.value)" align="left" />
                                                                                                                                    </span>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td align="center" height="30">
                                                                                                                                    <table id="联系状态添加" border="0" cellpadding="0" cellspacing="0" style="display: none;"
                                                                                                                                        width="100%">
                                                                                                                                        <tr>
                                                                                                                                            <td height="30" align="right" class="left_txt2" width="10%">
                                                                                                                                                客户编号：
                                                                                                                                            </td>
                                                                                                                                            <td align="left" width="20%">
                                                                                                                                                <asp:TextBox ID="txtCSTMID" runat="server" Enabled="False"></asp:TextBox>
                                                                                                                                            </td>
                                                                                                                                            <td height="30" align="right" class="left_txt2" width="10%">
                                                                                                                                                客户姓名：
                                                                                                                                            </td>
                                                                                                                                            <td align="left" width="10%">
                                                                                                                                                <asp:TextBox ID="txtCSTMName" runat="server" Enabled="False"></asp:TextBox>
                                                                                                                                            </td>
                                                                                                                                            <td height="30" align="right" class="left_txt2" width="10%">
                                                                                                                                                联系时间：
                                                                                                                                            </td>
                                                                                                                                            <td align="left">
                                                                                                                                                <asp:TextBox ID="txtContactTime" runat="server" onclick="new Calendar().show(this);"
                                                                                                                                                    ValidationGroup="t"></asp:TextBox>
                                                                                                                                                <asp:RegularExpressionValidator ID="REVContactTime" runat="server" ControlToValidate="txtContactTime"
                                                                                                                                                    ErrorMessage="日期格式错误" ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"
                                                                                                                                                    CssClass="left_txt" ValidationGroup="t"></asp:RegularExpressionValidator>
                                                                                                                                                <asp:RequiredFieldValidator ID="RFVCSDate" runat="server" ControlToValidate="txtContactTime"
                                                                                                                                                    CssClass="left_txt" Display="Dynamic" ErrorMessage="请填写联系时间" ValidationGroup="t"></asp:RequiredFieldValidator>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td height="30" align="right" class="left_txt2">
                                                                                                                                                联系内容：
                                                                                                                                            </td>
                                                                                                                                            <td colspan="3" align="left">
                                                                                                                                                <asp:TextBox ID="txtContactContent" runat="server" Height="54px" TextMode="MultiLine"
                                                                                                                                                    Width="433px"></asp:TextBox>
                                                                                                                                            </td>
                                                                                                                                            <td colspan="2" align="left">
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td colspan="4" style="width: 100px">
                                                                                                                                                &nbsp;
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td colspan="2" align="right">
                                                                                                                                                <asp:Button ID="btnContactStateAdd" runat="server" Text="添加" OnClick="btnContactStateAdd_Click"
                                                                                                                                                    ValidationGroup="t" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                            </td>
                                                                                                                                            <td colspan="2" align="left">
                                                                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                                <asp:Button ID="btnContactCancel" runat="server" Text="取消" OnClick="btnContactCancel_Click" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                    </table>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td height="30">
                                                                                                                                    &nbsp;
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td height="5" colspan="2">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </tbody>
                                                                                                        </table>
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:AsyncPostBackTrigger ControlID="btnContactStateAdd" EventName="Click" />
                                                                                                        <asp:AsyncPostBackTrigger ControlID="btnContactCancel" EventName="Click" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlProvince" EventName="SelectedIndexChanged" />
                                                                <asp:AsyncPostBackTrigger ControlID="btnCustomerInfoUpdate" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="btnCustomerInfoCancel" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="ddlCustomerClass" EventName="SelectedIndexChanged" />
                                                                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="BtnUnband" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="ddlCustomerImportant" EventName="SelectedIndexChanged" />
                                                                
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <!--意向信息-->
                                            <tbody style="display: none">
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table width="98%" height="133" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td bgcolor="#FAFBFC">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="100%" height="25" bgcolor="#FAFBFC">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="30" align="center">
                                                                                            <table width="100%" height="89" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td bgcolor="#f2f2f2" class="style1" align="center">

                                                                                                        <script type="text/javascript">
                                                                                                            function show(id) {
                                                                                                                if (document.getElementById(id).style.display == "block")
                                                                                                                { document.getElementById(id).style.display = "none"; }
                                                                                                                else { document.getElementById(id).style.display = "block"; }
                                                                                                            }      
                                                                                                        </script>

                                                                                                        <%--visibility: hidden; display: none;--%>
                                                                                                        <asp:GridView ID="gvIntention" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                                                                            ForeColor="Black" GridLines="Horizontal" DataKeyNames="ITTID" OnRowCancelingEdit="gvIntention_RowCancelingEdit"
                                                                                                            OnRowDataBound="gvIntention_RowDataBound" OnRowEditing="gvIntention_RowEditing"
                                                                                                            OnRowUpdating="gvIntention_RowUpdating" OnRowDeleting="gvIntention_RowDeleting"
                                                                                                            Width="100%" PageSize="30" AllowSorting="True" 
                                                                                                            onsorting="gvIntention_Sorting" BackColor="White" BorderColor="#999999" 
                                                                                                            BorderStyle="Groove" BorderWidth="2px">
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="意向国家">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabIntentionCountry" runat="server" Text='<%# Bind("IntentionCountry") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtIntentionCountry" runat="server" Text='<%# Bind("IntentionCountry") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ControlStyle Width="60px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="意向城市">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabIntentionCity" runat="server" Text='<%# Bind("IntentionCity") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtIntentionCity" runat="server" Text='<%# Bind("IntentionCity") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="意向学校">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabIntentionSchool" runat="server" Text='<%# Bind("IntentionSchool") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtIntentionSchool" runat="server" Text='<%# Bind("IntentionSchool") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="意向专业">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabIntentionProfession" runat="server" Text='<%# Bind("IntentionProfession") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtIntentionProfession" runat="server" Text='<%# Bind("IntentionProfession") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="意向学习阶段">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabIntentionPhase" runat="server" Text='<%# Bind("IntentionPhase") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:DropDownList ID="DDLIntentionPhase" runat="server" Width="60px">
                                                                                                                            <asp:ListItem Selected="True" Value="0">未定</asp:ListItem>
                                                                                                                            <asp:ListItem Value="1">初中</asp:ListItem>
                                                                                                                            <asp:ListItem Value="3">高中</asp:ListItem>
                                                                                                                            <asp:ListItem Value="3">本科</asp:ListItem>
                                                                                                                            <asp:ListItem Value="4">硕士</asp:ListItem>
                                                                                                                            <asp:ListItem Value="5">博士</asp:ListItem>
                                                                                                                        </asp:DropDownList>
                                                                                                                        <asp:HiddenField ID="HidIntentionPhase" runat="server" Value='<%# bind("IntentionPhase") %>' />
                                                                                                                    </EditItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="意向优先级" SortExpression="BetterWantTo">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:DropDownList ID="DDLBetterWantTo" runat="server" Width="60px">
                                                                                                                            <asp:ListItem Selected="True" Value="0">主要</asp:ListItem>
                                                                                                                            <asp:ListItem Value="1">次要</asp:ListItem>
                                                                                                                        </asp:DropDownList>
                                                                                                                        <asp:HiddenField ID="Hidwant" runat="server" Value='<%# bind("BetterWantTo") %>' />
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabBetterWantTo" runat="server" Text='<%# Bind("BetterWantTo") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="意向出国时间">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtIntentiondate" runat="server" 
                                                                                                                            Text='<%# Bind("Intentiondate") %>' onclick="new Calendar().show(this);"></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Lab_intentiondate" runat="server" 
                                                                                                                            Text='<%# Bind("Intentiondate") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="备注">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:CommandField CancelText="取消" DeleteText="删除" EditText="修改" HeaderText="操作" ShowDeleteButton="True"
                                                                                                                    ShowEditButton="True" UpdateText="更新" />
                                                                                                            </Columns>
                                                                                                            <FooterStyle BackColor="#CCCCCC" />
                                                                                                            <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                                                                                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                                                                                        </asp:GridView>
                                                                                                    </td>
                                                                                                    <td bgcolor="#f2f2f2" class="style1">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            <span style="float: left">
                                                                                                <input id="btnAddIntention" type="button" value="意向添加" onclick="show(this.value)"
                                                                                                    align="middle" />
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" height="30">
                                                                                            <table id="意向添加" border="0" cellpadding="0" cellspacing="0" style="display: block;">
                                                                                                <tr>
                                                                                                    <td width="25%" height="30" align="right" class="left_txt2" style="width: 100px">
                                                                                                        意向国家：
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:TextBox ID="txtIntentionCountry" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="style4">
                                                                                                        意向城市：
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:TextBox ID="txtIntentionCity" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="25%" height="30" align="right" class="left_txt2" style="width: 100px">
                                                                                                        意向学校：
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:TextBox ID="txtIntentionSchool" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="style4">
                                                                                                        意向专业：
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:TextBox ID="txtIntentionProfessional" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                                                                                                                <tr>
                                                                                                    <td width="25%" height="30" align="right" class="left_txt2" style="width: 100px">
                                                                                                        意向出国日期：
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:TextBox ID="txtIntentiondate" runat="server" onclick="new Calendar().show(this);"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="style4">
                                                                                                        &nbsp;</td>
                                                                                                    <td style="width: 100px">
                                                                                                        &nbsp;</td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="25%" height="30" align="right" class="left_txt2" style="width: 100px">
                                                                                                        意向学习阶段：
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 100px">
                                                                                                        <asp:DropDownList ID="DDLIntentionPhase" runat="server" Width="127px">
                                                                                                            <asp:ListItem Value="0">未定</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">小学</asp:ListItem>
                                                                                                            <asp:ListItem Value="2">初中</asp:ListItem>
                                                                                                            <asp:ListItem Value="3">高中</asp:ListItem>
                                                                                                            <asp:ListItem Value="4">本科</asp:ListItem>
                                                                                                            <asp:ListItem Value="5">硕士</asp:ListItem>
                                                                                                            <asp:ListItem Value="6">博士</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="style4">
                                                                                                        意向优先级：
                                                                                                    </td>
                                                                                                    <td style="width: 100px" align="left">
                                                                                                        <asp:DropDownList ID="DDLBetterWantTo" runat="server" Width="128px">
                                                                                                            <asp:ListItem Value="0">主要</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">次要</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="25%" height="30" align="right" class="left_txt2" style="width: 100px">
                                                                                                        备注：
                                                                                                    </td>
                                                                                                    <td colspan="3" align="left" style="width: 100px">
                                                                                                        <asp:TextBox ID="txtIntentionRemark" runat="server" Height="43px" TextMode="MultiLine"
                                                                                                            Width="339px"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="4" style="width: 100px">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" align="right">
                                                                                                        <asp:Button ID="btnIntentionInsert" runat="server" Text="添加" OnClick="btnIntentionInsert_Click"
                                                                                                            OnClientClick="secBoard(1)" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                    </td>
                                                                                                    <td colspan="2" align="left">
                                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                        <asp:Button ID="btnIntentionCancel" runat="server" Text="取消" OnClick="btnIntentionCancel_Click" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnIntentionInsert" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="btnIntentionCancel" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <!--语言技能-->
                                            <tbody style="display: none">
                                                <tr>
                                                    <td valign="top" align="middle">
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table width="98%" height="133" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td bgcolor="#FAFBFC">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="100%" height="25" bgcolor="#FAFBFC">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            <table width="100%" height="89" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td bgcolor="#f2f2f2" class="style1" align="center">
                                                                                                        <asp:GridView ID="gvLanguageSkills" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                                            CellPadding="3" ForeColor="Black" GridLines="Horizontal" 
                                                                                                            DataKeyNames="LGID" OnRowCancelingEdit="gvLanguageSkills_RowCancelingEdit"
                                                                                                            OnRowDataBound="gvLanguageSkills_RowDataBound" OnRowDeleting="gvLanguageSkills_RowDeleting"
                                                                                                            OnRowEditing="gvLanguageSkills_RowEditing" 
                                                                                                            OnRowUpdating="gvLanguageSkills_RowUpdating" BackColor="White" 
                                                                                                            BorderColor="#999999" BorderStyle="Groove" BorderWidth="2px">
                                                                                                            <RowStyle HorizontalAlign="Center" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="测验名称">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtLGIName" runat="server" Text='<%# Bind("LGIName") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabLGIName" runat="server" Text='<%# Bind("LGIName") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="测验得分">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtScore" runat="server" Text='<%# Bind("Score") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabScore" runat="server" Text='<%# Bind("Score") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="导入时间">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtImportingDate" runat="server" Enabled="False" Text='<%# Bind("ImportingDate") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabImportingDate" runat="server" Text='<%# Bind("ImportingDate") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="备注">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtLGRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="LabLGRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:CommandField CancelText="取消" DeleteText="删除" EditText="修改" HeaderText="操作" ShowDeleteButton="True"
                                                                                                                    ShowEditButton="True" UpdateText="更新" />
                                                                                                            </Columns>
                                                                                                            <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
                                                                                                            <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                                                                                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                                                                                HorizontalAlign="Center" />
                                                                                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                                                                                        </asp:GridView>
                                                                                                    </td>
                                                                                                    <td bgcolor="#f2f2f2" class="style1">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            <span style="float: left">
                                                                                                <input id="Button8" type="button" value="测验添加" onclick="show(this.value)" align="left" />
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" height="30">
                                                                                            <table id="测验添加" border="0" cellpadding="0" cellspacing="0" style="display: none;">
                                                                                                <tr>
                                                                                                    <td width="25%" height="30" align="right" class="left_txt2" style="width: 100px">
                                                                                                        测验名称：
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:TextBox ID="txtLanguageName" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="style4">
                                                                                                        测验得分：
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:TextBox ID="txtLanguageScore" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="25%" height="30" align="right" class="left_txt2" style="width: 100px">
                                                                                                        备注：
                                                                                                    </td>
                                                                                                    <td colspan="3" align="left" style="width: 100px">
                                                                                                        <asp:TextBox ID="txtLanguageRemark" runat="server" Height="43px" TextMode="MultiLine"
                                                                                                            Width="339px"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="4" style="width: 100px">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" align="right">
                                                                                                        <asp:Button ID="btnLanguageAdd" runat="server" Text="添加" OnClick="btnLanguageAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                    </td>
                                                                                                    <td colspan="2" align="left">
                                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                        <asp:Button ID="btnLanguageCancel" runat="server" Text="取消" OnClick="btnLanguageCancel_Click" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnLanguageAdd" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="btnLanguageCancel" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <!--学校成绩排名-->
                                            <tbody style="display: none">
                                                <tr>
                                                    <td valign="top" align="middle">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table width="98%" height="133" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td bgcolor="#FAFBFC">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="100%" height="25" bgcolor="#FAFBFC">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            <table width="100%" height="89" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td width="30%" align="right" bgcolor="#FAFBFC" class="style1">
                                                                                                        在读学校：
                                                                                                    </td>
                                                                                                    <td align="left" bgcolor="#FAFBFC">
                                                                                                        <asp:TextBox ID="txtCurrentSchool" runat="server" Width="304px"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="30%" align="right" bgcolor="#FAFBFC" class="style1">
                                                                                                        专业：
                                                                                                    </td>
                                                                                                    <td align="left" bgcolor="#FAFBFC">
                                                                                                        <asp:TextBox ID="txtMajor" runat="server" Width="304px"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="30%" align="right" bgcolor="#FAFBFC" class="style1">
                                                                                                        学校平均成绩：
                                                                                                    </td>
                                                                                                    <td align="left" bgcolor="#FAFBFC">
                                                                                                        <asp:TextBox ID="txtAverageScore" runat="server" Width="304px" class="style1"></asp:TextBox>
                
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="30%" align="right" bgcolor="#FAFBFC" class="style1">
                                                                                                        学校成绩排名：
                                                                                                    </td>
                                                                                                    <td align="left" bgcolor="#FAFBFC">
                                                                                                        <asp:TextBox ID="txtSchoolRankings" runat="server" Width="304px"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="30%" align="right" bgcolor="#FAFBFC" class="style1">
                                                                                                        其他学习情况：
                                                                                                    </td>
                                                                                                    <td align="left" bgcolor="#FAFBFC">
                                                                                                        <asp:TextBox ID="txtOtherStudy" runat="server" Height="101px" TextMode="MultiLine"
                                                                                                            Width="601px">
                                                                                                        </asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" height="30">
                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                ID="btnStudiesUpdate" runat="server" Text="完成修改" OnClick="btnStudiesUpdate_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                    ID="btnStudiesCancel" runat="server" Text="清空" OnClick="btnStudiesCancel_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnStudiesUpdate" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="btnStudiesCancel" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <!--家庭信息-->
                                            <tbody style="display: none">
                                                <tr>
                                                    <td valign="top" align="middle">
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table width="98%" height="133" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td bgcolor="#FAFBFC">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="100%" height="25" bgcolor="#FAFBFC">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            <table width="100%" height="89" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td align="center" bgcolor="#f2f2f2" class="style1">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                    <td bgcolor="#f2f2f2" class="style1">
                                                                                                        <asp:GridView ID="gvFamilyInfo" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                                                                            ForeColor="Black" GridLines="Horizontal" Width="100%" DataKeyNames="FID" OnSelectedIndexChanging="gvFamilyInfo_SelectedIndexChanging"
                                                                                                            OnRowDataBound="gvFamilyInfo_RowDataBound" 
                                                                                                            OnRowDeleting="gvFamilyInfo_RowDeleting" BackColor="White" 
                                                                                                            BorderColor="#999999" BorderStyle="Groove" BorderWidth="2px" 
                                                                                                            HorizontalAlign="Center">
                                                                                                            <RowStyle HorizontalAlign="Center" />
                                                                                                            <Columns>
                                                                                                                <asp:BoundField DataField="ParentName" HeaderText="家长姓名" />
                                                                                                                <asp:BoundField DataField="Sex" HeaderText="性别" />
                                                                                                                <asp:BoundField DataField="ParentProvince" HeaderText="省份" />
                                                                                                                <asp:BoundField DataField="ParentCity" HeaderText="城市" />
                                                                                                                <asp:BoundField DataField="ParentBirthday" HeaderText="出生日期" />
                                                                                                                <asp:BoundField DataField="ParentMobilephone" HeaderText="手机" />
                                                                                                                <asp:BoundField DataField="ParentTelphone" HeaderText="电话" />
                                                                                                                <asp:BoundField DataField="ParentWorkUnit" HeaderText="工作单位" />
                                                                                                                <asp:BoundField DataField="ParentWorkPosition" HeaderText="担当职务" />
                                                                                                                <asp:BoundField DataField="ParentAge" HeaderText="年龄" />
                                                                                                                <asp:BoundField DataField="ParentInCome" HeaderText="年收入状况" />
                                                                                                                <asp:BoundField DataField="Relationship" HeaderText="亲属关系" />
                                                                                                                <asp:CommandField DeleteText="删除" EditText="修改" HeaderText="操作" SelectText="操作" ShowDeleteButton="True"
                                                                                                                    ShowSelectButton="True" UpdateText="更新" />
                                                                                                            </Columns>
                                                                                                            <FooterStyle BackColor="#CCCCCC" />
                                                                                                            <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                                                                                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                                                                                HorizontalAlign="Center" />
                                                                                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                                                                                        </asp:GridView>
                                                                                                    </td>
                                                                                                    <td bgcolor="#f2f2f2" class="style1">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                    <td bgcolor="#f2f2f2" class="style1">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            <span style="float: left">
                                                                                                <input id="btnFamily" type="button" value="家庭信息添加" onclick="show(this.value)" />
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" height="30" width="100%">
                                                                                            <table id="家庭信息添加" border="0" cellpadding="0" cellspacing="0" style="display: none;"
                                                                                                width="100%">
                                                                                                <tr>
                                                                                                    <td height="30" align="right" class="left_txt2" width="20%">
                                                                                                        家长姓名：
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <div style="color: red">
                                                                                                            <asp:TextBox ID="txtParentName" runat="server" ValidationGroup="A1"></asp:TextBox>*
                                                                                                        </div>
                                                                                                        <asp:RequiredFieldValidator ID="REVPFamily" runat="server" Display="Dynamic" CssClass="left_txt2"
                                                                                                            ControlToValidate="txtParentName" ErrorMessage="家长姓名不能为空!" ValidationGroup="A1"></asp:RequiredFieldValidator>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        性别：
                                                                                                    </td>
                                                                                                    <td align="left" class="left_txt2">
                                                                                                        <asp:RadioButton ID="rbnPMale" runat="server" Text="男" GroupName="ParentSex" />
                                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                        <asp:RadioButton ID="rbnPFeMale" runat="server" Text="女" GroupName="ParentSex" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        出生日期：
                                                                                                    </td>
                                                                                                    <td align="left" class="left_txt2">
                                                                                                        <asp:TextBox ID="txtParentBirthday" runat="server" onclick="new Calendar().show(this);"
                                                                                                            ValidationGroup="A1"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="REVPbirthday" runat="server" ControlToValidate="txtParentBirthday"
                                                                                                            ErrorMessage="出生日期格式错误" ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        手机：
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <div style="color: red">
                                                                                                            <asp:TextBox ID="txtParentCellPhone" runat="server" ValidationGroup="A1"></asp:TextBox>*<asp:RequiredFieldValidator
                                                                                                                ID="RFVPTel" runat="server" ControlToValidate="txtParentCellPhone" CssClass="left_txt2"
                                                                                                                Display="Dynamic" ErrorMessage="手机号不能为空" ValidationGroup="A1"></asp:RequiredFieldValidator>
                                                                                                            <asp:RegularExpressionValidator ID="REVrightTel" runat="server" ControlToValidate="txtParentCellPhone"
                                                                                                                CssClass="left_txt2" Display="Dynamic" ErrorMessage="手机号格式有误" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$"
                                                                                                                ValidationGroup="A1"></asp:RegularExpressionValidator>
                                                                                                        </div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        工作单位：
                                                                                                    </td>
                                                                                                    <td align="left" class="left_txt2">
                                                                                                        <asp:TextBox ID="txtParentWorkUnit" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        职位：
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:TextBox ID="txtParentPostion" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right" class="style5">
                                                                                                        省份：
                                                                                                    </td>
                                                                                                    <td align="left" class="style6">
                                                                                                        <div style="color: red">
                                                                                                            <asp:DropDownList ID="DDLPProvice" runat="server" Height="17px" AutoPostBack="True"
                                                                                                                OnSelectedIndexChanged="DDLPProvice_SelectedIndexChanged" ValidationGroup="A1">
                                                                                                            </asp:DropDownList>
                                                                                                            *</div>
                                                                                                        <asp:RequiredFieldValidator ID="RFVPProvince" runat="server" ControlToValidate="DDLPProvice"
                                                                                                            ErrorMessage="客户所在省份不能为空" InitialValue="省份" CssClass="left_txt" Display="Dynamic"
                                                                                                            ValidationGroup="A1"></asp:RequiredFieldValidator>
                                                                                                    </td>
                                                                                                    <td align="right" class="style5">
                                                                                                        城市：
                                                                                                    </td>
                                                                                                    <td align="left" class="style6">
                                                                                                        <div style="color: red">
                                                                                                            <asp:DropDownList ID="DDLParentCity" runat="server" AutoPostBack="True" ValidationGroup="A1"
                                                                                                                OnSelectedIndexChanged="DDLParentCity_SelectedIndexChanged">
                                                                                                            </asp:DropDownList>
                                                                                                            *<asp:RequiredFieldValidator ID="RFVPCity" runat="server" ControlToValidate="DDLParentCity"
                                                                                                                CssClass="left_txt" Display="Dynamic" ErrorMessage="客户所在地区不能为空" InitialValue="城市"
                                                                                                                ValidationGroup="A1"></asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        电话：
                                                                                                    </td>
                                                                                                    <td align="left" class="left_txt2">
                                                                                                        <asp:TextBox ID="txtParentTel" runat="server" ValidationGroup="A1"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="REVPPhone" runat="server" ControlToValidate="txtParentTel"
                                                                                                            CssClass="left_txt" ErrorMessage="电话格式不正确" ValidationExpression="^(\d{3,4}-)?\d{6,8}$"
                                                                                                            ValidationGroup="A1"></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        年龄：
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:TextBox ID="txtParentAge" runat="server" Enabled="False"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        QQ：
                                                                                                    </td>
                                                                                                    <td align="left" class="left_txt2">
                                                                                                        <asp:TextBox ID="txtParentQQ" runat="server" ValidationGroup="A1"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="REVPQQ" runat="server" ControlToValidate="txtParentQQ"
                                                                                                            CssClass="left_txt" ErrorMessage="不正确的QQ号" ValidationExpression="^[0-9]*$" ValidationGroup="A1"></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        邮箱：
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:TextBox ID="txtParentMail" runat="server" ValidationGroup="A1"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="REVPmail" runat="server" ControlToValidate="txtParentMail"
                                                                                                            CssClass="left_txt" ErrorMessage="请输入正确的邮箱地址" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                            ValidationGroup="A1"></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right" class="left_txt2">
                                                                                                        亲属关系：
                                                                                                    </td>
                                                                                                    <td align="left" class="left_txt2">
                                                                                                        <asp:TextBox ID="txtParentRelationship" runat="server" OnTextChanged="txtParentRelationship_TextChanged"
                                                                                                            ValidationGroup="A1"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="REVPRelationship" runat="server" ControlToValidate="txtParentRelationship"
                                                                                                            ErrorMessage="请填写亲属关系" ValidationGroup="A1"></asp:RequiredFieldValidator>
                                                                                                    </td>
                                                                                                    <td align="right" class="left_txt2">
                                                                                                        收入状况：
                                                                                                    </td>
                                                                                                    <td align="left" class="left_txt2">
                                                                                                        <asp:TextBox ID="txtParentIncome" runat="server"></asp:TextBox>
                                                                                                        万元/年
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        生日提醒：
                                                                                                    </td>
                                                                                                    <td align="left" class="left_txt2">
                                                                                                        <asp:DropDownList ID="DDLParentRemind" runat="server" AutoPostBack="True">
                                                                                                            <asp:ListItem Value="0">是</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">否</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                    </td>
                                                                                                    <td class="left_txt2" align="left">
                                                                                                        <asp:TextBox ID="txtFID" runat="server" Visible="False"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30" align="right" class="left_txt2">
                                                                                                        备注：
                                                                                                    </td>
                                                                                                    <td colspan="3" align="left" class="left_txt2">
                                                                                                        <asp:TextBox ID="txtParentRemark" runat="server" Height="43px" TextMode="MultiLine"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="4">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" align="right">
                                                                                                        <asp:Button ID="btnAddFamilyInfo" runat="server" Text="添加" OnClick="btnAddFamilyInfo_Click"
                                                                                                            ValidationGroup="A1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                    </td>
                                                                                                    <td colspan="2" align="left">
                                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                        <asp:Button ID="btnFamilyInfoCancel" runat="server" Text="取消" OnClick="btnFamilyInfoCancel_Click" />
                                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                        <asp:Button ID="ButCh" runat="server" OnClick="ButCh_Click" Text="转化" Enabled="False"
                                                                                                            ValidationGroup="A1" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnAddFamilyInfo" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="btnFamilyInfoCancel" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="DDLPProvice" EventName="SelectedIndexChanged" />
                                                                <asp:AsyncPostBackTrigger ControlID="ButCh" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="DDLParentCity" EventName="SelectedIndexChanged" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <!--录取信息-->
                                            <tbody style="display: none">
                                                <tr>
                                                    <td valign="top" align="middle">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table width="98%" height="133" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td bgcolor="#FAFBFC">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="100%" height="25" bgcolor="#FAFBFC">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            <table width="100%" height="89" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td width="46%" align="right" bgcolor="#FAFBFC" class="style3">
                                                                                                        被录取的国家名称：
                                                                                                    </td>
                                                                                                    <td align="left" bgcolor="#FAFBFC" class="style8">
                                                                                                        <asp:TextBox ID="txtAdmissionCountry" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td align="right" bgcolor="#FAFBFC" class="style9">
                                                                                                        被录取的城市名称：
                                                                                                    </td>
                                                                                                    <td width="36%" align="left" bgcolor="#FAFBFC" class="style1">
                                                                                                        <asp:TextBox ID="txtAdmissionCity" runat="server" Style="margin-left: 4px"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="46%" align="right" bgcolor="#FAFBFC" class="style3">
                                                                                                        被录取的学校名称：
                                                                                                    </td>
                                                                                                    <td align="left" bgcolor="#FAFBFC" class="style8">
                                                                                                        <asp:TextBox ID="txtAdmissionSchool" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td align="right" bgcolor="#FAFBFC" class="style9">
                                                                                                        被录取的专业名称：
                                                                                                    </td>
                                                                                                    <td width="36%" align="left" bgcolor="#FAFBFC" class="style1">
                                                                                                        <asp:TextBox ID="txtAdmissionProfessional" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="46%" align="right" bgcolor="#FAFBFC" class="style3">
                                                                                                        被录取的学习阶段：
                                                                                                    </td>
                                                                                                    <td align="left" bgcolor="#FAFBFC" class="style8">
                                                                                                        <asp:DropDownList ID="ddlAdmissionPhase" runat="server">
                                                                                                            <asp:ListItem Value="0">未定</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">初中</asp:ListItem>
                                                                                                            <asp:ListItem Value="2">高中</asp:ListItem>
                                                                                                            <asp:ListItem Value="3">本科</asp:ListItem>
                                                                                                            <asp:ListItem Value="4">硕士</asp:ListItem>
                                                                                                            <asp:ListItem Value="5">博士</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td align="right" bgcolor="#FAFBFC" class="style9">
                                                                                                        被录取的日期：
                                                                                                    </td>
                                                                                                    <td width="36%" align="left" bgcolor="#FAFBFC" class="style1">
                                                                                                        <asp:TextBox ID="txtAdmissionDate" runat="server" onclick="new Calendar().show(this);"
                                                                                                            ValidationGroup="m"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="REVAdmissionDate" runat="server" ControlToValidate="txtAdmissionDate"
                                                                                                            ErrorMessage="录取日期格式错误" ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"
                                                                                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                                                                                        <asp:RequiredFieldValidator ID="RFVAdmissionDate" runat="server" ControlToValidate="txtAdmissionDate"
                                                                                                            Display="Dynamic" ErrorMessage="请填写录取时间" ValidationGroup="m"></asp:RequiredFieldValidator>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="46%" align="right" bgcolor="#FAFBFC" class="style3">
                                                                                                        备注：
                                                                                                    </td>
                                                                                                    <td width="8%" colspan="3" align="left" bgcolor="#FAFBFC" class="style2">
                                                                                                        <asp:TextBox ID="txtAdmissionRemark" runat="server" Height="102px" TextMode="MultiLine"
                                                                                                            Width="534px"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" height="30">
                                                                                            <asp:Button ID="btnAdmissionsUpdate" runat="server" Text="完成修改" OnClick="btnAdmissionsUpdate_Click"
                                                                                                ValidationGroup="m" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                    ID="BbtnAdmissionsCancel" runat="server" Text="取消修改" OnClick="BbtnAdmissionsCancel_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnAdmissionsUpdate" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="BbtnAdmissionsCancel" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <!--数据来源-->
                                            <!--联系状态-->
                                            <tbody style="display: none">
                                                <tr>
                                                    <td valign="top" align="middle">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../images/mail_rightbg.gif">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="bottom" background="../images/mail_leftbg.gif" class="style11">
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
