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

namespace CRMWebServer
{

    public partial class RemindFollowUp : System.Web.UI.Page
    {
        CustomerInfo custInfo = new CustomerInfo();
        CRMControlService.ReminderService RS = new ReminderService();
        StaffInfo staffInfo = new StaffInfo();
        DataSet DSFollowRemind = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["staffID"] != null)
            {
                staffInfo.StaffID = Int32.Parse(HttpContext.Current.Session["staffID"].ToString());
            }
            else
            {
                Response.Write("<script>alert('长时间未登陆，请重新登陆')</script>");
                Response.Write("<script>window.top.location='Nologin.aspx';</script>");
                return;
            }
            DSFollowRemind = RS.GetFollowupRemindDetailInfobyStaffID_Service(staffInfo.StaffID);
            gvFollowupRemind.DataSource = DSFollowRemind;
            gvFollowupRemind.DataBind();
        }

        protected void gvFollowupRemind_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = ((Label)e.Row.FindControl("LabCityInitial")).Text.ToUpper().Trim() + e.Row.Cells[0].Text.PadLeft(8, '0');
                if (e.Row.Cells[2].Text == "0")
                {
                    e.Row.Cells[2].Text = "未读";
                }
                else
                {
                    e.Row.Cells[2].Text = "已读";
                }
            }
        }

        protected void gvFollowupRemind_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int RIID = int.Parse(gvFollowupRemind.DataKeys[e.NewSelectedIndex].Value.ToString());
            RS.UpdateFollowupRemindDetailInfobyRIID(RIID);
            e.NewSelectedIndex = -1;
            DSFollowRemind = RS.GetFollowupRemindDetailInfobyStaffID_Service(staffInfo.StaffID);
            gvFollowupRemind.DataSource = DSFollowRemind;
            gvFollowupRemind.DataBind();
        }
    }
}
