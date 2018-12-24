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
    public class LogInfoService
    {
        public DataSet GetCustomerNameFromLogInfoByStaffID_Service(int staffID)
        {
            CRMDBService.LogInfoDB logdb = new LogInfoDB();
            DataSet ds = logdb.GetCustomerNameFromLogInfoByStaffID(staffID);
            return ds;
        }

        public DataSet GetManagerNamebyCustomerID_Service(int CustomerID)
        {
            CRMDBService.LogInfoDB logdb = new LogInfoDB();
            DataSet ds = logdb.GetManagerNamebyCustomerIDFromGW(CustomerID);
            return ds;
        }

        public DataSet GetAssignerNamebyCustomerIDFromCopywriter(int CustomerID)
        {
            CRMDBService.LogInfoDB logdb = new LogInfoDB();
            DataSet ds = logdb.GetAssignerNamebyCustomerIDFromCopywriter(CustomerID);
            return ds;
        }

        public void InsertLogInfo_Service(int DStaffID, int CustomerID, int GStaffID,  int AssignState, string remark)
        {
            CRMDBService.LogInfoDB logdb = new LogInfoDB();
            logdb.InsertLogInfo(DStaffID, CustomerID, GStaffID,  AssignState, remark);
        }

        public DataSet SearchLogByID_Service(int CustomerID)
        {
            CRMDBService.LogInfoDB logdb = new LogInfoDB();
            DataSet ds=logdb.SearchLogByID(CustomerID);
            return ds;
        }

        public DataSet GetCustomerInfobyIDCity_Service(int CustomerID, string CityInitial)
        {
            CRMDBService.LogInfoDB logdb = new LogInfoDB();
            DataSet ds = logdb.GetCustomerInfobyIDCity(CustomerID, CityInitial);
            return ds;
        }
    }
}
