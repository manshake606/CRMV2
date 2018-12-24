<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewContract.aspx.cs" 
Inherits="CRMWebServer.FinancialPage.Payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加签约合同</title>
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
                新建合同
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
                                        当前位置：添加客户签署合同页面
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
                                                    <span class="left_txt2">在这里，您可以新建合同</span><span
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
                                                    &nbsp;&nbsp;&nbsp;输入下面所需合同基本信息
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
                                                    签署合同日期：
                                                </td>
                                                <td width="3%" bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td width="32%" height="30" bgcolor="#f2f2f2">
                                                    <asp:TextBox ID="txtSignDate" runat="server" 
                                                        onclick="new Calendar().show(this);" ReadOnly="True" 
                                                        ></asp:TextBox>
                                                </td>
                                                <td width="45%" height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    选择签署合同的日期
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    代理：
                                                </td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    &nbsp;<asp:DropDownList ID="ddlProxy" runat="server">
                                                        <asp:ListItem Value="0">无代理</asp:ListItem>
                                                        <asp:ListItem Value="1">有代理</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    是否需要代理
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    代理名称：&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    &nbsp;<asp:TextBox ID="txtProxyName" runat="server"></asp:TextBox>
                                                </td>
                                                <td height="30" class="left_txt">
                                                    如果有代理需要输入代理名称信息
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    推荐人：
                                                </td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    &nbsp;<asp:TextBox ID="txtRecommendPeople" runat="server"></asp:TextBox>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    通过公司以外的推荐人
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    推荐费用：
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    &nbsp;<asp:TextBox ID="txtReferralFees" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RevReferralFees" runat="server" 
                                                        ControlToValidate="txtReferralFees" ErrorMessage="请输入数字" 
                                                        ValidationExpression="^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td height="30" class="left_txt">
                                                    推荐费用由公司决定
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    推荐费用支付时间：
                                                </td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    &nbsp;<asp:TextBox ID="txtReferralFeesPayDate" runat="server" 
                                                        onclick="new Calendar().show(this);"></asp:TextBox>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    记录支付推荐费用时间
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    是否有外包：
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    &nbsp;<asp:DropDownList ID="ddlOutSourcing" runat="server">
                                                        <asp:ListItem Value="0">无外包</asp:ListItem>
                                                        <asp:ListItem Value="1">有外包</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    无外包值为0有外包值为1
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    外包人：
                                                </td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    &nbsp;<asp:TextBox ID="txtOutSourcingPeople" runat="server"></asp:TextBox>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    输入外包人信息
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    外包费用：
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    &nbsp;<asp:TextBox ID="txtOutSourcingFees" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RevOutSourcingFees" runat="server" 
                                                        ControlToValidate="txtOutSourcingFees" ErrorMessage="请输入数字" 
                                                        ValidationExpression="^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td height="30" class="left_txt">
                                                    最终外包费用
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                    外包支付日期：
                                                </td>
                                                <td bgcolor="#f2f2f2">
                                                    &nbsp;
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2">
                                                    &nbsp;<asp:TextBox ID="txtOutSourcingPayDate" runat="server" 
                                                        onclick="new Calendar().show(this);" ></asp:TextBox>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    收到外包费用的具体时间
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right" class="left_txt2">
                                                    外包说明：
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td height="30">
                                                    &nbsp;<asp:TextBox ID="txtOutSourcingDirections" runat="server"></asp:TextBox>
                                                </td>
                                                <td height="30" bgcolor="#f2f2f2" class="left_txt">
                                                    特殊需要说明的外包信息
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" bgcolor="#f2f2f2" class="style1">
                                                    其它费用金额：
                                                </td>
                                                <td bgcolor="#f2f2f2" class="style2">
                                                    &nbsp;
                                                </td>
                                                <td bgcolor="#f2f2f2" class="style2">
                                                    &nbsp;<asp:TextBox ID="txtOtherFees" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RevOtherFees" runat="server" 
                                                        ControlToValidate="txtOtherFees" ErrorMessage="请输入数字" 
                                                        ValidationExpression="^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td bgcolor="#f2f2f2" class="style3">
                                                    其它金额费用
                                                </td>
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
                                        &nbsp;<asp:Button ID="btnConfirm" runat="server" Text="确定" OnClick="btnConfirm_Click" />
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
