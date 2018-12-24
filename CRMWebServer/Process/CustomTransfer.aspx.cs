using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using CRMControlService;
using ModelService;

namespace CRMWebServer.Process
{
    public partial class CustomTransfer : System.Web.UI.Page
    {
        StaffInfo staffInfo = new StaffInfo();
        CustomerInfo custInfo = new CustomerInfo();
        AssignState assignState = new AssignState();
        CRMControlService.AssignStateService ASS = new AssignStateService();
        ModelService.BindState BS = new BindState();
        CRMControlService.AuthorityService AS = new AuthorityService();
        CRMControlService.StaffInfoService stafs = new StaffInfoService();
        CRMControlService.LogInfoService LIS = new LogInfoService();
        CRMControlService.CustomerService CS = new CustomerService();


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
            if (!IsPostBack)
            {
                DataSet ds = stafs.GetStaffNamebyDirectlyID_Service(staffInfo.StaffID);
                DDlistGWName.DataSource = ds;
                DDlistGWName.DataTextField = "StaffName";
                DDlistGWName.DataValueField = "StaffID";
                DDlistGWName.DataBind();


                DDlistNewGW.DataSource = ds;
                DDlistNewGW.DataTextField = "StaffName";
                DDlistNewGW.DataValueField = "StaffID";
                DDlistNewGW.DataBind();
            }
        }

        protected void ButTrans_Click(object sender, EventArgs e)
        {
            int OldStaffID = int.Parse(DDlistGWName.SelectedValue);
            int newStaffID=int.Parse(DDlistNewGW.SelectedValue);
            DataSet DSCustomer = ASS.GetCustomerIDNamebyStaffID_Service(OldStaffID);
            int count = DSCustomer.Tables[0].Rows.Count;
            string ErrorCustomer = "";
            int errorcount = 0;
            for (int i = 0; i < count; i++)
            {

                int ErrorID = ASS.DoAssignBusiness(staffInfo.StaffID, newStaffID, 1, "", int.Parse(DSCustomer.Tables[0].Rows[i]["CustomerID"].ToString()), 9);
                if (ErrorID != 0)
                {
                    if (errorcount == 0)
                    {
                        ErrorCustomer += DSCustomer.Tables[0].Rows[i]["CustomerName"].ToString();
                        errorcount++;
                    }
                    else
                    {
                        ErrorCustomer = ErrorCustomer+","+DSCustomer.Tables[0].Rows[i]["CustomerName"].ToString();
                    }

                }
            }
            if (ErrorCustomer == "")
            {
                Response.Write("<script>alert('转移成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('"+ErrorCustomer+"转移失败')</script>");
            }
        }

        protected void DDlistNewGW_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
