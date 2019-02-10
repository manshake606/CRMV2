<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchDocument.aspx.cs"
    Inherits="CRMWebServer.Document.SearchDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>搜索文案</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/Calendar3.js">
        function showCalendar() {
            document.getElementById("CalendarStart").style.display = 'block';
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
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 19px;
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
                                文档搜索
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
                <table width="98%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="left_txt">
                            当前位置：文档搜索
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
                                        <span class="left_txt2">在这里，您可以根据您的需求，输入对应的搜索条件，搜索文档相关的结果。</span><span class="left_txt3"></span><span
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
                        <td height="20">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            请输入搜索条件：
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="文件上传时间从：" Width="125px" CssClass="left_txt"></asp:Label>
                                    </td>
                                    <td height="30" bgcolor="#f2f2f2">
                                        <asp:TextBox ID="txtStarttime" runat="server" onclick="new Calendar().show(this);"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="REVStarttime" runat="server" ControlToValidate="txtStarttime"
                                            ErrorMessage="时间格式有误" ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"
                                            CssClass="left_txt" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="到" Width="15px" CssClass="left_txt"></asp:Label>
                                    </td>
                                    <td height="30">
                                        <asp:TextBox ID="txtEndtime" runat="server" onclick="new Calendar().show(this)"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndtime"
                                            ErrorMessage="时间格式有误" ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"
                                            CssClass="left_txt" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="left_txt" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabCustomerID" runat="server" Text="客户编号：" Width="125px" 
                                            CssClass="left_txt"></asp:Label>
                                    </td>
                                    <td height="30" bgcolor="#f2f2f2">
                                        <asp:TextBox ID="txtCustomerID" runat="server" 
                                            ></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="REVCustomerID" runat="server" 
                                            ErrorMessage="客户编号格式错误" CssClass="left_txt" 
                                            ControlToValidate="txtCustomerID" Display="Dynamic" 
                                            ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabCustomerName" runat="server" Text="客户姓名：" Width="118px" 
                                            CssClass="left_txt"></asp:Label>
                                    </td>
                                    <td height="30">
                                        <asp:TextBox ID="txtCustomerName" runat="server" 
                                            ></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabDocumentName" runat="server" Text="文档名称：" Width="125px" 
                                            CssClass="left_txt"></asp:Label>
                                    </td>
                                    <td height="30" bgcolor="#f2f2f2">
                                        <asp:TextBox ID="txtDocumentName" runat="server" 
                                            ></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabUploadBy" runat="server" Text="上传者：" Width="118px" 
                                            CssClass="left_txt"></asp:Label>
                                    </td>
                                    <td height="30">
                                        <asp:TextBox ID="txtUploadBy" runat="server" 
                                            ></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabFileType" runat="server" Text="文档名称：" Width="125px" 
                                            CssClass="left_txt"></asp:Label>
                                    </td>
                                    <td height="30" bgcolor="#f2f2f2">
                                        <asp:DropDownList ID="DDLFileType" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td height="30">
                                        &nbsp;</td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_txt">
                            搜索结果：
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
                            <asp:GridView ID="gvSearchResult" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                                Width="1030px" OnPageIndexChanging="gvSearchResult_PageIndexChanging" 
                                OnRowCommand="gvSearchResult_RowCommand" CssClass="left_txt" PageSize="30" 
                                BackColor="White" BorderColor="#999999" BorderStyle="Groove" BorderWidth="2px" 
                                CellPadding="3" ForeColor="Black" GridLines="Horizontal">
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="FileID" HeaderText="文件ID" />
                                    <asp:BoundField DataField="Customer" HeaderText="客户ID" />
                                    <asp:BoundField DataField="CustomerName" HeaderText="客户姓名" />
                                    <asp:BoundField DataField="FilesName" HeaderText="文档名称" />
                                    <asp:BoundField DataField="DoccumentTypeName" HeaderText="文档类型" />
                                    <asp:BoundField DataField="FileUploadTime" HeaderText="上传时间" />
                                    <asp:BoundField DataField="StaffName" HeaderText="上传者" />
                                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnDownload" runat="server" CausesValidation="False" CommandArgument='<%# bind("FileID") %>'
                                                CommandName="download" Text="下载"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnRemove" runat="server" CausesValidation="False" CommandArgument='<%# bind("FileID") %>'
                                                CommandName="Remove" Text="删除"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
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
