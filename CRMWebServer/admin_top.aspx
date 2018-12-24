<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_top.aspx.cs" Inherits="CRMWebServer.admin_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server" >
    <title>管理页面</title>
    
    <script type="text/javascript">
function logout(){
    if (confirm("您确定要退出控制面板吗？")) {

        top.location = "Nologin.aspx";
    }
}
</script>
<script language="javascript">
function showsubmenu(sid) {
	var whichEl = eval("submenu" + sid);
	var menuTitle = eval("menuTitle" + sid);
	if (whichEl.style.display == "none"){
		eval("submenu" + sid + ".style.display=\"\";");
	}else{
		eval("submenu" + sid + ".style.display=\"none\";");
	}
}
</script>

<meta http-equiv="refresh" content="60">
<script language=JavaScript1.2>
function showsubmenu(sid) {
	var whichEl = eval("submenu" + sid);
	var menuTitle = eval("menuTitle" + sid);
	if (whichEl.style.display == "none"){
		eval("submenu" + sid + ".style.display=\"\";");
	}else{
		eval("submenu" + sid + ".style.display=\"none\";");
	}
}
</script>   
<base target="main">
<link href="css/skin.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #FFFFFF;
            text-decoration: none;
            height: 38px;
            width: 254px;
            line-height: 38px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <div>
    <table width="100%" height="64" border="0" cellpadding="0" cellspacing="0" class="admin_topbg">
  <tr>
    <td width="61%" height="64"><img src="images/logo3.gif" width="262" height="64"></td>
    <td width="39%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="38" class="style1" align=right>
            <asp:Label ID="StaffName" runat="server"></asp:Label>
            <asp:Label ID="Labdate" runat="server" Text=""></asp:Label>
          </td>
        <td width="24%" align=right>
            <asp:ImageButton ID="ImageButtonBacktoMenu" runat="server" 
                imageUrl="~/images/home.gif" onclick="ImageButtonBacktoMenu_Click"/>
           <a href="#" target="_self" onClick="logout();return false">
                <asp:ImageButton ID="ImageButtonLogout" runat="server" 
                ImageUrl="~/images/out.gif" onclick="ImageButtonLogout_Click" /></a></td>
        <td width="4%">&nbsp;</td>
      </tr>
      <tr>
        <td height="19" colspan="3">&nbsp;</td>
        </tr>
    </table></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
