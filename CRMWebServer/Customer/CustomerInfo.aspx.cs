using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using CRMControlService;
using ModelService;

namespace CRMWebServer.Customer
{
    public partial class CustomerInfo : System.Web.UI.Page
    {
        #region 全局参数声明
        //全局参数声明
        public string City = "城市";
        string sttafID = string.Empty;
        int customerID = 0;
        int rowsCount = 0;
        DataTable TB = new DataTable();
        ModelService.CustomerInfo CSIF = new ModelService.CustomerInfo();
        ModelService.Intention CIntention = new ModelService.Intention();
        //ModelService.StaffInfo SSaffInfo = new ModelService.StaffInfo();
        string GStaffName = string.Empty;
        string WStaffName = string.Empty;
        //CustomerService CS = null;
        //CustomerInfo myCI = null;
        //DataSet ds = null;
        CustomerService CSS = new CustomerService();
        DataSet ds = new DataSet();

        StaffInfo staffInfo = new StaffInfo();
        string moduleID = ConfigurationManager.AppSettings["CustomerInfo"];
        int authority = 0;
        CRMControlService.AuthorityService AS = new AuthorityService();
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        //public CustomerInfo()
        //{
        //    //参数实例化
        //    CS = new CustomerService();
        //    myCI = new CustomerInfo();
        //    ds = new DataSet();
        //}
        #endregion
        #region 页面载入数据
        protected void Page_Load(object sender, EventArgs e)
        {
            //DropDownList 数据绑定

            if (HttpContext.Current.Session["staffID"] != null)
            {
                staffInfo.StaffID = Int32.Parse(HttpContext.Current.Session["staffID"].ToString());
            }
            else
            {
                Response.Write("<script>alert('长时间未登陆，请重新登陆')</script>");
                Response.Write("<script>window.top.location='../Nologin.aspx';</script>");
                return;
            }

            authority = AS.CheckAuthorityByStaffID_Service(staffInfo.StaffID, moduleID);
            if (authority == 0)
            {
                Response.Redirect("../Error/404.aspx");
            }

            if (!IsPostBack)
            {
                BindProvince();
                BindDataToDropDownList();
                ViewState["SortOrder"] = "CustomerClass";
                ViewState["OrderDire"] = "ASC";
                //GetCustomerInformation();
                DataSet dsI = CSS.GetImportanceIntroduction_Service();
                GVIntroduction.DataSource = dsI;
                GVIntroduction.DataBind();
                
            }
              
        }
        #endregion
        #region  DropDownList 数据源绑定
        /// <summary>
        /// DropDownList数据源绑定
        /// </summary>
        protected void BindDataToDropDownList()
        {
            //客户重要性的绑定
            ddlCustomerImportant.DataTextField = "客户重要性";
            ddlCustomerImportant.DataValueField = "001";
            ddlCustomerImportant.DataBind();
            ddlCustomerImportant.Items.Add(new ListItem("不重要", "0"));
            ddlCustomerImportant.Items.Add(new ListItem("一般", "1"));
            ddlCustomerImportant.Items.Add(new ListItem("重要", "2"));
            ddlCustomerImportant.Items.Add(new ListItem("特别重要", "3"));
            //ddlCustomerImportant.Items.Add(new ListItem("不重要", "4"));

            ////客户分类绑定            
            //ddlCustomerClass.Items.Add(new ListItem(" 客户分类", "0"));
            ddlCustomerClass.Items.Add(new ListItem("未分类", "0"));
            ddlCustomerClass.Items.Add(new ListItem("短期潜在", "1"));
            ddlCustomerClass.Items.Add(new ListItem("长期潜在", "2"));
            ddlCustomerClass.Items.Add(new ListItem("意向不明", "3"));
            ddlCustomerClass.Items.Add(new ListItem("已签约", "4"));
            //ddlCustomerClass.Items.Add(new ListItem("未签约", "5"));
            ddlCustomerClass.Items.Add(new ListItem("已流失", "5"));

            //客户来源绑定
            //ddlDataResource.Items.Add(new ListItem("来源未知", "0"));
            //ddlDataResource.Items.Add(new ListItem("名单预约", "1"));
            //ddlDataResource.Items.Add(new ListItem("客户推荐", "2"));
            //ddlDataResource.Items.Add(new ListItem("移民推荐", "3"));
            //ddlDataResource.Items.Add(new ListItem("常州推荐", "4"));
            //ddlDataResource.Items.Add(new ListItem("主动上门", "5"));
            //ddlDataResource.Items.Add(new ListItem("网络来源", "6"));
            //ddlDataResource.Items.Add(new ListItem("个人渠道", "7"));
        }
        #endregion
        #region private void BindProvince() 省份名称绑定
        /// <summary>
        /// 省份名称数据绑定
        /// </summary>
        protected void BindProvince()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.ddlProvince.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes;
                XmlNode nodeCity = doc.DocumentElement.SelectSingleNode(@"Province/City[@Name='" + this.City + "']");
                foreach (XmlNode node in nodes)
                {
                    this.ddlProvince.Items.Add(node.Attributes["Name"].Value);
                    int n = this.ddlProvince.Items.Count - 1;
                    if (nodeCity != null && node == nodeCity.ParentNode)
                        this.ddlProvince.SelectedIndex = n;
                }
                //.SelectedItem.Text;
                //txtCurrentCity.Text = this.ddlCity.SelectedValue;
                BindCity();

            }
            else
            {

            }
        }
        #endregion
        #region private void BindCity() 城市名称数据绑定
        /// <summary>
        /// 城市名称数据绑定
        /// </summary>
        protected void BindCity()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.ddlCity.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes[this.ddlProvince.SelectedIndex].ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    this.ddlCity.Items.Add(node.Attributes["Name"].Value);
                    int n = this.ddlCity.Items.Count - 1;
                    if (node.Attributes["Name"].Value == this.City)
                    {
                        this.ddlCity.SelectedIndex = n;
                    }
                }
                if (this.ddlCity.SelectedIndex == -1)
                    this.ddlCity.SelectedIndex = 0;
            }
            else
            {

            }

        }
        #endregion
        #region 省份城市联动事件
        /// <summary>
        /// 省份城市联动，选择的省份改变，将触发此事件检索该省份所包含的城市名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();//绑定城市数据
        }
        #endregion
        #region 搜索事件
        /// <summary>
        /// 搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //
            if (ckbCustomerID.Checked == true)
            {
                VerifyCIDWhetherTrueAndBindData();
            }
            else if (CheckBoxWhetherCheckedExceptCkID() > 0)
            {
                CheckedWhetherTransmissionParam();
            }
            else
            {
                //VerifyCNameWhetherTrue();
                GetCustomerInformation();//可以考虑放到load里面                
            }

            //gvCustomerInfroList.RowDataBound += new GridViewRowEventHandler(gvCustomerInfroList_RowDataBound);
        }
        #endregion
        #region 获取客户基本信息无参 protected void GetCustomerInformation()
        /// <summary>
        /// 获取客户基本信息无参
        /// </summary>
        /// <param name="CustomerID">客户ID int类型</param>
        /// <returns>返回dst Dataset类型</returns>
        protected void GetCustomerInformation()
        {
            
            DataSet ds = CSS.GetCustomerInformation();
            DataView myView = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                myView.Sort = sort;
                TB = ds.Tables[0];
                this.gvCustomerInfroList.DataSource = myView;
                this.gvCustomerInfroList.DataBind();
            }
            else
            {
                this.gvCustomerInfroList.DataSource = myView;
                this.gvCustomerInfroList.DataBind();
            }
        }
        #endregion
        #region 获取客户基本信息有参 protected void GetCustomerInformation(int CustomerID, string CityInitial)
        /// <summary>
        /// 获取客户基本信息有参
        /// </summary>
        /// <param name="CustomerID">客户ID int类型</param>
        /// <param name="CityInitial">城市首字母简写</param>    
        protected void GetCustomerInformation(int CustomerID, string CityInitial)
        {
            CustomerService CSS = new CustomerService();
            DataSet ds = CSS.GetCustomerInfobyIDCityService(CustomerID, CityInitial);
            TB = ds.Tables[0];
            this.gvCustomerInfroList.DataSource = ds;
            this.gvCustomerInfroList.DataBind();
        }
        #endregion
        #region 客户编号组合处理
        ///// <summary>
        ///// 客户编号组合处理
        ///// </summary>
        //private int FormatCustomerID()
        //{
        //    //int rowsCount = 0;
        //    CustomerService CSS = new CustomerService();
        //    DataSet dst = CSS.GetCustomerInformation();
        //    if (dst.Tables[0].Rows.Count > 0)
        //    {
        //        rowsCount = dst.Tables[0].Rows.Count;
        //        for (int row = 0; row < rowsCount; row++)
        //        {

        //        }
        //    }
        //    customerID = dst.Tables[0].Rows[1]["CustomerID"].ToString();
        //    return 1;
        //}
        #endregion
        #region 客户信息动态绑定 private void SearchSelectedFuntion()
        /// <summary>
        /// 客户信息动态绑定 grid view RowDataBound 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCustomerInfroList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //string cityLetter = string.Empty;
            string resultID = string.Empty;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    customerID = Convert.ToInt32(e.Row.Cells[0].Text.Trim());
                    //e.Row.Attributes.Add("onclick", "return openLink('1')");//双击后传给前台js的参数
                    //e.Row.Attributes.Add("ondblclick", this.Page.GetPostBackClientEvent(this, "CustomerInfoDetails.aspx" + e.Row.Cells[1].Text + ";双"));
                    //string url = "CustomerInfoDetails.aspx?url=" + e.Row.Cells[0].Text;
                    //e.Row.Attributes["onclick"] = "javascript:ClickMouse('" + url + "')";
                    //cityLetter = e.Row.Cells[32].Text.Trim();
                    if (TB.Rows.Count > 0)
                    {
                        //rowsCount = 0;
                        if (rowsCount < TB.Rows.Count)
                        {
                            resultID = TB.Rows[rowsCount]["CityInitial"].ToString().ToUpper();
                            resultID += customerID.ToString().PadLeft(8, '0');
                            e.Row.Cells[0].Text = resultID;
                            rowsCount++;
                        }
                    }
                }
                catch
                {
                    Response.Write("<script>alert('用户编号初始化失败!')</script>");
                }
                //客户分类
                switch (e.Row.Cells[5].Text.Trim())
                {
                    case "0":
                        e.Row.Cells[5].Text = "客户未分类";
                        break;
                    case "1":
                        e.Row.Cells[5].Text = "短期潜在";
                        break;
                    case "2":
                        e.Row.Cells[5].Text = "长期潜在";
                        break;
                    case "3":
                        e.Row.Cells[5].Text = "意向不明";
                        break;
                    case "4":
                        e.Row.Cells[5].Text = "已经签约";
                        break;
                    case "5":
                        e.Row.Cells[5].Text = "已经流失";
                        break;
                }
                //客户重要性
                switch (e.Row.Cells[6].Text.Trim())
                {
                    case "0":
                        e.Row.Cells[6].Text = "不重要";
                        break;
                    case "1":
                        e.Row.Cells[6].Text = "一般";
                        break;
                    case "2":
                        e.Row.Cells[6].Text = "重要";
                        break;
                    case "3":
                        e.Row.Cells[6].Text = "特别重要";
                        break;
                    //case "4":
                    //    e.Row.Cells[8].Text = "未知重要性";
                    //    break;
                }
                //客户数据来源
                #region 暂时注销          
                //switch (e.Row.Cells[11].Text.Trim())
                //{
                //    case "0":
                //        e.Row.Cells[11].Text = "客户来源不明";
                //        break;
                //    case "1":
                //        e.Row.Cells[11].Text = "名单预约";
                //        break;
                //    case "2":
                //        e.Row.Cells[11].Text = "客户推荐";
                //        break;
                //    case "3":
                //        e.Row.Cells[11].Text = "移民推荐";
                //        break;
                //    case "4":
                //        e.Row.Cells[11].Text = "常州推荐";
                //        break;
                //    case "5":
                //        e.Row.Cells[11].Text = "主动上门";
                //        break;
                //    case "6":
                //        e.Row.Cells[11].Text = "网络来源";
                //        break;
                //    case "7":
                //        e.Row.Cells[11].Text = "人渠道";
                //        break;
                //}
                #endregion 暂时注销
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    //e.Row.Attributes.Add("onclick", "return openLink('CustomerID')");//双击后传给前台js的参数
                //}
                //CustomerService CSS = new CustomerService();
                //DataSet ds = CSS.GetCustomerInformation();
                //this.gvCustomerInfroList.Rows[0].Cells[0].Text = ds.Tables[0].Rows[0][0].ToString();
                //this.gvCustomerInfroList.Rows[0].Cells[1].Text = ds.Tables[0].Rows[0][1].ToString();
                //this.gvCustomerInfroList.Rows[0].Cells[2].Text = ds.Tables[0].Rows[0][2].ToString();
                //this.gvCustomerInfroList.Rows[0].Cells[3].Text = ds.Tables[0].Rows[0][3].ToString();
                //this.gvCustomerInfroList.Rows[0].Cells[4].Text = ds.Tables[0].Rows[0][4].ToString();
                //this.gvCustomerInfroList.Rows[0].Cells[5].Text = ds.Tables[0].Rows[0][5].ToString();
                //this.gvCustomerInfroList.Rows[0].Cells[6].Text = ds.Tables[0].Rows[0][6].ToString();
                //this.gvCustomerInfroList.Rows[0].Cells[7].Text = ds.Tables[0].Rows[0][7].ToString();
            }

        }
        #endregion
        #region gridview 分页导航 DataBound 绑定控制控件
        /// <summary>
        /// 分页导航 DataBound 绑定控制控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCustomerInfroList_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvCustomerInfroList.BottomPagerRow;
            Label lblCurrent = (Label)pagerRow.Cells[0].FindControl("lblPageCurrent");
            Label lblCount = (Label)pagerRow.Cells[0].FindControl("lblPageCount");
            Label lblRow = (Label)pagerRow.Cells[0].FindControl("lblPageRow");
            LinkButton btnFirstTem = (LinkButton)pagerRow.Cells[0].FindControl("btnFirst");
            LinkButton btnPrevTem = (LinkButton)pagerRow.Cells[0].FindControl("btnPrev");
            LinkButton btnNextTem = (LinkButton)pagerRow.Cells[0].FindControl("btnNext");
            LinkButton btnLastTem = (LinkButton)pagerRow.Cells[0].FindControl("btnLast");

            if (lblCurrent != null)
                lblCurrent.Text = (this.gvCustomerInfroList.PageIndex + 1).ToString();
            if (lblCount != null)
                lblCount.Text = this.gvCustomerInfroList.PageCount.ToString();
            if (lblRow != null)
                lblRow.Text = rowsCount.ToString();
            if (this.gvCustomerInfroList.PageIndex == 0)
            {
                btnFirstTem.Enabled = false;
                btnPrevTem.Enabled = false;

                if (this.gvCustomerInfroList.PageCount == 1)
                {
                    btnNextTem.Enabled = false;
                    btnLastTem.Enabled = false;
                }
            }
            else if (this.gvCustomerInfroList.PageIndex == (this.gvCustomerInfroList.PageCount - 1))
            {
                btnNextTem.Enabled = false;
                btnLastTem.Enabled = false;
            }
        }
        #endregion
        #region GridView 分页导航
        /// <summary>
        /// GridView 分页导航
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NavigateToPage(object sender, CommandEventArgs e)
        {

            switch (e.CommandArgument.ToString())
            {
                case "First":
                    this.gvCustomerInfroList.PageIndex = 0;
                    break;
                case "Prev":
                    if (this.gvCustomerInfroList.PageIndex > 0)
                        this.gvCustomerInfroList.PageIndex -= 1;
                    break;
                case "Next":
                    if (this.gvCustomerInfroList.PageIndex < (this.gvCustomerInfroList.PageCount - 1))
                        this.gvCustomerInfroList.PageIndex += 1;
                    break;
                case "Last":
                    this.gvCustomerInfroList.PageIndex = this.gvCustomerInfroList.PageCount - 1;
                    break;
            }
           //Bind(GVExpression, GVDirection);
            if (ckbCustomerID.Checked == true)
            {
                VerifyCIDWhetherTrueAndBindData();
            }
            else if (CheckBoxWhetherCheckedExceptCkID() > 0)
            {
                CheckedWhetherTransmissionParam();
            }
            else
            {                             
                GetCustomerInformation();             
            }
        }
        #endregion

        #region 搜索选项
        /// <summary>
        /// 搜索选择方法
        /// </summary>
        private void SearchSelectedFuntion()
        {
            if (this.ckbCustomerID.Checked == true)
            {
                //CSIF.CustomerID = Convert.ToInt32(this.txtCustomerID.Text);
            }
        }
        #endregion
        #region ckbCustomerIDFun()
        //private int CkbCustomerIDFun()
        //{
        //    string strID = string.Empty;
        //    //char[] strCustromID = new char();
        //    //客户编号还原为int类型
        //    if (this.txtCustomerID.Text.Trim().Length > 0)
        //    {
        //        try
        //        {
        //            strID = this.txtCustomerID.Text.Trim();
        //            CSIF.CustomerID = Convert.ToInt32(strID.Substring(1, strID.Length));
        //        }
        //        catch
        //        {
        //            return 0;
        //        }
        //    }
        //    return 1;
        //}
        #endregion
        #region 验证CustomerID输入的正确性和绑定结果
        /// <summary>
        /// 验证CustomerID输入的正确性和绑定结果
        /// </summary>
        private void VerifyCIDWhetherTrueAndBindData()
        {
            CustomerService CSS = new CustomerService();
            string strtxt = txtCustomerID.Text.Trim();
            if (txtCustomerID.Text.Length == 0)
            {
                CVCustomerID.IsValid = false;
                CVCustomerID.ErrorMessage = "编号不能为空";
                return;
            }
            if (txtCustomerID.Text.Trim().Length < 10)// || txtCustomerID.Text.Trim().Length > 11
            {
                CVCustomerID.IsValid = false;
                CVCustomerID.ErrorMessage = "编号输入错误";
                return;
            }
            if (txtCustomerID.Text.Trim().Contains(' '))
            {
                CVCustomerID.IsValid = false;
                CVCustomerID.ErrorMessage = "编号输入错误";
                return;
            }
            string CustomerID = strtxt.Substring(strtxt.Length - 8, 8);
            int CSID = 0;
            try
            {
                CSID = int.Parse(CustomerID);
            }
            catch
            {
                CVCustomerID.IsValid = false;
                CVCustomerID.ErrorMessage = "编号输入错误";
                return;
            }
            string City = strtxt.Substring(0, strtxt.Length - 8).ToUpper();
            DataSet ds = CSS.GetCustomerInfobyIDCityService(CSID, City);//(CSID, City);
            //DataSet ds = CSS.GetCustomerInfobyIDCityService(CSID, City);//(CSID, City);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                CVCustomerID.IsValid = false;
                CVCustomerID.ErrorMessage = "不存在此人";
                return;
            }
            DataView myView = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            myView.Sort = sort;
            TB = ds.Tables[0];
            this.gvCustomerInfroList.DataSource = myView;
            this.gvCustomerInfroList.DataBind();
        }
        #endregion


        #region 验证姓名输入是否合法 VerifyCNameWhetherTrue()
        /// <summary>
        /// 验证姓名输入是否合法
        /// </summary>
        private int VerifyCNameWhetherTrue()
        {
            if (ckbCustomerName.Checked == true && this.txtCustomerName.Text.Trim().Length > 0)
            {
                CSIF.CustomerName = this.txtCustomerName.Text.Trim();
                return 1;
            }
            else
                //REVCustomerName.ErrorMessage = "不存在此人";
                return 0;

        }
        #endregion
        #region 验证英文名字输入是否合法 VerifyCEnuNameWhetherTrue()
        /// <summary>
        /// 验证英文名字输入是否合法
        /// </summary>
        private int VerifyCEnuNameWhetherTrue()
        {
            if (ckbCustomerEnglishName.Checked == true && this.txtCustomerEnglishName.Text.Trim().Length > 0)
            {
                CSIF.EnglishName = this.txtCustomerEnglishName.Text.Trim();
                return 1;
            }
            else
                return 0;
        }
        #endregion
        #region 验证客户重要性的选择 VerifyCImportantSelected()
        /// <summary>
        /// 验证客户重要性的选择
        /// </summary>
        private int VerifyCImportantSelected()
        {
            if (ckbCustomerImportant.Checked == true && ddlCustomerImportant.SelectedIndex >= 0)
            {
                CSIF.CustomerImportance = ddlCustomerImportant.SelectedIndex;
                return 1; 
            }
            else
            {
                return 0;
            }
        }
        #endregion
        #region 验证客户分类的选择 VerifyCClassSelected()
        /// <summary>
        /// 验证客户分类的选择
        /// </summary>
        private int VerifyCClassSelected()
        {
            if (ckbCustomerClass.Checked == true && ddlCustomerClass.SelectedIndex >= 0)
            {                
                CSIF.CustomerClass = ddlCustomerClass.SelectedIndex;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
        #region 验证数据来源的选择 VerifyCDataFromSelected()
        /// <summary>
        /// 验证客户来源的选择
        /// </summary>s  
        private int VerifyCDataFromSelected()
        {
            if (ckbDataResource.Checked == true && this.txtDataResource.Text.Trim().Length > 0)
            {
                if ((this.txtDataResource.Text.Trim()) == "null" || (this.txtDataResource.Text.Trim()) == "Null")
                {
                    CSIF.FromData = "2";
                    return 2;
                }
                else
                {
                    CSIF.FromData = this.txtDataResource.Text.Trim();
                    return 1;
                }                
            }
            else
                //REVCustomerName.ErrorMessage = "不存在此人";
                return 0;

        }
        #endregion
        #region 验证客户所在省份的选择 VerifyCProvinceSelected()
        /// <summary>
        /// 验证客户所在省份的选择
        /// </summary>
        private int VerifyCProvinceSelected()
        {
            if (ckbCustomerProvince.Checked == true && ddlProvince.SelectedValue != "省份")
            {
                CSIF.CProvince = ddlProvince.SelectedValue;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
        #region 验证客户所在城市的选择 VerifyCCitySelected()
        /// <summary>
        /// 验证客户所在城市的选择
        /// </summary>
        private int VerifyCCitySelected()
        {
            if (ckbCustomerCity.Checked == true && ddlCity.SelectedValue != "城市")
            {
                CSIF.CCity = ddlCity.SelectedValue;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
        #region 验证国家意向是否合法 VerifyIntentionCountryWhetherTrue()
        /// <summary>
        /// 验证国家意向是否合法
        /// </summary>
        private int VerifyIntentionCountryWhetherTrue()
        {
            if (ckbIntentionCountry.Checked == true && this.txtIntentionCountry.Text.Trim().Length > 0)
            {
                CIntention.IntentionCountry = this.txtIntentionCountry.Text.Trim();//
                return 1;
            }
            else
                return 0;
        }
        #endregion
        #region 验证导入人输入是否合法 VerifyImportingPeopleWhetherTrue()
        /// <summary>
        /// 验证导入人输入是否合法
        /// </summary>
        private int VerifyImportingPeopleWhetherTrue()
        {
            if (ckbImportingPeople.Checked == true && this.txtImportingPeople.Text.Trim().Length > 0)
            {
                CSIF.ImportingPeople = this.txtImportingPeople.Text.Trim();
                return 1;
            }
            else
                return 0;
        }
        #endregion
        #region 验证顾问输入是否合法 VerifyFollowUpConsultantWhetherTrue()
        /// <summary>
        /// 验证顾问输入是否合法
        /// </summary>
        private int VerifyFollowUpConsultantWhetherTrue()
        {
            if (ckbFollowUpConsultant.Checked == true && this.txtFollowUpConsultant.Text.Trim().Length > 0)
            {
                GStaffName = this.txtFollowUpConsultant.Text.Trim();//
                return 1;
            }
            else
                return 0;
        }
        #endregion
        #region 验证文案输入是否合法 VerifyFollowUpCopyWhetherTrue()
        /// <summary>
        /// 验证文案输入是否合法
        /// </summary>
        private int VerifyFollowUpCopyWhetherTrue()
        {
            if (ckbFollowUpCopy.Checked == true && this.txtFollowUpCopy.Text.Trim().Length > 0)
            {
                WStaffName = this.txtFollowUpCopy.Text.Trim();//
                return 1;
            }
            else
                return 0;
        }
        #endregion
        #region 验证手机号码输入是否合法 VerifyCellPhoneNumberWhetherTrue()
        /// <summary>
        /// 验证手机号码输入是否合法
        /// </summary>
        private int VerifyCellPhoneNumberWhetherTrue()
        {
            if (ckbCellPhoneNumber.Checked == true && this.txtCellPhoneNumber.Text.Trim().Length > 0)
            {
                CSIF.Telphone = this.txtCellPhoneNumber.Text.Trim();//
                return 1;
            }
            else
                return 0;
        }
        #endregion

        /// <summary>
        /// 验证备用手机号码输入是否合法
        /// </summary>
        /// <returns></returns>
        private int VerifyBackUpTelWhetherTrue()
        {
            if (ckbBackupTel.Checked == true && this.txtBackupTel.Text.Trim().Length > 0)
            {
                CSIF.BackUpTel = this.txtBackupTel.Text.Trim();
                return 1;
            }
            else
                return 0;
        }
        #region 验证是否把该值传到后台
        /// <summary>
        /// 验证是否把该值传到后台
        /// </summary>
        private void CheckedWhetherTransmissionParam()
        {
            CustomerService CSS = new CustomerService();
            //判断中文名字是否被传送
            if (VerifyCNameWhetherTrue() < 1)
            {
                CSIF.CustomerName = "0";
            }
            //判断英文名字是否被传送
            if (VerifyCEnuNameWhetherTrue() < 1)
            {
                CSIF.EnglishName = "0";
            }
            //判断客户重要性是否被传送
            if (VerifyCImportantSelected() < 1)
            {
                CSIF.CustomerImportance = -1;
            }
            //判断客户分类是否被传送
            if (VerifyCClassSelected() < 1)
            {
                CSIF.CustomerClass = -1;
            }
            //判断数据来源是否被传送
            if (VerifyCDataFromSelected() < 1)
            {
                CSIF.FromData = "0";
            }
            //判断客户所在省份是否被传送
            if (VerifyCProvinceSelected() < 1)
            {
                CSIF.CProvince = "0";
            }
            //判断客户所在城市是否被传送
            if (VerifyCCitySelected() < 1)
            {
                CSIF.CCity = "0";
            }
            //判断客户意向国家是否被传送
            if (VerifyIntentionCountryWhetherTrue() < 1)
            {
                CIntention.IntentionCountry = "0";
            }
            //判断导入人是否被传送
            if (VerifyImportingPeopleWhetherTrue() < 1)// New Add
            {
                CSIF.ImportingPeople = "0";
            }
            //判断顾问是否被传送
            if (VerifyFollowUpConsultantWhetherTrue() < 1)// New Add
            {

                GStaffName = "0";
            }
            //判断文案是否被传送
            if (VerifyFollowUpCopyWhetherTrue() < 1)// New Add
            {
                WStaffName = "0";
            }
            //判断手机号码是否被传送
            if (VerifyCellPhoneNumberWhetherTrue() < 1)// New Add
            {
                CSIF.Telphone = "0";
            }
            if (VerifyBackUpTelWhetherTrue() < 1)
            {
                CSIF.BackUpTel = "0";
            }
            DataSet ds = CSS.GetCustomerInfoBySearchCondition(CSIF.CustomerName, CSIF.EnglishName, CSIF.CustomerImportance, CSIF.CustomerClass, CSIF.FromData, CSIF.CProvince, CSIF.CCity, CIntention.IntentionCountry, CSIF.ImportingPeople, GStaffName, WStaffName, CSIF.Telphone,CSIF.BackUpTel,CB_NoneFollow.Checked,txtStartIntentionTime.Text.Trim(),txtEndIntentionTime.Text.Trim());
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                CVNoticeCustomError.IsValid = false;
                //this.lblErrorMessageForCustomer.Visible = true;
                //this.lblErrorMessageForCustomer.Text = "不存在此人";
                CVNoticeCustomError.ErrorMessage = "不存在此人";
                return;
            }
            DataView myView = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            myView.Sort = sort;
            TB = ds.Tables[0];
            this.gvCustomerInfroList.DataSource = myView;
            this.gvCustomerInfroList.DataBind();
        }
        #endregion
        #region 判断CheckBox是否被选中
        /// <summary>
        /// 判断CheckBox是否被选中
        /// </summary>
        /// <returns>value</returns>
        private int CheckBoxWhetherCheckedExceptCkID()
        {
            if (ckbCustomerName.Enabled == true || ckbCustomerEnglishName.Enabled == true || ckbCustomerImportant.Enabled == true || ckbCustomerClass.Enabled == true || ckbDataResource.Enabled == true || ckbCustomerProvince.Enabled == true || ckbCustomerCity.Enabled == true || ckbIntentionCountry.Enabled == true || ckbImportingPeople.Enabled == true || ckbFollowUpConsultant.Enabled == true || ckbFollowUpCopy.Enabled == true || CB_NoneFollow.Enabled==true)//1
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
        #region 客户编号搜索checked change事件
        /// <summary>
        /// 客户编号搜索checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCustomerID_CheckedChanged(object sender, EventArgs e)//1客户编号
        {
            if (ckbCustomerID.Checked == true)//客户编号
            {
                this.txtCustomerID.Enabled = true;
                DisableCheckedBoxExceptID();
            }
            else
            {
                this.txtCustomerID.Text = "";
                this.txtCustomerID.Enabled = false;
                EnableCheckedBoxExceptID();
            }
        }
        #endregion
        #region 客户名字搜索checked change事件 1
        /// <summary>
        /// 客户名字搜索checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCustomerName_CheckedChanged(object sender, EventArgs e)//2客户姓名
        {
            if (ckbCustomerName.Checked == true)
            {
                this.txtCustomerName.Enabled = true;
                //DisableCheckedBoxID();
            }
            else
            {
                this.txtCustomerName.Text = "";
                this.txtCustomerName.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 客户英文名字搜索checked change事件 2
        /// <summary>
        /// 客户英文名字搜索checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCustomerEnglishName_CheckedChanged(object sender, EventArgs e)//3
        {
            if (ckbCustomerEnglishName.Checked == true)
            {
                this.txtCustomerEnglishName.Enabled = true;
                //DisableCheckedBoxID();
            }
            else
            {
                this.txtCustomerEnglishName.Text = "";
                this.txtCustomerEnglishName.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 客户重要性选择checked change事件 3
        /// <summary>
        /// 客户重要性选择checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCustomerImportant_CheckedChanged(object sender, EventArgs e)//4
        {
            if (ckbCustomerImportant.Checked == true)//客户重要性
            {
                this.ddlCustomerImportant.Enabled = true;
                //DisableCheckedBoxID();
            }
            else
            {
                this.ddlCustomerImportant.SelectedIndex = 0;
                this.ddlCustomerImportant.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 客户分类选择checked change事件 4
        /// <summary>
        /// 客户分类选择checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCustomerClass_CheckedChanged(object sender, EventArgs e)//5
        {
            if (ckbCustomerClass.Checked == true)
            {
                this.ddlCustomerClass.Enabled = true;
                //DisableCheckedBoxID();
            }
            else
            {
                this.ddlCustomerClass.SelectedIndex = 0;
                this.ddlCustomerClass.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 客户来源选择checked change事件 5
        /// <summary>
        /// 客户来源选择checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbDataResource_CheckedChanged(object sender, EventArgs e)//6
        {
            if (ckbDataResource.Checked == true)//数据来源
            {
                this.txtDataResource.Enabled = true;
                //DisableCheckedBoxID();
            }
            else
            {
                this.txtDataResource.Text = "";
                this.txtDataResource.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 省份选择checked change事件 6
        /// <summary>
        /// 省份选择checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCustomerProvince_CheckedChanged(object sender, EventArgs e)//7
        {
            if (ckbCustomerProvince.Checked == true)//客户来自于省份
            {
                //DisableCheckedBoxID();
                this.ddlProvince.Enabled = true;
                BindProvince();
                ddlProvince.SelectedIndex = 11;
                BindCity();
                ddlCity.SelectedIndex = 1;
            }
            else
            {
                this.ddlProvince.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 城市选择checked change事件 7
        /// <summary>
        /// 城市选择checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCustomerCity_CheckedChanged(object sender, EventArgs e)//8
        {
            if (ckbCustomerCity.Checked == true)//所在城市
            {
                //DisableCheckedBoxID();
                this.ddlCity.Enabled = true;
                //BindProvince();
                //ddlProvince.SelectedIndex = 11;
                //BindCity();
                //ddlCity.SelectedIndex = 1;
            }
            else
            {
                this.ddlCity.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 城市首字搜索checked change事件 8
        /// <summary>
        /// 城市首字搜索checked change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCustomerCityLetter_CheckedChanged(object sender, EventArgs e)//9
        {
            //if (ckbIntentionCountry.Checked == true)//城市首字母
            //{
            //    this.txtIntentionCountry.Enabled = true;
            //    //DisableCheckedBoxID();
            //}
            //else
            //{
            //    this.txtIntentionCountry.Text = "";
            //    this.txtIntentionCountry.Enabled = false;
            //    //EnableCheckedBoxID();
            //}
        }
        #endregion
        #region 客户意向国家搜索checked change事件 9
        /// <summary>
        /// 客户意向国家checked change事件9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbIntentionCountry_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIntentionCountry.Checked == true)//意向国家
            {
                this.txtIntentionCountry.Enabled = true;
                //DisableCheckedBoxID();
            }
            else
            {
                this.txtIntentionCountry.Text = "";
                this.txtIntentionCountry.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 导入人checked change事件10
        /// <summary>
        /// 导入人checked change事件10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbImportingPeople_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbImportingPeople.Checked == true)//导入人
            {
                this.txtImportingPeople.Enabled = true;
                //DisableCheckedBoxID();
            }
            else
            {
                this.txtImportingPeople.Text = "";
                this.txtImportingPeople.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 跟进顾问checked change事件11
        /// <summary>
        /// 跟进顾问checked change事件11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbFollowUpConsultant_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFollowUpConsultant.Checked == true)//跟进顾问
            {
                this.txtFollowUpConsultant.Enabled = true;
                this.ckbFollowUpCopy.Checked = false;
                this.txtFollowUpCopy.Enabled = false;
                this.txtFollowUpCopy.Text = "";
                //DisableCheckedBoxID();
            }
            else
            {
                this.txtFollowUpConsultant.Text = "";
                this.txtFollowUpConsultant.Enabled = false;
                //this.ckbFollowUpCopy.Checked = true;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 跟进文案checked change事件12
        /// <summary>
        /// 跟进文案checked change事件12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbFollowUpCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFollowUpCopy.Checked == true)//跟进文案
            {
                this.txtFollowUpCopy.Enabled = true;
                this.ckbFollowUpConsultant.Checked = false;
                this.txtFollowUpConsultant.Enabled = false;
                this.txtFollowUpConsultant.Text = "";                
                //DisableCheckedBoxID();
            }
            else
            {
                this.txtFollowUpCopy.Text = "";
                this.txtFollowUpCopy.Enabled = false;
                //this.ckbFollowUpConsultant.Checked = true;
                //EnableCheckedBoxID();
            }
        }
        #endregion
        #region 客户手机号码checked change事件13
        /// <summary>
        /// 客户手机号码checked change事件13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckbCellPhoneNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCellPhoneNumber.Checked == true)//导入人
            {
                this.txtCellPhoneNumber.Enabled = true;
                //DisableCheckedBoxID();
            }
            else
            {
                this.txtCellPhoneNumber.Text = "";
                this.txtCellPhoneNumber.Enabled = false;
                //EnableCheckedBoxID();
            }
        }
        #endregion

        #region Common Double Pramer 传两个参数

        #endregion
        #region 如果根据客户ID搜索其它搜索条件禁用
        /// <summary>
        /// 禁用其它Checked box 除ID
        /// </summary>
        private void DisableCheckedBoxExceptID()
        {
            if (ckbCustomerCity.Checked == true)
            {
                this.ckbCustomerCity.Checked = false;
                this.ddlCity.Enabled = false;
            }
            ckbCustomerCity.Enabled = false; //1
            //this.ddlCity.SelectedValue = "无锡";
            if (ckbIntentionCountry.Checked == true)
            {
                ckbIntentionCountry.Checked = false;
            }
            ckbIntentionCountry.Enabled = false;//2
            this.txtIntentionCountry.Text = "";
            if (ckbCustomerClass.Checked == true)
            {
                this.ckbCustomerClass.Checked = false;
                this.ddlCustomerClass.Enabled = false;
            }
            ckbCustomerClass.Enabled = false;//3
            this.ddlCustomerClass.SelectedIndex = 0;
            if (ckbCustomerEnglishName.Checked == true)
            {
                this.ckbCustomerEnglishName.Checked = false;
                //this.txtCustomerEnglishName.Text = "";
            }
            ckbCustomerEnglishName.Enabled = false;//4
            this.txtCustomerEnglishName.Text = "";
            //ckbCustomerID.Enabled = false;
            if (ckbCustomerImportant.Checked == true)
            {
                this.ckbCustomerImportant.Checked = false;
                this.ddlCustomerImportant.Enabled = false;
            }
            ckbCustomerImportant.Enabled = false;//5
            this.ddlCustomerImportant.SelectedIndex = 0;
            if (ckbCustomerName.Checked == true)
            {
                ckbCustomerName.Checked = false;
                //this.txtCustomerName.Text = "";
            }
            ckbCustomerName.Enabled = false;//6
            this.txtCustomerName.Text = "";
            if (ckbCustomerProvince.Checked == true)
            {
                ckbCustomerProvince.Checked = false;
                this.ddlProvince.Enabled = false;
            }
            ckbCustomerProvince.Enabled = false;//7
            //this.ddlProvince.SelectedValue = "江苏";
            if (ckbDataResource.Checked == true)
            {
                ckbDataResource.Checked = false;
                this.txtDataResource.Enabled = false;
            }
            ckbDataResource.Enabled = false;//8
            this.txtDataResource.Text = "";
            //New Add
            if (ckbImportingPeople.Checked == true)
            {
                ckbImportingPeople.Checked = false;
            }
            ckbImportingPeople.Enabled = false;//9
            this.txtImportingPeople.Text = "";
            //New Add
            if (ckbFollowUpConsultant.Checked == true)
            {
                ckbFollowUpConsultant.Checked = false;
            }
            ckbFollowUpConsultant.Enabled = false;//10
            this.txtFollowUpConsultant.Text = "";
            //New Add
            if (ckbFollowUpCopy.Checked == true)
            {
                ckbFollowUpCopy.Checked = false;
            }
            ckbFollowUpCopy.Enabled = false;//11
            this.txtFollowUpCopy.Text = "";
            //New Add
            if (ckbCellPhoneNumber.Checked == true)
            {
                ckbCellPhoneNumber.Checked = false;
            }
            ckbCellPhoneNumber.Enabled = false;//11
            this.txtCellPhoneNumber.Text = "";
        }
        #endregion
        #region 如果客户ID搜索条件取消其它搜索条件启用
        /// <summary>
        /// 启用其它Checked box 除ID
        /// </summary>
        private void EnableCheckedBoxExceptID()
        {
            ckbCustomerCity.Enabled = true;
            ckbIntentionCountry.Enabled = true;
            ckbCustomerClass.Enabled = true;
            ckbImportingPeople.Enabled = true;//
            ckbFollowUpConsultant.Enabled = true;//
            ckbFollowUpCopy.Enabled = true;//
            ckbCustomerEnglishName.Enabled = true;
            //ckbCustomerID.Enabled = true;
            ckbCustomerImportant.Enabled = true;
            ckbCustomerName.Enabled = true;
            ckbCustomerProvince.Enabled = true;
            ckbDataResource.Enabled = true;
            //New add
            ckbCellPhoneNumber.Enabled = true;
        }
        #endregion
        #region 禁用客户编号搜索
        /// <summary>
        /// 禁用客户编号搜索
        /// </summary>
        private void DisableCheckedBoxID()
        {
            this.ckbCustomerID.Enabled = false;
        }
        #endregion
        #region 启用客户编号搜索
        /// <summary>
        /// 启用客户编号搜索
        /// </summary>
        private void EnableCheckedBoxID()
        {
            if (ckbCustomerName.Enabled == true || ckbCustomerEnglishName.Enabled == true || ckbCustomerImportant.Enabled == true || ckbCustomerClass.Enabled == true || ckbDataResource.Enabled == true || ckbCustomerProvince.Enabled == true || ckbCustomerCity.Enabled == true || ckbIntentionCountry.Enabled == true || ckbCellPhoneNumber.Enabled == true)//1 ckbCellPhoneNumber
            {
                DisableCheckedBoxID();
            }
            else
                this.ckbCustomerID.Enabled = true;
        }
        #endregion

        protected void gvCustomerInfroList_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sPage = e.SortExpression;
            if (ViewState["SortOrder"].ToString() == sPage)
            {
                if (ViewState["OrderDire"].ToString() == "Desc")
                {
                    ViewState["OrderDire"] = "ASC";
                }
                else
                {
                    ViewState["OrderDire"] = "Desc";
                }
            }
            else
            {
                ViewState["SortOrder"] = e.SortExpression;
            }
            if (ckbCustomerID.Checked == true)
            {
                VerifyCIDWhetherTrueAndBindData();
            }
            else if (CheckBoxWhetherCheckedExceptCkID() > 0)
            {
                CheckedWhetherTransmissionParam();
            }
            else
            {
                //VerifyCNameWhetherTrue();
                GetCustomerInformation();//可以考虑放到load里面                
            }
        }

        protected void ckbBackupTel_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbBackupTel.Checked)
            {
                this.txtBackupTel.Enabled = true;
            }
            else
            {
                this.txtBackupTel.Text = "";
                this.txtBackupTel.Enabled = false;
            }
        }

        protected void ckbStartIntentionTime_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbStartIntentionTime.Checked == true)
            {
                txtStartIntentionTime.Enabled = true;
            }
            else
            {
                txtStartIntentionTime.Enabled = false;
                txtStartIntentionTime.Text = "";
            }
            
        }

        protected void ckbEndIntentionTime_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEndIntentionTime.Checked == true)
            {
                txtEndIntentionTime.Enabled = true;
            }
            else
            {
                txtEndIntentionTime.Enabled = false;
                txtEndIntentionTime.Text = "";
            }
        }




        #region 测试GridView双击事件

        #endregion
        #region 测试GridView双击事件

        #endregion
    }
}
