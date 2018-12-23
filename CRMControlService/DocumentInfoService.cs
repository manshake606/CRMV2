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
        public void InsertFileInfo_Service(string FileName, string FolderID, int CustomerID)
        {
            CDB.InsertFileInfo(FileName, FolderID,CustomerID);
        }

        public DataSet GetFileInfo_Service(string FolderID)
        {
            return CDB.GetFileInfo(FolderID);
        }

        //删除文件
        public void RemoveFileInfo_Service(string FileName)
        {
            CDB.RemoveFileInfo(FileName);
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
