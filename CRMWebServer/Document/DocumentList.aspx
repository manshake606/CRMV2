<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentList.aspx.cs" Inherits="CRMWebServer.Document.DocumentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文案详细</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
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
                                    文案详细</div>
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
                                            <span class="left_txt2">在这里，您查看到客户已经上传的文档信息，并且可以下载。</span></td>
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
                            <td class="left_bt">
                                <asp:Label ID="lbName" runat="server"></asp:Label><span class = left_txt>的所有文案信息：</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                        <td>
                            <asp:GridView ID="gvFileList" AllowPaging="True" runat="server" Style="margin-right: 0px"
                                OnPageIndexChanging="gdvUploadFile_PageIndexChanging" AutoGenerateColumns="False"
                                OnRowCommand="gdvUploadFile_RowCommand" Width="585px" CssClass="left_txt" 
                                PageSize="30" BackColor="White" BorderColor="#999999" BorderStyle="Groove" 
                                BorderWidth="2px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" 
                                HorizontalAlign="Center">
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="FilesName" HeaderText="文档名称" />
                                    <asp:BoundField DataField="FileUploadDate" HeaderText="上传时间" />
                                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnDownload" runat="server" CausesValidation="False" CommandArgument='<%# bind("FilesName") %>'
                                                CommandName="download" Text="下载"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnRemove" runat="server" CausesValidation="False" CommandArgument='<%# bind("FilesName") %>'
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
