using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;

namespace CRMDBService
{
    public class LogInfoDB
    {
        public DataSet GetCustomerNameFromLogInfoByStaffID(int StaffID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "distinct ";
            str += "CustomerInfo.CustomerID";
            str += ",";
            str += "CustomerInfo.CustomerName ";
            str += "from ";
            str += "CustomerInfo join LogInfo on LogInfo.CustomerID=CustomerInfo.CustomerID ";
            str += "where LogInfo.GStaffID='" + StaffID + "'";
            str += "and (LogInfo.AssignStatus='1')";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetManagerNamebyCustomerIDFromGW(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select top 1 ";
            str += "staffid,StaffName ";
            str += "from StaffInfo ";
            str += "join LogInfo on StaffInfo.StaffID=LogInfo.DStaffID  where ";
            str += "CustomerID="+CustomerID+" ";
            str += "and PostID=1 and AssignStatus=1 ";
            str += "order by LogInfo.BindDate desc";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }


        public DataSet GetAssignerNamebyCustomerIDFromCopywriter(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select top 1 ";
            str += "staffid,StaffName,PostID,logInfo.GStaffID ";
            str += "from StaffInfo ";
            str += "join LogInfo on StaffInfo.StaffID=LogInfo.DStaffID where ";
            str += "CustomerID=" + CustomerID + " ";
            str += " and AssignStatus=2 ";
            str += "order by LogInfo.BindDate desc";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public void InsertLogInfo(int DStaffID, int CustomerID, int GStaffID, int AssignState, string remark)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Insert into LogInfo(DStaffID,CustomerID,GStaffID,AssignStatus,BindDate,Remark) ";
            sqlstr += " values ";
            sqlstr += "(";
            sqlstr += DStaffID.ToString(); 
            sqlstr += ",";
            sqlstr += CustomerID.ToString(); ;
            sqlstr += ",";
            if (GStaffID == 0)
            {
                sqlstr += "null";
            }
            else
            {
                sqlstr += GStaffID.ToString();
            }
            sqlstr += ",";
            sqlstr += AssignState.ToString();
            sqlstr += ",";
            sqlstr += "'"+DateTime.Now.ToString()+"'";
            sqlstr += ",";
            sqlstr += "'" + remark + "'";
            sqlstr += ")";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public DataSet SearchLogByID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Select LogInfo.DStaffID,";
            sqlstr +="DInfo.StaffName as DStaffName,";
            sqlstr +="LogInfo.CustomerID, CustomerInfo.CustomerName, LogInfo.GStaffID,GInfo.StaffName,";
            sqlstr +="LogInfo.AssignStatus,LogInfo.BindDate,LogInfo.Remark,CustomerInfo.CityInitial";
            sqlstr +=" from LogInfo join CustomerInfo on CustomerInfo.CustomerID=LogInfo.CustomerID left join StaffInfo as DInfo on LogInfo.DStaffID=DInfo.StaffID";
            sqlstr +=" left join StaffInfo as GInfo on LogInfo.GStaffID=GInfo.StaffID";
            sqlstr += " where LogInfo.CustomerID=" + CustomerID;
            sqlstr += "order by LogInfo.LogID ASC";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetCustomerInfobyIDCity(int CustomerID, string CityInitial)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Select * from CustomerInfo ";
            sqlstr += "where CustomerID=" + CustomerID;
            sqlstr += " and CityInitial='" + CityInitial+"'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

    }
}
