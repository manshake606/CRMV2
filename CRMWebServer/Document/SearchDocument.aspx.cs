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
using System.IO;
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
        CRMControlService.ModifyCustomerService MCSv = new ModifyCustomerService();

        CRMWebServer.FinancialPage.Payment PM = new CRMWebServer.FinancialPage.Payment();

        ModelService.FilesInfo filesInfo = new ModelService.FilesInfo();
        ModelService.StaffInfo SI = new StaffInfo();
        ModelService.CustomerInfo CI = new CustomerInfo();
        ModelService.StaffInfo staffInfo = new StaffInfo();
        string filePath = ConfigurationManager.AppSettings["UploadFilePath"];
        //string moduleID;
        DataSet dsGetDocInfo;
        //DataSet dsDocumentName;
        //DataSet PID;
        int PostID;
        DateTime? uploadStartTime = null;
        DateTime? uploadEndTime = null;
        int CusomterID = 0;
        string CustomerName = "";
        string DocumentName = "";
        string UploadedBy = "";
        int FileType;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["staffID"] != null)
            {
                staffInfo.StaffID = Int32.Parse(HttpContext.Current.Session["staffID"].ToString());
                //moduleID = ConfigurationManager.AppSettings["Copywriter"];

                //dsDocumentName = SISv.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                //PID = SISv.GetStaffPIDByName_Service(dsDocumentName.Tables[0].Rows[0]["StaffName"].ToString());
                //PostID = int.Parse(PID.Tables[0].Rows[0]["PostID"].ToString());

                /*
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
                 * */
                if (!IsPostBack)
                {
                    DataTable dt = new DataTable();
                    DataSet dsFileInfo = DocInfoSv.GetFileTypeInfo_Service();
                    dt = dsFileInfo.Tables[0];
                    DDLFileType.Items.Clear();
                    DDLFileType.DataSource = dt;
                    DDLFileType.DataValueField = dt.Columns[0].ColumnName;
                    DDLFileType.DataTextField = dt.Columns[1].ColumnName;
                    DDLFileType.DataBind();
                    DDLFileType.Items.Insert(0, new ListItem("所有文件类型", "-1"));
                }
                


            }
            else
            {
                Response.Write("<script>alert('对不起，能还未登陆，或者长时间未操作，请重新登陆')</script>");
                //Response.Redirect("../Login.aspx");
                Response.Write("<script>window.top.location='../Nologin.aspx';</script>");
            }
            
        }

        //下载方法
        public void DownloadFile(string fileName)
        {
            
            string strTemp = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
            FileInfo fi = new FileInfo(@filePath + @"\" + filesInfo.FolderID + @"\" + filesInfo.FileType + @"\" + fileName);
            Response.Clear();
            //解决文件名乱码                    
            Response.AppendHeader("content-disposition", "attachment;filename=" + strTemp);
            //附件下载                    
            //Response.AppendHeader("content-disposition", "online;filename=" + strName);
            //在线打开                    
            //Response.OutputStream.Write(data, 0, nSize);     
            Response.WriteFile(fi.FullName);
            Response.Flush();
            Response.End();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            BindGvSearch();
        }

        public void BindGvSearch()
        {
            if (txtStarttime.Text != null && txtStarttime.Text != "")
            {
                uploadStartTime = DateTime.Parse(txtStarttime.Text);
            }
            if (txtEndtime.Text != null && txtEndtime.Text != "")
            {
                uploadEndTime = DateTime.Parse(txtEndtime.Text + " 23:59:59.000");
            }
            if (txtCustomerID.Text != null && txtCustomerID.Text != "")
            {
                CusomterID = int.Parse(txtCustomerID.Text);
            }
            if (txtCustomerName.Text != null && txtCustomerName.Text != "")
            {
                CustomerName = txtCustomerName.Text;
            }
            if (txtDocumentName.Text != null && txtDocumentName.Text != "")
            {
                DocumentName = txtDocumentName.Text;
            }
            if (txtUploadBy.Text != null && txtUploadBy.Text != "")
            {
                UploadedBy = txtUploadBy.Text;
            }
            FileType = int.Parse(DDLFileType.SelectedValue);
            DataSet dsFileInfo = DocInfoSv.GetFileInfoByCondition_Service(CusomterID, CustomerName, uploadStartTime, uploadEndTime, DocumentName, UploadedBy, FileType);
            gvSearchResult.DataSource = dsFileInfo;
            gvSearchResult.DataBind();
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
            DataSet ds = DocInfoSv.GetFileInfoByFileID_Service(int.Parse(e.CommandArgument.ToString()));
            if (e.CommandName == "download")
            {
                filesInfo.FileType = int.Parse(ds.Tables[0].Rows[0]["FileType"].ToString());
                filesInfo.FolderID = ds.Tables[0].Rows[0]["FolderID"].ToString();
                DownloadFile(ds.Tables[0].Rows[0]["FilesName"].ToString());

            }
            if (e.CommandName == "Remove")
            {

                if (File.Exists(filePath + @"\" + ds.Tables[0].Rows[0]["FolderID"].ToString() + @"\" + ds.Tables[0].Rows[0]["FileType"].ToString() + @"\" + ds.Tables[0].Rows[0]["FilesName"].ToString()))
                {
                    DocInfoSv.RemoveFileInfo_Service(e.CommandArgument.ToString());
                    MCSv.DeleteFileInfoRelationbyFileID_Service(int.Parse(e.CommandArgument.ToString()));
                    File.Delete(filePath + @"\" + ds.Tables[0].Rows[0]["FolderID"].ToString() + @"\" + ds.Tables[0].Rows[0]["FileType"].ToString() + @"\" + ds.Tables[0].Rows[0]["FilesName"].ToString());
                    //filesInfo.Customer = int.Parse(ds.Tables[0].Rows[0]["Customer"].ToString());
                    BindGvSearch();
                }
            }
        }
    }
}
