using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using CRMControlService;
using ModelService;


namespace CRMWebServer
{
    public partial class UploadDocument : System.Web.UI.Page
    {

        string filePath = ConfigurationManager.AppSettings["UploadFilePath"];
        string maxRequestSize = ConfigurationManager.AppSettings["MaxRequestSize"];
        string CustomerID;

        DataTable dt = new DataTable();
        ModelService.FilesInfo filesInfo = new ModelService.FilesInfo();
        ModelService.MoFinancial MF = new MoFinancial();

        CRMControlService.DocumentInfoService DocInfoSv = new DocumentInfoService();
        CRMControlService.StaffInfoService SISv = new StaffInfoService();
        StaffInfo staffInfo = new StaffInfo();
        CustomerInfo custInfo = new CustomerInfo();
        CRMControlService.LogInfoService LIS = new LogInfoService();
        CRMWebServer.FinancialPage.Payment PM = new CRMWebServer.FinancialPage.Payment();
        CRMControlService.CustomerService CSv = new CustomerService();
        CRMControlService.FinancialService FSv = new FinancialService();
        CRMControlService.AuthorityService AS = new AuthorityService();

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取初始文件名
            filesInfo.FileName = FileUpload1.FileName;

            if (HttpContext.Current.Session["staffID"] != null)
            {
                if (HttpContext.Current.Session["CustomerID"] != null || Request.QueryString["CustomerID"] != null)
                {
                    if (HttpContext.Current.Session["CustomerID"] != null)
                    {
                        CustomerID = HttpContext.Current.Session["CustomerID"].ToString();
                    }
                    else
                    {
                        CustomerID = Request.QueryString["CustomerID"];
                    }
                    staffInfo.StaffID = Int32.Parse(HttpContext.Current.Session["staffID"].ToString());

                    //判断该员工是否有权限删除已上传文档
                    string moduleID = ConfigurationManager.AppSettings["Copywriter"];
                    try
                    {
                        if (AS.CheckAuthorityByStaffID_Service(staffInfo.StaffID, moduleID) == 6)
                        {
                            gdvUploadFile.Columns[3].Visible = true;
                        }
                        else
                        {
                            if (AS.CheckAuthorityByStaffID_Service(staffInfo.StaffID, moduleID) == 0)
                            {
                                Response.Redirect("../Error/404.aspx");
                            }
                            else
                            {
                                gdvUploadFile.Columns[3].Visible = false;
                            }
                        }

                        //获取客户姓名，客户ID，并将客户ID转换成格式：WX00000001
                        string ChangeFormat = CustomerID.ToString().PadLeft(8, '0');
                        DataSet dsCustomerID = CSv.GetCustomerInformation(Convert.ToInt32(CustomerID));
                        string Address = dsCustomerID.Tables[0].Rows[0]["CCity"].ToString();
                        string FinalAdress = string.Empty;
                        string JXAddress = PM.GetPYString(Address);
                        foreach (char c in JXAddress)
                        {
                            FinalAdress += char.ToUpper(c);
                        }
                        txtCustomerID.Text = FinalAdress + ChangeFormat;
                        txtCustomerName.Text = dsCustomerID.Tables[0].Rows[0]["CustomerName"].ToString();

                        //通过客户ID获取他的合同编号
                        DataSet dsContractID = FSv.GetContractIDInfo(int.Parse(CustomerID));
                        txtContractID.Text = dsContractID.Tables[0].Rows[0]["ContractID"].ToString();
                        filesInfo.FolderID = txtContractID.Text.ToString().Trim();

                        //获取当前登录的文案的姓名
                        DataSet dsDocumentName = SISv.GetStaffNamebyStaffID_Service(staffInfo.StaffID);
                        txtDocumentName.Text = dsDocumentName.Tables[0].Rows[0]["StaffName"].ToString();

                        //通过客户ID获取对应顾问ID的姓名和编号
                        DataSet dsGWName = LIS.GetAssignerNamebyCustomerIDFromCopywriter(int.Parse(CustomerID));
                        MF.ContractID = txtConsultantName.Text = dsGWName.Tables[0].Rows[0]["StaffName"].ToString();

                        //判断该用户是否已经有上传文件的信息，如果有则显示在页面上
                        if (Directory.Exists(filePath + @"\" + filesInfo.FolderID))
                        {
                            if (DocInfoSv.IsFIDExistData(filesInfo.FolderID) == 1)
                            {
                                BindGridView();
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
                    Response.Write("<script>alert('请选择需要上传文档的客户')</script>");
                    Response.Redirect("../Document/SearchDocument.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('对不起，能还未登陆，或者长时间未操作，请重新登陆')</script>");
                Response.Write("<script>window.top.location='../Nologin.aspx';</script>");
            }
        }


        /// <summary>
        /// 上传文件到指定的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (HiddenField1.Value == "0")
            {
                return;
            }

            Upload();
        }

        private void Upload()
        {
            //判断是否选择了上传文件
            if (FileUpload1.HasFile)
            {
                //根据客户ID判断在该路径下是否存在以客户编号为名的文件夹 否则将建立以客户编号为名的文件夹
                if (!Directory.Exists(filePath + @"\" + filesInfo.FolderID))
                {
                    // 建立绝对路径文件夹。
                    System.IO.Directory.CreateDirectory(filePath + @"\" + filesInfo.FolderID);

                    // InsertDocumentInfoDB();
                    InsertFileInfoDB();
                    BindGridView();
                    // 保存文件到路径,取当前文件的绝对目录
                    FileUpload1.PostedFile.SaveAs(filePath + @"\" + filesInfo.FolderID + @"\" + filesInfo.FileName);

                }
                else
                {
                    //客户文件夹已经创建，判断文件是否已经上传
                    if (!File.Exists(filePath + @"\" + filesInfo.FolderID + @"\" + filesInfo.FileName))
                    {

                        //InsertDocumentInfoDB();
                        InsertFileInfoDB();
                        BindGridView();
                        // 保存文件到路径,取当前文件的绝对目录
                        FileUpload1.PostedFile.SaveAs(filePath + @"\" + filesInfo.FolderID + @"\" + filesInfo.FileName);
                    }
                    else
                    {
                        //覆盖已经上传的文档
                        FileUpload1.PostedFile.SaveAs(filePath + @"\" + filesInfo.FolderID + @"\" + filesInfo.FileName);
                    }
                }
            }
            else
            {
                Response.Write("<script language=javascript>window.alert('请选择需要上传的文件')</script>");
            }

        }

        //将已上传文件名称绑定到DataGridView并显示出来
        public void BindGridView()
        {
            try
            {
                DataSet ds = DocInfoSv.GetFileInfoByCustomerID_Service(filesInfo.Customer);
                gdvUploadFile.DataSource = ds;
                gdvUploadFile.DataBind();
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }

        //向数据库插入上传的文件信息
        private void InsertFileInfoDB()
        {
            try
            {
                //确认文件夹信息是否存在数据库，不存在则插入
                if (DocInfoSv.IsFileExistData(filesInfo.FileName, filesInfo.FolderID) == 0)
                {
                    DocInfoSv.InsertFileInfo_Service(filesInfo.FileName, filesInfo.FolderID, int.Parse(CustomerID), filesInfo.FileType,filesInfo.UploadedBy);
                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
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

        protected void gdvUploadFile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvUploadFile.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gdvUploadFile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = DocInfoSv.GetFileInfoByFileID_Service(int.Parse(e.CommandArgument.ToString()));
            if (e.CommandName == "download")
            {

                DownloadFile(ds.Tables[0].Rows[0]["FilesName"].ToString());

            }
            if (e.CommandName == "Remove")
            {

                if (File.Exists(filePath + @"\" + ds.Tables[0].Rows[0]["FolderID"].ToString() + @"\" + ds.Tables[0].Rows[0]["FilesName"].ToString()))
                {
                    DocInfoSv.RemoveFileInfo_Service(e.CommandArgument.ToString());
                    File.Delete(filePath + @"\" + ds.Tables[0].Rows[0]["FolderID"].ToString() + @"\" + ds.Tables[0].Rows[0]["FilesName"].ToString());
                    BindGridView();
                }
            }
        }
    }
}
