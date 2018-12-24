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
    public partial class admin_top : System.Web.UI.Page
    {
        StaffInfo staffInfo = new StaffInfo();
        StaffInfoService SIS = new StaffInfoService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["staffID"] != null)
            {
                staffInfo.StaffID = Int32.Parse(HttpContext.Current.Session["staffID"].ToString());
            }
            else
            {
                Response.Write("<script>alert('长时间未登陆，请重新登陆')</script>");
                Response.Redirect("NoLogin.aspx");
            }
            DataSet ds = SIS.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
            StaffName.Text =ds.Tables[0].Rows[0]["StaffName"].ToString() ;
            StaffName.Text += "您好!! ";
            Labdate.Text="今天是"+DateTime.Now.ToLongDateString().ToString();
            
        }

        protected void ImageButtonLogout_Click(object sender, ImageClickEventArgs e)
        {

                Session["staffID"] = null;
                Session["positionID"] = null;
                
        }

        protected void ImageButtonBacktoMenu_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("right.aspx");
        }
    }
}
