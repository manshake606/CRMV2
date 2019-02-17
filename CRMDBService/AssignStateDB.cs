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
    public class AssignStateDB
    {
        public DataSet GetCustomerAssignInfo(int AssignStatus, string CCity, int StaffID, int authority, string ImportPeople, string IntentionCountry, int important, int CustomerClass, string FromData, int ConsultantStaffID, int CopywriterStaffID,int Flag)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select distinct ";
            str += "CustomerInfo.CustomerID";
            str += ",";
            str += "CustomerInfo.CustomerName ";
            str += ",";
            str += "CustomerInfo.Sex ";
            str += ",";
            str += "CustomerInfo.Telphone ";
            str += ",";
            str += "CustomerInfo.CustomerImportance ";
            str += ",";
            str += "CustomerInfo.CustomerClass ";
            str += ",";
            str += "CustomerInfo.Grade ";
            str += ",";
            str += "Intention.IntentionCountry ";
            str += ",";
            str += "StaffInfo.StaffName ";
            str += ",";
            str += "AssignState.AssignStatus ";
            str += ",";
            str += "CustomerInfo.Age ";
            str += ",";
            str += "CustomerInfo.CCity ";
            str += ",";
            str += "StaffInfo.StaffID ";
            str += ",";
            str += "CustomerInfo.CityInitial ";
            str += ",";
            str += "AssignState.AssignTime ";
            str += "from ";
            str += "CustomerInfo left join AssignState on CustomerInfo.CustomerID=AssignState.CustomerID left join StaffInfo on AssignState.GStaffID=StaffInfo.StaffID left join Intention on CustomerInfo.CustomerID=Intention.CustomerID  ";
            str += " where AssignState.AssignStatus=" + AssignStatus + " ";
            str += "and Intention.BetterWantTo=0 ";
            str += "and CustomerInfo.CCity='" + CCity + "'";
            

            if (ImportPeople != "请选择")
            {
                str += "and CustomerInfo.ImportingPeople= '" + ImportPeople+"' ";
            }

            if (IntentionCountry != "请选择")
            {
                str += "and Intention.IntentionCountry= '" + IntentionCountry + "' ";
            }

            if (Flag == 1)
            {
                if (important != 10)
                {
                    str += "and CustomerInfo.CustomerImportance= '" + important + "' ";
                }
            }

            if (Flag == 0 )
            {
                str += "and CustomerInfo.CustomerClass<> 5 ";
            }
            else if (Flag == 1 && CustomerClass == 10)
            {
                str += "and CustomerInfo.CustomerClass<> 5 ";
            }
            else
            {
                str += "and CustomerInfo.CustomerClass= '" + CustomerClass + "' ";
            }

            if (FromData != "请选择" && FromData != "来源为空")
            {
                str += "and CustomerInfo.FromData= '" + FromData + "' ";
            }

            if (ConsultantStaffID != 0)
            {
                str += "and AssignState.GStaffID='" + ConsultantStaffID + "' and AssignState.AssignStatus=1 ";
            }

            if (CopywriterStaffID != 0)
            {
                str += "and AssignState.GStaffID='" + CopywriterStaffID + "' and AssignState.AssignStatus=2 ";
            }

            if(authority==8)
            {
                if (AssignStatus == 1)
                {
                    str += "and AssignState.GStaffID='" + StaffID + "' ";
                }
                else if (AssignStatus == 2)
                {
                    str += " and AssignState.DStaffID='" + StaffID + "' ";
                }
            }
            if (authority == 7)
            {
                str += "and AssignState.GStaffID='" + StaffID + "' ";
            }
            if (Flag == 0)
            {
                str += " and CustomerInfo.CustomerImportance<>0 ";
            }
            str += "order by CustomerInfo.CustomerImportance DESC,AssignState.AssignTime DESC ";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }
        public DataSet GetCustomerAssignInfo()
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "CustomerInfo.CustomerID";
            str += ",";
            str += "CustomerInfo.CustomerName ";
            str += ",";
            str += "Sex=case CustomerInfo.Sex when 0 then '男' when 1 then '女' end";
            str += ",";
            str += "CustomerInfo.Telphone ";
            str += ",";
            str += "CustomerImportance=case CustomerInfo.CustomerImportance when 0 then '不重要' when 1 then '一般' when 2 then '重要' when 3 then '特别重要' end";
            str += ",";
            str += "CustomerClass=case CustomerInfo.CustomerClass when 0 then '未分类' when 1 then '短期潜在' when 2 then '长期潜在' when 3 then '意向不明' when 4 then '已经签约' when 5 then '已经流失' end";
            str += ",";
            str += "CustomerInfo.Grade ";
            str += ",";
            str += "Intention.IntentionCountry ";
            str += ",";
            str += "StaffInfo.StaffName ";
            str += ",";
            str += "AssignStatus=case AssignState.AssignStatus when 0 then '新导入' when 1 then '顾问跟进' when 2 then '文案跟进' when 3 then '文案搁置' when 4 then '案件归档' when 5 then '案件退案' end";
            str += ",";
            str += "CustomerInfo.CityInitial ";
            str += "from ";
            str += "CustomerInfo left join AssignState on CustomerInfo.CustomerID=AssignState.CustomerID left join StaffInfo on AssignState.GStaffID=StaffInfo.StaffID left join Intention on CustomerInfo.CustomerID=Intention.CustomerID  ";
            str += "order by CustomerInfo.CustomerImportance DESC,AssignState.AssignTime DESC ";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }
        public void UpdateAssignState(int DStaffID, int GStaffID, int AssignState, string Remark,int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Update AssignState set DStaffID=" + DStaffID + ",";
            if (GStaffID == 0)
            {
                str += "GStaffID=null,";
            }
            else
            {
                if (AssignState == 3 || AssignState == 5)
                {
                    str += "GStaffID=null,";
                }
                else
                {
                    str += "GStaffID=" + GStaffID + ",";
                }
            }
            str += "AssignStatus=" + AssignState + ",";
            str += "AssignTime='" + DateTime.Now + "',";
            str += "Remark='" + Remark + "'";
            str += " where AssignState.CustomerID=" + CustomerID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public DataSet GetIntentionCountry()
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select distinct  IntentionCountry from  Intention where  (Intention.IntentionCountry!='' or Intention.IntentionCountry<>NULL) ";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;

        }

        public DataSet GetFollowupConsultant()
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select distinct staffID,StaffName from  StaffInfo where (PostID=6 or PostID=7 or PostID=8 or PostID=9 or PostID=1) ";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;

        }

        public DataSet CheckBind(int CustomerID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select AssignState.AssignStatus from AssignState where AssignState.CustomerID='" + CustomerID+"'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetCopywtiter()
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select distinct staffID,StaffName from  StaffInfo where (PostID=1 or PostID=2 or PostID=3 or PostID=4) ";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;

        }

        public DataSet GetFromData()
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select distinct FromData from CustomerInfo where FromData!='' and  FromData!='NULL'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;

        }

        public DataSet GetCustomerNowAssignState(int CustomerID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "Select CustomerInfo.CustomerID,CustomerInfo.CustomerName, AssignState.AssignStatus from AssignState join CustomerInfo on CustomerInfo.CustomerID=AssignState.CustomerID where AssignState.CustomerID=" + CustomerID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetImportingPeople()
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select distinct StaffInfo.StaffID,StaffInfo.StaffName from StaffInfo join CustomerInfo on StaffInfo.StaffName=CustomerInfo.ImportingPeople";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetContractIDbyCustomerID(int CustomerID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select CustomerInfo.CustomerName,Financial.ContractID from CustomerInfo left join Financial on Financial.CustomerID=CustomerInfo.CustomerID where CustomerInfo.CustomerID=" + CustomerID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }


        


        public void InsertAssignState(int DStaffID, int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Insert into AssignState ";
            str += "(";
            str += "DStaffID,";
            str += "AssignStatus,";
            str += "AssignTime,";
            str += "CustomerID)";
            str += " values (";
            str += DStaffID+",";
            str += "0,";
            str += "'" + DateTime.Now.ToString() + "',";
            str += CustomerID + ")";
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }


        public DataSet GetCustomerIDNamebyStaffID(int StaffID)
        {
            DataSet ds = new DataSet();
            DbHelper db = new DbHelper();
            string str = "";
            str += "select AssignState.CustomerID,CustomerInfo.CustomerName from AssignState join CustomerInfo on AssignState.CustomerID=CustomerInfo.CustomerID where AssignState.GstaffID='" + StaffID + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

    }
}
