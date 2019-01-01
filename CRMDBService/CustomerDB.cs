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
    public class CustomerDB
    {
        #region 全局声明参数
        //声明参数
        DbHelper dbh = null;
        DataSet dst = null;
        CustomerInfo myCTI = null;        
        #endregion
        #region 构造函数
        /// <summary>
        /// CustomerDB 类的构造函数
        /// </summary>
        public CustomerDB()
        {
            //实例化参数
            dbh = new DbHelper();
            dst = new DataSet();
            myCTI = new CustomerInfo();           
        }
        #endregion
        public DataSet GetCustomerNamebyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "CustomerInfo.CustomerID";
            str += ",";
            str += "CustomerInfo.CustomerName";
            str += " from";
            str += " CustomerInfo";
            str += " where";
            str += " CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }
        #region 获取客户基本信息无参
        /// <summary>
        /// 获取客户基本信息无参
        /// </summary>
        /// <param name="CustomerID">客户ID int类型</param>
        /// <returns>返回dst Dataset类型</returns>
        public DataSet GetCustomerInformation()
        {
            string SqlQuery = string.Empty;
            SqlQuery += "select ";
            SqlQuery += "[CustomerID]";
            SqlQuery += ",[CustomerName]";
            SqlQuery += ",[EnglishName]";
            SqlQuery += ",[Sex]";
            SqlQuery += ",[Birthday]";
            SqlQuery += ",[Age]";
            SqlQuery += ",[Phone]";
            SqlQuery += ",[TelPhone]";
            SqlQuery += ",[BackUpTel]";
            SqlQuery += ",[CProvince]";
            SqlQuery += ",[CCity]";
            SqlQuery += ",[CAddress]";
            SqlQuery += ",[CQQ]";
            SqlQuery += ",[Cemail]";
            SqlQuery += ",[OtherContact]";
            SqlQuery += ",[OtherContactPhone]";
            SqlQuery += ",[CustomerImportance]";
            SqlQuery += ",[Policymaker]";
            SqlQuery += ",[PolicymakerName]";
            SqlQuery += ",[CustomerClass]";
            SqlQuery += ",[DrainTowards]";
            SqlQuery += ",[ImportingPeople]";
            SqlQuery += ",[ImportingDate]";
            SqlQuery += ",[Sname]";
            SqlQuery += ",[Grade]";
            SqlQuery += ",[ProfessionName]";
            SqlQuery += ",[AdmissionCountry]";
            SqlQuery += ",[AdmissionCity]";
            SqlQuery += ",[AdmissionSname]";
            SqlQuery += ",[AdmissionProfessionName]";
            SqlQuery += ",[AdmissionDate]";
            SqlQuery += ",[Remark]";
            SqlQuery += ",[CityInitial]";
            SqlQuery += ",[CustomerFrom]";
            SqlQuery += ",[FromData]";
            SqlQuery += ",[Reference]";
            SqlQuery += ",[ReferenceRemark]";
            SqlQuery += ",[ContractNum]";
            SqlQuery += ",[CustomerImprove]";
            SqlQuery += ",[WorkExperience]";
            SqlQuery += " from";
            SqlQuery += " CustomerInfo";
            DbCommand cmd = dbh.GetSqlStringCommond(SqlQuery);
            return dbh.ExecuteDataSet(cmd);
        }
        #endregion
        #region 获取客户基本信息有参
        /// <summary>
        /// 获取客户基本信息有参
        /// </summary>
        /// <param name="CustomerID">客户ID int类型</param>
        /// <returns>返回dst Dataset类型</returns>
        public DataSet GetCustomerInformation(int CustomerID)
        {
            string SqlQuery = string.Empty;
            SqlQuery += "select ";
            SqlQuery += "[CustomerID]";
            SqlQuery += ",[CustomerName]";
            SqlQuery += ",[EnglishName]";
            SqlQuery += ",[Sex]";
            SqlQuery += ",[Birthday]";
            SqlQuery += ",[Age]";
            SqlQuery += ",[Phone]";
            SqlQuery += ",[TelPhone]";
            SqlQuery += ",[BackUpTel]";
            SqlQuery += ",[CProvince]";
            SqlQuery += ",[CCity]";
            SqlQuery += ",[CAddress]";
            SqlQuery += ",[CQQ]";
            SqlQuery += ",[Cemail]";
            SqlQuery += ",[OtherContact]";
            SqlQuery += ",[OtherContactPhone]";
            SqlQuery += ",[CustomerImportance]";
            SqlQuery += ",[Policymaker]";
            SqlQuery += ",[PolicymakerName]";
            SqlQuery += ",[CustomerClass]";
            SqlQuery += ",[DrainTowards]";
            SqlQuery += ",[ImportingPeople]";
            SqlQuery += ",[ImportingDate]";
            SqlQuery += ",[Sname]";
            SqlQuery += ",[Grade]";
            SqlQuery += ",[ProfessionName]";
            SqlQuery += ",[AdmissionCountry]";
            SqlQuery += ",[AdmissionCity]";
            SqlQuery += ",[AdmissionSname]";
            SqlQuery += ",[AdmissionProfessionName]";
            SqlQuery += ",[AdmissionDate]";
            SqlQuery += ",[Remark]";
            SqlQuery += ",[CityInitial]";
            SqlQuery += ",[CustomerFrom]";
            SqlQuery += ",[FromData]";
            SqlQuery += ",[Reference]";
            SqlQuery += ",[ReferenceRemark]";
            SqlQuery += ",[ContractNum]";
            SqlQuery += ",[CustomerImprove]";
            SqlQuery += ",[WorkExperience]";
            SqlQuery += " from";
            SqlQuery += " CustomerInfo";
            SqlQuery += " where";
            SqlQuery += " CustomerID='" + CustomerID + "'";
            DbCommand cmd = dbh.GetSqlStringCommond(SqlQuery);
            return dbh.ExecuteDataSet(cmd);
        }
        #endregion


        public DataSet GetImportanceIntroduction()
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "* ";
            str += " from";
            str += " ImportanceIntroduction";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetMainIntentionCountryByID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "Intention.IntentionCountry";
            str += " from";
            str += " Intention";
            str += " where";
            str += " CustomerID='" + CustomerID + "'";
            str += " and Intention.BetterWantTo=0 ";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public void DeleteCustomerInfobyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From CustomerInfo ";
            sqlstr += " where CustomerInfo.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteContactStatebyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From ContactState ";
            sqlstr += " where ContactState.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteAssignStatebyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From AssignState ";
            sqlstr += " where AssignState.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteFamilyInfobyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From FamilyInfo ";
            sqlstr += " where FamilyInfo.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteIntentionbyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From Intention ";
            sqlstr += " where Intention.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteLanguageSkillsbyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From LanguageSkills ";
            sqlstr += " where LanguageSkills.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteLogInfobyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From LogInfo ";
            sqlstr += " where LogInfo.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteRemindInfobyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From RemindInfo ";
            sqlstr += " where RemindInfo.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteSchoolRankInfobyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Delete ";
            sqlstr += " From SchoolRankInfo ";
            sqlstr += " where SchoolRankInfo.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void UpdateUnBandImportancebyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Update ";
            sqlstr += " CustomerInfo ";
            sqlstr += " set CustomerInfo.CustomerImportance=0 where CustomerInfo.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }

        public void UpdateUnBandAssignbyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Update ";
            sqlstr += " AssignState ";
            sqlstr += " set AssignState.AssignStatus=0,GStaffID=0 where AssignState.CustomerID='" + CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }


        #region 客户数据来源
        /// <summary>
        /// 客户数据来源
        /// </summary>
        /// <param name="CustomerID">客户ID int类型</param>
        /// <returns>返回dst Dataset类型</returns>
        public DataSet GetCustomerDataFrom(int CustomerID)
        {
            string SqlQuery = string.Empty;
            SqlQuery += "[CFID]";
            SqlQuery += ",[CustomerID]";
            SqlQuery += ",[CustomerFrom]";
            SqlQuery += ",[FromRemark]";           
            SqlQuery += ",[Reference]";
            SqlQuery += ",[FromData]";
            SqlQuery += ",[Remark]";            
            SqlQuery += " from";
            SqlQuery += " [CustomerFrom]";
            SqlQuery += " where";
            SqlQuery += " CustomerID='" + CustomerID + "'";
            DbCommand cmd = dbh.GetSqlStringCommond(SqlQuery);
            return dbh.ExecuteDataSet(cmd);
        }
        #endregion
        #region 根据客户ID搜索客户信息
        /// <summary>
        /// 根据客户ID和城市首字母搜索客户信息
        /// </summary>
        /// <param name="CustomerID">客户编号</param>
        /// <param name="CityInitial">客户来自城市</param>
        /// <returns>返回客户相关的信息</returns>
        public DataSet GetCustomerInfobyIDCity(int CustomerID, string CityInitial)
        {
            //DbHelper db = new DbHelper();
            //string sqlstr = "";
            //sqlstr += "Select * from CustomerInfo ";
            //sqlstr += "where CustomerID=" + CustomerID;
            //sqlstr += " and CityInitial='" + CityInitial + "'";
            //DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            //DataSet ds = db.ExecuteDataSet(cmd);

            string SqlQuery = string.Empty;
            #region 备用
            //SqlQuery += "select ";
            //SqlQuery += "k.*,B.IntentionCountry from ( ";
            //SqlQuery += "select top 1 (ContactState.CSDate) as LatestTime ";
            //SqlQuery += ",Customerinfo.[CustomerID]";
            //SqlQuery += ",[CustomerName]";
            //SqlQuery += ",[EnglishName]";
            //SqlQuery += ",[Sex]";
            //SqlQuery += ",CustomerInfo.[Birthday]";
            //SqlQuery += ",[Age]";
            //SqlQuery += ",Customerinfo.[Phone]";
            //SqlQuery += ",CustomerInfo.[TelPhone]";
            //SqlQuery += ",[BackUpTel]";
            //SqlQuery += ",[CProvince]";
            //SqlQuery += ",[CCity]";
            //SqlQuery += ",[CAddress]";
            //SqlQuery += ",[CQQ]";
            //SqlQuery += ",[Cemail]";
            //SqlQuery += ",[OtherContact]";
            //SqlQuery += ",[OtherContactPhone]";
            //SqlQuery += ",[CustomerImportance]";
            //SqlQuery += ",[Policymaker]";
            //SqlQuery += ",[PolicymakerName]";
            //SqlQuery += ",[CustomerClass]";
            //SqlQuery += ",[DrainTowards]";
            //SqlQuery += ",[ImportingPeople]";
            //SqlQuery += ",[ImportingDate]";
            //SqlQuery += ",[Sname]";
            //SqlQuery += ",[Grade]";
            //SqlQuery += ",[ProfessionName]";
            //SqlQuery += ",[AdmissionCountry]";
            //SqlQuery += ",[AdmissionCity]";
            //SqlQuery += ",[AdmissionSname]";
            //SqlQuery += ",[AdmissionProfessionName]";
            //SqlQuery += ",[AdmissionDate]";
            //SqlQuery += ",Customerinfo.[Remark]";
            //SqlQuery += ",[CityInitial]";
            //SqlQuery += ",[CustomerFrom]";
            //SqlQuery += ",[FromData]";
            //SqlQuery += ",[Reference]";
            //SqlQuery += ",[ReferenceRemark]";
            //SqlQuery += ",StaffInfo.StaffName";
            //SqlQuery += " from";
            //SqlQuery += " CustomerInfo left join AssignState on CustomerInfo.CustomerID=AssignState.CustomerID left join StaffInfo on StaffInfo.StaffID=AssignState.GStaffID right join ContactState on CustomerInfo.CustomerID=ContactState.CustomerID ";
            //SqlQuery += " where";
            //SqlQuery += " CustomerInfo.CustomerID=" + CustomerID;
            //SqlQuery += " and CityInitial='" + CityInitial + "' order by CSDate DESC ) k  left join (select * from Intention where Intention.BetterWantTo=0) B on k.CustomerID=B.CustomerID";
            //DbCommand cmd = dbh.GetSqlStringCommond(SqlQuery);
            //return dbh.ExecuteDataSet(cmd);
            #endregion 备用
            SqlQuery += "select ";
            SqlQuery += "[CustomerID]";
            SqlQuery += ",[CustomerName]";
            SqlQuery += ",[EnglishName]";
            SqlQuery += ",[Sex]";
            SqlQuery += ",[Birthday]";
            SqlQuery += ",[Age]";
            SqlQuery += ",[Phone]";
            SqlQuery += ",[TelPhone]";
            SqlQuery += ",[BackUpTel]";
            SqlQuery += ",[CProvince]";
            SqlQuery += ",[CCity]";
            SqlQuery += ",[CAddress]";
            SqlQuery += ",[CQQ]";
            SqlQuery += ",[Cemail]";
            SqlQuery += ",[OtherContact]";
            SqlQuery += ",[OtherContactPhone]";
            SqlQuery += ",[CustomerImportance]";
            SqlQuery += ",[Policymaker]";
            SqlQuery += ",[PolicymakerName]";
            SqlQuery += ",[CustomerClass]";
            SqlQuery += ",[DrainTowards]";
            SqlQuery += ",[ImportingPeople]";
            SqlQuery += ",[ImportingDate]";
            SqlQuery += ",[Sname]";
            SqlQuery += ",[Grade]";
            SqlQuery += ",[ProfessionName]";
            SqlQuery += ",[AdmissionCountry]";
            SqlQuery += ",[AdmissionCity]";
            SqlQuery += ",[AdmissionSname]";
            SqlQuery += ",[AdmissionProfessionName]";
            SqlQuery += ",[AdmissionDate]";
            SqlQuery += ",[Remark]";
            SqlQuery += ",[CityInitial]";
            SqlQuery += ",[CustomerFrom]";
            SqlQuery += ",[FromData]";
            SqlQuery += ",[Reference]";
            SqlQuery += ",[ReferenceRemark]";
            SqlQuery += ",[ContractNum]";
            SqlQuery += ",[CustomerImprove]";
            SqlQuery += ",[WorkExperience]";
            SqlQuery += ",[IntentionCountry]";
            SqlQuery += ",[StaffName]";
            SqlQuery += ",[LatestTime]";
            SqlQuery += " from";
            SqlQuery += " view_Search_Customer_infor";           
            SqlQuery += " where";
            SqlQuery += " CustomerID=" + CustomerID;
            SqlQuery += " and CityInitial='" + CityInitial + "'";
            DbCommand cmd = dbh.GetSqlStringCommond(SqlQuery);
            return dbh.ExecuteDataSet(cmd);
        }
        #endregion


        #region 根据用户选择的搜索条件搜索客户信息
        /// <summary>
        /// 根据搜索条件搜索客户信息
        /// </summary>
        /// <param name="cName">客户中文名字</param>
        /// <param name="eName">客户英文名字</param>
        /// <param name="cImportantce">客户重要性</param>
        /// <param name="cClass">客户分类</param>
        /// <param name="cFrom">客户来源</param>
        /// <param name="cProvince">客户省份</param>
        /// <param name="cCity">客户城市</param>
        /// <param name="cCityLetter">城市首字母</param>
        /// <returns>客户信息</returns>
        public DataSet GetCustomerInfoBySearchCondition(string cName, string eName, int cImportantce, int cClass, string dataFrom, string cProvince, string cCity, string cIntentionCountry, string ImportingPeople, string GStaffName, string WStaffName, string Cellphone, string BackUpTel,bool IsNonefollow,string StartDate,string EndDate,string ContractNum,int CustomerImprove)
        {
            string SqlQuery = string.Empty;
            SqlQuery += "select ";
            SqlQuery += "[CustomerID]";
            SqlQuery += ",[CustomerName]";
            SqlQuery += ",[EnglishName]";
            SqlQuery += ",[Sex]";
            SqlQuery += ",[Birthday]";
            SqlQuery += ",[Age]";
            SqlQuery += ",[Phone]";
            SqlQuery += ",[TelPhone]";
            SqlQuery += ",[BackUpTel]";
            SqlQuery += ",[CProvince]";
            SqlQuery += ",[CCity]";
            SqlQuery += ",[CAddress]";
            SqlQuery += ",[CQQ]";
            SqlQuery += ",[Cemail]";
            SqlQuery += ",[OtherContact]";
            SqlQuery += ",[OtherContactPhone]";
            SqlQuery += ",[CustomerImportance]";
            SqlQuery += ",[Policymaker]";
            SqlQuery += ",[PolicymakerName]";
            SqlQuery += ",[CustomerClass]";
            SqlQuery += ",[DrainTowards]";
            SqlQuery += ",[ImportingPeople]";
            SqlQuery += ",[ImportingDate]";
            SqlQuery += ",[Sname]";
            SqlQuery += ",[Grade]";
            SqlQuery += ",[ProfessionName]";
            SqlQuery += ",[AdmissionCountry]";
            SqlQuery += ",[AdmissionCity]";
            SqlQuery += ",[AdmissionSname]";
            SqlQuery += ",[AdmissionProfessionName]";
            SqlQuery += ",[AdmissionDate]";
            SqlQuery += ",[Remark]";
            SqlQuery += ",[CityInitial]";
            SqlQuery += ",[CustomerFrom]";
            SqlQuery += ",[FromData]";
            SqlQuery += ",[Reference]";
            SqlQuery += ",[ReferenceRemark]";
            SqlQuery += ",[ContractNum]";
            SqlQuery += ",[CustomerImprove]";
            SqlQuery += ",[WorkExperience]";
            SqlQuery += ",[IntentionCountry]";
            SqlQuery += ",[StaffName]";
            
            SqlQuery += ",[LatestTime]";
            SqlQuery += ",[ContractNum]";
            SqlQuery += ",[CustomerImprove]";
            SqlQuery += ",[WorkExperience]";
      
            SqlQuery += " from";
           
            SqlQuery += " view_Search_Customer_infor";
            
            SqlQuery += " where 1=1";
            if (cName != "0")
            {
                SqlQuery += " and CustomerName like '%" + cName + "%'";
            }
            if (eName != "0")
            {
                SqlQuery += " and EnglishName like '%" + eName + "%'";
            }
            if (cImportantce > 0)
            {
                SqlQuery += " and CustomerImportance=" + cImportantce;
            }
            if (cClass > -1)
            {
                SqlQuery += " and CustomerClass=" + cClass;
            }
            if (dataFrom != "0")
            {
                if (dataFrom != "2")
                {
                    SqlQuery += " and FromData like '%" + dataFrom + "%'";
                }
                else
                {
                    SqlQuery += " and FromData= ' ' "; 
                }
            }

            if (cProvince != "0")
            {
                SqlQuery += " and CProvince='" + cProvince + "'";
            }
            if (cCity != "0")
            {
                SqlQuery += " and CCity='" + cCity + "'";
            }
            if (cIntentionCountry != "0")
            {
                SqlQuery += " and IntentionCountry like '%" + cIntentionCountry + "%'";
            }
            if (ImportingPeople != "0")
            {
                SqlQuery += " and ImportingPeople like '%" + ImportingPeople + "%'";
            }
            if (GStaffName != "0")
            {
                SqlQuery += " and StaffName like '%" + GStaffName + "%'" + " and (PostID=6 or PostID=7 or PostID=8 or PostID=9) and AssignStatus=1 ";
            }
            if (WStaffName != "0")
            {
                SqlQuery += " and StaffName like '%" + WStaffName + "%'" + " and (PostID=2 or PostID=3 or PostID=4) and  AssignStatus=2 ";
            }
            if (Cellphone != "0")
            {
                SqlQuery += " and TelPhone='" + Cellphone + "'";
            }
            if (BackUpTel != "0")
            {
                SqlQuery += " and BackUpTel='" + BackUpTel + "'";
            }
            if (IsNonefollow == true)
            {
                SqlQuery += " and  " + "(CustomerID NOT IN" + "(" + "select customerID from LatestFollowUp)" + ")";
            }
            if (StartDate != "" && EndDate != "")
            {
                SqlQuery += " and (intentiondate>='" + StartDate + "' and intentiondate<='" + EndDate+"')";
            }
            else if(StartDate=="" && EndDate != "")
            {
                SqlQuery += " and (intentiondate<='" + EndDate+"')";
            }
            else if (StartDate != "" && EndDate == "")
            {
                SqlQuery += " and (intentiondate>='" + StartDate + "')";
            }
            if (ContractNum != "0")
            {
                SqlQuery += " and ContractNum='" + ContractNum + "'";
            }
            if (CustomerImprove > 0)
            {
                SqlQuery += " and CustomerImprove=" + CustomerImprove;
            }
            DbCommand cmd = dbh.GetSqlStringCommond(SqlQuery);
            return dbh.ExecuteDataSet(cmd);
        }
        #endregion
    }
}
