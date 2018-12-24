using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Configuration;
using System.IO;
using System.Data;
using CRMControlService;
using ModelService;

namespace CRMWebServer.Document
{
    public partial class DocumentList : System.Web.UI.Page
    {
        string filePath = ConfigurationManager.AppSettings["UploadFilePath"];
        string strCustomerID;
        ModelService.FilesInfo filesInfo = new ModelService.FilesInfo();
        StaffInfo staffInfo = new StaffInfo();

        CRMControlService.AuthorityService AS = new AuthorityService();
        CRMControlService.DocumentInfoService DocInfoSv = new DocumentInfoService();
        CRMControlService.CustomerService CSv = new CustomerService();
        CRMControlService.FinancialService FSv = new FinancialService();

        CRMWebServer.FinancialPage.Payment PM = new CRMWebServer.FinancialPage.Payment();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["staffID"] != null)
            {
                //if (HttpContext.Current.Session["CustomerID"] != null || Request.QueryString["CustomerID"] != null)
                //{
                //    if (HttpContext.Current.Session["CustomerID"] != null)
                //    {
                //        strCustomerID = HttpContext.Current.Session["CustomerID"].ToString();
                //    }
                //    else
                //    {
                //        strCustomerID = Request.QueryString["CustomerID"];
                //    }

                if (Request.QueryString["CustomerID"] != null)
                {
                    strCustomerID = Request.QueryString["CustomerID"];

                    staffInfo.StaffID = Int32.Parse(HttpContext.Current.Session["staffID"].ToString());
                    try
                    {
                        //判断该员工是否有权限删除已上传文档
                        string moduleID = ConfigurationManager.AppSettings["Copywriter"];
                        if (AS.CheckAuthorityByStaffID_Service(staffInfo.StaffID, moduleID) == 6)
                        {
                            gvFileList.Columns[3].Visible = true;
                        }
                        else
                        {
                            if (AS.CheckAuthorityByStaffID_Service(staffInfo.StaffID, moduleID) == 0)
                            {
                                Response.Redirect("../Error/404.aspx");
                            }
                            else
                            {
                                gvFileList.Columns[3].Visible = false;
                            }
                        }

                        //获取客户姓名，客户ID，并将客户ID转换成格式：WX00000001
                        string ChangeFormat = strCustomerID.PadLeft(8, '0');
                        DataSet dsCustomerID = CSv.GetCustomerInformation(Convert.ToInt32(strCustomerID));
                        string Address = dsCustomerID.Tables[0].Rows[0]["CCity"].ToString();
                        string FinalAdress = string.Empty;
                        string JXAddress = PM.GetPYString(Address);
                        foreach (char c in JXAddress)
                        {
                            FinalAdress += char.ToUpper(c);
                        }

                        //通过客户ID获取他的合同编号,姓名
                        DataSet dsContractID = FSv.GetContractIDInfo(int.Parse(strCustomerID));
                        filesInfo.FolderID = dsContractID.Tables[0].Rows[0]["ContractID"].ToString().Trim();
                        lbName.Text = dsCustomerID.Tables[0].Rows[0]["CustomerName"].ToString();

                        //判断该用户是否已经有上传文件的信息，如果有则显示在页面上
                        if (Directory.Exists(filePath + @"\" + filesInfo.FolderID) || DocInfoSv.IsFIDExistData(filesInfo.FolderID) == 1)
                        {
                            DataSet ds = DocInfoSv.GetFileInfo_Service(filesInfo.FolderID);
                            gvFileList.DataSource = ds;
                            gvFileList.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('还没有为该客户上传过相关文档！')</script>");
                        }
                    }
                    catch (Exception exp)
                    {
                        Response.Write(exp.Message);
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('对不起，能还未登陆，或者长时间未操作，请重新登陆')</script>");
                //Response.Redirect("../Login.aspx");
                Response.Write("<script>window.top.location='../Nologin.aspx';</script>");
            }
        }

        protected void gdvUploadFile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFileList.PageIndex = e.NewPageIndex;
            gvFileList.DataBind();
        }

        protected void gdvUploadFile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                DownloadFile(e.CommandArgument.ToString());
            }
            if (e.CommandName == "Remove")
            {
                if (File.Exists(filePath + @"\" + filesInfo.FolderID + @"\" + e.CommandArgument.ToString()))
                {
                    DocInfoSv.RemoveFileInfo_Service(e.CommandArgument.ToString());
                    File.Delete(filePath + @"\" + filesInfo.FolderID + @"\" + e.CommandArgument.ToString());

                    DataSet ds = DocInfoSv.GetFileInfo_Service(filesInfo.FolderID);
                    gvFileList.DataSource = ds;
                    gvFileList.DataBind();
                }
            }
        }

        //下载方法
        public void DownloadFile(string fileName)
        {
            FileInfo fi = new FileInfo(@filePath + @"\" + filesInfo.FolderID + @"\" + fileName);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fi.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fi.FullName);
            Response.Flush();
            Response.End();
        }

    }
}
