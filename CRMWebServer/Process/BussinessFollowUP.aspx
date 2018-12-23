<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BussinessFollowUP.aspx.cs" Inherits="CRMWebServer.Process.BussinessFollowUP" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>业务跟进</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar3.js">

        function ConfirmAdd() {
            if (confirm("确定要插入吗?")) {
                document.getElementById("HiddenField1").value = "1";
            }
            else {
                document.getElementById("HiddenField1").value = "0";
            }
        }

        
        
    </script>
    <script type="text/javascript">
        function logout() {
            top.location = "../login.aspx";
        }
    
    </script>

    <style type="text/css">


body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #EEF2FB;
    }
        
    
    
        .style5
        {
            width: 57%;
        }
        #TextArea1
        {
            width: 246px;
        }
        .style11
        {
            width: 19px;
        }
        .style12
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            height: 30px;
            width: 65%;
        }
        .style13
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #000000;
            height: 30px;
            width: 57%;
        }
        </style>
</head>
<body>
<form id="form1" runat="server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="18" valign="top" background="../images/mail_leftbg.gif"><img src="../images/left-top-right.gif" width="18" height="29" /></td>
    <td valign="top" background="../images/content-bg.gif">
    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg" id="table2">
      <tr>
        <td height="31">
   
            <div class="titlebt">
                业务跟进
                </div>
            </td>
      </tr>
    </table>
    </td>
    <td width="16" valign="top" background="images/mail_rightbg.gif"><img src="../images/nav-right-bg.gif" width="16" height="29" /></td>
  </tr>
    <tr>
    <td  valign="middle" background="../images/mail_leftbg.gif" ></td>
    
    
    
    
    <td valigcn="top" bgcolor="#F7F8F9">
    
    
    
    
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
       <td>
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td class="left_txt">当前位置：业务跟进</td>
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
                <td width="90%" valign="top"><span class="left_txt2">本页面负责查询,添加,修改客户的跟进信息</span><span 
                        class="left_txt3"></span><span class="left_txt2"></span><br>
                          <span class="left_txt2"></span><span class="left_txt3"></span><span 
                        class="left_txt2"></span><span class="left_txt3"></span><span 
                        class="left_txt2"></span>
                        
               </td>
              </tr>
            </table>
            </td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            
            
            
            
            
            
            
            
            
            
          </tr>
          <tr>
            <td>
            <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="nowtable">
              <tr>
                <td class="left_bt2">&nbsp;&nbsp;&nbsp;业务跟进信息查询</td>
              </tr>

            </table>
            </td>
          </tr>
          <tr>
            <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            
               <tr>
                <td  bgcolor="#f2f2f2" class="style13">
                    客户姓名：<asp:DropDownList ID="DDListCustomerName" runat="server" Width="114px">
                    </asp:DropDownList>
                    
                    顾问姓名：<asp:DropDownList ID="DDListEmployeeName" runat="server" Width="114px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DDListEmployeeName_SelectedIndexChanged" >
                    </asp:DropDownList>
                    
                    开始时间：<asp:TextBox ID="txtStarttime" runat="server" onclick="new Calendar().show(this);"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="REVStarttime" runat="server" 
                        ControlToValidate="txtStarttime" ErrorMessage="时间格式有误" 
                        
                        ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))" 
                        CssClass="left_txt" Display="Dynamic"></asp:RegularExpressionValidator>
                截止时间：<asp:TextBox ID="txtCalendarEnd" runat="server" 
                     onclick="new Calendar().show(this);" 
                        ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtCalendarEnd" ErrorMessage="时间格式有误" 
                        
                        ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))" 
                        CssClass=left_txt Display="Dynamic"></asp:RegularExpressionValidator>

                   </td>
                
               
                
                
              </tr>

              <tr>
                <td height="30" bgcolor="#f2f2f2" class="style13">
                    <asp:Button ID="ButSearch" runat="server" Text="查找" Width="71px" class="Submit" 
                        onclick="ButSearch_Click"/>
                  </td>
                
                
              </tr>
              <tr >
                
                
                <td bgcolor="#f2f2f2" class="style5">
                   <asp:GridView ID="gv_showfollowupInfo" runat="server" CellPadding="3" 
                       ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" 
                        DataKeyNames="CSID" 
                        onrowcancelingedit="gv_showfollowupInfo_RowCancelingEdit" 
                        onrowediting="gv_showfollowupInfo_RowEditing" 
                        onrowupdating="gv_showfollowupInfo_RowUpdating" 
                        onrowdatabound="gv_showfollowupInfo_RowDataBound" AllowPaging="True" 
                        onpageindexchanging="gv_showfollowupInfo_PageIndexChanging" Width="100%" 
                        CssClass="left_txt" PageSize="30" AllowSorting="True" 
                        onsorting="gv_showfollowupInfo_Sorting" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Groove" BorderWidth="2px">
                       <RowStyle HorizontalAlign="Center" />
                       <Columns>
                           <asp:BoundField DataField="CustomerID" HeaderText="客户ID" SortExpression="CustomerID">
                           <FooterStyle HorizontalAlign="Center" />
                           <HeaderStyle HorizontalAlign="Center" />
                           <ItemStyle HorizontalAlign="Center" />
                           </asp:BoundField>
                           <asp:TemplateField HeaderText="客户姓名">
                               <EditItemTemplate>
                                   <asp:DropDownList ID="DDlistCName" runat="server">
                                   </asp:DropDownList>
                                   <asp:HiddenField ID="hidtxt" runat="server" Value='<%# bind("CustomerID") %>' />
                               </EditItemTemplate>
                               <ItemTemplate>
                                   <asp:Label ID="LabCustomerName" runat="server" 
                                       Text='<%# Bind("CustomerName") %>'></asp:Label>
                               </ItemTemplate>
                               <FooterStyle HorizontalAlign="Center" />
                               <HeaderStyle HorizontalAlign="Center" />
                               <ItemStyle HorizontalAlign="Center" />
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="城市简写" Visible="False">
                               <EditItemTemplate>
                                   <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CityInitial") %>'></asp:TextBox>
                               </EditItemTemplate>
                               <ItemTemplate>
                                   <asp:Label ID="LabCityInitial" runat="server" Text='<%# Bind("CityInitial") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="跟进内容">
                               <EditItemTemplate>
                                   <asp:TextBox ID="TxtCSContent" runat="server" Text='<%# Bind("CSContent") %>' 
                                       TextMode="MultiLine"></asp:TextBox>
                               </EditItemTemplate>
                               <ItemTemplate>
                                   <asp:Label ID="LabCSContent" runat="server" Text='<%# Bind("CSContent") %>'></asp:Label>
                               </ItemTemplate>
                               <ControlStyle Width="50%" />
                               <FooterStyle HorizontalAlign="Center" Width="50%" />
                               <HeaderStyle HorizontalAlign="Center" Width="50%" />
                               <ItemStyle HorizontalAlign="Center" Width="50%" />
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="跟进日期" SortExpression="CSDate">
                               <EditItemTemplate>
                                   <asp:TextBox ID="TxtCSDate" runat="server" Text='<%# Bind("CSDate") %>'></asp:TextBox>
                               </EditItemTemplate>
                               <ItemTemplate>
                                   <asp:Label ID="LabCSDate" runat="server" Text='<%# Bind("CSDate") %>'></asp:Label>
                               </ItemTemplate>
                               <FooterStyle HorizontalAlign="Center" />
                               <HeaderStyle HorizontalAlign="Center" />
                               <ItemStyle HorizontalAlign="Center" />
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="跟进员工" SortExpression="StaffName">
                               <EditItemTemplate>
                                   <asp:DropDownList ID="DDlistStaffName" runat="server" >
                                   </asp:DropDownList>
                                   <asp:HiddenField ID="HidStafftxt" runat="server" 
                                       Value='<%# Bind("StaffID") %>' />
                               </EditItemTemplate>
                               <ItemTemplate>
                                   <asp:Label ID="LabStaffName" runat="server" Text='<%# Bind("StaffName") %>'></asp:Label>
                               </ItemTemplate>
                               <FooterStyle HorizontalAlign="Center" />
                               <HeaderStyle HorizontalAlign="Center" />
                               <ItemStyle HorizontalAlign="Center" />
                           </asp:TemplateField>
                           <asp:HyperLinkField DataNavigateUrlFields="CustomerID" 
                               DataNavigateUrlFormatString="~/Customer/CustomerInfoDetails.aspx?CustomerID={0}" 
                               HeaderText="详细" Text="详细">
                           <FooterStyle HorizontalAlign="Center" />
                           <HeaderStyle HorizontalAlign="Center" />
                           <ItemStyle HorizontalAlign="Center" />
                           </asp:HyperLinkField>
                       </Columns>
                       <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
                       <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
                       <EmptyDataTemplate>
                           <asp:Label ID="LabEmpty" runat="server" Text="记录为空！！" CssClass="left_txt"></asp:Label>
                       </EmptyDataTemplate>
                       <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
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
              <td  bgcolor="#f2f2f2" class="style13"></td>
              </tr>
              <tr>
              <td bgcolor="#f2f2f2" class="style5">
                  <asp:GridView ID="GVCount" runat="server" AutoGenerateColumns="False" width="100%"
                      CellPadding="3" ForeColor="Black" GridLines="Vertical" CssClass="left_txt" 
                      onrowdatabound="GVCount_RowDataBound" BackColor="White" 
                      BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                      <Columns>
                          <asp:BoundField DataField="StaffName" HeaderText="员工姓名" >
                          <FooterStyle HorizontalAlign="Center" />
                          <HeaderStyle HorizontalAlign="Center" />
                          <ItemStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="CustomerCount" HeaderText="跟进次数" >
                          <FooterStyle HorizontalAlign="Center" />
                          <HeaderStyle HorizontalAlign="Center" />
                          <ItemStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                      </Columns>
                      <FooterStyle BackColor="#5D7B9D" />
                      <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                      <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                      <AlternatingRowStyle BackColor="#CCCCCC" />
                  </asp:GridView>
              
              
              </td>
              
              </tr>

              </table>
          </td>
          </tr>
          <tr>
          <td>
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30"  bgcolor="#f2f2f2" class="style12">
                    <asp:DropDownList ID="DDlistAddCustomerName" runat="server" Width="114px" 
                        Visible="False">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DDlistAddStaffName" runat="server" Width="114px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DDlistAddStaffName_SelectedIndexChanged" 
                        Visible="False">
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtAddCSDate" runat="server" 
                        onclick="new Calendar().show(this);" Visible="False"></asp:TextBox>
                    
                </td>
                

                <td width="45%" height="30" bgcolor="#f2f2f2" class="left_txt">&nbsp;</td>
            </tr>
            <tr>
                <td height="30"  bgcolor="#f2f2f2" class="style12">
                    <asp:TextBox ID="TxtCSContent0" runat="server" TextMode="MultiLine" 
                        Width="253px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TxtRemark" runat="server" TextMode="MultiLine" 
                        Width="253px" Visible="False"></asp:TextBox>
                </td>
                
                
                <td width="45%" height="30" bgcolor="#f2f2f2" class="left_txt">&nbsp;</td>
              </tr>
            <tr>
                <td height="30"  bgcolor="#f2f2f2" class="style12"><asp:Button ID="ButAdd" 
                        runat="server" Text="添加" Width="71px" class="Submit" 
                        onclick="ButAdd_Click" Visible="False"/>
                    <asp:HiddenField ID="HiddenField1" runat="server" Visible="False" />
                </td>
                

                <td height="30" bgcolor="#f2f2f2" class="left_txt">&nbsp;</td>
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
    <td valign="bottom" background="../images/mail_leftbg.gif" class="style11"><img src="../images/buttom_left2.gif" width="17" height="17" /></td>
    <td background="../images/buttom_bgs.gif"><img src="../images/buttom_bgs.gif" width="17" height="17"></td>
    <td valign="bottom" background="../images/mail_rightbg.gif"><img src="../images/buttom_right2.gif" width="16" height="17" /></td>
  </tr>
</table>

</form>
</body>
</html>
