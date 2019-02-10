<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomerBaseInfo.aspx.cs" Inherits="CRMWebServer.InputCustomerInfo.AddCustomerBaseInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加客户基本信息</title>
    
    <script type="text/javascript" src="../js/Calendar3.js">
        
        </script>   
        

   
    
        <link href="../css/skin.css" rel="stylesheet" type="text/css" />

    <style type="text/css">

body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #F8F9FA;
    }
        #TextArea1
        {
            width: 246px;
        }
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            height: 30px;
        }
        .style2
        {
            height: 30px;
            width: 36%;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 30px;
        }
        .style4
        {
            width: 36%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="17" valign="top" background="../images/mail_leftbg.gif"><img src="../images/left-top-right.gif" width="17" height="29" /></td>
    <td valign="top" background="../images/content-bg.gif" >
    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg" id="table2">
      <tr>
        <td height="31">
   
            <div class="titlebt2">
                添加客户基本信息
                </div>
            </td>
      </tr>
    </table>
    </td>
    <td width="16" valign="top" background="images/mail_rightbg.gif"><img src="../images/nav-right-bg.gif" width="16" height="29" /></td>
  </tr>
  
  
  <tr>
    <td height="71" valign="middle" background="../images/mail_leftbg.gif">&nbsp;</td>
    <td valign="top" bgcolor="#F7F8F9">
    
    
    
    
    <table width="98%"  border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="13" valign="top">&nbsp;</td>
      </tr>
      <tr>
        <td valign="top">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td class="left_txt">当前位置：添加修改客户基本信息</td>
          </tr>
          <tr>
            <td height="20">
            <table width="100%" height="1" border="0" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC">
              <tr>
                <td></td>
              </tr>
            </table>
                </td>
          </tr>
          <tr>
            <td>
            <table width="100%" height="55" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="10%" height="55" valign="middle"><img src="../images/title.gif" width="54" height="55"></td>
                <td width="90%" valign="top"><span class="left_txt2">本页面负责添加和修改客户的基本信息</span><span 
                        class="left_txt3"></span><span class="left_txt2"></span><br>
                          <span class="left_txt2"></span><span class="left_txt3"></span><span 
                        class="left_txt2"></span><span class="left_txt3"></span><span 
                        class="left_txt2"></span></td>
              </tr>
            </table>
            </td>
          </tr>
         
          
          <tr>
            <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="25%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        客户编号：
                    </td>
                    <td bgcolor="#f2f2f2" align="left" class="style4">
                        <asp:TextBox ID="txtCustomerID" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td width="10%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        客户姓名：
                    </td>
                    <td width="25%" height="30" align="left" bgcolor="#f2f2f2" >
                        
                        <div style="color: red">
                            <asp:TextBox ID="txtCustomerName" runat="server" ValidationGroup="A1"></asp:TextBox>&nbsp;<b>*</b>
                            <asp:RequiredFieldValidator ID="RFVCustomerName" runat="server" 
                                ErrorMessage="客户姓名不能为空" CssClass="left_txt" 
                                ControlToValidate="txtCustomerName" ValidationGroup="A1" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" class="left_txt2">
                        英文名字：
                    </td>
                    <td align="left" class="style4">
                        <asp:TextBox ID="txtEnglishName" runat="server"></asp:TextBox>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        出生日期：
                    </td>
                    <td height="30" align="left" class="left_txt">
                        <asp:TextBox ID="txtBirthday" runat="server"  
                            onclick="new Calendar().show(this);" AutoPostBack="True" 
                            ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVStarttime" runat="server" 
                        ControlToValidate="txtBirthday" ErrorMessage="时间格式有误" 
                        
                            ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))" 
                            CssClass="left_txt"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        性别：
                    </td>
                    <td align="left" bgcolor="#f2f2f2" class="style4">
                        <asp:DropDownList ID="DDSex" runat="server" Width="128px">
                            <asp:ListItem Value="0">男</asp:ListItem>
                            <asp:ListItem Value="1">女</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        QQ：</td>
                    <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                        <asp:TextBox ID="txtCQQ" runat="server"></asp:TextBox> 
                        <asp:RegularExpressionValidator ID="REVQQ" runat="server" ControlToValidate="txtCQQ"
                                                                ErrorMessage="不正确的QQ号" 
                            ValidationExpression="^[0-9]*$" CssClass="left_txt"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style1">
                        手机：
                    </td>
                    <td align="left" class="style2">
                        <div style="color: red"><asp:TextBox ID="txtTelPhone" runat="server" 
                                ValidationGroup="A1"></asp:TextBox>&nbsp;*
                        <asp:RegularExpressionValidator ID="REVTel" runat="server" ControlToValidate="txtTelPhone" 
                            ErrorMessage="客户手机格式不正确" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$" 
                            CssClass="left_txt" Display="Dynamic" ValidationGroup="A1"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="REVtelphone" runat="server" 
                                ErrorMessage="手机号不能为空" CssClass="left_txt" ControlToValidate="txtTelPhone" 
                                Display="Dynamic" ValidationGroup="A1"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td width="8%" align="right" bgcolor="#f2f2f2" class="style1">
                        固定电话：
                    </td>
                    <td align="left" class="style3">
                        <asp:TextBox ID="txtPhone" runat="server" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVPhone" runat="server"
                                                                ControlToValidate="txtPhone" ErrorMessage="电话格式不正确" ValidationExpression="^(\d{3,4}-)?\d{6,8}$" CssClass="left_txt"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        备用手机：
                    </td>
                    <td align="left" bgcolor="#f2f2f2" class="style4">
                        <div style="color: red"><asp:TextBox ID="txtBackUpTel" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVBackupTel" runat="server" ControlToValidate="txtBackUpTel" 
                            ErrorMessage="备用手机格式不正确" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$" 
                            CssClass="left_txt"></asp:RegularExpressionValidator></div>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        城市首字母：
                        
                    </td>
                    <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                        <asp:TextBox ID="txtCityInitial" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" class="left_txt2">
                        所在省份：
                    </td>
                    <td align="left" class="style4">
                    <div style="color: red">
                        <asp:DropDownList ID="DDCProvince" runat="server" Width="126px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="DDCProvince_SelectedIndexChanged" ValidationGroup="A1">
                        </asp:DropDownList>&nbsp;&nbsp;*
                        <asp:RequiredFieldValidator ID="RFVProvince" runat="server" ControlToValidate="DDCProvince"
                                ErrorMessage="客户所在省份不能为空" InitialValue="省份" CssClass="left_txt" 
                            ValidationGroup="A1"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        所在城市：
                    </td>
                    <td height="30" align="left" >
                        <div style="color: red"><asp:DropDownList ID="DDCCity" runat="server" Width="126px" 
                                ValidationGroup="A1">
                        </asp:DropDownList>&nbsp;&nbsp;*
                         <asp:RequiredFieldValidator ID="RFVCity" runat="server" ControlToValidate="DDCCity"
                                ErrorMessage="客户所在地区不能为空" InitialValue="城市" CssClass="left_txt" 
                                ValidationGroup="A1"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        &nbsp;专业：</td>
                    <td align="left" bgcolor="#f2f2f2" class="style4">
                        <asp:TextBox ID="txtProfessionName" runat="server"></asp:TextBox>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        邮箱：
                    </td>
                    <td width="42%" align="left" height="30" bgcolor="#f2f2f2" class="left_txt">
                        <asp:TextBox ID="txtCemail" runat="server">
                        </asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVCmail" runat="server" 
                            ControlToValidate="txtCemail" CssClass="left_txt" ErrorMessage="请输入正确的邮箱地址" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" class="left_txt2">
                        联系人地址：
                    </td>
                    <td colspan="3" align="left" align="left">
                        <asp:TextBox ID="txtCAddress" runat="server" Width="487px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        其他联系人：
                    </td>
                    <td align="left" bgcolor="#f2f2f2" class="style4">
                        <asp:TextBox ID="txtOtherContact" runat="server"></asp:TextBox>
                    </td>
                    <td width="10%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        联系人电话：
                    </td>
                    <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                        <asp:TextBox ID="txtOtherContactPhone" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVotherPhone" runat="server" 
                            ControlToValidate="txtOtherContactPhone" CssClass="left_txt" ErrorMessage="电话格式不正确" 
                            ValidationExpression="^(\d{3,4}-)?\d{6,8}$|^1[3|4|5|8][0-9]\d{4,8}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" class="left_txt2">
                        决策人与之关系：
                    </td>
                    <td align="left" class="style4">
                        <asp:TextBox ID="txtPolicymaker" runat="server"></asp:TextBox>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        决策人姓名：
                    </td>
                    <td height="30" align="left" class="left_txt">
                        <asp:TextBox ID="txtPolicymakerName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        客户分类：
                    </td>
                    <td align="left" bgcolor="#f2f2f2" class="style4">
                        <asp:DropDownList ID="DDCustomerClass" runat="server" Width="126px">
                            <asp:ListItem Value="0">未分类</asp:ListItem>
                            <asp:ListItem Value="1">短期潜在</asp:ListItem>
                            <asp:ListItem Value="2">长期潜在</asp:ListItem>
                            <asp:ListItem Value="3">意向不明</asp:ListItem>
                            <asp:ListItem Value="4">已经签约</asp:ListItem>
                            <asp:ListItem Value="5">已经流失</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        流失去向：
                    </td>
                    <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                        <asp:DropDownList ID="DDDrainTowards" runat="server" Width="126px">
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
                    <td align="left" class="style4">
                        <asp:TextBox ID="txtSname" runat="server"></asp:TextBox>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        年级：
                    </td>
                    <td height="30" align="left" class="left_txt">
                        <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                
                
                <tr>
                    <td height="30" align="right" class="left_txt2">
                        &nbsp;客户来源：</td>
                    <td align="left" class="style4">
                        <asp:DropDownList ID="DDCustomerFrom" runat="server" Width="126px">
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
                        推荐人：</td>
                    <td height="30" align="left" class="left_txt">
                        <asp:TextBox ID="txtReference" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="CVReference" runat="server" 
                            ControlToValidate="txtReference" ErrorMessage="请填写推荐人"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td width="20%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        &nbsp;数据来源：</td>
                    <td align="left" bgcolor="#f2f2f2" class="style4">
                        <asp:TextBox ID="txtFromData" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="CVFromData" runat="server" 
                            ControlToValidate="txtFromData" ErrorMessage="请填写数据来源" 
                            CssClass="left_txt2"></asp:CustomValidator>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        &nbsp;推荐人备注：</td>
                    <td width="42%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt">
                        <asp:TextBox ID="txtReferenceRemark" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" class="left_txt2">
                        &nbsp;导入人：</td>
                    <td align="left" class="style4">
                        <asp:TextBox ID="txtImportingPeople" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        &nbsp;导入时间：</td>
                    <td height="30" align="left" class="left_txt">
                        <asp:TextBox ID="txtImportingDate" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" height="50" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        备注：
                    </td>
                    <td width="30%" colspan="3" align="left" bgcolor="#f2f2f2">
                        <asp:TextBox ID="txtRemark" runat="server" Width="485px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" class="left_txt2">
                        
                        客户重要性：</td>
                    <td align="left" class="style4">
                        <asp:DropDownList ID="DDCustomerImportance" runat="server" Width="126px">
                            <asp:ListItem Value="1">一般</asp:ListItem>
                            <asp:ListItem Value="0">不重要</asp:ListItem>
                            <asp:ListItem Value="2">重要</asp:ListItem>
                            <asp:ListItem Value="3">特别重要</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="8%" height="30" align="right"  class="left_txt2">
                        
                        主要意向国家：</td>
                    <td height="30" align="left" class="left_txt">
                        <asp:TextBox ID="txtIntentionCountry" runat="server"></asp:TextBox>
                    </td>
                </tr>
                                <tr>
                    <td height="30" align="right" class="left_txt2">
                        
                        合同编号：</td>
                    <td align="left" class="style4">
                        <asp:TextBox ID="txtContractNum" runat="server" ></asp:TextBox>
                    </td>
                    <td width="8%" height="30" align="right"  class="left_txt2">
                        
                        是否背景提升：</td>
                    <td height="30" align="left" class="left_txt">
                        <asp:DropDownList ID="DDCustomerImprove" runat="server" Width="126px">
                            <asp:ListItem Value="0">是</asp:ListItem>
                            <asp:ListItem Value="1">否</asp:ListItem>
                        </asp:DropDownList>
                                    </td>
                </tr>
                <tr>
                    <td width="20%" height="50" align="right" bgcolor="#f2f2f2" class="left_txt2">
                        工作经验：
                    </td>
                    <td width="30%" colspan="3" align="left" bgcolor="#f2f2f2">
                        <asp:TextBox ID="txtWorkExperience" runat="server" Width="485px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <tr>
                    <td width="20%" height="50" align="right" bgcolor="#f2f2f2" class="left_txt2">
  代理信息：
                    </td>
                    <td width="30%" colspan="3" align="left" bgcolor="#f2f2f2">
                        <asp:TextBox ID="txtAgentInfo" runat="server" Width="485px" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="right" class="left_txt2">
                        &nbsp;
                    </td>
                    <td class="style4">
                        &nbsp;<asp:Button ID="BtnConfirm" runat="server" Text="确定" 
                            style="width: 69px" onclick="BtnConfirm_Click" ValidationGroup="A1"/>&nbsp;<asp:HiddenField 
                            ID="HiddenField1" runat="server" />
                        
                    </td>
                    <td width="8%" height="60" align="left" class="left_txt2">
                        &nbsp;<asp:Button ID="BtnCancel" runat="server" Text="取消" style="width: 69px" 
                            onclick="BtnCancel_Click"/></td>
                    <td height="60" class="left_txt">
                        &nbsp;
                        <asp:Button ID="BtnBatchInput" runat="server" Text="批量添加" style="width: 69px" 
                            onclick="BtnBatchInput_Click" /></td>
                </tr>

                                                                                            </table>
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
