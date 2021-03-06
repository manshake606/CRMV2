﻿using System;
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
    public class ReminderDB
    {

        public DataSet GetFamilyRemindInfo(int staffID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select FamilyRemind.FRemindID,FamilyRemind.FID,FamilyRemind.CustomerID,FamilyRemind.IsRead from FamilyRemind join LogInfo on LogInfo.CustomerID=FamilyRemind.CustomerID  where  LogInfo.AssignStatus=2 and  FamilyRemind.IsRead=0 and LogInfo.DStaffID='" + staffID + "' and DATEDIFF(day,FamilyRemind.RemindDate,CONVERT (date, SYSDATETIME()))=0 ";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetFamilyRemindDetailInfobyStaffID(int staffID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select FamilyInfo.FID,FamilyInfo.ParentName,FamilyInfo.Relationship,FamilyInfo.CustomerID,FamilyInfo.ParentMobilephone,CustomerInfo.CustomerName,CustomerInfo.CityInitial,FamilyRemind.IsRead,FamilyRemind.FRemindID from FamilyRemind join FamilyInfo on FamilyRemind.FID=FamilyInfo.FID join CustomerInfo on CustomerInfo.CustomerID=FamilyRemind.CustomerID join LogInfo on LogInfo.CustomerID=FamilyRemind.CustomerID where LogInfo.AssignStatus=2 and LogInfo.DStaffID='" + staffID + "' and DATEDIFF(day,FamilyRemind.RemindDate,CONVERT (date, SYSDATETIME()))=0 order by FamilyRemind.IsRead ASC";
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
    }
}
