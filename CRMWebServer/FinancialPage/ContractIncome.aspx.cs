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
    public partial class ContractIncome : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DeductIncomeService myDeductIncomeService = new DeductIncomeService();
        ConsultantInCome myConsultantInCome = new ConsultantInCome();
        MoFinancial myMoFinancial = new MoFinancial();
        ConsultantRule myConsultantRule = new ConsultantRule();
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
            if (authority == 0)
            {
                Response.Redirect("../Error/404.aspx");
            }


            if (!IsPostBack)
            {
                BindGridView();
            }
            ddlPecentItem.DataSource = myDeductIncomeService.SelectItem();
            ddlPecentItem.DataTextField = "CommisionName";
            ddlPecentItem.DataValueField = "RateID";
            ddlPecentItem.DataBind();
        }

        #region 绑定GridView数据控件
        public void BindGridView()
        {
            ds = myDeductIncomeService.SelectInfo();
            gvConsultIncome.DataSource = ds.Tables[0].DefaultView;
            gvConsultIncome.DataBind();
        }
        #endregion

        #region 点击Edit时的事件

        protected void gvConsultIncome_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvConsultIncome.EditIndex = e.NewEditIndex;
            BindGridView();
        }
        #endregion

        #region 点击Update时的事件
        
        protected void gvConsultIncome_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int returnValue = 0;
            int paramID =Convert.ToInt32(this.gvConsultIncome.DataKeys[e.RowIndex].Value);
            string paramDate =((TextBox)gvConsultIncome.Rows[e.RowIndex].FindControl("txtDate")).Text.Trim();
            returnValue = myDeductIncomeService.UpdateInfo(paramID,paramDate);
            if (returnValue > 0)
            {
                Console.Write("<script>alter('更新成功')</script>");
            }
            gvConsultIncome.EditIndex = -1;
            BindGridView();
        }
        #endregion

        #region 点击取消时的控件
        protected void gvConsultIncome_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvConsultIncome.EditIndex = -1;
            BindGridView();
        }
        #endregion

        protected void btnConfirmAdd_Click(object sender, EventArgs e)
        {
            string paramDate = this.txtReleaseDate.Text.ToString();
        }
        #region 当选择下拉列表框时触发该事件
        protected void ddlPecentItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
