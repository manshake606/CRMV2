using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;
using System.Text;

namespace CRMDBService
{
    public class DocumentInfoDB
    {
        DbHelper db = new DbHelper();

        //判断数据库中是否有当前用户的文件夹信息
        public int IsFIDExistInfo(string FolderID)
        {
            DbDataReader dbdr;
            string sqlstr = "";
            sqlstr += "Select";
            sqlstr += " * ";
            sqlstr += " from ";
            sqlstr += " FileInfo ";
            sqlstr += " where FolderID='" + FolderID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            dbdr = db.ExecuteReader(cmd);

            if (dbdr.HasRows)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //插入上传文件信息
        public void InsertFileInfo(string FileName, string FolderID, int CustomerID)
        {
            string sqlstr = "";
            sqlstr += "Insert into FileInfo(FilesName,FolderID,FileUploadDate,CustomerID) ";
            sqlstr += " values ";
            sqlstr += "(";
            sqlstr += "'" + FileName + "'";
            sqlstr += ",";
            sqlstr += "'" + FolderID + "'";
            sqlstr += ",";
            sqlstr += "'" + DateTime.Today + "'";
            sqlstr += ",";
            sqlstr += "'" + CustomerID + "'";
            sqlstr += ")";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        //获取已上传的文件信息
        public DataSet GetFileInfo(string FolderID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select ";
            sqlstr += " FileInfo.FilesName";
            sqlstr += " ,";
            sqlstr += " FileInfo.FileUploadDate";
            sqlstr += " from ";
            sqlstr += " FileInfo ";
            sqlstr += " where FolderID='" + FolderID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }

        //判断文件是否已经上传
        public int IsFileExistInfo(string FileName, string FolderID)
        {
            DbDataReader dbdr;
            string sqlstr = "";
            sqlstr += "Select";
            sqlstr += " FilesName";
            sqlstr += " from ";
            sqlstr += " FileInfo ";
            sqlstr += " where FilesName='" + FileName + "' and FolderID='" + FolderID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            dbdr = db.ExecuteReader(cmd);

            if (dbdr.HasRows)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //删除已上传文件信息
        public void RemoveFileInfo(string FileName)
        {
            string sqlstr = "";
            sqlstr += "Delete";
            sqlstr += " FileInfo ";
            sqlstr += " where FilesName='" + FileName + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }


        ////获取通过查询时间获取客户的姓名，编号，合同编号，文案状态，顾问姓名，文案编号，指派给文案的时间等等信息
        public DataSet GetDocInfoByDate(DateTime Startime, DateTime Endtime, int StaffID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select";
            sqlstr += " CustomerInfo.CustomerID";
            sqlstr += ",";
            sqlstr += " CustomerInfo.CustomerName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionSname";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionProfessionName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionCountry";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionPhase";
            sqlstr += ",";
            sqlstr += " Financial.ContractID";
            sqlstr += ",";
            sqlstr += " Financial.EndDate";
            sqlstr += ",";
            sqlstr += " Financial.Proxy";
            sqlstr += ",";
            sqlstr += " Financial .ProxyName";
            sqlstr += ",";
            sqlstr += " AssignState.AssignStatus";
            sqlstr += ",";
            sqlstr += " LogInfo.BindDate";
            sqlstr += " from ";
            sqlstr += " CustomerInfo";
            sqlstr += " Inner join Financial on CustomerInfo.CustomerID =Financial.CustomerID";
            sqlstr += " inner join AssignState on CustomerInfo.CustomerID = AssignState.CustomerID";
            sqlstr += " inner join LogInfo on AssignState.CustomerID = LogInfo.CustomerID";
            sqlstr += " inner join StaffInfo on StaffInfo.StaffID = AssignState.GStaffID";
            sqlstr += " where (LogInfo.BindDate between '" + Startime + "' and  '" + Endtime + "')";
            sqlstr += " and StaffInfo.StaffID = " + StaffID + "";
            sqlstr += " and (AssignState.AssignStatus=2 or AssignState.AssignStatus=4)";
            sqlstr += " and LogInfo.BindDate=(Select MAX(binddate) from LogInfo where AssignState.CustomerID = LogInfo.CustomerID)";
            sqlstr += " order by AssignState.AssignStatus asc,LogInfo.BindDate desc";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }

        public DataSet GetAllDocInfo()
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select";
            sqlstr += " CustomerInfo.CustomerID";
            sqlstr += ",";
            sqlstr += " CustomerInfo.CustomerName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionSname";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionProfessionName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionCountry";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionPhase";
            sqlstr += ",";
            sqlstr += " Financial.ContractID";
            sqlstr += ",";
            sqlstr += " Financial.EndDate";
            sqlstr += ",";
            sqlstr += " Financial.Proxy";
            sqlstr += ",";
            sqlstr += " Financial .ProxyName";
            sqlstr += ",";
            sqlstr += " AssignState.AssignStatus";
            sqlstr += ",";
            sqlstr += " LogInfo.BindDate";
            sqlstr += " from ";
            sqlstr += " CustomerInfo";
            sqlstr += " Inner join Financial on CustomerInfo.CustomerID =Financial.CustomerID";
            sqlstr += " inner join AssignState on CustomerInfo.CustomerID = AssignState.CustomerID";
            sqlstr += " inner join LogInfo on AssignState.CustomerID = LogInfo.CustomerID";
            sqlstr += " where (AssignState.AssignStatus=2 or AssignState.AssignStatus=4)";
            sqlstr += " and LogInfo.BindDate=(Select MAX(binddate) from LogInfo where AssignState.CustomerID = LogInfo.CustomerID)";
            sqlstr += " order by AssignState.AssignStatus asc,LogInfo.BindDate desc";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }

        public DataSet GetDocInfoByDate(DateTime Startime, DateTime Endtime)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select";
            sqlstr += " CustomerInfo.CustomerID";
            sqlstr += ",";
            sqlstr += " CustomerInfo.CustomerName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionSname";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionProfessionName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionCountry";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionPhase";
            sqlstr += ",";
            sqlstr += " Financial.ContractID";
            sqlstr += ",";
            sqlstr += " Financial.EndDate";
            sqlstr += ",";
            sqlstr += " Financial.Proxy";
            sqlstr += ",";
            sqlstr += " Financial .ProxyName";
            sqlstr += ",";
            sqlstr += " AssignState.AssignStatus";
            sqlstr += ",";
            sqlstr += " LogInfo.BindDate";
            sqlstr += " from ";
            sqlstr += " CustomerInfo";
            sqlstr += " Inner join Financial on CustomerInfo.CustomerID =Financial.CustomerID";
            sqlstr += " inner join AssignState on CustomerInfo.CustomerID = AssignState.CustomerID";
            sqlstr += " inner join LogInfo on AssignState.CustomerID = LogInfo.CustomerID";
            sqlstr += " where (LogInfo.BindDate between '" + Startime + "' and  '" + Endtime + "')";
            sqlstr += " and (AssignState.AssignStatus=2 or AssignState.AssignStatus=4)";
            sqlstr += " and LogInfo.BindDate=(Select MAX(binddate) from LogInfo where AssignState.CustomerID = LogInfo.CustomerID)";
            sqlstr += " order by AssignState.AssignStatus asc,LogInfo.BindDate desc";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }

        public DataSet GetDocInfoByGW(DateTime Startime, DateTime Endtime, int StaffID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select";
            sqlstr += " CustomerInfo.CustomerID";
            sqlstr += ",";
            sqlstr += " CustomerInfo.CustomerName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionSname";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionProfessionName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionCountry";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionPhase";
            sqlstr += ",";
            sqlstr += " Financial.ContractID";
            sqlstr += ",";
            sqlstr += " Financial.EndDate";
            sqlstr += ",";
            sqlstr += " Financial.Proxy";
            sqlstr += ",";
            sqlstr += " Financial .ProxyName";
            sqlstr += ",";
            sqlstr += " AssignState.AssignStatus";
            sqlstr += ",";
            sqlstr += " LogInfo.BindDate";
            sqlstr += " from ";
            sqlstr += " CustomerInfo";
            sqlstr += " Inner join Financial on CustomerInfo.CustomerID =Financial.CustomerID";
            sqlstr += " inner join AssignState on CustomerInfo.CustomerID = AssignState.CustomerID";
            sqlstr += " inner join LogInfo on AssignState.CustomerID = LogInfo.CustomerID";
            sqlstr += " inner join StaffInfo on StaffInfo.StaffID = AssignState.DStaffID";
            sqlstr += " where (LogInfo.BindDate between '" + Startime + "' and  '" + Endtime + "')";
            sqlstr += " and StaffInfo.StaffID = " + StaffID + "";
            sqlstr += " and (AssignState.AssignStatus=2 or AssignState.AssignStatus=4)";
            sqlstr += " and LogInfo.BindDate=(Select MAX(binddate) from LogInfo where AssignState.CustomerID = LogInfo.CustomerID)";
            sqlstr += " order by AssignState.AssignStatus asc,LogInfo.BindDate desc";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }
        
        public DataSet GetDocInfoByStaffID(int StaffID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select";
            sqlstr += " CustomerInfo.CustomerID";
            sqlstr += ",";
            sqlstr += " CustomerInfo.CustomerName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionSname";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionProfessionName";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionCountry";
            sqlstr += ",";
            sqlstr += " CustomerInfo.AdmissionPhase";
            //sqlstr += ",";
            //sqlstr += " StaffInfo.PostID";
            sqlstr += ",";
            sqlstr += " Financial.ContractID";
            sqlstr += ",";
            sqlstr += " Financial.EndDate";
            sqlstr += ",";
            sqlstr += " Financial.Proxy";
            sqlstr += ",";
            sqlstr += " Financial .ProxyName";
            sqlstr += ",";
            sqlstr += " AssignState.AssignStatus";
            sqlstr += ",";
            sqlstr += " LogInfo.BindDate";
            sqlstr += " from ";
            sqlstr += " CustomerInfo";
            sqlstr += " Inner join Financial on CustomerInfo.CustomerID =Financial.CustomerID";
            sqlstr += " inner join AssignState on CustomerInfo.CustomerID = AssignState.CustomerID";
            sqlstr += " inner join LogInfo on AssignState.CustomerID = LogInfo.CustomerID";
            sqlstr += " inner join StaffInfo on StaffInfo.StaffID = AssignState.GStaffID";
            sqlstr += " where StaffInfo.StaffID = " + StaffID + "";
         // sqlstr += " and (StaffInfo.PostID=2 or StaffInfo.PostID=3 or StaffInfo.PostID=4)";
            sqlstr += " and AssignState.AssignStatus=2";
            sqlstr += " and LogInfo.BindDate=(Select MAX(binddate) from LogInfo where AssignState.CustomerID = LogInfo.CustomerID)";
            sqlstr += " order by AssignState.AssignStatus asc,LogInfo.BindDate desc";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }

    }
}
