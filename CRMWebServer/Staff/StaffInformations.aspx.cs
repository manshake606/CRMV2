using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ModelService;
using CRMControlService;
using System.Configuration;

namespace CRMWebServer.Staff
{
    public partial class StaffInformations : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        StaffInfoService myStaffInfoService = new StaffInfoService();
        StaffInfo myStaffInfo = new StaffInfo();
        CRMControlService.AuthorityService AS = new AuthorityService();
        string moduleID = ConfigurationManager.AppSettings["StaffInfo"];
        StaffInfo staffInfo = new StaffInfo();
        int authority = 0;
        #region Load 事件
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

            if (!IsPostBack)
            {
                if (authority == 14)
                {
                    BindGridViewSimple(staffInfo.StaffID);
                    btnSearch.Enabled = false;
                    btnStaffAdd.Enabled = false;
                }
                else
                {
                    ViewState["SortOrder"] = "StaffID";
                    ViewState["OrderDire"] = "desc";
                    BindGridView(0);
                }
            }
        }
        #endregion

        public void BindGridViewSimple(int StaffID)
        {
            ds = myStaffInfoService.SelectStaffInfoByID(StaffID);
            gvwStaff.DataSource = ds.Tables[0].DefaultView;
            gvwStaff.DataBind();
        }


        public void BindGridView(int Enable)
        {
            ds = myStaffInfoService.SelectAll(Enable);

            DataView myView = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                myView.Sort = sort;
                gvwStaff.DataSource = myView;
                gvwStaff.DataBind();
            }
            else
            {
                gvwStaff.DataSource = myView;
                gvwStaff.DataBind();
            }
        }

        protected void gvwStaff_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                int StaffID = Convert.ToInt32(e.CommandArgument.ToString());
                ds = myStaffInfoService.GetStaffAll(StaffID);
                //Session["StaffID"] = StaffID;
                Session["StaffName"] = ds.Tables[0].Rows[0][1].ToString();
                Session["Password"] = ds.Tables[0].Rows[0][2].ToString();
                Session["Birthday"] = ds.Tables[0].Rows[0][3].ToString();
                Session["StaffSex"] = Convert.ToInt32(ds.Tables[0].Rows[0][4]);
                Session["Phone"] = ds.Tables[0].Rows[0][5].ToString();
                Session["Email"] = ds.Tables[0].Rows[0][6].ToString();
                Session["PostID"] = Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
                Session["DirectlyID"] = Convert.ToInt32(ds.Tables[0].Rows[0][8].ToString());
                Session["EmployeeDate"] = ds.Tables[0].Rows[0][9].ToString();
                Session["Authority"] = ds.Tables[0].Rows[0][10].ToString();
                Session["CompanyAddress"] = ds.Tables[0].Rows[0][11].ToString();
                Session["Enable"] = Convert.ToInt32(ds.Tables[0].Rows[0][12].ToString());
                Session["CompanyProvice"] = ds.Tables[0].Rows[0][13].ToString();
                Session["StaffProperty"] = ds.Tables[0].Rows[0][14].ToString();
                Session["LoginName"] = ds.Tables[0].Rows[0][15].ToString();
                Response.Redirect("StaffUpdate.aspx?paramID=" + StaffID);
            }
        }
        #region 根据筛选条件查询员工信息
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtStaffID.Text == "")
            {
                if (txtStaffName.Text == "")
                {
                    if (Chb_ChooseAll.Checked == true)
                    {
                        BindGridView(1);
                    }
                    else
                    {
                        BindGridView(0);
                    }
                }
                else
                {
                    myStaffInfo.StaffName = this.txtStaffName.Text.Trim();
                    ds = myStaffInfoService.SelectParam(myStaffInfo);
                    this.gvwStaff.DataSource = ds.Tables[0].DefaultView;
                    this.gvwStaff.DataBind();
                }
            }
            else
            {
                myStaffInfo.StaffID = Convert.ToInt32(this.txtStaffID.Text.Trim());
                myStaffInfo.StaffName = this.txtStaffName.Text.Trim();
                ds = myStaffInfoService.SelectParamName(myStaffInfo);
                this.gvwStaff.DataSource = ds.Tables[0].DefaultView;
                this.gvwStaff.DataBind();
            }

        }
        #endregion

        #region 跳转到添加员工信息页面
        protected void btnStaffAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffAdd.aspx");
        }
        #endregion

        protected void gvwStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvwStaff = (GridView)sender;
            if (e.NewPageIndex < 0) 
            {
                TextBox pageNum = (TextBox)gvwStaff.BottomPagerRow.FindControl("txtNewPageIndex"); 
                int Pa = int.Parse(pageNum.Text); 
                if (Pa <= 0) 
                {
                    gvwStaff.PageIndex = 0; 
                } 
                else
                { gvwStaff.PageIndex = Pa - 1; }
            } 
            else 
            {
                gvwStaff.PageIndex = e.NewPageIndex; 
            }
            //gvwStaff.PageIndex = e.NewPageIndex;
            if (Chb_ChooseAll.Checked == true)
            {
                BindGridView(1);
            }
            else
            {
                BindGridView(0);
            }
        }

        protected void gvwStaff_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sPage = e.SortExpression;
            if (ViewState["SortOrder"].ToString() == sPage)
            {
                if (ViewState["OrderDire"].ToString() == "Desc")
                {
                    ViewState["OrderDire"] = "ASC";
                }
                else
                {
                    ViewState["OrderDire"] = "Desc";
                }
            }
            else
            {
                ViewState["SortOrder"] = e.SortExpression;
            }
            if (Chb_ChooseAll.Checked == true)
            {
                BindGridView(1);
            }
            else
            {
                BindGridView(0);
            }
        }
    }
}
