<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadDocument.aspx.cs"
    Inherits="CRMWebServer.UploadDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传文案</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
<!--
    <script type="text/javascript">
        function ConfirmAdd() {
            if (confirm("文件已经上传，是否覆盖?")) {
                document.getElementById("HiddenField1").value = "1";
            }
            else {
                document.getElementById("HiddenField1").value = "0";
            }
        }        
    </script>
!-->
    <style type="text/css">
        .style1
        {
            height: 97px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="17" valign="top" background="../images/mail_leftbg.gif">
                <img src="../images/left-top-right.gif" width="17" height="29" />
            </td>
            <td valign="top" background="../images/content-bg.gif">
                <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg"
                    id="table2">
                    <tr>
                        <td height="31">
                            <div class="titlebt">
                                上传文案
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
                <table width="98%" height="138" border="0" cellpadding="0" cellspacing="0">
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
                                        <span class="left_txt2">在这里，文案可以根据需求，为客户上传相关信息的文档到服务器。</span>
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
                            客户基本确认：
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
                                            <asp:Label ID="lbCustomerName" runat="server" Text="客户姓名：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerName" runat="server" Width="120px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbCustomerID" runat="server" Text="客户编号：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerID" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbContractID" runat="server" Text="合同编号：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContractID" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbConsultantName" runat="server" Text="顾问姓名：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConsultantName" runat="server" Width="120px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <!--
                                    <td>
                                        <td>
                                            <asp:Label ID="lbConsultantID" runat="server" Text="顾问编号：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConsultantID" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    !-->
                                    <td>
                                        <td>
                                            <asp:Label ID="lbDocumentName" runat="server" Text="文案姓名：" Width="72px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDocumentName" runat="server" Width="180px"></asp:TextBox>
                                        </td>
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
                            请选择并上传相关文件：
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="500px" />
                            <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click"  /><asp:HiddenField
                                ID="HiddenField1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="left_txt">
                            已经上传的文件：
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gdvUploadFile" AllowPaging="True" runat="server" Style="margin-right: 0px"
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
