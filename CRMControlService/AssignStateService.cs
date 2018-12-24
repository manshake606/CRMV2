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


    public class AssignStateService
    {

        LogInfoDB LIDB = new LogInfoDB();

        public DataSet GetCustomerAssignInfo_Service(int AssignStatus, string CCity,int StaffID,int authority ,string ImportPeople, string IntentionCountry, int important, int CustomerClass, string FromData, int ConsultantStaffID, int CopywriterStaffID,int flag)
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.GetCustomerAssignInfo(AssignStatus, CCity, StaffID, authority, ImportPeople, IntentionCountry, important, CustomerClass, FromData, ConsultantStaffID, CopywriterStaffID,flag);
            return ds;
        }

        public DataSet GetCustomerAssignInfo_Service()
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.GetCustomerAssignInfo();
            return ds;
        }
        public DataSet GetImportingPeople()
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.GetImportingPeople();
            return ds;
        }

        public DataSet GetIntentionCountry_Service()
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.GetIntentionCountry();
            return ds;
        }

        public DataSet GetFromData_Server()
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.GetFromData();
            return ds;
        }

        public DataSet GetFollowupConsultant_Service()
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.GetFollowupConsultant();
            return ds;
        }

        public DataSet GetCopywtiter_Service()
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.GetCopywtiter();
            return ds;
        }

        public DataSet GetCustomerNowAssignState_Service(int CustomerID)
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.GetCustomerNowAssignState(CustomerID);
            return ds;
        }

        public void UpdateAssignState_Service(int DStaffID, int GStaffID, int AssignState, string Remark, int CustomerID)
        {

            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ASDB.UpdateAssignState(DStaffID, GStaffID, AssignState, Remark, CustomerID);


        }

        public int CheckBind(int CustomerID)
        {
            DataSet ds = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            ds = ASDB.CheckBind(CustomerID);
            int result = int.Parse(ds.Tables[0].Rows[0]["AssignStatus"].ToString());
            return result;
            
        }
        

        public int DoAssignBusiness(int DStaffID,int GStaffID,int AssignState,string Remark, int CustomerID,int authority)
        {
            int ErrorCustomerID=0;
            Trans t = new Trans();
            try
            {
                UpdateAssignState_Service(DStaffID, GStaffID, AssignState, Remark, CustomerID);
                LIDB.InsertLogInfo(DStaffID, CustomerID, GStaffID,  AssignState, Remark);
                t.Commit();
            }
            catch
            {
                t.RollBack();
                ErrorCustomerID = CustomerID;
            }
            return ErrorCustomerID;
        }

        public DataSet GetContractIDbyCustomerID_Service(int CustomerID)
        {
            DataSet DS=new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            DS=ASDB.GetContractIDbyCustomerID(CustomerID);
            return DS;
        }


        public DataSet GetCustomerIDNamebyStaffID_Service(int StaffID)
        {
            DataSet DS = new DataSet();
            CRMDBService.AssignStateDB ASDB = new AssignStateDB();
            DS = ASDB.GetCustomerIDNamebyStaffID(StaffID);
            return DS;
        }
    }
}
