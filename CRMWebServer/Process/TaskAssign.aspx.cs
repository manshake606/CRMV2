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

namespace CRMWebServer.Process
{
    public partial class TaskAssign : System.Web.UI.Page
    {
        public string City = "城市";
        StaffInfo staffInfo = new StaffInfo();
        CustomerInfo custInfo = new CustomerInfo();
        AssignState assignState = new AssignState();
        CRMControlService.AssignStateService ASS = new AssignStateService();
        ModelService.BindState BS = new BindState();
        CRMControlService.AuthorityService AS = new AuthorityService();
        CRMControlService.StaffInfoService stafs = new StaffInfoService();
        CRMControlService.LogInfoService LIS = new LogInfoService();
        CRMControlService.CustomerService CS = new CustomerService();

        string moduleID = ConfigurationManager.AppSettings["Assign"];
        int authority = 0;
        DataSet ds = new DataSet();
        static int Flag = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

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

            BtnConfirm.Attributes.Add("onclick", "ConfirmAdd()");



            if (!IsPostBack)
            {
                Flag = 0;
                BindProvince();
                ddlUProvince.SelectedIndex = 11;
                BindCity();
                ddlUCity.SelectedIndex = 1;


                //加载意向下拉框
                DataSet dscountry = new DataSet();
                dscountry = ASS.GetIntentionCountry_Service();


                DataRow drc = dscountry.Tables[0].NewRow();
                drc["IntentionCountry"] = "请选择";

                dscountry.Tables[0].Rows.InsertAt(drc, 0);
                DDCountry.DataSource = dscountry;
                DDCountry.DataTextField = "IntentionCountry";

                DDCountry.DataBind();


                //加载数据来源
                DataSet dsFrom = new DataSet();
                dsFrom = ASS.GetFromData_Server();
                if (dsFrom.Tables[0].Rows.Count == 0)
                {
                    DDFromData.Items.Add(new ListItem("来源为空"));
                }
                else
                {

                    DataRow drF = dsFrom.Tables[0].NewRow();

                    drF["FromData"] = "请选择";
                    dsFrom.Tables[0].Rows.InsertAt(drF, 0);

                    DDFromData.DataSource = dsFrom;
                    DDFromData.DataTextField = "FromData";
                    DDFromData.DataBind();
                }

                //加载导入人
                DataSet dspeople = new DataSet();
                dspeople = ASS.GetImportingPeople();
                DataRow dr = dspeople.Tables[0].NewRow();
                dr["StaffName"] = "请选择";
                dr["StaffID"] = "0";
                dspeople.Tables[0].Rows.InsertAt(dr, 0);
                DDImportPeople.DataSource = dspeople;
                DDImportPeople.DataTextField = "StaffName";
                DDImportPeople.DataValueField = "StaffID";
                DDImportPeople.DataBind();

                //加载客户重要性
                DDImportance.Items.Add(new ListItem("请选择", "10"));
                DDImportance.Items.Add(new ListItem("特别重要", "3"));
                DDImportance.Items.Add(new ListItem("重要", "2"));
                DDImportance.Items.Add(new ListItem("一般", "1"));
                DDImportance.Items.Add(new ListItem("不重要", "0"));

                //加载客户分类
                DDCustomerClass.Items.Add(new ListItem("请选择", "10"));
                DDCustomerClass.Items.Add(new ListItem("未分类", "0"));
                DDCustomerClass.Items.Add(new ListItem("短期潜在", "1"));
                DDCustomerClass.Items.Add(new ListItem("长期潜在", "2"));
                DDCustomerClass.Items.Add(new ListItem("意向不明", "3"));
                DDCustomerClass.Items.Add(new ListItem("已经签约", "4"));
                DDCustomerClass.Items.Add(new ListItem("已经流失", "5"));

                DataSet dsConsultant = new DataSet();
                dsConsultant = ASS.GetFollowupConsultant_Service();
                DataRow drs = dsConsultant.Tables[0].NewRow();
                drs["StaffID"] = "0";
                drs["StaffName"] = "请选择";
                dsConsultant.Tables[0].Rows.InsertAt(drs, 0);
                DDFollowConsultant.DataSource = dsConsultant;
                DDFollowConsultant.DataTextField = "StaffName";
                DDFollowConsultant.DataValueField = "StaffID";
                DDFollowConsultant.DataBind();

                DataSet dsCopywriter = new DataSet();
                dsCopywriter = ASS.GetCopywtiter_Service();
                DataRow drw = dsCopywriter.Tables[0].NewRow();
                drw["StaffID"] = "0";
                drw["StaffName"] = "请选择";
                dsCopywriter.Tables[0].Rows.InsertAt(drw, 0);
                DDCopywriter.DataSource = dsCopywriter;
                DDCopywriter.DataTextField = "StaffName";
                DDCopywriter.DataValueField = "StaffID";
                DDCopywriter.DataBind();


                //经理登陆
                if (authority == 9)
                {
                    BindGWProvince();
                    ddlGWProvince.SelectedIndex = 11;
                    BindGWCity();
                    ddlGWCity.SelectedIndex = 1;
                    DataSet ds = stafs.GetGWNamebyAddressDirectlyID_Service(staffInfo.StaffID, ddlGWCity.SelectedItem.Text);
                    DDlistGWName.DataSource = ds;
                    DDlistGWName.DataTextField = "StaffName";
                    DDlistGWName.DataValueField = "StaffID";
                    DDlistGWName.DataBind();

                    DataSet dscopy = stafs.GetCopyWriterNamebyAddessDirectlyID_Service(staffInfo.StaffID, ddlGWCity.SelectedItem.Text);
                    DDlistCopyWriter.DataSource = dscopy;
                    DDlistCopyWriter.DataTextField = "StaffName";
                    DDlistCopyWriter.DataValueField = "StaffID";
                    DDlistCopyWriter.DataBind();


                    DataSet dsm = stafs.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                    DDlistManager.DataSource = dsm;
                    DDlistManager.DataTextField = "StaffName";
                    DDlistManager.DataValueField = "StaffID";
                    DDlistManager.DataBind();


                    DDListAssignStatus.Items.Add(new ListItem("新导入", "0"));
                    DDListAssignStatus.Items.Add(new ListItem("顾问跟进", "1"));
                    DDListAssignStatus.Items.Add(new ListItem("文案跟进", "2"));
                    DDListAssignStatus.Items.Add(new ListItem("文案搁置", "3"));
                    DDListAssignStatus.Items.Add(new ListItem("案件归档", "4"));
                    DDListAssignStatus.Items.Add(new ListItem("案件退案", "5"));


                    DDListAssignStatus.SelectedIndex = 0;



                    DDAssign.Items.Add(new ListItem("请选择", "10"));
                    DDAssign.Items.Add(new ListItem("指派顾问", "1"));
                    DDAssign.Items.Add(new ListItem("解绑顾问", "0"));
                    DDAssign.Items.Add(new ListItem("指派文案", "2"));
                    DDAssign.Items.Add(new ListItem("解绑文案", "3"));



                    //ds = ASS.GetCustomerAssignInfo_Service(int.Parse(DDListAssignStatus.SelectedValue), ddlUCity.SelectedItem.Text, staffInfo.StaffID, authority, DDImportPeople.SelectedItem.Text.Trim(), DDCountry.SelectedItem.Text.Trim(), int.Parse(DDImportance.SelectedValue), int.Parse(DDCustomerClass.SelectedValue), DDFromData.SelectedItem.Text.Trim(), int.Parse(DDFollowConsultant.SelectedItem.Value), int.Parse(DDCopywriter.SelectedValue), Flag);
                    //GVshowCustomerState.DataSource = ds;
                    //GVshowCustomerState.DataBind();
                    ViewState["SortOrder"] = "CustomerID";
                    ViewState["OrderDire"] = "asc";
                    BindGridView();
                    GVshowCustomerState.Columns[15].Visible = false;

                }
                //顾问登陆
                if (authority == 8)
                {
                    btnExport.Visible = false;
                    DDlistManager.Enabled = false;
                    DataSet ds = stafs.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                    DDlistGWName.DataSource = ds;
                    DDlistGWName.DataTextField = "StaffName";
                    DDlistGWName.DataValueField = "StaffID";
                    DDlistGWName.DataBind();
                    DDlistGWName.Enabled = false;
                    ddlGWProvince.Items.Add(ds.Tables[0].Rows[0]["CompanyProvice"].ToString());
                    ddlGWProvince.Enabled = false;
                    ddlGWCity.Items.Add(ds.Tables[0].Rows[0]["CompanyAddress"].ToString());
                    ddlGWCity.Enabled = false;
                    DataSet dscopy = stafs.GetGetCopyWriterNamebyAddessStaffDirect_Service(staffInfo.StaffID, ddlGWCity.SelectedItem.Text);
                    DDlistCopyWriter.DataSource = dscopy;
                    DDlistCopyWriter.DataTextField = "StaffName";
                    DDlistCopyWriter.DataValueField = "StaffID";
                    DDlistCopyWriter.DataBind();


                    DDListAssignStatus.Items.Add(new ListItem("顾问跟进", "1"));
                    DDListAssignStatus.Items.Add(new ListItem("文案跟进", "2"));
                    DDListAssignStatus.Items.Add(new ListItem("新导入", "0"));



                    DDListAssignStatus.SelectedIndex = 0;




                    DDAssign.Items.Add(new ListItem("请选择", "10"));
                    DDAssign.Items.Add(new ListItem("指派顾问", "1"));
                    DDAssign.Items.Add(new ListItem("指派文案", "2"));
                    DDAssign.Items.Add(new ListItem("顾问解绑", "0"));

                    ViewState["SortOrder"] = "CustomerID";
                    ViewState["OrderDire"] = "asc";
                    //ds = ASS.GetCustomerAssignInfo_Service(int.Parse(DDListAssignStatus.SelectedValue), ddlUCity.SelectedItem.Text, staffInfo.StaffID, authority, DDImportPeople.SelectedItem.Text.Trim(), DDCountry.SelectedItem.Text.Trim(), int.Parse(DDImportance.SelectedValue), int.Parse(DDCustomerClass.SelectedValue), DDFromData.SelectedItem.Text.Trim(), int.Parse(DDFollowConsultant.SelectedValue), int.Parse(DDCopywriter.SelectedValue), Flag);
                    //GVshowCustomerState.DataSource = ds;
                    //GVshowCustomerState.DataBind();
                    BindGridView();
                    GVshowCustomerState.Columns[15].Visible = false;

                    Label10.Visible = false;
                    Label11.Visible = false;
                    DDFollowConsultant.Visible = false;
                    DDCopywriter.Visible = false;
                    btnTrans.Visible = false;


                }

                //文案登陆
                if (authority == 7)
                {
                    btnExport.Visible = false;
                    DDlistGWName.Enabled = false;
                    DDlistManager.Enabled = false;
                    DataSet ds = stafs.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                    ddlGWProvince.Items.Add(ds.Tables[0].Rows[0]["CompanyProvice"].ToString());
                    ddlGWProvince.Enabled = false;
                    ddlGWCity.Items.Add(ds.Tables[0].Rows[0]["CompanyAddress"].ToString());
                    ddlGWCity.Enabled = false;
                    DataSet dscopy = stafs.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                    DDlistCopyWriter.DataSource = dscopy;
                    DDlistCopyWriter.DataTextField = "StaffName";
                    DDlistCopyWriter.DataValueField = "StaffID";
                    DDlistCopyWriter.DataBind();
                    DDlistCopyWriter.Enabled = false;
                    DDListAssignStatus.Items.Add(new ListItem("文案跟进", "2"));
                    DDListAssignStatus.Items.Add(new ListItem("文案搁置", "3"));
                    DDListAssignStatus.Items.Add(new ListItem("案件归档", "4"));
                    DDListAssignStatus.Items.Add(new ListItem("案件退案", "5"));

                    DDListAssignStatus.SelectedIndex = 0;



                    DDAssign.Items.Add(new ListItem("请选择", "10"));
                    DDAssign.Items.Add(new ListItem("文案搁置", "3"));
                    DDAssign.Items.Add(new ListItem("案件归档", "4"));
                    DDAssign.Items.Add(new ListItem("案件退案", "5"));


                    //ds = ASS.GetCustomerAssignInfo_Service(int.Parse(DDListAssignStatus.SelectedValue), ddlUCity.SelectedItem.Text, staffInfo.StaffID, authority, DDImportPeople.SelectedItem.Text.Trim(), DDCountry.SelectedItem.Text.Trim(), int.Parse(DDImportance.SelectedValue), int.Parse(DDCustomerClass.SelectedValue), DDFromData.SelectedItem.Text.Trim(), int.Parse(DDFollowConsultant.SelectedValue), int.Parse(DDCopywriter.SelectedValue), Flag);
                    //GVshowCustomerState.DataSource = ds;
                    //GVshowCustomerState.DataBind();
                    ViewState["SortOrder"] = "CustomerID";
                    ViewState["OrderDire"] = "asc";
                    BindGridView();
                    GVshowCustomerState.Columns[15].Visible = true;

                    Label10.Visible = false;
                    Label11.Visible = false;
                    DDFollowConsultant.Visible = false;
                    DDCopywriter.Visible = false;
                    btnTrans.Visible = false;
                }


            }
        }

        protected void BindSearch()
        {
            Flag = 1;
            string kk = DDCountry.SelectedItem.Text;
            //ds = ASS.GetCustomerAssignInfo_Service(int.Parse(DDListAssignStatus.SelectedValue), ddlUCity.SelectedItem.Text, staffInfo.StaffID, authority, DDImportPeople.SelectedItem.Text.Trim(), DDCountry.SelectedItem.Text.Trim(), int.Parse(DDImportance.SelectedValue), int.Parse(DDCustomerClass.SelectedValue), DDFromData.SelectedItem.Text.Trim(), int.Parse(DDFollowConsultant.SelectedValue), int.Parse(DDCopywriter.SelectedValue), Flag);
            //DataView myView = ds.Tables[0].DefaultView;
            //myView.Sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            //GVshowCustomerState.DataSource = myView;
            //GVshowCustomerState.DataBind();
            BindGridView();
            if (authority == 7)
            {
                GVshowCustomerState.Columns[15].Visible = true;
            }
            else
            {
                GVshowCustomerState.Columns[15].Visible = false;
            }
        }


        protected void ButSearch_Click(object sender, EventArgs e)
        {
            BindSearch();

        }

        #region private void BindProvince() 省份名称绑定
        /// <summary>
        /// 省份名称数据绑定
        /// </summary>
        protected void BindProvince()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.ddlUProvince.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes;
                XmlNode nodeCity = doc.DocumentElement.SelectSingleNode(@"Province/City[@Name='" + this.City + "']");
                foreach (XmlNode node in nodes)
                {
                    this.ddlUProvince.Items.Add(node.Attributes["Name"].Value);
                    int n = this.ddlUProvince.Items.Count - 1;
                    if (nodeCity != null && node == nodeCity.ParentNode)
                        this.ddlUProvince.SelectedIndex = n;
                }
                //.SelectedItem.Text;
                //txtCurrentCity.Text = this.ddlCity.SelectedValue;
                BindCity();
            }
        }
        #endregion

        #region private void BindGWProvince() 顾问省份名称绑定
        /// <summary>
        /// 顾问省份名称数据绑定
        /// </summary>
        protected void BindGWProvince()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.ddlGWProvince.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes;
                XmlNode nodeCity = doc.DocumentElement.SelectSingleNode(@"Province/City[@Name='" + this.City + "']");
                foreach (XmlNode node in nodes)
                {
                    this.ddlGWProvince.Items.Add(node.Attributes["Name"].Value);
                    int n = this.ddlGWProvince.Items.Count - 1;
                    if (nodeCity != null && node == nodeCity.ParentNode)
                        this.ddlGWProvince.SelectedIndex = n;
                }
                //.SelectedItem.Text;
                //txtCurrentCity.Text = this.ddlCity.SelectedValue;
                BindGWCity();
            }
        }
        #endregion

        #region private void BindGWCity() 顾问城市名称数据绑定
        /// <summary>
        /// 顾问城市名称数据绑定
        /// </summary>
        protected void BindGWCity()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.ddlGWCity.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes[this.ddlGWProvince.SelectedIndex].ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    this.ddlGWCity.Items.Add(node.Attributes["Name"].Value);
                    int n = this.ddlGWCity.Items.Count - 1;
                    if (node.Attributes["Name"].Value == this.City)
                    {
                        this.ddlGWCity.SelectedIndex = n;
                    }
                }
                if (this.ddlGWCity.SelectedIndex == -1)
                    this.ddlGWCity.SelectedIndex = 0;
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
                this.ddlUCity.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes[this.ddlUProvince.SelectedIndex].ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    this.ddlUCity.Items.Add(node.Attributes["Name"].Value);
                    int n = this.ddlUCity.Items.Count - 1;
                    if (node.Attributes["Name"].Value == this.City)
                    {
                        this.ddlUCity.SelectedIndex = n;
                    }
                }
                if (this.ddlUCity.SelectedIndex == -1)
                    this.ddlUCity.SelectedIndex = 0;
            }
        }
        #endregion

        protected void ddlUProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();//绑定城市数据
        }

        protected void GVshowCustomerState_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                

                if (e.Row.Cells[3].Text == "0")
                {
                    e.Row.Cells[3].Text = "男";
                }
                else
                {
                    e.Row.Cells[3].Text = "女";
                }
                if (e.Row.Cells[8].Text == "0")
                {
                    e.Row.Cells[8].Text = "不重要";
                }
                else if (e.Row.Cells[8].Text == "1")
                {
                    e.Row.Cells[8].Text = "一般";
                }
                else if (e.Row.Cells[8].Text == "2")
                {
                    e.Row.Cells[8].Text = "重要";
                }
                else if (e.Row.Cells[8].Text == "3")
                {
                    e.Row.Cells[8].Text = "特别重要";
                }
                if (e.Row.Cells[9].Text == "0")
                {
                    e.Row.Cells[9].Text = "未分类";
                }
                else if (e.Row.Cells[9].Text == "1")
                {
                    e.Row.Cells[9].Text = "短期潜在";
                }
                else if (e.Row.Cells[9].Text == "2")
                {
                    e.Row.Cells[9].Text = "长期潜在";
                }
                else if (e.Row.Cells[9].Text == "3")
                {
                    e.Row.Cells[9].Text = "意向不明";
                }
                else if (e.Row.Cells[9].Text == "4")
                {
                    e.Row.Cells[9].Text = "已经签约";
                }
                else if (e.Row.Cells[9].Text == "5")
                {
                    e.Row.Cells[9].Text = "已经流失";
                }
                if (e.Row.Cells[12].Text == "0")
                {
                    e.Row.Cells[12].Text = "新导入";
                }
                else if (e.Row.Cells[12].Text == "1")
                {
                    e.Row.Cells[12].Text = "顾问跟进";
                }
                else if (e.Row.Cells[12].Text == "2")
                {
                    e.Row.Cells[12].Text = "文案跟进";
                }
                else if (e.Row.Cells[12].Text == "3")
                {
                    e.Row.Cells[12].Text = "文案搁置";
                }
                else if (e.Row.Cells[12].Text == "4")
                {
                    e.Row.Cells[12].Text = "案件归档";
                }
                else if (e.Row.Cells[12].Text == "5")
                {
                    e.Row.Cells[12].Text = "案件退案";
                }
            }

        }

        protected void btnallchoose_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GVshowCustomerState.Rows)
            {

                CheckBox myCheck = (CheckBox)row.FindControl("checkid");

                if (myCheck != null)
                {

                    if (myCheck.Checked == true)
                    {

                        ListItem Li = new ListItem();
                        Li.Text = row.Cells[2].Text;
                        Li.Value = ((Label)row.FindControl("LabCustomerID")).Text;
                        int Flag = 0;
                        for (int i = 0; i < LbCustomerName.Items.Count; i++)
                        {
                            if (LbCustomerName.Items[i].Value == Li.Value)
                            {
                                Flag = 1;
                                break;
                            }
                        }
                        if (Flag != 1)
                        {
                            LbCustomerName.Items.Add(Li);
                        }
                    }

                }

            }
            foreach (ListItem li in LbCustomerName.Items)
            {
                li.Selected = true;
            }
            if (LbCustomerName.Items.Count == 1)
            {
                DataSet ds = LIS.GetAssignerNamebyCustomerIDFromCopywriter(int.Parse(LbCustomerName.Items[0].Value));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["PostID"].ToString() == "1")
                    {
                        DDlistManager.DataSource = ds;
                        DDlistManager.DataTextField = "StaffName";
                        DDlistManager.DataValueField = "StaffID";
                        DDlistManager.DataBind();
                    }
                    else
                    {
                        DDlistGWName.DataSource = ds;
                        DDlistGWName.DataTextField = "StaffName";
                        DDlistGWName.DataValueField = "StaffID";
                        DDlistGWName.DataBind();
                    }
                }
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            LbCustomerName.Items.Clear();
        }

        protected void ddlGWProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGWCity();
        }

        protected void ddlGWCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authority == 9)
            {
                DataSet ds = stafs.GetGWNamebyAddressDirectlyID_Service(staffInfo.StaffID, ddlGWCity.SelectedItem.Text);
                DDlistGWName.DataSource = ds;
                DDlistGWName.DataTextField = "StaffName";
                DDlistGWName.DataValueField = "StaffID";
                DDlistGWName.DataBind();

                DataSet dscopy = stafs.GetCopyWriterNamebyAddessDirectlyID_Service(staffInfo.StaffID, ddlGWCity.SelectedItem.Text);
                DDlistCopyWriter.DataSource = dscopy;
                DDlistCopyWriter.DataTextField = "StaffName";
                DDlistCopyWriter.DataValueField = "StaffID";
                DDlistCopyWriter.DataBind();
            }

        }

        protected void LbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectSum = 0;
            int Count = LbCustomerName.Items.Count;
            if (LbCustomerName.SelectedIndex != -1)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (LbCustomerName.Items[i].Selected)
                    {
                        SelectSum++;
                        if (authority == 8)
                        {
                            DataSet ds = LIS.GetManagerNamebyCustomerID_Service(int.Parse(LbCustomerName.Items[i].Value));
                            DDlistManager.DataSource = ds;
                            DDlistManager.DataTextField = "StaffName";
                            DDlistManager.DataValueField = "StaffID";
                            DDlistManager.DataBind();
                            if (SelectSum >= 2)
                            {
                                DDlistManager.Items.Clear();
                                break;
                            }
                        }
                        if (authority == 7)
                        {
                            DataSet ds = LIS.GetAssignerNamebyCustomerIDFromCopywriter(int.Parse(LbCustomerName.Items[i].Value));
                            if (ds.Tables[0].Rows[0]["PostID"].ToString() == "1")
                            {
                                DDlistManager.DataSource = ds;
                                DDlistManager.DataTextField = "StaffName";
                                DDlistManager.DataValueField = "StaffID";
                                DDlistManager.DataBind();
                            }
                            else
                            {
                                DDlistGWName.DataSource = ds;
                                DDlistGWName.DataTextField = "StaffName";
                                DDlistGWName.DataValueField = "StaffID";
                                DDlistGWName.DataBind();
                            }
                            if (SelectSum >= 2)
                            {
                                DDlistManager.Items.Clear();
                                DDlistGWName.Items.Clear();
                                break;
                            }
                        }
                    }
                }
            }




        }

        protected void DDAssign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authority == 9)
            {
                if (DDAssign.SelectedItem.Value == "1" || DDAssign.SelectedItem.Value == "0")
                {
                    DDlistCopyWriter.Enabled = false;
                    DDlistGWName.Enabled = true;
                    BtnConfirm.Enabled = true;
                }
                if (DDAssign.SelectedItem.Value == "2" || DDAssign.SelectedItem.Value == "3")
                {
                    DDlistGWName.Enabled = false;
                    DDlistCopyWriter.Enabled = true;
                    BtnConfirm.Enabled = true;
                }
            }
            if (authority == 8)
            {
                if (DDAssign.SelectedItem.Value == "0" || DDAssign.SelectedItem.Value == "1")
                {
                    DDlistManager.Enabled = false;
                    DDlistCopyWriter.Enabled = false;
                    DDlistGWName.Enabled = true;
                    BtnConfirm.Enabled = true;
                }
                else
                {
                    DDlistManager.Enabled = false;
                    DDlistCopyWriter.Enabled = true;
                    DDlistGWName.Enabled = false;
                    BtnConfirm.Enabled = true;
                }
            }
            if (authority == 7)
            {
                DDlistGWName.Enabled = false;
                DDlistManager.Enabled = false;
                BtnConfirm.Enabled = true;
            }


        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (LbCustomerName.Items.Count == 0)
            {
                Response.Write("<script>alert('请导入客户')</script>");
                return;
            }

            if (DDAssign.SelectedItem.Value == "10")
            {
                Response.Write("<script>alert('请选择操作!')</script>");
                return;
            }
            //没有点击确定，跳出
            if (HiddenField1.Value != "1")
            {
                return;
            }

            string NoSignName = "";

            int m = 0;
            int select = 0;
            int repro = 0;
            int signrollback = 0;
            int CopywriterGetrollback = 0;
            int Copywriternotfollow = 0;
            int done = 0;
            int baddone = 0;
            int nobind = 0;
            int gezhi = 0;
            for (int i = 0; i < LbCustomerName.Items.Count; i++)
            {
                if (LbCustomerName.Items[i].Selected)
                {
                    select++;
                    DataSet ds = ASS.GetCustomerNowAssignState_Service(int.Parse(LbCustomerName.Items[i].Value));

                    //未绑定的客户不允许解绑
                    if (DDAssign.SelectedItem.Value == "0")
                    {
                        if (int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString()) < 1)
                        {
                            m++;
                            signrollback++;
                            if (m < 2)
                            {
                                NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                            else
                            {
                                NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                        }
                    }

                    if (ds.Tables[0].Rows[0]["AssignStatus"].ToString() == "3")
                    {

                        if (DDAssign.SelectedItem.Value == "3")
                        {
                            gezhi++;
                            m++;
                            if (m < 2)
                            {
                                NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                            else
                            {
                                NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                        }

                    }


                    //不许做重复的操作
                    if (DDAssign.SelectedItem.Value == ds.Tables[0].Rows[0]["AssignStatus"].ToString() && DDAssign.SelectedItem.Value != "0" && DDAssign.SelectedItem.Value != "3")
                    {
                        repro++;
                        m++;

                        if (m < 2)
                        {
                            NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        }
                        else
                        {
                            NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        }

                    }

                    //已经指派文案的客户不允许再次进行指派顾问，顾问解绑
                    if (int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString()) == 2)
                    {
                        if (int.Parse(DDAssign.SelectedItem.Value) == 0 || int.Parse(DDAssign.SelectedItem.Value) == 1)
                        {
                            CopywriterGetrollback++;
                            m++;
                            if (m < 2)
                            {
                                NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                            else
                            {
                                NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }

                        }
                    }

                    //已经归档的客户,不能做任何操作
                    if (int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString()) == 4)
                    {
                        m++;
                        done++;
                        if (m < 2)
                        {
                            NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        }
                        else
                        {
                            NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        }

                    }

                    //已经退案的客户,不能做任何操作
                    if (int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString()) == 5)
                    {
                        m++;
                        baddone++;
                        if (m < 2)
                        {
                            NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        }
                        else
                        {
                            NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        }

                    }

                    //已经案件搁置的客户不能指给顾问或者给顾问解绑
                    if (int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString()) == 3)
                    {

                        if (DDAssign.SelectedValue == "0" || DDAssign.SelectedValue == "1")
                        {
                            m++;
                            Copywriternotfollow++;
                            if (m < 2)
                            {
                                NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                            else
                            {
                                NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                        }

                    }

                    //除了经理还没有绑定顾问的客户不能指派文案
                    if (DDAssign.SelectedValue == "2")
                    {

                        if (int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString()) == 0 && authority != 9)
                        {
                            m++;
                            nobind++;
                            if (m < 2)
                            {
                                NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                            else
                            {
                                NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                        }




                    }

                    //还没绑给文案的客户不能解绑文案
                    if (DDAssign.SelectedValue == "3")
                    {

                        if (int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString()) == 0 || int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString()) == 1)
                        {
                            m++;
                            nobind++;
                            if (m < 2)
                            {
                                NoSignName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                            else
                            {
                                NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            }
                        }

                    }




                }
            }
            if (select == 0)
            {
                Response.Write("<script>alert('请选择待操作用户')</script>");

                return;
            }
            if (NoSignName != "" && signrollback != 0)
            {
                Response.Write("<script>alert('" + NoSignName + "的状态不允许该操作')</script>");

                return;
            }
            if (NoSignName != "" && gezhi != 0)
            {
                Response.Write("<script>alert('" + NoSignName + "的状态不允许该操作')</script>");

                return;
            }

            if (NoSignName != "" && repro != 0)
            {
                Response.Write("<script>alert('" + NoSignName + "请勿重复操作')</script>");

                return;
            }

            if (NoSignName != "" && CopywriterGetrollback != 0)
            {
                Response.Write("<script>alert('" + "文案已经接手的" + NoSignName + "客户,不能做此操作')</script>");

                return;
            }
            if (NoSignName != "" && done != 0)
            {
                Response.Write("<script>alert('" + NoSignName + "已经归档了！无法操作')</script>");

                return;
            }

            if (NoSignName != "" && baddone != 0)
            {
                Response.Write("<script>alert('" + NoSignName + "已经退案了！无法操作')</script>");

                return;
            }

            if (NoSignName != "" && Copywriternotfollow != 0)
            {
                Response.Write("<script>alert('已经案件搁置的客户:" + NoSignName + "无法该操作')</script>");

                return;
            }
            if (NoSignName != "" && nobind != 0)
            {
                Response.Write("<script>alert('还没绑定的客户:" + NoSignName + "无法该操作')</script>");

                return;
            }



            int lbCount = 0;
            int listcount = LbCustomerName.Items.Count;
            int followid = 0;
            string mes = "";
            string ContractNum = "";
            DataSet dsc = new DataSet();
            int contractcount = 0;



            if (authority == 9)
            {
                string strBindName = "";

                if (DDAssign.SelectedItem.Value == "1")
                {
                    int h = 0;
                    for (int i = 0; i < LbCustomerName.Items.Count; i++)
                    {
                        if (LbCustomerName.Items[i].Selected)
                        {
                            DataSet ds = ASS.GetCustomerNowAssignState_Service(int.Parse(LbCustomerName.Items[i].Value));
                            if (ds.Tables[0].Rows[0]["AssignStatus"].ToString() != "0")
                            {
                                h++;
                                if (h < 2)
                                {
                                    strBindName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                                }
                                else
                                {
                                    NoSignName += "," + ds.Tables[0].Rows[0]["CustomerName"].ToString();
                                }
                            }
                        }
                    }
                    if (strBindName != "")
                    {
                        Response.Write("<script>alert('" + strBindName + "还未解绑，不能指派')</script>");
                        return;
                    }
                }



                if (DDAssign.SelectedItem.Value == "1")
                {
                    for (int i = 0; i < listcount; i++)
                    {
                        if (LbCustomerName.Items[followid].Selected)
                        {
                            int CustomerID = ASS.DoAssignBusiness(staffInfo.StaffID, int.Parse(DDlistGWName.SelectedItem.Value), int.Parse(DDAssign.SelectedItem.Value), txtRemark.Text, int.Parse(LbCustomerName.Items[followid].Value), 9);
                            if (CustomerID != 0)
                            {
                                if (lbCount == 0)
                                {
                                    mes += LbCustomerName.Items[followid].Text;
                                }
                                else
                                {
                                    mes += "," + LbCustomerName.Items[followid].Text;
                                }
                            }
                            else
                            {
                                LbCustomerName.Items.RemoveAt(LbCustomerName.Items.IndexOf(LbCustomerName.Items[followid]));
                                continue;
                            }
                        }
                        followid++;
                    }

                }
                if (DDAssign.SelectedItem.Value == "2")
                {
                    for (int i = 0; i < listcount; i++)
                    {
                        if (LbCustomerName.Items[followid].Selected)
                        {


                            dsc = ASS.GetContractIDbyCustomerID_Service(int.Parse(LbCustomerName.Items[followid].Value));
                            if (dsc.Tables[0].Rows[0]["ContractID"].ToString() == "" || dsc.Tables[0].Rows[0]["ContractID"].ToString() == null)
                            {
                                if (contractcount == 0)
                                {
                                    ContractNum += dsc.Tables[0].Rows[0]["CustomerName"].ToString();
                                    contractcount++;
                                }
                                else
                                {
                                    ContractNum += "," + dsc.Tables[0].Rows[0]["CustomerName"].ToString();
                                    contractcount++;
                                }
                                followid++;
                                continue;
                            }





                            int CustomerID = ASS.DoAssignBusiness(staffInfo.StaffID, int.Parse(DDlistCopyWriter.SelectedItem.Value), int.Parse(DDAssign.SelectedItem.Value), txtRemark.Text, int.Parse(LbCustomerName.Items[followid].Value), 9);
                            if (CustomerID != 0)
                            {
                                if (lbCount == 0)
                                {
                                    mes += LbCustomerName.Items[followid].Text;
                                }
                                else
                                {
                                    mes += "," + LbCustomerName.Items[followid].Text;
                                }
                            }
                            else
                            {
                                LbCustomerName.Items.RemoveAt(LbCustomerName.Items.IndexOf(LbCustomerName.Items[followid]));
                                continue;
                            }
                        }
                        followid++;
                    }
                }

                if (DDAssign.SelectedItem.Value == "0" || DDAssign.SelectedItem.Value == "3")
                {
                    for (int i = 0; i < listcount; i++)
                    {
                        if (LbCustomerName.Items[followid].Selected)
                        {
                            int CustomerID = ASS.DoAssignBusiness(staffInfo.StaffID, 0, int.Parse(DDAssign.SelectedItem.Value), txtRemark.Text, int.Parse(LbCustomerName.Items[followid].Value), 9);
                            if (CustomerID != 0)
                            {
                                if (lbCount == 0)
                                {
                                    mes += LbCustomerName.Items[followid].Text;
                                }
                                else
                                {
                                    mes += "," + LbCustomerName.Items[followid].Text;
                                }
                            }
                            else
                            {
                                LbCustomerName.Items.RemoveAt(LbCustomerName.Items.IndexOf(LbCustomerName.Items[followid]));
                                continue;
                            }
                        }
                        followid++;
                    }
                }
            }

            if (authority == 8)
            {

                if (DDAssign.SelectedItem.Value == "0")
                {
                    for (int i = 0; i < listcount; i++)
                    {
                        if (LbCustomerName.Items[followid].Selected)
                        {


                            int CustomerID = ASS.DoAssignBusiness(staffInfo.StaffID, 0, int.Parse(DDAssign.SelectedItem.Value), txtRemark.Text, int.Parse(LbCustomerName.Items[followid].Value), 8);
                            if (CustomerID != 0)
                            {
                                if (lbCount == 0)
                                {
                                    mes += LbCustomerName.Items[followid].Text;
                                }
                                else
                                {
                                    mes += "," + LbCustomerName.Items[followid].Text;
                                }
                            }
                            else
                            {
                                LbCustomerName.Items.RemoveAt(LbCustomerName.Items.IndexOf(LbCustomerName.Items[followid]));
                                continue;
                            }
                        }
                        followid++;
                    }
                }
                if (DDAssign.SelectedItem.Value == "1")
                {
                    for (int i = 0; i < listcount; i++)
                    {
                        if (LbCustomerName.Items[followid].Selected)
                        {


                            int CustomerID = ASS.DoAssignBusiness(staffInfo.StaffID, staffInfo.StaffID, int.Parse(DDAssign.SelectedItem.Value), txtRemark.Text, int.Parse(LbCustomerName.Items[followid].Value), 8);
                            if (CustomerID != 0)
                            {
                                if (lbCount == 0)
                                {
                                    mes += LbCustomerName.Items[followid].Text;
                                }
                                else
                                {
                                    mes += "," + LbCustomerName.Items[followid].Text;
                                }
                            }
                            else
                            {
                                LbCustomerName.Items.RemoveAt(LbCustomerName.Items.IndexOf(LbCustomerName.Items[followid]));
                                continue;
                            }
                        }
                        followid++;
                    }
                }

                if (DDAssign.SelectedItem.Value == "2")
                {
                    for (int i = 0; i < listcount; i++)
                    {
                        if (LbCustomerName.Items[followid].Selected)
                        {
                            dsc = ASS.GetContractIDbyCustomerID_Service(int.Parse(LbCustomerName.Items[followid].Value));
                            if (dsc.Tables[0].Rows[0]["ContractID"].ToString() == "" || dsc.Tables[0].Rows[0]["ContractID"].ToString() == null)
                            {
                                if (contractcount == 0)
                                {
                                    ContractNum += dsc.Tables[0].Rows[0]["CustomerName"].ToString();
                                    contractcount++;
                                }
                                else
                                {
                                    ContractNum += "," + dsc.Tables[0].Rows[0]["CustomerName"].ToString();
                                    contractcount++;
                                }
                                followid++;
                                continue;
                            }


                            int CustomerID = ASS.DoAssignBusiness(staffInfo.StaffID, int.Parse(DDlistCopyWriter.SelectedItem.Value), int.Parse(DDAssign.SelectedItem.Value), txtRemark.Text, int.Parse(LbCustomerName.Items[followid].Value), 8);
                            if (CustomerID != 0)
                            {
                                if (lbCount == 0)
                                {
                                    mes += LbCustomerName.Items[followid].Text;
                                }
                                else
                                {
                                    mes += "," + LbCustomerName.Items[followid].Text;
                                }
                            }
                            else
                            {
                                LbCustomerName.Items.RemoveAt(LbCustomerName.Items.IndexOf(LbCustomerName.Items[followid]));
                                continue;
                            }
                        }
                        followid++;
                    }
                }
            }

            if (authority == 7)
            {

                for (int i = 0; i < listcount; i++)
                {
                    if (LbCustomerName.Items[followid].Selected)
                    {
                        int CustomerID = ASS.DoAssignBusiness(staffInfo.StaffID, staffInfo.StaffID, int.Parse(DDAssign.SelectedItem.Value), txtRemark.Text, int.Parse(LbCustomerName.Items[followid].Value), 7);
                        if (CustomerID != 0)
                        {
                            if (lbCount == 0)
                            {
                                mes += LbCustomerName.Items[followid].Text;
                            }
                            else
                            {
                                mes += "," + LbCustomerName.Items[followid].Text;
                            }
                        }
                        else
                        {
                            LbCustomerName.Items.RemoveAt(LbCustomerName.Items.IndexOf(LbCustomerName.Items[followid]));
                            continue;
                        }
                    }
                    followid++;
                }
            }

            if (mes == "" && ContractNum == "")
            {
                Response.Write("<script>alert('操作成功')</script>");
                txtRemark.Text = "";
                //LbCustomerName.Items.Clear();
                BindGridView();
                //ds = ASS.GetCustomerAssignInfo_Service(int.Parse(DDListAssignStatus.SelectedValue), ddlUCity.SelectedItem.Text, staffInfo.StaffID, authority, DDImportPeople.SelectedItem.Text.Trim(), DDCountry.SelectedItem.Text.Trim(), int.Parse(DDImportance.SelectedValue), int.Parse(DDCustomerClass.SelectedValue), DDFromData.SelectedItem.Text.Trim(), int.Parse(DDFollowConsultant.SelectedValue), int.Parse(DDCopywriter.SelectedValue),Flag);
                //GVshowCustomerState.DataSource = ds;
                //GVshowCustomerState.DataBind();
                if (authority == 7)
                {
                    GVshowCustomerState.Columns[14].Visible = true;
                }
                else
                {
                    GVshowCustomerState.Columns[14].Visible = false;
                }
            }
            else if (ContractNum == "" && mes != "")
            {
                Response.Write("<script>alert('" + mes + "操作失败')</script>");

            }
            else if (ContractNum != "" && mes == "")
            {
                Response.Write("<script>alert('" + ContractNum + "还没有创建合同！')</script>");
            }
            else
            {
                Response.Write("<script>alert('" + ContractNum + "还没有创建合同！" + mes + "操作失败')</script>");
            }

        }

        protected void GVshowCustomerState_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView GVshowCustomerState = (GridView)sender;
            if (e.NewPageIndex < 0)
            {
                TextBox pageNum = (TextBox)GVshowCustomerState.BottomPagerRow.FindControl("txtNewPageIndex");
                int Pa = int.Parse(pageNum.Text);
                if (Pa <= 0)
                {
                    GVshowCustomerState.PageIndex = 0;
                }
                else
                { GVshowCustomerState.PageIndex = Pa - 1; }
            }
            else
            {
                GVshowCustomerState.PageIndex = e.NewPageIndex;
            }



            //GVshowCustomerState.PageIndex = e.NewPageIndex;
            BindGridView();
            //ds = ASS.GetCustomerAssignInfo_Service(int.Parse(DDListAssignStatus.SelectedValue), ddlUCity.SelectedItem.Text, staffInfo.StaffID, authority, DDImportPeople.SelectedItem.Text.Trim(), DDCountry.SelectedItem.Text.Trim(), int.Parse(DDImportance.SelectedValue), int.Parse(DDCustomerClass.SelectedValue), DDFromData.SelectedItem.Text.Trim(), int.Parse(DDFollowConsultant.SelectedValue), int.Parse(DDCopywriter.SelectedValue),Flag);
            //GVshowCustomerState.DataSource = ds;
            //GVshowCustomerState.DataBind();
            if (authority == 7)
            {
                GVshowCustomerState.Columns[14].Visible = true;
            }
            else
            {
                GVshowCustomerState.Columns[14].Visible = false;
            }
        }

        protected void GVshowCustomerState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "upload")
            {
                Session["CustomerID"] = e.CommandArgument.ToString();
                Session["StaffID"] = staffInfo.StaffID.ToString();
                Response.Redirect("../Document/UploadDocument.aspx");
            }
        }

        protected void GVshowCustomerState_Sorting(object sender, GridViewSortEventArgs e)
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

            if (Flag == 1)
            {
                BindGridView();
            }
            else
            {
                BindGridView();
            }
        }
        public void BindGridView()
        {
            ds = ASS.GetCustomerAssignInfo_Service(int.Parse(DDListAssignStatus.SelectedValue), ddlUCity.SelectedItem.Text, staffInfo.StaffID, authority, DDImportPeople.SelectedItem.Text.Trim(), DDCountry.SelectedItem.Text.Trim(), int.Parse(DDImportance.SelectedValue), int.Parse(DDCustomerClass.SelectedValue), DDFromData.SelectedItem.Text.Trim(), int.Parse(DDFollowConsultant.SelectedValue), int.Parse(DDCopywriter.SelectedValue), Flag);
            DataView myView = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count > 0)
            {
                myView.Sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
                GVshowCustomerState.DataSource = myView;
                GVshowCustomerState.DataBind();
            }
            else
            {
                GVshowCustomerState.DataSource = myView;
                GVshowCustomerState.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string CurrentUserName = System.Environment.UserName;
            ds = ASS.GetCustomerAssignInfo_Service();
            //Create Excel object
            Microsoft.Office.Interop.Excel.Application Ex = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = Ex.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            Ex.Visible = false;
            //Ex.Application.Workbooks.Add(true);
            //Set Title
            Ex.Cells[1, 1] = "客户编号";
            Ex.Cells[1, 2] = "客户姓名";
            Ex.Cells[1, 3] = "性别";
            Ex.Cells[1, 4] = "手机号码";
            Ex.Cells[1, 5] = "重要性";
            Ex.Cells[1, 6] = "客户分类";
            Ex.Cells[1, 7] = "年级";
            Ex.Cells[1, 8] = "意向国家";
            Ex.Cells[1, 9] = "跟进人";
            Ex.Cells[1, 10] = "指派状态";

            //Set row and column
            int RowMax = ds.Tables[0].Rows.Count;
            int ColMax = 10;
            ws.get_Range(ws.Cells[1, 1], ws.Cells[1, ColMax]).Font.Name = "黑体";
            ws.get_Range(ws.Cells[1, 1], ws.Cells[1, ColMax]).Font.Bold = true;
            ws.get_Range(ws.Cells[1, 1], ws.Cells[RowMax + 1, ColMax + 1]).Borders.LineStyle = 1;
            ws.get_Range(ws.Cells[1, 1], ws.Cells[RowMax + 1, ColMax + 1]).ColumnWidth = 15;
            //Fill data to excel
            for (int iRow = 0; iRow < RowMax; iRow++)
            {
                for (int iCol = 0; iCol < ColMax; iCol++)
                {
                    Ex.Cells[iRow + 2, iCol + 1] = ds.Tables[0].Rows[iRow][iCol].ToString();
                    //if (Convert.ToInt32(ds.Tables[0].Rows[iRow][0]) > 0)
                    //{
                    //    string GetcustomerID = ds.Tables[0].Rows[iRow][0].ToString();
                    //    string ChangeFormat = GetcustomerID.PadLeft(8, '0');
                    //    string GetCitySpell = ds.Tables[0].Rows[iRow][10].ToString();
                    //    Ex.Cells[iRow+2,1] = GetCitySpell + ChangeFormat;
                    //}
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime currDate = DateTime.Now;
                string DateName = currDate.Year + "-" + currDate.Month + "-" + currDate.Day;
                // Save Excle file
                Ex.DisplayAlerts = false;
                Ex.AlertBeforeOverwriting = false;
                Ex.ActiveWorkbook.SaveCopyAs(@"C:\TestDemo\Customer" + DateName + ".xlsx");
                //Ex.ActiveWorkbook.SaveCopyAs(@"C:\Users\" + CurrentUserName + "\\Desktop" + "\\Customer" + DateName + ".xlsx");
                //Quit Excel process
                Ex.Quit();
                Response.Write("<script>alert('导出成功至桌面 ！')</script>");
                //C:\Users\v-weiche\Desktop
            }
            else
            {
                Response.Write("<script>alert('空数据 ！')</script>");
            }
        }

        protected void btnTrans_Click(object sender, EventArgs e)
        {
            Session["staffID"] = staffInfo.StaffID;
            Response.Redirect("CustomTransfer.aspx");
        }
    }
}
