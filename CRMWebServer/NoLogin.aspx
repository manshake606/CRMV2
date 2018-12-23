<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoLogin.aspx.cs" Inherits="CRMWebServer.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<script type="text/javascript"> 
function Redirect() 
{        
    window.top.location = "login.aspx"; 
} 
</script>
<body onload="Redirect();">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
