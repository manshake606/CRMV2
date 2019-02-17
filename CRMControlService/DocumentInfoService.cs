using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using CRMDBService;

namespace CRMControlService
{
    public class DocumentInfoService
    {
        CRMDBService.DocumentInfoDB CDB = new DocumentInfoDB();

        //插入文件信息
        public void InsertFileInfo_Service(string FileName, string FolderID, int CustomerID, int FileType, int UploadedBy)
        {
            CDB.InsertFileInfo(FileName, FolderID, CustomerID, FileType, UploadedBy);
        }

        public DataSet GetFileInfo_Service(string FolderID)
        {
            return CDB.GetFileInfo(FolderID);
        }

        public DataSet GetFileInfoByCustomerID_Service(int CustomerID)
        {
            return CDB.GetFileInfoByCustomerID(CustomerID);
        }

        public DataSet GetFileInfoByFileID_Service(int FileID)
        {
            return CDB.GetFileInfoByFileID(FileID);
        }

        //删除文件
        public void RemoveFileInfo_Service(string FileID)
        {
            CDB.RemoveFileInfo(FileID);
        }

        //获取文件类型信息
        public DataSet GetFileTypeInfo_Service()
        {
            return CDB.GetFileTypeInfo();
        }

        //根据条件获取文件信息
        public DataSet GetFileInfoByCondition_Service(int CustomerID, string CustomerName, DateTime? uploadStartTime, DateTime? uploadEndTime, string FileName, string UploadedBy, int FileType)
        {
            return CDB.GetFileInfoByCondition(CustomerID, CustomerName, uploadStartTime, uploadEndTime, FileName, UploadedBy, FileType);
        }
        //根据条件获取顾问对应的文件信息
        public DataSet GetFileInfoByConditionAsConsultant_Service(int CustomerID, string CustomerName, DateTime? uploadStartTime, DateTime? uploadEndTime, string FileName, string UploadedBy, int FileType,int StaffID)
        {
            return CDB.GetFileInfoByConditionAsConsultant(CustomerID, CustomerName, uploadStartTime, uploadEndTime, FileName, UploadedBy, FileType, StaffID);
        }
        //根据条件获取文案对应的文件信息
        public DataSet GetFileInfoByConditionAsCopyWriter_Service(int CustomerID, string CustomerName, DateTime? uploadStartTime, DateTime? uploadEndTime, string FileName, string UploadedBy, int FileType, int StaffID)
        {
            return CDB.GetFileInfoByConditionAsCopyWriter(CustomerID, CustomerName, uploadStartTime, uploadEndTime, FileName, UploadedBy, FileType, StaffID);
        }

        public int IsFIDExistData(string FolderID)
        {
            return CDB.IsFIDExistInfo(FolderID);
        }

        public int IsFileExistData(string FileName,string FolderID)
        {
            return CDB.IsFileExistInfo(FileName,FolderID);
        }

        public DataSet GetDocInfoByDate_Service(DateTime Startime, DateTime Endtime, int StaffID)
        {
            return CDB.GetDocInfoByDate(Startime, Endtime, StaffID);
        }

        public DataSet GetDocInfoByDate_Service(DateTime Startime, DateTime Endtime)
        {
            return CDB.GetDocInfoByDate(Startime, Endtime);
        }

        public DataSet GetDocInfoByGW_Service(DateTime Startime, DateTime Endtime, int StaffID)
        {
            return CDB.GetDocInfoByGW(Startime, Endtime, StaffID);
        }

        public DataSet GetDocInfoByStaffID_Service(int StaffID)
        {
            return CDB.GetDocInfoByStaffID(StaffID);
        }

        public DataSet GetAllDocInfo_Service()
        {
            return CDB.GetAllDocInfo();
        }
    }
}
