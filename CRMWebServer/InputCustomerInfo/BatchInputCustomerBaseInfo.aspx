<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchInputCustomerBaseInfo.aspx.cs"
    Inherits="CRMWebServer.InputCustomerInfo.BatchInputCustomerBaseInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>批量添加用户信息</title>
    <script type="text/javascript">    
    function checkNull() {
        var path = document.getElementById("FileUpload1").value;
        if (path == "" || path == null) {
            alert('请选择要上传的文件!');
            return false;
        }
        return true;
    } 
       </script>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            font-weight: bold;
            color: #000000;
            text-decoration: none;
            height: 97px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                                        <span class="left_txt2">选择 csv 文件：</br> 若要批量添加用户信息，请选择一个包含用户信息的 CSV 文件。若要查看所需格式，请下载随后的
                                            CSV 文件示例。</span><asp:HyperLink ID="hyperLinkCSVLearnMore" boxtype="HyperLink" href="http://g.microsoftonline.com/1AX00zh-CHS/15"
                                                runat="server">&#20102;&#35299;&#26377;&#20851; CSV &#25991;&#20214;&#30340;&#26356;&#22810;&#20449;&#24687;</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
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
                        <td class="left_txt2">
                            路径和文件名：
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
                            <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" OnClientClick="return checkNull()" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <iframe id="iframeUpload" src="UploadFile.aspx" style="display: none;"></iframe>
                <div style="padding-top: 12px;">
                    <asp:LinkButton ID="lbtnDownloadBlank" runat="server" 
                        onclick="lbtnDownloadBlank_Click">&#19979;&#36733;&#31354;&#30333; CSV &#25991;&#20214;</asp:LinkButton>
                    <br />
                    使用文本编辑器(如记事本)根据此模板创建一个新 CSV 文件。
                </div>
                <div style="padding-top: 12px;">
                    <asp:LinkButton ID="lbtnDownloadSample" runat="server" 
                        onclick="lbtnDownloadSample_Click">&#19979;&#36733; CSV &#25991;&#20214;&#31034;&#20363;</asp:LinkButton>
                    <br />
                    文件中的列标题必须与示例中的列标题匹配。若要更改列标题，请使用文本编辑器(如记事本)。
                </div>
                </div>
                <div id="Imp_PanelVerification" boxtype="MultiPageLayoutPanel" class="MultiPageLayoutPanel"
                    style="display: none;">
                    <h2 class="BOX-HeaderSecondary title" id="Imp_PanelVerification_title">
                        验证结果
                    </h2>
                    <div id="divVerifySuccess">
                        查看你的结果。若要解决错误，请查看验证日志，更正 CSV 文件中的错误，然后重试。
                    </div>
                    <div id="divVerifyFailure">
                        无法验证你的文件，请查看文件验证日志。
                    </div>
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
