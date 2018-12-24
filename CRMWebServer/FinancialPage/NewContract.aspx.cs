using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ModelService;
using CRMControlService;
using System.Configuration;

namespace CRMWebServer.FinancialPage
{
    public partial class Payment : System.Web.UI.Page
    {
        MoFinancial myMoFinancial = new MoFinancial();
        FinancialService myFinancialService = new FinancialService();
        CustomerService myCustomerService = new CustomerService();
        DataSet ds =null;
        StaffInfo staffInfo = new StaffInfo();
        string moduleID = ConfigurationManager.AppSettings["Financial"];
        int authority = 0;
        CRMControlService.AuthorityService AS = new AuthorityService();

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
            //if (authority == 0)
            //{
            //    Response.Redirect("../Error/404.aspx");
            //}

            if (!IsPostBack)
            {
 
            }
            this.txtSignDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        #region public string GetPYString(string str)  获取汉字的首字母

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

        #endregion

        #region 根据客户编号添加签约合同信息
        /// <summary>
        /// 添加合同信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            DataSet myds = new DataSet();
            int returnValue = 0;
            string FinalAdress=string.Empty;
            string GetCustomerID=Request.QueryString["CustomerID"].ToString();
            if (GetCustomerID =="")
            {
                return;
            }
            string ChangeFormat=GetCustomerID.PadLeft(8,'0');
            ds = myCustomerService.GetCustomerInformation(Convert.ToInt32(GetCustomerID));
            myds = myFinancialService.SelectByparamID(Convert.ToInt32(GetCustomerID));
            if (myds.Tables[0].Rows.Count >0)
            {
                Response.Write("<script language='JavaScript'>if(window.confirm('合同编号已存在!')){window.location.href='../Process/TaskAssign.aspx'} else{window.location.href='NewContract.aspx'};</script>");
                return;
            }
            string Address=ds.Tables[0].Rows[0]["CCity"].ToString();
            string JXAddress = GetPYString(Address);
            foreach (char c in JXAddress)
            {
                FinalAdress+= char.ToUpper(c);
            }
            string FinalContractID = ChangeFormat + FinalAdress + DateTime.Now.ToString("yyyyMMdd");
            myMoFinancial.ContractID=FinalContractID;
            myMoFinancial.SignDate =this.txtSignDate.Text.Trim();
            myMoFinancial.Proxy = Convert.ToInt32(this.ddlProxy.SelectedValue);
            myMoFinancial.ProxyName = this.txtProxyName.Text.Trim();
            myMoFinancial.RecommendPeople = this.txtRecommendPeople.Text.Trim();
            myMoFinancial.ReferralFees = Method(this.txtReferralFees.Text.Trim());
            myMoFinancial.ReferralFeesPayDate =this.txtReferralFeesPayDate.Text.Trim();
            myMoFinancial.OutSourcing = Convert.ToInt32(this.ddlOutSourcing.SelectedValue);
            myMoFinancial.OutSourcingPeople = this.txtOutSourcingPeople.Text.Trim();
            myMoFinancial.OutSourcingFees = Method(this.txtOutSourcingFees.Text.Trim());
            myMoFinancial.OutSourcingPayDate =this.txtOutSourcingPayDate.Text.Trim();
            myMoFinancial.OutSourcingDirections = this.txtOutSourcingDirections.Text.Trim();
            myMoFinancial.OtherFees = Method(this.txtOtherFees.Text.Trim());
            myMoFinancial.CustomerID = Convert.ToInt32(GetCustomerID);
            returnValue = myFinancialService.AddContractInfo(myMoFinancial);
            if (returnValue > 0)
            {
                Response.Write("<script>alert('添加成功!');window.location.href='Financial.aspx'</script>");
            }
        }
        #endregion

        #region 验证double类型数值为空的情况

        public double Method(string param)
        {
            if (param == "")
            {
                return 0.00;
            }
            else
            {
                return Convert.ToDouble(param);
            }
        }
        #endregion

        #region 单击按钮返回到合同页面
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Process/TaskAssign.aspx");
        }
        #endregion
    }
}
