using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMControlService;
using ModelService;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using System.Configuration;

namespace CRMWebServer
{
    public partial class _Default : System.Web.UI.Page
    {
        StaffInfo staffInfo = new StaffInfo();
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
        }
    }
}
