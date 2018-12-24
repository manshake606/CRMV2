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
    public partial class ConsultantRule : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        MoPayment myMoPayment = new MoPayment();
        FinancialService myFinancialService=new FinancialService();
        StaffInfo staffInfo = new StaffInfo();
        string moduleID = ConfigurationManager.AppSettings["Financial"];
        int authority = 0;
        CRMControlService.AuthorityService AS = new AuthorityService();



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
                btnPayment.Enabled = false;
            }
            if (!IsPostBack)
            {
                BindGridView();
            }
            
        }
        #endregion

        #region 绑定GridView数据控件
        public void BindGridView()
        {
            ds = myFinancialService.SelectPayment();
            gvPayment.DataSource = ds.Tables[0].DefaultView;
            gvPayment.DataBind();
        }
        #endregion

        #region 查询按钮事件
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string paramPaymentID = this.txtContractID.Text.Trim();
            ds = myFinancialService.SelectPayment(paramPaymentID);
            gvPayment.DataSource = ds.Tables[0].DefaultView;
            gvPayment.DataBind();
        }
        #endregion

        #region Edit事件
        protected void gvPayment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPayment.EditIndex =e.NewEditIndex;
            BindGridView();
        }
        #endregion

        #region Update事件
        protected void gvPayment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int returnValue=0;
            myMoPayment.PaymentID =Convert.ToInt32(gvPayment.DataKeys[e.RowIndex].Value);
            myMoPayment.PaymentFees =Convert.ToDouble(((TextBox)gvPayment.Rows[e.RowIndex].FindControl("txtPaymentFees")).Text.Trim());
            myMoPayment.PaymentDate = ((TextBox)gvPayment.Rows[e.RowIndex].FindControl("txtPaymentDate")).Text.Trim();
            returnValue = myFinancialService.UpdatePayment(myMoPayment);
            if (returnValue > 0)
            {
                gvPayment.EditIndex = -1;
                BindGridView();
            }
        }
        #endregion

        #region Cancel事件
        protected void gvPayment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPayment.EditIndex = -1;
            BindGridView();
        }
        #endregion

        #region Add缴费记录方法
        protected void btnPayment_Click(object sender, EventArgs e)
        {
            int returnValue = 0;
            myMoPayment.PaymentFees = Convert.ToDouble(this.txtPaymentFees.Text.Trim());
            myMoPayment.PaymentDate = this.txtPaymentDate.Text;
            myMoPayment.ContractID = Session["ContractID"].ToString();
            myMoPayment.CustomerID =Convert.ToInt32(Session["MyCustomerID"].ToString());
            ds = myFinancialService.SelectFees(myMoPayment);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                myMoPayment.FeesTotal = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                myMoPayment.FeesTotal = Convert.ToDouble(this.txtFeesTotal.Text.Trim());
            }
            if ((ds.Tables[0].Rows[0][0].ToString()!="")&&(ds.Tables[0].Rows[0][1].ToString()!=""))
            {
                if ((Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()) + myMoPayment.PaymentFees) > Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString()))
                {
                    Response.Write("<script>alert('超过合同金额范围')</script>");
                    return;
                }
                else
                {
                   double result= myMoPayment.FeesTotal - ((Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()))+myMoPayment.PaymentFees);
                   Response.Write("<script>alert('余款须交"+result+"')</script>");
                }
            }
            returnValue = myFinancialService.InsertPayment(myMoPayment);
            if (returnValue > 0)
            {
               Response.Write("<script>alert('添加成功')</script>");
    
               BindGridView();
            }
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
