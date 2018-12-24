using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMControlService;
using ModelService;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using System.Configuration;


namespace CRMWebServer.InputCustomerInfo
{
    public partial class AddCustomerBaseInfo : System.Web.UI.Page
    {
        
        public string City = "城市";
        CustomerInfo CIF = new CustomerInfo();
        Intention ITA= new Intention();
        CRMControlService.AuthorityService AS = new AuthorityService();
        string moduleID = ConfigurationManager.AppSettings["InputCustomer"];
        CRMControlService.StaffInfoService stafs = new StaffInfoService();
        StaffInfo staffInfo = new StaffInfo();
        CRMControlService.ModifyCustomerService MCS = new ModifyCustomerService();
        DataSet ds = new DataSet();
        DataSet dns = new DataSet();
        DataSet dsIntention = new DataSet();
        int authority = 0;
        int Age = 0;
        string CustomerID = "";
        string Cityinit = "";


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
            if (HttpContext.Current.Session["CustomerID"] != null)
            {
                CIF.CustomerID = Int32.Parse(HttpContext.Current.Session["CustomerID"].ToString());
                dns = MCS.GetCustomerInfobyCustomerID_Service(CIF.CustomerID);
                CustomerID = dns.Tables[0].Rows[0]["CustomerID"].ToString();
                CustomerID = CustomerID.PadLeft(8, '0');
                Cityinit = dns.Tables[0].Rows[0]["CityInitial"].ToString();
                txtCustomerID.Text = Cityinit + CustomerID;
            }

            authority = AS.CheckAuthorityByStaffID_Service(staffInfo.StaffID, moduleID);
            if (authority == 0)
            {
                Response.Redirect("../Error/404.aspx");
            }
            if (authority == 3)
            {
                BtnBatchInput.Visible = false;
            }
            if (authority == 4)
            {
                BtnBatchInput.Visible = true;
            }
            
            if (!IsPostBack)
            {
                if (Session["CustomerID"] == null)
                {
                    BindProvince();
                    BindCity();

                }
               
                //GetCustomerInformation();
                if (Session["staffID"] != null)
                staffInfo.StaffID=int.Parse(Session["staffID"].ToString());
                DataSet dps = new DataSet();
                dps=stafs.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                txtImportingPeople.Text = dps.Tables[0].Rows[0]["StaffName"].ToString();
                

            }
            
        }



        #region   省份名称数据绑定
        /// <summary>
        /// 省份名称数据绑定
        /// </summary>
        protected void BindProvince()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.DDCProvince.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes;
                XmlNode nodeCity = doc.DocumentElement.SelectSingleNode(@"Province/City[@Name='" + this.City + "']");
                foreach (XmlNode node in nodes)
                {
                    this.DDCProvince.Items.Add(node.Attributes["Name"].Value);
                    int n = this.DDCProvince.Items.Count - 1;
                    if (nodeCity != null && node == nodeCity.ParentNode)
                        this.DDCProvince.SelectedIndex = n;
                }
                //.SelectedItem.Text;
                //txtCurrentCity.Text = this.ddlCity.SelectedValue;
                BindCity();

            }
        }
        #endregion


        #region 城市名称数据绑定
        /// <summary>
        /// 城市名称数据绑定
        /// </summary>
        protected void BindCity()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.DDCCity.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes[this.DDCProvince.SelectedIndex].ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    this.DDCCity.Items.Add(node.Attributes["Name"].Value);
                    int n = this.DDCCity.Items.Count - 1;
                    if (node.Attributes["Name"].Value == this.City)
                    {
                        this.DDCCity.SelectedIndex = n;
                    }
                }
                if (this.DDCCity.SelectedIndex == -1)
                    this.DDCCity.SelectedIndex = 0;
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
        protected void DDCProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();//绑定城市数据
        }
        #endregion

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {


            if ((DDCustomerFrom.SelectedItem.Value == "2" || DDCustomerFrom.SelectedItem.Value == "7" || DDCustomerFrom.SelectedItem.Value == "8") && txtReference.Text.Trim() == "")
            {
                CVReference.IsValid = false;
                return;
            }
            if (DDCustomerFrom.SelectedItem.Value == "1" && txtFromData.Text.Trim() == "")
            {
                CVFromData.IsValid = false;
                return;
            }
            CIF.CustomerName = txtCustomerName.Text.Trim();
            CIF.Telphone = txtTelPhone.Text.Trim();
            CIF.CProvince = DDCProvince.SelectedItem.Value.Trim();
            CIF.CCity = DDCCity.SelectedItem.Value.Trim();
            CIF.EnglishName = txtEnglishName.Text.Trim();
            CIF.Birthday = txtBirthday.Text.Trim();
            if (txtBirthday.Text.Trim() != null && txtBirthday.Text.Trim() != "")
            {
                Age = DateTime.Now.Year - Convert.ToDateTime(txtBirthday.Text.Trim()).Year + 1;
                if (Age <= 0)
                {
                    Response.Write("<script>alert('年龄有误！')</script>");
                    return;
                }
                CIF.Age = Age;
            }

            CIF.Sex = int.Parse(DDSex.SelectedItem.Value);
            CIF.CQQ = txtCQQ.Text.Trim();
            CIF.Phone = txtPhone.Text.Trim();
            CIF.BackUpTel = txtBackUpTel.Text.Trim();
            CIF.CityInitial = GetPYString(DDCCity.SelectedItem.Text).ToUpper();

            CIF.ProfessionName = txtProfessionName.Text.Trim();
            CIF.Cemail = txtCemail.Text.Trim();
            CIF.CAddress = txtCAddress.Text.Trim();
            CIF.OtherContact = txtOtherContact.Text.Trim();
            CIF.OtherContactPhone = txtOtherContactPhone.Text.Trim();
            CIF.Policymaker = txtPolicymaker.Text.Trim();
            CIF.PolicymakerName = txtPolicymakerName.Text.Trim();
            CIF.CustomerClass = int.Parse(DDCustomerClass.SelectedItem.Value.Trim());
            CIF.DrainTowards = int.Parse(DDDrainTowards.SelectedItem.Value.Trim());
            CIF.Sname = txtSname.Text.Trim();
            CIF.Grade = txtGrade.Text.Trim();
            
            CIF.CustomerImportance = int.Parse(DDCustomerImportance.SelectedItem.Value.Trim());
           
            CIF.CustomerFrom = int.Parse(DDCustomerFrom.SelectedItem.Value.Trim());
            CIF.Reference = txtReference.Text.Trim();
            CIF.FromData = txtFromData.Text.Trim();
            CIF.ReferenceRemark = txtReferenceRemark.Text.Trim();
            CIF.ImportingPeople = txtImportingPeople.Text.Trim();
            CIF.ImportingDate = DateTime.Now;
            CIF.Remark = txtRemark.Text.Trim();
            ITA.IntentionCountry = txtIntentionCountry.Text.Trim();
            ITA.BetterWantpriTo = 0;
            ITA.IntentionCity = "";
            ITA.IntentionPhase = 0;
            ITA.IntentionProfession = "";
            ITA.IntentionSchool = "";
            ITA.Remark = "";
            

            ds = MCS.GetCustomerInfobyTelphone_Service(CIF.Telphone);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('" +ds.Tables[0].Rows[0]["CustomerName"].ToString()+"已经存在！')</script>");
                return;
            }
            int error=MCS.DoInsertBusiness(CIF, staffInfo.StaffID,ITA);
            if (error == 0)
            {
                Response.Write("<script>alert('操作成功！')</script>");
                
                dns = MCS.GetCustomerInfobyTelphone_Service(CIF.Telphone);
                CustomerID = dns.Tables[0].Rows[0]["CustomerID"].ToString();
                CustomerID = CustomerID.PadLeft(8, '0');
                Cityinit = dns.Tables[0].Rows[0]["CityInitial"].ToString();
                txtCustomerID.Text = Cityinit + CustomerID;
                txtImportingDate.Text = dns.Tables[0].Rows[0]["ImportingDate"].ToString();
                return;
            }
            else
            {
                Response.Write("<script>alert('操作失败！')</script>");
                return;
            }
            
            

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

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtEnglishName.Text = "";
            txtBirthday.Text = "";
            txtCQQ.Text = "";
            txtTelPhone.Text = "";
            txtPhone.Text = "";
            txtBackUpTel.Text = "";
            DDSex.SelectedIndex = 0;
            DDCProvince.SelectedIndex = 0;
            BindProvince();
            txtCityInitial.Text = "";
            txtProfessionName.Text = "";
            txtCemail.Text = "";
            txtCAddress.Text = "";
            txtOtherContact.Text = "";
            txtOtherContactPhone.Text = "";
            txtPolicymaker.Text = "";
            txtPolicymakerName.Text = "";
            DDCustomerClass.SelectedIndex = 0;
            DDDrainTowards.SelectedIndex = 0;
            txtSname.Text = "";
            txtGrade.Text = "";
            DDCustomerFrom.SelectedIndex = 0;
            txtReference.Text = "";
            txtFromData.Text = "";
            txtReference.Text = "";
            txtReferenceRemark.Text = "";
            txtImportingDate.Text = "";
            txtRemark.Text = "";
            DDCustomerImportance.SelectedIndex = 0;
            txtIntentionCountry.Text = "";
            

        }

        protected void BtnBatchInput_Click(object sender, EventArgs e)
        {
            Response.Redirect("BatchInputCustomerBaseInfo.aspx");
        }

    }
}
