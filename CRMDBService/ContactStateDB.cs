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
    public class ContactStateDB
    {
        public DataSet GetContactStateInfo(int CustomerID, int StaffID, string StartTime, string EndTime)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select ";
            sqlstr += "ContactState.CSID";
            sqlstr += ",";
            sqlstr += "CustomerInfo.CustomerID";
            sqlstr += ",";
            sqlstr += "CustomerInfo.CustomerName";
            sqlstr += ",";
            sqlstr += "CustomerInfo.CityInitial";
            sqlstr += ",";
            sqlstr += "StaffInfo.StaffID";
            sqlstr += ",";
            sqlstr += "StaffInfo.StaffName";
            sqlstr += ",";
            sqlstr += "ContactState.CSContent";
            sqlstr += ",";
            sqlstr += "CONVERT(varchar(12),ContactState.CSDate,111) as CSDate";
            sqlstr += ",";
            sqlstr += "ContactState.Remark";
            sqlstr += " from ";
            sqlstr += "ContactState ";
            sqlstr += " join CustomerInfo on CustomerInfo.CustomerID=ContactState.CustomerID ";
            sqlstr += " left join StaffInfo on ContactState.StaffID=StaffInfo.StaffID ";

            if (CustomerID != 0 || StaffID != 0 || (StartTime != null && StartTime != "") || (EndTime != null && EndTime != ""))
            {
                sqlstr += " where ";

                if (StaffID != 0)
                {
                    sqlstr += "ContactState.StaffID='" + StaffID + "' ";
                    if (CustomerID != 0)
                    {
                        sqlstr += " and ContactState.CustomerID='" + CustomerID + "' ";
                    }
                    if (StartTime != null && StartTime != "")
                    {
                        sqlstr += "and CSDate >= '" + StartTime + "' ";
                    }
                    if (EndTime != null && EndTime != "")
                    {
                        sqlstr += "and CSDate <= '" + EndTime + "' ";
                    }
                }
                else if (CustomerID != 0)
                {
                    sqlstr += "ContactState.CustomerID='" + CustomerID + "' ";
                    if (StartTime != null && StartTime != "")
                    {
                        sqlstr += "and CSDate >= '" + StartTime + "' ";
                    }
                    if (EndTime != null && EndTime != "")
                    {
                        sqlstr += "and CSDate <= '" + EndTime + "' ";
                    }
                }
                else if ((StartTime != null && StartTime != ""))
                {
                    sqlstr += "CSDate >= '" + StartTime + "' ";
                    if (EndTime != null && EndTime != "")
                    {
                        sqlstr += "and CSDate <= '" + EndTime + "' ";
                    }
                }
                else if ((EndTime != null && EndTime != ""))
                {
                    sqlstr += "CSDate <= '" + EndTime + "' ";
                }
            }
            sqlstr += "order by CustomerName ASC,CSDate DESC";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetContactCount(string CSStartDate, string CSEndDate, int StaffId)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select * from (select * from (select COUNT(CustomerID) as customercount,staffid as id  from (select CustomerID,ContactState.StaffId as staffid from ContactState where 1=1 ";
            if (CSStartDate != "" && CSStartDate != null)
            {
                sqlstr += "and CSDate >='" + CSStartDate + "' ";
            }
            if (CSEndDate != "" && CSEndDate != null)
            {
                sqlstr += "and CSDate <='" + CSEndDate + "' ";
            }
            sqlstr += " ) t1 group by staffid) t2  right join StaffInfo on staffInfo.StaffID=t2.id ) t3 ";
            sqlstr += " where (PostID=6 or PostID=7 or PostID=8 or PostID=9 or PostID=1) and (DirectlyID=" + StaffId + " or StaffID=" + StaffId + ")";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public void UpdateContactStateInfo(int CSID, int CustomerID, int StaffID, string CSContent, string CSDate)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Update";
            sqlstr += " ContactState ";
            sqlstr += " set ContactState.CustomerID='" + CustomerID + "',";
            sqlstr += " ContactState.StaffID='" + StaffID + "',";
            sqlstr += " ContactState.CSContent='" + CSContent + "',";
            sqlstr += " ContactState.CSDate='" + CSDate + "'";
            sqlstr += " where CSID='" + CSID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteContactStateInfo(int CSID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete From ContactState";
            sqlstr += " where ";
            sqlstr += " ContactState.CSID='" + CSID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void InsertContactStateInfo(int CustomerID, int StaffID, string CSContent, string CSDate)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Insert into ContactState(CustomerID,StaffID,CSContent,CSDate) ";
            sqlstr += " values ";
            sqlstr += "(";
            sqlstr += CustomerID.ToString(); ;
            sqlstr += ",";
            sqlstr += StaffID.ToString(); ;
            sqlstr += ",";
            sqlstr += "'"+CSContent+"'";
            sqlstr += ",";
            sqlstr += "'"+CSDate+"'";
            sqlstr += ")";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public DataSet GetCustomerNamebyStaffID(int StaffID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "select ";
            sqlstr += " AssignState.CustomerID";
            sqlstr += ",";
            sqlstr += " CustomerInfo.CustomerName ";
            sqlstr += " from ";
            sqlstr += " CustomerInfo ";
            sqlstr += " join AssignState on AssignState.CustomerID=CustomerInfo.CustomerID ";
            sqlstr += " where ";
            sqlstr += " AssignState.AssignStatus=1 ";
            if (StaffID != 0)
            {
                sqlstr += " and AssignState.GStaffID='" + StaffID + "'";
            }
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }


    }
}
