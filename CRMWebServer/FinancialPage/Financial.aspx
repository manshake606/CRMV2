<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Financial.aspx.cs" Inherits="CRMWebServer.FinancialPage.Financial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>合同管理页面</title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />

    <script src="../js/Calendar3.js" type="text/javascript"></script>

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
                                合同管理
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
                                        <span class="left_txt2">在这里，您可以查询合同详细</span><span class="left_txt2">！</span><br>
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
                            &nbsp;根据不同条件查询合同信息：
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
                                            <asp:Label ID="lblCotractID" runat="server" Text="合同编号：" Width="77px" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContractID" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbSignDate" runat="server" Text="签约开始日期：" Width="88px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSignDate" runat="server" Width="180px" onclick="new Calendar().show(this);"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            <asp:Label ID="lblOverTime" runat="server" Text="签约结束日期" CssClass="left_txt"></asp:Label>  
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOverTime" runat="server" Width="180px" onclick="new Calendar().show(this);" ></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <td>
                                            <asp:Label ID="lbEndDate" runat="server" Text="结案开始日期：" Width="88px" 
                                                CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndDate" runat="server" Width="180px" onclick="new Calendar().show(this);"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                         <asp:Label ID="lblLastTime" runat="server" Text="结案结束日期：" CssClass="left_txt"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastTime" runat="server" Width="180px" onclick="new Calendar().show(this);"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        <td>
                                            &nbsp;
                                        <asp:Button ID="btnSearch" runat="server" Text="查询" Width="80px" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;
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
                            &nbsp; 显示合同数据信息：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="GVFinancial" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GVFinancial_RowCancelingEdit"
                                OnRowEditing="GVFinancial_RowEditing" OnRowUpdating="GVFinancial_RowUpdating"
                                CellPadding="3" ForeColor="Black" GridLines="Horizontal" DataKeyNames="ContractID"
                                OnRowCommand="GVFinancial_RowCommand" Font-Size="Small" AllowPaging="True" OnPageIndexChanging="GVFinancial_PageIndexChanging"
                                PageSize="8" BackColor="White" BorderColor="#999999" BorderStyle="Groove" 
                                BorderWidth="2px">
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="ContractID" HeaderText="合同编号" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="签约日期">
                                        <ItemTemplate>
                                            <%# Eval("SignDate") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtSignDate" runat="server" Text='<%# Eval("SignDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="结案日期">
                                        <ItemTemplate>
                                            <%# Eval("EndDate") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEndDate" runat="server" Text='<%# Eval("EndDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="是否有代理">
                                        <ItemTemplate>
                                            <%#Eval("Proxy").ToString()=="0"?"无":"有" %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="dropProxy" runat="server">
                                                <asp:ListItem Value="0">无代理</asp:ListItem>
                                                <asp:ListItem Value="1">有代理</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hfldProxy" runat="server" Value='<%# Eval("Proxy") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="代理名称">
                                        <ItemTemplate>
                                            <%# Eval("ProxyName") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtProxyName" runat="server" Text='<%# Eval("ProxyName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="推荐人">
                                        <ItemTemplate>
                                            <%# Eval("RecommendPeople") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRecommendPeople" runat="server" Text='<%# Eval("RecommendPeople") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="推荐费用">
                                        <ItemTemplate>
                                            <%# Eval("ReferralFees") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtReferralFees" runat="server" Text='<%# Eval("ReferralFees") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="推荐费支付时间">
                                        <ItemTemplate>
                                            <%# Eval("ReferralFeesPayDate") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtReferralFeesPayDate" runat="server" Text='<%# Eval("ReferralFeesPayDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="是否有外包">
                                        <ItemTemplate>
                                            <%# Eval("OutSourcing").ToString()=="0"?"否":"是" %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="dropOutSourcing" runat="server">
                                                <asp:ListItem Value="0">无外包</asp:ListItem>
                                                <asp:ListItem Value="1">有外包</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hfldOutSourcing" runat="server" Value='<%# Eval("OutSourcing") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="外包人">
                                        <ItemTemplate>
                                            <%# Eval("OutSourcingPeople") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOutSourcingPeople" runat="server" Text='<%# Eval("OutSourcingPeople") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="外包费用">
                                        <ItemTemplate>
                                            <%# Eval("OutSourcingFees") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOutSourcingFees" runat="server" Text='<%# Eval("OutSourcingFees") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="外包费用支付时间">
                                        <ItemTemplate>
                                            <%# Eval("OutSourcingPayDate") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOutSourcingPayDate" runat="server" Text='<%# Eval("OutSourcingPayDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="外包说明">
                                        <ItemTemplate>
                                            <%# Eval("OutSourcingDirections") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOutSourcingDirections" runat="server" Text='<%# Eval("OutSourcingDirections") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="其它费用">
                                        <ItemTemplate>
                                            <%# Eval("OtherFees") %></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOtherFees" runat="server" Text='<%# Eval("OtherFees") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CustomerName" HeaderText="客户姓名" ReadOnly="True" />
                                    <asp:CommandField HeaderText="更新" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="合同费用">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LbtnPayment" runat="server" CommandArgument='<%# Eval("ContractID") %>'
                                                CommandName="Payment">缴款</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="海佣费用">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnSeaCommision" runat="server" CommandArgument='<%# Eval("ContractID") %>'
                                                CommandName="PayFees">缴费</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#5D7B9D" ForeColor="Black" HorizontalAlign="Center" />
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
                        <td class="left_txt">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;
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
            <td valign="bottom" background="images/mail_rightbg.gif">
                <img src="../images/buttom_right2.gif" width="16" height="17" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
