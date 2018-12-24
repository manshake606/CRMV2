using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using CRMControlService;
using ModelService;
using System.Configuration;

namespace CRMWebServer.Document
{
    public partial class SearchDocument : System.Web.UI.Page
    {
        CRMControlService.DocumentInfoService DocInfoSv = new CRMControlService.DocumentInfoService();
        CRMControlService.LogInfoService LogSv = new LogInfoService();
        CRMControlService.CustomerService CSv = new CustomerService();
        CRMControlService.FinancialService FSv = new FinancialService();
        CRMControlService.StaffInfoService SISv = new StaffInfoService();
        CRMControlService.AuthorityService AS = new AuthorityService();

        CRMWebServer.FinancialPage.Payment PM = new CRMWebServer.FinancialPage.Payment();

        ModelService.FilesInfo filesInfo = new ModelService.FilesInfo();
        ModelService.StaffInfo SI = new StaffInfo();
        ModelService.CustomerInfo CI = new CustomerInfo();
        ModelService.StaffInfo staffInfo = new StaffInfo();
        string moduleID;
        DataSet dsGetDocInfo;
        DataSet dsDocumentName;
        DataSet PID;
        int PostID;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["staffID"] != null)
            {
                staffInfo.StaffID = Int32.Parse(HttpContext.Current.Session["staffID"].ToString());
                moduleID = ConfigurationManager.AppSettings["Copywriter"];

                dsDocumentName = SISv.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                PID = SISv.GetStaffPIDByName_Service(dsDocumentName.Tables[0].Rows[0]["StaffName"].ToString());
                PostID = int.Parse(PID.Tables[0].Rows[0]["PostID"].ToString());

                try
                {
                    //判断该员工是否有权限删除已上传文档
                    if (AS.CheckAuthorityByStaffID_Service(staffInfo.StaffID, moduleID) == 6)
                    {
                        if (PostID == 2 || PostID == 3 || PostID == 4)
                        {
                            //加载指派给当前登录的文案还未归档的
                            DataSet dsGetDocInfo = DocInfoSv.GetDocInfoByStaffID_Service(staffInfo.StaffID);
                            ResetDataSet(dsGetDocInfo);
                            gvSearchResult.DataSource = dsGetDocInfo;
                            gvSearchResult.DataBind();
                        }
                        else
                        {
                            if (PostID == 1)
                            {
                                DataSet dsGetDocInfo = DocInfoSv.GetAllDocInfo_Service();
                                ResetDataSet(dsGetDocInfo);
                                gvSearchResult.DataSource = dsGetDocInfo;
                                gvSearchResult.DataBind();
                            }
                        }
                        gvSearchResult.Columns[13].Visible = true;
                    }
                    else
                    {
                        if (AS.CheckAuthorityByStaffID_Service(staffInfo.StaffID, moduleID) == 0)
                        {
                            Response.Redirect("../Error/404.aspx");
                        }
                        else
                        {
                            gvSearchResult.Columns[13].Visible = false;
                        }
                    }
                }
                catch (Exception exp)
                {
                    Response.Write(exp.Message);
                }
            }
            else
            {
                Response.Write("<script>alert('对不起，能还未登陆，或者长时间未操作，请重新登陆')</script>");
                //Response.Redirect("../Login.aspx");
                Response.Write("<script>window.top.location='../Nologin.aspx';</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStarttime.Text.Trim().ToString() != null && txtEndtime.Text.Trim().ToString() != null)
            {
                DateTime strStartTime = Convert.ToDateTime(txtStarttime.Text.Trim() + " 00:00:00.000");
                DateTime strEndTime = Convert.ToDateTime(txtEndtime.Text.Trim() + " 23:59:59.000");

                try
                { 
                    //文案搜索所有经过自己操作过的客户文案信息（包含正在进行的和已归档完毕的）
                    if (PostID == 2 || PostID == 3 || PostID == 4)
                    {
                        dsGetDocInfo = DocInfoSv.GetDocInfoByDate_Service(strStartTime, strEndTime, staffInfo.StaffID);
                    }
                    else
                    {
                        //经理可以查看到所有用户的文档信息和状态
                        if (PostID == 1)
                        {
                            dsGetDocInfo = DocInfoSv.GetDocInfoByDate_Service(strStartTime, strEndTime);
                        }
                        else
                        {
                            //顾问可以查看自己所指派过的客户文案信息
                            if (PostID == 6 || PostID == 7 || PostID == 8 || PostID == 9)
                            {
                                dsGetDocInfo = DocInfoSv.GetDocInfoByGW_Service(strStartTime, strEndTime, staffInfo.StaffID);
                            }
                        }
                    }

                    ResetDataSet(dsGetDocInfo);
                    gvSearchResult.DataSource = dsGetDocInfo;
                    gvSearchResult.DataBind();
                }
                catch (Exception exp)
                {
                    Response.Write(exp.Message);
                }
            }
            else
            {
                Response.Write("<script>alert('请输入查询时间段')</script>");
            }
        }

        //将已有Dataset转换成需要的Dataset
        public void ResetDataSet(DataSet OriginalDS)
        {
            try
            {
                OriginalDS.Tables[0].Columns.Add("ConsultantName", typeof(string));
                OriginalDS.Tables[0].Columns.Add("DocumentName", typeof(string));
                OriginalDS.Tables[0].Columns.Add("CustomerNewID", typeof(string));
                OriginalDS.Tables[0].Columns.Add("AssignNewStatus", typeof(string));

                for (int i = 0; i < OriginalDS.Tables[0].Rows.Count; i++)
                {
                    //该客户对应的顾问姓名
                    // DataSet dsGWName = LIS.GetAssignerNamebyCustomerIDFromCopywriter(CI.CustomerID);
                    DataSet dsGWName = LogSv.GetAssignerNamebyCustomerIDFromCopywriter(Convert.ToInt32(OriginalDS.Tables[0].Rows[i]["CustomerID"]));
                    OriginalDS.Tables[0].Rows[i]["ConsultantName"] = dsGWName.Tables[0].Rows[0]["StaffName"].ToString();

                    //该客户对应的文案姓名
                    DataSet dsDocumentName = SISv.GetStaffNamebyStaffID_Service(Convert.ToInt32(dsGWName.Tables[0].Rows[0]["GStaffID"]));
                    OriginalDS.Tables[0].Rows[i]["DocumentName"] = dsDocumentName.Tables[0].Rows[0]["StaffName"].ToString();

                    //通过客户ID获取他的合同编号
                    DataSet dsContractID = FSv.GetContractIDInfo(int.Parse(OriginalDS.Tables[0].Rows[i]["CustomerID"].ToString()));
                    filesInfo.FolderID = dsContractID.Tables[0].Rows[0]["ContractID"].ToString();

                    //把客户ID转换成WX00000001的格式显示
                    string ChangeFormat = OriginalDS.Tables[0].Rows[i]["CustomerID"].ToString().PadLeft(8, '0');
                    DataSet dsCustomerID = CSv.GetCustomerInformation(Convert.ToInt32(OriginalDS.Tables[0].Rows[i]["CustomerID"]));
                    string Address = dsCustomerID.Tables[0].Rows[0]["CCity"].ToString();
                    string FinalAdress = string.Empty;
                    string JXAddress = PM.GetPYString(Address);
                    foreach (char c in JXAddress)
                    {
                        FinalAdress += char.ToUpper(c);
                    }

                    OriginalDS.Tables[0].Rows[i]["CustomerNewID"] = FinalAdress + ChangeFormat;

                    switch (OriginalDS.Tables[0].Rows[i]["AssignStatus"].ToString())
                    {
                        case "2":
                            OriginalDS.Tables[0].Rows[i]["AssignNewStatus"] = "正在跟进";
                            break;

                        case "4":
                            OriginalDS.Tables[0].Rows[i]["AssignNewStatus"] = "归档完毕";
                            break;
                    }
                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }

        protected void gvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSearchResult.PageIndex = e.NewPageIndex;
            gvSearchResult.DataBind();
        }

        protected void gvSearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upload")
            {
                Session["CustomerID"] = null;
                string url = "../Document/UploadDocument.aspx?CustomerID=" + e.CommandArgument.ToString();
                Response.Redirect(url);
            }
        }
    }
}
