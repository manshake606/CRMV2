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

namespace CRMWebServer.Staff
{
    public partial class StaffAdd : System.Web.UI.Page
    {
        public string City = "城市";
        DataSet ds = new DataSet();
        StaffInfoService myStaffInfoService = new StaffInfoService();
        StaffInfo myStaffInfo = new StaffInfo();
        #region Load 事件
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProvince();
                BindCity();
                //BindDdlPost();
                BindDdlDirect();
                PostChange();
            }


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
            DataTable mydt = ds.Tables[0];
            //DataRow dr = mydt.NewRow();                     //强制向下拉列表框中插入一条记录 
            //dr["PostName"] = "";
            //dr["PostID"] = 0;
            //mydt.Rows.InsertAt(dr, 0);
            //mydt.AcceptChanges();
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
            dr["StaffName"] = "未定";
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

        #region 点击按钮触发添加员工信息事件
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int returnValue = 0;
            string str="";
            myStaffInfo.StaffName = this.txtStaffName.Text.Trim();
            myStaffInfo.Password = this.txtPwd1.Text.Trim();
            myStaffInfo.Birthday = this.txtBirthday.Text.Trim();
            myStaffInfo.StaffSex =Convert.ToInt32( this.ddlSex.SelectedValue);
            myStaffInfo.Phone = this.txtStaffPhone.Text.Trim();
            myStaffInfo.Email = this.txtStaffEmail.Text.Trim();
            myStaffInfo.PostID =Convert.ToInt32(this.ddlPostID.SelectedValue);
            myStaffInfo.DirectlyID =Convert.ToInt32(this.ddlDirectlyID.SelectedValue);
            myStaffInfo.EmployeeDate = this.txtEmployeeDate.Text.Trim();
            str=(chk1.Checked ? "1,":"")+(chk2.Checked?"2,":"")+(chk3.Checked? "3,":"")+(chk4.Checked?"4,":"")+(chk5.Checked?"5,":"")+(chk6.Checked?"6,":"")+(chk7.Checked?"7,":"")+(chk8.Checked?"8,":"")+(chk9.Checked?"9,":"")+(chk10.Checked?"10,":"")+(chk11.Checked?"11,":"")+(chk12.Checked?"12,":"")+(chk13.Checked?"13,":"")+(chk14.Checked?"14,":"")+(chk15.Checked?"15,":"")+(chk16.Checked?"16,":"")+(chk17.Checked?"17,":"");
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
            string paramLoginName=this.txtLoginName.Text.Trim();
            int judegeValue=JudgeLoginName(paramLoginName);
            if (judegeValue > 0)
            {
                Response.Write("<script>alert('登录名已存在')</script>");
                return;
            }
            else
            {
                returnValue = myStaffInfoService.InsertStaff(myStaffInfo);
                if (returnValue > 0)
                {
                    Response.Write("<script>alert('添加成功')</script>");
                }
            }
        }

        #endregion

        #region 触发该按钮返回到员工信息浏览页面 
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffInformations.aspx");
        }
        #endregion

        #region 默认给员工分配权限 
        protected void ddlPostID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostChange();
        }
        #endregion

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
                chk2.Checked = true;
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
                chk2.Checked = true;
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
            else
            {
                chk1.Checked = true;
                chk2.Checked = true;
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
