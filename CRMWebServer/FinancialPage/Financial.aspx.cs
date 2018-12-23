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
    public partial class Financial : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        MoFinancial myMoFinancial = new MoFinancial();//实例化Model层
        FinancialService myFinancialService = new FinancialService();//实例化Service层
        StaffInfoService myStaffInfoService = new StaffInfoService();
        StaffInfo staffInfo = new StaffInfo();
        string moduleID = ConfigurationManager.AppSettings["Financial"];
        int authority = 0;
        CRMControlService.AuthorityService AS = new AuthorityService();
        int StaffPostID = 0;

        #region Load 事件 
        /// <summary>
        /// 确定页面是否是首次加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["staffID"] != null)
            {
                staffInfo.StaffID = Int32.Parse(HttpContext.Current.Session["staffID"].ToString());
                 ds= myStaffInfoService.SelectPostID(staffInfo);
                 StaffPostID =Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
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
                if (StaffPostID == 1)
                {
                    BindGridview();
                }
            }

        }
        #endregion

        #region 绑定数据控件gridview
        /// <summary>
        /// 将所有数据绑定到gridview
        /// </summary>
        public void BindGridview()
        {
            string GetStartDate =DateTime.Now.Year+"-"+DateTime.Now.Month + "-" +1;
            string GetEndDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            ds = myFinancialService.SelectFinancialInfo(GetStartDate,GetEndDate);
            GVFinancial.DataSource = ds.Tables[0];
            GVFinancial.DataBind();
        }
        #endregion

        #region 点击Cancel时触发该事件
        /// <summary>
        /// 当点击取消时返回原始状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVFinancial_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVFinancial.EditIndex = -1;
            BindGridview();
        }
        #endregion

        #region 点击Edit的时候触发该事件
        /// <summary>
        /// 当点击Edit的时候将字段变成可编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVFinancial_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVFinancial.EditIndex = e.NewEditIndex;
            BindGridview();
            ((DropDownList)this.GVFinancial.Rows[e.NewEditIndex].FindControl("dropProxy")).SelectedValue =((HiddenField)this.GVFinancial.Rows[e.NewEditIndex].FindControl("hfldProxy")).Value;//当点击Edit时候自动加载下拉列表框中的值
            ((DropDownList)this.GVFinancial.Rows[e.NewEditIndex].FindControl("dropOutSourcing")).SelectedValue = ((HiddenField)this.GVFinancial.Rows[e.NewEditIndex].FindControl("hfldOutSourcing")).Value;
        }
        #endregion

        //public void JudgeDatetime(string strdate)
        //{
        //    DateTime Min = DateTime.MinValue;
        //    if (!DateTime.TryParseExact(strdate, "yyyy-mm-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Min))
        //    {
        //        Response.Write("<script>alert('日期格式不正确,正确格式xxxx-xx-xx!')</script>");
        //        return;
        //    }
            
        //}

        #region 点击Update时触发该事件
        /// <summary>
        /// 点击Update的时候更新已经修改的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVFinancial_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DateTime Min = DateTime.MinValue;
            myMoFinancial.ContractID = this.GVFinancial.DataKeys[e.RowIndex].Value.ToString();
            string str = (myMoFinancial.ContractID).Substring(0, 8);
            myMoFinancial.SignDate = ((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtSignDate")).Text.Trim();
            string date1 = myMoFinancial.SignDate;
            if (!DateTime.TryParseExact(date1, "yyyy-mm-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Min))
            {
                Response.Write("<script>alert('日期格式不正确,正确格式xxxx-xx-xx!')</script>");
                return;
            }
            myMoFinancial.EndDate = ((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtEndDate")).Text.Trim();
            string date2 = myMoFinancial.EndDate;
            DateTime dt1 = Convert.ToDateTime(date1);
            DateTime dt2 = Convert.ToDateTime(date2);
            string datenow = DateTime.Now.ToString();
            DateTime dt3 = Convert.ToDateTime(datenow);
            if (!DateTime.TryParseExact(date2, "yyyy-mm-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Min))
            {
                Response.Write("<script>alert('日期格式不正确,正确格式xxxx-xx-xx!')</script>");
                return;
            }
            if (DateTime.Compare(dt2,dt1) < 0 || DateTime.Compare(dt2,dt3)>0 || DateTime.Compare(dt1,dt3)>0)
            {
                Response.Write("<script>alert('签约日期和结案日期不能超过当前日期,或结案日期必须大于等于签约日期')</script>");
                return;
            }
            myMoFinancial.Proxy = Convert.ToInt32(((DropDownList)this.GVFinancial.Rows[e.RowIndex].FindControl("dropProxy")).SelectedValue);
            myMoFinancial.ProxyName = ((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtProxyName")).Text.Trim();
            myMoFinancial.RecommendPeople = ((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtRecommendPeople")).Text.Trim();
            myMoFinancial.ReferralFees = Convert.ToDouble(((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtReferralFees")).Text.Trim());
            myMoFinancial.ReferralFeesPayDate = ((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtReferralFeesPayDate")).Text.Trim();
            string date3 = myMoFinancial.ReferralFeesPayDate;
            if (!DateTime.TryParseExact(date3, "yyyy-mm-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Min))
            {
                Response.Write("<script>alert('日期格式不正确,正确格式xxxx-xx-xx!')</script>");
                return;
            }
            myMoFinancial.OutSourcing = Convert.ToInt32(((DropDownList)this.GVFinancial.Rows[e.RowIndex].FindControl("dropOutSourcing")).SelectedValue);
            myMoFinancial.OutSourcingPeople = ((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtOutSourcingPeople")).Text.Trim();
            myMoFinancial.OutSourcingFees = Convert.ToDouble(((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtOutSourcingFees")).Text.Trim());
            myMoFinancial.OutSourcingPayDate = ((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtOutSourcingPayDate")).Text.Trim();
            string date4 = myMoFinancial.OutSourcingPayDate;
            if (!DateTime.TryParseExact(date4, "yyyy-mm-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Min))
            {
                Response.Write("<script>alert('日期格式不正确,正确格式xxxx-xx-xx!')</script>");
                return;
            }
            myMoFinancial.OutSourcingDirections = ((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtOutSourcingDirections")).Text.Trim();
            myMoFinancial.OtherFees = Convert.ToDouble(((TextBox)this.GVFinancial.Rows[e.RowIndex].FindControl("txtOtherFees")).Text.Trim());
            myMoFinancial.CustomerID = Convert.ToInt32(str);
            int returnValue = myFinancialService.UpdateFinancialInfo(myMoFinancial);
            if (returnValue > 0)
            {
                Response.Write("<script>alert('更新成功')</script>");
                GVFinancial.EditIndex = -1;
                BindGridview();
            }
        }
        #endregion

        #region 根据条件查询客户签约合同信息
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtContractID.Text.ToString().Trim() == "" && this.txtSignDate.Text.Trim() == "" && this.txtLastTime.Text.Trim()=="" && this.txtEndDate.Text.Trim() == "" && this.txtOverTime.Text.Trim()=="")
            {
                ds = myFinancialService.SelectFinancialInfo();
                GVFinancial.DataSource = ds.Tables[0];
                GVFinancial.DataBind();
            }
            else
            {
                myMoFinancial.ContractID = this.txtContractID.Text.ToString().Trim();
                myMoFinancial.SignDate = this.txtSignDate.Text.ToString().Trim();
                string OverDate = this.txtOverTime.Text.ToString().Trim();
                myMoFinancial.EndDate = this.txtEndDate.Text.ToString().Trim();
                string LastDate = this.txtLastTime.Text.ToString().Trim();
                if (OverDate == "" && myMoFinancial.SignDate != "")
                {
                    OverDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }
                if (LastDate == "" && myMoFinancial.EndDate != "")
                {
                    LastDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }
                ds = myFinancialService.SelectInfo(myMoFinancial,OverDate,LastDate);
                GVFinancial.DataSource = ds.Tables[0].DefaultView;
                GVFinancial.DataBind();
            }
        }
        #endregion

        #region 跨页面传值
        protected void GVFinancial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Payment")
            {
                string paramID = e.CommandArgument.ToString();
                ds = myFinancialService.SelectFinancialInfo(paramID);
                Session["ContractID"] = paramID;
                Session["MyCustomerID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["CustomerID"]);
                Response.Redirect("Payment.aspx");
            }
            else if (e.CommandName == "PayFees")
            {
                string paramID = e.CommandArgument.ToString();
                ds = myFinancialService.SelectFinancialInfo(paramID);
                Session["ContractID"] = paramID;
                Session["MyCustomerID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["CustomerID"]);
                Response.Redirect("SeaCommisions.aspx");
            }
        }
        #endregion

        #region 实现分页功能 
        protected void GVFinancial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView GVFinancial = (GridView)sender;
            if (e.NewPageIndex < 0)
            {
                TextBox pageNum = (TextBox)GVFinancial.BottomPagerRow.FindControl("txtNewPageIndex");
                int Pa = int.Parse(pageNum.Text);
                if (Pa <= 0)
                {
                    GVFinancial.PageIndex = 0;
                }
                else
                { GVFinancial.PageIndex = Pa - 1; }
            }
            else
            {
                GVFinancial.PageIndex = e.NewPageIndex;
            }
            //判断是load页面时候的分页 还是查询数据后的分页
            if (this.txtContractID.Text.ToString().Trim() == "" && this.txtSignDate.Text.Trim() == "" && this.txtLastTime.Text.Trim() == "" && this.txtEndDate.Text.Trim() == "" && this.txtOverTime.Text.Trim() == "")
            {
                ds = myFinancialService.SelectFinancialInfo();
                GVFinancial.DataSource = ds.Tables[0];
                GVFinancial.DataBind();
            }
            else
            {
                myMoFinancial.ContractID = this.txtContractID.Text.ToString().Trim();
                myMoFinancial.SignDate = this.txtSignDate.Text.ToString().Trim();
                string OverDate = this.txtOverTime.Text.ToString().Trim();
                myMoFinancial.EndDate = this.txtEndDate.Text.ToString().Trim();
                string LastDate = this.txtLastTime.Text.ToString().Trim();
                ds = myFinancialService.SelectInfo(myMoFinancial, OverDate, LastDate);
                GVFinancial.DataSource = ds.Tables[0].DefaultView;
                GVFinancial.DataBind();
            }
        }
        #endregion
    }
}
