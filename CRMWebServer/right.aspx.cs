using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using CRMDBService;
using ModelService;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using CRMControlService;

namespace CRMWebServer
{
    public partial class right : System.Web.UI.Page
    {
        StaffInfo staffInfo = new StaffInfo();
        DataSet DSFamily = new DataSet();
        DataSet DSFollowUP = new DataSet();
        DataSet DSCustomerFollowUP = new DataSet();
        CRMControlService.ReminderService RS = new ReminderService();
        int FamilyCount = 0;
        int FollowupCount = 0;
        int CustomerFollowUP = 0;
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

            DSFamily = RS.GetFamilyRemindInfo_Service(staffInfo.StaffID);
            if(DSFamily.Tables[0].Rows.Count>0)
            {
                FamilyCount = DSFamily.Tables[0].Rows.Count;
                LBFamily.ForeColor = System.Drawing.Color.Red;
            }
            LBFamily.Text = FamilyCount.ToString();



            DSFollowUP = RS.GetFollowupRemindInfobyStaffID(staffInfo.StaffID);
            if (DSFollowUP.Tables[0].Rows.Count > 0)
            {
                FollowupCount = DSFollowUP.Tables[0].Rows.Count;
                LBFollow.ForeColor = System.Drawing.Color.Red; 
            }
            LBFollow.Text = FollowupCount.ToString();

            DSCustomerFollowUP = RS.GetCustomCurrentRemindInfobyStaffID_Service(staffInfo.StaffID);
            if (DSCustomerFollowUP.Tables[0].Rows.Count > 0)
            {
                CustomerFollowUP = DSCustomerFollowUP.Tables[0].Rows.Count;
                LBCustomRemind.ForeColor = System.Drawing.Color.Red;
            }
            LBCustomRemind.Text = CustomerFollowUP.ToString();

            if (!IsPostBack)
            {
                if (DSFamily.Tables[0].Rows.Count > 0 || DSFollowUP.Tables[0].Rows.Count > 0 || DSCustomerFollowUP.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script>alert('您有新的提醒请查看！')</script>");
                }
            }
            

        }

        protected void LBFamily_Click(object sender, EventArgs e)
        {
            Session["staffID"]=staffInfo.StaffID;
            Server.Transfer("FamilyRemind.aspx");
        }

        protected void LBFollow_Click(object sender, EventArgs e)
        {
            Session["staffID"] = staffInfo.StaffID;
            Server.Transfer("RemindFollowUp.aspx");
        }

        protected void LBCustomRemind_Click(object sender, EventArgs e)
        {
            Session["staffID"] = staffInfo.StaffID;
            Server.Transfer("Remind\\CustomRemind.aspx");
        }

    }
}
