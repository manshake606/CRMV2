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
using ModelService;
using CRMControlService;

namespace CRMWebServer.Customer
{
    public partial class CustomerInfoDetails : System.Web.UI.Page
    {
        //static int TableID = -1;
        //public int TableID1 = 0;
        //static int TableID2 = 0;
        //static int TableID3 = 0;
        //static int TableID4 = 0;
        //static int TableID5 = 0;
        //static int TableID6 = 0;
        //private int CustomerID = 0;
        public string City = "城市";

        public int UpdateFamily = 0;
        ModelService.CustomerInfo CSIF = new ModelService.CustomerInfo();
        CRMDBService.ModifyCustomerDB MDB = new CRMDBService.ModifyCustomerDB();
        CRMControlService.ModifyCustomerService MCS = new CRMControlService.ModifyCustomerService();
        DataSet DSIntention = new DataSet();
        DataSet DSLG = new DataSet();
        DataSet DSSchool = new DataSet();
        DataSet DSFamily = new DataSet();
        DataSet DSFollowup = new DataSet();
        ModelService.Intention IT = new ModelService.Intention();
        ModelService.LanguageSkills LS = new ModelService.LanguageSkills();
        ModelService.SchoolRankInfo SRI = new ModelService.SchoolRankInfo();
        ModelService.FamilyInfo FI = new ModelService.FamilyInfo();
        CRMControlService.CustomerService CServer = new CustomerService();
        ContactState CS = new ContactState();
        CRMControlService.ContactStateService css = new ContactStateService();
        StaffInfo staffInfo = new StaffInfo();
        string moduleID = ConfigurationManager.AppSettings["CustomerInfo"];
        int authority = 0;
        CRMControlService.AuthorityService AS = new AuthorityService();
        CRMControlService.AssignStateService ASS = new AssignStateService();
    
        //delegate 

        #region 根据TableID判断显示对应的Table
        /// <summary>
        /// 根据TableID判断显示对应的Table
        /// </summary>
        /// <param name="tableID"></param>
        private void TransferTableID(int tableID)
        {
            //int caseSwitch = 1;
            switch (tableID)
            {
                case 0:
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(0);</script>");
                    break;
                case 1:
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(1);</script>");
                    break;
                case 2:
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(2);</script>");
                    break;
                case 3:
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(3);</script>");
                    break;
                case 4:
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(4);</script>");
                    break;
                case 5:
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(5);</script>");
                    break;
                case 6:
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(6);</script>");
                    break;
                default:
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(0);</script>");
                    break;
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
            ddlDataResource.Items.Add(new ListItem("来源未知", "0"));
            ddlDataResource.Items.Add(new ListItem("名单预约", "1"));
            ddlDataResource.Items.Add(new ListItem("客户推荐", "2"));
            ddlDataResource.Items.Add(new ListItem("移民推荐", "3"));
            ddlDataResource.Items.Add(new ListItem("常州推荐", "4"));
            ddlDataResource.Items.Add(new ListItem("主动上门", "5"));
            ddlDataResource.Items.Add(new ListItem("网络来源", "6"));
            ddlDataResource.Items.Add(new ListItem("个人渠道", "7"));
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

        }
        #endregion

        #region private void BindParentProvince() 省份名称绑定
        /// <summary>
        /// 省份名称数据绑定
        /// </summary>
        protected void BindParentProvince()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                //this.ddlProvince.Items.Clear();
                this.DDLPProvice.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes;
                XmlNode nodeCity = doc.DocumentElement.SelectSingleNode(@"Province/City[@Name='" + this.City + "']");
                foreach (XmlNode node in nodes)
                {
                    this.DDLPProvice.Items.Add(node.Attributes["Name"].Value);
                    int n = this.DDLPProvice.Items.Count - 1;
                    if (nodeCity != null && node == nodeCity.ParentNode)
                        this.DDLPProvice.SelectedIndex = n;
                }
                //.SelectedItem.Text;
                //txtCurrentCity.Text = this.ddlCity.SelectedValue;
                BindParentCity();
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

        #region private void BindParentCity() 城市名称数据绑定
        /// <summary>
        /// 城市名称数据绑定
        /// </summary>
        protected void BindParentCity()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                //this.ddlCity.Items.Clear();
                this.DDLParentCity.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes[this.DDLPProvice.SelectedIndex].ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    this.DDLParentCity.Items.Add(node.Attributes["Name"].Value);
                    int n = this.DDLParentCity.Items.Count - 1;
                    if (node.Attributes["Name"].Value == this.City)
                    {
                        this.DDLParentCity.SelectedIndex = n;
                    }
                }
                if (this.DDLParentCity.SelectedIndex == -1)
                    this.DDLParentCity.SelectedIndex = 0;
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

        #region Load 加载页面信息
        /// <summary>
        /// Load 页面信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (authority == 1)
            {
                BtnDelete.Visible = false;
            }
            if (authority == 2)
            {
                BtnDelete.Visible = true;
            }


            CSIF.CustomerID = int.Parse(Request.QueryString["CustomerID"].ToString());
            CSIF = MDB.GetCustomerInfobyCustomerIDtoCIF(CSIF.CustomerID);
            CSIF = MDB.GetAdmissionCustomerInfobyCustomerIDtoCIF(CSIF.CustomerID);
            int Bind=0;
            Bind=ASS.CheckBind(CSIF.CustomerID);
            if (Bind == 0)
            {
                BtnBind.Visible = true;
                BtnUnband.Visible = false;
            }
            else
            {
                BtnBind.Visible = false;
                BtnUnband.Visible = true;
            }

            if (!IsPostBack)
            {

                //BindDataToDropDownList();
                txtCustomerID.Text = CSIF.CityInitial + CSIF.CustomerID.ToString().Trim().PadLeft(8, '0');
                txtCSTMID.Text = CSIF.CityInitial + CSIF.CustomerID.ToString().Trim().PadLeft(8, '0');
                txtCSTMName.Text = CSIF.CustomerName;
                BindCustomer();

                //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>secBoard(6);</script>");
                BindProvince();
                int i = 0;
                for (; i < ddlProvince.Items.Count; i++)
                {
                    if (ddlProvince.Items[i].Text == CSIF.CProvince)
                    {

                        break;
                    }
                }
                ddlProvince.SelectedIndex = i;

                BindCity();
                int j = 0;
                for (; j < ddlCity.Items.Count; j++)
                {
                    if (ddlCity.Items[j].Text == CSIF.CCity)
                    {

                        break;
                    }
                }
                ddlCity.SelectedIndex = j;

                BindParentProvince();

                BindParentCity();
                rbnPMale.Checked = true;


                //加载主要意向国家
                BindMainCountry();

                //加载意向table
                ViewState["SortOrders"] = "BetterWantTo";
                ViewState["OrderDires"] = "ASC";
                BindIntention();
                

                //加载语言技能talbe
                BindLanguageSkill();

                //加载学校信息
                BindSchool();

                //加载父母信息
                BindFamily();

                //加载录取信息
                txtAdmissionCity.Text = CSIF.AdmissionCity;
                txtAdmissionCountry.Text = CSIF.AdmissionCountry;
                if (CSIF.AdmissionDate == null || CSIF.AdmissionDate == "")
                {
                    txtAdmissionDate.Text = "";
                }
                else
                {
                    txtAdmissionDate.Text = Convert.ToDateTime(CSIF.AdmissionDate).ToShortDateString();
                }
                txtAdmissionProfessional.Text = CSIF.AdmissionProfessionName;
                txtAdmissionSchool.Text = CSIF.AdmissionSname;
                txtAdmissionRemark.Text = CSIF.AdmissionRemark;
                ddlAdmissionPhase.SelectedIndex = CSIF.AdmissionPhase;

                //加载跟进内容
                ViewState["SortOrder"] = "CSDate";
                ViewState["OrderDire"] = "desc";
                BindFollow();
            }


            

           
            
        }
        #endregion

        public void BindMainCountry()
        {
            DataSet dscountry = new DataSet();
            dscountry = CServer.GetMainIntentionCountryByID_Service(CSIF.CustomerID);
            if (dscountry.Tables[0].Rows.Count>0)
            {
                IntentionCountrytxt.Text = dscountry.Tables[0].Rows[0]["IntentionCountry"].ToString().Trim();
            }
        }

        public void LoadCustomer()
        {
            string strtxt = txtCustomerID.Text.Trim();
            CSIF.CustomerID = int.Parse(strtxt.Substring(strtxt.Length - 8, 8));
            CSIF.CustomerName = txtCustomerNmae.Text.Trim();
            CSIF.EnglishName = txtCustomerEnglishName.Text.Trim();
            if (txtCustomerBirsthday.Text == "")
            {
                CSIF.Birthday = "";
            }
            else
            {
                CSIF.Birthday = Convert.ToDateTime(txtCustomerBirsthday.Text.Trim()).ToShortDateString();
            }
            if (rbMale.Checked == true)
            {
                CSIF.Sex = 0;
            }
            else
            {
                CSIF.Sex = 1;
            }
            if (CSIF.Birthday == "")
            {
                CSIF.Age = 0;
            }
            else
            {
                CSIF.Age = DateTime.Now.Year - Convert.ToDateTime(txtCustomerBirsthday.Text.Trim()).Year + 1;
            }
            CSIF.Phone = txtCellPhone.Text.Trim();
            CSIF.Telphone = txtTelPhone.Text.Trim();
            CSIF.BackUpTel = txtBackUpCellPhone.Text.Trim();
            CSIF.CProvince = ddlProvince.SelectedItem.Text.Trim();
            CSIF.CCity = ddlCity.SelectedItem.Text.Trim();
            CSIF.CityInitial = GetPYString(ddlCity.SelectedItem.Text.Trim()).ToUpper();
            CSIF.CQQ = txtQQ.Text.Trim();
            CSIF.Cemail = txtEmail.Text.Trim();
            CSIF.CAddress = txtCustomoerAddress.Text.Trim();
            CSIF.OtherContact = txtContactPerson.Text.Trim();
            CSIF.OtherContactPhone = txtContactPersonTel.Text.Trim();
            CSIF.Policymaker = txtRelationshipWithC.Text.Trim();
            CSIF.PolicymakerName = txtPolicymakerName.Text.Trim();
            CSIF.CustomerClass = ddlCustomerClass.SelectedIndex;
            CSIF.DrainTowards = ddlDrainTowards.SelectedIndex;
            CSIF.Sname = txtOldSchoolName.Text.Trim();
            CSIF.Grade = txtOldGrade.Text.Trim();
            CSIF.ProfessionName = txtOldProfessional.Text.Trim();
            if (ddlCustomerImportant.SelectedIndex == 1)
            {
                CSIF.CustomerImportance = 0;
            }
            else if (ddlCustomerImportant.SelectedIndex == 0)
            {
                CSIF.CustomerImportance = 1;
            }
            else if (ddlCustomerImportant.SelectedIndex == 2)
            {
                CSIF.CustomerImportance = 2;
            }
            else if (ddlCustomerImportant.SelectedIndex == 3)
            {
                CSIF.CustomerImportance = 3;
            }
            CSIF.CustomerFrom = ddlDataResource.SelectedIndex;
            CSIF.Reference = txtRecommendation.Text.Trim();
            CSIF.FromData = txtDataFrom.Text.Trim();
            CSIF.ReferenceRemark = txtRecommendRemark.Text.Trim();
            CSIF.ImportingPeople = txtImportingPeople.Text.Trim();
            CSIF.ImportingDate = Convert.ToDateTime(txtImportingTime.Text.Trim());
            CSIF.Remark = txtRemark.Text.Trim();
        }

        public void BindIntention()
        {
            DSIntention = MDB.GetCustomerIntentionbyCustomerID(CSIF.CustomerID);
            DataView myView = DSIntention.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrders"] + " " + (string)ViewState["OrderDires"];
            if (DSIntention.Tables[0].Rows.Count > 0)
            {
                myView.Sort = sort;
                gvIntention.DataSource = myView;
                gvIntention.DataBind();
            }
            else
            {
                gvIntention.DataSource = myView;
                gvIntention.DataBind();
            }
        }

        public void BindSchool()
        {
            DSSchool = MCS.GetSchoolInfobyCustomerID_Service(CSIF.CustomerID);
            txtAverageScore.Text = DSSchool.Tables[0].Rows[0]["AverageScore"].ToString();
            txtSchoolRankings.Text = DSSchool.Tables[0].Rows[0]["Ranking"].ToString();
            txtOtherStudy.Text = DSSchool.Tables[0].Rows[0]["SchoolOtherInfo"].ToString();
        }

        public void BindFamily()
        {
            DSFamily = MCS.GetFamilyInfobyCustomerID_Service(CSIF.CustomerID);
            gvFamilyInfo.DataSource = DSFamily;
            gvFamilyInfo.DataBind();
        }

        public void BindCustomer()
        {
            txtCustomerNmae.Text = CSIF.CustomerName;
            txtCustomerEnglishName.Text = CSIF.EnglishName;
            if (CSIF.Birthday == "")
            {
                txtCustomerBirsthday.Text = "";
            }
            else
            {
                txtCustomerBirsthday.Text = Convert.ToDateTime(CSIF.Birthday).ToShortDateString();
            }
            if (CSIF.Sex == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemle.Checked = true;
            }
            if (CSIF.Age == 0)
            {
                txtAge.Text = "";
            }
            else
            {
                txtAge.Text = CSIF.Age.ToString();
            }
            txtCellPhone.Text = CSIF.Phone;
            txtTelPhone.Text = CSIF.Telphone;
            txtBackUpCellPhone.Text = CSIF.BackUpTel;
            txtCityLetter.Text = CSIF.CityInitial;


            txtQQ.Text = CSIF.CQQ;
            txtEmail.Text = CSIF.Cemail;
            txtCustomoerAddress.Text = CSIF.CAddress;
            txtContactPerson.Text = CSIF.OtherContact;
            txtContactPersonTel.Text = CSIF.OtherContactPhone;
            txtRelationshipWithC.Text = CSIF.Policymaker;
            txtPolicymakerName.Text = CSIF.PolicymakerName;
            ddlCustomerClass.SelectedIndex = CSIF.CustomerClass;
            ddlDrainTowards.SelectedIndex = CSIF.DrainTowards;
            txtOldSchoolName.Text = CSIF.Sname;
            txtOldGrade.Text = CSIF.Grade;
            txtOldProfessional.Text = CSIF.ProfessionName;
            if (CSIF.CustomerImportance == 0)
            {
                ddlCustomerImportant.SelectedIndex = 1;
            }
            else if (CSIF.CustomerImportance == 1)
            {
                ddlCustomerImportant.SelectedIndex = 0;
            }
            else if (CSIF.CustomerImportance == 2)
            {
                ddlCustomerImportant.SelectedIndex = 2;
            }
            else if (CSIF.CustomerImportance == 3)
            {
                ddlCustomerImportant.SelectedIndex = 3;
            }

            ddlDataResource.SelectedIndex = CSIF.CustomerFrom;
            txtRecommendation.Text = CSIF.Reference;
            txtDataFrom.Text = CSIF.FromData;
            txtRecommendRemark.Text = CSIF.ReferenceRemark;
            txtImportingPeople.Text = CSIF.ImportingPeople;
            txtImportingTime.Text = CSIF.ImportingDate.ToString();
            txtRemark.Text = CSIF.Remark;
        }

        public void BindFollow()
        {
            DSFollowup = css.GetContactStateInfo_Service(CSIF.CustomerID, 0, "", "");
            DataView myView = DSFollowup.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            if (DSFollowup.Tables[0].Rows.Count > 0)
            {
                myView.Sort = sort;
                gv_showfollowupInfo.DataSource = myView;
                gv_showfollowupInfo.DataBind();
            }
            else
            {
                gv_showfollowupInfo.DataSource = myView;
                gv_showfollowupInfo.DataBind();

            }
        }

        #region 客户信息修改
        /// <summary>
        /// 客户信息修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCustomerInfoUpdate_Click(object sender, EventArgs e)
        {
            if ((ddlDataResource.SelectedItem.Value == "2" || ddlDataResource.SelectedItem.Value == "7" || ddlDataResource.SelectedItem.Value == "8") && txtRecommendation.Text.Trim() == "")
            {
                CVReference.IsValid = false;
                return;
            }
            if (ddlDataResource.SelectedItem.Value == "1" && txtDataFrom.Text.Trim() == "")
            {
                CVFromData.IsValid = false;
                return;
            }

            LoadCustomer();
            int Pass = MCS.UpdateCustomerInfobyCustomerID_Service(CSIF);
            if (Pass == 0)
            {
                CSIF = MDB.GetCustomerInfobyCustomerIDtoCIF(CSIF.CustomerID);
                BindCustomer();
                ScriptManager.RegisterStartupScript(UpdatePanel7, this.GetType(), "myscript", "<script>alert('更新成功!')</script>", false);

            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel7, this.GetType(), "myscript", "<script>alert('更新失败!')</script>", false);
            }

        }
        #endregion

        #region 客户信息取消设置
        /// <summary>
        /// 客户信息取消设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCustomerInfoCancel_Click(object sender, EventArgs e)
        {
            BindCustomer();
        }
        #endregion

        #region 意向信息添加
        /// <summary>
        /// 意向信息添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIntentionInsert_Click(object sender, EventArgs e)
        {
            DataSet DSI = new DataSet();
            

            loadIntentionbytxt();
            DSI = MCS.GetCustomerIntentionbyCustomerID_Service(IT.CustomerID);
            if (DSI.Tables[0].Rows.Count > 0 && IT.BetterWantpriTo == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "myscript", "<script>alert('已经有主要意向!')</script>", false);
                return;
            } 
            if (IT.IntentionCity == "" && IT.IntentionCountry == "" && IT.IntentionProfession == "" && IT.IntentionSchool == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "myscript", "<script>alert('请至少添加一个意向!')</script>", false);
                return;
            }
            int Pass = MCS.InsertCustomerIntention＿Service(IT);
            if (Pass == 0)
            {

                //提醒
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "myscript", "<script>alert('添加意向成功!')</script>", false);

                txtIntentionCity.Text = "";
                txtIntentionCountry.Text = "";
                txtIntentionProfessional.Text = "";
                txtIntentionSchool.Text = "";
                txtIntentiondate.Text = "";
                DDLIntentionPhase.SelectedIndex = 0;
                DDLBetterWantTo.SelectedIndex = 0;

            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "myscript", "<script>alert('添加失败!')</script>", false);

            }
            BindIntention();

        }
        #endregion

        protected void loadIntentionbytxt()
        {
            IT.CustomerID = CSIF.CustomerID;
            IT.IntentionCity = txtIntentionCity.Text.Trim();
            IT.IntentionCountry = txtIntentionCountry.Text.Trim();
            IT.IntentionProfession = txtIntentionProfessional.Text.Trim();
            IT.IntentionSchool = txtIntentionSchool.Text.Trim();
            IT.IntentionPhase = int.Parse(DDLIntentionPhase.SelectedItem.Value);
            IT.BetterWantpriTo = int.Parse(DDLBetterWantTo.SelectedItem.Value);
            IT.Intentiondate = DateTime.Parse(txtIntentiondate.Text.Trim());
            IT.Remark = txtRemark.Text.Trim();
        }

        protected void LoadLanguageSkillsbytxt()
        {
            LS.CustomerID = CSIF.CustomerID; ;
            LS.LGIName = txtLanguageName.Text.Trim();
            LS.Remark = txtLanguageRemark.Text.Trim();
            LS.Score = txtLanguageScore.Text.Trim();
            LS.ImportingDate = DateTime.Now;
        }

        protected void LoadFamilybytxt()
        {
            if (txtFID.Text != "")
            {
                FI.FID = int.Parse(txtFID.Text.Trim());
            }
            FI.CustomerID = CSIF.CustomerID;
            FI.ParentName = txtParentName.Text.Trim();
            if (rbnPMale.Checked == true)
            {
                FI.ParentSex = 0;
            }
            else
            {
                FI.ParentSex = 1;
            }
            if (txtParentBirthday.Text.Trim() != "")
            {
                FI.ParentBirthday = txtParentBirthday.Text.Trim();
            }
            else
            {
                FI.ParentBirthday = "";
            }
           
            FI.ParentMobilephone = txtParentCellPhone.Text.Trim();
            FI.ParentTelphone = txtParentTel.Text.Trim();
            FI.ParentProvince = DDLPProvice.SelectedItem.Text.Trim();
            FI.ParentCity = DDLParentCity.SelectedItem.Text.Trim();
            FI.ParentCityInitial = GetPYString(FI.ParentCity).ToUpper().Trim();
            if (FI.ParentBirthday.ToString() == "" || FI.ParentBirthday == null)
            {
                FI.ParentAge = 0;
            }
            else
            {
                FI.ParentAge = DateTime.Now.Year -Convert.ToDateTime(FI.ParentBirthday).Year + 1;
            }
            FI.ParentInCome = txtParentIncome.Text.Trim();
            FI.ParentMail = txtParentMail.Text.Trim();
            FI.ParentQQ = txtParentQQ.Text.Trim();
            FI.ParentWorkUnit = txtParentWorkUnit.Text.Trim();
            FI.ParentWorkPosition = txtParentPostion.Text.Trim();
            FI.Relationship = txtParentRelationship.Text.Trim();
            FI.Remark = txtParentRemark.Text.Trim();
            FI.BirthdayRemind = int.Parse(DDLParentRemind.SelectedItem.Value);
        }

        #region 取消意向信息插入
        /// <summary>
        /// 取消意向信息插入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIntentionCancel_Click(object sender, EventArgs e)
        {
            txtIntentionCity.Text = "";
            txtIntentionCountry.Text = "";
            txtIntentionProfessional.Text = "";
            txtIntentionSchool.Text = "";
            DDLIntentionPhase.SelectedIndex = 0;
            DDLBetterWantTo.SelectedIndex = 0;

        }
        #endregion

        protected void gvIntention_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvIntention.EditIndex = e.NewEditIndex;
            BindIntention();

        }

        protected void gvIntention_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvIntention.EditIndex = -1;
            BindIntention();
        }

        protected void gvIntention_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
                {
                    DropDownList drps = (DropDownList)e.Row.FindControl("DDLBetterWantTo");
                    HiddenField hfw = (HiddenField)e.Row.FindControl("Hidwant");
                    drps.SelectedIndex = int.Parse(hfw.Value);
                    drps.Enabled = false;
                    HiddenField hidPhase = (HiddenField)e.Row.FindControl("HidIntentionPhase");
                    DropDownList drPa = (DropDownList)e.Row.FindControl("DDLIntentionPhase");
                    drPa.SelectedIndex = int.Parse(hidPhase.Value);
                }
                else
                {
                    Label IntentionPhase = (Label)e.Row.FindControl("LabIntentionPhase");
                    if (IntentionPhase.Text == "0")
                    {
                        IntentionPhase.Text = "未定";
                    }
                    else if (IntentionPhase.Text == "1")
                    {
                        IntentionPhase.Text = "初中";
                    }
                    else if (IntentionPhase.Text == "2")
                    {
                        IntentionPhase.Text = "高中";
                    }
                    else if (IntentionPhase.Text == "3")
                    {
                        IntentionPhase.Text = "本科";
                    }
                    else if (IntentionPhase.Text == "4")
                    {
                        IntentionPhase.Text = "硕士";
                    }
                    else if (IntentionPhase.Text == "5")
                    {
                        IntentionPhase.Text = "博士";
                    }

                    Label LabBWT = (Label)e.Row.FindControl("LabBetterWantTo");
                    if (LabBWT.Text == "0")
                    {
                        LabBWT.Text = "主要";
                    }
                    if (LabBWT.Text == "1")
                    {
                        LabBWT.Text = "次要";
                    }
                }
            }



        }

        protected void gvIntention_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            IT.CustomerID = CSIF.CustomerID;
            IT.ITTID = int.Parse(gvIntention.DataKeys[e.RowIndex].Value.ToString());
            IT.IntentionCity = ((TextBox)gvIntention.Rows[e.RowIndex].FindControl("txtIntentionCity")).Text;
            IT.IntentionCountry = ((TextBox)gvIntention.Rows[e.RowIndex].FindControl("txtIntentionCountry")).Text;
            IT.IntentionSchool = ((TextBox)gvIntention.Rows[e.RowIndex].FindControl("txtIntentionSchool")).Text;
            IT.IntentionProfession = ((TextBox)gvIntention.Rows[e.RowIndex].FindControl("txtIntentionProfession")).Text;
            IT.IntentionPhase = Int32.Parse(((DropDownList)gvIntention.Rows[e.RowIndex].FindControl("DDLIntentionPhase")).SelectedItem.Value);
            IT.BetterWantpriTo = Int32.Parse(((DropDownList)gvIntention.Rows[e.RowIndex].FindControl("DDLBetterWantTo")).SelectedItem.Value);
            string Intentiondate = ((TextBox)gvIntention.Rows[e.RowIndex].FindControl("txtIntentiondate")).Text.Trim().ToString();
            DateTime dtime = new DateTime();
            try
            {
                dtime = Convert.ToDateTime(Intentiondate);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "myscript", "<script>alert('日期格式错误!')</script>", false);
                return;
            }
            IT.Intentiondate = dtime;

            IT.Remark = ((TextBox)gvIntention.Rows[e.RowIndex].FindControl("txtRemark")).Text;
            MCS.UpdateCustomerIntention_Service(IT);
            gvIntention.EditIndex = -1;
            BindIntention();
            BindMainCountry();
        }

        protected void gvIntention_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            IT.ITTID = int.Parse(gvIntention.DataKeys[e.RowIndex].Value.ToString());
            MCS.DeleteCustomerIntentionbyITTID_Service(IT.ITTID);
            BindIntention();
        }

        protected void btnLanguageAdd_Click(object sender, EventArgs e)
        {
            if (txtLanguageName.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "myscript", "<script>alert('请输入语言!')</script>", false);
                return;
            }
            LoadLanguageSkillsbytxt();
            int Pass = MCS.InsertLanguageSkills_Service(LS);
            if (Pass == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "myscript", "<script>alert('添加语言技能成功!')</script>", false);
                txtLanguageName.Text = "";
                txtLanguageRemark.Text = "";
                txtLanguageScore.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "myscript", "<script>alert('添加语言技能失败!')</script>", false);
            }
            BindLanguageSkill();
        }

        protected void btnLanguageCancel_Click(object sender, EventArgs e)
        {
            txtLanguageName.Text = "";
            txtLanguageRemark.Text = "";
            txtLanguageScore.Text = "";
        }

        protected void BindLanguageSkill()
        {
            DSLG = MCS.GetLanguageSkillsbyCustomerID_Service(CSIF.CustomerID);
            gvLanguageSkills.DataSource = DSLG;
            gvLanguageSkills.DataBind();
        }

        protected void gvLanguageSkills_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvLanguageSkills.EditIndex = e.NewEditIndex;
            BindLanguageSkill();
        }

        protected void gvLanguageSkills_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            LS.LGID = int.Parse(gvLanguageSkills.DataKeys[e.RowIndex].Value.ToString());
            LS.LGIName = ((TextBox)gvLanguageSkills.Rows[e.RowIndex].FindControl("txtLGIName")).Text;
            LS.Score = ((TextBox)gvLanguageSkills.Rows[e.RowIndex].FindControl("txtScore")).Text;
            LS.Remark = ((TextBox)gvLanguageSkills.Rows[e.RowIndex].FindControl("txtLGRemark")).Text;
            LS.CustomerID = CSIF.CustomerID;
            LS.ImportingDate = DateTime.Now;
            int Pass = MCS.UpdateLanguageSkills_Service(LS);
            if (Pass == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "myscript", "<script>alert('更新语言技能成功!')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "myscript", "<script>alert('更新语言技能失败!')</script>", false);
            }
            gvLanguageSkills.EditIndex = -1;
            BindLanguageSkill();
        }

        protected void gvLanguageSkills_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLanguageSkills.EditIndex = -1;
            BindLanguageSkill();
        }

        protected void gvLanguageSkills_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LS.LGID = int.Parse(gvLanguageSkills.DataKeys[e.RowIndex].Value.ToString());
            MCS.DeleteLanguageSkillsbyLGID(LS.LGID);
            BindLanguageSkill();
        }

        protected void gvLanguageSkills_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
                {
                    TextBox tb = (TextBox)e.Row.FindControl("txtImportingDate");
                    tb.Text = Convert.ToDateTime(tb.Text).ToShortDateString();

                }
                else
                {
                    Label LabLGTime = (Label)e.Row.FindControl("LabImportingDate");
                    LabLGTime.Text = Convert.ToDateTime(LabLGTime.Text).ToShortDateString();
                }
            }
        }

        protected void btnStudiesUpdate_Click(object sender, EventArgs e)
        {
            int Pass = MCS.UpdateSchoolInfo_Service(txtAverageScore.Text.Trim(), txtSchoolRankings.Text.Trim(), txtOtherStudy.Text.Trim(), CSIF.CustomerID.ToString());
            if (Pass == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel3, this.GetType(), "myscript", "<script>alert('更新学校信息成功!')</script>", false);
            }

        }

        protected void btnStudiesCancel_Click(object sender, EventArgs e)
        {
            int Pass = MCS.DeleteSchoolInfo_Service(txtAverageScore.Text.Trim(), txtSchoolRankings.Text.Trim(), txtOtherStudy.Text.Trim(), CSIF.CustomerID.ToString());
            if (Pass == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel3, this.GetType(), "myscript", "<script>alert('清空学校信息成功!')</script>", false);
            }
            txtAverageScore.Text = "";
            txtSchoolRankings.Text = "";
            txtOtherStudy.Text = "";
        }

        protected void btnAddFamilyInfo_Click(object sender, EventArgs e)
        {
            int Pass=0;
            LoadFamilybytxt();
            if (txtFID.Text == "")
            {
                Pass = MCS.InsertFamilyInfo_Service(FI);
            }
            else
            {
                //FI.FID = int.Parse(txtFID.Text.Trim());
                Pass = MCS.UpdateFamilyInfo_Service(FI);
                
            }
            if (Pass == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "myscript", "<script>alert('操作成功!')</script>", false);
                if (txtFID.Text != "")
                {
                    gvFamilyInfo.SelectedIndex = -1;
                }
                cleanFamilyInfo();

            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "myscript", "<script>alert('操作失败!')</script>", false);
            }

            BindFamily();
            

        }

        protected void DDLPProvice_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            BindParentCity();
            ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "myscript", "<script>show('家庭信息添加')</script>", false);
        }

        protected void gvFamilyInfo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "myscript", "<script>show('家庭信息添加')</script>", false);
            FI.FID = int.Parse(gvFamilyInfo.DataKeys[e.NewSelectedIndex].Value.ToString());
            DSFamily = MCS.GetFamilyInfobyFID_Service(FI.FID);
            txtParentName.Text = gvFamilyInfo.Rows[e.NewSelectedIndex].Cells[0].Text.Trim();

            if (gvFamilyInfo.Rows[e.NewSelectedIndex].Cells[1].Text.Trim()=="男")
            {
                rbnPMale.Checked = true;
            }
            else
            {
                rbnPFeMale.Checked = false;
            }

            BindParentProvince();
            int i = 0;
            for (; i < DDLPProvice.Items.Count; i++)
            {
                if (DDLPProvice.Items[i].Text == gvFamilyInfo.Rows[e.NewSelectedIndex].Cells[2].Text.Trim())
                {

                    break;
                }
            }
            DDLPProvice.SelectedIndex = i;

            BindParentCity();
            int j = 0;
            for (; j < DDLParentCity.Items.Count; j++)
            {
                if (DDLParentCity.Items[j].Text == gvFamilyInfo.Rows[e.NewSelectedIndex].Cells[3].Text.Trim())
                {

                    break;
                }
            }
            DDLParentCity.SelectedIndex = j;


            txtParentBirthday.Text = DSFamily.Tables[0].Rows[0]["ParentBirthday"].ToString().Trim();
            if (txtParentBirthday.Text != "")
            {
                txtParentBirthday.Text = Convert.ToDateTime(txtParentBirthday.Text).ToString("yyyy-MM-dd");
            }
            txtParentCellPhone.Text = DSFamily.Tables[0].Rows[0]["ParentMobilephone"].ToString();
            txtParentTel.Text = DSFamily.Tables[0].Rows[0]["ParentTelphone"].ToString();
            txtParentWorkUnit.Text = DSFamily.Tables[0].Rows[0]["ParentWorkUnit"].ToString();
            txtParentPostion.Text = DSFamily.Tables[0].Rows[0]["ParentWorkPosition"].ToString();
            txtParentAge.Text = DSFamily.Tables[0].Rows[0]["ParentAge"].ToString();
            txtParentQQ.Text = DSFamily.Tables[0].Rows[0]["ParentQQ"].ToString();
            txtParentMail.Text = DSFamily.Tables[0].Rows[0]["ParentMail"].ToString();
            txtParentRelationship.Text = DSFamily.Tables[0].Rows[0]["Relationship"].ToString();
            txtParentIncome.Text = DSFamily.Tables[0].Rows[0]["ParentInCome"].ToString();
            DDLParentRemind.SelectedIndex = int.Parse(DSFamily.Tables[0].Rows[0]["BirthdayRemind"].ToString());
            txtParentRemark.Text = DSFamily.Tables[0].Rows[0]["Remark"].ToString();
            txtFID.Text = FI.FID.ToString();
            ButCh.Enabled = true;
        }


        public string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 0 && (int)c <= 160)
                {//字母和符号原样保留十位数   
                    //tempStr += c.ToString();
                    tempStr += Convert.ToString(char.ToUpper(c));
                }
                else
                {//累加拼音声母    
                    tempStr += GetPYChar(c.ToString());

                }
            }
            return tempStr;
        }

        ///     
        /// 取单个字符的拼音声母    
        ///     
        /// 要转换的单个汉字    
        /// 拼音声母    
        public string GetPYChar(string c)
        {
            System.Text.Encoding GB2312 = System.Text.Encoding.GetEncoding("GB2312");//英文系统默认是一个汉字占一个字节，首先把汉字转换成GB2312编码方式
            byte[] array = new byte[2];
            array = GB2312.GetBytes(c);
            //array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }

        public void cleanFamilyInfo()
        {
            txtFID.Text = "";
            txtParentName.Text = "";
            rbnPMale.Checked = true;
            rbnPFeMale.Checked = false;
            txtParentBirthday.Text = "";
            txtParentCellPhone.Text = "";
            txtParentWorkUnit.Text = "";
            txtParentPostion.Text = "";
            DDLPProvice.SelectedIndex = 0;
            txtParentTel.Text = "";
            txtParentAge.Text = "";
            txtParentQQ.Text = "";
            txtParentMail.Text = "";
            txtParentRelationship.Text = "";
            txtParentIncome.Text = "";
            DDLParentRemind.SelectedIndex = 0;
            txtParentRemark.Text = "";

        }

        protected void gvFamilyInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "0")
                {
                    e.Row.Cells[1].Text = "男";
                }
                else
                {
                    e.Row.Cells[1].Text = "女";
                }
                if (e.Row.Cells[4].Text != "" && e.Row.Cells[4].Text != "&nbsp;")
                {
                    e.Row.Cells[4].Text = Convert.ToDateTime(e.Row.Cells[4].Text).ToString("yyyy-MM-dd");
                }
                if (e.Row.Cells[2].Text == "0")
                {
                    e.Row.Cells[2].Text = "省份";
                }
                if (e.Row.Cells[3].Text == "0")
                {
                    e.Row.Cells[3].Text = "城市";
                }

            }
            
        }

        protected void btnFamilyInfoCancel_Click(object sender, EventArgs e)
        {
            cleanFamilyInfo();
            gvFamilyInfo.SelectedIndex = -1;
        }

        protected void txtParentRelationship_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvFamilyInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            FI.FID = int.Parse(gvFamilyInfo.DataKeys[e.RowIndex].Value.ToString());
            MCS.DeleteFamilyInfobyFID_Service(FI.FID);
            BindFamily();
        }

        protected void btnAdmissionsUpdate_Click(object sender, EventArgs e)
        {
            if (txtAdmissionCity.Text == "" && txtAdmissionCountry.Text == "" && txtAdmissionProfessional.Text == "" && txtAdmissionSchool.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel5, this.GetType(), "myscript", "<script>alert('请至少添加一项录取信息!')</script>", false);
                return;
            }
            CSIF.AdmissionCity = txtAdmissionCity.Text.Trim();
            CSIF.AdmissionCountry = txtAdmissionCountry.Text.Trim();
            CSIF.CustomerID = CSIF.CustomerID;
            CSIF.AdmissionDate = Convert.ToDateTime(txtAdmissionDate.Text.Trim()).ToShortDateString();
            CSIF.AdmissionProfessionName = txtAdmissionProfessional.Text.Trim();
            CSIF.AdmissionSname = txtAdmissionSchool.Text.Trim();
            CSIF.AdmissionRemark = txtAdmissionRemark.Text.Trim();
            CSIF.AdmissionPhase = int.Parse(ddlAdmissionPhase.SelectedItem.Value);
            int Pass = MCS.UpdateAdmissionInfobyCustomerID_Service(CSIF);
            if (Pass == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel5, this.GetType(), "myscript", "<script>alert('更新成功!')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel5, this.GetType(), "myscript", "<script>alert('更新失败!')</script>", false);
            }
            
        }

        protected void BbtnAdmissionsCancel_Click(object sender, EventArgs e)
        {
            txtAdmissionCity.Text = "";
            txtAdmissionCountry.Text = "";
            CSIF.CustomerID = CSIF.CustomerID;
            txtAdmissionDate.Text = "";
            txtAdmissionProfessional.Text = "";
            txtAdmissionSchool.Text = "";
            txtAdmissionRemark.Text = "";
            ddlAdmissionPhase.SelectedIndex = 0;
            int Pass = MCS.UpdateAdmissionInfobyCustomerID_Service(CSIF);
            if (Pass == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel5, this.GetType(), "myscript", "<script>alert('清空成功!')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel5, this.GetType(), "myscript", "<script>alert('清空失败!')</script>", false);
            }
        }

        protected void gv_showfollowupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gv_showfollowupInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_showfollowupInfo.EditIndex = e.NewEditIndex;
            BindFollow();
        }

        protected void gv_showfollowupInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string date = ((TextBox)gv_showfollowupInfo.Rows[e.RowIndex].FindControl("TxtCSDate")).Text.Trim().ToString();
            DateTime dtime = new DateTime();
            try
            {
                dtime = Convert.ToDateTime(date);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel6, this.GetType(), "myscript", "<script>alert('日期格式错误!')</script>", false);
                return;
            }
            CS.CSID = Convert.ToInt32(gv_showfollowupInfo.DataKeys[e.RowIndex].Values[0]);
            CS.CustomerID = CSIF.CustomerID;
            CS.StaffID = staffInfo.StaffID;
            CS.CSContent = ((TextBox)gv_showfollowupInfo.Rows[e.RowIndex].FindControl("TxtCSContent")).Text;
            if (CS.CSContent.Length > 200)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel6, this.GetType(), "myscript", "<script>alert('跟进内容过长!')</script>", false);
                return;
            }
            css.UpdateContactStateInfo_Service(CS.CSID, CS.CustomerID, CS.StaffID, CS.CSContent, date);
            gv_showfollowupInfo.EditIndex = -1;
            BindFollow();
            


        }

        protected void gv_showfollowupInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_showfollowupInfo.EditIndex = -1;
            BindFollow();
        }

        protected void gv_showfollowupInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv_showfollowupInfo = (GridView)sender;
            if (e.NewPageIndex < 0)
            {
                TextBox pageNum = (TextBox)gv_showfollowupInfo.BottomPagerRow.FindControl("txtNewPageIndex");
                int Pa = int.Parse(pageNum.Text);
                if (Pa <= 0)
                {
                    gv_showfollowupInfo.PageIndex = 0;
                }
                else
                { gv_showfollowupInfo.PageIndex = Pa - 1; }
            }
            else
            {
                gv_showfollowupInfo.PageIndex = e.NewPageIndex;
            }
            BindFollow();
        }

        protected void btnContactStateAdd_Click(object sender, EventArgs e)
        {
            try
            {
                css.InsertContactStateInfo_Service(CSIF.CustomerID, staffInfo.StaffID, txtContactContent.Text.Trim().ToString(), txtContactTime.Text.Trim().ToString());
                ScriptManager.RegisterStartupScript(UpdatePanel6, this.GetType(), "myscript", "<script>alert('添加成功!')</script>", false);
                txtContactContent.Text = "";
                txtContactTime.Text = "";
                
                BindFollow();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel6, this.GetType(), "myscript", "<script>alert('添加失败!')</script>", false);
            }
        }

        protected void btnContactCancel_Click(object sender, EventArgs e)
        {
            txtContactContent.Text = "";
            txtContactTime.Text = "";
            
        }

        protected void gv_showfollowupInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CSID = Convert.ToInt32(gv_showfollowupInfo.DataKeys[e.RowIndex].Values[0]);
            css.DeleteContactStateInfo_Service(CSID);
            BindFollow();
        }

        protected void ButCh_Click(object sender, EventArgs e)
        {
            ModelService.CustomerInfo CSIFFamily = new ModelService.CustomerInfo();
            CSIFFamily.CustomerName = txtParentName.Text.Trim();
            if (rbnPMale.Checked == true)
            {
                CSIFFamily.Sex = 0;
            }
            else
            {
                CSIFFamily.Sex = 1;
            }
            if (txtParentBirthday.Text != "")
            {
                CSIFFamily.Birthday = txtParentBirthday.Text.Trim();
                CSIFFamily.Age = DateTime.Now.Year - Convert.ToDateTime(txtParentBirthday.Text.Trim()).Year + 1;
            }
            CSIFFamily.Telphone = txtParentCellPhone.Text.Trim();
            CSIFFamily.CProvince = DDLPProvice.SelectedItem.Text.Trim();
            CSIFFamily.CCity = DDLParentCity.SelectedItem.Text.Trim();
            CSIFFamily.CityInitial = GetPYString(DDLParentCity.SelectedItem.Text.Trim()).ToUpper();
            CSIFFamily.CQQ = txtParentQQ.Text.Trim();
            CSIFFamily.Cemail = txtParentMail.Text.Trim();
            CSIFFamily.Phone = txtParentTel.Text.Trim();
            CSIFFamily.Remark = txtParentRemark.Text.Trim();
            CSIFFamily.CustomerClass = 0;
            CSIFFamily.CustomerImportance = 1;
            CSIFFamily.DrainTowards = 0;
            CSIFFamily.AdmissionPhase = 0;
            CSIFFamily.CustomerFrom = 0;
            CSIFFamily.ImportingDate = DateTime.Now;


            DataSet ds = MCS.GetCustomerInfobyTelphone_Service(CSIFFamily.Telphone);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "myscript", "<script>alert('手机号已经存在！')</script>", false);
                return;
            }
            int error = MCS.DoInsertBusiness(CSIFFamily, staffInfo.StaffID, IT);
            
            if (error == 0)
            {
                gvFamilyInfo.SelectedIndex = -1;
                ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "myscript", "<script>alert('操作成功')</script>", false);
                ButCh.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "myscript", "<script>alert('操作失败')</script>", false);
                return;
            }
            BindFamily();
        }

        protected void DDLParentCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "myscript", "<script>show('家庭信息添加')</script>", false);
        }

        protected void gv_showfollowupInfo_Sorting(object sender, GridViewSortEventArgs e)
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
            BindFollow();
        }

        protected void gvIntention_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sPage = e.SortExpression;
            if (ViewState["SortOrders"].ToString() == sPage)
            {
                if (ViewState["OrderDires"].ToString() == "Desc")
                {
                    ViewState["OrderDires"] = "ASC";
                }
                else
                {
                    ViewState["OrderDires"] = "Desc";
                }
            }
            else
            {
                ViewState["SortOrders"] = e.SortExpression;
            }
            BindIntention();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int flag=CServer.doBatchDelete(CSIF.CustomerID);
            if (flag == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel7, this.GetType(), "myscript", "<script>alert('删除成功!')</script>", false);
                Response.Redirect("CustomerInfo.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel7, this.GetType(), "myscript", "<script>alert('删除失败!')</script>", false);
            }
        }

        protected void BtnUnband_Click(object sender, EventArgs e)
        {
            int result = CServer.doUnBand(CSIF.CustomerID, staffInfo.StaffID);
            if (result == 0)
            {
                CSIF = MDB.GetCustomerInfobyCustomerIDtoCIF(CSIF.CustomerID);
                BindCustomer();
                ScriptManager.RegisterStartupScript(UpdatePanel7, this.GetType(), "myscript", "<script>alert('解绑成功!')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel7, this.GetType(), "myscript", "<script>alert('解绑失败!')</script>", false);
            }
        }

        protected void BtnBind_Click(object sender, EventArgs e)
        {
            try
            {
                ASS.DoAssignBusiness(staffInfo.StaffID, staffInfo.StaffID, 1, "", CSIF.CustomerID, 8);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel7, this.GetType(), "myscript", "<script>alert('绑定失败!')</script>", false);
                return;
            }

            ScriptManager.RegisterStartupScript(UpdatePanel7, this.GetType(), "myscript", "<script>alert('绑定成功!')</script>", false);


        }

        protected void txtCustomerBirsthday_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
