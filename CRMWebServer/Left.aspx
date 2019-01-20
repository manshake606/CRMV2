<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="CRMWebServer.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理页面</title>

    <script src="js/prototype.lite.js" type="text/javascript"></script>

    <script src="js/moo.fx.js" type="text/javascript"></script>

    <script src="js/moo.fx.pack.js" type="text/javascript"></script>

    <style>
        body
        {
            font: 12px Arial, Helvetica, sans-serif;
            color: #000;
            background-color: #EEF2FB;
            margin: 0px;
        }
        #container
        {
            width: 182px;
        }
        H1
        {
            font-size: 12px;
            margin: 0px;
            width: 182px;
            cursor: pointer;
            height: 30px;
            line-height: 20px;
        }
        H1 a
        {
            display: block;
            width: 182px;
            color: #000;
            height: 30px;
            text-decoration: none;
            background-image: url(images/menu_bgS.gif);
            background-repeat: no-repeat;
            line-height: 30px;
            text-align: center;
            margin: 0px;
            padding: 0px;
        }
        .content
        {
            width: 182px;
            height: 26px;
        }
        .MM ul
        {
            list-style-type: none;
            margin: 0px;
            padding: 0px;
            display: block;
        }
        .MM li
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            list-style-type: none;
            display: block;
            text-decoration: none;
            height: 26px;
            width: 182px;
            padding-left: 0px;
        }
        .MM
        {
            width: 182px;
            margin: 0px;
            padding: 0px;
            left: 0px;
            top: 0px;
            right: 0px;
            bottom: 0px;
            clip: rect(0px,0px,0px,0px);
        }
        .MM a:link
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(images/menu_bg1.gif);
            background-repeat: no-repeat;
            height: 26px;
            width: 182px;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
            text-decoration: none;
        }
        .MM a:visited
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(images/menu_bg1.gif);
            background-repeat: no-repeat;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            height: 26px;
            width: 182px;
            text-decoration: none;
        }
        .MM a:active
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(images/menu_bg1.gif);
            background-repeat: no-repeat;
            height: 26px;
            width: 182px;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
            text-decoration: none;
        }
        .MM a:hover
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            font-weight: bold;
            color: #006600;
            background-image: url(images/menu_bg2.gif);
            background-repeat: no-repeat;
            text-align: center;
            display: block;
            margin: 0px;
            padding: 0px;
            height: 26px;
            width: 182px;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="280" border="0" cellpadding="0" cellspacing="0" bgcolor="#EEF2FB">
        <tr>
            <td width="182" valign="top">
                <div id="container">
                    <h1 class="type">
                        <a href="javascript:void(0)">客户信息管理</a></h1>
                    <div class="content">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/menu_topline.gif" width="182" height="5" />
                                </td>
                            </tr>
                        </table>
                        <ul class="MM">
                            <li><a href="Customer/CustomerInfo.aspx" target="main">客户信息</a></li>
                        </ul>
                    </div>
                    <h1 class="type">
                        <a href="javascript:void(0)">客户信息导入</a></h1>
                    <div class="content">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/menu_topline.gif" width="182" height="5" />
                                </td>
                            </tr>
                        </table>
                        <ul class="MM">
                            <li><a href="InputCustomerInfo/AddCustomerBaseInfo.aspx" target="main">客户添加</a></li>
                        </ul>
                    </div>
                    <h1 class="type">
                        <a href="javascript:void(0)">客户流程管理</a></h1>
                    <div class="content">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/menu_topline.gif" width="182" height="5" />
                                </td>
                            </tr>
                        </table>
                        <ul class="MM">
                            <li><a href="Process/BussinessFollowUP.aspx" target="main">业务跟进</a></li>
                            <li><a href="Process/TaskAssign.aspx" target="main">任务指派</a></li>
                            <li><a href="Process/LogInfo.aspx" target="main">日志查询</a></li>
                        </ul>
                    </div>
                    <h1 class="type">
                        <a href="javascript:void(0)">文案归档管理</a></h1>
                    <div class="content">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/menu_topline.gif" width="182" height="5" />
                                </td>
                            </tr>
                        </table>
                        <ul class="MM">
                            <li><a href="Document/SearchDocument.aspx" target="main">文案搜索</a></li>
                             <li><a href="Document/UploadFile.aspx" target="main">文案上传</a></li>
                        </ul>
                    </div>
                    <h1 class="type">
                        <a href="javascript:void(0)">财务信息管理</a></h1>
                    <div class="content">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/menu_topline.gif" width="182" height="5" />
                                </td>
                            </tr>
                        </table>
                        <ul class="MM">
                            <li><a href="FinancialPage/Financial.aspx" target="main">合同管理</a></li>
                            <li><a href="FinancialPage/ContractIncome.aspx" target="main">顾问提成</a></li>
                            <li><a href="FinancialPage/NewContract.aspx" target="main">新建合同</a></li>
                        </ul>
                    </div>
                    <h1 class="type">
                        <a href="javascript:void(0)">员工信息管理</a></h1>
                    <div class="content">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/menu_topline.gif" width="182" height="5" />
                                </td>
                            </tr>
                        </table>
                        <ul class="MM">
                            <li><a href="Staff/StaffInformations.aspx" target="main">员工信息管理</a></li>
                        </ul>
                    </div>
                </div>

                <script type="text/javascript">
                    var contents = document.getElementsByClassName('content');
                    var toggles = document.getElementsByClassName('type');

                    var myAccordion = new fx.Accordion(
			toggles, contents, { opacity: true, duration: 400 }
		);
                    myAccordion.showThisHideOpen(contents[0]);




                </script>

            </td>
        </tr>
    </table>
    </form>
</body>
</html>
