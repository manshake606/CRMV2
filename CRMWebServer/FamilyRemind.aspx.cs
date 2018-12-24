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
    public partial class FamilyRemind : System.Web.UI.Page
    {
        CustomerInfo custInfo = new CustomerInfo();
        CRMControlService.ReminderService RS = new ReminderService();
        StaffInfo staffInfo = new StaffInfo();
        DataSet DSFamilyRemind = new DataSet();

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

            DSFamilyRemind = RS.GetFamilyRemindDetailInfobyStaffID_Service(staffInfo.StaffID);
            gvFamilyRemind.DataSource = DSFamilyRemind;
            gvFamilyRemind.DataBind();
            
        }

        protected void gvFamilyRemind_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int FRimderID = int.Parse(gvFamilyRemind.DataKeys[e.NewSelectedIndex].Value.ToString());
            RS.UpdateFamilyRemindIsreadbyFRemindID_Service(FRimderID);
            e.NewSelectedIndex = -1;
            DSFamilyRemind = RS.GetFamilyRemindDetailInfobyStaffID_Service(staffInfo.StaffID);
            gvFamilyRemind.DataSource = DSFamilyRemind;
            gvFamilyRemind.DataBind();
            
        }

        protected void gvFamilyRemind_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = ((Label)e.Row.FindControl("LabCityInitial")).Text.ToUpper().Trim() + e.Row.Cells[0].Text.PadLeft(8, '0');
                if (e.Row.Cells[5].Text == "0")
                {
                    e.Row.Cells[5].Text = "未读";
                }
                else
                {
                    e.Row.Cells[5].Text = "已读";
                }
            }
        }

        protected void gvFamilyRemind_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


       
            
        
    }
}
