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

namespace CRMWebServer
{
    public partial class InputCustomer : System.Web.UI.Page
    {
        public string City = "城市";
        int customerID = 0;
        int rowsCount = 0;

        #region 页面载入数据
        protected void Page_Load(object sender, EventArgs e)
        {
            //DropDownList 数据绑定
            if (!IsPostBack)
            {
                BindProvince();
                BindCity();
                //GetCustomerInformation();
            }

        }
        #endregion
        
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

        #region 判断电话号码是数字不为空
        protected void CheckTel( object sender, EventArgs e)
        {
            string tel = txtTelphone.Text.Trim ();
            if (tel != "" && tel[0] != 0)
            {
                for (int i = 0; i < tel.Length - 1; i++)
                {
                    if (!(tel[i] >= 0 && tel[i] <= 9))
                        Response.Write("<script language = 'javascript'> alert (' 请输入正确的手机号码');</script>");
                }
            }
            else Response.Write("<script language = 'javascript'> alert ('请输入手机号码');</script>");
        }
        #endregion
               
        #region 提交Submit
        protected void ButtonSubmit(object sender, EventArgs e)
        {
            
        }
        #endregion

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

            string tel = txtTelphone.Text.Trim();
            if (tel != "" && tel[0] != 0)
            {
                args.IsValid  = true;
                for (int i = 0; i < tel.Length; i++)
                {
                    if (tel[i] >= 0 && tel[i] <= 9)
                        args.IsValid = false; break;
                }

            }
            else args.IsValid = false;
            //if (tel != "" && tel[0] != 0)
            //{
            //    for (int i = 0; i < tel.Length - 1; i++)
            //    {
            //        if (!(tel[i] >= 0 && tel[i] <= 9))
            //            Response.Write("<script language = 'javascript'> alert (' 请输入正确的手机号码');</script>");
            //    }
            //}
            //else Response.Write("<script language = 'javascript'> alert ('请输入手机号码');</script>");
        }

    }
}
