<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRMWebServer.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<title>登陆页面</title>
<style type="text/css">

body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
background-color: #1D3647;

}

    .style1
    {
        height: 20px;
    }

    .style2
    {
        width: 16%;
    }

</style>
<link href="css/skin.css" rel="stylesheet" type="text/css">
<body >
<form id="form1" runat="server">
<table width="100%" height="800" border="0" cellpadding="0" cellspacing="0" class="login_bg">
  <tr>
    <td height="42" valign="top">
    <table width="100%" height="42" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
    </table>
    </td>
  </tr>
  <tr>
    <td >
    <table width="100%"  border="0" cellpadding="0" cellspacing="0" >
      <tr>
        <td width="49%" align="right">
        <table width="91%"  border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td height="344" valign="top">
              <table width="89%"  border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td class="style1"></td>
                </tr>
                <tr>
                  <td height="80" align="right" valign="top"><img src="images/logo5.png" width="279" height="68"></td>
                </tr>
                <tr>
                  <td height="115" align="right" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                        <td width="35%">&nbsp;</td>
                        <td height="25" colspan="2" class="left_txt" align="right"><p>1- 澳星环宇为出国的客户提供首选方案...</p></td>
                        </tr>
                        <tr>
                        <td>&nbsp;</td>
                        <td height="25" colspan="2" class="left_txt" align="right"><p>2- 一站通式的整合方式，方便用户使用...</p></td>
                        </tr>
                        <tr>
                        <td>&nbsp;</td>
                        <td height="25" colspan="2" class="left_txt" align="right"><p>3- 强大的后台系统，管理内容易如反掌...</p></td>
                        </tr>
                        <tr>
                        <td>&nbsp;</td>
                        <td width="30%" height="40"><img src="images/icon-demo.gif" width="16" height="16"><a href="http://www.austarstudy.com/" target="_blank" >使用说明</a> </td>
                        <td width="35%"><img src="images/icon-login-seaver.gif" width="16" height="16"><a href="http://www.austarstudy.com/" target="_blank" >在线客服</a></td>
                        </tr>
                    </table>
                  </td>
                </tr>
              </table>
              </td>
            </tr>
        </table>
        </td>
        <td width="1%" >&nbsp;</td>
        <td width="50%" valign="bottom">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="4%">&nbsp;</td>
              <td width="96%" height="90" align="bottom"><span class="login_txt_bt"></span></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>
              <table cellSpacing="0" cellPadding="0" width="100%" border="0" id="table211" height="307">
                  <tr>
                    <td height="143" colspan="2" align="middle">
                        <table cellSpacing="0" cellPadding="0" width="100%" border="0" height="143" id="table212">
                          <tr>
                            <td height="38" class="style2"><span class="login_txt">用户名：&nbsp;&nbsp; </span></td>
                            <td height="38" colspan="2" class="top_hui_text" align="left"><input  id ="txtLoginName" type ="text"  name="username" class="editbox4" value="" size="20" runat ="server" ></input> 
                                </td>
                          </tr>
                          <tr>
                            <td height="35" class="style2" ><span class="login_txt">密 码：&nbsp;&nbsp; </span></td>
                            <td height="35" colspan="2" class="top_hui_text" align="left"><input  id ="txtPassword" class="editbox4" type="password" size="20" name="password" runat ="server" ></input>
                              <img src="images/luck.gif" width="19" height="18"> </td>
                          </tr>                          
                          <tr>
                            <td height="35" class="style2"  >&nbsp;<asp:Button ID="btnLogin" runat="server" 
                                    Text="登陆" onclick="btnLogin_Click" /><%--<input name="Submit" type="submit"  class="button" id="Submit" value="登陆" runat ="server" onclick = "Button_click()" ></input> --%></td>
                            <td width="20%" height="35" ><input type ="reset" value ="取消" name ="Cancel" /> <%--< <input name="cs" type="button" class="button" id="cs" value="取消" onClick="showConfirmMsg1()"> --%></td>
                            <td width="67%" class="top_hui_text"></td>
                          </tr>
                        </table>
                    </td>
                  </tr>
                  <tr>
                    <td width="433" height="80" align="right" valign="bottom"></td>
                    <td width="57" align="right" >&nbsp;</td>
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

  <tr>
  <td >
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="login-buttom-bg">
      <tr>
        <td align="center"><span class="login-buttom-txt">Copyright &copy; 2009-2010 www.865171.cn</span></td>
      </tr>
    </table>
  </td>
  </tr>
</table>
</form>
</body>
