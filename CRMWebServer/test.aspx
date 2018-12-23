<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="CRMWebServer.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" cellpadding="0" width="100%" border="0"> 
<tr> 
<td height="25" width="30%" align="right"> 
UName ： 
</td> 
<td height="25" width="*" align="left"> 
<asp:TextBox ID="txtUName" runat="server" Width="200px"></asp:TextBox> 
</td> 
</tr> 
<tr> 
<td height="25" width="30%" align="right"> 
UCountry ： 
</td> 
<td height="25" width="*" align="left"> 
<asp:TextBox ID="txtUCountry" runat="server" Width="200px"></asp:TextBox> 
</td> 
</tr> 
<tr> 
<td height="25" width="30%" align="right"> 
UProvince ： 
</td> 
<td height="25" width="*" align="left"> 
<asp:DropDownList ID="ddlUProvince" runat="server" onchange="ResetCity(this,'ddlUCity');"> 
</asp:DropDownList> 
</td> 
</tr> 
<tr> 
<td height="25" width="30%" align="right"> 
UCity ： 
</td> 
<td height="25" width="*" align="left"> 
<asp:DropDownList ID="ddlUCity" runat="server"> 
</asp:DropDownList> 
</td> 
</tr> 
<tr> 
<td height="25" colspan="2"> 
<div align="center"> 
<asp:Button ID="btnAdd" runat="server" Text="注册" OnClick="btnAdd_Click"></asp:Button> 
&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="读取" />
</div> 
</td> 
</tr> 
</table> 
<script type="text/javascript" src="js/Common.js">InitProvince('ddlUProvince');</script> 

    </div>
    </form>
</body>
</html>
