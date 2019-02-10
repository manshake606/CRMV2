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
    public partial class BussinessFollowUP : System.Web.UI.Page
    {
        CustomerInfo custInfo = new CustomerInfo();
        StaffInfo staffInfo = new StaffInfo();
        ContactState CS = new ContactState();
        CRMControlService.CustomerService CSCS = new CustomerService();
        CRMControlService.ContactStateService css = new ContactStateService();
        CRMControlService.LogInfoService LogS = new LogInfoService();
        CRMControlService.StaffInfoService stafs = new StaffInfoService();
        CRMControlService.AuthorityService AS = new AuthorityService();
        string moduleID = ConfigurationManager.AppSettings["FollowUp"];
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
            //ButAdd.Attributes.Add("onclick", "ConfirmAdd()");
            //StaffInfoService StaffInfoS = new StaffInfoService();
            if (!Page.IsPostBack)
            {
                if (authority == 10)
                {
                    DataSet dssta = stafs.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                    DDListEmployeeName.DataSource = dssta;
                    DDListEmployeeName.DataTextField = "StaffName";
                    DDListEmployeeName.DataValueField = "StaffID";
                    DDListEmployeeName.DataBind();
                    DDListEmployeeName.SelectedValue = staffInfo.StaffID.ToString();
                    DDlistAddStaffName.DataSource = dssta;
                    DDlistAddStaffName.DataTextField = "StaffName";
                    DDlistAddStaffName.DataValueField = "StaffID";
                    DDlistAddStaffName.DataBind();
                    DDlistAddStaffName.SelectedIndex=-1;
                    DataSet dsc = css.GetCustomerNamebyStaffID_Service(int.Parse(DDListEmployeeName.SelectedValue));
                    DataSet dscu = css.GetCustomerNamebyStaffID_Service(int.Parse(DDlistAddStaffName.SelectedValue));
                    DDListCustomerName.DataSource = dsc.Tables[0];
                    DDlistAddCustomerName.DataSource = dscu.Tables[0];
                    if (dsc.Tables[0].Rows.Count == 0)
                    {
                        DDListCustomerName.Items.Add("无跟进客户");
                    }
                    else
                    {
                        DDListCustomerName.DataTextField = "CustomerName";
                        DDListCustomerName.DataValueField = "CustomerID";
                        DDListCustomerName.DataBind();
                        DDListCustomerName.Items.Add(new ListItem("所有跟进客户", "0"));
                        DDListCustomerName.SelectedValue = "0";
                    }

                    if (dscu.Tables[0].Rows.Count == 0)
                    {
                        DDlistAddCustomerName.Items.Add("无跟进客户");
                    }
                    else
                    {
                        DDlistAddCustomerName.DataTextField = "CustomerName";
                        DDlistAddCustomerName.DataValueField = "CustomerID";
                        DDlistAddCustomerName.DataBind();
                    }
                    txtStarttime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    txtCalendarEnd.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    ViewState["SortOrder"] = "CustomerID";
                    ViewState["OrderDire"] = "desc";
                    BindInit();
                    


                }
                if (authority == 11)
                {
                    DataSet dsSt = stafs.GetStaffNamebyDirectlyID_Service(staffInfo.StaffID);
                    DDListEmployeeName.DataSource = dsSt;
                    DDListEmployeeName.DataTextField = "StaffName";
                    DDListEmployeeName.DataValueField = "StaffID";
                    DDListEmployeeName.DataBind();
                    DDListEmployeeName.Items.Add(new ListItem("所有下属顾问", "0"));
                    DDListEmployeeName.SelectedValue = "0";
                    DDlistAddStaffName.DataSource = dsSt;
                    DDlistAddStaffName.DataTextField = "StaffName";
                    DDlistAddStaffName.DataValueField = "StaffID";
                    DDlistAddStaffName.DataBind();
                    DDlistAddStaffName.SelectedIndex = 0;
                    DataSet dsc = css.GetCustomerNamebyStaffID_Service(int.Parse(DDListEmployeeName.SelectedValue));
                    DataSet dscu = new DataSet();
                    if (DDlistAddStaffName.SelectedValue == null || DDlistAddStaffName.SelectedValue == "")
                    {
                        dscu = css.GetCustomerNamebyStaffID_Service(0);
                    }
                    else
                    {
                        dscu = css.GetCustomerNamebyStaffID_Service(int.Parse(DDlistAddStaffName.SelectedValue));
                    }
                    DDListCustomerName.DataSource = dsc.Tables[0];
                    DDlistAddCustomerName.DataSource = dscu.Tables[0];
                    if (dsc.Tables[0].Rows.Count == 0)
                    {
                        DDListCustomerName.Items.Add("无跟进客户");
                    }
                    else
                    {
                        DDListCustomerName.DataTextField = "CustomerName";
                        DDListCustomerName.DataValueField = "CustomerID";
                        DDListCustomerName.DataBind();
                        DDListCustomerName.Items.Add(new ListItem("所有跟进客户", "0"));
                        DDListCustomerName.SelectedValue = "0";
                    }

                    if (dscu.Tables[0].Rows.Count == 0)
                    {
                        DDlistAddCustomerName.Items.Add("无跟进客户");
                    }
                    else
                    {
                        DDlistAddCustomerName.DataTextField = "CustomerName";
                        DDlistAddCustomerName.DataValueField = "CustomerID";
                        DDlistAddCustomerName.DataBind();

                    }

                    txtStarttime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    txtCalendarEnd.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    ViewState["SortOrder"] = "CustomerID";
                    ViewState["OrderDire"] = "desc";
                    BindInit();
                    BindCount();
                }
            }

        }

        protected void ButSearch_Click(object sender, EventArgs e)
        {
            BindInit();
            if (authority == 11)
            {
                BindCount();
            }
        }


        protected void BindCount()
        {
            GVCount.DataSource = css.GetContactCount_Server(txtStarttime.Text, txtCalendarEnd.Text, Int32.Parse(HttpContext.Current.Session["staffID"].ToString()));
            GVCount.DataBind();
        }

        protected void BindInit()
        {
            if (DDListCustomerName.SelectedItem.Text == "无跟进客户" || DDListCustomerName.SelectedValue == "0")
            {
                custInfo.CustomerID = 0;
            }
            else
            {
                custInfo.CustomerID = Int32.Parse(DDListCustomerName.SelectedValue);
            }
            if (DDListCustomerName.SelectedItem.Text == "所有下属顾问" || DDListEmployeeName.SelectedValue == "0")
            {
                staffInfo.StaffID = 0;
            }
            else
            {
                staffInfo.StaffID = Int32.Parse(DDListEmployeeName.SelectedValue);
            }
            DataSet ds = css.GetContactStateInfo_Service(custInfo.CustomerID, staffInfo.StaffID, txtStarttime.Text, txtCalendarEnd.Text);
            DataView myView = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                myView.Sort = sort;
                gv_showfollowupInfo.DataSource = myView;
                gv_showfollowupInfo.DataBind();
            }
            else
            {
                gv_showfollowupInfo.DataSource = myView;
                gv_showfollowupInfo.DataBind();
            }
        }

        protected void gv_showfollowupInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_showfollowupInfo.EditIndex = e.NewEditIndex;
            BindInit();

        }

        protected void gv_showfollowupInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_showfollowupInfo.EditIndex = -1;
            BindInit();

        }

        protected void gv_showfollowupInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string date = ((TextBox)gv_showfollowupInfo.Rows[e.RowIndex].FindControl("TxtCSDate")).Text.Trim().ToString();
            DateTime dtime = new DateTime();
            try
            {
                dtime = Convert.ToDateTime(date);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('日期格式错误!标准格式YYYY/MM/DD')</script>");
                return;
            }


            CS.CSID = Convert.ToInt32(gv_showfollowupInfo.DataKeys[e.RowIndex].Values[0]);
            custInfo.CustomerID = Int32.Parse(((DropDownList)gv_showfollowupInfo.Rows[e.RowIndex].FindControl("DDlistCName")).SelectedItem.Value);
            CS.CSContent = ((TextBox)gv_showfollowupInfo.Rows[e.RowIndex].FindControl("TxtCSContent")).Text;
            if (CS.CSContent.Length > 200)
            {
                return;
            }
            CS.Remark = ((TextBox)gv_showfollowupInfo.Rows[e.RowIndex].FindControl("TxtRemark")).Text;
            if (CS.Remark.Length > 80)
            {
                return;
            }
            CS.StaffID = Int32.Parse(((DropDownList)gv_showfollowupInfo.Rows[e.RowIndex].FindControl("DDlistStaffName")).SelectedItem.Value);
            CRMControlService.ContactStateService CRMCS = new ContactStateService();
            CRMCS.UpdateContactStateInfo_Service(CS.CSID, custInfo.CustomerID, CS.StaffID, CS.CSContent, date);
            gv_showfollowupInfo.EditIndex = -1;
            BindInit();


        }

        protected void gv_showfollowupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Cells[0].Text = ((Label)e.Row.FindControl("LabCityInitial")).Text + e.Row.Cells[0].Text.PadLeft(8, '0');
            //}


            if ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
            {
                DataSet dsf = new DataSet();

                int hidstaffid = Convert.ToInt32(((HiddenField)e.Row.FindControl("HidStafftxt")).Value);
                int hidcustomerID = Convert.ToInt32(((HiddenField)e.Row.FindControl("hidtxt")).Value);
                dsf = stafs.GetStaffNamebyStaffID_Service(hidstaffid);
                DropDownList drps = (DropDownList)e.Row.FindControl("DDlistStaffName");
                drps.DataSource = dsf.Tables[0];
                drps.DataTextField = "StaffName";
                drps.DataValueField = "StaffID";
                drps.DataBind();
                drps.Enabled = false;

                DataSet dss = new DataSet();
                dss = CSCS.GetCustomerNamebyCustomerID(hidcustomerID);
                DropDownList drp = (DropDownList)e.Row.FindControl("DDlistCName");
                drp.DataSource = dss.Tables[0];
                drp.DataTextField = "CustomerName";
                drp.DataValueField = "CustomerID";
                drp.DataBind();
                drp.Enabled = false;
            }
        }

        protected void DDListEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDListCustomerName.Items.Clear();
            DataSet dsc = css.GetCustomerNamebyStaffID_Service(int.Parse(DDListEmployeeName.SelectedValue));
            DDListCustomerName.DataSource = dsc.Tables[0];
            if (dsc.Tables[0].Rows.Count == 0)
            {
                DDListCustomerName.Items.Add("无跟进客户");
            }
            else
            {

                DDListCustomerName.DataTextField = "CustomerName";
                DDListCustomerName.DataValueField = "CustomerID";
                DDListCustomerName.DataBind();
                DDListCustomerName.Items.Add(new ListItem("所有跟进客户", "0"));
                DDListCustomerName.SelectedValue = "0";
            }
        }









        protected void DDlistAddStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDlistAddCustomerName.Items.Clear();
            DataSet dsc = css.GetCustomerNamebyStaffID_Service(int.Parse(DDlistAddStaffName.SelectedValue));
            DDlistAddCustomerName.DataSource = dsc.Tables[0];
            if (dsc.Tables[0].Rows.Count == 0)
            {
                DDlistAddCustomerName.Items.Add("无跟进客户");
            }
            else
            {

                DDlistAddCustomerName.DataTextField = "CustomerName";
                DDlistAddCustomerName.DataValueField = "CustomerID";
                DDlistAddCustomerName.DataBind();
            }
        }

        

        protected void gv_showfollowupInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv_showfollowupInfo = (GridView)sender;
            if (e.NewPageIndex < 0)
            {
                TextBox pageNum = (TextBox)gv_showfollowupInfo.BottomPagerRow.FindControl("txtNewPageIndex");
                int Pa = int.Parse(pageNum.Text);
                if (Pa <= 0)
                {
                    gv_showfollowupInfo.PageIndex = 0;
                }
                else
                { gv_showfollowupInfo.PageIndex = Pa - 1; }
            }
            else
            {
                gv_showfollowupInfo.PageIndex = e.NewPageIndex;
            }
            BindInit();
        }

        protected void ButAdd_Click(object sender, EventArgs e)
        {

        }

        protected void GVCount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == null || e.Row.Cells[1].Text == "" || e.Row.Cells[1].Text=="&nbsp;")
                e.Row.Cells[1].Text = "0";
            }
        }

        protected void gv_showfollowupInfo_Sorting(object sender, GridViewSortEventArgs e)
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
            BindInit();
        }




    }
}
