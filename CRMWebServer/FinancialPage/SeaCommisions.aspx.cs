using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CRMControlService;
using ModelService;
using System.Configuration;

namespace CRMWebServer.FinancialPage
{
    public partial class SeaCommisions : System.Web.UI.Page
    {
        SeaCommisionService mySeaCommisionService = new SeaCommisionService();
        DataSet ds = new DataSet();
        SeaCommision mySeaCommision = new SeaCommision();

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



            if (Session["ContractID"] != null && Session["MyCustomerID"] != null)
            {
                txtContract.Text = Session["ContractID"].ToString();
                txtCustomerID.Text = Session["MyCustomerID"].ToString();
            }
            else
            {
                btnAdd.Enabled = false;
            }
            if (!IsPostBack)
            {
                BindGridView();
            }

        }

        #region 绑定GridView数据控件
        public void BindGridView()
        {
            ds = mySeaCommisionService.SelectSeaCommision();
            gvSeaCommision.DataSource = ds.Tables[0].DefaultView;
            gvSeaCommision.DataBind();
        }
        #endregion

        #region 根据合同编号查询海佣金额记录
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string paramContractID = this.txtContractID.Text.Trim();
            if (this.txtContractID.Text == "" || this.txtContractID.Text == null)
            {
                BindGridView();
            }
            ds = mySeaCommisionService.SelectParam(paramContractID);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('查询结果为空 !')</script>");
            }
            gvSeaCommision.DataSource = ds.Tables[0].DefaultView;
            gvSeaCommision.DataBind();
            
        }
        #endregion

        #region 添加海佣缴费记录
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int returnValue = 0;
            string paramID = Session["ContractID"].ToString();
            mySeaCommision.SeaCommisionCallsDate = this.txtSeaCommisionCallsDate.Text.Trim();
            mySeaCommision.SeaCommisionActualAmount =Convert.ToDouble(this.txtSeaCommisionActualAmount.Text.Trim());
            mySeaCommision.SeaCommisionGetDate = this.txtSeaCommisionGetDate.Text.Trim();
            mySeaCommision.SeaCommisionTotalAmount =Convert.ToDouble(this.txtSeaCommisionTotalAmount.Text.Trim());
            mySeaCommision.ContractID = Session["ContractID"].ToString();
            mySeaCommision.CustomerID = Convert.ToInt32(Session["MyCustomerID"].ToString());
            ds = mySeaCommisionService.SelectByContractID(mySeaCommision);
            if (ds.Tables[0].Rows.Count > 0)
            {
                mySeaCommision.SeaCommisionTotalAmount = Convert.ToDouble(ds.Tables[0].Rows[0][1]);
                mySeaCommision.SeaCommisionLimit = Convert.ToInt32(ds.Tables[0].Rows[0][2]);
            }
            else
            {
                mySeaCommision.SeaCommisionTotalAmount = Convert.ToDouble(this.txtSeaCommisionTotalAmount.Text.Trim());
                mySeaCommision.SeaCommisionLimit = Convert.ToInt32(this.txtSeaCommisionLimit.Text.Trim());
            }
            returnValue = mySeaCommisionService.InsertSeaCommision(mySeaCommision);
            if (returnValue > 0)
            {
                Response.Write("<script>alert('添加成功 !')</script>");
            }
            BindGridView();
        }
        #endregion

        #region 返回合同页面
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Financial.aspx");
        }
        #endregion
    }
}
