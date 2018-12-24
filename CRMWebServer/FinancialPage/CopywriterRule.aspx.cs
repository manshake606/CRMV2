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
    public partial class CopywriterRule : System.Web.UI.Page
    {
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

        }
    }
}
