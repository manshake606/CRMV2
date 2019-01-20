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

    

    public class CustomerService
    {
        #region 声明全局参数
        //声明参数
        CustomerDB CDB = null;
        DataSet ds = null;
        CRMDBService.LogInfoDB LDB = new LogInfoDB();
        #endregion
        #region 构造函数
        /// <summary>
        /// CustomerService 类的构造函数
        /// </summary>
        public CustomerService()
        {
            //实例参数
            CDB = new CustomerDB();
            ds = new DataSet();
        }
        #endregion
        public DataSet GetCustomerNamebyCustomerID(int CustomerID)
        {
            //CustomerDB CDB = new CustomerDB();
            ds = CDB.GetCustomerNamebyCustomerID(CustomerID);
            //DataSet ds = CDB.GetCustomerNamebyCustomerID(CustomerID);
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
            CustomerDB CDB = new CustomerDB();
            ds = CDB.GetCustomerInformation();
            return ds;
        }
        #endregion
        #region 获取客户基本信息有参
        /// <summary>
        /// 获取客户基本信息
        /// </summary>
        /// <param name="CustomerID">客户ID int类型</param>
        /// <returns>返回dst Dataset类型</returns>
        public DataSet GetCustomerInformation(int CustomerID)
        {
            ds = CDB.GetCustomerInformation(CustomerID);
            return ds;
        }
        #endregion
        #region 获取客户基本信息
        /// <summary>
        /// 获取客户基本信息
        /// </summary>
        /// <param name="CustomerID">客户ID int类型</param>
        /// <returns>返回dst Dataset类型</returns>
        public DataSet GetCustomerDataFrom(int CustomerID)
        {
            ds = CDB.GetCustomerDataFrom(CustomerID);
            return ds;
        }
        #endregion


        public DataSet GetImportanceIntroduction_Service()
        {
            ds = CDB.GetImportanceIntroduction();
            return ds;
        }

        public DataSet GetCustomerNamebyCustomerIDOrName_Service(int CustomerID,string CustomerName)
        {
            ds = CDB.GetCustomerNamebyCustomerIDOrName(CustomerID, CustomerName);
            return ds;
        }



        #region 根据客户ID搜索客户信息
        /// <summary>
        /// 根据客户ID搜索客户信息
        /// </summary>
        /// <param name="CustomerID">客户编号</param>
        /// <param name="CityInitial">客户来自城市</param>
        /// <returns>返回客户相关的信息</returns>
        public DataSet GetCustomerInfobyIDCityService(int CustomerID, string CityInitial)
        {
            //CRMDBService.LogInfoDB logdb = new LogInfoDB();
            //DataSet ds = logdb.GetCustomerInfobyIDCity(CustomerID, CityInitial);           
            ds = CDB.GetCustomerInfobyIDCity(CustomerID, CityInitial);
            return ds;
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
        public DataSet GetCustomerInfoBySearchCondition(string cName, string eName, int cImportantce, int cClass, string dataFrom, string cProvince, string cCity, string cIntentionCountry, string ImportingPeople, string GStaffName, string WStaffName, string Cellphone, string BackUpTel,bool isNonefollow,string StartDate,string EndDate,string ContractNum,int CustomerImprove)
        {
            ds = CDB.GetCustomerInfoBySearchCondition(cName, eName, cImportantce, cClass, dataFrom, cProvince, cCity, cIntentionCountry, ImportingPeople, GStaffName, WStaffName, Cellphone, BackUpTel, isNonefollow, StartDate, EndDate, ContractNum, CustomerImprove);
            return ds;
        }
        #endregion


        public DataSet GetMainIntentionCountryByID_Service(int CustomerID)
        {
            ds = CDB.GetMainIntentionCountryByID(CustomerID);
            return ds;
        }

        public int doBatchDelete(int CustomerID)
        {
            int Error = 0;
            Trans t = new Trans();
            try
            {
                CDB.DeleteCustomerInfobyCustomerID(CustomerID);
                CDB.DeleteAssignStatebyCustomerID(CustomerID);
                CDB.DeleteContactStatebyCustomerID(CustomerID);
                CDB.DeleteFamilyInfobyCustomerID(CustomerID);
                CDB.DeleteIntentionbyCustomerID(CustomerID);
                CDB.DeleteLanguageSkillsbyCustomerID(CustomerID);
                CDB.DeleteRemindInfobyCustomerID(CustomerID);
                CDB.DeleteSchoolRankInfobyCustomerID(CustomerID);
                CDB.DeleteLogInfobyCustomerID(CustomerID);
                t.Commit();
            }
            catch
            {
                Error = 1;
                t.RollBack();
            }
            return Error;
        }

        public int doUnBand(int CustomerID, int StaffID)
        {
            int Error = 0;
            Trans t = new Trans();
            try
            {
                CDB.UpdateUnBandImportancebyCustomerID(CustomerID);
                CDB.UpdateUnBandAssignbyCustomerID(CustomerID);
                LDB.InsertLogInfo(StaffID, CustomerID, 0, 0, "");
                t.Commit();
            }
            catch
            {
                Error = 1;
                t.RollBack();
            }
            return Error;
        }
    }
}
