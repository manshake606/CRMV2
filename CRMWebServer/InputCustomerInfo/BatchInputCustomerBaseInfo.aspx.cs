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

namespace CRMWebServer.InputCustomerInfo
{
    public partial class BatchInputCustomerBaseInfo : System.Web.UI.Page
    {
        CRMControlService.ModifyCustomerService MCS = new ModifyCustomerService();
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
                Response.Write("<script>window.top.location='../Nologin.aspx';</script>");
                return;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                Response.Write("<script>alert('请选择文件!')</script>");
                return;
            }
            string name = FileUpload1.PostedFile.FileName;
            if (name.Substring(name.Length-4,4)!="xlsm")
            {
                Response.Write("<script>alert('请选择正确文件!')</script>");
                return;
            }
            
            string path = Server.MapPath("../BC/");
            
            FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
            int inputnum=0;
            int exist=0;
            int errornum=0;

            string ErrorName = MCS.doBatchInsert(path + FileUpload1.FileName, staffInfo.StaffID, ref inputnum, ref exist, ref errornum);
            
            if (ErrorName == "")
            {
                Response.Write("<script>alert('批量导入成功!\\n成功导入"+inputnum+"条!\\n重复"+exist+"条!\\n失败"+errornum+"条!')</script>");
                System.IO.File.Delete(path + FileUpload1.FileName);
            }
            else
            {
                Response.Write("<script>alert('" + ErrorName + "\\n成功导入" + inputnum + "条!\\n重复" + exist + "条!\\n失败" + errornum + "条!')</script>");
                System.IO.File.Delete(path + FileUpload1.FileName);
            }
        }
      
        protected void lbtnDownloadBlank_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadFile("Import_CustomerInfo_Blank.xlsm");
            }
            catch
            {
                Response.Write("<script>alert('文件下载异常，请检查是否未关闭')</script>");
                return;
            }
        }

        protected void lbtnDownloadSample_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadFile("Import_CustomerInfo_Sample.xlsm");
            }
            catch
            {
                Response.Write("<script>alert('文件下载异常，请检查是否未关闭')</script>");
                return;
            }
        }
       
        //下载方法
        public void DownloadFile(string fileName)
        {
            
            Response.Redirect("../BatchSample/" + fileName);
 

        }
    }
}
