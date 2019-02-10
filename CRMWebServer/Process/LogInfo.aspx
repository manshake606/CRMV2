<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInfo.aspx.cs" Inherits="CRMWebServer.Process.LogInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>日志查询</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        
        
    </script>
    <style type="text/css">
    #CalendarStart{display:none;}
    #CalendarEnd{display:none;}
    #CalendarAddCSdate{display:none;}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #F8F9FA;
    }
        .style5
        {
            width: 64%;
        }
        #TextArea1
        {
            width: 246px;
        }
        .style7
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            height: 30px;
        }
        .style9
        {
            width: 64%;
            height: 30px;
        }
        .style10
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 30px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="17" valign="top" background="../images/mail_leftbg.gif"><img src="../images/left-top-right.gif" width="17" height="29" /></td>
    <td valign="top" background="../images/content-bg.gif">
    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg" id="table2">
      <tr>
        <td height="31">
   
            <div class="titlebt">
                日志查询
                </div>
            </td>
      </tr>
    </table>
    </td>
    <td width="16" valign="top" background="images/mail_rightbg.gif"><img src="../images/nav-right-bg.gif" width="16" height="29" /></td>
  </tr>
  
  
  <tr>
    <td height="71" valign="middle" background="../images/mail_leftbg.gif">&nbsp;</td>
    <td valign="top" bgcolor="#F7F8F9">
    
    
    
    
    <table width="98%"  border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="13" valign="top">&nbsp;</td>
      </tr>
      <tr>
        <td valign="top">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td class="left_txt">当前位置：日志查询</td>
          </tr>
          <tr>
            <td height="20">
            <table width="100%" height="1" border="0" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC">
              <tr>
                <td></td>
              </tr>
            </table>
                </td>
          </tr>
          <tr>
            <td>
            <table width="100%" height="55" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="10%" height="55" valign="middle"><img src="../images/title.gif" width="54" height="55"></td>
                <td width="90%" valign="top"><span class="left_txt2">本页面负责查询客户的日志</span><span 
                        class="left_txt3"></span><span class="left_txt2"></span><br>
                          <span class="left_txt2"></span><span class="left_txt3"></span><span 
                        class="left_txt2"></span><span class="left_txt3"></span><span 
                        class="left_txt2"></span></td>
              </tr>
            </table>
            </td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td><table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="nowtable">
              <tr>
                <td class="left_bt2">&nbsp;&nbsp;&nbsp;日志信息查询</td>
              </tr>

            </table>
            </td>
          </tr>
          
          <tr>
            <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="20%" align="right" bgcolor="#f2f2f2" class="style7">
                    客户编号：</td>
               
                <td bgcolor="#f2f2f2" class="style9">
                    <asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CVCustomerID" runat="server" ErrorMessage="编号错误" CssClass="left_txt"></asp:CustomValidator>
                </td>
                <td width="45%" bgcolor="#f2f2f2" class="style10">样例：XXXX</td>
              </tr>
              <tr>
                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2"></td>
                
                <td height="30" bgcolor="#f2f2f2" class="style5">
                    <asp:Button ID="ButSearch" runat="server" Text="查找" Width="71px" class="Submit" 
                        onclick="ButSearch_Click"/>
                  &nbsp;
                    </td>
                <td height="30" bgcolor="#f2f2f2" class="left_txt">&nbsp;</td>
              </tr>
              <tr >
                <td height="30" align="right" bgcolor="#f2f2f2" class="left_txt2"></td>
                
                <td bgcolor="#f2f2f2" class="style5">
                    <asp:GridView ID="gvLogInfo" runat="server" CellPadding="3" ForeColor="Black" 
                        GridLines="Horizontal" AutoGenerateColumns="False" 
                        onrowdatabound="gvLogInfo_RowDataBound" Width="671px" CssClass="left_txt" 
                        BackColor="White" BorderColor="#999999" BorderStyle="Groove" 
                        BorderWidth="2px">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="DStaffName" HeaderText="指派人" >
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CustomerName" HeaderText="客户" >
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StaffName" HeaderText="被指派人" >
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AssignStatus" HeaderText="指派状态" >
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BindDate" HeaderText="指派时间" >
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remark" HeaderText="备注" >
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
                    </asp:GridView></td>
               <td height="30"  bgcolor="#f2f2f2" class="left_txt2"></td>
               
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
    <td valign="bottom" background="../images/mail_leftbg.gif"><img src="../images/buttom_left2.gif" width="17" height="17" /></td>
    <td background="../images/buttom_bgs.gif"><img src="../images/buttom_bgs.gif" width="17" height="17"></td>
    <td valign="bottom" background="../images/mail_rightbg.gif"><img src="../images/buttom_right2.gif" width="16" height="17" /></td>
  </tr>

</table>

    </form>
</body>
</html>
