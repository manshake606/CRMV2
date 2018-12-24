<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="CRMWebServer.Customer.CustomerInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Infromation Search Page</title>
    <script type="text/javascript" src="../js/Calendar3.js">    
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
            color: #000000;
            height: 30px;
        }
        .style3
        {
            height: 30px;
        }
        .style4
        {
            height: 30px;
            width: 16%;
        }
        .style5
        {
            width: 16%;
        }
        .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            height: 55px;
        }
        .style7
        {
            width: 16%;
            height: 55px;
        }
  </style>
             <%--<script type=  "text/javascript">
                 function openLink(url) //url是后台传过来的参数
                 {
                     window.open("CustomerInfoDetails.aspx?ur=" + url, "1", "resizable=yes,toolbar=no,statusbar=no,menubar=no,location=no,scrollbars=yes,titlebar=no,width:900,height:700");
                 }
                 function ClickMouse(url) {
                     var msgID = url;
                     var expiration = new Date((new Date).getTime() + 1000 * 60000);
                     document.cookie = "msgID=" + msgID + ";expires=" + expiration.toGMTString() + ";path=/";
                     //触发后台Button1按钮事件，延迟时间为1秒
                     setTimeout("__doPostBack('Button1','')", 1000);
                 }
    </script>--%>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
    <td width="18" valign="top" background="../images/mail_leftbg.gif"><img src="../images/left-top-right.gif" width="18" height="29" /></td>
    <td valign="top" background="../images/content-bg.gif">
    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg" id="table2">
      <tr>
        <td height="31">
   
            <div class="titlebt">
                客户信息
                </div>
            </td>
      </tr>
    </table>
    </td>
    <td width="16" valign="top" background="images/mail_rightbg.gif"><img src="../images/nav-right-bg.gif" width="16" height="29" /></td>
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
                                            当前位置：客户信息
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
                                            <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="10%" height="55" valign="middle">
                                                        <img src="../images/title.gif" width="54" height="55">
                                                    </td>
                                                    <td width="90%" valign="top">
                                                        <span class="left_txt2">在这里，您可以根据您的需求，修改设置筛选您想要的信息</span><span class="left_txt3">客户基本信息</span><span
                                                            class="left_txt2">！</span><br>
                                                        <span class="left_txt2">以下是</span><span class="left_txt3">CRM系统客户数据归纳说明</span><span class="left_txt2">。</span>
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
                                            <asp:GridView ID="GVIntroduction" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="3" ForeColor="Black" GridLines="Horizontal" Width="100%" 
                                                CssClass="left_txt2" BackColor="White" BorderColor="#999999" 
                                                BorderStyle="Groove" BorderWidth="2px">
                                                <RowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField DataField="BestImportance" HeaderText="特别重要" >
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Importance" HeaderText="重要" >
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="General" HeaderText="一般" >
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NoImportance" HeaderText="不重要" >
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
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
                                    <td>
                                     &nbsp;
                                    </td>
                                    
                                    </tr>
                                    <tr>
                                        <td>
                                            <table height="31" border="0" cellpadding="0" cellspacing="0" class="nowtable">
                                                <tr>
                                                    <td class="left_bt2">
                                                        &nbsp;&nbsp;&nbsp;搜索参数设置
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                   <asp:ScriptManager ID="ScriptManager2" runat="server">
                                            </asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="6%" align="left" bgcolor="#f2f2f2" class="style2">
                                                                <asp:CheckBox ID="ckbCustomerID" runat="server" Text="客户ID：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbCustomerID_CheckedChanged"　 />
                                                            </td>
                                                            <td bgcolor="#f2f2f2" class="style4">
                                                                <asp:TextBox ID="txtCustomerID" runat="server" Enabled="False"></asp:TextBox>
                       <asp:CustomValidator ID="CVCustomerID" runat="server" ErrorMessage="编号错误" CssClass="left_txt" Display="Dynamic"></asp:CustomValidator>
                                                            </td>
                                                            <td width="8%" align="right" bgcolor="#f2f2f2" class="style2">
                                                                <asp:CheckBox ID="ckbCustomerName" runat="server" Text="客户姓名：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbCustomerName_CheckedChanged" />
                                                            </td>
                                                            <td width="17%" bgcolor="#f2f2f2" class="style3">
                                                                <asp:TextBox ID="txtCustomerName" runat="server" Enabled="False"></asp:TextBox>
                     <%--  <asp:CustomValidator ID="CVCustomerName" runat="server" ErrorMessage="姓名不合法" CssClass="left_txt"></asp:CustomValidator>--%> 
 <asp:RegularExpressionValidator ID="REVCustomerName" runat="server" ControlToValidate="txtCustomerName"  ErrorMessage="中文<10个" 
                                                                    CssClass="left_txt" ValidationExpression="^[\u4e00-\u9fa5]{0,10}$" 
                                                                    Display="Dynamic"></asp:RegularExpressionValidator>  
                                                            </td>
                                                            <td width="8%" align="left" bgcolor="#f2f2f2" class="style2">
                                                                <asp:CheckBox ID="ckbCustomerEnglishName" runat="server" Text="客户英文名：" 
                                                                    AutoPostBack="True" 
                                                                    oncheckedchanged="ckbCustomerEnglishName_CheckedChanged" />
                                                            </td>
                                                            <td bgcolor="#f2f2f2" class="style4">
                                                                <asp:TextBox ID="txtCustomerEnglishName" runat="server" Enabled="False"></asp:TextBox>
     <asp:RegularExpressionValidator ID="REVCustomerEnuName" runat="server" ControlToValidate="txtCustomerEnglishName"  ErrorMessage="姓名不合法" 
                                                                    CssClass="left_txt" ValidationExpression="^[a-zA-Z0-9]{1,30}$" 
                                                                    Display="Dynamic"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="8%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt2">
                                                                <asp:CheckBox ID="ckbCustomerImportant" runat="server" Text="客户重要性：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbCustomerImportant_CheckedChanged" />
                                                               
                                                            </td>
                                                            <td bgcolor="#f2f2f2" class="style5">
                                                                <asp:DropDownList ID="ddlCustomerImportant" runat="server" Enabled="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                <asp:CheckBox ID="ckbCustomerClass" runat="server" Text="客户分类：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbCustomerClass_CheckedChanged" />
                                                            </td>
                                                            <td width="15%" bgcolor="#f2f2f2">
                                                                <asp:DropDownList ID="ddlCustomerClass" runat="server" Enabled="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="8%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt2">
                                                                <asp:CheckBox ID="ckbDataResource" runat="server" Text="数据来源：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbDataResource_CheckedChanged" />
                                                            </td>
                                                            <td bgcolor="#f2f2f2" class="style5">
                                                              <%--  <asp:DropDownList ID="ddlDataResource" runat="server" Enabled="False">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox ID="txtDataResource" runat="server" Enabled="False"></asp:TextBox> </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="8%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt2">
                                                                <asp:CheckBox ID="ckbCustomerProvince" runat="server" Text="所在省份：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbCustomerProvince_CheckedChanged" />
                                                            </td>
                                                            <td bgcolor="#f2f2f2" class="style5">
                                                                <asp:DropDownList ID="ddlProvince" runat="server" 
                                                                    OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" Enabled="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
                                                                <asp:CheckBox ID="ckbCustomerCity" runat="server" Text="所在市区：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbCustomerCity_CheckedChanged" />
                                                            </td>
                                                            <td width="15%" bgcolor="#f2f2f2">
                                                                <asp:DropDownList ID="ddlCity" runat="server" Enabled="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="6%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt2">
                                                                <asp:CheckBox ID="ckbIntentionCountry" runat="server" Text="意向国家：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbIntentionCountry_CheckedChanged"/></td>
                                                            <td bgcolor="#f2f2f2" class="style5">
                                                                <asp:TextBox ID="txtIntentionCountry" runat="server" Enabled="False"></asp:TextBox>
       <%--<asp:RegularExpressionValidator ID="REVCityLetter" runat="server" ControlToValidate="txtIntentionCountry"  ErrorMessage="只能为字母" CssClass="left_txt" ValidationExpression="^[a-zA-Z]{1,12}$">
       </asp:RegularExpressionValidator> --%>
        <asp:RegularExpressionValidator ID="revIntentionCountry" runat="server" ControlToValidate="txtIntentionCountry"  ErrorMessage="中文<10个" 
                                                                    CssClass="left_txt" ValidationExpression="^[\u4e00-\u9fa5]{0,10}$" 
                                                                    Display="Dynamic"></asp:RegularExpressionValidator> 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="8%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt2">
 <asp:CheckBox ID="ckbImportingPeople" runat="server" Text="导入人：" AutoPostBack="True" oncheckedchanged="ckbImportingPeople_CheckedChanged" />
                                                               
                                                            </td>
                                                            <td bgcolor="#f2f2f2" class="style5">
                                                               
                                                                <asp:TextBox ID="txtImportingPeople" runat="server" Enabled="False"></asp:TextBox>
                                           <asp:RegularExpressionValidator ID="revImportingPeople" runat="server" 
                                                                    ControlToValidate="txtImportingPeople"  ErrorMessage="中文<10个" 
                                                                    CssClass="left_txt" ValidationExpression="^[\u4e00-\u9fa5]{0,10}$" 
                                                                    Display="Dynamic"></asp:RegularExpressionValidator> 
                                                            </td>
                                                            <td width="8%" height="30" align="right" bgcolor="#f2f2f2" class="left_txt2">
 <asp:CheckBox ID="ckbFollowUpConsultant" runat="server" Text="跟进顾问：" AutoPostBack="True" 
                                                                    oncheckedchanged="ckbFollowUpConsultant_CheckedChanged"/>
                                                            </td>
                                                            <td width="15%" bgcolor="#f2f2f2">
                                                                
                                                                <asp:TextBox ID="txtFollowUpConsultant" runat="server" Enabled="False"></asp:TextBox>
           <asp:RegularExpressionValidator ID="revFollowUpConsultant" runat="server" ControlToValidate="txtFollowUpConsultant"  
                                                                    ErrorMessage="中文<10个" CssClass="left_txt" 
                                                                    ValidationExpression="^[\u4e00-\u9fa5]{0,10}$" Display="Dynamic"></asp:RegularExpressionValidator> 
                                                            </td>
                                                            <td width="6%" height="30" align="left" bgcolor="#f2f2f2" class="left_txt2">
                                                                <asp:CheckBox ID="ckbFollowUpCopy" runat="server" Text="跟进文案：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbFollowUpCopy_CheckedChanged"/></td>
                                                            <td bgcolor="#f2f2f2" class="style5">
                                                                <asp:TextBox ID="txtFollowUpCopy" runat="server" Enabled="False"></asp:TextBox>
       <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFollowUpCopy"  ErrorMessage="只能为字母" CssClass="left_txt" ValidationExpression="^[a-zA-Z]{1,12}$">
       </asp:RegularExpressionValidator> --%>
          <asp:RegularExpressionValidator ID="revFollowUpCopy" runat="server" ControlToValidate="txtFollowUpCopy"  ErrorMessage="中文<10个" 
                                                                    CssClass="left_txt" ValidationExpression="^[\u4e00-\u9fa5]{0,10}$" 
                                                                    Display="Dynamic"></asp:RegularExpressionValidator> 
                                                            </td>
                                                        </tr> 
                                                        <tr>
                                                            <td width="8%" align="left" bgcolor="#f2f2f2" class="style6">
                                                                <asp:CheckBox ID="ckbCellPhoneNumber" runat="server" Text="客户手机号：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbCellPhoneNumber_CheckedChanged" />
                                                            </td>
                                                            <td bgcolor="#f2f2f2" colspan="2" class="style7">
                                                                                                                                <asp:TextBox ID="txtCellPhoneNumber" runat="server" Enabled="False"></asp:TextBox>
                       
                                                          <asp:RegularExpressionValidator ID="REVTel" runat="server" ControlToValidate="txtCellPhoneNumber"
                                                                                                                ErrorMessage="客户手机格式不正确" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$" CssClass="left_txt"
                                                                                                                Display="Dynamic" ValidationGroup="A1"></asp:RegularExpressionValidator>
                                                                                                            <asp:RequiredFieldValidator ID="REVtelphone" runat="server" ErrorMessage="手机号不能为空"
                                                                                                                CssClass="left_txt" ControlToValidate="txtCellPhoneNumber" Display="Dynamic" ValidationGroup="A1"></asp:RequiredFieldValidator>  </td>
                                         
                                                            <td width="15%" bgcolor="#f2f2f2" align="right" class="style6">
                                                                &nbsp;
                                                                <asp:CheckBox ID="ckbBackupTel" runat="server" Text="备用手机号：" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbBackupTel_CheckedChanged" />
                                                            </td>
                                                            
                                                            <td width="8%" align="right" bgcolor="#f2f2f2" class="style6">
                                                                <asp:TextBox ID="txtBackupTel" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td bgcolor="#f2f2f2" class="style7">
                                                             &nbsp;
                                                                <asp:RegularExpressionValidator ID="REVBackTel1" runat="server" 
                                                                    ControlToValidate="txtBackupTel" CssClass="left_txt" Display="Dynamic" 
                                                                    ErrorMessage="备用手机格式不正确" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$" 
                                                                    ValidationGroup="A1"></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="REVBackTelphone1" runat="server" 
                                                                    ControlToValidate="txtBackupTel" CssClass="left_txt" Display="Dynamic" 
                                                                    ErrorMessage="手机号不能为空" ValidationGroup="A1"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>       
                                                        <tr>
                                                            <td width="8%" align="left" bgcolor="#f2f2f2" class="style6">
                                                                <asp:CheckBox ID="CB_NoneFollow" runat="server" Text="选择从未跟进客户" 
                                                                    AutoPostBack="True" oncheckedchanged="ckbCellPhoneNumber_CheckedChanged" />
                                                            </td>
                                                            <td bgcolor="#f2f2f2" colspan="2" class="style7">
                                                                                                                                <asp:CheckBox ID="ckbStartIntentionTime" runat="server" AutoPostBack="True" 
                                                                                                                                    oncheckedchanged="ckbStartIntentionTime_CheckedChanged" Text="预计出国时间始" 
                                                                                                                                    class="left_txt2"/>
                                                                                                                                <asp:TextBox ID="txtStartIntentionTime" runat="server" 
                                                                                                                                    onclick="new Calendar().show(this);" Enabled="False"></asp:TextBox>
                                                            </td>
                                         
                                                            <td width="15%" bgcolor="#f2f2f2" align="right" class="style6">
                                                                <asp:CheckBox ID="ckbEndIntentionTime" runat="server" AutoPostBack="True" 
                                                                    class="left_txt2" oncheckedchanged="ckbEndIntentionTime_CheckedChanged" 
                                                                    Text="预计出国时间尾" />
                                                                &nbsp;
                                                                </td>
                                                            
                                                            <td width="8%" align="right" bgcolor="#f2f2f2" class="style6">
                                                                <asp:TextBox ID="txtEndIntentionTime" runat="server" 
                                                                    onclick="new Calendar().show(this);" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td bgcolor="#f2f2f2" class="style7">
                                                             &nbsp;
                                                                </td>
                                                        </tr>                                
                                                        <tr>
                                                            <td height="17" colspan="4" align="right">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                           </ContentTemplate>
                                            </asp:UpdatePanel> 
                                            <div style="margin-top: -10px; margin-right: 30px; margin-bottom: 6px;" align="right">
                                                <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" 
                                                    style="height: 26px" />&nbsp;</div>
                                                 <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3">
                                            <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="nowtable">
                                                <tr>
                                                    <td class="left_bt2">
                                                        &nbsp;&nbsp;客户信息列表
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" colspan="3">
                                            <table width="100%" height="89" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td bgcolor="#f2f2f2" class="style1">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td bgcolor="#f2f2f2" align="center" class="style1">
                                                       <span style="font-size: large; color: #FF0000">
                                                        <asp:CustomValidator ID="CVNoticeCustomError" runat="server" ErrorMessage="" Display="Dynamic"></asp:CustomValidator></span> 
    <asp:GridView ID="gvCustomerInfroList" runat="server" AllowSorting="True" CellPadding="3" ForeColor="Black" 
                                                            AutoGenerateColumns="False" AllowPaging="True"  onrowdatabound="gvCustomerInfroList_RowDataBound" 
                                                            ondatabound="gvCustomerInfroList_DataBound" Width="946px"
                                                            onsorting="gvCustomerInfroList_Sorting"　CellSpacing="2" BackColor="White" 
                                                            BorderColor="#999999" BorderStyle="Groove" BorderWidth="2px" 
                                                            GridLines="Horizontal" PageSize="30">
                                                            <RowStyle HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:BoundField DataField="CustomerID" HeaderText="客户编号" SortExpression="CustomerID"/>
                                                                <asp:BoundField DataField="CustomerName" HeaderText="客户姓名" SortExpression="CustomerName"/>
                                                                <asp:BoundField DataField="Grade" HeaderText="年级" />
                                                                <asp:BoundField DataField="TelPhone" HeaderText="手机号码" />
                                                                <asp:BoundField DataField="CCity" HeaderText="所在城市" />
                                                                <asp:BoundField DataField="CustomerClass" HeaderText="客户分类" SortExpression="CustomerClass"  />
                                                                <asp:BoundField DataField="CustomerImportance" HeaderText="客户重要性" SortExpression="CustomerImportance"/>
                                                                <asp:BoundField DataField="IntentionCountry" HeaderText="意向国家" />
                                                                <asp:BoundField DataField="StaffName" HeaderText="跟进人" SortExpression="StaffName" />
                                                                <asp:BoundField DataField="LatestTime" HeaderText="跟进时间" HtmlEncode= "false" DataFormatString="{0:yyyy-MM-dd}" SortExpression="LatestTime" />
                                                                <asp:BoundField DataField="FromData" HeaderText="数据来源" />                                                             
                                                                <asp:BoundField DataField="ImportingPeople" HeaderText="导入人" />
                                                                <asp:HyperLinkField DataNavigateUrlFields="CustomerID" HeaderText="详细" DataNavigateUrlFormatString="~/Customer/CustomerInfoDetails.aspx?CustomerID={0}"
                                                                    Text="详细" />
                                                            </Columns>
                                                            <PagerTemplate>
                                                            <div id="main">                  <div id="info">&nbsp;&nbsp;页次：<asp:Label ID="lblPageCurrent" runat="server" Text="1" CssClass="txtInfo"></asp:Label>/<asp:Label ID="lblPageCount" runat="server" Text="1"></asp:Label>&nbsp;&nbsp;
                  共&nbsp;<asp:Label ID="lblPageRow" runat="server" Text="1" CssClass="txtInfo"></asp:Label>&nbsp;条记录
                  </div>
                  <div id="page">
                      <asp:LinkButton ID="btnFirst" runat="server" CssClass="link" CommandName="Pager" CommandArgument="First" OnCommand="NavigateToPage">[首页]</asp:LinkButton>&nbsp;
                      <asp:LinkButton ID="btnPrev" runat="server" CssClass="link" CommandName="Pager" CommandArgument="Prev" OnCommand ="NavigateToPage">[前一页]</asp:LinkButton>&nbsp;
                      <asp:LinkButton ID="btnNext" runat="server" CssClass="link" CommandName="Pager" CommandArgument="Next" OnCommand="NavigateToPage">[下一页]</asp:LinkButton>&nbsp;
                      <asp:LinkButton ID="btnLast" runat="server" CssClass="link" CommandName="Pager" CommandArgument="Last" OnCommand="NavigateToPage">[尾页]</asp:LinkButton>&nbsp;
                  </div> </div>
                                                            </PagerTemplate>
                                                                                                            
                                                            <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
                                                            <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="true" ForeColor="White" 
                                                                HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="#CCCCCC" />
               
                                                        </asp:GridView>
                                                    </td>
                                                    <td bgcolor="#f2f2f2" class="style1">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f2f2f2" class="style1">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td bgcolor="#f2f2f2" class="style1">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td bgcolor="#f2f2f2" class="style1">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
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
    <td valign="bottom" background="../images/mail_leftbg.gif" class="style11"><img src="../images/buttom_left2.gif" width="17" height="17" /></td>
    <td background="../images/buttom_bgs.gif"><img src="../images/buttom_bgs.gif" width="17" height="17"></td>
    <td valign="bottom" background="../images/mail_rightbg.gif"><img src="../images/buttom_right2.gif" width="16" height="17" /></td>
  </tr>
        </table>
    </div>
    </form>
</body>
</html>
