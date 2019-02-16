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
using ModelService;

namespace CRMDBService
{
    public class ReminderDB
    {
        
        public DataSet GetFamilyRemindInfo(int staffID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select FamilyRemind.FRemindID,FamilyRemind.FID,FamilyRemind.CustomerID,FamilyRemind.IsRead from FamilyRemind join LogInfo on LogInfo.CustomerID=FamilyRemind.CustomerID  where  LogInfo.AssignStatus=2 and  FamilyRemind.IsRead=0 and LogInfo.GStaffID='" + staffID + "' and DATEDIFF(day,FamilyRemind.RemindDate,CONVERT (date, SYSDATETIME()))=0 ";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetFamilyRemindDetailInfobyStaffID(int staffID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select FamilyInfo.FID,FamilyInfo.ParentName,FamilyInfo.Relationship,FamilyInfo.CustomerID,FamilyInfo.ParentMobilephone,CustomerInfo.CustomerName,CustomerInfo.CityInitial,FamilyRemind.IsRead,FamilyRemind.FRemindID from FamilyRemind join FamilyInfo on FamilyRemind.FID=FamilyInfo.FID join CustomerInfo on CustomerInfo.CustomerID=FamilyRemind.CustomerID join LogInfo on LogInfo.CustomerID=FamilyRemind.CustomerID where LogInfo.AssignStatus=2 and LogInfo.GStaffID='" + staffID + "' and DATEDIFF(day,FamilyRemind.RemindDate,CONVERT (date, SYSDATETIME()))=0 order by FamilyRemind.IsRead ASC";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }



        public void UpdateFamilyRemindIsreadbyFRemindID(int FRemindID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Update";
            sqlstr += " FamilyRemind ";
            sqlstr += " set FamilyRemind.IsRead=1 where FamilyRemind.FRemindID='" + FRemindID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public DataSet GetFollowupRemindInfobyStaffID(int staffID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select RemindInfo.RIID,RemindInfo.CustomerID,customerinfo.CustomerName,CustomerInfo.CityInitial,RemindInfo.IsRead from RemindInfo join CustomerInfo on RemindInfo.CustomerID=CustomerInfo.CustomerID join AssignState on RemindInfo.CustomerID=AssignState.CustomerID join StaffInfo on AssignState.GStaffID=StaffInfo.StaffID where AssignState.GStaffID=" + staffID + " and AssignState.AssignStatus=1 and DATEDIFF(day,RemindInfo.NextContactTime,CONVERT (date, SYSDATETIME()))=0  and RemindInfo.Isread=0 order by RemindInfo.IsRead ASC";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }


        public DataSet GetFollowupRemindDetailInfobyStaffID(int staffID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select RemindInfo.RIID,RemindInfo.CustomerID,customerinfo.CustomerName,CustomerInfo.CityInitial,RemindInfo.IsRead from RemindInfo join CustomerInfo on RemindInfo.CustomerID=CustomerInfo.CustomerID join AssignState on RemindInfo.CustomerID=AssignState.CustomerID join StaffInfo on AssignState.GStaffID=StaffInfo.StaffID where AssignState.GStaffID=" + staffID + " and AssignState.AssignStatus=1 and DATEDIFF(day,RemindInfo.NextContactTime,CONVERT (date, SYSDATETIME()))=0 order by RemindInfo.IsRead ASC";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public void UpdateFollowupRemindDetailInfobyRIID(int RIID)
        {

            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Update";
            sqlstr += " RemindInfo ";
            sqlstr += " set RemindInfo.IsRead=1 where RemindInfo.RIID='" + RIID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }


        public DataSet GetCustomRemindInfobyStaffID(int staffID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select CustomRemind.ID,CustomRemind.RemindDate,CustomRemind.RemindContent,CustomRemind.CreatedBy,CustomRemind.IsActive,CustomRemind.CreateTime from CustomRemind join StaffInfo on CustomRemind.CreatedBy=StaffInfo.StaffID where CustomRemind.IsActive=1 and  CustomRemind.CreatedBy='" + staffID + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public void InsertCustomRemindInfo(DateTime RemindDate, string RemindContent, int CreatedBy, int IsActive)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Insert into CustomRemind(RemindDate,RemindContent,CreatedBy,IsActive,CreateTime) ";
            sqlstr += " values ";
            sqlstr += "('";
            sqlstr += RemindDate+"'"; 
            sqlstr += ",'";
            sqlstr += RemindContent + "'";
            sqlstr += ",'";
            sqlstr += CreatedBy.ToString() + "'";
            sqlstr += ",'";
            sqlstr += IsActive.ToString() + "'";
            sqlstr += ",";
            sqlstr += "'"+DateTime.Now.ToString()+"'";
            sqlstr += ")";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteCustomerRemindbyID(int ID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Update";
            sqlstr += " CustomRemind ";
            sqlstr += " set CustomRemind.IsActive='0' where CustomRemind.ID='" + ID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void UpdateCustomRemindInfo(CustomRemindInfo CRIF)
        {

            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Update";
            sqlstr += " CustomRemind ";
            sqlstr += " set CustomRemind.RemindDate='" + CRIF.RemindDate.ToString()+"',";
            sqlstr += " CustomRemind.RemindContent='" + CRIF.RemindContent+"',";
            sqlstr += " CustomRemind.CreatedBy='" + CRIF.CreatedBy.ToString()+"',";
            sqlstr += " CustomRemind.IsActive='" + CRIF.IsActive.ToString()+"',";
            sqlstr += " CustomRemind.CreateTime='" + CRIF.CreateTime.ToString()+ "'";
            sqlstr += " where CustomRemind.ID='" + CRIF.ID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

    }
}
