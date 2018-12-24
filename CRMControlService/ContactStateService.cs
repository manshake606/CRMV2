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
    public class ContactStateService
    {
        public DataSet GetContactStateInfo_Service(int CustomerID, int StaffID, string StartTime, string EndTime)
        {
            CRMDBService.ContactStateDB Cdb = new ContactStateDB();
            DataSet ds = Cdb.GetContactStateInfo(CustomerID, StaffID, StartTime, EndTime);
            return ds;
        }

        public DataSet GetContactCount_Server(string CSStartDate, string CSEndDate, int StaffId)
        {
            CRMDBService.ContactStateDB Cdb = new ContactStateDB();
            DataSet ds = Cdb.GetContactCount(CSStartDate, CSEndDate, StaffId);
            return ds;
        }


        public void DeleteContactStateInfo_Service(int CSID)
        {
            CRMDBService.ContactStateDB Cdb = new ContactStateDB();
            Cdb.DeleteContactStateInfo(CSID);
        }

        public void UpdateContactStateInfo_Service(int CSID, int CustomerID, int StaffID, string CSContent, string CSDate)
        {
            CRMDBService.ContactStateDB CSB = new ContactStateDB();
            CSB.UpdateContactStateInfo(CSID, CustomerID, StaffID, CSContent, CSDate);
        }

        public DataSet GetCustomerNamebyStaffID_Service(int StaffID)
        {
            CRMDBService.ContactStateDB Cdb = new ContactStateDB();
            DataSet ds = Cdb.GetCustomerNamebyStaffID(StaffID);
            return ds;
        }

        public void InsertContactStateInfo_Service(int CustomerID, int StaffID, string CSContent, string CSDate)
        {
            CRMDBService.ContactStateDB CDB = new ContactStateDB();
            CDB.InsertContactStateInfo(CustomerID, StaffID, CSContent, CSDate);
        }
    }
}
