<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskAssign.aspx.cs" Inherits="CRMWebServer.Process.TaskAssign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>任务指派</title>
    <script type="text/javascript">
        function SelectAllCheckboxest(tableName) {
            var rowcount = document.getElementById(tableName).rows.length;
            var all = document.getElementById(tableName + "_ctl01_chkAll");
            for (var a = 2; a <= rowcount; a++) {
                if (a >= 10)
                    var ckid = tableName + "_ctl&_checkid";
                else
                    var ckid = tableName + "_ctl0&_checkid";
                var aa = document.getElementById(ckid.replace("&", a));
               
                if (all.checked)
                    aa.checked=true;
                else
                    aa.checked = false;
            }
        }

        function ConfirmAdd() {
            if (confirm("确定此操作吗?")) {
                document.getElementById("HiddenField1").value = "1";
            }
            else {
                document.getElementById("HiddenField1").value = "0";
            }
        }
     </script>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            width: 1047px;
        }
        .style2
        {
            width: 1047px;
        }
        .style4
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            width: 83px;
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
                任务指派
                </div>
            </td>
      </tr>
    </table>
    </td>
    <td width="16" valign="top" background="../images/mail_rightbg.gif"><img src="../images/nav-right-bg.gif" width="16" height="29" /></td>
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
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td class="left_txt">当前位置：任务指派</td>
          </tr>
          <tr>
            <td height="20"><table width="100%" height="1" border="0" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC">
              <tr>
                <td></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td><table width="100%" height="55" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="10%" height="55" valign="middle"><img src="../images/title.gif" width="54" height="55"></td>
                <td width="90%" valign="top"><span class="left_txt2">本页面负责指派任务，标记任务状态</span><span 
                        class="left_txt3"></span><span class="left_txt2"></span><br>
                          <span class="left_txt2"></span><span class="left_txt3"></span><span 
                        class="left_txt2"></span><span class="left_txt3"></span><span 
                        class="left_txt2"></span></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>
            <table width="100%"  border="0" cellpadding="0" cellspacing="0" class="nowtable">
              <tr>
                <td class="left_bt2">&nbsp;&nbsp;&nbsp;客户状态查询</td>
              </tr>
            <tr>
            <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="left" bgcolor="#f2f2f2"  class="style4">
                <asp:Label ID="Label1" runat="server" Text="指派状态：" CssClass="left_txt2"></asp:Label>
                </td>
                <td height="30" bgcolor="#f2f2f2"  class="style5">
                   
                    <asp:DropDownList ID="DDListAssignStatus" runat="server" Width="80px" 
                        >
                    </asp:DropDownList>
                    <asp:Label ID="Label6" runat="server" Text="所在省份：" CssClass="left_txt2"></asp:Label><asp:DropDownList ID="ddlUProvince" runat="server" Width="80px" 
                          AutoPostBack="True" 
                        onselectedindexchanged="ddlUProvince_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="Label4" runat="server" Text="所在城市：" CssClass="left_txt2"></asp:Label><asp:DropDownList ID="ddlUCity" runat="server" Width="80px" >
                    </asp:DropDownList>
                    <asp:Label ID="Label3" runat="server" Text="导入人：" CssClass="left_txt2"></asp:Label>
                    <asp:DropDownList ID="DDImportPeople" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="Label5" runat="server" Text="意向国家：" CssClass="left_txt2"></asp:Label>
                    <asp:DropDownList ID="DDCountry" runat="server">
                    </asp:DropDownList>
                    
                    
                    </asp:DropDownList>
                
                
            </tr>
            <tr>
            <td height="30" align="left" bgcolor="#f2f2f2"  class="style4">
                <asp:Label ID="Label7" runat="server" Text="重要性：" CssClass="left_txt2"></asp:Label>
                </td>
            <td height="30" bgcolor="#f2f2f2"  class="style5">
            <asp:DropDownList ID="DDImportance" runat="server" style="height: 22px">
                    </asp:DropDownList>
                    <asp:Label ID="Label8" runat="server" Text="客户分类：" CssClass="left_txt2"></asp:Label>
                    
                  

                  
                    <asp:DropDownList ID="DDCustomerClass" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="Label9" runat="server" Text="数据来源：" CssClass="left_txt2"></asp:Label>
                    <asp:DropDownList ID="DDFromData" runat="server">
                    </asp:DropDownList>
            <asp:Label ID="Label10" runat="server" Text="跟进顾问：" CssClass="left_txt2"></asp:Label>
            <asp:DropDownList ID="DDFollowConsultant" runat="server">
                    </asp:DropDownList>
            
            <asp:Label ID="Label11" runat="server" Text="跟进文案：" CssClass="left_txt2"></asp:Label>
            <asp:DropDownList ID="DDCopywriter" runat="server">
                    </asp:DropDownList>
            
            </td>
                
            
            </tr>

             <tr>
                  
                
                <td height="30" bgcolor="#f2f2f2" class="style5">
                  <asp:Button ID="ButSearch" runat="server" Text="查找" Width="71px" class="Submit" 
                        onclick="ButSearch_Click"/></td>
                </td>
                <td bgcolor="#f2f2f2">
                    <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" 
                        Text="导出数据" />
                 <asp:Button ID="btnTrans" runat="server" Text="客户转移" onclick="btnTrans_Click" />
                 </td>
                
            </tr>
            
            </table>

            </td>
            </tr>
            </table>
            </td>
          </tr>
          
          <tr>
            <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            
              <tr >
                <td bgcolor="#f2f2f2" class="style2" width="100%">
                    <asp:GridView ID="GVshowCustomerState" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" 
                        CssClass="left_txt" EmptyDataText="无符合条件记录" FooterStyle-BackColor="#FF3300" 
                        ForeColor="Black" GridLines="Horizontal" 
                        onpageindexchanging="GVshowCustomerState_PageIndexChanging" 
                        onrowcommand="GVshowCustomerState_RowCommand" 
                        onrowdatabound="GVshowCustomerState_RowDataBound" 
                        onsorting="GVshowCustomerState_Sorting" PageSize="30" style="margin-right: 0px" 
                        Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Groove" 
                        BorderWidth="2px">
                        <PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" 
                            PreviousPageText="上一页" />
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="选项">
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkid" runat="server" />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" 
                                        onclick="SelectAllCheckboxest('GVshowCustomerState');" />
                                </HeaderTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CustomerID" HeaderText="客户ID" SortExpression="CustomerID"/>
                            <asp:BoundField DataField="CustomerName" HeaderText="姓名" />
                            <asp:BoundField DataField="Sex" HeaderText="性别" />
                            <asp:BoundField DataField="Grade" HeaderText="年级" />
                            <asp:BoundField DataField="Telphone" HeaderText="电话" />
                            <asp:BoundField DataField="IntentionCountry" HeaderText="意向国家" />
                            <asp:TemplateField HeaderText="城市缩写" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LabCityInitial" runat="server" Text='<%# Bind("CityInitial") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CityInitial") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CustomerImportance" HeaderText="重要性" 
                                SortExpression="CustomerImportance" />
                            <asp:BoundField DataField="CustomerClass" HeaderText="客户分类" 
                                SortExpression="CustomerClass" />
                            <asp:TemplateField HeaderText="员工ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LabStaffID" runat="server" Text='<%# Bind("StaffID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="StaffName" HeaderText="绑定员工" />
                            <asp:BoundField DataField="AssignStatus" HeaderText="指派状态" SortExpression="AssignStatus"/>
                            <asp:TemplateField HeaderText="客户编号" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LabCustomerID" runat="server" Text='<%# Bind("CustomerID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AssignTime" HeaderText="指派时间" SortExpression="AssignTime"/>
                            <asp:TemplateField HeaderText="文档上传" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Mylinkbutton" runat="server" CausesValidation="False" 
                                        CommandArgument='<%# bind("CustomerID") %>' CommandName="upload" Text="上传文档"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField DataNavigateUrlFields="CustomerID" 
                                DataNavigateUrlFormatString="~/Customer/CustomerInfoDetails.aspx?CustomerID={0}" 
                                HeaderText="详细" Text="详细" />
                            <asp:HyperLinkField DataNavigateUrlFields="CustomerID" 
                                DataNavigateUrlFormatString="~/FinancialPage/NewContract.aspx?CustomerID={0}" 
                                HeaderText="合同管理" Text="合同管理" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" BorderStyle="Solid" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                            <PagerTemplate>
                                    <table>
                                        <tr>
                                            <td style="text-align: right">
                                                第<asp:Label ID="lblPageIndex" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>"></asp:Label>页
                                                共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount %>"></asp:Label>页
                                                <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                    CommandName="Page" Text="首页" ForeColor="White"></asp:LinkButton>
                                                <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                    CommandName="Page" Text="上一页" ForeColor="White"></asp:LinkButton>
                                                <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                    CommandName="Page" Text="下一页" ForeColor="White"></asp:LinkButton>
                                                <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                    CommandName="Page" Text="尾页" ForeColor="White"></asp:LinkButton>
                                                <asp:TextBox ID="txtNewPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1%>"
                                                    Width="20px"></asp:TextBox>
                                                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                    CommandName="Page" Text="GO" ForeColor="White"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>
                    </asp:GridView>
                  </td>

              </tr>
              <tr>
                <td height="30" align="left" bgcolor="#f2f2f2" class="style1">
                    
                    <asp:Button ID="btnallchoose" runat="server" Text="导入待指派客户" Width="101px" class="Submit" 
                        onclick="btnallchoose_Click"/>
                        <asp:Button ID="btnreset" runat="server" Text="重置待指派客户" Width="101px" 
                        class="Submit" onclick="btnreset_Click"/>
                  </td>

              </tr>
 
              </table>
              
              
              
              </td>
          </tr>
          <tr>
          <td>
          <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="nowtable">
          <tr>
                <td class="left_bt2">&nbsp;&nbsp;&nbsp;任务指派</td>
          </tr>
          <tr>
          <td>
          
          
          
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="left" bgcolor="#f2f2f2" class="style4">
                    <asp:Label ID="LabCustomerName" runat="server" Text="待指派客户："></asp:Label>
                    </td>

                <td height="30" bgcolor="#f2f2f2" class="style5">
                    <asp:ListBox ID="LbCustomerName" runat="server" Width="83px" 
                        SelectionMode="Multiple" AutoPostBack="True" 
                        onselectedindexchanged="LbCustomerName_SelectedIndexChanged" Height="34px"></asp:ListBox>
                </td>
                
              </tr>
            <tr>
                <td height="30" align="left" bgcolor="#f2f2f2" class="style4">
                    公司省份：</td>
                
                <td height="30" bgcolor="#f2f2f2" class="style5">
                    <asp:DropDownList ID="ddlGWProvince" runat="server" Width="80px" 
                          AutoPostBack="True" 
                        onselectedindexchanged="ddlGWProvince_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="LabCity" runat="server" Text="公司城市：" CssClass="left_txt2"></asp:Label>
                    <asp:DropDownList ID="ddlGWCity" runat="server" Width="80px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlGWCity_SelectedIndexChanged">
                    </asp:DropDownList>
                    
                    <asp:Label ID="Label2" runat="server" Text="指派经理：" CssClass="left_txt2">
                    </asp:Label>
                    <asp:DropDownList ID="DDlistManager" runat="server" Width="80px" >
                    </asp:DropDownList>
                    
                    <asp:Label ID="LabGW" runat="server" Text="指派顾问：" CssClass="left_txt2"></asp:Label>
                    <asp:DropDownList ID="DDlistGWName" runat="server" Width="80px">
                    </asp:DropDownList>
                    
                    <asp:Label ID="LabWA" runat="server" Text="文案姓名：" CssClass="left_txt2"></asp:Label>
                    <asp:DropDownList ID="DDlistCopyWriter" runat="server" Width="80px">
                    </asp:DropDownList>
                    
                    <asp:Label ID="LabAssign" runat="server" Text="任务指派：" CssClass="left_txt2"></asp:Label>
                    <asp:DropDownList ID="DDAssign" runat="server" Width="80px" 
                        AutoPostBack="True" onselectedindexchanged="DDAssign_SelectedIndexChanged">
                    </asp:DropDownList>
                    
                    
                </td>
               
            </tr>
            
              
              <tr>
                <td height="30" align="left" bgcolor="#f2f2f2" class="style4">
                    备注：
                    </td>

                <td height="30" bgcolor="#f2f2f2" class="style5">
                    <asp:TextBox ID="txtRemark" runat="server" CssClass=left_txt Height="29px" 
                        TextMode="MultiLine" Width="629px"></asp:TextBox>
                </td>
                
              </tr>
           
            
          
            <tr>
                <td height="30" align="left" bgcolor="#f2f2f2" class="style4">
                    指派或标记：</td>

                <td height="30" bgcolor="#f2f2f2" class="style5">
                    <asp:Button ID="BtnConfirm" runat="server" Text="确认" Width="71px" 
                        class="Submit" onclick="BtnConfirm_Click"/><asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
               
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
