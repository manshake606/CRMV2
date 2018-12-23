using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ModelService;
using CRMControlService;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

namespace CRMWebServer.Staff
{
    public partial class StaffUpdate : System.Web.UI.Page
    {
        public string City = "城市";      
        DataSet ds = new DataSet();
        StaffInfoService myStaffInfoService = new StaffInfoService();
        StaffInfo myStaffInfo = new StaffInfo();
        CRMControlService.AuthorityService AS = new AuthorityService();
        string moduleID = ConfigurationManager.AppSettings["StaffInfo"];
        StaffInfo staffInfo = new StaffInfo();
        int authority = 0;

        #region Load 事件
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
            if (!IsPostBack)
            {
                
                    BindProvince();
                    BindCity();
                    BindDdlDirect();
                   


                    LoadValue();
                    if (authority == 14)
                    {
                        ddlPostID.Enabled = false;
                        ddlDirectlyID.Enabled = false;
                        chk0.Enabled = false;
                        chk1.Enabled = false;
                        chk2.Enabled = false;
                        chk3.Enabled = false;
                        chk4.Enabled = false;
                        chk5.Enabled = false;
                        chk6.Enabled = false;
                        chk7.Enabled = false;
                        chk8.Enabled = false;
                        chk9.Enabled = false;
                        chk10.Enabled = false;
                        chk11.Enabled = false;
                        chk12.Enabled = false;
                        chk13.Enabled = false;
                        chk14.Enabled = false;
                        chk15.Enabled = false;
                        chk16.Enabled = false;
                        chk17.Enabled = false;
                    }
                    

                    //PostChange();
            }

            //BindDdlPost();
            
            
        }
        #endregion

        #region 加载页面显示需要更新的数值
        public void LoadValue()
        {
            string paramStr;
            this.txtStaffName.Text = Session["StaffName"].ToString();
            this.txtPwd1.Text = Session["Password"].ToString();
            this.txtPwd2.Text = txtPwd1.Text;
            this.txtBirthday.Text = Session["Birthday"].ToString();
            this.ddlSex.SelectedValue = Session["StaffSex"].ToString();
            this.txtStaffPhone.Text = Session["Phone"].ToString();
            this.txtStaffEmail.Text = Session["Email"].ToString();
            
            this.ddlPostID.SelectedIndex = int.Parse(Session["PostID"].ToString())-1;
            int j = 0;
            for (; j < ddlDirectlyID.Items.Count; j++)
            {
                if (ddlDirectlyID.Items[j].Value == Session["DirectlyID"].ToString())
                {

                    break;
                }
            }
            ddlDirectlyID.SelectedIndex = j;
            this.txtEmployeeDate.Text = Session["EmployeeDate"].ToString();
            paramStr = Session["Authority"].ToString();
            string[] Str = paramStr.Split(',');
            for (int i = 0; i < Str.Length; i++)   //选中默认checkBox的权限
            {
                switch (Convert.ToInt32(Str[i]))
                {
                    case 0: chk0.Checked = true; break;
                    case 1: chk1.Checked = true; break;
                    case 2: chk2.Checked = true; break;
                    case 3: chk3.Checked = true; break;
                    case 4: chk4.Checked = true; break;
                    case 5: chk5.Checked = true; break;
                    case 6: chk6.Checked = true; break;
                    case 7: chk7.Checked = true; break;
                    case 8: chk8.Checked = true; break;
                    case 9: chk9.Checked = true; break;
                    case 10: chk10.Checked = true; break;
                    case 11: chk11.Checked = true; break;
                    case 12: chk12.Checked = true; break;
                    case 13: chk13.Checked = true; break;
                    case 14: chk14.Checked = true; break;
                    case 15: chk15.Checked = true; break;
                    case 16: chk16.Checked = true; break;
                    case 17: chk17.Checked = true; break;
                }
            }
            this.DDListCProvince.SelectedItem.Text = Session["CompanyProvice"].ToString();
            this.DDListCCity.SelectedItem.Text = Session["CompanyAddress"].ToString();
            this.ddlLogin.SelectedValue = Session["Enable"].ToString();
            this.ddlProperty.SelectedItem.Text = Session["StaffProperty"].ToString();
            this.txtLoginName.Text = Session["LoginName"].ToString();
        }
        #endregion

        #region   省份名称数据绑定
        /// <summary>
        /// 省份名称数据绑定
        /// </summary>
        protected void BindProvince()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.DDListCProvince.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes;
                XmlNode nodeCity = doc.DocumentElement.SelectSingleNode(@"Province/City[@Name='" + this.City + "']");
                foreach (XmlNode node in nodes)
                {
                    this.DDListCProvince.Items.Add(node.Attributes["Name"].Value);
                    int n = this.DDListCProvince.Items.Count - 1;
                    if (nodeCity != null && node == nodeCity.ParentNode)
                        this.DDListCProvince.SelectedIndex = n;
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

        #region 城市名称数据绑定
        /// <summary>
        /// 城市名称数据绑定
        /// </summary>
        protected void BindCity()
        {
            string CurrentPath = this.Server.MapPath("/ProvinceCity/Province.xml");
            if (System.IO.File.Exists(CurrentPath))
            {
                this.DDListCCity.Items.Clear();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(CurrentPath);
                XmlNodeList nodes = doc.DocumentElement.ChildNodes[this.DDListCProvince.SelectedIndex].ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    this.DDListCCity.Items.Add(node.Attributes["Name"].Value);
                    int n = this.DDListCCity.Items.Count - 1;
                    if (node.Attributes["Name"].Value == this.City)
                    {
                        this.DDListCCity.SelectedIndex = n;
                    }
                }
                if (this.DDListCCity.SelectedIndex == -1)
                    this.DDListCCity.SelectedIndex = 0;
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
        protected void DDListCProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();//绑定城市数据
        }
        #endregion

        #region 绑定员工职位下拉列表框
        public void BindDdlPost()
        {
            ds = myStaffInfoService.SelectPost();
            ddlPostID.DataSource = ds.Tables[0].DefaultView;
            ddlPostID.DataTextField = "PostName";
            ddlPostID.DataValueField = "PostID";
            ddlPostID.DataBind();
        }
        #endregion

        #region 绑定直属上司的编号
        public void BindDdlDirect()
        {
            ds = myStaffInfoService.SelectDirect();
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["StaffID"] = 0;
            dr["StaffName"] = "";
            dt.Rows.InsertAt(dr, 0);
            dt.AcceptChanges();
            ddlDirectlyID.DataSource = ds.Tables[0].DefaultView;
            ddlDirectlyID.DataTextField = "StaffName";
            ddlDirectlyID.DataValueField = "StaffID";
            ddlDirectlyID.DataBind();

        }
        #endregion

        #region 判断该要添加员工的登录名是否存在
        public int JudgeLoginName(string paramValue)
        {
            ds = myStaffInfoService.SelectLoginName(paramValue);
            return ds.Tables[0].Rows.Count;
        }
        #endregion
        #region
        public string JudgeLogin(string paramValue)
        {
            ds = myStaffInfoService.SelectLoginName(paramValue);
            return ds.Tables[0].Rows[0][0].ToString();
        }
        #endregion

        #region 点击按钮触发更新员工信息事件
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int returnValue = 0;
            string str="";
            myStaffInfo.StaffID=Convert.ToInt32(Request.QueryString["paramID"]);
            //myStaffInfo.StaffID = Convert.ToInt32(Session["StaffID"].ToString());
            myStaffInfo.StaffName = this.txtStaffName.Text.Trim();
            myStaffInfo.Password = this.txtPwd1.Text.Trim();
            myStaffInfo.Birthday = this.txtBirthday.Text.Trim();
            myStaffInfo.StaffSex =Convert.ToInt32( this.ddlSex.SelectedValue);
            myStaffInfo.Phone = this.txtStaffPhone.Text.Trim();
            myStaffInfo.Email = this.txtStaffEmail.Text.Trim();
            myStaffInfo.PostID =Convert.ToInt32(this.ddlPostID.SelectedValue);
            myStaffInfo.DirectlyID =Convert.ToInt32(this.ddlDirectlyID.SelectedValue);
            myStaffInfo.EmployeeDate = this.txtEmployeeDate.Text.Trim();
            str=(chk0.Checked?"0":"")+(chk1.Checked ? "1,":"")+(chk2.Checked?"2,":"")+(chk3.Checked? "3,":"")+(chk4.Checked?"4,":"")+(chk5.Checked?"5,":"")+(chk6.Checked?"6,":"")+(chk7.Checked?"7,":"")+(chk8.Checked?"8,":"")+(chk9.Checked?"9,":"")+(chk10.Checked?"10,":"")+(chk11.Checked?"11,":"")+(chk12.Checked?"12,":"")+(chk13.Checked?"13,":"")+(chk14.Checked?"14,":"")+(chk15.Checked?"15,":"")+(chk16.Checked?"16,":"")+(chk17.Checked?"17,":"");
            string[] str2 = str.Split(',');
            for (int i = 0; i <str2.Length-1; i++)
			{
			 if(i==0)
             {
                 myStaffInfo.Authority += str2[i];
             }
             else
             {
                 myStaffInfo.Authority += "," + str2[i];
             }
			}
            myStaffInfo.CompanyProvice=this.DDListCProvince.SelectedItem.Text;
            myStaffInfo.CompanyAddress=this.DDListCCity.SelectedItem.Text;
            myStaffInfo.Enable=Convert.ToInt32(this.ddlLogin.SelectedValue);
            myStaffInfo.StaffProperty=this.ddlProperty.SelectedItem.Text;
            myStaffInfo.LoginName = this.txtLoginName.Text.Trim();
            string paramLoginName = this.txtLoginName.Text.Trim();
            int judegeValue = JudgeLoginName(paramLoginName);
            if (judegeValue > 0)
            {
                string SystemLoginName = JudgeLogin(paramLoginName);
                if (paramLoginName == Session["LoginName"].ToString())
                {
                    returnValue = myStaffInfoService.UpdateStaff(myStaffInfo);
                    if (returnValue > 0)
                    {
                        Response.Write("<script>alert('更新成功')</script>");
                        Response.Redirect("StaffInformations.aspx");
                    }
                }
                else if (paramLoginName == SystemLoginName)
                {
                    Response.Write("<script>alert('登录名已存在')</script>");
                    return;
                }
            }
            else
            {
                returnValue = myStaffInfoService.UpdateStaff(myStaffInfo);
                if (returnValue > 0)
                {
                    Response.Write("<script>alert('更新成功')</script>");
                    Response.Redirect("StaffInformations.aspx");
                }
            }
        }

        #endregion

        #region 返回到员工管理页面
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffInformations.aspx");
        }
        #endregion

        protected void ddlPostID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostChange();
        }

        public void PostChange()
        {
            int paramValue = Convert.ToInt32(ddlPostID.SelectedItem.Value.ToString());

            if (paramValue == 1)
            {
                chk1.Checked = true;
                chk2.Checked = true;
                chk3.Checked = true;
                chk4.Checked = true;
                chk5.Checked = true;
                chk6.Checked = true;
                chk7.Checked = true;
                chk8.Checked = true;
                chk9.Checked = true;
                chk10.Checked = true;
                chk11.Checked = true;
                chk12.Checked = true;
                chk13.Checked = true;
                chk14.Checked = true;
                chk15.Checked = true;
                chk16.Checked = true;
                chk17.Checked = true;
            }
            else if (paramValue == 6 || paramValue == 7 || paramValue == 8 || paramValue == 9)
            {

                chk1.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = true;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = true;
                chk9.Checked = false;
                chk10.Checked = true;
                chk11.Checked = false; ;
                chk12.Checked = false;
                chk13.Checked = false;
                chk14.Checked = true;
                chk15.Checked = false;
                chk16.Checked = true;
                chk17.Checked = false;
            }
            else if (paramValue == 2 || paramValue == 3 || paramValue == 4)
            {
                chk1.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = true;
                chk6.Checked = true;
                chk7.Checked = true;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false; ;
                chk12.Checked = false;
                chk13.Checked = false;
                chk14.Checked = true;
                chk15.Checked = false;
                chk16.Checked = true;
                chk17.Checked = false;
            }
            else if(paramValue==5)
            {
                chk1.Checked = true;
                chk2.Checked = false;
                chk3.Checked = true;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false; ;
                chk12.Checked = false;
                chk13.Checked = false;
                chk14.Checked = true;
                chk15.Checked = false;
                chk16.Checked = true;
                chk17.Checked = false;
            }
        }
    }
    
}
