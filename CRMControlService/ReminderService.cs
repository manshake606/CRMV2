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
using ModelService;

namespace CRMControlService
{
    public class ReminderService
    {
        DataSet ds = new DataSet();
        CRMDBService.ReminderDB RDB = new ReminderDB();
        public DataSet GetFamilyRemindInfo_Service(int staffID)
        {
            ds = RDB.GetFamilyRemindInfo(staffID);
            return ds; 
        }


        public DataSet GetFamilyRemindDetailInfobyStaffID_Service(int staffID)
        {
            ds = RDB.GetFamilyRemindDetailInfobyStaffID(staffID);
            return ds;
        }

        public void UpdateFamilyRemindIsreadbyFRemindID_Service(int FRemindID)
        {
            RDB.UpdateFamilyRemindIsreadbyFRemindID(FRemindID);

        }

        public DataSet GetFollowupRemindDetailInfobyStaffID_Service(int staffID)
        {
            ds = RDB.GetFollowupRemindDetailInfobyStaffID(staffID);
            return ds; 
        }

        public void UpdateFollowupRemindDetailInfobyRIID(int RIID)
        {
            RDB.UpdateFollowupRemindDetailInfobyRIID(RIID);
        }

        public DataSet GetFollowupRemindInfobyStaffID(int staffID)
        {
            ds = RDB.GetFollowupRemindInfobyStaffID(staffID);
            return ds;
        }

        public DataSet GetCustomRemindInfobyStaffID_Service(int staffID)
        {
            ds = RDB.GetCustomRemindInfobyStaffID(staffID);
            return ds;
        }

        public DataSet GetCustomCurrentRemindInfobyStaffID_Service(int staffID)
        {
            ds = RDB.GetCustomCurrentRemindInfobyStaffID(staffID);
            return ds;
        }

        public void InsertCustomRemindInfo_Service(DateTime RemindDate, string RemindContent, int CreatedBy, int IsActive)
        {
            RDB.InsertCustomRemindInfo(RemindDate, RemindContent, CreatedBy, IsActive);
        }

        public void UpdateCustomRemindInfo_Service(CustomRemindInfo CRIF)
        {
            RDB.UpdateCustomRemindInfo(CRIF);
        }

        public void DeleteCustomerRemindbyID_Service(int ID)
        {
            RDB.DeleteCustomerRemindbyID(ID);
        }


    }


}
