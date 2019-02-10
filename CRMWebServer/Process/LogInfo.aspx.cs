using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMControlService;
using ModelService;
using System.Data;
using System.Configuration;

namespace CRMWebServer.Process
{
    public partial class LogInfo : System.Web.UI.Page
    {
        CustomerInfo custInfo = new CustomerInfo();
        CRMControlService.LogInfoService LogS = new LogInfoService();
        StaffInfo staffInfo = new StaffInfo();
        string moduleID = ConfigurationManager.AppSettings["LogInfo"];
        CRMControlService.AuthorityService AS = new AuthorityService();
        int authority = 0;

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
            
        }

        protected void ButSearch_Click(object sender, EventArgs e)
        {
            string strtxt = txtCustomerID.Text.Trim();
            if (txtCustomerID.Text.Length == 0)
            {
                CVCustomerID.IsValid = false;
                CVCustomerID.ErrorMessage = "编号不能为空";
                return;
            }

            string CustomerID = strtxt;
            int CSID = 0;
            try
            {
                CSID = int.Parse(CustomerID);
            }
            catch
            {
                CVCustomerID.IsValid = false;
                CVCustomerID.ErrorMessage = "编号输入错误";
                return;
            }
            //string City = strtxt.Substring(0, strtxt.Length - 8).ToUpper();
            DataSet ds = LogS.GetCustomerInfobyIDCity_Service(CSID);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                CVCustomerID.IsValid = false;
                CVCustomerID.ErrorMessage = "不存在此人";
                return;
            }
            DataSet dslog = LogS.SearchLogByID_Service(CSID);
            gvLogInfo.DataSource = dslog;
            gvLogInfo.DataBind();
        }

        protected void gvLogInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[3].Text == "0")
                {
                    e.Row.Cells[3].Text = "新导入";
                }
                else if (e.Row.Cells[3].Text == "1")
                {
                    e.Row.Cells[3].Text = "已指派顾问";
                }
                else if (e.Row.Cells[3].Text == "2")
                {
                    e.Row.Cells[3].Text = "已指派文案";
                }
                else if (e.Row.Cells[3].Text == "3")
                {
                    e.Row.Cells[3].Text = "文案搁置";
                }
                else if (e.Row.Cells[3].Text == "4")
                {
                    e.Row.Cells[3].Text = "案件归档";
                }
                else if (e.Row.Cells[3].Text == "5")
                {
                    e.Row.Cells[3].Text = "案件退案";
                }
            }
        }
    }
}
